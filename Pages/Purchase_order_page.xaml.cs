using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
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

            if (!MainWindow.Connected_user.canPurchaseOrder)
            {
                Purchase.IsEnabled = false;
                Purchase.Visibility = Visibility.Collapsed;
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

        public async void InitializeAllData(string filter = "", string sort_by = "", bool DESC = true, string _search_text = "")
        {
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Tools WHERE Tool_stock_mini > Tool_actual_stock ";

            // FILTER CONVERTER
            switch (filter)
            {
                case "Serial Number":
                    filter = "Tool_serial_id";
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
                query += "AND " + filter + " LIKE '%" + _search_text + "%' ";
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
                        Tool_image_path = (string)row["Tool_image_path"],
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
                        SqlConnection conn = Database_c.Get_DB_Connection();
                        string[] selected_array = selected_serial_id.ToArray();
                        DataTable Tools_Table = new DataTable();

                        for (int i = 0; i < selected_array.Length; i++)
                        {
                            string serial_id = selected_array[i];
                            string query = "SELECT Tool_position as Position, Tool_serial_id as Marque, Tool_designation as Désignation, (Tool_stock_mini - Tool_actual_stock) as Quantité, " +
                                "Tool_price as Prix_Unitaire, (Tool_price*(Tool_stock_mini - Tool_actual_stock)) as Total_Euro, Tool_project as Centre_De_Coût, Tool_supplier as Fournisseur FROM Tools WHERE ( Tool_stock_mini > Tool_actual_stock ) AND Tool_serial_id = '" + serial_id + "' ";

                            SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
                            adapter.Fill(Tools_Table);
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
