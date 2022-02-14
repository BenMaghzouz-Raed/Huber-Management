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
using System.Windows.Shapes;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for Add_new_output_Window.xaml
    /// </summary>
    public partial class Add_new_output_Window : Window
    {
        public Add_new_output_Window(string serial_nb_detail = null)
        {
            InitializeComponent();
            new_search_page = new search_page(serial_nb_detail);
            Add_reception_container.Content = new_search_page;

        }

        public search_page new_search_page { get; set; }
        public output_fields_page new_output{ get; set; }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Add_reception_container != null)
            {
                string selected_serial_id = "";
                foreach (Searched_tool_row row in new_search_page.searched_rows_panel.Children)
                {
                    bool isselected = Convert.ToBoolean(row.tool_radio_btn.IsChecked.Value);
                    if (isselected)
                    {
                        selected_serial_id = row.tool_serial_id.Content.ToString();
                    }
                }
                if (selected_serial_id != "")
                {
                    new_output = new output_fields_page(selected_serial_id);
                    Add_reception_container.Content = new_output;

                    next_btn.Visibility = Visibility.Collapsed;
                    confirm_btn.Visibility = Visibility.Visible;

                    Cancel_btn.Visibility = Visibility.Collapsed;
                    return_btn.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("You didn't select any tool !", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }


        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            Add_reception_container.NavigationService.GoBack();

            next_btn.Visibility = Visibility.Visible;
            confirm_btn.Visibility = Visibility.Collapsed;

            Cancel_btn.Visibility = Visibility.Visible;
            return_btn.Visibility = Visibility.Collapsed;
        }

        private async void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            // check if quantity is not empty
            int quantity = 0;
            int.TryParse(new_output.quantity_add.Text.ToString(), out quantity);

            if (quantity > 0)
            {
                SQLiteConnection conn = Database_c.Get_DB_Connection();
                string serial_id = new_output.serial_nb_detail.Text.ToString();

                // check if the wanted quantity is valid
                DataTable result = Tools_c.Get_by_serial_id(serial_id, conn);
                int actual_stock = int.Parse(result.Rows[0]["Tool_actual_stock"].ToString());

                if (actual_stock >= quantity)
                {
                    string query = "INSERT INTO Transactions (Transaction_type, Transaction_tool_serial_id, Transaction_quantity, Transaction_by, Output_requester, Output_DSI, Transaction_comment, Transaction_date)" +
                    " Values( 'OUT', @Transaction_tool_serial_id, @Transaction_quantity, @Transaction_by, @Output_requester, @Output_DSI, @Transaction_comment, DATETIME('now', 'localtime'))";

                    SQLiteCommand command = new SQLiteCommand(query, conn);
                    command.Parameters.AddWithValue("@Transaction_tool_serial_id", serial_id);

                    command.Parameters.AddWithValue("@Transaction_quantity", quantity);
                    command.Parameters.AddWithValue("@Output_DSI", new_output.dsi_add.Text.ToString());

                    string requester = getComboBox_or_TextBox_value(new_output.requester_add_combobox, new_output.requester_add);
                    command.Parameters.AddWithValue("@Output_requester", requester);

                    command.Parameters.AddWithValue("@Transaction_by", MainWindow.Connected_user.user_fullName.ToString());
                    command.Parameters.AddWithValue("@Transaction_comment", new_output.comment_add.Text.ToString());
                    await Task.Run(() => command.ExecuteNonQuery());

                    // Update Actual Stock 
                    string Updatequery = "UPDATE Tools SET Tool_actual_stock = Tool_actual_stock - @Transaction_quantity, Tool_price = @Tool_price WHERE Tool_serial_id = @Tool_serial_id";
                    SQLiteCommand command2 = new SQLiteCommand(Updatequery, conn);
                    command2.Parameters.AddWithValue("@Transaction_quantity", quantity);
                    command2.Parameters.AddWithValue("@Tool_serial_id", serial_id);

                    decimal price = (new_output.price_add.Text != "") ? decimal.Parse(new_output.price_add.Text) : 0;
                    command2.Parameters.AddWithValue("@Tool_price", price);
                    await Task.Run(() => command2.ExecuteNonQuery());
                    MessageBox.Show(serial_id + " added succesfully to checkout transactions! Please reload the page", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (MainWindow._Output_page != null)
                    {
                        MainWindow._Output_page.NavigationService.Refresh();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You can't make this transaction for " + serial_id + "! Check your actual stock", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Database_c.Close_DB_Connection();
            }
            else
            {
                MessageBox.Show("The quantity field is empty!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string getComboBox_or_TextBox_value(ComboBox combobox, TextBox textbox)
        {
            if (textbox != null && textbox.Visibility == Visibility.Visible)
            {
                return textbox.Text.ToString();
            }
            else if (combobox != null && combobox.Visibility == Visibility.Visible)
            {
                if (combobox.SelectedItem != null)
                {
                    return ((ComboBoxItem)combobox.SelectedItem).Content.ToString();
                }
                return "";

            }
            else
            {
                MessageBox.Show("Something went wrong! close the window and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Error";
            }
        }
    }
}
