using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for search_from_defective_page.xaml
    /// </summary>
    public partial class search_from_defective_page : Page
    {
        public search_from_defective_page(string serial_nb_detail = null, string defective_id = "", string defective_quantity = "")
        {
            InitializeComponent();

            SqlConnection conn = Database_c.Get_DB_Connection();
            if (serial_nb_detail != null)
            {
                DataTable result = Tools_c.Get_by_serial_id(serial_nb_detail, conn);
                searched_rows_panel.Children.Clear();
                searched_rows_panel.Children.Add(new Controls.Search_from_defective_row(
                                defective_id,
                                result.Rows[0]["Tool_serial_id"].ToString(),
                                result.Rows[0]["Tool_image_path"].ToString(),
                                defective_quantity,
                                result.Rows[0]["Tool_designation"].ToString(), true)
                    );
                searched_result.Visibility = Visibility.Visible;
            }

            Database_c.Close_DB_Connection();

        }

        private async void search_for_tools_to_add_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _search_text = ((TextBox)search_for_tools_to_add).Text.ToString();
            if (_search_text.Length > 0)
            {
                SqlConnection conn = Database_c.Get_DB_Connection();
                DataTable result = new DataTable();
                // Create the Query
                string query = "Select top 5 * FROM Faulty_Tools LEFT JOIN Tools ON (Faulty_Tools.Tool_serial_id = Tools.Tool_serial_id) WHERE (Faulty_Tools.Tool_serial_id LIKE '%" + _search_text + "%') AND Faulty_Tools.Faulty_quantity > 0 ORDER By Faulty_Tools.added_date";
                // Execute the Query 
                SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
                await Task.Run(() => adapter.Fill(result));
                if (result.Rows.Count > 0)
                {
                    searched_rows_panel.Children.Clear();
                    foreach (DataRow row in result.Rows)
                    {
                        searched_rows_panel.Children.Add(new Controls.Search_from_defective_row(
                            row["Faulty_tool_id"].ToString(),
                            row["Tool_serial_id"].ToString(),
                            row["Tool_image_path"].ToString(),
                            row["Faulty_quantity"].ToString(),
                            row["Tool_designation"].ToString()
                            ));
                    }
                    searched_result.Visibility = Visibility.Visible;
                    Database_c.Close_DB_Connection();
                }
                else
                {
                    searched_result.Visibility = Visibility.Collapsed;
                }
            }
        }

    }
}
