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
    public partial class DocRaspredelenAdd : Form
    {
        int[] groupsId = new int[0];
        int lenght = 0;
        int lines;
        int selectedGroup = -1;
        Panel panel = new Panel();
        string uniqId = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();


        //настраиваемые периоды
        Panel panelPerod = new Panel();
        bool multiPeriod = false;
        int periodCount = 0;
        DateTimePicker[] dateNewPerodStart = new DateTimePicker[0];
        DateTimePicker[] dateNewPerodEnd = new DateTimePicker[0];
        Label[] numPeriod = new Label[0];
        Label[] cherta = new Label[0];
        string periodDateStart = "";
        string periodDateEnd = "";
        int addedPer = 0;

        //даты из ГУП
        DateTime[] start = new DateTime[0];
        DateTime[] end = new DateTime[0];
        int dateLen = 0;

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
        string[][] rucOrgStr;
        int[][] rucOrgId;
        int lenRucOrg;
        string[] cbValueArr;

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

        
        private void GetRucovodCollege()
        {
            string sqlStuds = String.Format("SELECT R.Id, R.Name, R.Surname, R.Patronymic " +
                "FROM Rucovoditeli as R " +
                "INNER JOIN Organizations AS O " +
                "ON R.OrgId = O.Id " +
                "WHERE R.Status='1' AND O.Status = '1' AND O.StudyOrg = '1'");
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
            string sqlSU = String.Format("SELECT COUNT(*) FROM Students WHERE GroupId=N'{0}' AND Status = '1'",
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

                    rucOrgStr = new string[lines][];
                    cbValueArr = new string[lines];
                    for (int i = 0; i < lines; i++)
                    {
                        cbValueArr[i] = "";
                    }
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
            string sqlStuds = String.Format("SELECT Id, Name FROM Organizations WHERE Status = '1'",
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
            string sqlStuds = String.Format("SELECT S.Id, S.Name, S.Surname, S.Patronymic " +
                "FROM Students as S " +
                "INNER JOIN Groups AS G " +
                "ON S.GroupId = G.Id " +
                "WHERE S.GroupId=N'{0}' AND G.Status = '1' AND S.Status = '1'",
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
                prPlace[i].SelectedIndexChanged += PlaceOnClick;
                for (int j = 0;j< prPlaceStr.Length; j++)
                {
                    prPlace[i].Items.Add(prPlaceStr[j]);
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
                }
                rucColl[i].DropDownStyle = ComboBoxStyle.DropDownList;
                panel.Controls.Add(rucColl[i]);

                //Руководители от организации
                rucOrg[i] = new ComboBox();
                rucOrg[i].Top = 10 + otstup * i;
                rucOrg[i].Left = 540;
                rucOrg[i].Enabled = false;
                rucOrg[i].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
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

        private void GetRucovodOrg(int num, int orgId)
        {
            string sqlStuds = String.Format("SELECT Id, Name, Surname, Patronymic " +
                "FROM Rucovoditeli WHERE OrgId = {0}", orgId);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlStuds, connection);
                SqlDataReader reader = sql.ExecuteReader();
                lenghtStud = 0;
                Array.Resize(ref rucOrgId, lines);
                Array.Resize(ref rucOrgStr, lines);
                while (reader.Read())
                {
                    lenghtStud++;
                    Array.Resize(ref rucOrgId[num], lenghtStud);
                    Array.Resize(ref rucOrgStr[num], lenghtStud);
                    rucOrgId[num][lenghtStud - 1] = reader.GetInt32(0);
                    rucOrgStr[num][lenghtStud - 1] = reader.GetString(1) + " " +
                        reader.GetString(2) + " " + reader.GetString(3);
                }
            }
        }

        private void PlaceOnClick(object sender, EventArgs eventArgs)
        {
            for (int i = 0; i < lines; i++)
            {
                if (prPlace[i].Text != "")
                {
                    if(cbValueArr[i] != prPlace[i].Text)
                    {
                        cbValueArr[i] = prPlace[i].Text;
                        rucOrg[i].Enabled = true;
                        rucOrg[i].Items.Clear();
                        GetRucovodOrg(i, prPlaceId[prPlace[i].SelectedIndex]);
                        for (int j = 0; j < rucOrgStr[i].Length; j++)
                        {
                            if (rucOrgStr[i][j] != null)
                                rucOrg[i].Items.Add(rucOrgStr[i][j]);
                        }
                    }
                    
                }
            }
        }
        private void AddResprContent(int docId)
        {
            for(int i = 0; i < lines; i++)
            {
                string sqlAddStud = String.Format("INSERT INTO DocumentRaspreselenieContent " +
                "(DocRaspredId, StudId, RucCollegeId, RucOrgId, DogovorNum, DogovorDate, DogovorType, OrgId) " +
                "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}')"
                , docId, sudentsId[i], rucCollId[rucColl[i].SelectedIndex],
                rucOrgId[i][rucOrg[i].SelectedIndex], tbNum[i].Text,
                tbDate[i].Text, tbType[i].Text, prPlaceId[prPlace[i].SelectedIndex]);

                using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(sqlAddStud, connect);
                    int h = command.ExecuteNonQuery();
                }
            }
        }
        private void LoadPM()
        {
            comboBox4.Enabled = true;
            string specCode = "";
            string prType = comboBox3.Text;    

            string sqlProv = String.Format("SELECT Code FROM Groups WHERE " +
                    "GroupNumber=N'{0}'",cbSU.Text);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlProv, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    specCode = reader.GetString(0);
                }
            }


            string sqlPM = String.Format("SELECT Id, Name FROM ProfModule WHERE " +
                    "SpecCode=N'{0}' AND TypePractic=N'{1}' AND Status = '1'", specCode, prType);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                DataTable dt = new DataTable();
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlPM, connection);
                    SqlDataReader myReader = cmd.ExecuteReader();
                    dt.Load(myReader);
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Нет записей!");
                    Close();
                }
                comboBox4.DataSource = dt;
                comboBox4.ValueMember = "Id";
                comboBox4.DisplayMember = "Name";
                comboBox4.SelectedIndex = -1;
            }
        }
        private void LoadDate()
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            button3.Enabled = true;
            string group = cbSU.Text;
            string type = comboBox3.Text.ToLower();
            string sqlDateStart = String.Format("SELECT WeekDateStart, WeekDateEnd FROM StudyProcess " +
                "WHERE GroupNumber = N'{0}' AND WeekType = N'{1}' " +
                "GROUP BY WeekDateStart, WeekDateEnd", group, type);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlDateStart, connection);
                SqlDataReader reader = sql.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dateLen++;
                        Array.Resize(ref start, dateLen);
                        Array.Resize(ref end, dateLen);
                        start[dateLen - 1] = DateTime.Parse(reader.GetString(0));
                        end[dateLen - 1] = DateTime.Parse(reader.GetString(1));
                    }
                }
                else
                {
                    MessageBox.Show("Нет подходящих дат для этой группы с этим типом практики.\n" +
                        "Отредактируйте ГУП или впишите свои даты!");
                }
                
            }
            DateTime temp;
            for (int i = 0; i < dateLen; i++)
            {
                for (int j = i + 1; j < dateLen; j++)
                {
                    if (start[i] > start[j])
                    {
                        temp = start[i];
                        start[i] = start[j];
                        start[j] = temp;
                    }
                    if (end[i] > end[j])
                    {
                        temp = end[i];
                        end[i] = end[j];
                        end[j] = temp;
                    }
                }
            }
            for (int i = 0; i < dateLen; i++)
            {
                if (i >= 1)
                {
                    if (start[i].AddDays(-7) == start[i - 1])
                        continue;
                }
                comboBox1.Items.Add(start[i]);
            }
            for (int i = 0; i < dateLen; i++)
            {
                if (i < dateLen - 1)
                {
                    if (end[i].AddDays(7) == end[i + 1])
                        continue;
                }
                comboBox2.Items.Add(end[i]);
            }
        }

        private void EnableOFF()
        {
            this.Controls.Remove(panel);
            bEnter.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            pColRuc.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            button3.Enabled = false;
            panel1.Visible = true;
            panel2.Visible = false;
            label14.Text = "Кол-во студентов в\nгруппе: ";
        }

        private void HideShowDate()
        {
            if (multiPeriod)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                checkBox1.Enabled = false;
                panel2.Visible = true;
                panel1.Visible = false;
                button3.Text = "Выбрать даты из ГУП";

                //создание панели
                panelPerod = new Panel();
                panelPerod.Location = new Point(10, 10);
                panelPerod.Size = new Size(300, 150);
                panelPerod.AutoScroll = true;
                if (panelPerod.AutoScrollMargin.Width < 5 ||
                    panelPerod.AutoScrollMargin.Height < 5)
                {
                    panelPerod.SetAutoScrollMargin(5, 5);
                }
                panelPerod.BorderStyle = BorderStyle.FixedSingle;
                panel2.Controls.Add(panelPerod);
            }
            else
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                checkBox1.Enabled = true;
                panel2.Visible = false;
                panel1.Visible = true;
                button3.Text = "Добавить/изменить период практики";
                panel2.Controls.Remove(panelPerod);
                periodCount = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cbSU_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableOFF();
            if (comboBox3.Text != "" && cbSU.Text != "")
                LoadPM();
            else
                comboBox4.Enabled = false;
        }

        private void DocRaspredelenAdd_Load(object sender, EventArgs e)
        {
            //загрузка групп
            string sqlSU = "SELECT Id, GroupNumber FROM Groups WHERE Status='1'";
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


            //загрузка руководителей для быстрой подстановки руководителя
            string sqlColRuc = "SELECT R.Name, R.Surname, R.Patronymic " +
                "FROM Rucovoditeli AS R " +
                "INNER JOIN Organizations AS O " +
                "ON R.OrgId = O.Id " +
                "WHERE R.Status='1' AND O.Status = '1' AND O.StudyOrg = '1'";
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand(sqlColRuc, connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    comboBox5.Items.Add(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
                    comboBox6.Items.Add(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
                }
            }
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if(cbSU.Text == "")
            {
                label5.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                label5.ForeColor = Color.Black;
            }

            if (comboBox3.Text == "")
            {
                label9.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                label9.ForeColor = Color.Black;
            }

            if (comboBox4.Text == "")
            {
                label10.ForeColor = Color.Red;
                flag = false;
            }
            else
            {
                label10.ForeColor = Color.Black;
            }

            if (!multiPeriod)
            {
                if (comboBox1.Text == "")
                {
                    label7.ForeColor = Color.Red;
                    flag = false;
                }
                else
                {
                    label7.ForeColor = Color.Black;
                }

                if (comboBox2.Text == "")
                {
                    label8.ForeColor = Color.Red;
                    flag = false;
                }
                else
                {
                    label8.ForeColor = Color.Black;
                }
            }
            else
            {
                label8.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
            }

            if (lines < 1)
            {
                flag = false;
                MessageBox.Show("Нечего добавлять!");
            }
            
            for (int i = 0; i < lines; i++)
            {
                if (prPlace[i].Text == "" || rucColl[i].Text == "" || rucOrg[i].Text == "")
                {
                    studLabels[i].ForeColor = Color.Red;
                    flag = false;
                }
                else
                {
                    studLabels[i].ForeColor = Color.Black;
                }
            }
            if (flag)
            {
                if (multiPeriod)
                {
                    if(periodCount > 1)
                    {
                        string sqlAddStud = String.Format("INSERT INTO DocumentRaspredelenie " +
                        "(GroupId, DateStart, DateEnd,UnqueId,ProfModule,PrType,PartOfPeriodsStatus) " +
                        "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}','2')"
                        , selectedGroup, dateNewPerodStart[addedPer].Value.ToString("dd/MM/yyyy"), dateNewPerodEnd[addedPer].Value.ToString("dd/MM/yyyy"), 
                        uniqId, comboBox4.Text, comboBox3.Text);

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
                        //закрытие редактирования
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        cbSU.Enabled = false;
                        comboBox3.Enabled = false;
                        comboBox5.Enabled = false;
                        comboBox6.Enabled = false;
                        button3.Enabled = false;
                        panel1.Visible = true;
                        panel2.Visible = false;
                        pColRuc.Enabled = false;

                        addedPer++;
                        if(addedPer == periodCount)
                        {
                            string sqlAddMain = String.Format("INSERT INTO DocumentRaspredelenie " +
                        "(GroupId, DateStart, DateEnd,UnqueId,ProfModule,PrType,PartOfPeriodsStatus) " +
                        "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}','1')"
                        , selectedGroup, dateNewPerodStart[0].Value.ToString("dd/MM/yyyy"), dateNewPerodEnd[periodCount - 1].Value.ToString("dd/MM/yyyy"), 
                        uniqId, comboBox4.Text, comboBox3.Text);

                            using (SqlConnection connect = new SqlConnection(Strings.ConStr))
                            {
                                connect.Open();
                                SqlCommand command = new SqlCommand(sqlAddMain, connect);
                                int h = command.ExecuteNonQuery();
                                if (h == 0) MessageBox.Show("Error!!");
                            }
                            Close();
                        }
                    }
                    else if(periodCount == 1)
                    {
                        string sqlAddStud = String.Format("INSERT INTO DocumentRaspredelenie " +
                        "(GroupId, DateStart, DateEnd,UnqueId,ProfModule,PrType) " +
                        "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')"
                        , selectedGroup, dateNewPerodStart[0].Value.ToString("dd/MM/yyyy"), dateNewPerodEnd[0].Value.ToString("dd/MM/yyyy"), 
                        uniqId, comboBox4.Text, comboBox3.Text);

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
                    else
                        MessageBox.Show("Не добавлено периодов практики!");
                }
                else
                {
                    string sqlAddStud = String.Format("INSERT INTO DocumentRaspredelenie " +
                        "(GroupId, DateStart, DateEnd,UnqueId,ProfModule,PrType) " +
                        "VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')"
                        , selectedGroup, comboBox1.Text, comboBox2.Text, uniqId, comboBox4.Text, comboBox3.Text);

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
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            if (!checkBox1.Checked)
            {
                for (int i = 0; i < dateLen; i++)
                {
                    comboBox1.Items.Add(start[i]);
                    comboBox2.Items.Add(end[i]);
                }
            }
            else
            {
                for (int i = 0; i < dateLen; i++)
                {
                    if(start[i]>=DateTime.Now)
                        comboBox1.Items.Add(start[i]);
                    if (end[i] >= DateTime.Now)
                        comboBox2.Items.Add(end[i]);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableOFF();
            if (comboBox3.Text != "" && cbSU.Text != "")
                LoadPM();
            else
                comboBox4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox4.Text != "" && comboBox3.Text != "" && cbSU.Text != "")
            {
                selectedGroup = groupsId[cbSU.SelectedIndex];
                PrintWorkPlace();
                bEnter.Enabled = true;
                label5.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                pColRuc.Enabled = true;
                LoadDate();
                label14.Text = "Кол-во студентов в\nгруппе: " + lines;
            }
            else
            {
                label5.ForeColor = Color.Red;
                label9.ForeColor = Color.Red;
                label10.ForeColor = Color.Red;
                MessageBox.Show("Введите корректные данные!");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Enabled = true;
            comboBox6.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                for(int i = 0; i < lines; i++)
                {
                    rucColl[i].Text = comboBox5.Text;
                }
            }
            else if (radioButton3.Checked)
            {
                for (int i = 0; i < lines / 2; i++)
                {
                    rucColl[i].Text = comboBox5.Text;
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                for (int i = lines / 2; i < lines; i++)
                {
                    rucColl[i].Text = comboBox6.Text;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (multiPeriod)
                multiPeriod = false;
            else
                multiPeriod = true;
            HideShowDate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(periodCount < 7)
            {
                int otstup = 30;
                periodCount++;
                Array.Resize(ref dateNewPerodStart, periodCount);
                Array.Resize(ref dateNewPerodEnd, periodCount);
                Array.Resize(ref numPeriod, periodCount);
                Array.Resize(ref cherta, periodCount);
                int i = periodCount - 1;

                //номер периода
                numPeriod[i] = new Label();
                numPeriod[i].Top = 10 + otstup * i;
                numPeriod[i].Left = 5;
                numPeriod[i].Font = new Font("Arial", 10, FontStyle.Regular);
                numPeriod[i].AutoSize = true;
                numPeriod[i].Text = periodCount.ToString() + ")";
                panelPerod.Controls.Add(numPeriod[i]);

                //начальная дата
                dateNewPerodStart[i] = new DateTimePicker();
                dateNewPerodStart[i].Width = 100;
                dateNewPerodStart[i].Top = 5 + otstup * i;
                dateNewPerodStart[i].Left = 35;
                dateNewPerodStart[i].Font = new Font("Arial", 10, FontStyle.Regular);
                dateNewPerodStart[i].Format = DateTimePickerFormat.Short;
                panelPerod.Controls.Add(dateNewPerodStart[i]);

                //черточка)
                cherta[i] = new Label();
                cherta[i].Top = 5 + otstup * i;
                cherta[i].Left = 145;
                cherta[i].Font = new Font("Arial", 10, FontStyle.Regular);
                cherta[i].Width = 15;
                cherta[i].Text = "-";
                panelPerod.Controls.Add(cherta[i]);

                //конечная дата
                dateNewPerodEnd[i] = new DateTimePicker();
                dateNewPerodEnd[i].Width = 100;
                dateNewPerodEnd[i].Top = 5 + otstup * i;
                dateNewPerodEnd[i].Left = 170;
                dateNewPerodEnd[i].Font = new Font("Arial", 10, FontStyle.Regular);
                dateNewPerodEnd[i].Format = DateTimePickerFormat.Short;
                panelPerod.Controls.Add(dateNewPerodEnd[i]);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(periodCount > 0)
            {
                int i = periodCount - 1;

                panelPerod.Controls.Remove(numPeriod[i]);
                panelPerod.Controls.Remove(dateNewPerodStart[i]);
                panelPerod.Controls.Remove(cherta[i]);
                panelPerod.Controls.Remove(dateNewPerodEnd[i]);

                periodCount--;
                Array.Resize(ref dateNewPerodStart, periodCount);
                Array.Resize(ref dateNewPerodEnd, periodCount);
                Array.Resize(ref numPeriod, periodCount);
                Array.Resize(ref cherta, periodCount);
            }
        }
    }
}
