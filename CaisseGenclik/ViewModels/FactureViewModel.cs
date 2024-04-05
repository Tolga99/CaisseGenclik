using CaisseGenclik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseGenclik.ViewModels
{
    public class FactureViewModel : INotifyPropertyChanged
    {
        public Facture Facture { get; set; }

        public FactureViewModel()
        {
            Facture = new Facture();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // Implémentez les propriétés, commandes et logique nécessaires pour gérer l'écran "Facture"
    }
}