using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace UchetPractica
{
    public partial class DocumentsWork : Form
    {
        private int selectedDocId = -1;
        public int SelectedDocgId { get => selectedDocId; set => selectedDocId = value; }
        public DocumentsWork()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string spec = "";
            string code = "";
            string groupNum = "";
            string course = "";
            string studCount = "";
            string dateStart = "";
            string dateEnd = "";
            string practType = "";
            string profModule = "";

            string sqlProv = String.Format("SELECT G.GroupNumber, D.DateStart, D.DateEnd, D.ProfModule, D.PrType, " +
                "G.Specialty, G.Code, G.Cours, G.StudentsCount " +
                "FROM DocumentRaspredelenie AS D " +
                "INNER JOIN Groups AS G " +
                "ON D.GroupId = G.Id " +
                "WHERE D.Id = N'{0}'", selectedDocId);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlProv, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    groupNum = reader.GetString(0);
                    dateStart = reader.GetString(1);
                    dateEnd = reader.GetString(2);
                    profModule = reader.GetString(3);
                    practType = reader.GetString(4);
                    spec = reader.GetString(5);
                    code = reader.GetString(6);
                    course = reader.GetInt32(7).ToString();
                    studCount = reader.GetInt32(8).ToString();
                }
            }
            if (practType == "Уп")
                practType = "Учебная практика";
            else if (practType == "Уп (р)")
                practType = "Учебная практика (распределенная)";
            else if (practType == "Пп")
                practType = "Производственная практика";
            else if (practType == "Пд")
                practType = "Преддипломная практика";


            Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = wordApp.Documents.Add();
            //заполняем документ текстом
            Word.Paragraph par = wordDoc.Paragraphs.Last;
            par.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            par.Range.Font.Size = 13;
            par.Range.Font.Name = "Times New Roman";
            string text = "Приложение к приказу\n";
            text += "СПб ГБПОУ «Петровский колледж»\n";
            text += "от ______ 2020 № _____\n";//Подставлять дату
            par.Range.Text = text;

            par.Range.Bold = 2;
            par.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            par.Range.Text += "Список распределения студентов по местам практики\n";
            par.Range.Bold = 0;

            par.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            text = "Специальность: " + code + " - " + spec + "\n";
            text += "Группа: " + groupNum + " Курс: " + course + " Кол - во студентов: " + studCount + " чел.\n";
            text += "Вид практики: " + practType + " " + profModule + "\n";
            text += "Период практики: " + dateStart + " - " + dateStart + "\n\n";
            par.Range.Text += text;

            int colStud = 0;//Кол-во студентов(кол-во строк в таблице)
            string[] student = new string[0];
            string[] rucCollege = new string[0];
            string[] rucOrg = new string[0];
            string[] dogovorInfo = new string[0];//пока не используется
            string[] orgInfo = new string[0];

            string sqlTable = String.Format("SELECT S.Name, S.Surname, S.Patronymic, O.Name, O.Address " +
                "FROM DocumentRaspreselenieContent AS RC " +
                "INNER JOIN Students AS S ON RC.StudId = S.Id " +
                "INNER JOIN Organizations AS O ON RC.OrgId = O.Id " +
                "WHERE RC.DocRaspredId = N'{0}'", selectedDocId);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlTable, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    colStud++;
                    Array.Resize(ref student, colStud);
                    Array.Resize(ref rucCollege, colStud);
                    Array.Resize(ref rucOrg, colStud);
                    Array.Resize(ref dogovorInfo, colStud);
                    Array.Resize(ref orgInfo, colStud);
                    student[colStud - 1] = reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                    orgInfo[colStud - 1] = reader.GetString(3) + "\n" + reader.GetString(4);
                }
            }
            
            //руководители от колледжа
            string sqlTable2 = String.Format("SELECT R.Name, R.Surname, R.Patronymic " +
                "FROM DocumentRaspreselenieContent AS RC " +
                "INNER JOIN Rucovoditeli AS R ON RC.RucCollegeId = R.Id " +
                "WHERE RC.DocRaspredId = N'{0}'", selectedDocId);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlTable2, connection);
                SqlDataReader reader = command.ExecuteReader();
                int temp = 0;
                while (reader.Read())
                {
                    temp++;
                    rucCollege[temp-1] = reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                }
            }

            //руководители от предприятия
            string sqlTable3 = String.Format("SELECT R.Name, R.Surname, R.Patronymic " +
                "FROM DocumentRaspreselenieContent AS RC " +
                "INNER JOIN Rucovoditeli AS R ON RC.RucOrgId = R.Id " +
                "WHERE RC.DocRaspredId = N'{0}'", selectedDocId);
            using (SqlConnection connection = new SqlConnection(Strings.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlTable3, connection);
                SqlDataReader reader = command.ExecuteReader();
                int temp = 0;
                while (reader.Read())
                {
                    temp++;
                    rucOrg[temp - 1] = reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                }
            }

            par.Range.Font.Size = 10;
            var tableRange = par.Range;
            wordApp.ActiveDocument.Tables.Add(tableRange, colStud + 1, 6);
            var table = wordApp.ActiveDocument.Tables[wordApp.ActiveDocument.Tables.Count];
            table.set_Style("Сетка таблицы");
            table.ApplyStyleHeadingRows = true;
            table.ApplyStyleLastRow = false;
            table.ApplyStyleFirstColumn = true;
            table.ApplyStyleLastColumn = false;
            table.ApplyStyleRowBands = true;
            table.ApplyStyleColumnBands = false;


            table.Cell(1, 1).Range.Bold = 2;
            table.Cell(1, 1).Range.Text = "№";
            table.Cell(1, 2).Range.Bold = 2;
            table.Cell(1, 2).Range.Text = "ФИО студента";
            table.Cell(1, 3).Range.Bold = 2;
            table.Cell(1, 3).Range.Text = "Место практики, адрес";
            table.Cell(1, 4).Range.Bold = 2;
            table.Cell(1, 4).Range.Text = "Номер договора";
            table.Cell(1, 5).Range.Bold = 2;
            table.Cell(1, 5).Range.Text = "Наставник";
            table.Cell(1, 6).Range.Bold = 2;
            table.Cell(1, 6).Range.Text = "Руководитель практики";
            table.Columns.AutoFit();


            for (int i = 2; i < colStud + 2; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    
                    if (j == 1)
                    {
                        table.Cell(i, j).Range.Text = (i - 1).ToString();
                        continue;
                    }
                    else if (j == 2)
                    {
                        table.Cell(i, j).Range.Text = student[i - 2];
                        continue;
                    }
                    else if (j == 3)
                    {
                        table.Cell(i, j).Range.Text = orgInfo[i - 2];
                        continue;
                    }
                    else if (j == 4)
                    {
                        table.Cell(i, j).Range.Text = "Номер договора";
                        continue;
                    }
                    else if (j == 5)
                    {
                        table.Cell(i, j).Range.Text = rucCollege[i - 2];
                        continue;
                    }
                    else if (j == 6)
                    {
                        table.Cell(i, j).Range.Text = rucOrg[i - 2];
                        continue;
                    }
                }
            }
            wordApp.Visible = true;
        }

        private void DocumentsWork_Load(object sender, EventArgs e)
        {
            int space = 0;
            label2.Left = label1.Left + label1.Width + lDocId.Width + space;
            lGroupName.Left = label2.Left + label2.Width;
            label3.Left = lGroupName.Left + lGroupName.Width;
            lDateStart.Left = label3.Left + label3.Width;
            label4.Left = lDateStart.Left + lDateStart.Width;
            lDateEnd.Left = label4.Left + label4.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
