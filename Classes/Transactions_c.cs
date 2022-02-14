using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Huber_Management
{
    public class Transactions_c
    {
        public string Transaction_id { get; set; }
        public int Transaction_quantity { get; set; }
        public string Transaction_tool_serial_id { get; set; }
        public string Transaction_type { get; set; }
        public string Output_requester { get; set; } = "";
        public string Output_DSI { get; set; } = "-";
        public string Transaction_by { get; set; }
        public string Transaction_comment { get; set; }
        public string Transaction_date { get; set; }

        public static DataTable Get_all(SQLiteConnection con)
        {
            DataTable table = new DataTable();

            string Query = "SELECT * FROM Transactions Order by Transaction_date DESC ";

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(Query, con);
            adapter.Fill(table);

            return table;
        }

        // Add Reception 
        public static bool Add_single_Transaction(Transactions_c Transaction, SQLiteConnection con)
        {
            bool isAdded = false;
            DataTable table = new DataTable();

            string[] dateString = string.Join(" ", Transaction.Transaction_date.ToString().Split().Where(x => x != "")).Split('/');
            string date = dateString[1] + "/" + dateString[0] + "/" + dateString[2];
            DateTime Transaction_date = DateTime.ParseExact(date, "MM/dd/yyyy HH:mm:ss", null);

            string Query = "INSERT INTO Transactions (Transaction_quantity, Transaction_tool_serial_id, Transaction_type," +
                " Output_requester, Output_DSI, Transaction_by, Transaction_comment, Transaction_date)" +
                "VALUES (@Transaction_quantity, @Transaction_tool_serial_id, @Transaction_type, " +
                "@Output_requester, @Output_DSI, @Transaction_by, @Transaction_comment, @Transaction_date)";

            SQLiteCommand command = new SQLiteCommand(Query, con);
            command.Parameters.AddWithValue("@Transaction_quantity", Transaction.Transaction_quantity);

            command.Parameters.AddWithValue("@Transaction_type", Transaction.Transaction_type);

            string transaction_tool_serial_id = string.Join(" ", Transaction.Transaction_tool_serial_id.ToString().Split().Where(x => x != ""));
            command.Parameters.AddWithValue("@Transaction_tool_serial_id", transaction_tool_serial_id);

            string Output_requester = string.Join(" ", Transaction.Output_requester.ToString().Split().Where(x => x != ""));
            command.Parameters.AddWithValue("@Output_requester", Output_requester);

            string Output_dsi = string.Join(" ", Transaction.Output_DSI.ToString().Split().Where(x => x != ""));
            command.Parameters.AddWithValue("@Output_DSI", Output_dsi);

            string transaction_by = string.Join(" ", Transaction.Transaction_by.ToString().Split().Where(x => x != ""));
            command.Parameters.AddWithValue("@Transaction_by", transaction_by);

            string transaction_comment = string.Join(" ", Transaction.Transaction_comment.ToString().Split().Where(x => x != ""));
            command.Parameters.AddWithValue("@Transaction_comment", transaction_comment);

            command.Parameters.AddWithValue("@Transaction_date", Transaction_date);

            command.ExecuteNonQuery();

            isAdded = true;

            return isAdded;
        }

        public static async void Get_all_Receptions(SQLiteConnection con)
        {
            string Query = "SELECT * FROM Transactions WHERE Transaction_type = 'IN' DESC";
            SQLiteCommand command = new SQLiteCommand(Query, con);
            await Task.Run(() => command.ExecuteNonQuery());
        }

        public static async void Get_all_Output(SQLiteConnection con)
        {
            string Query = "SELECT * FROM Transactions WHERE Transaction_type = 'OUT' DESC";
            SQLiteCommand command = new SQLiteCommand(Query, con);
            await Task.Run(() => command.ExecuteNonQuery());
        }
    }
}
