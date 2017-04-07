using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeduzaClient.Models;
using MeduzaClient.Models.Page;
using MeduzaClient.Services;
using MeduzaClient.Services.Interfaces;
using MeduzaClient.ViewModels.Common;

namespace MeduzaClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService  _navigation;
        private IDataService _dataService;
        public MainViewModel(INavigationService navigation, IDataService dataService)
        {
            _navigation = navigation;
            _dataService = dataService;
            NavigateToNews = new ActionCommand(NavigateHandler);
        }

        private List<Document> _main;
        public List<Document> Docs
        {
            get
            {
                return _main;
            }
            set
            {
                _main = value;
                OnPropertyChanged();
            }
        }

        private void NavigateHandler()
        {
            _navigation.NavigateToViewModel<NewsViewModel>();
        }

        public override async Task OnNavigatedToAsync(object navigationData)
        {
            var data = await _dataService.GetAllDataAsync();
            Docs = data.ToList();
            await base.OnNavigatedToAsync(navigationData);
        }

        public ActionCommand NavigateToNews { get; private set; }
    }
}
