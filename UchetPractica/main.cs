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

        private void Main_Load(object sender, EventArgs e)
        {
            string[] readText = File.ReadAllLines(AuthUserCookie.userCookie);
            if(readText.Length != 0)
            {
                AuthUserCookie.CookieAuth(readText[0], readText[1]);
            }
            else
            {
                Auth auth = new Auth();
                auth.ShowDialog();
            }
            DeleteOldGroups();
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
    }
}
