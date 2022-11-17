using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.View;
using Restaurant_Demonstration.ViewModel;


namespace Restaurant_Demonstration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfiguerServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfiguerServices(ServiceCollection services)
        {
            services.AddTransient<MainView>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<SectionsViewModel>();
            services.AddTransient<CustomerViewModel>();
            services.AddTransient<ProductsViewModel>();

            services.AddTransient<ISectionsDataProvider.SectionsDataProvider>();
            services.AddTransient<ICustomersDataProvider, CustomersDataProvider>();
            services.AddTransient<IProductsDataProvider, ProductsDataProvider>();

        }
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = _serviceProvider.GetService<MainView>();
                    //mainView?.Show();

                    //var mainView = new MainView();
                    mainView?.Show();
                    loginView.Close();
                }
            };
        }
    }

}
