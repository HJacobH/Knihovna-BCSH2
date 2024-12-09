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
    /// Interaction logic for VypujceniView.xaml
    /// </summary>
    public partial class VypujceniView : Window
    {
        private readonly VypujceniViewModel _viewModel;
        public VypujceniView()
        {
            InitializeComponent();
            _viewModel = new VypujceniViewModel();
            this.DataContext = _viewModel;

            this.Closed += (s, e) => _viewModel.Dispose();
        }
    }
}
