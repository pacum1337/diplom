using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchetPractica
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            tbOldPas.UseSystemPasswordChar = true;
        }


        private void EditPanel(string header,string l1name, string lName, string ceillName)
        {
            CleanPanel();
            lPanelHeader.Text = header;
            lInp1.Text = l1name;
            label1.Text = ceillName;
            if(lName == "lPas")
            {
                lInp2.Visible = true;
                textBox2.Visible = true;
                lInp3.Text = "Старый пароль";
                textBox1.UseSystemPasswordChar = true;
            }
            else
            {
                lInp2.Visible = false;
                textBox2.Visible = false;
                lInp3.Text = "Пароль";
                textBox1.UseSystemPasswordChar = false;
            }
            panel1.Visible = true;
        }
        private void CleanPanel()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            tbOldPas.Text = "";
        }


        private void EditDB()
        {
            MD5 md5 = new MD5CryptoServiceProvider();


            bool doublePas = false;
            string ceil = label1.Text;
            string value = textBox1.Text.Trim();
            string id = "", oldPas="";

            string inpOldPas = tbOldPas.Text.Trim();
            byte[] checkSu1 = md5.ComputeHash(Encoding.UTF8.GetBytes(inpOldPas + Strings.hashStr));
            inpOldPas = BitConverter.ToString(checkSu1).Replace("-", String.Empty);


            bool pasIsEq = false;

            string[] readText = File.ReadAllLines(AuthUserCookie.file_direct_auth_user);
            if (readText.Length != 0)
            {
                id = readText[0];
                oldPas = readText[1];
            }

            if (lInp2.Visible == true)
            {
                if(textBox1.Text.Trim() != textBox2.Text.Trim())
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                else
                {
                    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(value+ Strings.hashStr));
                    value = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                    doublePas = true;
                }
            }
            else
            {
                doublePas = true;
            }

            if(inpOldPas == oldPas)
            {
                pasIsEq = true;
            }
            else
            {
                pasIsEq = false;
                MessageBox.Show("Не правильно введен текущий пароль");
            }

            string sqlText = "UPDATE Users SET {0} = N'{1}' WHERE Id = N'{2}' AND Password = N'{3}'";
            if (doublePas && pasIsEq)
            {
                string sql = String.Format(sqlText, ceil, value, id, oldPas);
                using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    int h = command.ExecuteNonQuery();
                    if (h > 0)
                    {
                        MessageBox.Show("Информация изменена");
                        if (lInp2.Visible)
                        {
                            string file_direct_auth_user = AuthUserCookie.file_direct_auth_user;
                            File.WriteAllText(file_direct_auth_user, "");
                            using (var writer = new StreamWriter(file_direct_auth_user, true))
                            {
                                writer.WriteLine(id);
                                writer.WriteLine(value);
                            }

                            string cookie = AuthUserCookie.userCookie;
                            File.WriteAllText(cookie, "");
                            using (var writer = new StreamWriter(cookie, true))
                            {
                                writer.WriteLine(id);
                                writer.WriteLine(value);
                            }
                        }
                        CleanPanel();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CleanPanel();
            panel1.Visible = false;
        }

        private void lPas_Click(object sender, EventArgs e)
        {
            EditPanel("Изменение пароля", "Новый пароль", lPas.Name, "Password");
        }


        private void lLog_Click(object sender, EventArgs e)
        {
            EditPanel("Изменение логина", "Новый логин", lLog.Name, "Login");
        }

        private void lSur_Click(object sender, EventArgs e)
        {
            EditPanel("Изменение фамилии", "Новая фамилия", lSur.Name, "Surname");
        }

        private void lName_Click(object sender, EventArgs e)
        {
            EditPanel("Изменение имени", "Новое имя", lName.Name, "Name");
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditDB();
        }
    }
}
