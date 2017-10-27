using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinSeed.ViewModels
{
    public class MyNavigationPageViewModel : BaseViewModel
    {
        public MyNavigationPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }
    }
}
