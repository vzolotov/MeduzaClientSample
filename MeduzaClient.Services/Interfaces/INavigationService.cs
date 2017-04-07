namespace MeduzaClient.Services.Interfaces
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        void GoBack();
        void NavigateToView(string view, object parameter = null);
        void NavigateToViewModel<TViewModel>(object parameter = null);
    }
}
