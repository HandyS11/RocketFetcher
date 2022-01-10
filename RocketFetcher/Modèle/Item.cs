using System;
using System.Runtime.Serialization;

namespace Modèle
{
    /// <summary>
    /// Item est la classe la plus basse et représente un item de RocketLeague 
    /// </summary>
    [DataContract]
    public class Item : IEquatable<Item>
    {
        /// <summary>
        /// Nom de l'item
        /// </summary>
        [DataMember]
        public string Name { get; private set; }


        /// <summary>
        /// Rareté de l'item
        /// </summary>
        [DataMember]
        public string Rarity { get; private set; }


        /// <summary>
        /// Type de l'item
        /// </summary>
        [DataMember]
        public string Type { get; private set; }


        /// <summary>
        /// Certification de l'item
        /// </summary>
        [DataMember]
        public string Certification { get; private set; }


        /// <summary>
        /// Série de l'item
        /// </summary>
        [DataMember]
        public string Serie { get; private set; }


        /// <summary>
        /// Date de sortie de l'item
        /// </summary>
        [DataMember]
        public DateTime ReleaseDate { get; private set; }


        /// <summary>
        /// Couleur de l'item
        /// </summary>
        [DataMember]
        public string Color { get; private set; }


        /// <summary>
        /// Dit si l'item est échangeable
        /// </summary>
        [DataMember]
        public bool IsPaintable { get; private set; }


        /// <summary>
        /// Dit si l'item est Certifiable
        /// </summary>
        [DataMember]
        public bool IsCertifiable { get; private set; }


        /// <summary>
        /// Dit si l'item à un Blueprint
        /// </summary>
        [DataMember]
        public bool HasBlueprint { get; private set; }


        /// <summary>
        /// Donne le Prix de l'item
        /// </summary>
        [DataMember]
        public int Price { get; private set; }


        /// <summary>
        /// Path de l'image
        /// </summary>
        [DataMember]
        public string ImagePath { get; private set; }


        /// <summary>
        /// Constructeur d'un item
        /// </summary>
        /// <param name="Name">Nom de l'Item</param>
        /// <param name="Rarity">Rareté</param>
        /// <param name="Type">Type</param>
        /// <param name="Serie">Série</param>
        /// <param name="ReleaseDate">Date de sortie</param>
        /// <param name="Color">Couleur </param>
        /// <param name="IsPaintable">Peut être coloré ?</param>
        /// <param name="IsCertifiable">Peut être certifié ?</param>
        /// <param name="HasBlueprint">Possède un blueprint ?</param>
        /// <param name="Price">Prix</param>
        /// <param name="Certifications">Certification </param>
        public Item(string name, string rarity, string type, string certification, string serie, DateTime releaseDate, string color, bool isPaintable, bool isCertifiable, bool hasBlueprint, int price, string imagepath)
        {
            if (name != null && serie != null && releaseDate != null)
            {
                Name = name;
                Rarity = rarity.ToString();
                Type = type.ToString();
                Certification = certification.ToString();
                Serie = serie;
                ReleaseDate = releaseDate;
                Color = color.ToString();
                IsPaintable = isPaintable;
                IsCertifiable = isCertifiable;
                HasBlueprint = hasBlueprint;
                Price = price;
                ImagePath = imagepath;
            }
        }


        /// <summary>
        /// Méthode equals pour vérifier si l'objet en tant que tel vaut l'objet avec lequel on appelle la méthode
        /// </summary>
        /// <param name="obj"> Objet a comparer </param>
        /// <returns> un appel à la bonne fonction ou faux </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!GetType().Equals(obj.GetType())) return false;

            return Equals(obj as Item); ///appel au equals approprié
        }


        /// <summary>
        /// Méthode equals pour vérifier si 2 Items sont les mêmes
        /// </summary>
        /// <param name="other"> autre item </param>
        /// <returns> un boolean en fonction de si ils sont égaux ou non</returns>
        public bool Equals(Item other)
        {
            return Name.Equals(other.Name) && Rarity.Equals(other.Rarity) && Type.Equals(other.Type) && Serie.Equals(other.Serie); /// on vérifie que chaque valeur voule vaut celle e l'autre item
        }


        /// <summary>
        /// Méthode qui calcule et renvoie l'Hashcode d'un Item
        /// </summary>
        /// <returns> le hashcode </returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();///hashcode
        }


        /// <summary>
        /// ToString qui donne les généralités d'un Item
        /// </summary>
        /// <returns> le tostring </returns>
        public override string ToString()
        {
            return $" Name:{Name}\n Rarity:{Rarity}\n Type:{Type} \n Certification: {Certification}\n Serie:{Serie}\n Release Date:{ReleaseDate.ToShortDateString()}\n Color:{Color}\n Paintable:{IsPaintable}\n Cerifiable:{IsCertifiable}\n Blueprint:{HasBlueprint}\n Price:{Price}\n";/// affichage des informations d'un item
        }
    }
}
