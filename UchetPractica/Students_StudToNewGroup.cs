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
    public partial class Students_StudToNewGroup : Form
    {
        int[] superUsers = new int[0];
        int lenght = 0;
        public Students_StudToNewGroup()
        {
            InitializeComponent();
        }

        private void Students_StudToNewGroup_Load(object sender, EventArgs e)
        {
            string sqlSU = "SELECT Id, GroupNumber FROM Groups WHERE Cours <= 4 AND Status = '1'";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlSU, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    lenght++;
                    Array.Resize(ref superUsers, lenght);
                    cbGroup.Items.Add(reader.GetString(1).ToString());
                    superUsers[lenght - 1] = reader.GetInt32(0);
                }
            }
        }

        private void bCancelShow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bEnterShow_Click(object sender, EventArgs e)
        {
            if (cbGroup.Text == "")
            {
                MessageBox.Show("Выберите группу!");
            }
            else
            {
                string sqlEditStud = String.Format("UPDATE Students SET GroupId = '{0}' " +
                        " WHERE Id = '{1}'", superUsers[cbGroup.SelectedIndex].ToString(), label3.Text);
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
                Close();
            }
        }
    }
}
