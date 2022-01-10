using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace Modèle
{
    /// <summary>
    /// Classe Haute qui permet de posséder un compte qu iregroupe des sets
    /// </summary>
    [DataContract]
    public class Compte : CompteGuest, IEquatable<Compte>
    {
        /// <summary>
        /// Liste qui va contenir la liste des sets
        /// </summary>
        public ReadOnlyCollection<Set> Sets
        {
            get;
            private set;
        }
        [DataMember]
        List<Set> sets = new List<Set>();


        [OnDeserialized]
        void InitReadOnlyCollection(StreamingContext sc = new StreamingContext())
        {
            Sets = new ReadOnlyCollection<Set>(sets);
        }


        /// <summary>
        /// Mot de Passe de l'utilisateur
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            private set
            {
                if (value != null)
                {
                    password = value;
                }
            }
        }
        [DataMember]
        private string password;


        /// <summary>
        /// Email de l'utilisateur
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            private set
            {
                if (value != null)
                {
                    email = value;
                }
                else throw new ArgumentNullException("NUL");
            }
        }
        [DataMember]
        private string email;


        /// <summary>
        /// Image de l'utilisateur
        /// </summary>
        public string Image
        {
            get
            {
                return image;
            }
            private set
            {
                if (value != null)
                {
                    image = value;
                }
                else throw new ArgumentNullException("NUL");
            }
        }
        [DataMember]
        private string image;


        /// <summary>
        /// Constructeur de compte
        /// </summary>
        /// <param name="Login"> Pseudo du compte</param>
        /// <param name="Password">Mot de passe du compte</param>
        /// <param name="Email">Email du compte</param>
        /// <param name="Image">Image du compte </param>
        public Compte(string log, string pass, string em, string img)
        {
            Login = log;
            Password = pass;
            Email = em;
            SetActif = new Set("Set Actif");
            Image = img;
            InitReadOnlyCollection();
        }


        /// <summary>
        /// ToString qui décrit le compte de l'utilisateur (ses informations )
        /// </summary>
        /// <returns> le tostring </returns>
        public override string ToString()
        {
            string message2 = "";
            if (Sets.Count() > 0)
            {
                foreach (Set set in Sets)
                {
                    message2 = $" {message2} {set.ToString()}\n";
                }
                return $"------------------------------\n Compte de {Login}, son email est : {Email} et son mot de passe est {Password} \n\n Sa liste de Sets :{message2}\n------------------------------\n\n ";
            }
            return $"----------\n Compte de {Login}, son email est : {Email} et son mot de passe est {Password}\n----------\n\n  "; /// Return du ToString
        }


        /// <summary>
        /// Méthode pour ajouter un Set à la liste de Set
        /// </summary>
        /// <param name="set"> le set à ajouter</param>
        public void CompteAdd(Set set)
        {
            if (sets.Contains(set))
            {
                Debug.WriteLine("Already exists");
                return; ///Il existe déja donc on ne l'ajoutera pas
            }
            else sets.Add(set);
        }


        /// <summary>
        /// Méthode qui permet de supprimer un set depuis un compte si le compte contient ce set
        /// </summary>
        /// <param name="set"> le set à supprimer </param>
        /// <param name="compte"> le compte </param>
        public void DeleteSetFromCompte(Set set, Compte compte)
        {
            if (compte.Sets.Contains(set))
            {
                compte.sets.Remove(set);
            }
        }


        /// <summary>
        ///  Méthode pour pouvoir appeller la fonction NumSet (avec un private set pour NumSet) dans Compte
        /// </summary>
        /// <param name="numSet"> numéro du set</param>
        /// <param name="set"> le set </param>
        public void CompteSetNumSet(Set set, int numSet) //// Content :)
        {
            set.SetNumSet(set, numSet, sets);
            List<Set> util = new List<Set>();
            util.AddRange(Sets.OrderBy(s => s.NumSet));
            sets = util;

            Sets = new ReadOnlyCollection<Set>(sets);
        }


        /// <summary>
        /// Méthodes Equals pour comparer deux objets en tant que tel puis en tant que Compte
        /// </summary>
        /// <param name="obj"> l'objet a comparer </param>
        /// <returns> l'appel à la bonne fonction ou faux</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!GetType().Equals(obj.GetType())) return false;

            return Equals(obj as Compte);
        }


        /// <summary>
        /// Méthode equals qui compare deux comptes
        /// </summary>
        /// <param name="other"> l'autre compte </param>
        /// <returns> un bool pour si les deux sont égaux ou non</returns>
        public bool Equals(Compte other)
        {
            return this.Equals(other.Login) && this.Equals(other.Email);
        }


        /// <summary>
        ///  Le GetHashCode
        /// </summary>
        /// <returns> le hashcode</returns>
        public override int GetHashCode()
        {
            return Login.GetHashCode() + Password.GetHashCode() + Email.GetHashCode();
        }
    }
}