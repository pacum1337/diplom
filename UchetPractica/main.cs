﻿using ExcelDataReader;
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

        private void Main_Load(object sender, EventArgs e)
        {
            AutoAuth();
            DeleteOldGroups();
            AutoChangeCourse();
        }

        protected void UserExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthUserCookie.UserLogOut();
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DocumentsWork documents = new DocumentsWork();
            documents.ShowDialog();
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            Students students = new Students();
            students.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Organizations organizations = new Organizations();
            organizations.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rucovoditeli rucovoditeli = new Rucovoditeli();
            rucovoditeli.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Groups groups = new Groups();
            groups.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Documents arhiv = new Documents();
            arhiv.ShowDialog();
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

                                using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление студентов группы из бд
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
                                                            string typeValue = dataGridView1[j, i].Value.ToString().Trim();
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
        }
    }
}
