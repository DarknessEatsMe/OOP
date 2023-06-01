using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class Form1 : Form
    {
        public int count = -1;
        string fName = "";
        List<RichTextBox> RTBList = new List<RichTextBox>();
        List<TabPage> TabPageList = new List<TabPage>();
        public List<string> text = new List<string>();



        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
            colorDialog1.FullOpen = true;
            fontDialog1.ShowColor = true;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text[tabControl1.SelectedIndex] != RTBList[tabControl1.SelectedIndex].Text)
            {
                DialogResult result = MessageBox.Show("Вы желаете сохранить файл?", "Внимание!", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    сохранитьКакToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    text[tabControl1.SelectedIndex] = RTBList[tabControl1.SelectedIndex].Text;
                    открытьToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    return;
                }
            }

            if (openFileDialog1.FileName == String.Empty) return;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                fName = openFileDialog1.FileName;
                tabControl1.SelectedTab.Name = fName;

                RTBList[tabControl1.SelectedIndex].LoadFile(tabControl1.SelectedTab.Name, RichTextBoxStreamType.RichText);
                text[tabControl1.SelectedIndex] = RTBList[tabControl1.SelectedIndex].Text;
                RTBList[tabControl1.SelectedIndex].BackColor = RTBList[tabControl1.SelectedIndex].SelectionBackColor;
                tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
                Text = fName;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            открытьToolStripMenuItem_Click(sender, e);
        }

        public void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTBList[tabControl1.SelectedIndex].SelectAll();
            RTBList[tabControl1.SelectedIndex].SelectionBackColor = RTBList[tabControl1.SelectedIndex].BackColor;
            RTBList[tabControl1.SelectedIndex].DeselectAll();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            fName = saveFileDialog1.FileName;
            tabControl1.SelectedTab.Name = saveFileDialog1.FileName;
            Text = fName;
            RTBList[tabControl1.SelectedIndex].SaveFile(tabControl1.SelectedTab.Name, RichTextBoxStreamType.RichText);


            tabControl1.SelectedTab.Text = saveFileDialog1.FileName;
            text[tabControl1.SelectedIndex] = RTBList[tabControl1.SelectedIndex].Text;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Equals("Безымянный"))
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                try
                {
                    RTBList[tabControl1.SelectedIndex].SaveFile(tabControl1.SelectedTab.Name, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Файл успешно сохранен", "Сохранение", MessageBoxButtons.OK);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                text[tabControl1.SelectedIndex] = RTBList[tabControl1.SelectedIndex].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            сохранитьКакToolStripMenuItem_Click(sender, e);
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text[tabControl1.SelectedIndex] != RTBList[tabControl1.SelectedIndex].Text)
            {
                DialogResult result = MessageBox.Show("Вы желаете сохранить файл?", "Внимание!", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    сохранитьКакToolStripMenuItem_Click(sender, e);
                    if (text[tabControl1.SelectedIndex] != RTBList[tabControl1.SelectedIndex].Text)
                    {
                        return;
                    }
                }
                else if (result == DialogResult.No)
                {
                    text[tabControl1.SelectedIndex] = "";
                    RTBList[tabControl1.SelectedIndex].Clear();
                    новыйToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    return;
                }

            }
            fName = "Безымянный";

            text[tabControl1.SelectedIndex] = "";
            RTBList[tabControl1.SelectedIndex].Clear();
            RTBList[tabControl1.SelectedIndex].BackColor = Color.White;
            RTBList[tabControl1.SelectedIndex].SelectAll();
            RTBList[tabControl1.SelectedIndex].SelectionBackColor = Color.White;
            RTBList[tabControl1.SelectedIndex].DeselectAll();
            RTBList[tabControl1.SelectedIndex].Font = new Font("Microsoft Sans Serif", 14);
            RTBList[tabControl1.SelectedIndex].ForeColor = Color.Black;
            tabControl1.SelectedTab.Name = "Безымянный";
            tabControl1.SelectedTab.Text = "Безымянный";
            Text = fName;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Федотов Евгений Николаевич\nГруппа: ЦПИ-21", "О программе", MessageBoxButtons.OK);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TabPageList.Count; i++)
            {
                tabControl1.SelectedTab = TabPageList[i];
                if (text[i] != RTBList[i].Text)
                {
                    DialogResult result = MessageBox.Show("Вы желаете сохранить файл?", "Внимание!", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        сохранитьКакToolStripMenuItem_Click(sender, e);
                    }
                    else if (result == DialogResult.No)
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }

                }
            }
            
            Close();
        }

        private void изменитьШрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel) return;

            RTBList[tabControl1.SelectedIndex] = Format.changeFont(RTBList[tabControl1.SelectedIndex], fontDialog1);
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;

            RTBList[tabControl1.SelectedIndex] = Format.changeColor(RTBList[tabControl1.SelectedIndex], colorDialog1);
        }

        private void открытьВНовойВкладкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            count++;
            TabPageList.Add(TabPageFactory.doTabPage(count));
            tabControl1.TabPages.Add(TabPageList[count]);

            RTBList.Add(RichTextBoxFactory.doRichTextBox(count, TabPageList[count]));
            TabPageList[count].Controls.Add(RTBList[count]);
            
            tabControl1.SelectedTab = TabPageList[count];

            text.Add(String.Empty);

            открытьToolStripMenuItem_Click(sender, e);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            count++;

            TabPageList.Add(TabPageFactory.doTabPage(count));
            tabControl1.TabPages.Add(TabPageList[count]);

            RTBList.Add(RichTextBoxFactory.doRichTextBox(count, TabPageList[count]));
            TabPageList[count].Controls.Add(RTBList[count]);

            text.Add(String.Empty);
            tabControl1.SelectedTab.Name = "Безымянный";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = tabControl1.SelectedTab.Name;
        }

    }
}
