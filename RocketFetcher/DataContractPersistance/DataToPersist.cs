using Modèle;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContractPersistance
{
    /// <summary>
    /// Classe utilitaire pour éviter de surcharger la persistance
    /// </summary>
    [DataContract]
    public class DataToPersist
    {
        [DataMember]
        public List<Item> items { get; set; } = new List<Item>();
        [DataMember]
        public List<Set> sets { get; set; } = new List<Set>();
        [DataMember]
        public List<Compte> comptes { get; set; } = new List<Compte>();

        [DataMember]
        public bool RememberMe { get; set; }
        [DataMember]
        public string RememberLogin { get; set; }
    }
}
