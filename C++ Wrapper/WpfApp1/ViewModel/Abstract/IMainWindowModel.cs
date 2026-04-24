using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp.ViewModel.Abstract
{
    public interface IMainWindowModel
    {
        int Id { get; set; }
        string Text { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void Text1Change(ref string text);
    }
}
