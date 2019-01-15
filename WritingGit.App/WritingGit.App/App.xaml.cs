using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WritingGit.App.Views;
using LibGit2Sharp;
using System.Diagnostics;
using System.Linq;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WritingGit.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            if (!Directory.Exists(Models.Globals.storageFolder + "\\TestRepo"))
            {
                Repository.Clone("https://github.com/herrozerro/The-Disk-Setting.git", Models.Globals.storageFolder + "\\TestRepo");
            }


            using (var repo = new Repository(Models.Globals.storageFolder + "\\TestRepo"))
            {
                foreach (var commit in repo.Commits.OrderBy(x => x.Author.When))
                {
                    Debug.WriteLine($"Date: {commit.Author.When}, Author: {commit.Author}, Message: {commit.Message}");
                }
            }

            MainPage = new MainPage();
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
