using DataContractPersistance;
using Modèle;
using StubLib;
using System;

namespace Test_PersXML
{
    class Program
    {
        static void Main(string[] args) //// MARCHE ENFIN LDSKDOQSKOQOFKOQFKOQSFOQO
        {
            Manager m = new Manager(new Stub());
            m.ChargeDonnées();

            foreach (var v in m.AllComptes)
            {
                Console.WriteLine(v.ToString());
            }

            Console.WriteLine("On vérifie que le chargement ne charge pas en double si on charge plusieurs fois");
            m.ChargeDonnées();

            foreach (var v in m.AllComptes)
            {
                Console.WriteLine(v.ToString());
            }

            Console.WriteLine("Réponse ??? (En effet) \n \n \n \n");
            ///Manager m2 = new Manager(new DataContractPers());

            ///m2.AllItems = m.AllItems;
            ///m2.AllComptes = m.AllComptes;
            ///m2.AllSets = m.AllSets;
            m.Persistance = new DataContractPers();
            m.SauvegardeDonnées();
            m.ChargeDonnées();
            Console.WriteLine("Presque Fini");

            foreach (var v in m.AllComptes)
            {
                Console.WriteLine(v.ToString());
            }
            Console.WriteLine("Fini");
        }
    }
}