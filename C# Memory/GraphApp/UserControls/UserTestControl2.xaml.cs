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

namespace GraphApp.UserControls
{
    /// <summary>
    /// Interaction logic for UserTestControl2.xaml
    /// </summary>
    public partial class UserTestControl2 : NotifyPropertyChangedUserControl
    {
        public UserTestControl2()
        {
            InitializeComponent();
        }

        IMainWindowModel _model;
    }
}
