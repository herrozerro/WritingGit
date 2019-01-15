using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WritingGit.App.Models;
using Xamarin.Forms;

namespace WritingGit.App.ViewModels
{
    public class GitRepoViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public string Repo { get; set; }
        public string Name { get; set; }

        public GitRepoViewModel()
        {
            Title = "Git Repos";

            LoadGitRepo = new Command(async () => await LoadGitRepoFromUrl());
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ICommand LoadGitRepo { get; }
        public Command LoadItemsCommand { get; set; }

        async Task LoadGitRepoFromUrl()
        {
            if (!Directory.Exists(Models.Globals.storageFolder + "\\Repos\\" + Name))
            {
                Repository.Clone("https://github.com/herrozerro/The-Disk-Setting.git", Models.Globals.storageFolder + "\\Repos\\" + Name);
            }

            using (var repo = new Repository(Models.Globals.storageFolder + "\\Repos\\" + Name))
            {
                foreach (var commit in repo.Commits.OrderBy(x => x.Author.When))
                {
                    Debug.WriteLine($"Date: {commit.Author.When}, Author: {commit.Author}, Message: {commit.Message}");
                }
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = GetItems();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        List<Item> GetItems()
        {
            var ls = new List<Item>();
            var i = 1;

            foreach (var item in Directory.GetDirectories(Models.Globals.storageFolder + "\\Repos\\"))
            {
                ls.Add(new Item { Id = i.ToString(), Text = item, Description = item});
                i++;
            }

            return ls;
        }
    }
}
