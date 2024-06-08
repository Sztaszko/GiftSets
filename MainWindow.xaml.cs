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
            
        }
    }
}