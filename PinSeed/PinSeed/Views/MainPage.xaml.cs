using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PinSeed.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

        }
      
      
    }
}
