using Modèle;
using RocketFetcher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    /// <summary>
    /// Interaction logic for Rarity.xaml
    /// </summary>
    public partial class Rarity : UserControl
    {
        private Manager m => (App.Current as App).m;

        public Rarity()
        {
            InitializeComponent();

            DataContext = m.AllItems;
        }


        private void FetchAndSort(object sender, RoutedEventArgs e)
        {
            PagePrincipale pp = (App.Current.MainWindow as MainWindow).mainPart.Content as PagePrincipale;
            pp.fetcher.Content = new ListItems();

            string rarity = Modèle.Rarity.Legacy.ToString();
            bool test = true;

            Button item = sender as Button;
            switch (item.Name)
            {
                case "All":
                    test = false;
                    break;
                case "Legacy":
                    rarity = Modèle.Rarity.Legacy.ToString();
                    break;
                case "Common":
                    rarity = Modèle.Rarity.Common.ToString();
                    break;
                case "Uncommon":
                    rarity = Modèle.Rarity.Uncommon.ToString();
                    break;
                case "Rare":
                    rarity = Modèle.Rarity.Rare.ToString();
                    break;
                case "Very_Rare":
                    rarity = Modèle.Rarity.Very_Rare.ToString();
                    break;
                case "Import":
                    rarity = Modèle.Rarity.Import.ToString();
                    break;
                case "Exotic":
                    rarity = Modèle.Rarity.Exotic.ToString();
                    break;
                case "Black_Market":
                    rarity = Modèle.Rarity.Black_Market.ToString();
                    break;
                case "Limited":
                    rarity = Modèle.Rarity.Limited.ToString();
                    break;
                case "Prenium":
                    rarity = Modèle.Rarity.Premium.ToString();
                    break;
            }

            // Ya mieux mais voilà ..

            IEnumerable<Item> allItems = m.AllItems;
            List<Item> itemsSort = new List<Item>();
            List<Item> items = allItems.ToList();

            if (m.SelectedSort == 0)
            {
                itemsSort.AddRange(items.OrderBy(Item => Item.Name));
            }
            else
            {
                itemsSort.AddRange(items.OrderBy(Item => Item.Price));
            }

            if (test)
            {
                itemsSort = itemsSort.Where(i => i.Rarity == rarity).ToList();
            }
            else
            {
                itemsSort = itemsSort.ToList();
            }

            if (!String.IsNullOrWhiteSpace(m.SearchValue))
            {
                itemsSort = itemsSort.Where(i => i.Name.Contains(m.SearchValue, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            DataContext = itemsSort;
            pp.fetcher.DataContext = this.DataContext;
        }
    }
}