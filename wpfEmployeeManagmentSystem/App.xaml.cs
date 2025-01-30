using EmployeeManagementSystem.Application.Services;
using EmployeeManagementSystem.Domain.Repositories;
using EmployeeManagementSystem.Infrastructure.Data;
using EmployeeManagementSystem.Infrastructure.Repositories;
using EmployeeManagementSystem.Presentation.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CodeDom;
using System.Configuration;
using System.Data;
using System.Windows;

namespace wpfEmployeeManagmentSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // Register DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("YourConnectionString"));

            // Register Repositories--------
            services.AddScoped(typeof (IGenericRepository<>),typeof(GenericRepository<>));

            // Register Services
           

            // Register ViewModels
            services.AddScoped<MainWindowViewModel>();

            services.AddScoped<MainWindow>();


            // Register ervices
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            _serviceProvider = services.BuildServiceProvider();

            // Show the Main Window
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
