using CaisseGenclik.ViewModels;
using System.Windows;

namespace CaisseGenclik.Views
{
    /// <summary>
    /// Interaction logic for CaisseView.xaml
    /// </summary>
    public partial class CaisseView : Window
    {
        public CaisseView()
        {
            InitializeComponent();
            DataContext = new CaisseViewModel();
        }
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact : sva.records.o@gmail.com", "À propos", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}