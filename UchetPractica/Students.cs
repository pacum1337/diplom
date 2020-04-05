using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        int lenght = 0;
        int[] cbId = new int[0];
        bool isGroup = true;
        bool colStud = false;
        bool colGroup = false;

        public Students()
        {
            InitializeComponent();
        }

        private void StudentsShowData()
        {
            string sqlStudents = String.Format("SELECT S.Id, S.Name, S.Surname, S.Patronymic, G.GroupNumber " +
                "FROM Students AS S " +
                "INNER JOIN Groups AS G ON S.GroupId = G.Id");

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

            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
        }

        private void GroupsShowData()
        {
            string sqlStudents = String.Format("SELECT * FROM Groups");

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

            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 80;
        }

        private void CBGroupLoad()
        {
            cbGroupNum.Items.Clear();
            cbGroupNum.Items.Add("-");

            string sqlSU = "SELECT * FROM Groups";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlSU, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    lenght++;
                    Array.Resize(ref cbId, lenght);
                    cbGroupNum.Items.Add(reader.GetString(1).ToString());
                    cbId[lenght - 1] += reader.GetInt32(0);
                }
            }
        }

        private int GetCourse(string groupNum)
        {
            string num = groupNum[1].ToString();
            int numOfYear = Convert.ToInt32(num);
            int cours;
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
            return cours;
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
            }
            else
            {
                CBGroupLoad();
                pStud.Visible = true;
                pGroup.Visible = false;

                tbName.Text = "";
                tbSurname.Text = "";
                tbPatr.Text = "";
                cbGroupNum.Text = "-";
            }
        }

        private void bCancelShow_Click(object sender, EventArgs e)
        {
            pGroup.Visible = false;

            tbName.Text = "";
            tbSurname.Text = "";
            tbPatr.Text = "";
            cbGroupNum.Text = "";
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

                        tbGroupNum.Text = groupNumber;
                        tbSpecialty.Text = specialty;
                        tbGroupCode.Text = groupCode;
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
                        CBGroupLoad();
                        string name = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                        string surname = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                        string patr = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                        string groupNum = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);

                        cbGroupNum.Text = groupNum;
                        tbName.Text = name;
                        tbSurname.Text = surname;
                        tbPatr.Text = patr;
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
            if (cbGroupNum.Text == "-")
            {
                MessageBox.Show("Выберите группу!");
            }
            else if(tbName.Text.Length < 2)
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
                string groupId = cbId[cbGroupNum.SelectedIndex - 1].ToString();
                string name = tbName.Text.Trim();
                string surname = tbSurname.Text.Trim();
                string patr = tbPatr.Text.Trim();
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
                            "(GroupId, Name, Surname,Patronymic) " +
                            "VALUES (N'{0}',N'{1}',N'{2}','{3}')"
                            , groupId, name, surname, patr);

                        using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand(sqlAddStud, connect);
                            int h = command.ExecuteNonQuery();
                            if (h == 0) MessageBox.Show("Error!!");
                            else MessageBox.Show("Добавлен новый студент!");
                        }
                        StudentsShowData();
                        pStud.Visible = false;
                    }
                }
                else//Редактирование студента
                {
                    string sqlEditStud = String.Format("UPDATE Students SET GroupId = '{0}', " +
                        "Name = N'{1}', Surname = N'{2}', Patronymic = N'{3}' " +
                        " WHERE Id = '{4}'", groupId, name, surname, patr, selectStudId);
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
                        string sqlAddStud = String.Format("INSERT INTO Groups " +
                            "(GroupNumber, Specialty, Cours, StudentsCount, Code) " +
                            "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')"
                            , groupNumber, specialty, cours, studCount, groupCode);

                        using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand(sqlAddStud, connect);
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
                        "Specialty = N'{1}', Code = N'{2}'" +
                        " WHERE Id = '{3}'", groupNumber, specialty, groupCode, selectGroupId);
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
            if (isGroup)
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
            else
            {
                if (colStud)
                {
                    selectStudId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string name = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    string surname = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    if (selectGroupId > 0)
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
                                    StudentsShowData();
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
            pGroup.Visible = false;
            pStud.Visible = false;
        }

        private void StudentsShow_Click(object sender, EventArgs e)
        {
            StudentsShowData();
            pStud.Visible = false;
            pGroup.Visible = false;
            StudentsShow.Enabled = false;
            GroupShow.Enabled = true;
            isGroup = false;
        }

        private void GroupShow_Click(object sender, EventArgs e)
        {
            GroupsShowData();
            pStud.Visible = false;
            pGroup.Visible = false;
            StudentsShow.Enabled = true;
            GroupShow.Enabled = false;
            isGroup = true;
        }
    }
}