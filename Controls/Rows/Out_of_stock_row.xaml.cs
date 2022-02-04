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
        public Out_of_stock_row(Tools_c out_of_stock_tool)
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

            tools_row_serial_id.Content = out_of_stock_tool.Tool_serial_id;
            tools_row_actual_stock.Content = out_of_stock_tool.Tool_actual_stock;
            tools_row_stock_mini.Content = out_of_stock_tool.Tool_stock_mini;
            tools_row_needed_quantity.Content = out_of_stock_tool.Tool_stock_mini - out_of_stock_tool.Tool_actual_stock;

            decimal price = 0;
            decimal.TryParse(((out_of_stock_tool.Tool_stock_mini - out_of_stock_tool.Tool_actual_stock) * out_of_stock_tool.Tool_price).ToString(), out price);
            string price_c = price.ToString("C").Remove(0, 1) + " €";
            string price_dt_c = (price * 3).ToString("C").Remove(0, 1);
            tools_row_total_nq.Content = price_c;
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
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
        }

        public void criticality_converter(int criticality_val)
        {
            string converted_value = "";
            switch (criticality_val)
            {
                case <= 15:
                    tool_criticality.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FBEDD9");
                    tool_criticality.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFA427");
                    tool_criticality.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFA427");
                    converted_value = "C";
                    break;
                case <= 60:
                    converted_value = "B";
                    break;
                case <= 90:
                    converted_value = "A";
                    break;
                default:
                    converted_value = "A";
                    break;
            }

            tool_criticality.Text = converted_value;
            tool_criticality.ToolTip = criticality_val.ToString() + " Days";

        }

    }
}
