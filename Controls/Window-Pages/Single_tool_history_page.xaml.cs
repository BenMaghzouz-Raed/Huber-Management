using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for Single_tool_history_page.xaml
    /// </summary>
    public partial class Single_tool_history_page : Page
    {
        public Single_tool_history_page(string serial_id)
        {
            InitializeComponent();
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            InitializeData(serial_id, conn);
            Database_c.Get_DB_Connection();
        }

        public async void InitializeData(string serial_id, SQLiteConnection conn)
        {
            // Transactions
            DataTable table1 = new DataTable();
            string Query1 = "SELECT * FROM Transactions WHERE (Transaction_tool_serial_id = '" + serial_id + "') Order By Transaction_date DESC";
            SQLiteDataAdapter adapter1 = await Task.Run(() => new SQLiteDataAdapter(Query1, conn));
            adapter1.Fill(table1);
            if (table1.Rows.Count > 0)
            {
                Transactions_rows_panel.Children.Clear();
                foreach (DataRow row in table1.Rows)
                {
                    string[] date = row["Transaction_date"].ToString().Split(null);
                    Transactions_rows_panel.Children.Add(new Single_Tool_Transactions_Row(
                    date[0],
                    date[1],
                    row["Transaction_type"].ToString(),
                    row["Transaction_quantity"].ToString(),
                    row["Output_requester"].ToString(),
                    row["Transaction_by"].ToString(),
                    row["Transaction_comment"].ToString()
                    ));
                }
            }
        }

    }
}
