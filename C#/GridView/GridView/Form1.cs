using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // カラム数を指定
            dataGridView1.ColumnCount = 4;

            // カラム名を指定
            dataGridView1.Columns[0].HeaderText = "教科";
            dataGridView1.Columns[1].HeaderText = "点数";
            dataGridView1.Columns[2].HeaderText = "氏名";
            dataGridView1.Columns[3].HeaderText = "クラス名";

            // データを追加
            dataGridView1.Rows.Add("国語", 90, "田中　一郎", "A");
            dataGridView1.Rows.Add("数学", 50, "鈴木　二郎", "A");
            dataGridView1.Rows.Add("英語", 90, "佐藤　三郎", "B");
        }
    }
}
