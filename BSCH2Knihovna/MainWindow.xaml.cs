using BSCH2Knihovna.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BSCH2Knihovna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenKnihaView_Click(object sender, RoutedEventArgs e)
        {
            var knihaview = new KnihaView();
            knihaview.Show();
        }

        private void OpenReadersView_Click(object sender, RoutedEventArgs e)
        {
            //var readersView = new ReadersView();
            //readersView.Show();
        }

        private void OpenBorrowingsView_Click(object sender, RoutedEventArgs e)
        {
            //var borrowingsView = new BorrowingsView();
            //borrowingsView.Show();
        }

        private void OpenSekceView_Click(object sender, RoutedEventArgs e)
        {
            var sekceView = new SekceKnihovny();
            sekceView.Show();
        }

        private void DeleteDatabase_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete the entire database? This action cannot be undone.",
                                         "Delete Database", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (var repository = new LibraryRepository())
                {
                    repository.DeleteDatabaseFile();
                }

                MessageBox.Show("Database deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}