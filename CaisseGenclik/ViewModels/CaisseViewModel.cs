using CaisseGenclik.Models;
using CaisseGenclik.Others;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CaisseGenclik.ViewModels
{
    public class CaisseViewModel : INotifyPropertyChanged
    {
        private Article _selectedArticle;
        public Article SelectedArticle
        {
            get { return _selectedArticle; }
            set
            {
                if (_selectedArticle != value)
                {
                    _selectedArticle = value;
                    OnPropertyChanged(nameof(SelectedArticle));
                }
            }
        }
        private ObservableCollection<Article> _panier = new ObservableCollection<Article>();
        public ObservableCollection<Article> Panier
        {
            get { return _panier; }
            set
            {
                _panier = value;
                OnPropertyChanged(nameof(Panier));
                // Mettre à jour le solde du panier lorsque la liste d'articles change
                CalculateSoldePanier();
            }
        }
        private ObservableCollection<Article> _stockArticles = new ObservableCollection<Article>();
        public ObservableCollection<Article> StockArticles
        {
            get { return _stockArticles; }
            set
            {
                _stockArticles = value;
                OnPropertyChanged(nameof(StockArticles));
            }
        }
        private double _soldePanier;
        public double SoldePanier
        {
            get { return _soldePanier; }
            set
            {
                _soldePanier = value;
                OnPropertyChanged(nameof(SoldePanier));
            }
        }
        public ICommand AjouterCommand { get; }
        public ICommand RetirerCommand { get; }

        public CaisseViewModel()
        {
            // Initialiser la collection d'articles
            StockArticles = new ObservableCollection<Article>();
            GenererListeArticles();
            // Initialiser les commandes d'ajout et de retrait
            AjouterCommand = new DelegateCommand((a) => AjouterCommandExecute());
            RetirerCommand = new DelegateCommand((a) => RetirerCommandExecute());

        }
        private void GenererListeArticles()
        {
            // Ajouter les articles à la collection
            StockArticles.Add(new Article {Id = 1, Nom = "Cay", Prix = 0.50 });
            StockArticles.Add(new Article {Id = 2, Nom = "Café", Prix = 1.00 });
            StockArticles.Add(new Article {Id = 3, Nom = "Chips", Prix = 0.80 });
            StockArticles.Add(new Article {Id = 4, Nom = "Toasts au fromage", Prix = 2.00 });
        }

        // Méthode pour ajouter un article au panier
        private void AjouterCommandExecute()
        {
            if (SelectedArticle != null)
            {
                Panier.Add(SelectedArticle);
                // Mettre à jour le solde du panier après l'ajout d'un article
                CalculateSoldePanier();
            }
        }

        // Méthode pour retirer un article du panier
        private void RetirerCommandExecute()
        {
            if (SelectedArticle != null)
            {
                Panier.Remove(SelectedArticle);
                // Mettre à jour le solde du panier après le retrait d'un article
                CalculateSoldePanier();
            }
        }

        // Méthode pour calculer le solde du panier
        public void CalculateSoldePanier()
        {
            SoldePanier = Panier.Sum(article => article.Prix);
        }
        public void OnArticleSelected(Article selectedArticle)
        {
            SelectedArticle = selectedArticle;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}