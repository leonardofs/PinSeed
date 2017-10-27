using Xamarin.Forms;

namespace PinSeed.Views
{
    public partial class MyNavigationPage : NavigationPage
    {
        public MyNavigationPage()
        { 

            MyNavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
       
        }
    }
}
