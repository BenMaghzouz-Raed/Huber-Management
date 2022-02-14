using System;
using System.Collections.Generic;
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
    /// Interaction logic for Dashboard_out_of_stock_row.xaml
    /// </summary>
    public partial class Dashboard_out_of_stock_row : UserControl
    {
        public Dashboard_out_of_stock_row(string Tool_serial_id, int Tool_actual_stock, int Tool_stock_mini,
        int needed_quantity, decimal Total_price_nq, string Tool_supplier)
        {
            InitializeComponent();

            tools_row_serial_id.Text = Tool_serial_id;
            tools_row_actual_stock.Content = Tool_actual_stock;
            tools_row_needed_quantity.Content = needed_quantity;

            string total_price_c = Total_price_nq.ToString("C");
            tools_row_total_nq.Content = total_price_c;

            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;
            string price_dt_c = (Total_price_nq * dt_value).ToString("C").Remove(0, 1);
            tools_row_total_nq.ToolTip = price_dt_c + " DT";

            tools_row_supplier.Content = Tool_supplier == "" ? "-" : Tool_supplier;
        }

        public void Tool_row_element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                string serial_id = this.tools_row_serial_id.Text.ToString();
                Single_tool_Window tool_details = new Single_tool_Window(serial_id);
                tool_details.Show();
            }
        }

        private void MenuItem_viewDetails_Click(object sender, RoutedEventArgs e)
        {
            string serial_id = this.tools_row_serial_id.Text.ToString();
            Single_tool_Window tool_details = new Single_tool_Window(serial_id);
            tool_details.Show();
        }

    }
}
