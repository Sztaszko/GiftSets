using System;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GiftSetsWPF{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();

            sqlConnection = new SqlConnection(new SqlConnectionStringBuilder() {
                    DataSource = "DESKTOP-49KKDKG\\MSSQLEARN",
                    InitialCatalog = "giftsetsDB",
                    UserID = "sa",
                    Password = "db2024"}.ConnectionString);
            
            DisplayProducts();
            
        }
        private void DisplayProducts() {
            try {
                string query = "SELECT * FROM Products";
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection)) {
                    DataTable setsTable = new DataTable();
                    adapter.Fill(setsTable);
                    productsList.DisplayMemberPath = "name";
                    productsList.SelectedValuePath = "ProductID";
                    productsList.ItemsSource = setsTable.DefaultView;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DisplaySets() {
            try {
                string query = "SELECT * FROM Sets";
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection)) {
                    DataTable setsTable = new DataTable();
                    adapter.Fill(setsTable);
                    setsList.DisplayMemberPath = "name";
                    setsList.SelectedValuePath = "SetID";
                    setsList.ItemsSource = setsTable.DefaultView;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DisplayProductPrice() {
            try {
                string query = "SELECT * FROM Products p WHERE p.ProductID = @ProductID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ProductID", productsList.SelectedValue);

                sqlConnection.Open();
                using(SqlDataReader reader = sqlCommand.ExecuteReader()) {
                    
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}, {2}, {3}",
                            reader[0], reader[1], reader[2], reader[3]));
                    }
                    // productPriceBox.Text = reader[0].ToString();
                }
                sqlConnection.Close();

            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                sqlConnection.Close();
            }
        }

        private void productsList_SelectionChanged(object sender, SelectionChangedEventArgs args) {
            DisplayProductPrice();
        }
    }
}