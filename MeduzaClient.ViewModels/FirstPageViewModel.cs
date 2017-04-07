using MeduzaClient.Services.Interfaces;
using MeduzaClient.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeduzaClient.ViewModels
{
    public class FirstPageViewModel : ViewModelBase
    {
        private INavigationService _navigation;
        public FirstPageViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            GotoHomeCommand = new ActionCommand(GotoHomeCommandAction);
        }       

        public override Task OnNavigatedToAsync(object navigationData)
        {
            //Навигация на первую страницу приложения
            _navigation.NavigateToViewModel<MainPageViewModel>();
            return base.OnNavigatedToAsync(navigationData);
        }

        public ActionCommand GotoHomeCommand { get; private set; }
        private void GotoHomeCommandAction()
        {
            _navigation.NavigateToViewModel<MainPageViewModel>();
        }
    }
}
