using System;
using System.Runtime.Serialization;

namespace Modèle
{
    /// <summary>
    /// Une classe permettant la mise en place du mode guest (sans-compte)
    /// </summary>
    [DataContract, KnownType(typeof(Compte))]
    public class CompteGuest : IEquatable<CompteGuest>
    {
        /// <summary>
        /// Identifiant/Pseudo de l'utilisateur
        /// </summary>
        public string Login
        {
            get
            {
                return login;
            }
            protected set
            {
                if (value != null)
                {
                    login = value;
                }
                else throw new ArgumentNullException("NUL");
            }
        }
        [DataMember]
        protected string login;


        [DataMember]
        public Set SetActif { get; set; } = new Set("Set Actif");


        /// <summary>
        /// Constructeur du compte Guest (assez vide en effet)
        /// </summary>
        public CompteGuest()
        {
            Login = "Guest";
        }


        /// <summary>
        /// ToString du compte Guest
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" Compte Guest de {Login}, il disparaitra bientôt dans le vide .... \n";
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!GetType().Equals(obj.GetType())) return false;

            return Equals(obj as CompteGuest); ///appel au equals approprié
        }


        public bool Equals(CompteGuest other)
        {
            return this.Equals(other.Login); ///On return le login pour le equals bien que chaque compte de guest est le même
        }


        public override int GetHashCode()
        {
            return Login.GetHashCode(); ///On aura le même hashcode pour chaque compteguest
        }
    }
}
