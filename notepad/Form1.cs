using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace notepad
{
    public partial class Form1 : Form
    {
        StatusBar m = new StatusBar();
        PrintDocument k = new PrintDocument();
        
        string file = " ";
        public Form1()
        {
            InitializeComponent();
            k.PrintController = new StandardPrintController();
            
        }

        private void undo_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            
        }

        private void copy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void paste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectall_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("آیا می خواهید قبل از ایجادفایل جدید تغییرات را ذخیره کنید؟", "خطا", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (Result==DialogResult.Yes)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)| *.*";
                if (save.ShowDialog()==DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, richTextBox1.Text);
                }
            }
            else if (Result==DialogResult.Cancel)
            {
                return;
            }
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(open.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(file))
            {
                File.WriteAllText(file, richTextBox1.Text);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)| *.*";
                save.Title = "ذخیره فایل";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, richTextBox1.Text);
                    file = save.FileName;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveas = new SaveFileDialog();
            saveas.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)| *.*";
            saveas.Title = "ذخیره با نام جدید";
            if (saveas.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveas.FileName, richTextBox1.Text);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k.Print();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult re = fontDialog1.ShowDialog();
            if (re==DialogResult.OK)
            {
                Font = fontDialog1.Font;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = !richTextBox1.WordWrap;
            wordWrapToolStripMenuItem.Checked = richTextBox1.WordWrap;
            m.Visible = !richTextBox1.WordWrap;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m.Visible = !m.Visible;
            statusBarToolStripMenuItem.Checked = m.Visible;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My NotePad\nVersion 1.0\nCreated by MriKri", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
