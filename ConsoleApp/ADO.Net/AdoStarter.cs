using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                connection.Open();
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
