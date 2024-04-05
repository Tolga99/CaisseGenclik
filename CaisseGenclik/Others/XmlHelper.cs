using CaisseGenclik.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CaisseGenclik.Others
{
    public static class XmlHelper
    {
        public static List<Article> ChargerArticlesDepuisXml(string cheminFichier)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Article>));
            using (FileStream fileStream = new FileStream(cheminFichier, FileMode.Open))
            {
                return (List<Article>)serializer.Deserialize(fileStream);
            }
        }
    }
}