using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchetPractica
{
    public partial class Students : Form
    {
        int selectStudId = -1;
        int selectGroupId = -1;
        bool addRed;
        bool isGroup = true;
        bool colStud = false;
        bool colGroup = false;
        int showGroupId = -1;
        string showGroupNum = "";

        public Students()
        {
            InitializeComponent();
        }

        public static int GetCourse(string groupNum)
        {
            int cours = 0; ;
            try
            {
                string num = groupNum[1].ToString();
                int numOfYear = Convert.ToInt32(num);
                DateTime time = DateTime.Today;//Вычисление курса группы
                int year = time.Year % 10;
                DateTime sept = new DateTime(time.Year, 9, 1);
                if (time < sept)
                {
                    if (numOfYear < year)
                    {
                        cours = year - numOfYear;
                    }
                    else if (numOfYear > year)
                    {
                        cours = (10 - numOfYear) + year;
                    }
                    else
                    {
                        cours = 0;
                    }
                }
                else
                {
                    if (numOfYear < year)
                    {
                        cours = year - numOfYear + 1;
                    }
                    else if (numOfYear > year)
                    {
                        cours = (10 - numOfYear) + year + 1;
                    }
                    else
                    {
                        cours = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cours;

        }

        private void StudentsShowData()
        {
            dataGridView1.DataSource = null;

            string sqlStudents = String.Format("SELECT S.Id, S.Name, S.Surname, " +
                "S.Patronymic, G.GroupNumber, S.Status " +
                "FROM Students AS S " +
                "INNER JOIN Groups AS G ON S.GroupId = G.Id " +
                "WHERE S.GroupId=N'{0}'", showGroupId);

            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStudents, connect);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                SqlCommand command = new SqlCommand(sqlStudents, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    colStud = true;
                }
                else
                {
                    colStud = false;
                }
            }
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Номер группы";
            dataGridView1.Columns[5].HeaderText = "Статус";

            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;
        }

        private void GroupsShowData(string sqlGroups = "SELECT Id, GroupNumber, " +
            "Specialty, Cours, StudentsCount, Code, Status " +
            "FROM Groups WHERE Cours <= 4 AND Status=N'Обучается'")
        {
            dataGridView1.DataSource = null;

            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlGroups, connect);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                SqlCommand command = new SqlCommand(sqlGroups, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    colGroup = true;
                }
                else
                {
                    colGroup = false;
                }
            }
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Номер группы";
            dataGridView1.Columns[2].HeaderText = "Специальность";
            dataGridView1.Columns[3].HeaderText = "Курс";
            dataGridView1.Columns[4].HeaderText = "Количество студентов";
            dataGridView1.Columns[5].HeaderText = "Код группы";
            dataGridView1.Columns[6].HeaderText = "Статус";


            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 120;
        }
        private void CountStuds()
        {
            //получение id всех групп
            int l = 0;
            int[] grId = new int[0];
            string sqlGroups = "SELECT * FROM Groups";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlGroups, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    l++;
                    Array.Resize(ref grId, l);
                    grId[l - 1] = reader.GetInt32(0);
                }
            }

            
            for(int i = 0;i< grId.Length; i++)
            {
                //расчет кол-ва студентов
                int studCount = 0;
                string sqlAllStuds = String.Format("SELECT * FROM Students WHERE GroupId = N'{0}'", grId[i]);
                using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                {
                    connection.Open();
                    SqlCommand sql = new SqlCommand(sqlAllStuds, connection);
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        studCount++;
                    }
                }

                //Обновление кол-ва студентов в группах
                string sqlEditStudCount = String.Format("UPDATE Groups SET StudentsCount = '{0}' " +
                        " WHERE Id = '{1}'", studCount, grId[i]);
                using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlEditStudCount, connection);
                    int h = command.ExecuteNonQuery();
                }
            }
        }

        private int GetCountStuds()
        {
            //расчет кол-ва студентов
            int studCount = 0;
            string sqlAllStuds = String.Format("SELECT * FROM Students WHERE GroupId = N'{0}'", showGroupId);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlAllStuds, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    studCount++;
                }
            }

            //Обновление кол-ва студентов в группах
            string sqlEditStudCount = String.Format("UPDATE Groups SET StudentsCount = '{0}' " +
                    " WHERE Id = '{1}'", studCount, showGroupId);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlEditStudCount, connection);
                int h = command.ExecuteNonQuery();
            }
            return 0;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bAddShow_Click(object sender, EventArgs e)//При нажатии добавления
        {
            addRed = true;

            if (isGroup)
            {
                pStud.Visible = false;
                pGroup.Visible = true;

                tbGroupNum.Text = "";
                tbSpecialty.Text = "";
                tbGroupCode.Text = "";
                cbStatusGroup.SelectedIndex = 0;
            }
            else
            {
                pStud.Visible = true;
                pGroup.Visible = false;

                tbName.Text = "";
                tbSurname.Text = "";
                tbPatr.Text = "";
                tbGrNum.Text = showGroupNum;
                cbStatusStud.SelectedIndex = 0;
            }
        }

        private void bCancelShow_Click(object sender, EventArgs e)
        {
            pStud.Visible = false;

            tbName.Text = "";
            tbSurname.Text = "";
            tbPatr.Text = "";
            tbGrNum.Text = "";
        }

        private void Students_Load(object sender, EventArgs e)
        {
            GroupsShowData();
        }

        private void bEditShow_Click(object sender, EventArgs e)
        {
            addRed = false;
            if (isGroup)
            {
                if (colGroup)
                {
                    selectGroupId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    if (selectGroupId > 0)
                    {
                        pStud.Visible = false;
                        pGroup.Visible = true;

                        string groupNumber = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                        string specialty = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                        string groupCode = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                        string status = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);

                        tbGroupNum.Text = groupNumber;
                        tbSpecialty.Text = specialty;
                        tbGroupCode.Text = groupCode;
                        cbStatusGroup.Text = status;
                    }
                    else
                    {
                        MessageBox.Show("Выберите группу для исправления!");
                        pGroup.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для изменения");
                }
            }
            else
            {
                if (colStud)
                {
                    selectStudId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    if (selectStudId > 0)
                    {
                        pGroup.Visible = false;
                        pStud.Visible = true;
                        string name = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                        string surname = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                        string patr = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                        string status = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);

                        tbGrNum.Text = showGroupNum;
                        tbName.Text = name;
                        tbSurname.Text = surname;
                        tbPatr.Text = patr;
                        cbStatusStud.Text = status;
                    }
                    else
                    {
                        MessageBox.Show("Выберите студента для исправления!");
                        pStud.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для изменения");
                }
            }
        }

        private void bEnterShow_Click(object sender, EventArgs e)
        {
            if(tbName.Text.Length < 2)
            {
                MessageBox.Show("Имя слишком короткое!");
            }
            else if (tbSurname.Text.Length < 2)
            {
                MessageBox.Show("Фамилия слишком короткая!");
            }
            else if (tbPatr.Text.Length < 2)
            {
                MessageBox.Show("Отчество слишком короткое!");
            }
            else
            {
                string grName = showGroupNum;
                string groupId = showGroupId.ToString();
                string name = tbName.Text.Trim();
                string surname = tbSurname.Text.Trim();
                string patr = tbPatr.Text.Trim();
                string status = cbStatusStud.Text;
                if (addRed)//Добавление студента 
                {
                    bool haveSoStud = false;

                    string sqlProv = String.Format("SELECT * FROM Students WHERE " +
                    "GroupId='{0}' AND Name=N'{1}' AND Surname=N'{2}' AND Patronymic=N'{3}'", groupId, name,
                    surname, patr);

                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlProv, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Этот студент уже зарегистрирован в этой группе!");
                            haveSoStud = true;
                        }
                    }

                    if (!haveSoStud)
                    {
                        string sqlAddStud = String.Format("INSERT INTO Students " +
                            "(GroupId, Name, Surname,Patronymic,Status) " +
                            "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')"
                            , groupId, name, surname, patr, status);

                        using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand(sqlAddStud, connect);
                            int h = command.ExecuteNonQuery();
                            if (h == 0) MessageBox.Show("Error!!");
                            else MessageBox.Show("Добавлен новый студент в группу № " + grName + "!");
                        }
                        StudentsShowData();
                        pStud.Visible = false;
                        GetCountStuds();
                    }
                }
                else//Редактирование студента
                {
                    string sqlEditStud = String.Format("UPDATE Students SET GroupId = '{0}', " +
                        "Name = N'{1}', Surname = N'{2}', Patronymic = N'{3}', Status=N'{4}' " +
                        " WHERE Id = '{5}'", groupId, name, surname, patr, status, selectStudId);
                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlEditStud, connection);
                        int h = command.ExecuteNonQuery();
                        if (h > 0)
                        {
                            MessageBox.Show("Информация изменена");
                        }
                    }
                    StudentsShowData();
                    pStud.Visible = false;
                }
            }
        }

        private void bShowGroupCancel_Click(object sender, EventArgs e)
        {
            pGroup.Visible = false;

            tbGroupNum.Text = "";
            tbSpecialty.Text = "";
            tbGroupCode.Text = "";
        }

        private void bShowGroupEnter_Click(object sender, EventArgs e)
        {
            if (tbGroupNum.Text.Length < 2)
            {
                MessageBox.Show("Введите номер группы!");
            }
            else if (tbSpecialty.Text == "")
            {
                MessageBox.Show("Введите специальность группы!");
            }
            else if (tbGroupCode.Text == "")
            {
                MessageBox.Show("Введите код группы!");
            }
            else
            {
                string groupNumber = tbGroupNum.Text.Trim();
                string specialty = tbSpecialty.Text.Trim();
                int cours = GetCourse(tbGroupNum.Text.Trim());
                int studCount = 0;
                string groupCode = tbGroupCode.Text.Trim();
                string status = cbStatusGroup.Text;

                if (addRed)//Добавление группы 
                {
                    bool haveSoGroup = false;

                    string sqlProv = String.Format("SELECT * FROM Groups WHERE " +
                    "GroupNumber='{0}'", groupNumber);

                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlProv, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Эта группы уже зарегистрирована!");
                            haveSoGroup = true;
                        }
                    }

                    if (!haveSoGroup)
                    {
                        string sqlAddGroup = String.Format("INSERT INTO Groups " +
                            "(GroupNumber, Specialty, Cours, StudentsCount, Code, Status) " +
                            "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')"
                            , groupNumber, specialty, cours, studCount, groupCode, status);

                        using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand(sqlAddGroup, connect);
                            int h = command.ExecuteNonQuery();
                            if (h == 0) MessageBox.Show("Error!!");
                            else MessageBox.Show("Добавлена новая группа!");
                        }
                        GroupsShowData();
                        pGroup.Visible = false;
                    }
                }
                else//Редактирование группы
                {
                    string sqlEditStud = String.Format("UPDATE Groups SET GroupNumber = '{0}', " +
                        "Specialty = N'{1}', Code = N'{2}', Status = N'{3}'" +
                        " WHERE Id = '{4}'", 
                        groupNumber, specialty, groupCode, status, selectGroupId);
                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlEditStud, connection);
                        int h = command.ExecuteNonQuery();
                        if (h > 0)
                        {
                            MessageBox.Show("Информация изменена");
                        }
                    }
                    GroupsShowData();
                    pGroup.Visible = false;
                }
            } 
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (isGroup)//удаление группы
            {
                if (colGroup)
                {
                    selectGroupId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string grNum = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    string delStudCount = "0";
                    if (selectGroupId > 0)
                    {
                        DialogResult dr = MessageBox.Show("Вы уверены, что хотите удалить\n" +
                            "группу №" + grNum + " из базы данных?", "Подтверждение действия",
                            MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            string sqlDelGroup = String.Format("DELETE FROM Groups " +
                                        "WHERE Id = '{0}'", selectGroupId);
                            string sqlDelStudOfGroup = String.Format("DELETE FROM Students " +
                                        "WHERE GroupId = '{0}'", selectGroupId);

                            using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление студентов группы из бд
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlDelStudOfGroup, connection);
                                int number = command.ExecuteNonQuery();
                                if (number > 0)
                                {
                                    delStudCount = Convert.ToString(number);
                                }
                            }

                            using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlDelGroup, connection);
                                int number = command.ExecuteNonQuery();
                                if (number > 0)
                                {
                                    MessageBox.Show("Группа №" + grNum + " удалена из базы данных\n" +
                                        "Так же удалено " + delStudCount + " студента, входивших в состав группы");
                                    GroupsShowData();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите группу для удаления!");
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для удаления!");
                }
            }
            else//удаление студента
            {
                if (colStud)
                {
                    selectStudId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string name = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    string surname = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    if (selectStudId > 0)
                    {
                        DialogResult dr = MessageBox.Show("Вы уверены, что хотите удалить\n" +
                            name + " " + surname + " из базы данных?", "Подтверждение действия",
                            MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            string sqlDelStud = String.Format("DELETE FROM Students " +
                                        "WHERE Id = '{0}'", selectStudId);

                            using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlDelStud, connection);
                                int number = command.ExecuteNonQuery();
                                if (number > 0)
                                {
                                    MessageBox.Show("Студент " + name + " " + surname + " удален из базы данных");
                                    GetCountStuds();
                                    StudentsShowData();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите студента для удаления!");
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для удаления!");
                }
            }
            pGroup.Visible = false;
            pStud.Visible = false;
        }

        private void StudentsShow_Click(object sender, EventArgs e)
        {
            if (isGroup)
            {
                isGroup = false;
                if (colGroup)
                {
                    showGroupId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    if (showGroupId > 0)
                    {
                        showGroupNum = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                        lGroupNum.Text = "Отображаются студенты группы № " + showGroupNum;
                        lGroupNum.Visible = true;

                        StudentsShowData();
                        pStud.Visible = false;
                        pGroup.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Выберите группу студентов для отображения!");
                        pGroup.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Нет групп для отображения студентов");
                    showGroupId = -1;
                    isGroup = true;
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void GroupShow_Click(object sender, EventArgs e)
        {
            GroupsShowData();
            pStud.Visible = false;
            pGroup.Visible = false;
            isGroup = true;
            lGroupNum.Visible = false;
        }

        private void ExelExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlStatusGroup = String.Format("UPDATE Groups SET Status=N'Не обучается'");

            using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlStatusGroup, connection);
                int number = command.ExecuteNonQuery();
            }

            string sqlStatusStud = String.Format("UPDATE Students SET Status=N'Не обучается'");

            using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlStatusStud, connection);
                int number = command.ExecuteNonQuery();
            }

            DataTableCollection tableCollection;
            DialogResult dr = MessageBox.Show("При импорте все старые данные будут перезаписаны на новые\n" +
                "без возможности отмены действия.\n" +
                "Вы уверены, что хотите импортировать данные?", "Подтверждение действия", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                /*try
                {*/
                    string excelPath;
                    using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            excelPath = openFileDialog.FileName;
                            using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                            {
                                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                {
                                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                    {
                                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { }
                                    });
                                    tableCollection = result.Tables;
                                    foreach (DataTable table in tableCollection)
                                    {
                                        DataTable dt = tableCollection[table.TableName.ToString()];
                                        dataGridView2.DataSource = dt;
                                        string groupNum = "";//group info
                                        string groupCode = "";
                                        string groupSpecialty = "";
                                        bool haveSoGroup = false;
                                        int cours = 0;
                                        int newGroupId = -1;
                                        int oldGroupId = -1;
                                        int len = 0;

                                        bool excelControl = true;

                                        string name = "";//stud info
                                        string surname = "";
                                        string patr = "";
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {

                                            if (i == 0)
                                            {
                                                string num = dataGridView2[1, i].Value.ToString().Trim();
                                                int strIndex = num.IndexOf("№");
                                                num = num.Remove(0, strIndex + 2);
                                                groupNum = num.Trim();
                                                cours = GetCourse(groupNum);
                                            }
                                            else if (i == 1)
                                            {
                                                string Text = dataGridView2[1, i].Value.ToString().Trim();
                                                string[] words = Text.Split(' ');
                                                string spec = "";
                                                groupCode = words[0].Trim();
                                                for (int j = 1; j < words.Length; j++)
                                                {
                                                    spec += words[j];
                                                    spec += " ";
                                                }
                                                groupSpecialty = spec.Trim();

                                                //Проверка на существование группы
                                                string sqlGroupProv = String.Format("SELECT * FROM Groups WHERE " +
                                                    "GroupNumber=N'{0}'", groupNum);
                                                using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                                                {
                                                    connection.Open();
                                                    SqlCommand command = new SqlCommand(sqlGroupProv, connection);
                                                    SqlDataReader sqlReader = command.ExecuteReader();
                                                    if (sqlReader.HasRows)
                                                    {
                                                        sqlReader.Read();
                                                        oldGroupId = sqlReader.GetInt32(0);
                                                        haveSoGroup = true;
                                                    }
                                                }

                                                if (haveSoGroup)//Изменение статуса существующей группы с таким же номером
                                                {
                                                    string sqlDelGroup = String.Format("UPDATE Groups SET Status=N'Обучается' " +
                                                        "WHERE GroupNumber=N'{0}'", groupNum);

                                                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
                                                    {
                                                        connection.Open();
                                                        SqlCommand command = new SqlCommand(sqlDelGroup, connection);
                                                        int number = command.ExecuteNonQuery();
                                                    }
                                                    //Получение id созданной группы
                                                    string sqlString = String.Format("SELECT Id FROM Groups WHERE GroupNumber='{0}'", groupNum);

                                                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                                                    {
                                                        connection.Open();
                                                        SqlCommand sql = new SqlCommand(sqlString, connection);
                                                        SqlDataReader readerSerch = sql.ExecuteReader();

                                                        if (readerSerch.HasRows)
                                                        {
                                                            readerSerch.Read();
                                                            newGroupId = readerSerch.GetInt32(0);
                                                        }
                                                    }
                                                }
                                                else//Добавление в бд новой группы
                                                {
                                                    string sqlAddGroup = String.Format("INSERT INTO Groups " +
                                                    "(GroupNumber, Specialty, Cours, StudentsCount, Code, Status) " +
                                                    "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')"
                                                    , groupNum, groupSpecialty, cours, 0, groupCode, "Обучается");

                                                    using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                                                    {
                                                        connect.Open();
                                                        SqlCommand command = new SqlCommand(sqlAddGroup, connect);
                                                        int h = command.ExecuteNonQuery();
                                                        if (h == 0) MessageBox.Show("Error!!");
                                                    }

                                                    //Получение id созданной группы
                                                    string sqlString = String.Format("SELECT Id FROM Groups WHERE GroupNumber='{0}'", groupNum);

                                                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                                                    {
                                                        connection.Open();
                                                        SqlCommand sql = new SqlCommand(sqlString, connection);
                                                        SqlDataReader readerSerch = sql.ExecuteReader();

                                                        if (readerSerch.HasRows)
                                                        {
                                                            readerSerch.Read();
                                                            newGroupId = readerSerch.GetInt32(0);
                                                        }
                                                    }
                                                }
                                            }
                                            if (i > 4 && dataGridView2[2, i].Value.ToString() == "")
                                            {
                                                excelControl = false;
                                            }
                                            else if (i > 4 && excelControl)
                                            {
                                                string Text = dataGridView2[2, i].Value.ToString().Trim();
                                                string[] words = Text.Split(' ');
                                                string[] items = new string[0];
                                                int countItems = 0;
                                                for(int g = 0; g < words.Length; g++)
                                                {
                                                
                                                if (words[g] == "" || words[g] == " ")
                                                    {
                                                        continue;
                                                    }
                                                else
                                                {
                                                    countItems++;
                                                    Array.Resize(ref items, countItems);
                                                    items[countItems - 1] = words[g];
                                                }
                                                    
                                                }
                                                surname = items[0];
                                                name = items[1];
                                                if (items.Length > 2)
                                                {
                                                    patr = items[2];
                                                }
                                                else
                                                {
                                                    patr = "";
                                                }


                                            string sqlProvStud = String.Format("SELECT * FROM Students WHERE " +
                                                "GroupId=N'{0}' AND Name=N'{1}' AND Surname=N'{2}' AND Patronymic=N'{3}'", 
                                                newGroupId, name, surname, patr);
                                            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                                            {
                                                connection.Open();
                                                SqlCommand command = new SqlCommand(sqlProvStud, connection);
                                                SqlDataReader sqlReader = command.ExecuteReader();
                                                if (sqlReader.HasRows)
                                                {
                                                    string sqlStatusEdit = String.Format("UPDATE Students SET Status=N'Обучается' WHERE " +
                                                        "GroupId=N'{0}' AND Name=N'{1}' AND Surname=N'{2}' AND Patronymic=N'{3}'",
                                                         newGroupId, name, surname, patr);

                                                    using (SqlConnection con = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
                                                    {
                                                        con.Open();
                                                        SqlCommand com = new SqlCommand(sqlStatusEdit, con);
                                                        int number = com.ExecuteNonQuery();
                                                    }
                                                }
                                                else
                                                {
                                                    //Добавление студентов
                                                    string sqlAddStud = String.Format("INSERT INTO Students " +
                                                                "(GroupId, Name, Surname,Patronymic, Status) " +
                                                                "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')"
                                                                , newGroupId, name, surname, patr, "Обучается");

                                                    using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                                                    {
                                                        connect.Open();
                                                        SqlCommand comm = new SqlCommand(sqlAddStud, connect);
                                                        int h = comm.ExecuteNonQuery();
                                                        if (h == 0) MessageBox.Show("Error!!");
                                                    }
                                                }
                                            }

                                            
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                /*}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
                CountStuds();
                if (isGroup)
                {
                    GroupsShowData();
                }
                else
                {
                    StudentsShowData();
                }

            }
        }

        private void ExitFromAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShablonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exclel_folder = Strings.excel_shablons_folder;
            string excel_file = "excel_shablon_group_and_studs.xlsx";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Path.Combine(exclel_folder, excel_file), Path.Combine(fbd.SelectedPath, excel_file));
            }
        }

        private void OldGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Groups WHERE Cours > 4 OR Status!=N'Обучается'";
            GroupsShowData(sql);
            pStud.Visible = false;
            pGroup.Visible = false;
            isGroup = true;
            lGroupNum.Visible = false;
        }
    }
}