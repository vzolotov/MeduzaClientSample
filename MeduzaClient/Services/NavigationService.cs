using System;
using MeduzaClient.Services.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MeduzaClient.Views.Helpers;
using System.Linq;

namespace MeduzaClient.Services
{
    public sealed class NavigationService : INavigationService
    {
        /// <summary>
        /// Не оптимально конечно, но для тестового задания хватит
        /// </summary>
        Frame Frame => Window.Current.Content.GetAllChildren<SplitView>().FirstOrDefault().GetAllChildren<Frame>().FirstOrDefault();
        /// <summary>
        /// Возможность перехода на другую страницу
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                try
                {
                    var result = Frame.CanGoBack;
                    return result;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public void NavigateToViewModel<TViewModel>(object parameter = null)
        {
            try
            {
                var viewType = ResolveViewType<TViewModel>();
                if (Window.Current.Content != null)
                {
                    if (parameter != null)
                    {
                        Frame.Navigate(viewType, parameter);
                    }
                    else
                    {
                        Frame.Navigate(viewType);
                    }
                }
            }
            catch
            {
            }
        }

        public void NavigateToView(string view, object parameter = null)
        {
            try
            {
                var viewType = ResolveView(view);
                if (Window.Current.Content != null)
                {
                    if (parameter != null)
                    {
                        Frame.Navigate(viewType, parameter);
                    }
                    else
                    {
                        Frame.Navigate(viewType);
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// поиск вью по имени вью-модели
        /// </summary>
        /// <typeparam name="TViewModel">вью-мождель для навигации</typeparam>
        /// <returns>тип вью(страницы) на которую будет выполнен переход</returns>
        private static Type ResolveViewType<TViewModel>()
        {
            var viewModelType = typeof(TViewModel);
            var viewType = typeof(MainPage);
            var viewClass = viewType.AssemblyQualifiedName.Replace(
                viewType.Name,
                viewType.Name.Replace("ViewModel", string.Empty));
            var viewName = viewModelType.Name.Replace(
                viewModelType.Name,
                viewModelType.Name.Replace("ViewModel", string.Empty));
            var result = viewType.AssemblyQualifiedName.Replace(viewType.Name, viewType.Name.Replace("Main", viewName));
            var type = Type.GetType(result);
            return type;
        }

        private static Type ResolveView(string viewName)
        {

            var viewType = typeof(MainPage);
            var viewClass = viewType.AssemblyQualifiedName.Replace(
                viewType.Name,
                viewType.Name.Replace("ViewModel", string.Empty));
            var result = viewType.AssemblyQualifiedName.Replace(viewType.Name, viewType.Name.Replace("Shop", viewName));
            var type = Type.GetType(result);
            return type;
        }
    }
}
