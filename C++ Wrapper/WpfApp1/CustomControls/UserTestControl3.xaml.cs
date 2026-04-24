using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace GraphApp.CustomControls
{
    /// <summary>
    /// Interaction logic for UserTestControl3.xaml
    /// </summary>
    public partial class UserTestControl3 : UserControl, INotifyPropertyChanged
    {
        public UserTestControl3(/*IMainViewModel model*/)
        {
            InitializeComponent();
            DataContext = this;
            //_model = model;
        }

        //IMainViewModel _model;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        string _Text1;
        public string Text1 { get => _Text1; set { _Text1 = value; NotifyPropertyChanged(); } }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //_model.Text1Change();
        }
    }
}
