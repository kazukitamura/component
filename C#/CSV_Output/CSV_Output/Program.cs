using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Output
{
    class Program
    {
        static void Main(string[] args)
        {
           
                var x = new double[] { 3, 4, 5, 6, 7 };
                var y = new double[] { 2, 1, 3, 5, 6 };
                var z = new double[] { 3, 1, 0, -3, 4 };
                try
                {
                    // appendをtrueにすると，既存のファイルに追記
                    //         falseにすると，ファイルを新規作成する
                    var append = false;
                    // 出力用のファイルを開く
                    using (var sw = new System.IO.StreamWriter(@"C:\Users\USER101\Desktop\test.csv", append))
                    {
                        for (int i = 0; i < x.Length; ++i)
                        {
                            // 
                            sw.WriteLine("{0}, {1}, {2},", x[i], y[i], z[i]);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    // ファイルを開くのに失敗したときエラーメッセージを表示
                    System.Console.WriteLine(e.Message);
                }
            
        }
    }
}
