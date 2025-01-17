﻿using CaisseGenclik.Others;
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
            ConnexionCommand = new RelayCommand(Connexion);
        }

        private void Connexion(object parameter)
        {
            // Vérifiez si le nom d'utilisateur et le mot de passe sont corrects
            if (NomUtilisateur == "Ad" && MotDePasse == "17")
            {
                // Connexion réussie, passez à l'écran "Caisse"
                var caisse = new CaisseViewModel();
                var viewCaisse = new CaisseView();
                viewCaisse.Show();
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
