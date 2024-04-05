using CaisseGenclik.Others;
using CaisseGenclik.ViewModels;
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

namespace CaisseGenclik.Views
{
    /// <summary>
    /// Interaction logic for ConnexionView.xaml
    /// </summary>
    public partial class ConnexionView : Window
    {
        public ConnexionView()
        {
            InitializeComponent();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact : sva.records.o@gmail.com", "À propos", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}