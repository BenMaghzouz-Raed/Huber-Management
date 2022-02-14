using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SQLite;
using Huber_Management.Controls;
using System.Collections.Generic;
using Microsoft.Win32;
using ClosedXML.Excel;

namespace Huber_Management.Pages
{
    /// <summary>
    /// Interaction logic for Purchase_order_page.xaml
    /// </summary>
    public partial class Purchase_order_page : Page
    {
        public static List<string> selected_serial_id { get; set; } = new List<string>();
        public Purchase_order_page()
        {
            InitializeComponent();
        }

        void Load(object sender, RoutedEventArgs e)
        {
            // PRIVILEGES
            if (!MainWindow.Connected_user.canPurchaseOrder)
            {
                Purchase.IsEnabled = false;
            }

            serial_id.tableHeader_Label.Content = serial_id.Tag.ToString();
            min_stock.tableHeader_Label.Content = min_stock.Tag.ToString();
            actual_stock.tableHeader_Label.Content = actual_stock.Tag.ToString();
            needed_quantity.tableHeader_Label.Content = needed_quantity.Tag.ToString();
            total_nq.tableHeader_Label.Content = total_nq.Tag.ToString();
            supplier.tableHeader_Label.Content = supplier.Tag.ToString();
            criticality.tableHeader_Label.Content = criticality.Tag.ToString();

            InitializeAllData();
        }

        public Controls.TableHeader_RadioBtn Selected_sort_by { get; set; } = null;

        public async void InitializeAllData(string top = "", string text_search_filter = "", string sort_by = "", bool DESC = true, string _search_text = "")
        {
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SQLiteConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Tools WHERE Tool_stock_mini > Tool_actual_stock ";

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
            if (_search_text != "" && _search_text.Length > 0)
            {
                query += "AND " + text_search_filter + " LIKE '%" + _search_text + "%' ";
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
                case "needed_quantity":
                    sort_by = "Tool_stock_mini - Tool_actual_stock";
                    break;
                case "total_nq":
                    sort_by = "(Tool_stock_mini - Tool_actual_stock)*Tool_price";
                    break;
                case "supplier":
                    sort_by = "Tool_supplier";
                    DESC = !DESC;
                    break;
                case "criticality":
                    sort_by = "Tool_criticality";
                    break;
                default:
                    sort_by = "Tool_criticality";
                    break;
            }
            query += " Order by " + sort_by;

            // DSEC or ASC CONVERTER
            if (DESC)
            {
                query += " DESC";
            }

            // TOP CONVERTER
            if (top != "All" && top != "")
            {
                query += " LIMIT " + top;
            }
            else if (top == "All")
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
            if (All_tools_rows_panel != null && all_data.Rows.Count > 0)
            {
                All_tools_rows_panel.Children.Clear();
                foreach (DataRow row in all_data.Rows)
                {
                    int criticality = 0;
                    int.TryParse(row["Tool_criticality"].ToString(), out criticality);
                    bool isChecked = false;
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
                        Tool_image_path = row["Tool_image_path"].ToString(),
                        Tool_criticality = criticality,
                    };
                    if (selected_serial_id.Contains(row["Tool_serial_id"].ToString()))
                    {
                        isChecked = true;
                    }
                    All_tools_rows_panel.Children.Add(new Controls.Out_of_stock_row(newTool, isChecked));
                }

            }
            else
            {
                All_tools_rows_panel.Children.Clear();
                All_tools_rows_panel.Children.Add(this.noDataFound);
            }

