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
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService  _navigation;
        private IDataService _dataService;
        public MainPageViewModel(INavigationService navigation, IDataService dataService)
        {
            _navigation = navigation;
            _dataService = dataService;
            NavigateToNewsCommand = new ActionCommand<Document>(NavigationHandler);
        }      
        
        private List<Document> _main;
        /// <summary>
        /// Список новостей
        /// </summary>
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

        /// <summary>
        /// Загрузка данных при переходе на страницу
        /// </summary>
        /// <param name="navigationData">данные передоваемые при навигации</param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object navigationData)
        {
            var data = await _dataService.GetAllDataAsync();
            Docs = data.ToList();
            await base.OnNavigatedToAsync(navigationData);
        }

        /// <summary>
        /// Команда навигации на выбранную новость
        /// </summary>
        public ActionCommand<Document> NavigateToNewsCommand { get; private set; }

        private void NavigationHandler(Document obj)
        {
            _navigation.NavigateToViewModel<NewsPageViewModel>(obj);
        }
    }
}
