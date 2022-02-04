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
    /// Interaction logic for Output_page.xaml
    /// </summary>
    public partial class Output_page : Page
    {
        public Output_page()
        {
            InitializeComponent();
        }

        void Load(object sender, RoutedEventArgs e)
        {
            date.tableHeader_Label.Content = date.Tag.ToString();
            serial_id.tableHeader_Label.Content = serial_id.Tag.ToString();
            quantity.tableHeader_Label.Content = quantity.Tag.ToString();
            requester.tableHeader_Label.Content = requester.Tag.ToString();
            price.tableHeader_Label.Content = price.Tag.ToString();
            total_price.tableHeader_Label.Content = total_price.Tag.ToString();

            date.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            requester.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            date.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            requester.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            InitializeAllData();
        }
        public Controls.TableHeader_RadioBtn Selected_sort_by { get; set; } = null;


        public async void InitializeAllData(string filter = "", string sort_by = "", bool DESC = true, string _search_text = "")
        {
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Transactions LEFT JOIN Tools ON (Transaction_tool_serial_id = Tool_serial_id) WHERE (Transaction_type = 'OUT')";

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
            if (_search_text != "" && _search_text != "Search by ID or Name..." && _search_text.Length > 0)
            {
                if (filter == "")
                {
                    query += "AND Transaction_tool_serial_id LIKE '%" + _search_text + "%' ";
                }
                else
                {
                    query += "AND Transaction_tool_serial_id LIKE '%" + _search_text + "%' ";
                }
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
                case "requester":
                    sort_by = "Transaction_req_prov";
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
            if (Output_rows_panel != null)
            {
                Output_rows_panel.Children.Clear();
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

                    Transactions_c output = new Transactions_c
                    {
                        Transaction_id = row["Transaction_id"].ToString(),
                        Transaction_tool_serial_id = row["Transaction_tool_serial_id"].ToString(),
                        Transaction_date = row["Transaction_date"].ToString(),
                        Transaction_quantity = int.Parse(row["Transaction_quantity"].ToString()),
                        Transaction_req_prov = row["Transaction_req_prov"].ToString(),
                        Transaction_by = row["Transaction_by"].ToString(),
                        Transaction_comment = row["Transaction_comment"].ToString(),
                    };
                    Output_rows_panel.Children.Add(new Controls.Output_Row(output, newTool));
                }

            }

            Database_c.Close_DB_Connection();

            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Collapsed;
                DataScrollViewer.Visibility = Visibility.Visible;
            }

        }


        //public async void InitializeAllData(string filter = "", string sort_by = "", bool _isChecked = false, string _search_text = "")
        //{
        //    LoadingIcon.Visibility = Visibility.Visible;
        //    DataScrollViewer.Visibility = Visibility.Collapsed;
        //    SqlConnection conn = Database_c.Get_DB_Connection();
        //    DataTable all_data = new DataTable();

        //    // Create the Query
        //    string query = "Select * FROM Transactions LEFT JOIN Tools ON (Transaction_tool_serial_id = Tool_serial_id) WHERE (Transaction_type = 'OUT')";
        //        // FILTER CONVERTER
        //    switch (filter)
        //    {
        //        case "Added Date":
        //            filter = "";
        //            break;
        //        case "A-Z":
        //            filter = "";
        //            break;
        //        case "Actual Stock":
        //            filter = "";
        //            break;
        //        default:
        //            query += "";
        //            break;
        //    }
        //        // SEARCH CONVERTER
        //    if (_search_text != "" && _search_text != "Search by ID or Name..." && _search_text.Length > 0)
        //    {
        //        query += " AND (Transaction_tool_serial_id LIKE '%" + _search_text + "%') ";
        //    }
        //        // SORT BY CONVERTER
        //    switch (sort_by)
        //    {
        //        case "Date":
        //            sort_by = "Transaction_date";
        //            break;
        //        case "A-Z":
        //            sort_by = "Transaction_tool_serial_id";
        //            break;
        //        case "Quantity":
        //            sort_by = "Transaction_quantity";
        //            break;
        //        default:
        //            sort_by = "Transaction_date";
        //            break;
        //    }
        //    query += " Order by " + sort_by;
        //        // DSEC or ASC CONVERTER
        //    if (!_isChecked)
        //    {
        //        query += " DESC";
        //    }


        //    // Execute the Query 
        //    SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
        //    await Task.Run(() => adapter.Fill(all_data));

        //    // Show the Result
        //    try
        //    {
        //        Output_rows_panel.Children.Clear();
        //        Tools_c newTool = new Tools_c();
        //        foreach (DataRow row in all_data.Rows)
        //        {
        //            if (!row.IsNull("Tool_id"))
        //            {
        //                newTool.Tool_id = (int)row["Tool_id"];
        //                newTool.Tool_serial_id = (string)row["Tool_serial_id"];
        //                newTool.Tool_designation = (string)row["Tool_designation"];
        //                newTool.Tool_drawing = (string)row["Tool_drawing"];
        //                newTool.Tool_project = (string)row["Tool_project"];
        //                newTool.Tool_process = (string)row["Tool_process"];
        //                newTool.Tool_division = (string)row["Tool_division"];
        //                newTool.Tool_position = (string)row["Tool_position"];
        //                newTool.Tool_supplier = (string)row["Tool_supplier"];
        //                newTool.Tool_stock_mini = (int)row["Tool_stock_mini"];
        //                newTool.Tool_actual_stock = (int)row["Tool_actual_stock"];
        //                newTool.Tool_price = (decimal)row["Tool_price"];
        //                newTool.Tool_image_path = (string)row["Tool_image_path"];
        //            }

        //            Transactions_c output = new Transactions_c
        //            {
        //                Transaction_id = row["Transaction_id"].ToString(),
        //                Transaction_tool_serial_id = row["Transaction_tool_serial_id"].ToString(),
        //                Transaction_date = row["Transaction_date"].ToString(),
        //                Transaction_quantity = int.Parse(row["Transaction_quantity"].ToString()),
        //                Transaction_req_prov = row["Transaction_req_prov"].ToString(),
        //                Transaction_by = row["Transaction_by"].ToString(),
        //                Transaction_comment = row["Transaction_comment"].ToString(),
        //            };

        //            Output_rows_panel.Children.Add(new Controls.Output_Row(output, newTool));
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //    Database_c.Close_DB_Connection();
        //    LoadingIcon.Visibility = Visibility.Collapsed;
        //    DataScrollViewer.Visibility = Visibility.Visible;
        //}

        private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Refresh();
            }
        }

        // Get Data With Filtring 
        //public void InitializeAllData_Filters(object sender, EventArgs e)
        //{
        //    if (sort_by_combobox != null && filter_combobox != null && isDESC != null)
        //    {
        //        try
        //        {
        //            string _filter = ((ComboBoxItem)filter_combobox.SelectedItem).Content.ToString();
        //            string _sort_by = ((ComboBoxItem)sort_by_combobox.SelectedItem).Content.ToString();
        //            string _text = ((TextBox)Nav_search_box).Text.ToString();

        //            InitializeAllData(_filter, _sort_by, isDESC.IsChecked.Value, _text);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}


        // Get Data With Filtring 
        public void InitializeAllData_Filters(object sender, EventArgs e)
        {
            if (filter_combobox != null && Nav_search_box != null)
            {
                try
                {
                    string _filter = ((ComboBoxItem)filter_combobox.SelectedItem).Content.ToString();
                    string _text = ((TextBox)Nav_search_box).Text.ToString();

                    if (Selected_sort_by != null)
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

        private void Add_output_tool_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_new_output_Window new_output = new Controls.Add_new_output_Window();
            new_output.Show();
        }
    }
}

