using DataContractPersistance;
using Modèle;
using StubLib;
using System;

namespace Test_PersJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager(new Stub());
            m.ChargeDonnées();

            foreach (var v in m.AllComptes)
            {
                Console.WriteLine(v.ToString());
            }

            m.Persistance = new DataContractPersJSON();
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