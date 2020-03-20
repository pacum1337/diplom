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
    public partial class Auth : Form
    {
        bool flag = false;
        MD5 mdPas = new MD5CryptoServiceProvider();
        public Auth()
        {
            InitializeComponent();
            tbPas.UseSystemPasswordChar = true;
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            string login = tbLog.Text.Trim();
            string hash = Strings.hashStr;
            byte[] checkSum1 = mdPas.ComputeHash(Encoding.UTF8.GetBytes(tbPas.Text.Trim() + hash));
            string password = BitConverter.ToString(checkSum1).Replace("-", String.Empty);

            string sqlString = String.Format("SELECT * FROM Users WHERE Login='{0}' AND Password=N'{1}'", login, password);

            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlString, connection);
                SqlDataReader reader = sql.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    MessageBox.Show("Добро пожаловать " + reader.GetString(1) + " " + reader.GetString(2));
                    flag = true;
                    if (cbRemember.Checked)//Save cookie
                    {
                        string file_direct_remember = AuthUserCookie.userCookie;
                        File.WriteAllText(file_direct_remember, "");
                        using (var writer = new StreamWriter(file_direct_remember, true))
                        {
                            writer.WriteLine(reader.GetInt32(0).ToString());
                            writer.WriteLine(reader.GetString(4));
                        }
                    }
                    string file_direct_auth_user = AuthUserCookie.file_direct_auth_user;
                    File.WriteAllText(file_direct_auth_user, "");
                    using (var writer = new StreamWriter(file_direct_auth_user, true))
                    {
                        writer.WriteLine(reader.GetInt32(0).ToString());
                        writer.WriteLine(reader.GetString(4));
                    }
                    Close();
                }
                else MessageBox.Show("Такого пользователя не существует!");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!flag)
            {
                Application.Exit();
            }
        }

        private void lReg_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            reg.ShowDialog();
        }
    }
}
