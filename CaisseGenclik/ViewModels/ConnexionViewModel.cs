using CaisseGenclik.Others;
using CaisseGenclik.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CaisseGenclik.ViewModels
{
    public class ConnexionViewModel : INotifyPropertyChanged
    {
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }
        public ICommand ConnexionCommand { get; }

        public ConnexionViewModel()
        {
            ConnexionCommand = new DelegateCommand((a) => Connexion());
        }

        private void Connexion()
        {
            // Vérifiez si le nom d'utilisateur et le mot de passe sont corrects
            if (NomUtilisateur == "admin" && MotDePasse == "itix")
            {
                // Connexion réussie, passez à l'écran "Caisse"
                var caisse = new CaisseViewModel();
                var viewCaisse = new CaisseView();
                viewCaisse.Show();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = viewCaisse;
            }
            else
            {
                // Affichez un message d'erreur
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
