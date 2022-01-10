using Modèle;
using System;
using Xunit;

namespace UnitTests
{
    /// <summary>
    /// Tests unitaires sur les sets
    /// </summary>
    public class UnitTest_Set
    {
        [Fact]
        public void Test1()
        {
            Set MonSet = new Set("MonSet");

            Item item1 = new Item("Test", Rarity.Common.ToString(), Specification.Wheels.ToString(), Certification.Victor.ToString(), "Test", new DateTime(2022, 2, 1), Color.Cobalt.ToString(), true, true, false, 125, "Path");
            Item item2 = new Item("Test2", Rarity.Rare.ToString(), Specification.Antennas.ToString(), Certification.Victor.ToString(), "Test2", new DateTime(2022, 2, 1), Color.Crimson.ToString(), true, false, true, 155, "Path");

            MonSet.SetAdd(item1, true);
            MonSet.SetAdd(item2, true);

            Assert.True(MonSet.SetItems.ContainsKey(item1));
        }
        [Fact]


        public void Test2()
        {
            Set MonSet = new Set("MonSet");

            Item item1 = new Item("Test", Rarity.Common.ToString(), Specification.Wheels.ToString(), Certification.Victor.ToString(), "Test", new DateTime(2022, 2, 1), Color.Cobalt.ToString(), true, true, false, 125, "Path");
            Item item2 = new Item("Test2", Rarity.Rare.ToString(), Specification.Antennas.ToString(), Certification.Victor.ToString(), "Test2", new DateTime(2022, 2, 1), Color.Crimson.ToString(), true, false, true, 155, "Path");

            MonSet.SetAdd(item1, true);
            MonSet.SetAdd(item2, true);

            Assert.True(MonSet.SetItems.ContainsKey(item2));
        }
        [Fact]


        public void Test3()
        {
            Set MonSet = new Set("MonSet");

            Item item1 = new Item("Test", Rarity.Common.ToString(), Specification.Wheels.ToString(), Certification.Victor.ToString(), "Test", new DateTime(2022, 2, 1), Color.Cobalt.ToString(), true, true, false, 125, "Path");
            Item item2 = new Item("Test2", Rarity.Rare.ToString(), Specification.Antennas.ToString(), Certification.Victor.ToString(), "Test2", new DateTime(2022, 2, 1), Color.Crimson.ToString(), true, false, true, 155, "Path");

            MonSet.SetAdd(item1, true);
            MonSet.SetAdd(item2, true);

            MonSet.DeleteItemFromSet(MonSet, item2);

            Assert.False(MonSet.SetItems.ContainsKey(item2));
        }
    }
}