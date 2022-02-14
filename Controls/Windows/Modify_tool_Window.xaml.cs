using Microsoft.Win32;
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
    /// Interaction logic for Modify_tool_Window.xaml
    /// </summary>
    public partial class Modify_tool_Window : Window
    {
        public Modify_tool_Window(string tool_serial_id)
        {
            InitializeComponent();
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            Initialize_tool_data(tool_serial_id, conn);
            Database_c.Close_DB_Connection();
        }

        decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;

        // INITIALIZE THE DATA OF THE SELECTED TOOL
        public async void Initialize_tool_data(string tool_serial_id, SQLiteConnection conn)
        {
            DataTable all_data = await Task.Run(() => Tools_c.Get_by_serial_id(tool_serial_id, conn));
            if(all_data.Rows.Count == 1)
            {
                DataRow row = all_data.Rows[0];

                // inputs
                Serial_nb_add.Text = tool_serial_id;
                quantity_add.Text = row["Tool_actual_stock"].ToString();

                InitializeComboBox("Tool_division", division_add_combobox, row["Tool_division"].ToString(), conn);

                position_add.Text = row["Tool_position"].ToString();

                min_add.Text = row["Tool_stock_mini"].ToString();
                max_add.Text = row["Tool_stock_max"].ToString(); ;

                designation_add.Text = row["Tool_designation"].ToString();
                price_add.Text = row["Tool_price"].ToString();

                decimal dt_price = decimal.Parse(row["Tool_price"].ToString());
                price_add_DT.Text = (dt_price * dt_value).ToString();

                InitializeComboBox("Tool_project", project_add_combobox, row["Tool_project"].ToString(), conn);            
                InitializeComboBox("Tool_process", process_add_combobox, row["Tool_process"].ToString(), conn);
                InitializeComboBox("Tool_supplier", supplier_add_combobox, row["Tool_supplier"].ToString(), conn);

                supplier_code_add.Text = row["Tool_supplier_code"].ToString();
                tool_criticality.Text = row["Tool_criticality"].ToString();

                ImagePath.Text = row["Tool_image_path"].ToString();
                if(ImagePath.Text.ToString() != "")
                {
                    try
                    {
                        MyImage.Source = new BitmapImage(new Uri(ImagePath.Text));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

            }
        }
        private async void InitializeComboBox(string Tool_column_name, ComboBox combobox_name, string selectedValue, SQLiteConnection conn)
        {
            DataTable InitializeData = new DataTable();
            string query = "SELECT DISTINCT " + Tool_column_name + " as results FROM Tools GROUP BY (" + Tool_column_name + ")";
            SQLiteDataAdapter adapter = await Task.Run(() => new SQLiteDataAdapter(query, conn));
            adapter.Fill(InitializeData);
            foreach (DataRow row in InitializeData.Rows)
            {
                if (row["results"].ToString() != "")
                {
                    ComboBoxItem newItem = new ComboBoxItem();
                    newItem.Content = row["results"].ToString();
                    if(row["results"].ToString() == selectedValue)
                    {
                        newItem.IsSelected = true;
                    }
                    combobox_name.Items.Add(newItem);
                }
            }
        }

        /// <summary>
        /// Update the Tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Update_tool_Click(object sender, RoutedEventArgs e)
        {
            bool isUpdated = false;
            // Add tool to Tools database
            SQLiteConnection conn = Database_c.Get_DB_Connection();

            string imagePath = ImagePath.Text.ToString();
            string ImageName = System.IO.Path.GetFileName(imagePath);

            // INPUTS VALIDATION
            int quantity = 1;
            int.TryParse(quantity_add.Text.ToString(), out quantity);

            int min = 0;
            int.TryParse(min_add.Text.ToString(), out min);

            int max = 0;
            int.TryParse(max_add.Text.ToString(), out max);

            int criticality = 0;
            int.TryParse(tool_criticality.Text.ToString(), out criticality);

            decimal price = 0;
            decimal.TryParse(price_add.Text.ToString(), out price);

            // Remove Extra Space
            string tool_designation = string.Join(" ", designation_add.Text.ToString().Split().Where(x => x != ""));

            Tools_c UpdateTool = new Tools_c
            {
                Tool_serial_id = Serial_nb_add.Text.ToString(),
                Tool_actual_stock = quantity,

                Tool_division = getComboBox_or_TextBox_value(division_add_combobox, division_add),
                Tool_position = position_add.Text.ToString(),
                Tool_process = getComboBox_or_TextBox_value(process_add_combobox, process_add),
                Tool_stock_mini = min,
                Tool_stock_max = max,

                Tool_designation = tool_designation,
                Tool_project = getComboBox_or_TextBox_value(project_add_combobox, project_add),
                Tool_supplier = getComboBox_or_TextBox_value(supplier_add_combobox, supplier_add),
                Tool_supplier_code = supplier_code_add.Text.ToString(),

                Tool_image_path = imagePath,
                Tool_image_name = ImageName,

                Tool_criticality = criticality,
                Tool_price = price,
            };

            // Update the Tool to Database
            isUpdated = await Task.Run(() => Tools_c.Update_single_tool(UpdateTool, conn));
            if (isUpdated)
            {
                MessageBox.Show("The Tool with Serial number = '" + Serial_nb_add.Text.ToString() + "' Updated successfully. Please reload the page", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            Database_c.Close_DB_Connection();
        }

        // Browse for Image
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) { return; }

            string imagePath = dialog.FileName;
            string imageName = System.IO.Path.GetFileName(imagePath);

            ImagePath.Text = dialog.FileName;

            MyImage.Source = new BitmapImage(new Uri(imagePath));
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void new_division_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            division_add_combobox.Visibility = Visibility.Collapsed;
            division_add.Visibility = Visibility.Visible;
        }

        private void new_supplier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            supplier_add_combobox.Visibility = Visibility.Collapsed;
            supplier_add.Visibility = Visibility.Visible;
        }

        private void new_project_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            project_add_combobox.Visibility = Visibility.Collapsed;
            project_add.Visibility = Visibility.Visible;
        }

        private void new_process_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            process_add_combobox.Visibility = Visibility.Collapsed;
            process_add.Visibility = Visibility.Visible;
        }

        private string getComboBox_or_TextBox_value(ComboBox combobox, TextBox textbox)
        {
            if (textbox != null && textbox.Visibility == Visibility.Visible)
            {
                return textbox.Text.ToString();
            }
            else if (combobox != null && combobox.Visibility == Visibility.Visible)
            {
                if(combobox.SelectedItem != null)
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

        private void price_add_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal price_euro = 0;
            decimal.TryParse(((TextBox)sender).Text.ToString(), out price_euro);

            string price_c = (price_euro * dt_value).ToString();

            if (price_c.Contains("."))
            {
                price_c += "000";
                price_add_DT.Text = price_c.Remove(price_c.IndexOf(".") + 3);
            }
            else
            {
                price_add_DT.Text = price_c;
            }
        }
        private void price_add_DT_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal price_dt = 0;
            decimal.TryParse(((TextBox)sender).Text.ToString(), out price_dt);
            string price_c = "";
            if ( dt_value != 0)
            {
                price_c = (price_dt / dt_value).ToString();

            }

            if (price_c.Contains("."))
            {
                price_c += "000";
                price_add.Text = price_c.Remove(price_c.IndexOf(".") + 3);
            }
            else
            {
                price_add.Text = price_c;
            }

        }
    }
}


