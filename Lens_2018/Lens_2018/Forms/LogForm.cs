using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lens_2018
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void AddLine(string line, Color TextColor)
        {
            try
            {
                richTextBox1.SelectionColor = TextColor;
                richTextBox1.AppendText(line);
                richTextBox1.AppendText(System.Environment.NewLine);
                if (this.checkBox1.Checked == true)
                {
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }

                LogOperation.SaveLogMsg(line);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
