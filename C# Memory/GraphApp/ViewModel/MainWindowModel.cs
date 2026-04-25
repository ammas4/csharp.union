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
        string _textCommon;
        public string TextCommon { get => _textCommon; set { _textCommon = value; NotifyPropertyChanged(); } }

        List<string> _textsCommon = new List<string>(16);
        public List<string> TextsCommon { get => _textsCommon; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
