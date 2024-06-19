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
using System.Reflection.Metadata.Ecma335;

namespace GiftSetsWPF{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        List<int> createdSetProductsList = new List<int>(10); //list of products IDs
        public MainWindow()
        {
            InitializeComponent();

            sqlConnection = new SqlConnection(new SqlConnectionStringBuilder() {
                    DataSource = "DESKTOP-49KKDKG\\MSSQLEARN",
                    InitialCatalog = "giftsetsDB",
                    UserID = "sa",
                    Password = "db2024"}.ConnectionString);
            
            DisplayProducts();

            DisplaySets();

            DisplayCreatedSet();
            
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

        private void DisplayCreatedSet() {
            try {
                if (createdSetProductsList.Any()) {
                    var parameters = new string[createdSetProductsList.Count];
                    SqlCommand sqlCommand = new SqlCommand();
                    
                    for (int i=0; i<createdSetProductsList.Count; i++) {
                        parameters[i] = string.Format("@createdSetProductsList{0}", i);
                        sqlCommand.Parameters.AddWithValue(parameters[i], createdSetProductsList[i]);
                    }

                    sqlCommand.CommandText = string.Format("SELECT * FROM Products WHERE ProductID in ({0})", string.Join(", ", parameters));
                    sqlCommand.Connection = sqlConnection;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand)) {
                        DataTable createdSetTable = new DataTable();
                        adapter.Fill(createdSetTable);
                        createdSetList.DisplayMemberPath = "name";
                        createdSetList.SelectedValuePath = "ProductID";
                        createdSetList.ItemsSource = createdSetTable.DefaultView;
                    }
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
                    
                    if (reader.Read()) {
                        var datamap = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
                        productPriceBox.Text = datamap["price"].ToString();
                    }
                    
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

        private void AddToSetClick(object sender, RoutedEventArgs args) {
             try {
                createdSetProductsList.Add((int) productsList.SelectedValue);
                DisplayCreatedSet();

            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteFromSetClick(object sender, RoutedEventArgs args) {
            try {
                createdSetProductsList.Remove((int) createdSetList.SelectedValue);
                DisplayCreatedSet();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateSetClick(object sender, RoutedEventArgs args) {
            try {     
                SqlCommand sqlCommand = new SqlCommand();
                
                string query_columns = "INSERT INTO Sets (name";
                string query_values = " VALUES (@name";
                sqlCommand.Parameters.Add(new SqlParameter(string.Format("@name"), SqlDbType.VarChar)).Value=setNameBox.Text;

                for (int i=0; i<createdSetProductsList.Count; i++) {
                    query_values = query_values + "," + string.Format(" @product{0}ID", i+1);
                    query_columns = query_columns + "," + string.Format(" product{0}ID", i+1);
                    sqlCommand.Parameters.Add(new SqlParameter(string.Format("@product{0}ID", i+1), SqlDbType.Int)).Value=createdSetProductsList[i];
                }
                query_columns += ")";
                query_values += ")";
                string query = query_columns + query_values;
                
                sqlCommand.CommandText = query;
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            } finally{
                sqlConnection.Close();
                DisplaySets();
            }
        }
    }


    public class myListBoxItem : ListBoxItem {
        public int distinct_id {get; set;}
    }
}