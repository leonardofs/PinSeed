using Prism.Unity;
using PinSeed.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PinSeed
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            MyNavigationPage.SetHasNavigationBar(this, false);

            NavigationService.NavigateAsync("MyNavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<TakePicturePage>();
            Container.RegisterTypeForNavigation<MapPage>();
            Container.RegisterTypeForNavigation<LastRegistersPage>();
            Container.RegisterTypeForNavigation<FormPage>();
            Container.RegisterTypeForNavigation<MyNavigationPage>();
        }
        
    }
}
