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
    /// Interaction logic for Output_Row.xaml
    /// </summary>
    public partial class Output_Row : UserControl
    {
        public Output_Row(Transactions_c Output, Tools_c Tool)
        {
            InitializeComponent();
            InitializeOneRow(Output, Tool);

        }

        public void InitializeOneRow(Transactions_c Output, Tools_c Tool)
        {
            output_id.Content = Output.Transaction_id;

            string[] date = Output.Transaction_date.Split(null);
            output_date.Content = date[0];

            if (Tool.Tool_image_path != "")
            {
                tools_row_image.Source = new BitmapImage(new Uri(Tool.Tool_image_path));
            }
            tools_row_serial_id.Content = Output.Transaction_tool_serial_id;
            tools_row_designation.Text = Tool.Tool_designation;

            output_quantity.Content = Output.Transaction_quantity;
            output_requester.Text = Output.Output_requester;
            output_dsi.Content = Output.Output_DSI;

            decimal price = 0;
            decimal.TryParse(Tool.Tool_price.ToString(), out price);
            string price_c = price.ToString("C");

            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;

            string price_dt_c = (price * dt_value).ToString("C").Remove(0, 1);
            tools_row_price.Content = price_c;
            tools_row_price.ToolTip = price_dt_c + " DT";

            decimal total_price = (decimal)(price * (int)Output.Transaction_quantity);
            string total_price_c = total_price.ToString("C");
            string total_price_dt_c = (total_price * dt_value).ToString("C").Remove(0, 1);
            tools_row_total.Content = total_price_c;
            tools_row_total.ToolTip = total_price_dt_c + " DT";


            output_by.Text = Output.Transaction_by;

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
            string output_id = this.output_id.Content.ToString();
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to Cancel this transaction " + serial_id + " ?", "Cancel Transaction", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.OK)
            {
                SQLiteConnection conn = Database_c.Get_DB_Connection();

                try
                {
                    string Query = "Delete FROM Transactions WHERE (Transaction_id = @output_id) AND (Transaction_tool_serial_id = @serial_id)";
                    SQLiteCommand command = new SQLiteCommand(Query, conn);
                    command.Parameters.AddWithValue("@serial_id", serial_id);
                    command.Parameters.AddWithValue("@output_id", output_id);
                    command.ExecuteNonQuery();

                    int quantity = 0;
                    int.TryParse(this.output_quantity.Content.ToString(), out quantity);

                    string Updatequery = "UPDATE Tools SET Tool_actual_stock = Tool_actual_stock + @Transaction_quantity WHERE Tool_serial_id = @Tool_serial_id";
                    SQLiteCommand command2 = new SQLiteCommand(Updatequery, conn);
                    command2.Parameters.AddWithValue("@Tool_serial_id", serial_id);
                    command2.Parameters.AddWithValue("@Transaction_quantity", quantity);

                    await Task.Run(() => command2.ExecuteNonQuery());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    Database_c.Close_DB_Connection();
                    return;
                }
                Database_c.Close_DB_Connection();
                MainWindow._Output_page.InitializeAllData_Filters_Function();
            }
        }

        private void MenuItem_viewImage_Click(object sender, RoutedEventArgs e)
        {
            Open_image_window big_image = new Open_image_window(tools_row_image.Source, tools_row_serial_id.Content.ToString() );
            big_image.Show();
        }

    }
}
