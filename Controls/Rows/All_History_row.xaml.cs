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
using System.Windows.Shapes;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for All_History_row.xaml
    /// </summary>
    public partial class All_History_row : UserControl
    {
        public All_History_row(
            string history_date,
            string history_time,
            string tool_image_path,
            string tool_serial_id,
            string history_type,
            string history_quantity,
            string history_price,
            string history_requester,
            string history_supplier,
            string history_by,
            string history_comment)
        {
            InitializeComponent();

            this.history_date.Content = history_date;
            this.history_time.Content = history_time;
            tools_row_serial_id.Content = tool_serial_id;
            this.history_type.Content = history_type;
            this.history_quantity.Content = history_quantity;
            this.history_requester.Content = history_requester;
            this.history_supplier.Content = history_supplier;
            this.history_by.Content = history_by;
            this.history_comment.Text = history_comment;

            // CONVERT PRICE
            decimal price = 0;
            decimal.TryParse(history_price, out price);
            string price_c = price.ToString("C");
            this.history_price.Content = price_c;
            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;
            string price_dt_c = (price * dt_value).ToString("C").Remove(0, 1);
            this.history_price.ToolTip = price_dt_c + " DT";

            // CONVERT TOTAL PRICE
            decimal total_price = (decimal)(price * int.Parse(history_quantity) );
            string total_price_c = total_price.ToString("C");
            string total_price_dt_c = (total_price * dt_value).ToString("C").Remove(0, 1);
            this.history_total_price.Content = total_price_c;
            this.history_total_price.ToolTip = total_price_dt_c + " DT";

            if (history_type == "OUT")
            {
                this.history_type.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                History_tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FAE7E6");
            }
            else if (history_type == "IN")
            {
                History_tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#E6F6E9");
            }

            if (tool_image_path != "")
            {
                try
                {
                    tools_row_image.Source = new BitmapImage(new Uri(tool_image_path));
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
