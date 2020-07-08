using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace ExcelApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string ExcelBookFileName = textBox1.Text;
            Microsoft.Office.Interop.Excel.Application ExcelApp
              = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = false;
            Workbook wb = ExcelApp.Workbooks.Open(ExcelBookFileName,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Type.Missing);
            Worksheet ws1 = wb.Sheets[1];
            ws1.Select(Type.Missing);
            Range range = ExcelApp.get_Range("A1", Type.Missing);
            if (range != null)
            {
                var val = range.Value2;
                textBox2.Text += Convert.ToString(val);
            }
            wb.Close(false, Type.Missing, Type.Missing);
            ExcelApp.Quit();
        }
    }
}
