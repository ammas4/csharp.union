using GraphApp.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp.ViewModel
{
    internal class MainWindowModel : IMainWindowModel, INotifyPropertyChanged
    {
        public MainWindowModel()
        {
        }
        public int Id { get; set; }
        string _Text;
        public string Text { get => _Text; set { _Text = value; NotifyPropertyChanged(nameof(Text)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public void Text1Change(ref string text)
        {
            text += " add";
        }
    }
}
