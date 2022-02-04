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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for All_Tools_Row.xaml
    /// </summary>
    public partial class All_Tools_Row : UserControl
    {
        public All_Tools_Row(Tools_c Tool)
        {
            InitializeComponent();

            tools_row_serial_id.Content = Tool.Tool_serial_id;
            tools_row_designation.Text = Tool.Tool_designation;
            tools_row_project.Content = Tool.Tool_project;
            tools_row_process.Content = Tool.Tool_process;
            tools_row_division.Content = Tool.Tool_division;
            tools_row_position.Content = Tool.Tool_position;
            tools_row_stock_mini.Content = Tool.Tool_stock_mini;
            tools_row_actual_stock.Content = Tool.Tool_actual_stock;
            tools_row_supplier.Content = Tool.Tool_supplier;

            int stock_min = int.Parse(tools_row_stock_mini.Content.ToString());
            int actual_stock = int.Parse(tools_row_actual_stock.Content.ToString());

            if ( stock_min == actual_stock )
            {
                Tool_warning.Visibility = Visibility.Visible;
            }
            else if(stock_min > actual_stock)
            {
                Tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FAE7E6");
                tools_row_serial_id.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_designation.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_project.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_process.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_division.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_position.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_stock_mini.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_actual_stock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                tools_row_supplier.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
            }

            if (Tool.Tool_image_path != "")
            {
                try
                {
                    tools_row_image.Source = new BitmapImage(new Uri(Tool.Tool_image_path));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Tool_row_element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                string serial_id = this.tools_row_serial_id.Content.ToString();
                Single_tool_Window tool_details = new Single_tool_Window(serial_id);
                tool_details.Show();
                tool_details.Activate();
            }
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
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure that you want to permanently Delete " + serial_id + " from the database ?", "Delete " + serial_id + " ?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
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

        private void MenuItem_modify_Click(object sender, RoutedEventArgs e)
        {
            Modify_tool_Window big_image = new Modify_tool_Window(tools_row_serial_id.Content.ToString());
            big_image.Show();
        }
    }
}
