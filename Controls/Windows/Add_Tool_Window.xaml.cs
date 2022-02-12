using Huber_Management.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Add_Tool_Window.xaml
    /// </summary>
    public partial class Add_Tool_Window : Window
    {
        public Add_Tool_Window()
        {
            InitializeComponent();
            SqlConnection conn = Database_c.Get_DB_Connection();

            // INITIALIZE DIVISION COMBOBOX
            InitializeComboBox("Tool_project", project_add_combobox, conn);

            // INITIALIZE DIVISION COMBOBOX
            InitializeComboBox("Tool_supplier", supplier_add_combobox, conn);

            // INITIALIZE DIVISION COMBOBOX
            InitializeComboBox("Tool_division", division_add_combobox, conn);

            // INITIALIZE PROCESS COMBOBOX
            InitializeComboBox("Tool_process", process_add_combobox, conn);

            Database_c.Close_DB_Connection();
        }

        private async void InitializeComboBox(string Tool_column_name, ComboBox combobox_name, SqlConnection conn)
        {
            DataTable InitializeData = new DataTable();
            string query = "SELECT DISTINCT " + Tool_column_name + " as results FROM Tools GROUP BY (" + Tool_column_name + ")";
            SqlDataAdapter adapter = await Task.Run(() =>  new SqlDataAdapter(query, conn));
            adapter.Fill(InitializeData);
            foreach (DataRow row in InitializeData.Rows)
            {
                if (row["results"].ToString() != "")
                {
                    ComboBoxItem newItem = new ComboBoxItem();
                    newItem.Content = row["results"].ToString();
                    combobox_name.Items.Add(newItem);
                }
            }
        }

        /// <summary>
        /// Confirm the adding of one tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Add_new_tool_Click(object sender, RoutedEventArgs e)
        {
            bool isAdded = false;
            SqlConnection conn = Database_c.Get_DB_Connection();
            string serial_id = string.Join(" ", Serial_nb_add.Text.ToString().Split().Where(x => x != ""));

            if ( serial_id == "")
            {
                MessageBox.Show("The serial ID field is empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Tools_c.isExist_serial_id(serial_id, conn))
            {
                MessageBox.Show("This Serial Number '" + serial_id + "' already exist!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {   // Add tool to Tools database

                string imagePath = ImagePath.Text.ToString();
                string ImageName = System.IO.Path.GetFileName(imagePath);

                // INPUTS VALIDATION
                int quantity = 1;
                if(quantity_add.Text.ToString() != "") int.TryParse(quantity_add.Text.ToString(), out quantity);

                int min = 0;
                int.TryParse(min_add.Text.ToString(), out min);

                int max = 0;
                int.TryParse(max_add.Text.ToString(), out max);

                decimal price = 0;
                decimal.TryParse(price_add.Text.ToString(), out price);

                int criticality = 90;
                int.TryParse(tool_criticality.Text.ToString(), out criticality);

                // Remove Extra Space
                string tool_designation = string.Join(" ", designation_add.Text.ToString().Split().Where(x => x != ""));

                Tools_c NewTool = new Tools_c {
                    Tool_serial_id = serial_id,
                    Tool_actual_stock = quantity,

                    Tool_division = getComboBox_or_TextBox_value(division_add_combobox, division_add),
                    Tool_process = getComboBox_or_TextBox_value(process_add_combobox, process_add),
                    Tool_project = getComboBox_or_TextBox_value(project_add_combobox, project_add),
                    Tool_supplier = getComboBox_or_TextBox_value(supplier_add_combobox, supplier_add),

                    Tool_position = position_add.Text.ToString(),

                    Tool_stock_mini = min,
                    Tool_stock_max = max,
                    Tool_price = price,

                    Tool_designation = tool_designation,
                    Tool_criticality = criticality,
                    Tool_supplier_code = supplier_code_add.Text.ToString(),

                    Tool_image_path = imagePath,
                    Tool_image_name = ImageName,                    
                };

                // Add the Tool to Database
                isAdded = await Task.Run(() => Tools_c.Add_single_tool(NewTool,conn));
                if (isAdded)
                {
                    MessageBox.Show(quantity + " Tool(s) with Serial number = '" + serial_id + "' added successfully. Please reload the page", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                Database_c.Close_DB_Connection();
            }
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
            //string imageName = System.IO.Path.GetFileName(imagePath);

            ImagePath.Text = dialog.FileName;

            MyImage.Source = new BitmapImage(new Uri(imagePath));
            MyImage.Stretch = Stretch.Uniform;
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
            if(textbox != null && textbox.Visibility == Visibility.Visible)
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
                MessageBox.Show("Something went wrong! Please close the window and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Error";
            }
        }

        decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;

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
            if (dt_value != 0)
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
