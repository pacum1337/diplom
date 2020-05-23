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
    public partial class Documents : Form
    {
        private bool colCont;
        private bool close = true;

        public Documents()
        {
            InitializeComponent();
            cbGroupNum.SelectedIndex = 0;
            cbPracticPlace.SelectedIndex = 0;
            cbLiderOrg.SelectedIndex = 0;
            cbLiderCollege.SelectedIndex = 0;
            cbPeriodStart.SelectedIndex = 0;
            cbPeriodEnd.SelectedIndex = 0;
        }

        private void LoadDocRaspred()
        {
            string sqlGroups = "SELECT D.Id, G.GroupNumber, D.DateStart, D.DateEnd " +
                "FROM DocumentRaspredelenie AS D " +
                "INNER JOIN Groups AS G ON D.GroupId = G.Id ";
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
                    colCont = true;
                }
                else
                {
                    colCont = false;
                }
            }
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Номер группы";
            dataGridView1.Columns[2].HeaderText = "Дата начала практики";
            dataGridView1.Columns[3].HeaderText = "Дата окончания практики";

            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            close = false;
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DocumentsWork work = new DocumentsWork();
            work.SelectedDocgId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            work.lDocId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            work.lGroupName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            work.lDateStart.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            work.lDateEnd.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            work.ShowDialog();
        }

        private void Documents_Load(object sender, EventArgs e)
        {
            LoadDocRaspred();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DocRaspredelenAdd raspredelenAdd = new DocRaspredelenAdd();
            raspredelenAdd.Width = 1797;
            raspredelenAdd.ShowDialog();
            LoadDocRaspred();
        }

        private void Documents_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (close)
            {
                Application.Exit();
            }
        }
    }
}
