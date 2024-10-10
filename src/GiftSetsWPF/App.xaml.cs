using GiftSets.Domain.Commands;
using GiftSets.Domain.Queries;
using GiftSetsWPF.Stores;
using GiftSetsWPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GiftSetsWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow();

        MainWindow.Show();

        base.OnStartup(e);

    }
}

