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
    /// Interaction logic for Reception_Row.xaml
    /// </summary>
    public partial class Reception_Row : UserControl
    {
        public Reception_Row(Transactions_c Reception, Tools_c Tool)
        {
            InitializeComponent();
            InitializeOneRow(Reception, Tool);
        }

        public void InitializeOneRow(Transactions_c Reception, Tools_c Tool)
        {
            reception_id.Content = Reception.Transaction_id;

            string[] date = Reception.Transaction_date.Split(null);
            reception_date.Content = date[0];

            if (Tool.Tool_image_path != "")
            {
                tools_row_image.Source = new BitmapImage(new Uri(Tool.Tool_image_path));
            }
            tools_row_serial_id.Content = Reception.Transaction_tool_serial_id;
            tools_row_designation.Text = Tool.Tool_designation;

            reception_quantity.Content = Reception.Transaction_quantity;
            tools_row_supplier.Content = Tool.Tool_supplier;

            decimal price = 0;
            decimal.TryParse(Tool.Tool_price.ToString(), out price);
            string price_c = price.ToString("C").Remove(0, 1);

            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;
            string price_dt_c = (price*dt_value).ToString("C").Remove(0, 1);
            tools_row_price.Content = price_c + " €";
            tools_row_price.ToolTip = price_dt_c + " DT";

            decimal total_price = (decimal)( price * (int)Reception.Transaction_quantity);
            string total_price_c = total_price.ToString("C").Remove(0, 1);
            string total_price_dt_c = (total_price*dt_value).ToString("C").Remove(0, 1);
            tools_row_total.Content = total_price_c + " €";
            tools_row_total.ToolTip = total_price_dt_c + " DT";

            reception_by.Text = Reception.Transaction_by;

            // PRIVILEGES SETTINGS
            if (!MainWindow.Connected_user.canDelete)
            {
                MenuItem_Delete.Visibility = Visibility.Collapsed;
            }
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

        private async void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            string serial_id = this.tools_row_serial_id.Content.ToString();
            string reception_id = this.reception_id.Content.ToString();

            MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to Cancel this transaction for " + serial_id + " ?", "Cancel Transaction", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.OK)
            {
                SqlConnection conn = Database_c.Get_DB_Connection();

                try
                {
                    int quantity = 0;
                    int.TryParse(this.reception_quantity.Content.ToString(), out quantity);
                    // check if the wanted quantity is valid
                    DataTable result = Tools_c.Get_by_serial_id(serial_id, conn);
                    int actual_stock = int.Parse(result.Rows[0]["Tool_actual_stock"].ToString());

                    if(actual_stock >= quantity)
                    {
                        string Query = "Delete FROM Transactions WHERE (Transaction_id = @reception_id) AND (Transaction_tool_serial_id = @serial_id)";
                        SqlCommand command = new SqlCommand(Query, conn);
                        command.Parameters.Add(new SqlParameter("@serial_id", serial_id));
                        command.Parameters.Add(new SqlParameter("@reception_id", reception_id));
                        command.ExecuteNonQuery();
                        
                        string Updatequery = "UPDATE Tools SET Tool_actual_stock = Tool_actual_stock - @Transaction_quantity WHERE Tool_serial_id = @Tool_serial_id";
                        SqlCommand command2 = new SqlCommand(Updatequery, conn);
                        command2.Parameters.Add(new SqlParameter("@Tool_serial_id", serial_id));
                        command2.Parameters.Add(new SqlParameter("@Transaction_quantity", quantity));

                        await Task.Run(() => command2.ExecuteNonQuery());
                    }
                    else
                    {
                        MessageBox.Show("Sorry we can't cancel this transaction for " + serial_id + "! You need to cancel other transactions first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    Database_c.Close_DB_Connection();
                    return;
                }
                Database_c.Close_DB_Connection();
            }
        }

        private void MenuItem_viewImage_Click(object sender, RoutedEventArgs e)
        {
            Open_image_window big_image = new Open_image_window(tools_row_image.Source, tools_row_serial_id.Content.ToString());
            big_image.Show();
        }
    }
}
