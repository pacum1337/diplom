using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchetPractica
{
    class Strings
    {
        //hash
        public static readonly string hashStr = "wferjververineirvneirovneruvjiwoafsjcoia";
        //connect str
        public static string direct = Environment.CurrentDirectory;
        public static string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + direct + @"\Data\DB\uchet_db.mdf;Integrated Security=True;Connect Timeout=30";
    }
}
