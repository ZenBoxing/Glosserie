using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Library.State.Authenticators;
using Glosserie.WPF.Services;
using Glosserie.WPF.Stores;
using Glosserie.WPF.ViewModels;
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
            INavigationService InitialNavigationService = serviceProvider.GetRequiredService<INavigationService>();
            InitialNavigationService.Navigate(serviceProvider.GetRequiredService<LoginViewModel>());

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<NavigationStore>();

            services.AddSingleton<IVocabListService, VocabListService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAuthenticator, Authenticator>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<CreateViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<VocabListsViewModel>();

            services.AddScoped<ShellViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow {
                DataContext = s.GetRequiredService<ShellViewModel>()
            });

            return services.BuildServiceProvider();
        }
    }
}
