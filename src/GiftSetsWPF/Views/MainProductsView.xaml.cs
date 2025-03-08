using GiftSetsWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace GiftSetsWPF.Views
{
    public partial class MainProductsView : UserControl
    {
        public MainProductsView()
        {
            InitializeComponent();
            DataContextChanged += MainProductsView_DataContextChanged;
        }

        private void MainProductsView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is MainProductsViewModel viewModel)
            {
                viewModel.ProductsListing.LoadProductsAsync();
            }
        }
    }
}
