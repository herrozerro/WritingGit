using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace WritingGit.Core.Services
{
    public class GitService
    {

        public void CloneRepository(string url, string name)
        {

            if (!Directory.Exists(".\\Repos\\" + name))
            {
                var co = new CloneOptions();
                co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = "", Password = "" };
                try
                {
                    Repository.Clone(url,".\\Repos\\" + name, co);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public IEnumerable<Repository> GetRepositories()
        {
            List<Repository> repositories = new List<Repository>();
            
            var drs = Directory.GetDirectories(".\\Repos\\");

            foreach (var dir in drs)
            {
                var s = Repository.Discover(dir);
                var repo = new Repository(s);

                repositories.Add(repo);
            }

            return repositories;
        }

    }
}
