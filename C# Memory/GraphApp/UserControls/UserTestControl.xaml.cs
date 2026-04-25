using GraphApp.Model;
using GraphApp.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphApp.UserControls
{
    /// <summary>
    /// Interaction logic for UserTestControl.xaml
    /// </summary>
    public partial class UserTestControl : UserControl, INotifyPropertyChanged
    {
        public UserTestControl()
        {
            InitializeComponent();
        }
        IMainWindowModel _model;


        string _textLocal;
        public string TextLocal { get => _textLocal; set { _textLocal = value; NotifyPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _ = DataContext as IMainWindowModel;
        }
    }
}
