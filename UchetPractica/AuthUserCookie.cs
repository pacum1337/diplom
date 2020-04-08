using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchetPractica
{
    class AuthUserCookie
    {
        public static void CookieAuth(string id,string pas)
        {
            string sqlString = String.Format("SELECT * FROM Users WHERE Id='{0}' AND Password='{1}'", id, pas);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlString, connection);
                SqlDataReader reader = sql.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    MessageBox.Show("Добро пожаловать " + reader.GetString(1) + " " + reader.GetString(2));

                    string sqlAuth = String.Format("UPDATE SystemTable " +
                            "SET UserAuthId = '{0}', UserAuthPassword = N'{1}'",
                            reader.GetInt32(0).ToString(), reader.GetString(4));

                    using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                    {
                        connect.Open();
                        SqlCommand command = new SqlCommand(sqlAuth, connect);
                        int h = command.ExecuteNonQuery();
                        if (h == 0) MessageBox.Show("Error!!");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка. Авторизуйтесь снова");
                    UserLogOut();
                    Application.Restart();
                }
            }
        }
        public static void UserLogOut()
        {
            string sqlAuth = String.Format("UPDATE SystemTable " +
                            "SET UserCookieId = '', UserCookiePassword = ''");

            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlAuth, connect);
                int h = command.ExecuteNonQuery();
                if (h == 0) MessageBox.Show("Error!!");
            }
        }
        public static void UserOut()
        {
            string sqlAuth = String.Format("UPDATE SystemTable " +
                            "SET UserAuthId = '', UserAuthPassword = ''");

            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlAuth, connect);
                int h = command.ExecuteNonQuery();
                if (h == 0) MessageBox.Show("Error!!");
            }
        }
    }
}
