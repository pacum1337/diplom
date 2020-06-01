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
    public partial class Rucovoditeli : Form
    {
        private bool colRuc = false;
        private bool addRed;
        int[] orgId = new int[0];
        int lenght = 0;
        int selectRucId = -1;

        public Rucovoditeli()
        {
            InitializeComponent();
        }

        private void LoadData(string sqlGroups = "SELECT R.Id, O.Name as OrgName, R.Name as RucName, " +
                "R.Surname, R.Patronymic, R.Status " +
                "FROM Rucovoditeli AS R " +
                "INNER JOIN Organizations AS O " +
                "ON R.OrgId = O.Id " +
                "WHERE R.Status='1' AND O.Status = '1'")
        {
            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlGroups, connect);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                SqlCommand command = new SqlCommand(sqlGroups, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    colRuc = true;
                }
                else
                {
                    colRuc = false;
                }
            }
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Фамилия";
            dataGridView1.Columns[4].HeaderText = "Отчество";

            dataGridView1.Columns[5].Visible = false;

            dataGridView1.Columns[1].Width = 160;
        }

        private void CBLoad()
        {
            cbOrg.Items.Clear();
            string sqlSU = "SELECT Id, Name FROM Organizations";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlSU, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    lenght++;
                    Array.Resize(ref orgId, lenght);
                    cbOrg.Items.Add(reader.GetString(1).ToString());
                    orgId[lenght - 1] = reader.GetInt32(0);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Width = 550;
        }

        private void Rucovoditeli_Load(object sender, EventArgs e)
        {
            LoadData();
            this.Width = 550;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Width = 860;
            addRed = true;
            panel1.Visible = true;
            CBLoad();
            tbName.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            cbStatus.Text = "Работающий";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Width = 860;
            addRed = false;
            if (colRuc)
            {
                selectRucId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (selectRucId > 0)
                {
                    panel1.Visible = true;

                    string orgName = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    string name = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    string surname = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                    string patr = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                    string status = "";
                    if (Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value) == "1")
                        status = "Работающий";
                    else if(Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value) == "2")
                        status = "Не работающий";

                    CBLoad();
                    cbOrg.Text = orgName;
                    tbName.Text = name;
                    textBox4.Text = surname;
                    textBox1.Text = patr;
                    cbStatus.Text = status;
                }
                else
                {
                    MessageBox.Show("Выберите группу для исправления!");
                    panel1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Нет записей для изменения");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cbOrg.Text == "")
            {
                MessageBox.Show("Выберите организацию!");
            }
            else if (tbName.Text == "")
            {
                MessageBox.Show("Введите имя руководителя!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Введите фамилию руководителя!");
            }
            else
            {
                string id = orgId[cbOrg.SelectedIndex].ToString();
                string name = tbName.Text.Trim();
                string surname = textBox4.Text.Trim();
                string patr = textBox1.Text.Trim();
                string status = "";
                if (cbStatus.Text == "Работающий")
                    status = "1";
                else if(cbStatus.Text == "Не работающий")
                    status = "2";
                if (addRed)//Добавление студента 
                {
                    bool haveSoStud = false;

                    string sqlProv = String.Format("SELECT * FROM Rucovoditeli WHERE " +
                    "OrgId='{0}' AND Name=N'{1}' AND Surname=N'{2}' AND Patronymic=N'{3}'"
                    , id, name, surname, patr);

                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlProv, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Этот руководитель уже зарегистрирован!");
                            haveSoStud = true;
                        }
                    }

                    if (!haveSoStud)
                    {
                        string sqlAddStud = String.Format("INSERT INTO Rucovoditeli " +
                            "(OrgId, Name, Surname,Patronymic,Status) " +
                            "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')"
                            , id, name, surname, patr, status);

                        using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand(sqlAddStud, connect);
                            int h = command.ExecuteNonQuery();
                            if (h == 0) MessageBox.Show("Error!!");
                            else MessageBox.Show("Добавлен новый руководитель!");
                        }
                        LoadData();
                        panel1.Visible = false;
                        this.Width = 550;
                    }
                }
                else//Редактирование группы
                {
                    string sqlEditStud = String.Format("UPDATE Rucovoditeli SET OrgId = '{0}', " +
                        "Name = N'{1}', Surname = N'{2}', Patronymic = N'{3}', Status=N'{4}' " +
                        "WHERE Id = '{5}'", id, name, surname, patr, status, selectRucId);
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
                    LoadData();
                    panel1.Visible = false;
                    this.Width = 550;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colRuc)
            {
                selectRucId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (selectRucId > 0)
                {
                    DialogResult dr = MessageBox.Show("Вы уверены, что хотите удалить " +
                        "руководителя из базы данных?", "Подтверждение действия",
                        MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        string sqlDelStud = String.Format("DELETE FROM Rucovoditeli " +
                                    "WHERE Id = '{0}'", selectRucId);

                        using (SqlConnection connection = new SqlConnection(Strings.ConStr))//Удаление самой группы из бд
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlDelStud, connection);
                            int number = command.ExecuteNonQuery();
                            if (number > 0)
                            {
                                MessageBox.Show("Руководитель удален из базы данных");
                                LoadData();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите руководителя для удаления!");
                }
            }
            else
            {
                MessageBox.Show("Нет записей для удаления!");
            }
            panel1.Visible = false;
        }

        private void всехКромеНеРаботающихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void вToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlGroups = "SELECT R.Id, O.Name as OrgName, R.Name as RucName, " +
                "R.Surname, R.Patronymic, R.Status " +
                "FROM Rucovoditeli AS R " +
                "INNER JOIN Organizations AS O " +
                "ON R.OrgId = O.Id " +
                "WHERE R.Status!='1' OR O.Status != '1'";
            LoadData(sqlGroups);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
