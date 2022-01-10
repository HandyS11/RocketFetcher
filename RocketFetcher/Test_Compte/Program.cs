using Modèle;
using System;

namespace Test_Compte
{
    class Program /// FONCTIONNE
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de Compte");

            Compte MonCompte = new Compte("Test", "1234", "Test@gmail.com", "");
            CompteGuest MonGuest = new CompteGuest();

            ///Compte nul = new Compte(null,null,null, ""); /// éviter de décommenter sinon le code il est pas content

            Console.WriteLine(MonCompte.ToString());
            Console.WriteLine(MonGuest.ToString());

            Set MonSet = new Set("MonSet");
            Set MonAutreSet = new Set("MonAutreSet");

            Item item1 = new Item("Test", Rarity.Common.ToString(), Specification.Wheels.ToString(), Certification.Victor.ToString(), "Test", new DateTime(2022, 1, 1), Color.Cobalt.ToString(), true, true, false, 125, "Path");
            Item item3 = item1;
            Item item2 = new Item("Test2", Rarity.Rare.ToString(), Specification.Antennas.ToString(), Certification.Victor.ToString(), "Test2", new DateTime(2022, 2, 1), Color.Crimson.ToString(), true, false, true, 155, "Path");
            Item item4 = new Item("Test3", Rarity.Very_Rare.ToString(), Specification.Bodies.ToString(), Certification.Striker.ToString(), "Test3", new DateTime(2022, 2, 1), Color.Sky_Blue.ToString(), true, false, true, 185, "Path");
            MonSet.SetAdd(item1, true);
            MonSet.SetAdd(item2, true);
            MonAutreSet.SetAdd(item4, true);
            MonAutreSet.SetAdd(item1, false);

            Console.Write(MonSet.ToString());

            MonSet.SetAdd(item3, false);

            Console.Write(MonSet.ToString());

            MonCompte.CompteAdd(MonSet);
            MonCompte.CompteAdd(MonAutreSet);
            MonCompte.CompteSetNumSet(MonAutreSet, 2);
            MonCompte.CompteSetNumSet(MonSet, 2);
            Console.WriteLine(MonSet.ToString());
            MonCompte.CompteSetNumSet(MonSet, 3);
            Console.WriteLine(MonAutreSet.ToString());

            Console.WriteLine("----Récupitulatif----");

            foreach (var v in MonCompte.Sets)
            {
                Console.WriteLine(v.ToString());
            }
            Console.WriteLine(MonCompte.ToString());
        }
    }
}