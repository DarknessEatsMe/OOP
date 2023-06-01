using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    internal class RichTextBoxFactory
    {

        public static RichTextBox doRichTextBox(int count, TabPage tabPage)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "richTextBox" + count.ToString();
            rtb.Location = new Point(18, 18);
            rtb.Size = new Size(tabPage.Size.Width - 45, tabPage.Size.Height - 45);
            rtb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            return rtb;
        }

    }
}
