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

            Items = new ObservableCollection<Item>();
            LoadGitRepo = new Command(async () => await LoadGitRepoFromUrl());
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Commit = new Command(async () => await ExecuteCommit());
        }

        public ICommand LoadGitRepo { get; }
        public Command LoadItemsCommand { get; }
        public Command Commit { get; }

        async Task LoadGitRepoFromUrl()
        {
            var folder = Globals.storageFolder;

            if (!Directory.Exists(Models.Globals.storageFolder + "\\Repos\\" + Name))
            {
                var co = new CloneOptions();
                co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = "", Password = "" };
                try
                {
                    Repository.Clone(Repo, 
                        Models.Globals.storageFolder + "\\Repos\\" + Name,
                        co);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

            }

            using (var repo = new Repository(Models.Globals.storageFolder + "\\Repos\\" + Name))
            {
                foreach (var commit in repo.Commits.OrderBy(x => x.Author.When))
                {
                    Debug.WriteLine($"Date: {commit.Author.When}, Author: {commit.Author}, Message: {commit.Message}");
                }
            }

            await ExecuteLoadItemsCommand();
        }

        async Task ExecuteCommit()
        {
            using (var repo = new Repository(Models.Globals.storageFolder + "\\Repos\\" + Name))
            {
                Commands.Stage(repo, "README.md");
                repo.Commit("TestCommit", repo.Commits.First().Author, repo.Commits.First().Author);
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
                ls.Add(new Item { Id = i.ToString(), Text = item, Description = item });
                i++;
            }

            return ls;
        }
    }
}
