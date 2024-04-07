using CaisseGenclik.Models;
using CaisseGenclik.Others;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaisseGenclik.ViewModels
{
    public class ArticlesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Article> Articles { get; set; }
        public ICommand AjouterArticleCommand { get; }

        public ArticlesViewModel()
        {
            // Initialisez vos articles ici
            Articles = new ObservableCollection<Article>
            {
                new Article { Nom = "Cay", Prix = 2.50, ImagePath = "CheminVersImageCay.jpg" },
                // Ajoutez d'autres articles ici
            };

            AjouterArticleCommand = new DelegateCommand((a) => AjouterArticle());

        }

        private void AjouterArticle()
        {
            //Article article = parameter as Article;
            // Ajoutez la logique pour ajouter l'article à la facture
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}