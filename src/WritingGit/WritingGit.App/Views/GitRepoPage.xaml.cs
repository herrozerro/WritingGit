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
	public partial class GitRepoPage : ContentPage
	{
        private GitRepoViewModel viewModel;

		public GitRepoPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new GitRepoViewModel();
        }

        protected override void OnAppearing()
        {
            if (viewModel.Items.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
	}
}