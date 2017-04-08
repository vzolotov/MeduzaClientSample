using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MeduzaClient.Services;
using MeduzaClient.Services.Interfaces;
using MeduzaClient.Database;
using MeduzaClient.Services.Database;

namespace MeduzaClient.ViewModels
{
    public class ViewModelResolver
    {
        public static IContainer Container { get; set; }

        public ViewModelResolver()
        {
            var builder = new ContainerBuilder();
            //services
            builder.RegisterType<NotifycationService>().As<INotifycationService>().SingleInstance();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            builder.RegisterType<OpenLinkService>().As<IOpenLinkService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<ApiService>().As<IApiService>().SingleInstance();
            builder.RegisterType<CacheService>().As<ICacheService>().SingleInstance();
            builder.RegisterType<DataService>().As<IDataService>().SingleInstance();
            builder.RegisterType<DataContext>().SingleInstance();
            builder.RegisterType<DbManager>().As<IDbManager>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
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
