using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    internal class TabPageFactory
    {
        public static TabPage doTabPage(int count)
        {
            TabPage tabPage = new TabPage();
            tabPage.Location = new Point(4, 25);
            tabPage.Name = "tabPage " + count.ToString();
            tabPage.Padding = new Padding(3);
            tabPage.Size = new Size(1408, 333);
            tabPage.TabIndex = 0;
            tabPage.UseVisualStyleBackColor = true;
            return tabPage;
        }
    }
}
