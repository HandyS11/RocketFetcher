using Modèle;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DataContractPersistance
{
    /// <summary>
    /// Classe permettant la persistance des données en JSON
    /// </summary>
    public class DataContractPersJSON : DataContractPers
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public DataContractPersJSON()
        {
            RelativePath = "JSON";          // "..//..//JSON"
            FileName = "RocketFetcherData.json";
            Serializer = new DataContractJsonSerializer(typeof(DataToPersist));
        }


        /// <summary>
        /// /Méthode pour sauvegarder, dans un fichier json, les données fournies en paramètre
        /// </summary>
        /// <param name="items"></param>
        /// <param name="sets"></param>
        /// <param name="comptes"></param>
        public override void SauvegarderDonnées(IEnumerable<Item> items, IEnumerable<Set> sets, IEnumerable<Compte> comptes, bool rememberMe, string rememberLogin)
        {
            if (!Directory.Exists(FilePath))
            {
                Debug.WriteLine("|||| Doesn't exists||||");
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new DataToPersist();
            data.items.AddRange(items);
            data.sets.AddRange(sets);
            data.comptes.AddRange(comptes);
            data.RememberMe = rememberMe;
            data.RememberLogin = rememberLogin;

            using (Stream writer = File.Create(PersFile))
            {
                Serializer.WriteObject(writer, data);
            }
        }
    }
}
