using Modèle;
using System;

namespace Test_Set
{
    class Program /// FONCTIONNE 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de Sets \n");

            Set MonSet = new Set("MonSet");

            Item item1 = new Item("Test", Rarity.Common.ToString(), Specification.Wheels.ToString(), Certification.Victor.ToString(), "Test", new DateTime(2022, 2, 1), Color.Cobalt.ToString(), true, true, false, 125, "Path");
            Item item2 = new Item("Test2", Rarity.Rare.ToString(), Specification.Antennas.ToString(), Certification.Victor.ToString(), "Test2", new DateTime(2022, 2, 1), Color.Crimson.ToString(), true, false, true, 155, "Path");

            MonSet.SetAdd(item1, true);
            MonSet.SetAdd(item2, true);

            Console.Write(MonSet.ToString());
        }
    }
}