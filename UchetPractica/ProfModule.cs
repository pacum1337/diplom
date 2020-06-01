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
    public partial class ProfModule : Form
    {
        bool colStud = false;
        bool addRed;
        int selectStudId = -1;

        public ProfModule()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string sqlStudents = "SELECT * FROM ProfModule";
            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStudents, connect);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                SqlCommand command = new SqlCommand(sqlStudents, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    colStud = true;
                }
                else
                {
                    colStud = false;
                }
            }
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Название ПМ";
            dataGridView1.Columns[2].HeaderText = "Код специальности";
            dataGridView1.Columns[3].HeaderText = "Статус";
            dataGridView1.Columns[4].HeaderText = "Тип практики";

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[3, i].Value.ToString() == "1")
                    dataGridView1[3, i].Value = "Отображается";
                else if (dataGridView1[3, i].Value.ToString() == "2")
                    dataGridView1[3, i].Value = "Скрытое";
            }
        }

        private void LoadCB()
        {
            string sqlSU = "SELECT Code FROM Groups GROUP BY CODE";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlSU, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    cbCode.Items.Add(reader.GetString(0).ToString());
                }
            }
        }

        private void bAddShow_Click(object sender, EventArgs e)
        {
            this.Width = 820;
            addRed = true;
            pStud.Visible = true;
            tbName.Text = "";
            cbStatusStud.SelectedIndex = 0;
            cbCode.Text = "";
        }

        private void ProfModule_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCB();
            this.Width = 485;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void bEditShow_Click(object sender, EventArgs e)
        {
            this.Width = 820;
            addRed = false;
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                if (colStud)
                {
                    selectStudId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    if (selectStudId > 0)
                    {
                        pStud.Visible = true;
                        string name = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                        string code = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                        string status = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);

                        tbName.Text = name;
                        cbCode.Text = code;
                        cbStatusStud.Text = status;
                    }
                    else
                    {
                        MessageBox.Show("Выберите МП для исправления!");
                        pStud.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для изменения");
                }
            }
            else
            {
                MessageBox.Show("Не выбрана строка!");
            }
        }

        private void bCancelShow_Click(object sender, EventArgs e)
        {
            this.Width = 485;
            pStud.Visible = false;
        }

        private void bEnterShow_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Введите имя ПМ!");
            }
            else if (cbCode.Text == "")
            {
                MessageBox.Show("Введите код спеиальности!");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите тип практики!");
            }
            else
            {
                string name = tbName.Text.Trim();
                string code = cbCode.Text.Trim();
                string typePr = comboBox1.Text;

                string status = "";
                if (cbStatusStud.Text == "Отображается")
                    status = "1";
                else if (cbStatusStud.Text == "Скрытое")
                    status = "2";
                
                if (addRed)//Добавление студента 
                {
                    bool haveSoStud = false;

                    string sqlProv = String.Format("SELECT * FROM ProfModule WHERE " +
                    "Name = N'{0}' AND SpecCode = N'{1}' AND TypePractic = N'{2}'", name, code, typePr);

                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlProv, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Этот ПМ уже зарегистрирован!");
                            haveSoStud = true;
                        }
                    }

                    if (!haveSoStud)
                    {
                        string sqlAddStud = String.Format("INSERT INTO ProfModule " +
                            "(Name, SpecCode, Status, TypePractic) " +
                            "VALUES (N'{0}',N'{1}',N'{2}',N'{3}')"
                            , name, code, status, typePr);

                        using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand(sqlAddStud, connect);
                            int h = command.ExecuteNonQuery();
                            if (h == 0) MessageBox.Show("Error!!");
                            else MessageBox.Show("Добавлен новый ПМ!");
                        }
                        LoadData();
                        pStud.Visible = false;
                        this.Width = 485;
                    }
                }
                else//Редактирование студента
                {
                    string sqlEditStud = String.Format("UPDATE ProfModule SET Name = '{0}', " +
                        "SpecCode = N'{1}', Status = N'{2}', TypePractic = N'{3}'" +
                        " WHERE Id = '{4}'", name, code, status, typePr, selectStudId);
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
                    pStud.Visible = false;
                    this.Width = 485;
                }
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
