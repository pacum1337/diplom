using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchetPractica
{
    public partial class Documents : Form
    {
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

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DocumentsWork work = new DocumentsWork();
            work.ShowDialog();
        }
    }
}
