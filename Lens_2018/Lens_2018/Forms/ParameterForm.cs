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
    public partial class ParameterForm : Form
    {
        public ParameterForm()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            try
            {
                // 执行选中后的事件
                AfterSelected();
            }
            catch (Exception ex)
            {
                GlobalData.m_TaskForm.SetErrorMessage(ex.Message);
            }
        }
        #region 选择节点事件,使用Switch
        private void AfterSelected()
        {
            string selectNodeName = this.treeView1.SelectedNode.Text;
            UserControl userControlDisplay = null;
            if (this.treeView1.SelectedNode.Text == "单动速度")
            {

            }
            else if
            {

            }
            this.groupBox1.Text = selectNodeName;
            this.groupBox1.Controls.Clear();

            
            userControlDisplay.Location = new System.Drawing.Point(10, 20);

            this.groupBox1.Controls.Add(userControlDisplay);

        }

        #endregion



    }
}
