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
        private ObservableCollection<Article> _articlesPanier = new ObservableCollection<Article>();
        public ObservableCollection<Article> ArticlesPanier
        {
            get { return _articlesPanier; }
            set
            {
                _articlesPanier = value;
                OnPropertyChanged(nameof(ArticlesPanier));
                // Mettre à jour le solde du panier lorsque la liste d'articles change
                CalculateSoldePanier();
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
            ArticlesPanier = new ObservableCollection<Article>();
            GenererListeArticles();
            // Initialiser les commandes d'ajout et de retrait
            AjouterCommand = new DelegateCommand((a) => AjouterCommandExecute());
            RetirerCommand = new DelegateCommand((a) => RetirerCommandExecute());

        }
        private void GenererListeArticles()
        {
            // Ajouter les articles à la collection
            ArticlesPanier.Add(new Article { Nom = "Cay", Prix = 0.50 });
            ArticlesPanier.Add(new Article { Nom = "Café", Prix = 1.00 });
            ArticlesPanier.Add(new Article { Nom = "Chips", Prix = 0.80 });
            ArticlesPanier.Add(new Article { Nom = "Toasts au fromage", Prix = 2.00 });
        }

        // Méthode pour ajouter un article au panier
        public void AjouterCommandExecute()
        {
            if (SelectedArticle != null)
            {
                ArticlesPanier.Add(SelectedArticle);
                // Mettre à jour le solde du panier après l'ajout d'un article
                CalculateSoldePanier();
            }
        }

        // Méthode pour retirer un article du panier
        public void RetirerCommandExecute()
        {
            if (SelectedArticle != null)
            {
                ArticlesPanier.Remove(SelectedArticle);
                // Mettre à jour le solde du panier après le retrait d'un article
                CalculateSoldePanier();
            }
        }

        // Méthode pour calculer le solde du panier
        public void CalculateSoldePanier()
        {
            SoldePanier = ArticlesPanier.Sum(article => article.Prix);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}