﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleTrader.Domain.Models;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new MajorIndexService().GetMajorIndex(MajorIndexType.DowJones).ContinueWith((task) =>
            {
                var index = task.Result;
            });

            Window window = new MainWindow();


            window.DataContext = new MainViewModel();

            window.Show();

            base.OnStartup(e);
        }
    }
}