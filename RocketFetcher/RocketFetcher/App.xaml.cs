using DataContractPersistance;
using Modèle;
using StubLib;
using System.Windows;

namespace RocketFetcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager m = new Manager(new DataContractPers());
        //public Manager m = new Manager(new DataContractPersJSON());
        //public Manager m = new Manager(new Stub());

        public App()
        {
            m.ChargeDonnées();      // Chargement des données en mémoire.

            //m.Persistance = new DataContractPers();
            //m.Persistance = new DataContractPersJSON();

            //m.SauvegardeDonnées();
        }
    }
}