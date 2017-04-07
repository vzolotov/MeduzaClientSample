using System;
using MeduzaClient.Services.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MeduzaClient.Views.Helpers;
using System.Linq;
using MeduzaClient.Views;

namespace MeduzaClient.Services
{
    public sealed class NavigationService : INavigationService
    {

        Frame _mainFrame;
        /// <summary>
        /// Не оптимально конечно, но для тестового задания хватит
        /// </summary>
        Frame Frame
        {
            get
            {
                if (_mainFrame == null)
                {
                    var frame = (Frame)Window.Current.Content;
                    var page = (FirstPage)frame.Content;
                    var split = page.GetAllChildren<SplitView>().FirstOrDefault();
                    _mainFrame = (Frame)split.Content;
                }
                return _mainFrame;
            }
        }
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
            var result = viewType.AssemblyQualifiedName.Replace(viewType.Name, viewName);
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
