using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchetPractica
{
    class CursorOnLoad
    {
        public static Cursor ChangeCoursor(Cursor cur)
        {
            if(cur == Cursors.Default)
            {
                cur = Cursors.WaitCursor;
            }
            else if (cur == Cursors.WaitCursor)
            {
                cur = Cursors.Default;
            }
            return cur;
        }
    }
}
