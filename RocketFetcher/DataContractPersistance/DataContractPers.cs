using Modèle;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContractPersistance
{
    /// <summary>
    /// Classe permettant la persistance de données en XML
    /// </summary>
    public class DataContractPers : IPersistanceManager
    {
        /// <summary>
        /// Propriété calculée : Chemin du fichier à utiliser
        /// </summary>
        public string FilePath => Path.Combine(Directory.GetCurrentDirectory(), RelativePath);


        /// <summary>
        /// Chemin relatif 
        /// </summary>
        public string RelativePath { get; set; } = "XML";        // "..//..//XML"  


        /// <summary>
        /// Nom du fichier
        /// </summary>
        public string FileName { get; set; } = "RocketFetcherData.xml";


        /// <summary>
        /// Serializer : ce qui nous permet d'enregistrer ou de lire
        /// </summary>
        /// 
        protected XmlObjectSerializer Serializer { get; set; } = new DataContractSerializer(typeof(DataToPersist),
                                                                 new DataContractSerializerSettings()
                                                                 {
                                                                 PreserveObjectReferences = true
                                                                 });


        /// <summary>
        /// propriété calculée : Chemin du fichier et son nom
        /// </summary>
        protected string PersFile => Path.Combine(FilePath, FileName);


        /// <summary>
        /// Méthode qui permet de charger les données (IEnumerable de Item, Set et Compte) d'un fichier XML et de les renvoyer
        /// </summary>
        /// <returns></returns>
        public virtual (IEnumerable<Item> items, IEnumerable<Set> sets, IEnumerable<Compte> comptes, bool RememberMe, string RememberLogin) ChargeDonnées()
        {
            if (!File.Exists(PersFile))
            {
                Debug.Write("Seems like the file is missing");
            }

            DataToPersist data;
            using (Stream s = File.OpenRead(PersFile))
            {
                data = Serializer.ReadObject(s) as DataToPersist;
            }
            return (data.items, data.sets, data.comptes, data.RememberMe, data.RememberLogin);   ///On return les données voulues
        }


        /// <summary>
        /// Méthode pour sauvegarder les données passés en paramètre dans un fichier XML
        /// </summary>
        /// <param name="items"></param>
        /// <param name="sets"></param>
        /// <param name="comptes"></param>
        public virtual void SauvegarderDonnées(IEnumerable<Item> items, IEnumerable<Set> sets, IEnumerable<Compte> comptes, bool rememberMe, string rememberLogin)
        {
            if (!Directory.Exists(FilePath))
            {
                Debug.WriteLine("||||Doesn't exists||||");
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new DataToPersist();
            data.items.AddRange(items);
            data.sets.AddRange(sets);
            data.comptes.AddRange(comptes);
            data.RememberMe = rememberMe;
            data.RememberLogin = rememberLogin;

            var settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, data);
                }
            }
        }
    }
}