using System;
using LiveCharts;
using LiveCharts.Wpf;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Huber_Management.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard_page.xaml
    /// </summary>
    public partial class Dashboard_page : Page
    {
        public Dashboard_page()
        {
            InitializeComponent();
            SqlConnection conn = Database_c.Get_DB_Connection();
            InitializeStatistic(conn);
            InitializeChart();
            InitializeOutOfStockTable(conn);
            Database_c.Close_DB_Connection();
        }

        public void InitializeStatistic(SqlConnection conn)
        {
            DataTable total_tool = new DataTable();
            string query = "SELECT COUNT(Tool_serial_id) as Total, SUM(Tool_actual_stock*Tool_price) as PRICE From Tools";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(total_tool);
            if(total_tool.Rows.Count > 0)
            {
                DataRow row = total_tool.Rows[0];
                total_tools.Content = row["Total"].ToString();

                decimal price = 0;
                decimal.TryParse(row["PRICE"].ToString(), out price);
                string price_c = price.ToString("C").Remove(0, 1);
                total_price.Text = price_c + " €";

                decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;
                string price_dt_c = (price*dt_value).ToString("C").Remove(0, 1);
                total_price.ToolTip = price_dt_c + " DT";
            }

            // Total Saving
            DataTable total_saving = new DataTable();
            string query1 = "SELECT SUM(Repaired_quantity*Tool_price) as SAVING From Tools, Repaired_Tools WHERE ( Repaired_Tools.Tool_serial_id = Tools.Tool_serial_id )";
            SqlDataAdapter adapter1 = new SqlDataAdapter(query1, conn);
            adapter1.Fill(total_saving);

            if (total_saving.Rows.Count > 0)
            {
                DataRow row = total_saving.Rows[0];

                decimal saving = 0;
                decimal.TryParse(row["SAVING"].ToString(), out saving);
                string price_c = saving.ToString("C").Remove(0, 1);
                total_gain.Content = price_c + " €";

                decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;
                string price_dt_c = (saving * dt_value).ToString("C").Remove(0, 1);
                total_gain.ToolTip = price_dt_c + " DT";
            }

        }

        public async void InitializeOutOfStockTable(SqlConnection conn)
        {
            DataTable all_data = new DataTable();
            string query = "Select * FROM Tools WHERE (Tool_actual_stock < Tool_stock_mini) Order by Tool_date_added DESC";
            SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
            await Task.Run(() => adapter.Fill(all_data));

            if(all_data.Rows.Count > 0)
            {
                Out_of_stock_rows_panel.Children.Clear();
                Out_of_stock_Header.Visibility = System.Windows.Visibility.Visible;
                foreach (DataRow row in all_data.Rows)
                {
                    string Tool_serial_id = (string)row["Tool_serial_id"];
                    int Tool_actual_stock = (int)row["Tool_actual_stock"];
                    int Tool_stock_mini = (int)row["Tool_stock_mini"];
                    int needed_quantity = Tool_stock_mini - Tool_actual_stock;
                    decimal Total_price_nq = (decimal)row["Tool_price"] * needed_quantity;
                    string Tool_supplier = (string)row["Tool_supplier"];
                    string Tool_image_path = (string)row["Tool_image_path"];

                    Out_of_stock_rows_panel.Children.Add(new Controls.Dashboard_out_of_stock_row(
                        Tool_serial_id, Tool_actual_stock, Tool_stock_mini,
                        needed_quantity, Total_price_nq, Tool_supplier));
                }
            }
        }

        public void InitializeChart()
        {
            InputChart.ChartTitle.Text = "Monthly Saving";
        }

    }
}
