using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchetPractica
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string[] readText = File.ReadAllLines(AuthUserCookie.userCookie);
            if(readText.Length != 0)
            {
                AuthUserCookie.CookieAuth(readText[0], readText[1]);
            }
            else
            {
                Auth auth = new Auth();
                auth.ShowDialog();
            }
            
        }

        protected void UserExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthUserCookie.UserLogOut();
            Application.Restart();
        }
    }
}
