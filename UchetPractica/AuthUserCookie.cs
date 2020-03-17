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
    class AuthUserCookie:Main
    {
        public static string userCookie = Strings.direct + @"\Data\Cookie\user.txt";
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
            File.WriteAllText(userCookie, "");
        }
    }
}
