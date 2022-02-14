using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for History_page.xaml
    /// </summary>
    public partial class History_page : Page
    {
        private Controls.TableHeader_RadioBtn Selected_sort_by { get; set; } = null;

        public History_page()
        {
            InitializeComponent();
        }
        void Load(object sender, RoutedEventArgs e)
        {
            // INITIALIZE BY WHO COMBOBOX
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            DataTable by_who_table = new DataTable();
            string query = "SELECT DISTINCT(Transaction_by) as results FROM Transactions";
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
            supplier.tableHeader_Label.Content = supplier.Tag.ToString();
            price.tableHeader_Label.Content = price.Tag.ToString();
            total_price.tableHeader_Label.Content = total_price.Tag.ToString();
            history_type.tableHeader_Label.Content = history_type.Tag.ToString();
            requester.tableHeader_Label.Content = requester.Tag.ToString();

            date.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            supplier.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            history_type.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            requester.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            date.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            supplier.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            history_type.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            requester.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            InitializeAllData();
        }

        public async void InitializeAllData(string when = "", string who = "", string filter = "", string sort_by = "", bool DESC = true, string _search_text = "")
        {
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SQLiteConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Transactions LEFT JOIN Tools ON (Transaction_tool_serial_id = Tool_serial_id) ";

            // FILTER CONVERTER
            switch (filter)
            {
                case "Serial Number":
                    filter = "Transaction_tool_serial_id";
                    break;
                case "Drawing":
                    filter = "Tool_drawing";
                    break;
                case "Supplier":
                    filter = "Tool_supplier";
                    break;
                case "Position":
                    filter = "Tool_position";
                    break;
                default:
                    filter = "Transaction_tool_serial_id";
                    break;
            }

            // SEARCH CONVERTER
            if (_search_text != "" && _search_text.Length > 0)
            {
                query += " WHERE " + filter + " LIKE '%" + _search_text + "%' ";
            }
            else
            {
                query += " WHERE " + filter + " LIKE '%%' ";
            }

            // WHEN CONVERTER
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            string[] YearMonth = date.Split("-");
            string thisMonth = YearMonth[0] + "-" + YearMonth[1];
            switch (when)
            {
                case "This Month":
                    when = " AND strftime('%Y-%m', Transaction_date) = '" + thisMonth + "' ";
                    break;
                case "Last Month":
                    int lastMonth = int.Parse(YearMonth[1]) - 1;
                    string last_month = lastMonth < 10 ? "0"+lastMonth.ToString() : lastMonth.ToString();
                    when = " AND strftime('%Y-%m', Transaction_date) = '" + YearMonth[0] + "-" + last_month + "' ";
                    break;
                case "Last Year":
                    int lastYear = int.Parse(YearMonth[0]) - 1;
                    when = " AND strftime('%Y', Transaction_date) = '" + lastYear.ToString() + "' ";
                    break;
                case "This Year":
                    when = " AND strftime('%Y', Transaction_date) = '" + YearMonth[0] + "' ";
                    break;
                case "All":
                    when = "";
                    break;
                default:
                    when = " AND strftime('%Y-%m', Transaction_date) = '" + thisMonth + "' ";
                    break;
            }
            query += when;

            // BY WHO CONVERTER
            if (who != "Any" && who != "")
            {
                query += " AND (Transaction_by = '" + who + "' ) ";
            }

            // SORT BY CONVERTER
            switch (sort_by)
            {
                case "serial_id":
                    sort_by = "Transaction_tool_serial_id";
                    DESC = !DESC;
                    break;
                case "date":
                    sort_by = "Transaction_date";
                    break;
                case "quantity":
                    sort_by = "Transaction_quantity";
                    break;
                case "supplier":
                    sort_by = "Tool_supplier";
                    DESC = !DESC;
                    break;
                case "price":
                    sort_by = "Tool_price";
                    break;
                case "total_price":
                    sort_by = "Tool_price * Transaction_quantity";
                    break;
                default:
                    sort_by = "Transaction_date";
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
                SQLiteDataAdapter adapter = await Task.Run(() => new SQLiteDataAdapter(query, conn));
                adapter.Fill(all_data);
                if (History_rows_panel != null)
                {
                    History_rows_panel.Children.Clear();
                    foreach (DataRow row in all_data.Rows)
                    {
                        //Tools_c newTool = new Tools_c
                        //{
                        //    Tool_serial_id = row["Tool_serial_id"].ToString(),
                        //    Tool_designation = row["Tool_designation"].ToString(),
                        //    Tool_drawing = row["Tool_drawing"].ToString(),
                        //    Tool_project = row["Tool_project"].ToString(),
                        //    Tool_process = row["Tool_process"].ToString(),
                        //    Tool_division = row["Tool_division"].ToString(),
                        //    Tool_position = row["Tool_position"].ToString(),
                        //    Tool_supplier = row["Tool_supplier"].ToString(),
                        //    Tool_stock_mini = int.Parse(row["Tool_stock_mini"].ToString()),
                        //    Tool_stock_max = int.Parse(row["Tool_stock_max"].ToString()),
                        //    Tool_actual_stock = int.Parse(row["Tool_actual_stock"].ToString()),
                        //    Tool_price = decimal.Parse(row["Tool_price"].ToString()),
                        //    Tool_image_path = row["Tool_image_path"].ToString()
                        //};

                        //if (row["Transaction_type"].ToString() == "IN")
                        //{
                        //    Transactions_c reception = new Transactions_c
                        //    {
                        //        Transaction_id = row["Transaction_id"].ToString(),
                        //        Transaction_tool_serial_id = row["Transaction_tool_serial_id"].ToString(),
                        //        Transaction_date = row["Transaction_date"].ToString(),
                        //        Transaction_quantity = int.Parse(row["Transaction_quantity"].ToString()),
                        //        Output_requester = row["Output_requester"].ToString(),
                        //        Transaction_by = row["Transaction_by"].ToString(),
                        //        Transaction_comment = row["Transaction_comment"].ToString(),
                        //    };
                        //}

                        string[] date_time = row["Transaction_date"].ToString().Split(null);
                        Controls.All_History_row newHistory = new Controls.All_History_row
                        (
                            date_time[0],
                            date_time[1],
                            row["Tool_image_path"].ToString(),
                            row["Tool_serial_id"].ToString(),
                            row["Transaction_type"].ToString(),
                            row["Transaction_quantity"].ToString(),
                            row["Tool_price"].ToString(),
                            row["Output_requester"].ToString(),
                            row["Tool_supplier"].ToString(),
                            row["Transaction_by"].ToString(),
                            row["Transaction_comment"].ToString()
                        );
                        History_rows_panel.Children.Add(newHistory);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Database_c.Close_DB_Connection();
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Collapsed;
                DataScrollViewer.Visibility = Visibility.Visible;
            }

        }

        public void InitializeAllData_Filters(object sender, EventArgs e)
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

        private void sort_by_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Selected_sort_by = (Controls.TableHeader_RadioBtn)(sender);
            InitializeAllData_Filters(sender, e);
        }

    }
}
