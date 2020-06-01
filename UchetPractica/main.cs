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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchetPractica
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
        }

        private void DeleteOldGroups()
        {
            //получение id всех групп
            int l = 0;
            int[] grId = new int[0];
            string sqlGroups = "SELECT * FROM Groups WHERE Cours >= 9";
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

            int delStudCount = 0;
            int delGroupCount = 0;

            for (int i = 0; i < grId.Length; i++)
            {
                string sqlDelGroup = String.Format("DELETE FROM Groups " +
                                        "WHERE Id = '{0}'", grId[i]);
                string sqlDelStudOfGroup = String.Format("DELETE FROM Students " +
                            "WHERE GroupId = '{0}'", grId[i]);

                using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление студентов группы из бд
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlDelStudOfGroup, connection);
                    int number = command.ExecuteNonQuery();
                    if (number > 0)
                    {
                        delStudCount += number;
                    }
                }

                using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlDelGroup, connection);
                    int number = command.ExecuteNonQuery();
                    if (number > 0)
                    {
                        delGroupCount += number;
                    }
                }
            }
            if(delGroupCount > 0 || delStudCount > 0)
                MessageBox.Show("По итогам чистки данных, было удалено " + delGroupCount + 
                " групп\nи " + delStudCount + " студентов", "Чистка данных");
        }

        private void AutoAuth()
        {
            string sqlString = String.Format("SELECT * FROM SystemTable");
            string[] readText = new string[2];
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlString, connection);
                SqlDataReader reader = sql.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    readText[0] = Convert.ToString(reader.GetInt32(1));
                    readText[1] = reader.GetString(2);
                }
            }
            if (readText[0] != "0" && readText[1] != "")
            {
                AuthUserCookie.CookieAuth(readText[0], readText[1]);
            }
            else
            {
                Auth auth = new Auth();
                auth.ShowDialog();
            }
        }

        private void AutoChangeCourse() 
        {
            string sqlCheckDate = "SELECT LastCheckChangeCourse FROM SystemTable";
            DateTime date = DateTime.Today;
            bool LastDateIsNull = false;
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlCheckDate, connection);
                SqlDataReader reader = sql.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    if (reader.IsDBNull(0))
                    {
                        LastDateIsNull = true;
                    }
                    else
                    {
                        date = DateTime.Parse(Convert.ToString(reader.GetString(0)));
                    }
                }
            }
            DateTime today = DateTime.Today;
            if (LastDateIsNull || date.AddMonths(1) < today)
            {
                int l = 0;
                int[] grId = new int[0];
                string sqlGroups = "SELECT Id FROM Groups";
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

                for (int i = 0; i < grId.Length; i++)
                {
                    string groupNum;
                    string sqlGroup = String.Format("SELECT * FROM Groups WHERE Id='{0}'", grId[i]);
                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand sql = new SqlCommand(sqlGroup, connection);
                        SqlDataReader reader = sql.ExecuteReader();
                        reader.Read();
                        groupNum = reader.GetString(1);
                    }
                    int newCourse = Students.GetCourse(groupNum);
                    string sqlEditStud = String.Format("UPDATE Groups SET Cours = '{0}' " +
                        "WHERE Id = '{1}'", newCourse, grId[i]);
                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlEditStud, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }

            string strToday = today.ToString("dd/MM/yyyy");
            string sqlLastChange = String.Format("UPDATE SystemTable SET LastCheckChangeCourse = '{0}'",
                strToday);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlLastChange, connection);
                command.ExecuteNonQuery();
            }
        }

        private void StudyProcessMessages()
        {
            
            string sqlCheckDate = "SELECT StudyProcessMessages, StudyOffWeekDate FROM SystemTable";
            string offDate = "";
            string typeMess = "";
            string groups = "";
            DateTime trueStartDate = DateTime.Today;
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlCheckDate, connection);
                SqlDataReader reader = sql.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        typeMess = reader.GetString(0).Trim();
                        offDate = reader.GetString(1).Trim();
                    }
                }
            }

            if (typeMess != "off" && typeMess != "offWeek")
            {
                try
                {
                    string sql = "SELECT * FROM StudyProcess WHERE WeekType=N'пп' ";
                    DateTime date = DateTime.Today;
                    DateTime endDate, startDate;

                    if (typeMess == "1")
                    {
                        sql += "AND GroupNumber LIKE '1%'" ;
                    }
                    else if(typeMess == "2")
                    {
                        sql += "AND GroupNumber LIKE '2%'";
                    }
                    else if (typeMess == "3")
                    {
                        sql += "AND GroupNumber LIKE '3%'";
                    }
                    else if (typeMess == "4")
                    {
                        sql += "AND GroupNumber LIKE '4%'";
                    }
                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sql, connection);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string grnum = reader.GetString(1);
                            DateTime dateFeature = date.AddDays(7);
                            startDate = DateTime.Parse(reader.GetString(2));
                            endDate = DateTime.Parse(reader.GetString(3));
                            if(startDate <= dateFeature && endDate >= dateFeature)
                            {
                            trueStartDate = startDate;
                                bool yjeIdet = false;
                                string sqlYjeIdet = String.Format("SELECT * FROM StudyProcess WHERE " +
                                    "WeekType='пп' AND GroupNumber='{0}' AND WeekDateStart='{1}'",
                                    grnum, startDate.AddDays(-8).ToString("dd/MM/yyyy"));
                                using (SqlConnection connection1 = new SqlConnection(Strings.ConStr))
                                { 
                                    connection1.Open();
                                    SqlCommand command1 = new SqlCommand(sqlYjeIdet, connection1);
                                    SqlDataReader reader1 = command1.ExecuteReader();

                                    if (reader1.HasRows)
                                    {
                                        yjeIdet = true;
                                    }
                                }
                                if (!yjeIdet)
                                {
                                groups += grnum + " ";
                                }
                            }
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Ошибка вывода уведомлений.\n" +
                        "Обновите график учебного процесса или отключите уведомления",
                        "Ошибка вывода уведомлений");
                }
            }
            else if(typeMess == "offWeek")
            {
                DateTime time = DateTime.Parse(offDate);
                int dayOfWeek = (int)time.DayOfWeek;
                if(dayOfWeek != 0)
                {
                    time = time.AddDays(8 - dayOfWeek);
                }
                else
                {
                    time = time.AddDays(1);
                }
                if (DateTime.Today >= time)
                {
                    StudyMessages("all");
                    StudyProcessMessages();
                }
                else
                {
                    return;
                }
            }
            if(groups != "")
            {
                MessageBox.Show("Практика у групп: " + groups.Trim() + "\n" +
                    trueStartDate.ToString("dd/MM/yyyy") + " - число начала практики");
            }
        }

        private void StudyProcessPeriod()
        {
            string sql = "SELECT StudyProcessPeriod FROM SystemTable";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        lStudyProcess.Text = "Загружен график учебного процесса " + reader.GetString(0);
                    else
                        lStudyProcess.Text = "График учебного процесса не загружен в базу данных";
                }
            }
            string sqlProv = "SELECT MIN(Id) FROM StudyProcess";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlProv, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                    lStudyProcess.Text = "График учебного процесса не загружен в базу данных";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AutoAuth();
            DeleteOldGroups();
            AutoChangeCourse();
            StudyProcessMessages();
            StudyProcessPeriod();
        }

        protected void UserExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthUserCookie.UserLogOut();
            Application.Restart();
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Students students = new Students();
            students.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Organizations organizations = new Organizations();
            organizations.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Rucovoditeli rucovoditeli = new Rucovoditeli();
            rucovoditeli.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Documents arhiv = new Documents();
            arhiv.ShowDialog();
            this.Visible = true;
        }

        private void redactProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthUserCookie.UserOut();
        }

        private void ImportExcelGraphikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string fileName = "";
            DataTableCollection tableCollection;
            DialogResult dr = MessageBox.Show("При импорте все старые данные будут перезаписаны на новые\n" +
                "без возможности отмены действия.\n" +
                "Вы уверены, что хотите импортировать данные?", "Подтверждение действия", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string excelPath;
                    using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = openFileDialog.FileName;
                            fileName = Path.GetFileName(filePath);
                            this.Cursor = CursorOnLoad.ChangeCoursor(this.Cursor);
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

                                string sqlDelProcess = "DELETE FROM StudyProcess";

                                using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление старого ГУП
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand(sqlDelProcess, connection);
                                    command.ExecuteNonQuery();
                                }

                                foreach (DataTable table in tableCollection)
                                    {
                                        DataTable dt = tableCollection[table.TableName.ToString()];
                                        dataGridView1.DataSource = dt;

                                        int startX=-1, startY=-1;
                                        string[] datesStart = new string[0];
                                        string[] datesEnd = new string[0];
                                        int datesLen = 0;
                                        DateTime tempDate;
                                        int coord;
                                        bool horoshVnosit = false;
                                        string groupNum = "";
                                        string twoNumGr = "";

                                        for (int i = 0; i< dt.Rows.Count; i++)
                                        {
                                            coord = 0;
                                            for (int j = 0; j < dt.Columns.Count; j++)
                                            {
                                                if(dataGridView1[j, i].Value.ToString().Trim().ToLower() == "группа")
                                                {
                                                    startX = j;
                                                    startY = i;
                                                }

                                                string s = dataGridView1[j, i].Value.ToString().Trim().ToLower();
                                                Regex regex = new Regex(@"^\w*\s?(\d{4}\s?-\s?\d{4})\w*");
                                                MatchCollection matches = regex.Matches(s);
                                                if (matches.Count > 0)
                                                {
                                                    string sqlEditGYP = String.Format("UPDATE SystemTable SET StudyProcessPeriod = N'{0}'", matches[0]);
                                                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                                                    {
                                                        connection.Open();
                                                        SqlCommand command = new SqlCommand(sqlEditGYP, connection);
                                                        command.ExecuteNonQuery();
                                                    }
                                                    StudyProcessPeriod();
                                                }

                                                if(i == startY + 2 && startY != -1)
                                                {
                                                    if(dataGridView1[j, i].Value.ToString().Trim() != "")
                                                    {
                                                        datesLen++;
                                                        Array.Resize(ref datesStart, datesLen);
                                                        Array.Resize(ref datesEnd, datesLen);

                                                        datesStart[datesLen - 1] = dataGridView1[j, i].Value.ToString().Trim();
                                                        tempDate = DateTime.Parse(datesStart[datesLen - 1]).AddDays(6);
                                                        datesEnd[datesLen - 1] = tempDate.ToString("dd/MM/yyyy");
                                                    }
                                                }

                                                if (groupNum != "" && !horoshVnosit)
                                                {
                                                    twoNumGr = groupNum[0].ToString();
                                                    twoNumGr += groupNum[1].ToString();
                                                    int temp;
                                                    try
                                                    {
                                                        temp = Convert.ToInt32(twoNumGr);
                                                    }
                                                    catch
                                                    {
                                                        horoshVnosit = true;
                                                    }
                                                }

                                                if(i >= startY + 6 && startY != -1 && !horoshVnosit)
                                                {
                                                    if(j == 0)
                                                    {
                                                        groupNum = dataGridView1[j, i].Value.ToString().Trim();
                                                    }
                                                    else
                                                    {
                                                        if(dataGridView1[j, i].Value.ToString().Trim() != "")
                                                        {
                                                            string typeValue = dataGridView1[j, i].Value.ToString().Trim().ToLower();
                                                            string sqlAddProcessLine = String.Format("INSERT INTO StudyProcess " +
                                                                "(GroupNumber, WeekDateStart, WeekDateEnd, WeekType) " +
                                                                "VALUES (N'{0}',N'{1}',N'{2}',N'{3}')"
                                                                , groupNum, datesStart[coord], datesEnd[coord], typeValue);

                                                            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                                                            {
                                                                connect.Open();
                                                                SqlCommand command = new SqlCommand(sqlAddProcessLine, connect);
                                                                int h = command.ExecuteNonQuery();
                                                                if (h == 0) MessageBox.Show("Error!!");
                                                            }
                                                            coord++;
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string nameFromTable = "";
            string sqlProv = String.Format("SELECT StydyProcessNowFileName FROM SystemTable");
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlProv, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if(!reader.IsDBNull(0))
                        nameFromTable = reader.GetString(0);
                }
            }
            if(nameFromTable != "")
            {
                File.Delete(Strings.excel_shablons_folder + nameFromTable);
            }
            if (!File.Exists(Strings.excel_shablons_folder + fileName))
            {
                File.Copy(filePath, Strings.excel_shablons_folder + fileName);
            }
            string sqlEditStud = String.Format("UPDATE SystemTable SET StydyProcessNowFileName = N'{0}'", fileName);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlEditStud, connection);
                command.ExecuteNonQuery();
            }
            this.Cursor = CursorOnLoad.ChangeCoursor(this.Cursor);
        }

        private void ShablonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exclel_folder = Strings.excel_shablons_folder;
            string excel_file = "Study_process_shablon.xlsx";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Path.Combine(exclel_folder, excel_file), Path.Combine(fbd.SelectedPath, excel_file));
            }
        }

        private void StudyMessages(string TypeMes)
        {
            string sqlAuth = String.Format("UPDATE SystemTable SET StudyProcessMessages = N'{0}'", TypeMes);

            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlAuth, connect);
                int h = command.ExecuteNonQuery();
                if (h == 0) MessageBox.Show("Error!!");
            }
        }

        private void всеОтделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyMessages("all");
        }

        private void оИПТСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyMessages("1");
        }

        private void группы2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyMessages("2");
        }

        private void группы3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyMessages("3");
        }

        private void группы4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyMessages("4");
        }

        private void отключитьУведомленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyMessages("off");
        }

        private void отключитьДоСледующейНеделиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudyMessages("offWeek");

            string sqlCheckDate = "SELECT StudyProcessMessages FROM SystemTable";
            string typeMess = "";
            DateTime date = DateTime.Today;
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlCheckDate, connection);
                SqlDataReader reader = sql.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        typeMess = reader.GetString(0).Trim();
                    }
                }
            }


            string sqlAuth = String.Format("UPDATE SystemTable SET StudyOffWeekDate=N'{0}'"
                ,date.ToString("dd/MM/yyyy"));
            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlAuth, connect);
                int h = command.ExecuteNonQuery();
                if (h == 0) MessageBox.Show("Error!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProfModule prof = new ProfModule();
            prof.ShowDialog();
            this.Visible = true;
        }

        private void скачатьТекущийГУПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exclel_folder = Strings.excel_shablons_folder;
            string excel_file = "";
            string sqlProv = String.Format("SELECT StydyProcessNowFileName FROM SystemTable");
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlProv, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                        excel_file = reader.GetString(0);
                }
            }
            if(excel_file != "")
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(Path.Combine(exclel_folder, excel_file), Path.Combine(fbd.SelectedPath, excel_file));
                }
            }
            else
            {
                MessageBox.Show("Нет загруженного ГУП!");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
