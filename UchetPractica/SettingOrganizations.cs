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
    public partial class SettingOrganizations : Form
    {
        private bool addRed = false;
        public bool AddRed { get => addRed; set => addRed = value; }

        private int selectedOrgId = -1;
        public int SelectedOrgId { get => selectedOrgId; set => selectedOrgId = value; }
        public bool resOrg = false;
        public SettingOrganizations()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("Введите название организации!");
            }
            else if (tbAddress.Text.Trim() == "")
            {
                MessageBox.Show("Введите адрес организации!");
            }
            else if (tbDirector.Text.Trim() == "")
            {
                MessageBox.Show("Введите руководителя (директора) организации!");
            }
            else if (tbOGRN.Text.Trim() == "")
            {
                MessageBox.Show("Введите ОГРН организации!");
            }
            else if (tbOGRN.Text.Trim() == "")
            {
                MessageBox.Show("Введите ОГРН организации!");
            }
            else if (tbINN.Text.Trim() == "")
            {
                MessageBox.Show("Введите ИНН организации!");
            }
            else
            {
                string nameOrg = tbName.Text.Trim();
                string address = tbAddress.Text.Trim();
                string director = tbDirector.Text.Trim();
                string date = dtpDateReg.Value.ToString("dd/MM/yyyy");
                string ogrn = tbOGRN.Text.Trim();
                string inn = tbINN.Text.Trim();
                string kpp = tbKPP.Text.Trim();
                string studyOrg = "";
                if (checkBox1.Checked)
                    studyOrg = "1";
                string status = "";
                if (cbStatus.Text == "Работающая")
                    status = "1";
                else if(cbStatus.Text == "Не работающая")
                    status = "2";


                if (addRed)//Добавление организации 
                {
                    bool haveSoOrg = false;

                    string sqlProv = String.Format("SELECT * FROM Organizations WHERE " +
                    "INN='{0}'", inn);

                    using (SqlConnection connection = new SqlConnection(Strings.ConStr))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlProv, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Эта компания уже зарегистрирована!");
                            haveSoOrg = true;
                        }
                    }

                    if (!haveSoOrg)
                    {
                        string sqlAddGroup = String.Format("INSERT INTO Organizations " +
                            "(Name, Address, DateReristration, Director, OGRN, " +
                            "INN, KPP, DocCount, Status, StudyOrg) " +
                            "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}', " +
                            "N'{5}',N'{6}',N'{7}',N'{8}', N'{9}')"
                            , nameOrg, address, date, director, ogrn, inn, kpp, 0, status, studyOrg);

                        using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand(sqlAddGroup, connect);
                            int h = command.ExecuteNonQuery();
                            if (h == 0) MessageBox.Show("Error!!");
                            else MessageBox.Show("Добавлена новая организация!");
                        }
                        resOrg = true;
                        Close();
                    }
                }
                else//Редактирование организации
                {
                    try
                    {
                        string sqlEditStud = String.Format("UPDATE Organizations SET Name=N'{0}', " +
                            "Address=N'{1}', DateReristration=N'{2}', Director=N'{3}', OGRN=N'{4}', " +
                            "INN=N'{5}', KPP=N'{6}', Status=N'{7}', StudyOrg=N'{8}' " +
                            "WHERE Id = '{9}'",
                            nameOrg, address, date, director, ogrn, inn, kpp,status, studyOrg, selectedOrgId);
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
                        resOrg = true;
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Организация с таким ИНН уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void tbOGRN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void tbINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void tbKPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void выхлжИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
