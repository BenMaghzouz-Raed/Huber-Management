using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SQLite;

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
            // PRIVILEGES SETTINGS
            if (!MainWindow.Connected_user.canAdd)
            {
                Add_tool_to_db.IsEnabled = false;
            }

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

        public async void InitializeAllData(string top_filter = "", string top = "", string text_search_filter = "", string sort_by ="", bool DESC = true, string _search_text="")
        {
            if(LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SQLiteConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Tools ";

            // FILTER CONVERTER
            switch (text_search_filter)
            {
                case "Serial Number":
                    text_search_filter = "Tool_serial_id";
                    break;
                case "Drawing":
                    text_search_filter = "Tool_drawing";
                    break;
                case "Supplier":
                    text_search_filter = "Tool_supplier";
                    break;
                case "Position":
                    text_search_filter = "Tool_position";
                    break;
                case "Project":
                    text_search_filter = "Tool_project";
                    break;
                case "Process":
                    text_search_filter = "Tool_process";
                    break;
                case "Division":
                    text_search_filter = "Tool_division";
                    break;
                case "Supplier Code":
                    text_search_filter = "Tool_supplier_code";
                    break;
                default:
                    text_search_filter = "Tool_serial_id";
                    break;
            }
            // SEARCH CONVERTER
            if(_search_text != "" && _search_text.Length > 0)
            {
                query += "WHERE " + text_search_filter + " LIKE '%" + _search_text + "%' ";
            }

            // TOP FILTER CONVERTER
            if (top_filter != "")
            {
                //switch (top_filter)
                //{
                //    case "Mismatched data":
                //        sort_by = " AND Tool_serial_id IN (SELECT Tool_serial_id ";
                //        DESC = !DESC;
                //        break;
                //    default:
                //        top_filter = "";
                //        break;
                //}
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
                query += " DESC ";
            }

            // TOP CONVERTER
            if(top != "All" && top != "")
            {
                query += " LIMIT " + top;
            }
            else if(top == "All")
            {
                query += "";
            }
            else
            {
                query += " LIMIT 15";
            }

            // EXECUTE QUERY
            try
            {
                SQLiteDataAdapter adapter = await Task.Run(() => new SQLiteDataAdapter(query, conn));
                adapter.Fill(all_data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(All_tools_rows_panel != null && all_data.Rows.Count > 0)
            {
                All_tools_rows_panel.Children.Clear();
                foreach (DataRow row in all_data.Rows)
                {

                    Tools_c newTool = new Tools_c
                    {
                        Tool_serial_id = row["Tool_serial_id"].ToString(),
                        Tool_designation = row["Tool_designation"].ToString(),
                        Tool_drawing = row["Tool_drawing"].ToString(),
                        Tool_project = row["Tool_project"].ToString(),
                        Tool_process = row["Tool_process"].ToString(),
                        Tool_division = row["Tool_division"].ToString(),
                        Tool_position = row["Tool_position"].ToString(),
                        Tool_supplier = row["Tool_supplier"].ToString(),
                        Tool_stock_mini = int.Parse(row["Tool_stock_mini"].ToString()),
                        Tool_stock_max = int.Parse(row["Tool_stock_max"].ToString()),
                        Tool_actual_stock = int.Parse(row["Tool_actual_stock"].ToString()),
                        Tool_price = decimal.Parse(row["Tool_price"].ToString()),
                        Tool_image_path = row["Tool_image_path"].ToString()
                    };
                    All_tools_rows_panel.Children.Add(new Controls.All_Tools_Row(newTool));
                }
            }
            else
            {
                All_tools_rows_panel.Children.Clear();
                All_tools_rows_panel.Children.Add(this.noDataFound);
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
        public void InitializeAllData_Filters_Function()
        {
            if (search_filter != null && Nav_search_box != null && top_combobox != null && filter_combobox != null )
            {
                try
                {
                    string text_search_filter = ((ComboBoxItem)search_filter.SelectedItem).Content.ToString();
                    string top_filter = ((ComboBoxItem)filter_combobox.SelectedItem).Content.ToString();
                    string _top = ((ComboBoxItem)top_combobox.SelectedItem).Content.ToString();
                    string _text = ((TextBox)Nav_search_box).Text.ToString();
                    if ( Selected_sort_by != null)
                    {
                        bool DSEC = Selected_sort_by.RadioBtn_invisible_Down.IsChecked.Value;

                        string _sort_by = Selected_sort_by.Name.ToString();
                        InitializeAllData(top_filter, _top, text_search_filter, _sort_by, DSEC, _text);
                    }
                    else
                    {
                        InitializeAllData(top_filter, _top, text_search_filter, "", true, _text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void InitializeAllData_Filters(object sender, EventArgs e)
        {
            InitializeAllData_Filters_Function();
        }

        private void sort_by_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Selected_sort_by = (Controls.TableHeader_RadioBtn)(sender);
            InitializeAllData_Filters(sender, e);
        }
    }
}
