using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopper.Data;
using RockstarTHA.WPF.ViewModels;

namespace RockstarTHA.WPF
{
    /// <summary>
    /// Sets up application on startup
    /// </summary>
    sealed partial class App : Application
    {
        // <summary>
        // Sets the main window for the application
        // </summary>
        // <param name="e">Contains start up event details</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}
