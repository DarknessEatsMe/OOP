using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    internal class Format
    {

        public static RichTextBox changeColor(RichTextBox rtb, ColorDialog colorDialog)
        {
            rtb.BackColor = colorDialog.Color;
            rtb.SelectAll();
            rtb.SelectionBackColor = colorDialog.Color;
            rtb.DeselectAll();
            return rtb;
        }

        public static RichTextBox changeFont(RichTextBox rtb, FontDialog fontDialog)
        {
            rtb.Font = fontDialog.Font;
            rtb.ForeColor = fontDialog.Color;
            return rtb;
        }

    }
}
