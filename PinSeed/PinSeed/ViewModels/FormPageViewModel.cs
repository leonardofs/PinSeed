using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PinSeed.ViewModels
{
    public class FormPageViewModel : BaseViewModel, INavigatedAware
    {

        private byte[] imagem;
        public byte[] Imagem
        {
            get { return imagem; }
            set { SetProperty(ref imagem, value); }
        }

        private NavigationParameters _navigationParams;


        public FormPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public override void OnNavigatedTo(NavigationParameters navigationParams)
        {
            imagem = navigationParams.GetValue<byte[]>("ImageAsBytes");
            
             _navigationParams = navigationParams;

            if (navigationParams.GetNavigationMode() == 0)
                _navigationService.GoBackAsync(null, false);
        }

    }
}
