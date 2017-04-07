using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeduzaClient.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MeduzaClient.Views
{
    public class BasePage : Page
    {
        ViewModelBase _baseViewModel;
        public BasePage()
        {
            DataContextChanged += BasePage_DataContextChanged;
        }

        private void BasePage_DataContextChanged(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
        {
            _baseViewModel = args.NewValue as ViewModelBase;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _baseViewModel?.OnNavigatedToAsync(e.Parameter);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            _baseViewModel?.OnNavigatedFrom(e.Parameter);
        }
    }
}
