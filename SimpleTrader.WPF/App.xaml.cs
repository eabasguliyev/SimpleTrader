using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.EntityFramework.Services.Common;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        // GetService - return null if service not found
        // GetRequiredService - throw exception if service not found

        protected override async void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();

            //using (IServiceScope scope = serviceProvider.CreateScope())
            //{
            //    var differentViewModel = scope.ServiceProvider.GetRequiredService<MainViewModel>();

            //    var equal = differentViewModel == window.DataContext;

            //}

            window.Show();

            base.OnStartup(e);
        }

        // IServiceProvider - for getting services
        // IServiceCollection - for registering services


        // 1. Singleton - one instance per application
        // 2. Transient - different instance everytime
        // 3. Scoped - one instance per scope

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<SimpleTraderDbContextFactory>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();

            services.AddScoped<IMajorIndexService, MajorIndexService>();

            services.AddSingleton<ISimpleTraderViewModelAbstractFactory, SimpleTraderViewModelAbstractFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<MajorIndexListingViewModel>, MajorIndexListingViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();
        }
    }
}
