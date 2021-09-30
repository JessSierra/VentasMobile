using System;
using VentasMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentasMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainMenu();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
