using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    //*local DB
using System.Data;

namespace Huber_Management
{
    public class users_c
    {
        public int user_id { get; set; }
        public String user_name { get; set; }
        public bool IsAdmin { get; set; }


        public static DataTable Get_by_id(String _id)
        {
            SqlConnection con = Database_c.Get_DB_Connection();
            DataTable table = new DataTable();

            String Query = "SELECT * FROM Users WHERE User_id = @id";

            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.Add(new SqlParameter("@id", _id));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }

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

    }

}
