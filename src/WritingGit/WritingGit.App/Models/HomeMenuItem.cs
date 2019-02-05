using System;
using System.Collections.Generic;
using System.Text;

namespace WritingGit.App.Models
{
    public enum MenuItemType
    {
        Landing,
        Browse,
        About,
        Git
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
