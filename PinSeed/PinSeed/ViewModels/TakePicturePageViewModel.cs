using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.IO;
using System.Diagnostics;

namespace PinSeed.ViewModels
{
    public class TakePicturePageViewModel : BaseViewModel, INavigatedAware
    {

        public DelegateCommand TakePictureCommand { get; set; }
        public DelegateCommand SelectPictureCommand { get; set; }
        public NavigationParameters _navigationParams { get; set; }


        //indicador usado para desativar botoes durante chamadas de metodos.
        private bool enableButtons;
        public bool EnableButtons
        {
            get { return enableButtons; }
            set { SetProperty(ref enableButtons, value); }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }



        /// <summary>
        /// Construtror
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="pageDialogService"></param>
        public TakePicturePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            CrossMedia.Current.Initialize();
            TakePictureCommand = new DelegateCommand(async () => await ExecuteTakePictureCommand());
            
            NoLoading();
        }
        

        private async Task ExecuteTakePictureCommand()
        {

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {

                await _pageDialogService.DisplayAlertAsync("Sem permissão", "Camera indisponivel.", "OK");
                return;
            }
            else
            {

                try
                {

                    WhenLoading();

                    /////////////////////////////////////////// Navegação

                    var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        PhotoSize = PhotoSize.Medium,
                        Directory = "Sample",
                        Name = "test.jpg"
                    });

                    if (file == null)
                    {
                        return;
                    }

                    byte[] imageAsBytes = null;
                    using (var memoryStream = new MemoryStream())
                    {
                        file.GetStream().CopyTo(memoryStream);
                        file.Dispose();
                        imageAsBytes = memoryStream.ToArray();
                    }
                    if (imageAsBytes.Length > 0)
                    {
                        try
                        {
                            _navigationParams = new NavigationParameters
                            {
                                { "ImageAsBytes", imageAsBytes }
                            };

                            await _navigationService.NavigateAsync("FormPage", _navigationParams, false);
                            NoLoading();
                            return;
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e);
                            NoLoading();
                            await _pageDialogService.DisplayAlertAsync("Erro navega", e.ToString(), "OK");
                            throw;
                            
                        }
                    }
                    else
                    {
                        await _pageDialogService.DisplayAlertAsync("Erro", "imagem Vazia", "OK");
                        NoLoading();
                        return;

                    }
                    ////////////////////////////////////////////////////////////////Fim da Navegação
                  

                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
 
    
        private void WhenLoading()
        {
            EnableButtons = false;
            IsLoading = true;
        }

        private void NoLoading()
        {
            EnableButtons = true;
            IsLoading = false;
        }

        //Selecionar foto da galeria
       


        /// <summary>
        /// Passa a imagem para a pagina de cadastro 
        /// </summary>
        /// <param name="file"> Recebe MediaFile</param>
        private async Task Navigate(MediaFile file)
        {
            byte[] imageAsBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                imageAsBytes = memoryStream.ToArray();
            }
            if (imageAsBytes.Length > 0)
            {
                try
                {

                    _navigationParams.Add("ImageAsBytes", imageAsBytes); 

                    await _navigationService.NavigateAsync("FormPage", _navigationParams, false);
                    return;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    await _pageDialogService.DisplayAlertAsync("Erro navega", e.ToString(), "OK");
                    throw;
                }
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Erro", "imagem Vazia", "OK");
                return;
            }

        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
