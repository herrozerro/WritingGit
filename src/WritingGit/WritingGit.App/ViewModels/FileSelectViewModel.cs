using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace WritingGit.App.ViewModels
{
    public class FileSelectViewModel : BaseViewModel
    {
        public ObservableCollection<string> Files;
        public Command LoadFilesCommand { get; set; }

        public FileSelectViewModel()
        {
            Title = "Files";
            Files = new ObservableCollection<string>();
        }
    }
}
