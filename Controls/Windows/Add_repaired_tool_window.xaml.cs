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
    /// Interaction logic for Add_repaired_tool_window.xaml
    /// </summary>
    public partial class Add_repaired_tool_window : Window
    {
        public search_from_defective_page new_search_page { get; set; } = null;
        public Repaired_fields_page new_repaired { get; set; }
        public Tools_c repaired_tool { get; set; }

        public Add_repaired_tool_window(string serial_nb_detail = null, string defective_id = "", string defective_quantity = "")
        {
            InitializeComponent();
            new_search_page = new search_from_defective_page(serial_nb_detail, defective_id, defective_quantity);
            Add_repaired_container.Content = new_search_page;
            show_search_page();
        }

        private void show_search_page()
        {
            Cancel_btn.Visibility = Visibility.Visible;
            next_btn.Visibility = Visibility.Visible;
            confirm_btn.Visibility = Visibility.Collapsed;
            return_btn.Visibility = Visibility.Collapsed;
        }

        private void show_next_page()
        {
            confirm_btn.Visibility = Visibility.Visible;
            return_btn.Visibility = Visibility.Visible;
            Cancel_btn.Visibility = Visibility.Collapsed;
            next_btn.Visibility = Visibility.Collapsed;
        }

        private async void next_btn_Click(object sender, RoutedEventArgs e)
        {
            if (new_search_page != null)
            {
                string selected_serial_id = "";
                string faulty_id = "";
                string faulty_quantity = "";

                foreach (Search_from_defective_row row in new_search_page.searched_rows_panel.Children)
                {
                    bool isselected = Convert.ToBoolean(row.tool_radio_btn.IsChecked.Value);
                    if (isselected)
                    {
                        selected_serial_id = row.tool_serial_id.Content.ToString();
                        faulty_id = row.defective_id.Content.ToString();
                        faulty_quantity = row.defective_quantity.ToString();
                    }
                }
                if (selected_serial_id != "" && faulty_id != "")
                {
                    SqlConnection conn = Database_c.Get_DB_Connection();
                    DataTable result = await Task.Run(() => Tools_c.Get_by_serial_id(selected_serial_id, conn));
                    repaired_tool = new Tools_c();

                    repaired_tool.Tool_serial_id = selected_serial_id;
                    repaired_tool.Tool_supplier_code = result.Rows[0]["Tool_supplier_code"].ToString();

                    decimal price = 0;
                    decimal.TryParse(result.Rows[0]["Tool_price"].ToString(), out price);
                    repaired_tool.Tool_price = price;

                    repaired_tool.Tool_project = result.Rows[0]["Tool_project"].ToString();
                    repaired_tool.Tool_designation = result.Rows[0]["Tool_designation"].ToString();
                    repaired_tool.Tool_actual_stock = int.Parse(result.Rows[0]["Tool_actual_stock"].ToString());
                    repaired_tool.Tool_stock_mini = int.Parse(result.Rows[0]["Tool_stock_mini"].ToString());

                    repaired_tool.Tool_image_path = result.Rows[0]["Tool_image_path"].ToString();

                    new_repaired = new Repaired_fields_page(repaired_tool, faulty_id, faulty_quantity);
                    Add_repaired_container.Content = new_repaired;

                    show_next_page();

                    Database_c.Get_DB_Connection();
                }
                else
                {
                    MessageBox.Show("You didn't select any tool !", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }
        
        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            Add_repaired_container.NavigationService.GoBack();
            show_search_page();
        }

        private async void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            if (new_repaired.Repaired_quantity.Text.ToString() != "")
            {
                MessageBox.Show("The quantity field is empty!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (int.Parse(new_repaired.defective_detail.Text) < int.Parse(new_repaired.Repaired_quantity.Text.ToString() ))
            {
                MessageBox.Show("Repaired quantity > Defective quantityt !!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                SqlConnection conn = Database_c.Get_DB_Connection();
                string serial_id = new_repaired.serial_nb_detail.Text.ToString();
                bool exist = Tools_c.isExist_serial_id(serial_id, conn);

                // ADD TO REPAIRED TOOLS
                string query = "INSERT INTO Repaired_Tools (Tool_serial_id, Tasks_description, Repaired_quantity, Faulty_tools_id, Repaired_by) " +
                "Values(@Tool_serial_id, @Tasks_description, @Repaired_quantity, @Faulty_tools_id, 'Saif Eddine Hamdi')";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Tool_serial_id", serial_id));

                int quantity = 0;
                int.TryParse(new_repaired.Repaired_quantity.Text.ToString(), out quantity);
                command.Parameters.Add(new SqlParameter("@Repaired_quantity", quantity));

                decimal price = 0;
                decimal.TryParse(new_repaired.price_add.Text.ToString(), out price);

                command.Parameters.Add(new SqlParameter("@Tasks_description", new_repaired.comment_add.Text.ToString()));
                command.Parameters.Add(new SqlParameter("@Faulty_tools_id", new_repaired.faulty_serial_id.Text.ToString()));
                await Task.Run(() => command.ExecuteNonQuery());

                // UPDATE TOOLS INFORMATION
                if (exist)
                {
                    string Updatequery = "UPDATE Tools SET Tool_price = @Tool_price WHERE Tool_serial_id = @Tool_serial_id";

                    // Update Actual Stock 
                    if (((RadioButton)new_repaired.add_toggleButton).IsChecked.Value)
                    {
                        Updatequery = "UPDATE Tools SET Tool_actual_stock = Tool_actual_stock + " + quantity + ", Tool_price = @Tool_price WHERE Tool_serial_id = @Tool_serial_id";
                        //command2.Parameters.Add(new SqlParameter("@Faulty_quantity", quantity));
                    }

                    SqlCommand command2 = new SqlCommand(Updatequery, conn);
                    command2.Parameters.Add(new SqlParameter("@Tool_serial_id", serial_id));
                    command2.Parameters.Add(new SqlParameter("@Tool_price", price));
                    await Task.Run(() => command2.ExecuteNonQuery());
                }
                else // TOOL DOES NOT EXIST
                {
                    MessageBox.Show(serial_id + " Does not exist in Defective tools!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // SUBTRACT REPAIRED QUANTITY FROM FAULTY TOOLS
                string UpdateFaulty = "UPDATE Faulty_Tools SET Faulty_quantity = Faulty_quantity - " + quantity + " WHERE Faulty_tool_id = @Faulty_tool_id ";
                SqlCommand command3 = new SqlCommand(UpdateFaulty, conn);
                command3.Parameters.Add(new SqlParameter("@Faulty_tool_id", new_repaired.faulty_serial_id.Text.ToString()));

                await Task.Run(() => command3.ExecuteNonQuery());


                Database_c.Close_DB_Connection();
                MessageBox.Show(quantity + " Tool(s) with the Serial Number = '" + serial_id + "' added to Repaired tools ! Please reload the page", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
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
