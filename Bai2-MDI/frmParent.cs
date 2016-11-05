using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bai2_MDI
{
    public partial class frmParent : Form
    {
        private int i = 0;
        public frmParent()
        {
            InitializeComponent();
        }

        private void frmParent_Load(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines("reserved words.txt");
            undoToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
            //pasteToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            findToolStripMenuItem.Enabled = false;
            findNextToolStripMenuItem.Enabled = false;
            gotoToolStripMenuItem.Enabled = false;
            saveSToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        private void mnuFile_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null)
            {
                if (saveAsFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string text = frmActive.GetString();
                    System.IO.File.WriteAllText(saveAsFileDialog.FileName, text);
                    //frmActive.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frm = new frmChild();
            frm.MdiParent = this;
            frm.Show();
            i = i+1;
            frm.Text="Notepad" + i;
            saveToolStripMenuItem.Enabled = true;
            saveSToolStripMenuItem.Enabled = true;
        }

        private void ofd1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frm = new frmChild();
            frm.MdiParent = this;
            frm.Show();
            saveToolStripMenuItem.Enabled = true;
            saveSToolStripMenuItem.Enabled = true;
            if (ofd1.ShowDialog() == DialogResult.OK) {
                string text = System.IO.File.ReadAllText(ofd1.FileName);
                frmChild frmActive = (frmChild)this.ActiveMdiChild;
                if (frmActive != null) {
                    frmActive.richTextBox1.Text = text;
                }
                frm.Text = ofd1.FileName;
                /*StreamReader objDoc = new StreamReader(ofd1.FileName);
                frmChild frm = new frmChild();
                frm.MdiParent = this;
                frm.Show();
                frm.Text = ofd1.FileName;
                frm.richTextBox1.Text = objDoc.ReadToEnd();*/
            };
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null) {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    frmActive.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            
            }
        }

        private void tbrnew_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if(frmActive != null)
            if (fontDialog1.ShowDialog() == DialogResult.OK) {
                frmActive.richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmChild frmActive = (frmChild)this.ActiveMdiChild;
             if (frmActive != null) {
                 frmActive.richTextBox1.Undo();
             }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null) {
                if (pageSettupDialog.ShowDialog() == DialogResult.OK) { 
                    //frmActive.richTextBox1.
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null)
            {
                if (printDialog1.ShowDialog() == DialogResult.OK) { }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null) {
                if (frmActive.richTextBox1.SelectedText != "") {
                    frmActive.richTextBox1.Cut();
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null) {
                if (frmActive.richTextBox1.SelectedText != "") {
                    frmActive.richTextBox1.Copy();
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText)) {
                frmActive.richTextBox1.Paste();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null)
            {
                if (frmActive.richTextBox1.SelectedText != "")
                {
                    frmActive.richTextBox1.SelectedText = "";
                }
            }
        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            frmActive.creatFrmGoTo().Show();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if(frmActive!=null)
            frmActive.richTextBox1.Select(0, frmActive.richTextBox1.TextLength);
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null)
            {
                DateTime localDate = DateTime.Now;
                frmActive.richTextBox1.Text += localDate.ToString();
            }
        }

        private void aboutNotepadMDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Student : Phan Đăng Diên \nStudentID : 586092");
        }

        private void tbrOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void tbrSave_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void tbrPrint_Click(object sender, EventArgs e)
        {
            printToolStripMenuItem_Click(sender, e);
        }

        private void tbrCut_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void tbrCopy_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void tbrPaste_Click(object sender, EventArgs e)
        {
            pageSetupToolStripMenuItem_Click(sender, e);
        }

        private void tbrHelp_Click(object sender, EventArgs e)
        {
            aboutNotepadMDIToolStripMenuItem_Click(sender, e);
        }

    }
}
