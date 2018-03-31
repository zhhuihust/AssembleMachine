using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lens_2018
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
        }

        public void SetErrorMessage(string str)
        {
           // this.statusStrip1.BackColor = Color.Red;
           // this.toolStripStatusLabel1.Text = str;
            GlobalData.m_LogForm.AddLine(str, Color.Red);
        }
    }
}
