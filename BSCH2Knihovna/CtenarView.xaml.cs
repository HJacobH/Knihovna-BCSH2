using BSCH2Knihovna.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BSCH2Knihovna
{
    /// <summary>
    /// Interaction logic for CtenarView.xaml
    /// </summary>
    public partial class CtenarView : Window
    {
        private readonly CtenarViewModel _viewModel;
        public CtenarView()
        {
            InitializeComponent();
            _viewModel = new CtenarViewModel();
            DataContext = _viewModel;
            this.Closed += (s, e) => _viewModel.Dispose();
        }
    }
}
