using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace Modèle
{
    /// <summary>
    /// Variable globale TAILLEMAX
    /// </summary>
    static class TMAX
    {
        public static int TAILLEMAX = 14; /// Soit le nombre de spécifications (en vrai 10 mais on fait genre)
    }


    /// <summary>
    /// Classe Set qui permettra de regrouper des Items selon les choix de l'utilisateur et des restrictions imposées
    /// </summary>
    [DataContract]
    public class Set : IEquatable<Set>
    {
        /// <summary>
        /// Numéro du Set
        /// </summary>
        [DataMember]
        public int NumSet { get; private set; } = 0;


        /// <summary>
        /// Nom du Set
        /// </summary>
        [DataMember]
        public string Name { get; private set; }


        /// <summary>
        /// On utilise un Dictionnaire d'Items et un int pour la valeur de l'item dans le set (entre  et TAILLEMAX)
        /// </summary>
        [OnDeserialized]
        void InitReadOnlyDictionnary(StreamingContext sc = new StreamingContext())
        {
            SetItems = new ReadOnlyDictionary<Item, int>(setItems);
        }


        /// <summary>
        /// Dictionnaire permettant de stocker des Item associés a des int
        /// </summary>
        public ReadOnlyDictionary<Item, int> SetItems
        {
            get;
            private set;
        }
        [DataMember]
        Dictionary<Item, int> setItems = new Dictionary<Item, int>();


        /// <summary>
        /// Constructeur d'un Set
        /// </summary>
        /// <param name="Name">Nom du set</param>
        public Set(string name)
        {
            Name = name;
            InitReadOnlyDictionnary();

            this.NumSet = NumSet;
        }


        /// <summary>
        /// Méthode qui permet de supprimer un item d'un set s'il y est contenu
        /// </summary>
        /// <param name="set"> set ou supprimer l'item</param>
        /// <param name="item"> item a supprimer </param>
        public void DeleteItemFromSet(Set set, Item item)
        {
            if (set.SetItems.ContainsKey(item))
            {
                setItems.Remove(item);
            }
        }


        /// <summary>
        /// On écrit SetNumSet ici pour puvoir l'appeller dans Compte
        /// </summary>
        /// <param name="set"> set a modifier</param>
        /// <param name="numSet"> numéro a attribuer</param>
        /// <param name="Sets"> liste de sets</param>
        public void SetNumSet(Set set, int numSet, IEnumerable<Set> Sets) //// Pour dans une liste
        {
            IEnumerable<Set> test = Sets.Where(s => s.NumSet == numSet); ///Avec LINQ on cherche si le NumSet existe déja

            if (test.Count() > 0) ///On vérifie que le compte vaut 0 sinon ça veut dire qu'il existe déja
            {
                Debug.WriteLine("This Num is already assigned");
                return;/// On return car in obtiens une réponse qui rends impossible le changement
            }
            else
            {
                set.NumSet = numSet; /// On applique le changement
            }
        }


        /// <summary>
        /// Equals qui permet de vérifier si l'objet est le même que le set avec lequel on appelle la fonction
        /// </summary>
        /// <param name="obj"> objet à comparer</param>
        /// <returns> l'appel à la bonne fonction ou faux</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!GetType().Equals(obj.GetType())) return false;

            return Equals(obj as Set); /// Appel au equals spécialisé
        }


        /// <summary>
        /// Méthode pour comparer deux sets (s'ils sont égaux) , s'ils possèdent le même nom et le même nombre d'éléments
        /// </summary>
        /// <param name="other"> autre set</param>
        /// <returns> si ils sont égaux</returns>
        public bool Equals(Set other)
        {
            return NumSet.Equals(other.NumSet) && Name.Equals(other.Name); /// On vérifie l'égalité des paramètres, si un seul est faux le tout vaudra faux
        }


        /// <summary>
        /// Hashcode d'un Set
        /// </summary>
        /// <returns> le hashcode </returns>
        public override int GetHashCode()
        {
            return NumSet.GetHashCode() + Name.GetHashCode(); ///Hashcode
        }


        /// <summary>
        /// Description de ce que contient le Set
        /// </summary>
        /// <returns> le tostring </returns>
        public override string ToString()
        {
            string message = "";

            if (SetItems == null)
            {
                Debug.WriteLine("Alors, c'est compliqué car ton truc là, ton dico bah il est nul , euh null ");
                return "null";
            }

            foreach (var entry in SetItems)
            {
                message = $"{message} {entry.Key.ToString()}\n"; /// Pour chaque clé de SetItems soit un Item on appelle la fonction ToString de ce dernier et l'ajoute dans le string message
            }

            return $" Nom du Set:{Name}\n Nombre d'éléments du set:{SetItems.Count}\n Numero du Set : {NumSet}\n\n {message}\n\n"; /// Ensuite on utilise message pour énoncer les Items
        }


        /// <summary>
        /// Méthode pour ajouter un Item dans un set
        /// </summary>
        /// <param name="item"> item a ajouter</param>
        /// <param name="Change"> si on veut ou non changer si un item existe déja avec le même type</param>
        public void SetAdd(Item item, bool Change)
        {
            if (SetItems == null)
            {
                Debug.WriteLine("Alors, c'est compliqué car ton truc là, ton dico, bah il est nul , euh null ");
                return; ///On ne peut pas utiliser un dictionnaire null
            }

            if (SetItems.Count == TMAX.TAILLEMAX && Change == false)
            {
                Debug.WriteLine("Limite atteinte");
                return; ///On ne peut rien modifier
            }

            int nbItems = SetItems.Count(kvp => kvp.Key.Type == item.Type);

            if (nbItems == 0)
            {
                setItems.Add(item, 0);
                return;
            }

            if (nbItems > 0 && !Change)
            {
                return; /// On ne modifie rien
            }

            if (nbItems > 0 && Change)
            {
                foreach (var it in SetItems)
                {
                    if (it.Key.Type == item.Type)
                    {
                        int j = it.Value;
                        setItems.Remove(it.Key);
                        setItems.Add(item, j);
                        return;
                    }
                }
            }
        }
    }
}