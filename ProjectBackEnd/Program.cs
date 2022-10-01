//using Microsoft.Extensions.Configuration;
//using System;
//using System.Data.SqlClient;

//namespace ProjectBackEnd
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            bool showMenu = true;
//            while (showMenu)
//            {
//                showMenu = MainMenu();
//            }



//        }
//        private static bool MainMenu()
//        {

//            Console.WriteLine("Getting Connection ...");
//            //Console.Clear();
//            Console.WriteLine("Choose an option:");
//            Console.WriteLine("1) Task1");
//            Console.WriteLine("2) Task2");
//            return MenuSwitch();
//        }

//        private static SqlDataReader Menu(string query)
//        {
//            SqlDataReader sqlDataReader;
//            try
//            {
//                SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
//                conn.DataSource = @"FEXRI\SQLEXPRESS01";//your server
//                conn.InitialCatalog = "ProjectBackend"; //your database name
//                conn.IntegratedSecurity = true;

//                //create instanace of database connection
//                using (SqlConnection connection = new SqlConnection(conn.ConnectionString))

//                {



//                    Console.WriteLine("Query parametr");
//                    //Query used in the code
//                   // String task2= "SELECT  p.[isciNomresi],p.[Ad],p.[Soyadi],p.UmumiIsSaati,p.UmumiIsDeqiqesi,p.[UmumiIsSaati] * 10 * p.[emekHaqqiEmsali] + round((cast(p.UmumiIsDeqiqesi as decimal(18, 2)) / 60 * 10 * p.[emekHaqqiEmsali]), 2) as EmekHaqqi from(SELECT s.[isciNomresi],[Ad],[Soyadi],[emekHaqqiEmsali],ABS((12 - SUM(w.[girisSaati])) - (12 - SUM(w.[cixisSaati]))) as UmumiIsSaati,ABS((60 - SUM(w.[girisDeqiqesi])) - (60 - SUM(w.[cixisDeqiqesi]))) as UmumiIsDeqiqesi FROM[dbo].[Personel] as s INNER JOIN[dbo].[Worktime] as w on s.isciNomresi = w.isciNomresi group by  s.[isciNomresi],[Ad],[Soyadi], [emekHaqqiEmsali]) as p where p.isciNomresi=" +Console.ReadLine();

//                    //Connect to Azure SQL using the connection
//                    using (SqlCommand sqlcommand = new SqlCommand(query, connection))
//                    {
//                        //Open the connection
//                        connection.Open();
//                        //Execute the reader function to read the information
//                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
//                        {
//                            sqlDataReader = reader;
//                            return sqlDataReader;

//                        }
//                    }
//                }
//            }


//            catch (SqlException e)
//            {
//                //Write the error message
//                Console.WriteLine(e.ToString());
//            }
//            return sqlDataReader;
//        }
//        private static bool MenuSwitch()
//        {
//            switch (Console.ReadLine())
//            {
//                case "1":
//                    Test1();
//                    return false;
//                case "2":
//                    return true;
//                case "3":
//                    return false;
//                default:
//                    return true;
//            }

//        }
//        private static string Test1()
//        {
//            String task1 = "SELECT isciNomresi,Ad,Soyadi,iseGirisVaxti,Unvan,emekHaqqiEmsali,birAydaCalisdigiMuddet from [dbo].[Personel] where isciNomresi=";
//            SqlDataReader reader = Menu(task1);
//            Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6));

//            Console.Write("Enter the string you want to modify: ");
//            return Console.ReadLine();
//        }
//    }

//}

