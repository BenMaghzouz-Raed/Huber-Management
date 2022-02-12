using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    //*local DB
using System.Data;
using System.Windows;

namespace Huber_Management
{
    public class users_c
    {
        public string user_name { get; set; }
        public string user_fullName { get; set; } = "";
        public bool IsAdmin { get; set; } = false;
        public bool isConnected { get; set; } = false;
        public string user_added_date { get; set; } = "";
        public string last_login { get; set; } = "";
        public string privileges_id { get; set; } = "";
        public bool canDelete { get; set; } = false;
        public bool canEdit { get; set; } = false;
        public bool canAdd { get; set; } = false;
        public bool canReception { get; set; } = false;
        public bool canCheckout { get; set; } = false;
        public bool canPurchaseOrder { get; set; } = false;

        public static DataTable Get_by_name(String _name)
        {
            SqlConnection con = Database_c.Get_DB_Connection();
            DataTable table = new DataTable();

            String Query = "SELECT * FROM Users WHERE User_name = @username";

            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.Add(new SqlParameter("@username", _name));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }

        public static bool isExist_user_name(string _user_name, SqlConnection con)
        {
            DataTable table = new DataTable();

            string Query = "SELECT COUNT(*) as count_id FROM Users WHERE User_name = @user_name";

            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.Add(new SqlParameter("@user_name", _user_name));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            int number = int.Parse(table.Rows[0]["count_id"].ToString());
            bool test = (number == 0) ? false : true;

            return test;
        }

        public static void Delete_by_user_name(string _user_name, SqlConnection con)
        {
            string Query = "Delete FROM Users WHERE User_name = @user_name";
            try
            {
                SqlCommand command = new SqlCommand(Query, con);
                command.Parameters.Add(new SqlParameter("@user_name", _user_name));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            finally
            {
                MessageBox.Show("'" + _user_name + "' Account deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        //public static string getConnectedUserUserName(SqlConnection conn)
        //{
        //    string query = "SELECT User_name FROM Users WHERE isConnected = 1";
        //    DataTable table = new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
        //    adapter.Fill(table);

        //    if (table.Rows.Count > 0)
        //    {
        //        return table.Rows[0]["User_name"].ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }

        //}

    }

}
