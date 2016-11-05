using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai2_MDI
{
    public partial class frmChild : Form
    {
        public frmGoTo frmGT;
        public frmChild()
        {
            frmGoTo frm = new frmGoTo(this);
            InitializeComponent();
            frmGT = frm;
        }

        public frmGoTo creatFrmGoTo() {
            frmGoTo frmGt = new frmGoTo(this);
            return frmGt;
        }

        public string GetString()
        {
            richTextBox1.SelectAll();
            return richTextBox1.SelectedText;
        }
   

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //active Undo selection if there any text
            frmParent activeParent = (frmParent)this.MdiParent;
            if (richTextBox1.TextLength  != 0) activeParent.undoToolStripMenuItem.Enabled = true;
            
           
            
            //------------
            //load and change color of keywords
            int searchStart = 0;
            string[] lines = System.IO.File.ReadAllLines(@"reserved words.txt");
            foreach (string line in lines)
            {
                this.CheckKeyword(line, Color.Blue, 0, ref searchStart);
            }
        }

        private void CheckKeyword(string word, Color color, int startIndex, ref int searchStart)
        {

            if (this.richTextBox1.Text.Contains(word))
            {

                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;
                
                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    if (this.richTextBox1.Text.IndexOf(word, 0) == 0)
                    {
                        this.richTextBox1.Select((index), word.Length);
                        this.richTextBox1.SelectionColor = color;
                        this.richTextBox1.Select(selectStart, 0);
                        this.richTextBox1.SelectionColor = Color.Black;
                    }
                    else
                        if (richTextBox1.Text[index - 1].ToString().Equals(" ") || richTextBox1.Text[index - 1].ToString().Equals("\n"))
                    {
                        this.richTextBox1.Select((index), word.Length);
                        this.richTextBox1.SelectionColor = color;
                        this.richTextBox1.Select(selectStart, 0);
                        this.richTextBox1.SelectionColor = Color.Black;
                    }
                }
            }


        }

        private void richTextBox1_SelectionChanged(Object sender, EventArgs e)
        {
            //active Cut,Copy,Delete selections if there's any text selected.
            if (richTextBox1.SelectedText != "")
            {
                frmParent activeParent = (frmParent)this.MdiParent;
                activeParent.cutToolStripMenuItem.Enabled = true;
                activeParent.copyToolStripMenuItem.Enabled = true;
                activeParent.deleteToolStripMenuItem.Enabled = true;
            }

            //active Goto selection if there's any text in RichTextBox
            frmParent frmParentActive = (frmParent)this.MdiParent;
            if (this.richTextBox1.Text.Length != 0) {
                frmParentActive.gotoToolStripMenuItem.Enabled = true;
            }

        }



    }
}
