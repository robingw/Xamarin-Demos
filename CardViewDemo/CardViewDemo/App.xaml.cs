using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CardViewDemo.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CardViewDemo
{
    public partial class App : Application
    {
        public NavigationPage navigationPage;

        public App()
        {
            InitializeComponent();

            MainPage = navigationPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
