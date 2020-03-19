using System;
using System.Data.Common;
using System.Data.OleDb;
using Microsoft.Data.Sqlite;


namespace ConsoleApp.ADO.Net
{
    internal static class AdoStarter
    {
        public static void Run()
        {
            CreateConnectionSqlite();
            //CreateConnectionMdb();
        }

        private static void CreateConnectionMdb()
        {
            var olebuilder = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.Jet.OLEDB.4.0",
                DataSource = @"D:\WORK\PROTOTYPE\ConsoleApp\ADO.Net\Db\Base_2.mdb"
            };
            var connectionString = olebuilder.ToString();
            using (var connection = new OleDbConnection(connectionString))
            {
                //await connection.OpenAsync();
                connection.Open();
                WriteConnectionInfo(connection);
            }
        }

        private static void CreateConnectionSqlite()
        {
            //var csb = new SqliteConnectionStringBuilder()
            //{
            //    DataSource = @"D:\_Dbs\Base_1.db"
            //};
            //using (var connection = new SqliteConnection(csb.ToString()))
            //{
            //    connection.Open();
            //    WriteConnectionInfo(connection);
            //}
        }

        private static void WriteConnectionInfo(DbConnection connection)
        {
            // Вывод информации о подключении
            Console.WriteLine("Свойства подключения:");
            Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
            Console.WriteLine("\tБаза данных: {0}", connection.Database);
            Console.WriteLine("\tСервер: {0}", connection.DataSource);
            Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
            Console.WriteLine("\tСостояние: {0}", connection.State);
        }
    }
}
