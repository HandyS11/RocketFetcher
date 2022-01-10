using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Modèle
{
    /// <summary>
    /// Classe Manager : Point d'entré principale du sosu système
    /// </summary>
    [DataContract]
    public class Manager : INotifyPropertyChanged
    /// Implémenter interface persistance (voir vidéo cours)
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string property)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));


        /// <summary>
        /// dépendance vers le gestionnaire de persistance
        /// </summary>
        public IPersistanceManager Persistance { get; set; }


        /// <summary>
        /// Listes qui ne servent qu'en interne du manager et qui ont pour seul but d'une fois avoir créé un Set / Item / Compte , l'ajouter pour l'enregistrer plus tard (persistance)
        /// </summary>
        /// 
        [DataMember]
        public ReadOnlyObservableCollection<Item> AllItems { get; set; }
        ObservableCollection<Item> allItems = new ObservableCollection<Item>();
        [DataMember]
        public ReadOnlyObservableCollection<Set> AllSets { get; set; }
        ObservableCollection<Set> allSets = new ObservableCollection<Set>();
        [DataMember]
        public ReadOnlyObservableCollection<Compte> AllComptes { get; set; }
        ObservableCollection<Compte> allComptes = new ObservableCollection<Compte>();

        public Compte SelectedAccount { get; set; }

        public Set SelectedSet
        {
            get => selectedSet;
            set
            {
                if (selectedSet != value)
                {
                    selectedSet = value;
                    OnPropertyChanged(nameof(SelectedSet));
                }
            }
        }
        private Set selectedSet;


        public int SelectedSort { get; set; }

        public string SearchValue { get; set; }

        public int SelectedFetch { get; set; }

        public Item SelectedItem { get; set; }


        [DataMember]
        public bool RememberMe { get; set; } = false;

        [DataMember]
        public string RememberLogin { get; set; } = "";


        public Manager(IPersistanceManager persistance) //// Remplacer par interface persistance IPersistanceManager et paramètre pers
        {
            Persistance = persistance;
            AllItems = new ReadOnlyObservableCollection<Item>(allItems);
            AllSets = new ReadOnlyObservableCollection<Set>(allSets);
            AllComptes = new ReadOnlyObservableCollection<Compte>(allComptes);
        }


        /// <summary>
        /// Méthode qui ajoute un item aux items existants
        /// </summary>
        ///  /// <param name="item"> item à ajouter </param>
        public void AddItem(Item item)
        {
            if (AllItems.Contains(item))
            {
                return;
            }
            allItems.Add(item);
        }


        /// <summary>
        /// Méthode qui permet d'ajouter le set aux sets existants
        /// </summary>
        /// <param name="set"> set à ajouter </param>
        public void AddSet(Set set)
        {
            if (AllSets.Contains(set))
            {
                return;
            }
            allSets.Add(set);
        }


        /// <summary>
        /// Idem pour un compte aux comptes existants
        /// </summary>
        /// <param name="compte"> compte à ajouter </param>
        public void AddCompte(Compte compte)
        {
            if (AllComptes.Contains(compte))
            {
                return;
            }
            allComptes.Add(compte);
        }


        /// <summary>
        /// Méthode de chargement des données
        /// </summary>
        public void ChargeDonnées()
        {
            allItems.Clear();  ///Pour éviter les doublons
            allSets.Clear();
            allComptes.Clear();

            var données = Persistance.ChargeDonnées(); /// <--- dépendance
            foreach (var i in données.items)
            {
                allItems.Add(i);
                //Debug.WriteLine(i.ToString());
            }

            foreach (var j in données.sets)
            {
                allSets.Add(j);
                ///Debug.WriteLine(j.ToString());
            }

            foreach (var k in données.comptes)
            {
                allComptes.Add(k);
                ///Debug.WriteLine(k.ToString());
            }
            RememberMe = données.RememberMe;
            RememberLogin = données.RememberLogin;
        }


        /// <summary>
        /// Méthode qui sauvegarde les données via la persistance
        /// </summary>
        public void SauvegardeDonnées()
        {
            Persistance.SauvegarderDonnées(AllItems, AllSets, AllComptes, RememberMe, RememberLogin); /// <--- dépendance ici aussi
        }


        /// <summary>
        /// Méthode pour détruire un Compte
        /// </summary>
        /// <param name="compte"> compte à supprimer </param>
        /// <returns></returns>
        public void DeleteCompte(Compte compte)
        {
            if (AllComptes.Contains(compte))
            {
                allComptes.Remove(compte);
            }
            else Debug.WriteLine("AllComptes doesn't contain this account, are you sure it exists ?");
        }


        /// <summary>
        /// Méthode pour détruire un Set
        /// </summary>
        /// <param name="set">set à supprimer </param>
        /// <returns></returns>
        public void DeleteSet(Set set, Compte compte, bool Everything) /// 
        {
            if (AllSets.Contains(set))
            {
                allSets.Remove(set);

                if (Everything == true)
                {
                    foreach (Compte c in AllComptes)
                    {
                        if (c.Sets.Contains(set))
                        {
                            c.DeleteSetFromCompte(set, c);
                        }
                    }
                }
                else if (compte.Sets.Contains(set))
                {
                    compte.DeleteSetFromCompte(set, compte);
                }
            }
            else return;
        }


        /// <summary>
        /// M"thode pour détruire un item
        /// </summary>
        /// <param name="item"> item à supprimer </param>
        public void DeleteItem(Item item)
        {
            if (AllItems.Contains(item))
            {
                allItems.Remove(item);

                foreach (Set set in AllSets)
                {
                    if (set.SetItems.ContainsKey(item))
                    {
                        set.DeleteItemFromSet(set, item);
                    }
                }
            }
        }


        /// NOTE : On ne prends pas en compte dans les fonctions suivantes la possibilité qu'ils existent déja car si ils existent déja, il vont être
        /// présents dans la liste correspondante et donc on ne pourra pas les mettre (ce qui inclut donc qu'ils n'auront aucune référence et qu'il finirons
        /// par être détruits)


        /// <summary>
        /// /Méthode pour créer un Set depuis Manager
        /// </summary>
        /// <param name="name"> nom du set à créer</param>
        /// <returns> u nset </returns>
        public Set CreateSet(string name)
        {
            Set set = new Set(name);
            return set;
        }


        /// <summary>
        /// Méthode pour créer un Compte depuis Manager
        /// </summary>
        /// <param name="login"> pseudo du compte</param>
        /// <param name="password"> mot de passe du compte </param>
        /// <param name="email"> email du compte </param>
        /// <returns> un compte </returns>
        public Compte CreateCompte(string login, string password, string email, string image)
        {
            Compte compte = new Compte(login, password, email, image);
            return compte;
        }


        /// <summary>
        /// Méthode pour créer un Item depuis Manager
        /// </summary>
        /// <param name="name"> nom de l'item à créer</param>
        /// <param name="rarity"> sa rareté </param>
        /// <param name="type"> son type </param>
        /// <param name="certification"> sa certifiation</param>
        /// <param name="serie"> sa série </param>
        /// <param name="releaseDate"> sa date de sortie</param>
        /// <param name="color"> sa couleur </param>
        /// <param name="isTradeable"> si il est échangeable </param>
        /// <param name="isCertifiable">si il est certifiable </param>
        /// <param name="hasBlueprint"> si il a un blueprint </param>
        /// <param name="price">son prix</param>
        /// <param name="imagepath"> path de l'image</param>
        /// <returns> un item </returns>
        public Item CreateItem(string name, string rarity, string type, string certification, string serie, DateTime releaseDate, string color, bool isTradeable, bool isCertifiable, bool hasBlueprint, int price, string imagepath)
        {
            Item item = new Item(name, rarity, type, certification, serie, releaseDate, color, isTradeable, isCertifiable, hasBlueprint, price, imagepath);

            return item;
        }
    }
}
