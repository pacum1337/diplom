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

        private void button2_Click(object sender, EventArgs e)
        {
            Documents documents = new Documents();
            documents.ShowDialog();
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            Students students = new Students();
            students.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Organizations organizations = new Organizations();
            organizations.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rucovoditeli rucovoditeli = new Rucovoditeli();
            rucovoditeli.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Groups groups = new Groups();
            groups.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arhiv arhiv = new Arhiv();
            arhiv.ShowDialog();
        }

        private void redactProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthUserCookie.UserOut();
        }
    }
}
