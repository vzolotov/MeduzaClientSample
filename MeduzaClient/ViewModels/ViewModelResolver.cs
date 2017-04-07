using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MeduzaClient.Services;
using MeduzaClient.Services.Interfaces;

namespace MeduzaClient.ViewModels
{
    public class ViewModelResolver
    {
        public static IContainer Container { get; set; }

        public ViewModelResolver()
        {
            var builder = new ContainerBuilder();
            //services
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<ApiService>().As<IApiService>().SingleInstance();
            builder.RegisterType<CacheService>().As<ICacheService>().SingleInstance();
            builder.RegisterType<DataService>().As<IDataService>().SingleInstance();
            //VM
            builder.RegisterType<MainPageViewModel>().SingleInstance();
            builder.RegisterType<NewsPageViewModel>().SingleInstance();
            builder.RegisterType<FirstPageViewModel>().SingleInstance();
            Container = builder.Build();
        }

        public static MainPageViewModel MainViewModel => Container.Resolve<MainPageViewModel>();
        public static NewsPageViewModel NewsViewModel => Container.Resolve<NewsPageViewModel>();
        public static FirstPageViewModel FirstViewModel => Container.Resolve<FirstPageViewModel>();
    }
}