            Database_c.Close_DB_Connection();

            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Collapsed;
                DataScrollViewer.Visibility = Visibility.Visible;
            }

        }

        private async void Purchase_Click(object sender, RoutedEventArgs e)
        {
            if (selected_serial_id.Count > 0)
            { // Export Excel File
                SaveFileDialog SaveDialog = new SaveFileDialog() { Filter = "Excel|*.xlsx|*.xls|*.xlsm" };
                Nullable<bool> returned = SaveDialog.ShowDialog();

                if (returned == true)
                {
                    try
                    {
                        SQLiteConnection conn = Database_c.Get_DB_Connection();
                        string[] selected_array = selected_serial_id.ToArray();
                        DataTable Tools_Table = new DataTable();
                        Tools_Table.Clear();
                        Tools_Table.Columns.Add("Position");
                        Tools_Table.Columns.Add("Code Article / Serial NB");
                        Tools_Table.Columns.Add("Marque");
                        Tools_Table.Columns.Add("Désignation");
                        Tools_Table.Columns.Add("Quantité");
                        Tools_Table.Columns.Add("Prix Unitaire");
                        Tools_Table.Columns.Add("Total Euro");
                        Tools_Table.Columns.Add("Centre De Coût");
                        Tools_Table.Columns.Add("Fournisseur");

                        for (int i = 0; i < selected_array.Length; i++)
                        {
                            string serial_id = selected_array[i];
                            string query = "SELECT Tool_supplier_code, Tool_serial_id, Tool_designation, (Tool_stock_mini - Tool_actual_stock) as Quantité, " +
                                "Tool_price, (Tool_price*(Tool_stock_mini - Tool_actual_stock)) as Total_Euro, Tool_project, Tool_supplier FROM Tools WHERE ( Tool_stock_mini > Tool_actual_stock ) AND Tool_serial_id = '" + serial_id + "' ";
                            
                            DataTable sec_Table = new DataTable();
                            SQLiteDataAdapter adapter = await Task.Run(() => new SQLiteDataAdapter(query, conn));
                            adapter.Fill(sec_Table);
                            DataRow sec_row = sec_Table.Rows[0];

                            DataRow row_position = Tools_Table.NewRow();
                            row_position["Position"] = i.ToString();

                            if (sec_row["Tool_supplier_code"].ToString() != "")
                            {
                                row_position["Code Article / Serial NB"] = sec_row["Tool_supplier_code"].ToString();
                            }
                            else
                            {
                                row_position["Code Article / Serial NB"] = sec_row["Tool_serial_id"].ToString();
                            }

                            row_position["Désignation"] = sec_row["Tool_designation"].ToString();
                            row_position["Quantité"] = sec_row["Quantité"].ToString();
                            row_position["Prix Unitaire"] = sec_row["Tool_price"].ToString();
                            row_position["Total Euro"] = sec_row["Total_Euro"].ToString();
                            row_position["Centre De Coût"] = sec_row["Tool_project"].ToString();
                            row_position["Fournisseur"] = sec_row["Tool_supplier"].ToString();

                            Tools_Table.Rows.Add(row_position);
                        }

                        XLWorkbook book = new XLWorkbook();
                        book.Worksheets.Add(Tools_Table, "Ordres d'achat");

                        book.SaveAs(SaveDialog.FileName);

                        // SUCCESS
                        MessageBox.Show(SaveDialog.FileName + " is saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Database_c.Close_DB_Connection();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                        Database_c.Close_DB_Connection();
                        return;
                    }

                }
            }
            else
            {
                MessageBox.Show("You didn't select any tool !", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }

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
            if (search_filter != null && Nav_search_box != null && top_combobox != null)
            {
                try
                {
                    string _filter = ((ComboBoxItem)search_filter.SelectedItem).Content.ToString();
                    string _text = ((TextBox)Nav_search_box).Text.ToString();
                    string _top = ((ComboBoxItem)top_combobox.SelectedItem).Content.ToString();

                    if (Selected_sort_by != null)
                    {
                        bool DSEC = Selected_sort_by.RadioBtn_invisible_Down.IsChecked.Value;

                        string _sort_by = Selected_sort_by.Name.ToString();
                        InitializeAllData(_top, _filter, _sort_by, DSEC, _text);
                    }
                    else
                    {
                        InitializeAllData(_top, _filter, "", true, _text);
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

        private void select_all_Checked(object sender, RoutedEventArgs e)
        {
            selected_serial_id = new List<string>();
            foreach (Out_of_stock_row row in this.All_tools_rows_panel.Children)
            {
                row.checkbox.IsChecked = true;
            }
        }

        private void select_all_Unchecked(object sender, RoutedEventArgs e)
        {
            selected_serial_id = new List<string>();
            foreach (Out_of_stock_row row in this.All_tools_rows_panel.Children)
            {
                row.checkbox.IsChecked = false;
            }
        }
    }
}
