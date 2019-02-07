using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WritingGit.App.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WritingGit.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
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
