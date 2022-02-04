using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public string Transaction_req_prov { get; set; } = "";
        public string Transaction_by { get; set; }
        public string Transaction_comment { get; set; }
        public string Transaction_date { get; set; }

        public static DataTable Get_all(SqlConnection con)
        {
            DataTable table = new DataTable();

            string Query = "SELECT * FROM Transactions Order by Transaction_date DESC ";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            adapter.Fill(table);

            return table;
        }

        // Add Reception 
        public static bool Add_single_Transaction(Transactions_c Transaction, SqlConnection con)
        {
            bool isAdded = false;
            DataTable table = new DataTable();

            string[] dateString = string.Join(" ", Transaction.Transaction_date.ToString().Split().Where(x => x != "")).Split('/');
            string date = dateString[1] + "/" + dateString[0] + "/" + dateString[2];
            DateTime Transaction_date = DateTime.ParseExact(date, "MM/dd/yyyy HH:mm:ss", null);

            string Query = "INSERT INTO Transactions (Transaction_quantity, Transaction_tool_serial_id, Transaction_type," +
                " Transaction_req_prov, Transaction_by, Transaction_comment, Transaction_date)" +
                "VALUES (@Transaction_quantity, @Transaction_tool_serial_id, @Transaction_type, " +
                "@Transaction_req_prov, @Transaction_by, @Transaction_comment, @Transaction_date)";

            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.Add(new SqlParameter("@Transaction_quantity", Transaction.Transaction_quantity));

            command.Parameters.Add(new SqlParameter("@Transaction_type", Transaction.Transaction_type));

            string transaction_tool_serial_id = string.Join(" ", Transaction.Transaction_tool_serial_id.ToString().Split().Where(x => x != ""));
            command.Parameters.Add(new SqlParameter("@Transaction_tool_serial_id", transaction_tool_serial_id));

            string transaction_req_prov = string.Join(" ", Transaction.Transaction_req_prov.ToString().Split().Where(x => x != ""));
            command.Parameters.Add(new SqlParameter("@Transaction_req_prov", transaction_req_prov));

            string transaction_by = string.Join(" ", Transaction.Transaction_by.ToString().Split().Where(x => x != ""));
            command.Parameters.Add(new SqlParameter("@Transaction_by", transaction_by));

            string transaction_comment = string.Join(" ", Transaction.Transaction_comment.ToString().Split().Where(x => x != ""));
            command.Parameters.Add(new SqlParameter("@Transaction_comment", transaction_comment));

            command.Parameters.Add(new SqlParameter("@Transaction_date", Transaction_date));

            command.ExecuteNonQuery();

            isAdded = true;

            return isAdded;
        }

        public static bool Delete_all(SqlConnection con)
        {
            bool deleted = false;
            try
            {
                string Query = "Delete FROM Transactions";
                SqlCommand command = new SqlCommand(Query, con);
                command.ExecuteNonQuery();
                deleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return deleted;
        }

        public static async void Get_all_Receptions(SqlConnection con)
        {
            string Query = "SELECT * FROM Transactions WHERE Transaction_type = 'IN' DESC";
            SqlCommand command = new SqlCommand(Query, con);
            await Task.Run(() => command.ExecuteNonQuery());
        }

        public static async void Get_all_Output(SqlConnection con)
        {
            string Query = "SELECT * FROM Transactions WHERE Transaction_type = 'OUT' DESC";
            SqlCommand command = new SqlCommand(Query, con);
            await Task.Run(() => command.ExecuteNonQuery());
        }
    }
}
