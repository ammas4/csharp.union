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
using GraphApp.Model;
using GraphApp.ViewModel.Abstract;

namespace GraphApp.CustomControls
{
    /// <summary>
    /// Interaction logic for UserTestControl.xaml
    /// </summary>
    public partial class UserTestControl : NotifyPropertyChangedUserControl
    {
        public UserTestControl()
        {
            InitializeComponent();
            DataContextChanged += UserTestControl_DataContextChanged;
        }

        private void UserTestControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _model = (IMainWindowModel)e.NewValue;
        }

        public string Text1 { get => _model?.Text; set { if (_model != null) { _model.Text = value; base.NotifyPropertyChanged(); } } }

        IMainWindowModel _model;
    }
}
