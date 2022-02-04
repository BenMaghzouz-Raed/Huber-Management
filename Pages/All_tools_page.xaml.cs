using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace Huber_Management.Pages
{
    /// <summary>
    /// Interaction logic for All_tools_page.xaml
    /// </summary>
    public partial class All_tools_page : Page
    {
        public All_tools_page()
        {
            InitializeComponent();

        }

        void Load(object sender, RoutedEventArgs e)
        {
            serial_id.tableHeader_Label.Content = serial_id.Tag.ToString();
            project.tableHeader_Label.Content = project.Tag.ToString();
            process.tableHeader_Label.Content = process.Tag.ToString();
            position.tableHeader_Label.Content = position.Tag.ToString();
            division.tableHeader_Label.Content = division.Tag.ToString();
            min_stock.tableHeader_Label.Content = min_stock.Tag.ToString();
            actual_stock.tableHeader_Label.Content = actual_stock.Tag.ToString();

            InitializeAllData();
        }

        public Controls.TableHeader_RadioBtn Selected_sort_by { get; set; } = null;

        public async void InitializeAllData(string filter ="", string sort_by ="", bool DESC = true, string _search_text="")
        {
            if(LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Tools ";

            // FILTER CONVERTER
            switch (filter)
            {
                case "Added Date":
                    filter = "";
                    break;
                case "A-Z":
                    filter = "";
                    break;
                case "Actual Stock":
                    filter = "";
                    break;
                default:
                    query += "";
                    break;
            }
            // SEARCH CONVERTER
            if(_search_text != "" && _search_text != "Search by ID or Name..." && _search_text.Length > 0)
            {
                if(filter == "")
                {
                    query += "WHERE Tool_serial_id LIKE '%" + _search_text + "%' ";
                }
                else
                {
                    query += "WHERE Tool_serial_id LIKE '%" + _search_text + "%' ";
                }
            }
            // SORT BY CONVERTER
            switch (sort_by)
            {
                case "serial_id":
                    sort_by = "Tool_serial_id";
                    DESC = !DESC;
                    break;
                case "min_stock":
                    sort_by = "Tool_stock_mini";
                    break;
                case "actual_stock":
                    sort_by = "Tool_actual_stock";
                    break;
                case "project":
                    sort_by = "Tool_project";
                    DESC = !DESC;
                    break;
                case "process":
                    sort_by = "Tool_process";
                    DESC = !DESC;
                    break;
                case "division":
                    sort_by = "Tool_division";
                    DESC = !DESC;
                    break;
                case "position":
                    sort_by = "Tool_position";
                    DESC = !DESC;
                    break;
                default:
                    sort_by = "Tool_date_added";
                    break;
            }
            query += " Order by " + sort_by;

            // DSEC or ASC CONVERTER
            if (DESC)
            {
                query += " DESC";
            }

            // EXECUTE QUERY
            try
            {
                SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
                adapter.Fill(all_data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(All_tools_rows_panel != null)
            {
                All_tools_rows_panel.Children.Clear();
                foreach (DataRow row in all_data.Rows)
                {

                    Tools_c newTool = new Tools_c
                    {
                        Tool_serial_id = (string)row["Tool_serial_id"],
                        Tool_designation = (string)row["Tool_designation"],
                        Tool_drawing = (string)row["Tool_drawing"],
                        Tool_project = (string)row["Tool_project"],
                        Tool_process = (string)row["Tool_process"],
                        Tool_division = (string)row["Tool_division"],
                        Tool_position = (string)row["Tool_position"],
                        Tool_supplier = (string)row["Tool_supplier"],
                        Tool_stock_mini = (int)row["Tool_stock_mini"],
                        Tool_stock_max = (int)row["Tool_stock_max"],
                        Tool_actual_stock = (int)row["Tool_actual_stock"],
                        Tool_price = (decimal)row["Tool_price"],
                        Tool_image_path = (string)row["Tool_image_path"]
                    };
                    All_tools_rows_panel.Children.Add(new Controls.All_Tools_Row(newTool));
                }

            }

            Database_c.Close_DB_Connection();

            if(LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Collapsed;
                DataScrollViewer.Visibility = Visibility.Visible;
            }

        }

        private void Add_tool_to_db_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_Tool_Window add_tool_window = new Controls.Add_Tool_Window();
            add_tool_window.Show();
        }

        private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Refresh();
            }
        }

        // Get Data With Filtring 
        public void InitializeAllData_Filters(object sender, EventArgs e)
        {
            if (filter_combobox != null && Nav_search_box != null)
            {
                try
                {
                    string _filter = ((ComboBoxItem)filter_combobox.SelectedItem).Content.ToString();
                    string _text = ((TextBox)Nav_search_box).Text.ToString();

                    if ( Selected_sort_by != null)
                    {
                        bool DSEC = Selected_sort_by.RadioBtn_invisible_Down.IsChecked.Value;

                        string _sort_by = Selected_sort_by.Name.ToString();
                        InitializeAllData(_filter, _sort_by, DSEC, _text);
                    }
                    else
                    {
                        InitializeAllData(_filter, "", true, _text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void sort_by_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Selected_sort_by = (Controls.TableHeader_RadioBtn)(sender);
            InitializeAllData_Filters(sender, e);
        }
    }
}
