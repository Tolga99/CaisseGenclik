using CaisseGenclik.Models;
using CaisseGenclik.Others;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

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

        private string _printPanier;
        public string PrintPanier
        {
            get
            {
                return _printPanier;
            }
            set
            {
                _printPanier = value;
                OnPropertyChanged(nameof(PrintPanier));
            }
        }
        public ICommand AjouterCommand { get; }
        public ICommand RetirerCommand { get; }

        // Propriété pour la commande de clôture du panier
        public ICommand CloturerPanierCommand { get; }

        public CaisseViewModel()
        {
            // Initialiser la collection d'articles
            StockArticles = new ObservableCollection<Article>();
            GenererListeArticles();
            // Initialiser les commandes d'ajout et de retrait
            AjouterCommand = new DelegateCommand((a) => AjouterCommandExecute());
            RetirerCommand = new DelegateCommand((a) => RetirerCommandExecute());
            CloturerPanierCommand = new DelegateCommand((a) => CloturerPanier());

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
                PanierToString();
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
                PanierToString();
                // Mettre à jour le solde du panier après le retrait d'un article
                CalculateSoldePanier();
            }
        }
        public string PanierToString()
        {
            StringBuilder contenuPanier = new StringBuilder();

            foreach (Article article in Panier.Distinct())
            {
                contenuPanier.AppendLine($"{Panier.Where(a => a.Nom == article.Nom).Count()}x {article.Nom} (unit. {article.Prix} €) => {Panier.Where(a => a.Nom == article.Nom).Count() * article.Prix} €");
            }

            contenuPanier.AppendLine($"Total : {SoldePanier} €");

            return PrintPanier = contenuPanier.ToString();
        }
        // Méthode pour clôturer le panier
        public void CloturerPanier()
        {
            // Obtenir la date actuelle
            DateTime dateCloture = DateTime.Now;

            // Créer le nom de fichier à partir de la date de clôture
            string nomFichierBase = dateCloture.ToString("dd-MM-yyyy");
            string nomFichier = nomFichierBase + ".txt";
            int iteration = 1;

            // Vérifier si un fichier avec le même nom existe déjà
            while (File.Exists(nomFichier))
            {
                // Incrémenter l'itération et générer un nouveau nom de fichier
                nomFichier = $"{nomFichierBase}_{iteration}.txt";
                iteration++;
            }

            // Obtenir le contenu du panier sous forme de chaîne de caractères
            string contenuPanier = PanierToString();

            // Afficher un message de confirmation avant de clôturer le panier
            //MessageBoxResult result = MessageBox.Show($"Êtes-vous sûr de vouloir clôturer le panier ?\n\nLe contenu du panier sera enregistré dans le fichier {nomFichier}.", "Confirmation de clôture", MessageBoxButton.YesNo, MessageBoxImage.Question);
            MessageBoxResult result = MessageBox.Show($"Confirmez-vous la clôture du panier avec un solde de {SoldePanier} € ?\n\n{contenuPanier}", "Confirmation de clôture", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // Vérifier si l'utilisateur a confirmé la clôture du panier
            if (result == MessageBoxResult.Yes)
            {
                // Écrire le contenu du panier dans un fichier texte
                File.WriteAllText(nomFichier, contenuPanier);

                // Afficher un message de confirmation après la clôture du panier
                MessageBox.Show($"Le panier a été clôturé et enregistré dans le fichier {nomFichier}.", "Confirmation de clôture", MessageBoxButton.OK, MessageBoxImage.Information);

                // Réinitialiser le panier après la clôture
                Panier.Clear();
                SoldePanier = 0;
                PrintPanier = String.Empty;
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