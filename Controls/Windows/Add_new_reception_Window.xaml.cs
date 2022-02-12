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
using System.Windows.Shapes;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for Add_new_reception_Window.xaml
    /// </summary>
    public partial class Add_new_reception_Window : Window
    {
        public Add_new_page new_tool { get; set; } = null;
        public search_page new_search_page { get; set; } = null;
        public reception_fields_page new_reception { get; set; }
        public Tools_c reception_tool{ get; set; }

        public Add_new_reception_Window(string serial_nb_detail = null)
        {
            InitializeComponent();
            new_search_page = new search_page(serial_nb_detail);
            Add_reception_container.Content = new_search_page;
            hide_add_new_page();
            // PRIVILEGES SETTINGS
            if (!MainWindow.Connected_user.canAdd)
            {
                Add_new_tool.Visibility = Visibility.Collapsed;
            }
        }

        private void hide_search_page()
        {
            search_next_btn.Visibility = Visibility.Collapsed;
            add_new_next_btn.Visibility = Visibility.Visible;
            confirm_btn.Visibility = Visibility.Collapsed;

            Add_new_tool.Visibility = Visibility.Collapsed;
            Search_tool.Visibility = Visibility.Visible;
            return_btn.Visibility = Visibility.Collapsed;
        }

        private void hide_add_new_page()
        {
            search_next_btn.Visibility = Visibility.Visible;
            add_new_next_btn.Visibility = Visibility.Collapsed;
            confirm_btn.Visibility = Visibility.Collapsed;

            Add_new_tool.Visibility = Visibility.Visible;
            Search_tool.Visibility = Visibility.Collapsed;
            return_btn.Visibility = Visibility.Collapsed;
        }

        private void show_next_page()
        {
            search_next_btn.Visibility = Visibility.Collapsed;
            add_new_next_btn.Visibility = Visibility.Collapsed;
            confirm_btn.Visibility = Visibility.Visible;

            Add_new_tool.Visibility = Visibility.Collapsed;
            Search_tool.Visibility = Visibility.Collapsed;
            return_btn.Visibility = Visibility.Visible;
        }

        private async void search_next_btn_Click(object sender, RoutedEventArgs e)
        {
            if (new_search_page != null)
            {
                string selected_serial_id = "";
                foreach ( Searched_tool_row row in new_search_page.searched_rows_panel.Children)
                {
                    bool isselected = Convert.ToBoolean(row.tool_radio_btn.IsChecked.Value);
                    if (isselected)
                    {
                        selected_serial_id = row.tool_serial_id.Content.ToString();
                    }
                }
                if(selected_serial_id != "")
                {
                    SqlConnection conn = Database_c.Get_DB_Connection();
                    DataTable result = await Task.Run(() => Tools_c.Get_by_serial_id(selected_serial_id, conn));
                    reception_tool = new Tools_c();

                    reception_tool.Tool_serial_id = selected_serial_id;
                    reception_tool.Tool_supplier_code = result.Rows[0]["Tool_supplier_code"].ToString();

                    decimal price = 0;
                    decimal.TryParse(result.Rows[0]["Tool_price"].ToString(), out price);
                    reception_tool.Tool_price = price;

                    reception_tool.Tool_project = result.Rows[0]["Tool_project"].ToString();
                    reception_tool.Tool_designation = result.Rows[0]["Tool_designation"].ToString();

                    reception_tool.Tool_image_path = result.Rows[0]["Tool_image_path"].ToString();

                    new_reception = new reception_fields_page(reception_tool);
                    Add_reception_container.Content = new_reception;

                    show_next_page();

                    Database_c.Get_DB_Connection();
                }
                else
                {
                    MessageBox.Show("You didn't select any tool !", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }
        private void Search_tool_Click(object sender, RoutedEventArgs e)
        {
            new_search_page = new search_page();
            Add_reception_container.Content = new_search_page;
            hide_add_new_page();
            new_tool = null;
        }

        private void Add_new_tool_Click(object sender, RoutedEventArgs e)
        {
            new_tool = new Add_new_page();
            Add_reception_container.Content = new_tool;
            hide_search_page();
            new_search_page = null;
        }

        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            Add_reception_container.NavigationService.GoBack();
            confirm_btn.Visibility = Visibility.Collapsed;
            return_btn.Visibility = Visibility.Collapsed;

            if ( new_search_page != null)
            {
                hide_add_new_page();
            }
            if ( new_tool != null )
            {
                hide_search_page();
            }

        }

        private async void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            if (new_reception.quantity_add.Text.ToString() != "")
            {
                SqlConnection conn = Database_c.Get_DB_Connection();
                string serial_id = reception_tool.Tool_serial_id;
                bool exist = Tools_c.isExist_serial_id(serial_id, conn);

                string query = "INSERT INTO Transactions (Transaction_type, Transaction_tool_serial_id, Transaction_quantity, Transaction_by, Transaction_comment)" +
                " Values( 'IN', @Transaction_tool_serial_id, @Transaction_quantity, 'Saif Eddine Hamdi', @Transaction_comment)";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Transaction_tool_serial_id", serial_id));

                int quantity = 0;
                int.TryParse(new_reception.quantity_add.Text.ToString(), out quantity);
                command.Parameters.Add(new SqlParameter("@Transaction_quantity", quantity));

                decimal price = 0;
                decimal.TryParse(new_reception.price_add.Text.ToString(), out price);

                command.Parameters.Add(new SqlParameter("@Transaction_comment", new_reception.comment_add.Text.ToString()));
                await Task.Run(() => command.ExecuteNonQuery());

                if (exist)  // CONFIRMATION BY SEARCH PAGE
                {
                    // Update Actual Stock 
                    string Updatequery = "UPDATE Tools SET Tool_actual_stock = Tool_actual_stock + @Transaction_quantity, Tool_price = @Tool_price, Tool_supplier_code = @Tool_supplier_Code WHERE Tool_serial_id = @Tool_serial_id";
                    SqlCommand command2 = new SqlCommand(Updatequery, conn);
                    command2.Parameters.Add(new SqlParameter("@Tool_serial_id", serial_id));
                    command2.Parameters.Add(new SqlParameter("@Transaction_quantity", quantity));

                    command2.Parameters.Add(new SqlParameter("@Tool_price", price));

                    command2.Parameters.Add(new SqlParameter("@Tool_supplier_Code", new_reception.supplier_code_add.Text.ToString()));
                    await Task.Run(() => command2.ExecuteNonQuery());
                }
                else // CONFIRMATION BY ADD NEW PAGE
                {
                    reception_tool.Tool_price = price;
                    reception_tool.Tool_actual_stock = quantity;
                    reception_tool.Tool_supplier_code = new_reception.supplier_code_add.Text.ToString();

                    Tools_c.Add_single_tool(reception_tool, conn);
                }

                Database_c.Close_DB_Connection();
                MessageBox.Show(serial_id + " added succesfully to received transactions! Please reload the page", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("The quantity field is empty!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void add_new_next_btn_Click(object sender, RoutedEventArgs e)
        {
            string serial_id = new_tool.Serial_nb_add.Text.ToString();
            if (serial_id != "")
            {
                SqlConnection conn = Database_c.Get_DB_Connection();
                bool exist = Tools_c.isExist_serial_id(serial_id, conn);
                if (exist)
                {
                    MessageBox.Show(serial_id + " already exist!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    Database_c.Close_DB_Connection();
                }
                else
                {
                    reception_tool = new Tools_c();
                    reception_tool.Tool_serial_id = serial_id;
                    reception_tool.Tool_supplier = getComboBox_or_TextBox_value(new_tool.supplier_add_combobox, new_tool.supplier_add);

                    reception_tool.Tool_division = getComboBox_or_TextBox_value(new_tool.division_add_combobox, new_tool.division_add);
                    reception_tool.Tool_position = new_tool.position_add.Text;

                    int min = 0;
                    int.TryParse(new_tool.min_add.Text, out min);
                    reception_tool.Tool_stock_mini = min;

                    int max = 0;
                    int.TryParse(new_tool.max_add.Text, out max);
                    reception_tool.Tool_stock_max = max;

                    reception_tool.Tool_designation = new_tool.designation_add.Text;
                    reception_tool.Tool_image_path = new_tool.ImagePath.Text;
                    reception_tool.Tool_image_name = System.IO.Path.GetFileName(new_tool.ImagePath.Text);
                    new_reception = new reception_fields_page(reception_tool);
                    Add_reception_container.Content = new_reception;

                    show_next_page();
                    Database_c.Close_DB_Connection();

                }
            }
            else
            {
                MessageBox.Show("Serial Number Field is empty !!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }

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
