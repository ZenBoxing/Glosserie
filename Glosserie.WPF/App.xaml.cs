using Glosserie.WPF.Library.Services;
using Glosserie.WPF.ViewModels;
using Glosserie.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Glosserie.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IVocabListService, VocabListService>();

            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<VocabListsViewModel>, VocabListsViewModelFactory>();

            services.AddScoped<ShellViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<ShellViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
