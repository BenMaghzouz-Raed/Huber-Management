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
    /// Interaction logic for Faulty_tool_row.xaml
    /// </summary>
    public partial class Faulty_tool_row : UserControl
    {
        public Faulty_tool_row(Tools_c Tool, string faulty_id, string causes, string faulty_date, string faulty_quantity, string faulty_by)
        {
            InitializeComponent();
            // PRIVILEGES
            if (!MainWindow.Connected_user.canRepair)
            {
                MenuItem_add_to_repaired.Visibility = Visibility.Collapsed;
                MenuItem_Delete.Visibility = Visibility.Collapsed;
            }
            InitializeOneRow(Tool, faulty_id, causes, faulty_date, faulty_quantity, faulty_by);
        }

        public void InitializeOneRow(Tools_c Tool, string faulty_id, string causes, string faulty_date, string faulty_quantity, string faulty_by)
        {
            this.faulty_id.Content = faulty_id;

            string[] date = faulty_date.Split(null);
            this.faulty_date.Content = date[0];

            if (Tool.Tool_image_path != "")
            {
                tools_row_image.Source = new BitmapImage(new Uri(Tool.Tool_image_path));
            }
            tools_row_serial_id.Content = Tool.Tool_serial_id;
            tools_row_designation.Text = Tool.Tool_designation;

            this.faulty_quantity.Content = faulty_quantity;
            this.reception_by.Text = faulty_by;

            decimal price = 0;
            decimal.TryParse(Tool.Tool_price.ToString(), out price);
            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;

            decimal total_price = (decimal)(price * int.Parse(faulty_quantity));
            string total_price_c = total_price.ToString("C");
            this.faulty_total.Content = total_price_c;

            string total_price_dt_c = (total_price * dt_value).ToString("C").Remove(0, 1);
            this.faulty_total.ToolTip = total_price_dt_c + " DT";

            this.faulty_causes.Text = causes;

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
            string faulty_id = this.faulty_id.Content.ToString();

            MessageBoxResult dialogResult = MessageBox.Show("This may affect some other data in Repaired Tools Table! Are you sure you want to Remove this tool '" + serial_id + "' from Defective Tools?", "Remove From Defective", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.OK)
            {
                SQLiteConnection conn = Database_c.Get_DB_Connection();
                try
                {
                    // DELETE FROM DEFECTIVE TABLE
                    string Query = "Delete FROM Faulty_Tools WHERE (Faulty_tool_id = @Faulty_tool_id) AND (Tool_serial_id = @serial_id)";
                    SQLiteCommand command = new SQLiteCommand(Query, conn);
                    command.Parameters.AddWithValue("@serial_id", serial_id);
                    command.Parameters.AddWithValue("@Faulty_tool_id", faulty_id);
                    await Task.Run(() => command.ExecuteNonQuery());

                    // DELETE FROM REPAIRED TABLE
                    string Query2 = "Delete FROM Repaired_Tools WHERE (Faulty_tools_id = @Faulty_tools_id) AND (Tool_serial_id = @serial_id)";
                    SQLiteCommand command2 = new SQLiteCommand(Query2, conn);
                    command2.Parameters.AddWithValue("@serial_id", serial_id);
                    command2.Parameters.AddWithValue("@Faulty_tools_id", faulty_id);
                    await Task.Run(() => command2.ExecuteNonQuery());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    Database_c.Close_DB_Connection();
                    return;
                }
                Database_c.Close_DB_Connection();
                MessageBox.Show(serial_id + " Removed successfully from defective tools", "Removed", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow._Faulty_Tools_page.InitializeAllData_Filters_Function();
            }
        }

        private void MenuItem_viewImage_Click(object sender, RoutedEventArgs e)
        {
            Open_image_window big_image = new Open_image_window(tools_row_image.Source, tools_row_serial_id.Content.ToString());
            big_image.Show();
        }

        private void MenuItem_add_to_repaired_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_repaired_tool_window newRepaired = new Controls.Add_repaired_tool_window(
                this.tools_row_serial_id.Content.ToString(),
                this.faulty_id.Content.ToString(),
                this.faulty_quantity.Content.ToString()
                );
            newRepaired.Show();
        }
    }
}