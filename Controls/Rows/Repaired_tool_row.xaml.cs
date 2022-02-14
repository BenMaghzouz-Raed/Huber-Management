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
    /// Interaction logic for Repaired_tool_row.xaml
    /// </summary>
    public partial class Repaired_tool_row : UserControl
    {
        public Repaired_tool_row(Tools_c Tool, string repaired_id, string causes, string repaired_date, string repaired_quantity, string repaired_by)
        {
            InitializeComponent();
            InitializeOneRow(Tool, repaired_id, causes, repaired_date, repaired_quantity, repaired_by);
        }

        public void InitializeOneRow(Tools_c Tool, string repaired_id, string causes, string repaired_date, string repaired_quantity, string repaired_by)
        {   
            this.repaired_id.Content = repaired_id;

            string[] date = repaired_date.Split(null);
            this.repaired_date.Content = date[0];

            if (Tool.Tool_image_path != "")
            {
                tools_row_image.Source = new BitmapImage(new Uri(Tool.Tool_image_path));
            }
            tools_row_serial_id.Content = Tool.Tool_serial_id;
            tools_row_designation.Text = Tool.Tool_designation;

            this.repaired_quantity.Content = repaired_quantity;
            this.reception_by.Text = repaired_by;

            decimal price = 0;
            decimal.TryParse(Tool.Tool_price.ToString(), out price);
            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;

            decimal total_price = (decimal)(price * int.Parse(repaired_quantity));
            string total_price_c = total_price.ToString("C");
            string total_price_dt_c = (total_price * dt_value).ToString("C").Remove(0, 1);
            this.repaired_total.Content = total_price_c;
            this.repaired_total.ToolTip = total_price_dt_c + " DT";

            this.repaired_causes.Text = causes;
        }

        public void Tool_row_element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                string serial_id = this.tools_row_serial_id.Content.ToString();
                Single_tool_Window tool_details = new Single_tool_Window(serial_id);
                tool_details.Show();
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
    }
}
