using MeduzaClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeduzaClient.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
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
    }
}
