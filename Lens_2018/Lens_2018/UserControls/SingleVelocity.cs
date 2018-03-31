using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lens_2018
{
    public partial class SingleVelocity : UserControl
    {
        public SingleVelocity()
        {
            InitializeComponent();

            SetShow();
        }

        private Dictionary<string, string> data_Save = new Dictionary<string, string>();

        public Dictionary<string,string> Data_Save
        {
            get
            {
                data_Save.Clear();

                data_Save.Add(this.label1.Text, this.textBox1.Text);
                data_Save.Add(this.label2.Text, this.textBox2.Text);
                data_Save.Add(this.label3.Text, this.textBox3.Text);

                return data_Save;
            }

        }

        public void SetShow()
        {

        }








    }
}
