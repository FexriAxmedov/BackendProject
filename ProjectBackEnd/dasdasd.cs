




//using microsoft.extensions.configuration;
//using system;
//using system.data.sqlclient;

//namespace projectbackend
//{
//    class program
//    {
//        static void main(string[] args)
//        {
//            console.writeline("getting connection ...");
//            try
//            {
//                sqlconnectionstringbuilder conn = new sqlconnectionstringbuilder();
//                conn.datasource = @"fexri\sqlexpress01";//your server
//                conn.initialcatalog = "projectbackend"; //your database name
//                conn.integratedsecurity = true;

//                create instanace of database connection
//                using (sqlconnection connection = new sqlconnection(conn.connectionstring))
//                {
//                    int input = convert.toint32(console.readline());
//                    string input2 = console.readline();

//                    query used in the code
//                      string task1 = "select iscinomresi,ad,soyadi,isegirisvaxti,unvan,emekhaqqiemsali,biraydacalisdigimuddet from [dbo].[personel] where iscinomresi=" + input;
//                    string task2 = "select  p.[iscinomresi],p.[ad],p.[soyadi],p.umumiissaati,p.umumiisdeqiqesi,p.[umumiissaati] * 10 * p.[emekhaqqiemsali] + round((cast(p.umumiisdeqiqesi as decimal(18, 2)) / 60 * 10 * p.[emekhaqqiemsali]), 2) as emekhaqqi from(select s.[iscinomresi],[ad],[soyadi],[emekhaqqiemsali],abs((12 - sum(w.[girissaati])) - (12 - sum(w.[cixissaati]))) as umumiissaati,abs((60 - sum(w.[girisdeqiqesi])) - (60 - sum(w.[cixisdeqiqesi]))) as umumiisdeqiqesi from[dbo].[personel] as s inner join[dbo].[worktime] as w on s.iscinomresi = w.iscinomresi group by  s.[iscinomresi],[ad],[soyadi], [emekhaqqiemsali]) as p where p.iscinomresi=" + input;
//                    string task3 = "select iscinomresi, ad, soyadi, isegirisvaxti, unvan, emekhaqqiemsali, biraydacalisdigimuddet from [dbo].[personel] where unvan = '" + input2 + "'order by emekhaqqiemsali desc";
//                    string task4 = " select year(isegirisvaxti) as il , count(isegirisvaxti) as peronelsay from [dbo].[personel] group by isegirisvaxti";
//                    string task5 = "select iscinomresi,count(girissaati) as gecikdiyisay from [dbo].[worktime] where girissaati> 9 group by iscinomresi";
//                    string task6 = "select  p.iscinomresi, concat(ad, ' ', soyadi) as 'ad soyad', cast(convert(varchar, dateadd(second, girissaati * 3600 + girisdeqiqesi * 60, 0), 108) as time) as girisvaxti, cast(convert(varchar, dateadd(second, cixissaati * 3600 + cixisdeqiqesi * 60, 0), 108) as time) as cixisvaxti, concat(abs((12 - sum(w.[girissaati])) - (12 - sum(w.[cixissaati]))), ' saat ', abs((60 - sum(w.[girisdeqiqesi])) - (60 - sum(w.[cixisdeqiqesi]))), ' dq') as umumiislediyisaat from[dbo].[personel] as p inner join[dbo].[worktime] as w on p.iscinomresi = w.iscinomresi group by  p.[iscinomresi],[ad],[soyadi],[cixissaati],[cixisdeqiqesi],[girissaati],[girisdeqiqesi]";

//                    connect to azure sql using the connection
//                    using (sqlcommand sqlcommand = new sqlcommand(task6, connection))
//                    {
//                        open the connection
//                        connection.open();
//                        execute the reader function to read the information
//                        using (sqldatareader reader = sqlcommand.executereader())
//                        {
//                            while (reader.read())
//                            {
//                               // task1
//                                console.writeline("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.getint32(0), reader.getstring(1), reader.getstring(2), reader.getdatetime(3), reader.getstring(4), reader.getdecimal(5), reader.getint32(6));
//                              //  task2//
//                                   console.writeline("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader.getint32(0), reader.getstring(1), reader.getstring(2), reader.getint32(3), reader.getint32(4), reader.getdecimal(5));

//                               // task3
//                                 console.writeline("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.getint32(0), reader.getstring(1), reader.getstring(2), reader.getdatetime(3), reader.getstring(4), reader.getdecimal(5), reader.getint32(6));
//                               // task4
//                                  console.writeline("\t{0}\t{1}", reader.getint32(0), reader.getint32(1));
//                              //  task5
//                                 console.writeline("\t{0}\t{1}", reader.getint32(0), reader.getint32(1));
//                              //  task6
//                                console.writeline("\t{0}\t{1}\t{2}\t{3}\t{4}", reader.getint32(0), reader.getstring(1), reader.gettimespan(2), reader.gettimespan(3), reader.getstring(4));


//                            }
//                        }
//                    }
//                }
//            }
//            catch (sqlexception e)
//            {
//             //   write the error message
//                console.writeline(e.tostring());
//            }
//            console.readline();
//        }
//    }
//}
