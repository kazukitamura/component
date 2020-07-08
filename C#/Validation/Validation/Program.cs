using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("取り込みFileをフルパスで入力してください。");
            Console.WriteLine("例：C:\\TEST.txt");
            Console.Write("File Path : ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("Shift-JIS")))
                {
                    int i = 0;
                    bool result = true;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineData = line.Split(',');

                        if (lineData.Count() != 3)
                        {
                            Console.WriteLine("フォーマットが異なります");
                            throw new Exception();
                        }

                        MyData data = MyData.SetData(lineData);

                        Console.WriteLine("[" + ++i + "レコード目]");
                        Validator validator = Validator.CreateValidator(data);
                        try
                        {
                            validator.Validate();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("エラーが発生しました。：" + i + "レコード目 " + ex.Message);
                            result = false;
                        }

                    }

                    if (result)
                    {
                        Console.WriteLine("*Validation result:      [OK]");
                    }
                    else
                    {
                        Console.WriteLine("*Validation result:      [NG]");
                    }
                }
            }
            else
            {
                Console.WriteLine("Fileが存在しません。");
            }

            Console.ReadKey();
        }

    }
}

