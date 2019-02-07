using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingGit.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WritingGit.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileSelectPage : ContentPage
    {
        FileSelectViewModel viewModel;

        public FileSelectPage(Repository repo)
        {

        }

        public FileSelectPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new FileSelectViewModel();
        }

        async void OnFileSelected(object sender, EventArgs e)
        {

        }
    }
}