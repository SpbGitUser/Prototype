using System;
using System.Data.OleDb;


namespace ConsoleApp.ADO.Net
{
    internal static class AdoStarter
    {
        public static void Run()
        {
            //CreateConnectionSqlite();
            CreateConnectionMdb();
        }

        private static void CreateConnectionMdb()
        {
            var olebuilder = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.Jet.OLEDB.4.0",
                DataSource = @"D:\WORK\PROTOTYPE\ConsoleApp\ADO.Net\Db\Base_2.mdb"
            };
            var connsenctionString = olebuilder.ToString();
            using (var connection = new OleDbConnection(connsenctionString))
            {
                //await connection.OpenAsync();
                connection.Open();

                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);
                //Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
            }
        }

        //private static void CreateConnectionSqlite()
        //{
        //    var connsenctionString = @"D:\WORK\PROTOTYPE\ConsoleApp\ADO.Net\Db\Base_1.db;Version=3;";
        //    using (var connection = new SQLiteConnection(connsenctionString))
        //    {
        //        connection.Open();
        //    }
        //}
    }
}
