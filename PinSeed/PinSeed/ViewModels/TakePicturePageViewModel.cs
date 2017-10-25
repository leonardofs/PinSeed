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

namespace PinSeed.ViewModels
{
    public class TakePicturePageViewModel : BaseViewModel
    {

        public DelegateCommand TakePictureCommand { get; set; }
        public DelegateCommand SelectPictureCommand { get; set; }


        public TakePicturePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
             CrossMedia.Current.Initialize();
            TakePictureCommand = new DelegateCommand(async () => await ExecuteTakePictureCommand());
            SelectPictureCommand = new DelegateCommand(async () => await ExecuteSelectPictureCommand());

        }

        // Usar camera para tirar foto

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

                    // TODO: aqui a foto foi tirada
                    await _pageDialogService.DisplayAlertAsync("Localização do Arquivo", file.Path, "OK");

                    /*image.Source = ImageSource.FromStream(() =>
                   {
                     var stream = file.GetStream();
                        file.Dispose();
                     return stream;
                    });
                    */
                }
                catch (Exception e)
                {
                    throw;
                    await _pageDialogService.DisplayAlertAsync("Erro", e.ToString() , "OK");
                }
            }
        }

        //Selecionar foto da galeria

        private async Task ExecuteSelectPictureCommand()
        {

            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }


            if (!(cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted))
            {
                
                await _pageDialogService.DisplayAlertAsync("Sem permissão", "Sem acesso a galeria de fotos", "OK");
                return;
            }
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium
            });


            if (file == null)
                return;

            /* image.Source = ImageSource.FromStream(() =>
             {
               var stream = file.GetStream();
                     file.Dispose();
               return stream;
             });
             */
        }

    }
}
