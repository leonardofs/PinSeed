
using Prism.Navigation;
using Prism.Services;


namespace PinSeed.ViewModels
{
    public class MyNavigationPageViewModel : BaseViewModel
    {
        public MyNavigationPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }
    }
}
