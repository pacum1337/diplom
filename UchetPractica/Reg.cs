using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UchetPractica
{
    public partial class Reg : Form
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        string superUsers ="";
        public Reg()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Reg_Load(object sender, EventArgs e)
        {
            string sqlSU= "SELECT * FROM Users WHERE SuperUser = 1";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlSU, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    cbSU.Items.Add(reader.GetString(1).ToString());
                    superUsers += reader.GetInt32(0).ToString();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cbSU.Text !="")
            {
                tbSUPas.Enabled = true;
            }
            else
            {
                tbSUPas.Enabled = false;
            }
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string surname = tbSur.Text.Trim();
            string login = tbLog.Text.Trim();
            string pas1 = tbPas.Text.Trim();
            string pas2 = tbPas2.Text.Trim();

            string hash = Strings.hashStr;
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(tbSUPas.Text.Trim() + hash));
            string superPas = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            if(name != "" && surname != ""&& login != ""&& pas1 != ""&&pas2 != "")
            {
                if(pas1 == pas2)
                {
                    if(cbSU.Text != "")
                    {
                        if(superPas != "")
                        {
                            byte[] checkSum2 = md5.ComputeHash(Encoding.UTF8.GetBytes(pas1 + hash));
                            string password = BitConverter.ToString(checkSum2).Replace("-", String.Empty);

                            bool superCheck = true;//cbSuperuser checked
                            string sqlReg ="";
                            if (cbSuperReg.Checked)
                            {
                                DialogResult dr = MessageBox.Show("Вы уверены, что хотите создать \nпользователя с ролью 'SuperUser'?", "Подтверждение действия",
                                MessageBoxButtons.YesNo);
                                if (dr == DialogResult.Yes)
                                {
                                    sqlReg = String.Format("INSERT INTO Users (Name, Surname, Login, Password, " +
                                    "SuperUser) " +
                                    "VALUES (N'{0}',N'{1}',N'{2}',N'{3}', 1)", name, surname, login, password);
                                }
                                else
                                {
                                    superCheck = false;
                                }
                            }
                            else
                            {
                                sqlReg = String.Format("INSERT INTO Users (Name, Surname, Login, Password) " +
                                "VALUES (N'{0}',N'{1}',N'{2}',N'{3}')", name, surname, login, password);
                            }


                            bool isSuper = false;
                            string sqlString = String.Format("SELECT * FROM Users WHERE Id='{0}' AND Password=N'{1}'"
                                , superUsers[cbSU.SelectedIndex].ToString(), superPas);
                            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                            {
                                connection.Open();
                                SqlCommand sql = new SqlCommand(sqlString, connection);
                                SqlDataReader reader = sql.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    isSuper = true;
                                }
                                else MessageBox.Show("Не верно введен пароль SuperUser");
                            }

                            if (isSuper && superCheck)
                            {
                                using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                                {
                                    connect.Open();
                                    SqlCommand command = new SqlCommand(sqlReg, connect);
                                    int h = command.ExecuteNonQuery();
                                    if (h == 0) MessageBox.Show("Error!!");
                                    else MessageBox.Show("Пользователь зарегистрирован!");
                                    Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не введен пароль SuperUser!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите SuperUser из списка!");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
            }
            else
            {
                MessageBox.Show("Заполните не заполненые поля!");
            }
        }
    }
}
