using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace ProjectBackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            try
            {
                SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
                conn.DataSource = @"FEXRI\SQLEXPRESS01";//your server
                conn.InitialCatalog = "ProjectBackend"; //your database name
                conn.IntegratedSecurity = true; 

                //create instanace of database connection
                using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                {
                    //    int input = Convert.ToInt32(Console.ReadLine()) ;
                    //    string input2 = Console.ReadLine();

                    //Query used in the code
                    //  String task1 = "SELECT isciNomresi,Ad,Soyadi,iseGirisVaxti,Unvan,emekHaqqiEmsali,birAydaCalisdigiMuddet from [dbo].[Personel] where isciNomresi="+ input;
                    //  String task2= "SELECT  p.[isciNomresi],p.[Ad],p.[Soyadi],p.UmumiIsSaati,p.UmumiIsDeqiqesi,p.[UmumiIsSaati] * 10 * p.[emekHaqqiEmsali] + round((cast(p.UmumiIsDeqiqesi as decimal(18, 2)) / 60 * 10 * p.[emekHaqqiEmsali]), 2) as EmekHaqqi from(SELECT s.[isciNomresi],[Ad],[Soyadi],[emekHaqqiEmsali],ABS((12 - SUM(w.[girisSaati])) - (12 - SUM(w.[cixisSaati]))) as UmumiIsSaati,ABS((60 - SUM(w.[girisDeqiqesi])) - (60 - SUM(w.[cixisDeqiqesi]))) as UmumiIsDeqiqesi FROM[dbo].[Personel] as s INNER JOIN[dbo].[Worktime] as w on s.isciNomresi = w.isciNomresi group by  s.[isciNomresi],[Ad],[Soyadi], [emekHaqqiEmsali]) as p where p.isciNomresi=" + input;
                    // String task3 = "SELECT isciNomresi, Ad, Soyadi, iseGirisVaxti, Unvan, emekHaqqiEmsali, birAydaCalisdigiMuddet from [dbo].[Personel] where Unvan = '"+ input2 + "'order by emekHaqqiEmsali desc";
                    //  String task4 = " SELECT YEAR(iseGirisVaxti) as Il , COUNT(iseGirisVaxti) as PeronelSay from [dbo].[Personel] group by iseGirisVaxti";
                    // String task5 = "SELECT isciNomresi,COUNT(girisSaati) as GecikdiyiSay from [dbo].[Worktime] where girisSaati> 9 group by isciNomresi";
                    String task6 = "SELECT  p.isciNomresi, CONCAT(Ad, ' ', Soyadi) as 'Ad Soyad', CAST(CONVERT(varchar, DATEADD(SECOND, girisSaati * 3600 + girisDeqiqesi * 60, 0), 108) AS TIME) as GirisVaxti, CAST(CONVERT(varchar, DATEADD(SECOND, cixisSaati * 3600 + cixisDeqiqesi * 60, 0), 108) AS TIME) as CixisVaxti, CONCAT(ABS((12 - SUM(w.[girisSaati])) - (12 - SUM(w.[cixisSaati]))), ' saat ', ABS((60 - SUM(w.[girisDeqiqesi])) - (60 - SUM(w.[cixisDeqiqesi]))), ' dq') as UmumiIslediyiSaat from[dbo].[Personel] as p INNER JOIN[dbo].[Worktime] as w on p.isciNomresi = w.isciNomresi group by  p.[isciNomresi],[Ad],[Soyadi],[cixisSaati],[cixisDeqiqesi],[girisSaati],[girisDeqiqesi]";

                    //Connect to Azure SQL using the connection
                    using (SqlCommand sqlcommand = new SqlCommand(task6, connection))
                    {
                        //Open the connection
                        connection.Open();
                        //Execute the reader function to read the information
                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //task1//
                                //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6));
                                //task2//
                                //   Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDecimal(5));

                                //task3
                                // Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6));
                                //task4
                                //  Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0), reader.GetInt32(1));
                               //task5
                                // Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0), reader.GetInt32(1));
                               //task6
                                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader.GetInt32(0), reader.GetString(1), reader.GetTimeSpan(2), reader.GetTimeSpan(3), reader.GetString(4));


                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                //Write the error message
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
