using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;


namespace DbToDtoList
{
    static class Program
    {
        public class TestClass
        {
            public string ItemKey { get; set; }
            public string ItemString { get; set; }
            public string ItemNumeric { get; set; }
            public DateTime? ItemDate { get; set; }

            public TestClass()
            {

            }
        }

        static void Main(string[] args)
        {

            //DB接続
            SqlConnection con = new SqlConnection(GetConnectionString());
            try
            {
                //DB接続開始
                con.Open();

                //SQLコマンド発行
                using (SqlCommand com = con.CreateCommand())
                {
                    StringBuilder sql = new StringBuilder();
                    //取得項目名は設定先のクラスプロパティ名へ合わせる
                    sql.AppendLine("SELECT");
                    sql.AppendLine("tk_cd AS ITEMKEY");
                    sql.AppendLine(",name AS ItemString");
                    sql.AppendLine(",tel_no AS ItemNumeric");
                    sql.AppendLine(",insert_date_time AS ItemDate");
                    sql.AppendLine("FROM");
                    sql.AppendLine("[Shitaya2019_ka].[dbo].[D11_Tk]");
                    com.CommandText = sql.ToString();

                    //SQL取得結果指定クラス格納
                    List<TestClass> rets = DbToPropertys<TestClass>(com);
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //DB接続終了
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        static string GetConnectionString()
        {
            //接続文字列生成
            SqlConnectionStringBuilder ret = new SqlConnectionStringBuilder()
            {
                //DB接続先
                DataSource = "SV10",
                //対象DB
                InitialCatalog = "Shitaya2019_ka",
                //認証方法
                IntegratedSecurity = false,
                //ユーザー
                UserID = "sa",
                //パスワード
                Password = "38369421"
            };

            return ret.ToString();
        }

        static List<T> DbToPropertys<T>(SqlCommand com) where T : class, new()
        {
            List<T> ret = new List<T>();
            //指定クラス内プロパティリスト取得
            List<PropertyInfo> propertys = typeof(T).GetProperties().ToList();

            //SQLコマンド実行
            using (DbDataReader reader = com.ExecuteReader())
            {
                //取得結果ループ
                while (reader.Read())
                {
                    //指定クラスインスタンス作成
                    T t = new T();

                    //取得行列数取得
                    int end = reader.FieldCount;
                    //列数分ループ（ここで取得結果を対応するプロパティに設定）
                    for (int cnt = 0; cnt < end; cnt++)
                    {
                        //nullの場合次の列へ
                        if (reader.IsDBNull(cnt))
                        {
                            continue;
                        }

                        //取得結果項目名から設定先プロパティ取得（大文字小文字の区別なし）
                        PropertyInfo property = propertys.Find(x => x.Name.ToUpper().Equals(reader.GetName(cnt).ToUpper()));

                        //設定先がない場合次の列へ
                        if (property == null)
                        {
                            continue;
                        }

                        //設定先プロパティの型を取得（null許容型対応）
                        Type converttype = property.PropertyType.IsGenericType ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;
                        //設定先プロパティへ取得結果設定。第一引数のt（DTOのメンバ）に、第二引数の値を設定。
                        property.SetValue(t, Convert.ChangeType(reader.GetValue(cnt), converttype));
                    }

                    ret.Add(t);
                }
            }

            return ret;
        }

    }
}
