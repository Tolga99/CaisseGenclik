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
    /// Interaction logic for FactureView.xaml
    /// </summary>
    public partial class FactureView : Window
    {
        public FactureView()
        {
            InitializeComponent();
            DataContext = new FactureViewModel();
        }
    }
}
