using MeduzaClient.Models;
using MeduzaClient.Services.Interfaces;
using MeduzaClient.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeduzaClient.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        IOpenLinkService _linkService;
        INotifycationService _notify;
        public NewsPageViewModel(IOpenLinkService linkService, INotifycationService notify)
        {
            _linkService = linkService;
            _notify = notify;
            ShowDocumentCommand = new ActionCommand(async () =>
           {
               try
               {
                   await _linkService.OpenLinkAsync(Document?.url);
               }
               catch (Exception ex)
               {
                   await _notify.ShowMessageAsync("Ошибка при открытии новости");
               }
           });
        }
        public override Task OnNavigatedToAsync(object navigationData)
        {
            Document = (Document)navigationData;
            return base.OnNavigatedToAsync(navigationData);
        }

        private Document _document;
        public Document Document
        {
            get
            {
                return _document;
            }
            set
            {
                _document = value;
                OnPropertyChanged();
            }
        }

        public ActionCommand ShowDocumentCommand
        {
            get;
            private set;
        }
    }
}
