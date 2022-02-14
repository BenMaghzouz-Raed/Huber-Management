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

namespace Huber_Management.Pages
{
    /// <summary>
    /// Interaction logic for Faulty_Tools_page.xaml
    /// </summary>
    public partial class Faulty_Tools_page : Page
    {
        public Faulty_Tools_page()
        {
            InitializeComponent();
        }

        void Load(object sender, RoutedEventArgs e)
        {

            // INITIALIZE BY WHO COMBOBOX
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            DataTable by_who_table = new DataTable();
            string query = "SELECT DISTINCT(Faulty_by) as results FROM Faulty_Tools";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
            adapter.Fill(by_who_table);
            foreach (DataRow row in by_who_table.Rows)
            {
                if (row["results"].ToString() != "")
                {
                    ComboBoxItem newItem = new ComboBoxItem();
                    newItem.Content = row["results"].ToString();
                    by_who_combobox.Items.Add(newItem);
                }
            }
            Database_c.Close_DB_Connection();

            date.tableHeader_Label.Content = date.Tag.ToString();
            serial_id.tableHeader_Label.Content = serial_id.Tag.ToString();
            quantity.tableHeader_Label.Content = quantity.Tag.ToString();
            total_price.tableHeader_Label.Content = total_price.Tag.ToString();
            faulty_by.tableHeader_Label.Content = faulty_by.Tag.ToString();

            date.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            faulty_by.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            date.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            faulty_by.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            // PRIVILEGES
            if (!MainWindow.Connected_user.canRepair)
            {
                Add_faulty_tool.IsEnabled = false;
            }
            InitializeAllData();
        }
        public Controls.TableHeader_RadioBtn Selected_sort_by { get; set; } = null;


        public async void InitializeAllData(string when = "", string who = "", string text_search_filter = "", string sort_by = "", bool DESC = true, string _search_text = "")
        {
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                noDataFound.Visibility = Visibility.Collapsed;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SQLiteConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "SELECT * FROM Faulty_Tools LEFT JOIN Tools ON (Faulty_Tools.Tool_serial_id = Tools.Tool_serial_id) WHERE Faulty_quantity > 0 ";


            // FILTER CONVERTER
            switch (text_search_filter)
            {
                case "Serial Number":
                    text_search_filter = "Faulty_Tools.Tool_serial_id";
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
                    text_search_filter = "Faulty_Tools.Tool_serial_id";
                    break;
            }
            // SEARCH CONVERTER
            if (_search_text != "" && _search_text.Length > 0)
            {
                query += " AND " + text_search_filter + " LIKE '%" + _search_text + "%' ";
            }

            // WHEN CONVERTER
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            string[] YearMonth = date.Split("-");
            string thisMonth = YearMonth[0] + "-" + YearMonth[1];
            switch (when)
            {
                case "This Month":
                    when = " AND strftime('%Y-%m', added_date) = '" + thisMonth + "' ";
                    break;
                case "Last Month":
                    int lastMonth = int.Parse(YearMonth[1]) - 1;
                    string last_month = lastMonth < 10 ? "0" + lastMonth.ToString() : lastMonth.ToString();
                    when = " AND strftime('%Y-%m', added_date) = '" + YearMonth[0] + "-" + last_month + "' ";
                    break;
                case "Last Year":
                    int lastYear = int.Parse(YearMonth[0]) - 1;
                    when = " AND strftime('%Y', added_date) = '" + lastYear.ToString() + "' ";
                    break;
                case "This Year":
                    when = " AND strftime('%Y', added_date) = '" + YearMonth[0] + "' ";
                    break;
                case "All":
                    when = "";
                    break;
                default:
                    when = " AND strftime('%Y-%m', added_date) = '" + thisMonth + "' ";
                    break;
            }
            query += when;

            // BY WHO CONVERTER
            if (who != "Any" && who != "")
            {
                query += " AND ( Faulty_by = '" + who + "' ) ";
            }

            // SORT BY CONVERTER
            switch (sort_by)
            {
                case "serial_id":
                    sort_by = "Faulty_Tools.Tool_serial_id";
                    DESC = !DESC;
                    break;
                case "date":
                    sort_by = "Faulty_Tools.added_date";
                    break;
                case "quantity":
                    sort_by = "Faulty_quantity";
                    break;
                case "faulty_by":
                    sort_by = "Faulty_by";
                    DESC = !DESC;
                    break;
                case "total_price":
                    sort_by = "Tool_price * Faulty_quantity";
                    break;
                default:
                    sort_by = "Faulty_Tools.added_date";
                    break;
            }
            query += " Order by " + sort_by;

            // DSEC or ASC CONVERTER
            if (DESC)
            {
                query += " DESC";
            }

            try
            {
                SQLiteDataAdapter adapter = await Task.Run(() => new SQLiteDataAdapter(query, conn));
                adapter.Fill(all_data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            // EXECUTE QUERY
            if (all_data.Rows.Count > 0 && this.Faulty_rows_panel != null)
            {
                try
                {
                    Faulty_rows_panel.Children.Clear();
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

                        Controls.Faulty_tool_row new_faulty_row = new Controls.Faulty_tool_row
                            (
                            newTool,
                            row["Faulty_tool_id"].ToString(),
                            row["causes"].ToString(),
                            row["added_date"].ToString(),
                            row["Faulty_quantity"].ToString(),
                            row["Faulty_by"].ToString()
                            );
                        Faulty_rows_panel.Children.Add(new_faulty_row);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (LoadingIcon != null)
                {
                    LoadingIcon.Visibility = Visibility.Collapsed;
                    DataScrollViewer.Visibility = Visibility.Visible;
                    noDataFound.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                noDataFound.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
                LoadingIcon.Visibility = Visibility.Collapsed;
            }

            Database_c.Close_DB_Connection();
        }

        private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Refresh();
            }
        }

        public void InitializeAllData_Filters_Function()
        {
            if (search_filter != null && Nav_search_box != null && when_combobox != null && by_who_combobox != null)
            {
                try
                {
                    string _when = ((ComboBoxItem)when_combobox.SelectedItem).Content.ToString();
                    string _who = ((ComboBoxItem)by_who_combobox.SelectedItem).Content.ToString();
                    string _filter = ((ComboBoxItem)search_filter.SelectedItem).Content.ToString();
                    string _text = ((TextBox)Nav_search_box).Text.ToString();

                    if (Selected_sort_by != null)
                    {
                        bool DSEC = Selected_sort_by.RadioBtn_invisible_Down.IsChecked.Value;

                        string _sort_by = Selected_sort_by.Name.ToString();
                        InitializeAllData(_when, _who, _filter, _sort_by, DSEC, _text);
                    }
                    else
                    {
                        InitializeAllData(_when, _who, _filter, "", true, _text);
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

        private void Add_faulty_tool_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_faulty_tool_window new_faulty = new Controls.Add_faulty_tool_window();
            new_faulty.Show();
        }
    }
}
