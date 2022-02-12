using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//< add using >
using System.Data.SqlClient;    //*local DB
using System.Data;              //*ConnectionState, DataTable
using System.IO;
using System.Diagnostics;
using Grpc.Core;
using System.Windows;

//</ add using >

namespace Huber_Management{

    public static class Database_c{

        private static string connection_string { get; } = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bmrae\source\repos\Huber-Management\Huber-Management\Database\Local-db.mdf;Integrated Security = True";

        private static string cn_String
        { 
            get {
                //string database_path = System.Environment.CurrentDirectory + @"\Database\Local-db.mdf";
                return (connection_string);
            } 
        }

        public static SqlConnection Get_DB_Connection()
        {
            //-------- db_Get_Connection() --------
            //string cn_String = Properties.Settings.Default.connection_string;
            SqlConnection cn_connection = null;
            try
            {
                cn_connection = new SqlConnection(cn_String);
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
            SqlConnection cn_connection = Get_DB_Connection();
            //< get Table >
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);
            adapter.Fill(table);

            return table;
        }

        public static void Execute_SQL(string SQL_Text)
        {
            //--------< Execute_SQL() >--------
            SqlConnection cn_connection = Get_DB_Connection();
            //< get Table >
            SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();

        }

        public static void Close_DB_Connection()
        {
            //--------< Close_DB_Connection() >--------
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }

    }
}