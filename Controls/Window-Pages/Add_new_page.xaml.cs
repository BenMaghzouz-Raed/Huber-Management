using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for Add_new_page.xaml
    /// </summary>
    public partial class Add_new_page : Page
    {
        public Add_new_page()
        {
            InitializeComponent();
            SQLiteConnection conn = Database_c.Get_DB_Connection();

            // INITIALIZE DIVISION COMBOBOX
            InitializeComboBox("Tool_division", division_add_combobox, conn);

            // INITIALIZE DIVISION COMBOBOX
            InitializeComboBox("Tool_supplier", supplier_add_combobox, conn);

            Database_c.Close_DB_Connection();

        }
        private async void InitializeComboBox(string Tool_column_name, ComboBox combobox_name, SQLiteConnection conn)
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
                    combobox_name.Items.Add(newItem);
                }
            }
        }

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
            MyImage.Stretch = Stretch.Uniform;
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

    }
}
