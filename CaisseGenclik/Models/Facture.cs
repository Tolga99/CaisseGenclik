using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseGenclik.Models
{
    public class Facture
    {
        public List<Article> ListeArticles { get; set; }
        public decimal Total { get; set; }

        public Facture()
        {
            ListeArticles = new List<Article>();
            Total = 0;
        }
    }
}
