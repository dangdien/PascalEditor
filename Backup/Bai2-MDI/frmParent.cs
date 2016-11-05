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
            saveToolStripMenuItem.Enabled = false;
            saveSToolStripMenuItem.Enabled = false;
            pageSetupToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            wordWrapToolStripMenuItem.Enabled = false;
            fontToolStripMenuItem.Enabled = false;
        }

        private void mnuFile_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frm = new frmChild();
            frm.MdiParent = this;
            frm.Show();
            i = i+1;
            frm.Text="Notepad" + i;
        }

        private void ofd1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() == DialogResult.OK) {
                StreamReader objDoc = new StreamReader(ofd1.FileName);
                frmChild frm = new frmChild();
                frm.MdiParent = this;
                frm.Show();
                frm.Text = ofd1.FileName;
                frm.richTextBox1.Text = objDoc.ReadToEnd();
            };
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmActive = (frmChild)this.ActiveMdiChild;
            if (frmActive != null) {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    frmActive.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.UnicodePlainText);
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
    }
}
