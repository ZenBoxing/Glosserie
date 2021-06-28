using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Library.State.Authenticators;
using Glosserie.WPF.Stores;
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
        protected override async void OnStartup(StartupEventArgs e)
        {
            //Authenticator authenticator = new Authenticator(new AuthenticationService());
            //UserModel user = await authenticator.Login(new LoginModel
            //{ 
            //    Email = "someemail@email.com",
            //    Password = "Password"
            //});

            IServiceProvider serviceProvider = CreateServiceProvider();
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IVocabListService, VocabListService>();
            
            services.AddSingleton<INavigationStore, NavigationStore>();

            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<VocabListsViewModel>, VocabListsViewModelFactory>();
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewModelFactory>();
            services.AddSingleton<IViewModelFactory<RegisterViewModel>, RegisterViewModelFactory>();

            services.AddScoped<ShellViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<ShellViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
