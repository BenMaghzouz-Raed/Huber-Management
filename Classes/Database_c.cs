using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//< add using >
using System.Data.SQLite;    //*local DB
using System.Data;              //*ConnectionState, DataTable
using System.IO;
using System.Diagnostics;
using Grpc.Core;
using System.Windows;

//</ add using >

namespace Huber_Management{

    public static class Database_c{

        public static string connection_string { get; set; }

        public static SQLiteConnection Get_DB_Connection()
        {
            //string full_path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\data1.sqlite").ToString();
            connection_string = @"Data Source=" + path;

            //-------- db_Get_Connection() --------
            //string cn_String = Properties.Settings.Default.connection_string;
            SQLiteConnection cn_connection = null;
            try
            {
                cn_connection = new SQLiteConnection(connection_string);
                if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return cn_connection;

        }

        public static DataTable Get_DataTable(string SQL_Text)
        {
            //-------- db_Get_DataTable() --------
            SQLiteConnection cn_connection = Get_DB_Connection();
            //< get Table >
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQL_Text, cn_connection);
            adapter.Fill(table);

            return table;
        }

        public static void Execute_SQL(string SQL_Text)
        {
            //--------< Execute_SQL() >--------
            SQLiteConnection cn_connection = Get_DB_Connection();
            //< get Table >
            SQLiteCommand cmd_Command = new SQLiteCommand(SQL_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();

        }

        public static void Close_DB_Connection()
        {
            //--------< Close_DB_Connection() >--------
            SQLiteConnection cn_connection = new SQLiteConnection(connection_string);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }

    }
}