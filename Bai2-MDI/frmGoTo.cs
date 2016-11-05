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
    public partial class frmGoTo : Form
    {
        public frmChild frmCh;
        public frmGoTo(frmChild frm)
        {
            frmCh = frm;
            InitializeComponent();
        }


        private void lblLineNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            int position = 0;
            int lineNumber = int.Parse(txtLineNumber.Text);
            for (int i = 0; i < lineNumber; i++)
            {
                position += frmCh.richTextBox1.Lines[i].Length;
            }
            frmCh.richTextBox1.SelectionStart = position-frmCh.richTextBox1.Lines[lineNumber-1].Length+lineNumber-1;
            //frmCh.richTextBox1.Text = position.ToString(); //frmCh.richTextBox1.Lines[lineNumber - 1].Length.ToString();
            //frmCh.richTextBox1.ScrollToCaret();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
