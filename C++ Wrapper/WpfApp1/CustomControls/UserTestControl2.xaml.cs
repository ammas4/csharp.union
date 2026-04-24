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

namespace GraphApp.CustomControls
{
    /// <summary>
    /// Interaction logic for UserTestControl2.xaml
    /// </summary>
    public partial class UserTestControl2 : UserControl, INotifyPropertyChanged
    {
        public UserTestControl2()
        {
            DataContextChanged += UserTestControl2_DataContextChanged;
            InitializeComponent();
        }
        private void UserTestControl2_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _model = (IMainWindowModel)e.NewValue;
        }

        IMainWindowModel _model;
        string _Text1;
        public string Text1 { get => _Text1; set { _Text1 = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var _ = (IMainWindowModel)DataContext;
            _model.Text = Text1;
            //_label.Content = Text1;
            ////_model.SecondVM.Label = _Text1;
            //VLabel.Content = _Text1;
        }
    }
}
