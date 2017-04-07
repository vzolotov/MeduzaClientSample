using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MeduzaClient.ViewModels
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        /// <summary>
        /// Обработка навигации на страницу
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public virtual Task OnNavigatedToAsync(object navigationData)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Обработка навигации со страницы
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public virtual Task OnNavigatedFrom(object navigationData)
        {
            return Task.CompletedTask;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
