using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for Out_of_stock_row.xaml
    /// </summary>
    public partial class Out_of_stock_row : UserControl
    {
        public Out_of_stock_row(Tools_c out_of_stock_tool, bool isChecked = false)
        {
            InitializeComponent();
            if (out_of_stock_tool.Tool_image_path != "")
            {
                try
                {
                    tools_row_image.Source = new BitmapImage(new Uri(out_of_stock_tool.Tool_image_path));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            checkbox.IsChecked = isChecked;
            tools_row_serial_id.Content = out_of_stock_tool.Tool_serial_id;
            tools_row_actual_stock.Content = out_of_stock_tool.Tool_actual_stock;
            tools_row_stock_mini.Content = out_of_stock_tool.Tool_stock_mini;
            tools_row_needed_quantity.Content = out_of_stock_tool.Tool_stock_mini - out_of_stock_tool.Tool_actual_stock;

            decimal price = 0;
            decimal.TryParse(((out_of_stock_tool.Tool_stock_mini - out_of_stock_tool.Tool_actual_stock) * out_of_stock_tool.Tool_price).ToString(), out price);
            string price_c = price.ToString("C").Remove(0, 1);

            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;
            string price_dt_c = (price * dt_value).ToString("C").Remove(0, 1);
            tools_row_total_nq.Content = price_c + " €";
            tools_row_total_nq.ToolTip = price_dt_c + " DT";

            tools_row_supplier.Content = out_of_stock_tool.Tool_supplier;
            criticality_converter(out_of_stock_tool.Tool_criticality);
        }

        public void Tool_row_element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ClickCount == 2)
            //{
            //    string serial_id = this.tools_row_serial_id.Content.ToString();
            //    Single_tool_Window tool_details = new Single_tool_Window(serial_id);
            //    tool_details.Show();
            //}

            this.checkbox.IsChecked = !checkbox.IsChecked.Value;
        }

        private void MenuItem_viewDetails_Click(object sender, RoutedEventArgs e)
        {
            string serial_id = this.tools_row_serial_id.Content.ToString();
            Single_tool_Window tool_details = new Single_tool_Window(serial_id);
            tool_details.Show();
        }

        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = Database_c.Get_DB_Connection();
            string serial_id = this.tools_row_serial_id.Content.ToString();
            MessageBoxResult dialogResult = MessageBox.Show("Are u sur you want to Delete " + serial_id + " from the database ?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.OK)
            {
                Tools_c.Delete_by_serial_id(serial_id, conn);
            }
            Database_c.Close_DB_Connection();
        }

        private void MenuItem_viewImage_Click(object sender, RoutedEventArgs e)
        {
            Open_image_window big_image = new Open_image_window(tools_row_image.Source, tools_row_serial_id.Content.ToString());
            big_image.Show();
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#DFEDF7");
            if (!Pages.Purchase_order_page.selected_serial_id.Contains(this.tools_row_serial_id.Content.ToString()))
            {
                Pages.Purchase_order_page.selected_serial_id.Add(this.tools_row_serial_id.Content.ToString());
            }
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            if (Pages.Purchase_order_page.selected_serial_id.Contains(this.tools_row_serial_id.Content.ToString()))
            {
                Pages.Purchase_order_page.selected_serial_id.Remove(this.tools_row_serial_id.Content.ToString());
            }
        }

        public void criticality_converter(int criticality_val)
        {
            string converted_value = "A";

            int A_value = MainWindow.Default_settings.Criticality_A_value;
            int B_value = MainWindow.Default_settings.Criticality_B_value;
            int C_value = MainWindow.Default_settings.Criticality_C_value;
            if (criticality_val <= C_value)
            {
                tool_criticality.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#005596");
                converted_value = "C";
            }
            else if (criticality_val <= B_value && criticality_val > C_value)
            {
                tool_criticality.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#DF781C");
                converted_value = "B";
            }
            else if( criticality_val <= A_value && criticality_val > B_value)
            {
                converted_value = "A";
            }

            tool_criticality.Text = converted_value;
            tool_criticality.ToolTip = "Lead time = " + criticality_val.ToString() + " Days";
        }

    }
}
