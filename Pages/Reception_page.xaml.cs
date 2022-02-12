using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Windows.Media;

namespace Huber_Management.Pages
{
    /// <summary>
    /// Interaction logic for Reception_page.xaml
    /// </summary>
    public partial class Reception_page : Page
    {
        public Reception_page()
        {
            InitializeComponent();
        }
        void Load(object sender, RoutedEventArgs e)
        {   
            // PRIVILEGES SETTINGS
            if (!MainWindow.Connected_user.canReception)
            {
                Add_reception_tool.IsEnabled = false;
            }

            // INITIALIZE BY WHO COMBOBOX
            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable by_who_table = new DataTable();
            string query = "SELECT DISTINCT(Transaction_by) as results FROM Transactions";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
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

            date.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            supplier.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            date.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            supplier.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            InitializeAllData();
        }
        private Controls.TableHeader_RadioBtn Selected_sort_by { get; set; } = null;

        public async void InitializeAllData(string when = "", string who = "", string filter = "", string sort_by = "", bool DESC = true, string _search_text = "")
        {
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Transactions LEFT JOIN Tools ON (Transaction_tool_serial_id = Tool_serial_id) WHERE (Transaction_type = 'IN') ";
            
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
                    filter = "Tool_serial_id";
                    break;
            }

            // SEARCH CONVERTER
            if (_search_text != "" && _search_text.Length > 0)
            {
                query += " AND " + filter + " LIKE '%" + _search_text + "%' ";
            }

            // WHEN CONVERTER
            switch (when)
            {
                case "This Month":
                    when = " AND ( MONTH(Transaction_date)=MONTH(GETDATE()) and YEAR(Transaction_date)=YEAR(GETDATE()) ) ";
                    break;
                case "Last Month":
                    when = " AND ( MONTH(Transaction_date)<=( MONTH(GETDATE()) - 1 ) and YEAR(Transaction_date)=YEAR(GETDATE()) ) ";
                    break;
                case "Last Year":
                    when = " AND ( YEAR(Transaction_date)= (YEAR(GETDATE()) - 1) ) ";
                    break;
                case "This Year":
                    when = " AND ( YEAR(Transaction_date)=YEAR(GETDATE()) ) ";
                    break;
                case "All":
                    when = "";
                    break;
                default:
                    when = " AND ( MONTH(Transaction_date)=MONTH(GETDATE()) and YEAR(Transaction_date)=YEAR(GETDATE()) ) ";
                    break;
            }
            query += when;

            // BY WHO CONVERTER
            if(who != "Any" && who != "")
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
                SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
                adapter.Fill(all_data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Reception_rows_panel != null && all_data.Rows.Count > 0)
            {
                Reception_rows_panel.Children.Clear();
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

                    Transactions_c reception = new Transactions_c
                    {
                        Transaction_id = row["Transaction_id"].ToString(),
                        Transaction_tool_serial_id = row["Transaction_tool_serial_id"].ToString(),
                        Transaction_date = row["Transaction_date"].ToString(),
                        Transaction_quantity = int.Parse(row["Transaction_quantity"].ToString()),
                        Transaction_req_prov = row["Transaction_req_prov"].ToString(),
                        Transaction_by = row["Transaction_by"].ToString(),
                        Transaction_comment = row["Transaction_comment"].ToString(),
                    };
                    Reception_rows_panel.Children.Add(new Controls.Reception_Row(reception, newTool));
                }

            }
            else
            {
                Reception_rows_panel.Children.Clear();
                Reception_rows_panel.Children.Add(this.noDataFound);
            }

            Database_c.Close_DB_Connection();

            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Collapsed;
                DataScrollViewer.Visibility = Visibility.Visible;
            }

        }

        //private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if(this.NavigationService != null)
        //    {
        //        this.NavigationService.Refresh();
        //    }
        //}

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

        private void Add_reception_tool_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_new_reception_Window new_reception = new Controls.Add_new_reception_Window();
            new_reception.Show();
        }

    }
}
