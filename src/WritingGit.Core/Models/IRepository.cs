using System;
using System.Collections.Generic;
using System.Text;

namespace WritingGit.Core.Models
{
    public interface IRepository
    {
        string Name { get; set; }
        string Path { get; set; }
        string RemoteUrl { get; set; }
    }
}
