using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                TreeNode tn = new TreeNode("ノード");
                treeView1.Nodes.Add(tn);

                //treeView1.Nodes.Add("ノード");//こちらでも可
            }
            else
            {
                TreeNode tn = new TreeNode("ノード");
                treeView1.SelectedNode.Nodes.Add(tn);

                //treeView1.SelectedNode.Nodes.Add("ノード");//こちらでも可

                treeView1.SelectedNode.Expand();
            }
        }
    }

}

