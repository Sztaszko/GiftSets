using GiftSetsEF;
using GiftSetsEF.Context;
using GiftSetsWPF.Core;
using GiftSetsWPF.Services;
using GiftSetsWPF.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace GiftSetsWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IConfiguration _configuration;
    private IServiceProvider _serviceProvider { get; set; }

    public App()
    {
        BuildConfiguration();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private void BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        #if DEBUG
                .AddUserSecrets<App>()
        #endif
                .AddEnvironmentVariables();

        _configuration = builder.Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>(provider => new MainWindow
        {
            DataContext = provider.GetRequiredService<MainViewModel>()
        });
        services.AddSingleton<MainProductsViewModel>();
        services.AddSingleton<ProductDetailsViewModel>();
        services.AddSingleton<ProductDetailsViewModel>();

        services.Configure<ProductsDbOptions>(_configuration.GetSection("ProductsDbOptions"));
        services.AddProductsDbServices();
        services.AddTransient<IProductsDataProviderService, ProductsDataProviderService>();

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}

