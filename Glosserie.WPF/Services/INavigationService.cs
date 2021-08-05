using Glosserie.WPF.ViewModels;

namespace Glosserie.WPF.Services
{
    public interface INavigationService
    {
        void Navigate();
        void Navigate(ViewModelBase viewModel);
    }
}