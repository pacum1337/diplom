using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            text = "Специальность: 09.02.03 - Программирование в компьютерных системах\n";
            text += "Группа: 3602 Курс: 4 Кол - во студентов: 21 чел.\n";
            text += "Вид практики: Производственная(по профилю специальности) практика ПМ.03 Участие в интеграции программных модулей\n";
            text += "Период практики: 23.03.2020 - 11.04.2020\n\n";
            par.Range.Text += text;

            int colStud = 10;//Кол-во студентов(кол-во строк в таблице)
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
                        table.Cell(i, j).Range.Text = "Имя Фамилия Отчество";
                        continue;
                    }
                    else if (j == 3)
                    {
                        table.Cell(i, j).Range.Text = "Место практики, адрес";
                        continue;
                    }
                    else if (j == 4)
                    {
                        table.Cell(i, j).Range.Text = "Номер договора";
                        continue;
                    }
                    else if (j == 5)
                    {
                        table.Cell(i, j).Range.Text = "Наставник";
                        continue;
                    }
                    else if (j == 6)
                    {
                        table.Cell(i, j).Range.Text = "Руководитель практики";
                        continue;
                    }
                }
            }

            wordApp.Visible = true;

        }
    }
}
