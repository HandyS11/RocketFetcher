using Modèle;
using System;

namespace Test_Items
{
    class Program /// FONCTIONNE
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("Test", Rarity.Common.ToString(), Specification.Wheels.ToString(), Certification.Victor.ToString(), "Test", new DateTime(2022, 2, 1), Color.Cobalt.ToString(), true, true, false, 125, "Path");
            Item item2 = new Item("Test2", Rarity.Rare.ToString(), Specification.Antennas.ToString(), Certification.Victor.ToString(), "Test", new DateTime(2022, 2, 1), Color.Crimson.ToString(), true, false, true, 155, "Path");

            Console.WriteLine(item1.ToString());
            Console.WriteLine(item2.ToString());
        }
    }
}