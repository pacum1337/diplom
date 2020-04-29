﻿using System;
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
    public partial class DocRaspredelenAdd : Form
    {
        int[] groupsId = new int[0];
        int lenght = 0;
        int lines;
        int selectedGroup = -1;
        Panel panel = new Panel();

        //студенты
        string[] sudentsInfo = new string[0];
        int[] sudentsId = new int[0];
        int lenghtStud = 0;
        Label[] studLabels = new Label[1];
        

        //места практик
        ComboBox[] prPlace;
        string[] prPlaceStr;
        int[] prPlaceId;
        int lenPlace;

        //руководители от колледжа
        ComboBox[] rucColl;
        string[] rucColleStr;
        int[] rucCollId;
        int lenRucColl;

        //руководители от организации
        ComboBox[] rucOrg;
        string[] rucOrgStr;
        int[] rucOrgId;
        int lenRucOrg;

        //Текст бокс номер договора
        TextBox[] tbNum;

        //Текст бокс дата договора
        TextBox[] tbDate;

        //Текст бокс тип договора
        TextBox[] tbType;
        public DocRaspredelenAdd()
        {
            InitializeComponent();
        }
        private void GetRucovodOrg()
        {
            string sqlStuds = String.Format("SELECT Id, Name, Surname, Patronymic " +
                "FROM Rucovoditeli",
                selectedGroup);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlStuds, connection);
                SqlDataReader reader = sql.ExecuteReader();
                lenghtStud = 0;
                while (reader.Read())
                {
                    lenRucOrg++;
                    Array.Resize(ref rucOrgId, lenRucOrg);
                    Array.Resize(ref rucOrgStr, lenRucOrg);
                    rucOrgId[lenRucOrg - 1] = reader.GetInt32(0);
                    rucOrgStr[lenRucOrg - 1] = reader.GetString(1) + " " +
                        reader.GetString(2) + " " + reader.GetString(3);
                }
            }
        }
        private void GetRucovodCollege()
        {
            string sqlStuds = String.Format("SELECT Id, Name, Surname, Patronymic " +
                "FROM Rucovoditeli",
                selectedGroup);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlStuds, connection);
                SqlDataReader reader = sql.ExecuteReader();
                lenghtStud = 0;
                while (reader.Read())
                {
                    lenRucColl++;
                    Array.Resize(ref rucCollId, lenRucColl);
                    Array.Resize(ref rucColleStr, lenRucColl);
                    rucCollId[lenRucColl - 1] = reader.GetInt32(0);
                    rucColleStr[lenRucColl - 1] = reader.GetString(1) + " " +
                        reader.GetString(2) + " " + reader.GetString(3);
                }
            }
        }
        private void CountStuds()
        {
            string sqlSU = String.Format("SELECT COUNT(*) FROM Students WHERE GroupId=N'{0}'",
                selectedGroup);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlSU, connection);
                SqlDataReader reader = sql.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lines = reader.GetInt32(0);

                    studLabels = new Label[reader.GetInt32(0)];
                    prPlace = new ComboBox[reader.GetInt32(0)];
                    rucColl = new ComboBox[reader.GetInt32(0)];
                    rucOrg = new ComboBox[reader.GetInt32(0)];
                    tbNum = new TextBox[reader.GetInt32(0)];
                    tbDate = new TextBox[reader.GetInt32(0)];
                    tbType = new TextBox[reader.GetInt32(0)];
                }
            }
        }
        private void GetPracticPlace()
        {
            string sqlStuds = String.Format("SELECT Id, Name FROM Organizations",
                selectedGroup);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlStuds, connection);
                SqlDataReader reader = sql.ExecuteReader();
                lenPlace = 0;
                while (reader.Read())
                {
                    lenPlace++;
                    Array.Resize(ref prPlaceId, lenPlace);
                    Array.Resize(ref prPlaceStr, lenPlace);
                    prPlaceId[lenPlace - 1] = reader.GetInt32(0);
                    prPlaceStr[lenPlace - 1] = reader.GetString(1);
                }
            }
        }
        private void GetStudLabel()
        {
            string sqlStuds = String.Format("SELECT Id, Name, Surname, Patronymic " +
                "FROM Students WHERE GroupId=N'{0}'",
                selectedGroup);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlStuds, connection);
                SqlDataReader reader = sql.ExecuteReader();
                lenghtStud = 0;
                while (reader.Read())
                {
                    lenghtStud++;
                    Array.Resize(ref sudentsInfo, lenghtStud);
                    Array.Resize(ref sudentsId, lenghtStud);
                    sudentsId[lenghtStud - 1] = reader.GetInt32(0);
                    sudentsInfo[lenghtStud - 1] = reader.GetString(1) + "\n" +
                        reader.GetString(2) + "\n" + reader.GetString(3);
                }
            }
        }
        private void PrintWorkPlace()
        {
            CountStuds();
            GetStudLabel();
            GetPracticPlace();
            GetRucovodCollege();
            GetRucovodOrg();

            panel = new Panel();
            panel.Location = new Point(12, 80);
            panel.Size = new Size(950, 400);
            panel.AutoScroll = true;
            if (panel.AutoScrollMargin.Width < 5 ||
                panel.AutoScrollMargin.Height < 5)
            {
                panel.SetAutoScrollMargin(5, 5);
            }
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(panel);
            int otstup = 100;
            for (int i = 0; i < lines; i++)
            {
                //ФИО студента
                studLabels[i] = new Label();
                studLabels[i].Top = 10 + otstup*i;
                studLabels[i].Left = 20;
                studLabels[i].Text = sudentsInfo[i];
                studLabels[i].AutoSize = true;
                studLabels[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                panel.Controls.Add(studLabels[i]);

                //места практик
                prPlace[i] = new ComboBox();
                prPlace[i].Top = 10 + otstup * i;
                prPlace[i].Left = 200;
                prPlace[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                for(int j = 0;j< prPlaceStr.Length; j++)
                {
                    prPlace[i].Items.Add(prPlaceStr[j]);

                    //
                    prPlace[i].Text = prPlaceStr[j];

                }
                prPlace[i].DropDownStyle = ComboBoxStyle.DropDownList;
                panel.Controls.Add(prPlace[i]);

                //Руководители от колледжа
                rucColl[i] = new ComboBox();
                rucColl[i].Top = 10 + otstup * i;
                rucColl[i].Left = 360;
                rucColl[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                for (int j = 0; j < rucColleStr.Length; j++)
                {
                    rucColl[i].Items.Add(rucColleStr[j]);

                    //
                    rucColl[i].Text = rucColleStr[0];
                }
                rucColl[i].DropDownStyle = ComboBoxStyle.DropDownList;
                panel.Controls.Add(rucColl[i]);

                //Руководители от организации
                rucOrg[i] = new ComboBox();
                rucOrg[i].Top = 10 + otstup * i;
                rucOrg[i].Left = 540;
                rucOrg[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                for (int j = 0; j < rucOrgStr.Length; j++)
                {
                    rucOrg[i].Items.Add(rucOrgStr[j]);

                    //
                    rucOrg[i].Text = rucOrgStr[j];
                }
                rucOrg[i].DropDownStyle = ComboBoxStyle.DropDownList;
                panel.Controls.Add(rucOrg[i]);

                //tb num dogovor
                tbNum[i] = new TextBox();
                tbNum[i].Top = 10 + otstup * i;
                tbNum[i].Left = 740;
                tbNum[i].Width = 120;
                tbNum[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                panel.Controls.Add(tbNum[i]);

                //
                tbNum[i].Text = "1";


                //tb date dogovor
                tbDate[i] = new TextBox();
                tbDate[i].Top = 35 + otstup * i;
                tbDate[i].Left = 740;
                tbDate[i].Width = 120;
                tbDate[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                panel.Controls.Add(tbDate[i]);

                //
                tbDate[i].Text = "1";


                //tb type dogovor
                tbType[i] = new TextBox();
                tbType[i].Top = 60 + otstup * i;
                tbType[i].Left = 740;
                tbType[i].Width = 120;
                tbType[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                panel.Controls.Add(tbType[i]);

                //
                tbType[i].Text = "1";
            }
        }
        private void AddResprContent(int docId)
        {
            for(int i = 0; i < lines; i++)
            {
                string sqlAddStud = String.Format("INSERT INTO DocumentRaspreselenieContent " +
                "(DocRaspredId, StudId, RucCollegeId, RucOrgId, DogovorNum, DogovorDate, DogovorType) " +
                "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')"
                , docId, sudentsId[i], rucCollId[rucColl[i].SelectedIndex],
                rucOrgId[rucOrg[i].SelectedIndex], tbNum[i].Text,
                tbDate[i].Text, tbType[i].Text);

                using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(sqlAddStud, connect);
                    int h = command.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void cbSU_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Controls.Remove(panel);
            selectedGroup = groupsId[cbSU.SelectedIndex];
            PrintWorkPlace();
        }

        private void DocRaspredelenAdd_Load(object sender, EventArgs e)
        {
            string sqlSU = "SELECT Id, GroupNumber FROM Groups";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlSU, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    lenght++;
                    Array.Resize(ref groupsId, lenght);
                    cbSU.Items.Add(reader.GetString(1).ToString());
                    groupsId[lenght - 1] = reader.GetInt32(0);
                }
            }
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            string uniqId = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            string sqlAddStud = String.Format("INSERT INTO DocumentRaspredelenie " +
                "(GroupId, DateStart, DateEnd,UnqueId) " +
                "VALUES (N'{0}',N'{1}',N'{2}',N'{3}')"
                , selectedGroup, dtpDateReg.Value.ToString("dd/MM/yyyy"),
                dateTimePicker1.Value.ToString("dd/MM/yyyy"), uniqId);

            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlAddStud, connect);
                int h = command.ExecuteNonQuery();
                if (h == 0) MessageBox.Show("Error!!");
            }
            int docId = -1;
            string sqlProv = String.Format("SELECT Id FROM DocumentRaspredelenie WHERE " +
                    "UnqueId='{0}'", uniqId);

            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlProv, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    docId = reader.GetInt32(0);
                }
            }
            AddResprContent(docId);
            Close();
        }
    }
}