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
    /// Interaction logic for Categorie.xaml
    /// </summary>
    public partial class Categorie : UserControl
    {
        private Manager m => (App.Current as App).m;

        public Categorie()
        {
            InitializeComponent();

            DataContext = m.AllItems;
        }


        private void FetchAndSort(object sender, RoutedEventArgs e)
        {
            PagePrincipale pp = (App.Current.MainWindow as MainWindow).mainPart.Content as PagePrincipale;
            pp.fetcher.Content = new ListItems();

            string type = Specification.Antennas.ToString();
            bool test = true;

            Button item = sender as Button;

            switch (item.Name)
            {
                case "ALL":
                    test = false;
                    break;
                case "Antennas":
                    type = Specification.Antennas.ToString();
                    break;
                case "Banners":
                    type = Specification.Banners.ToString();
                    break;
                case "Bodies":
                    type = Specification.Bodies.ToString();
                    break;
                case "Boosts":
                    type = Specification.Boosts.ToString();
                    break;
                case "Decals":
                    type = Specification.Decals.ToString();
                    break;
                case "Explosions":
                    type = Specification.Explosions.ToString();
                    break;
                case "Paints":
                    type = Specification.Paints.ToString();
                    break;
                case "Toppers":
                    type = Specification.Toppers.ToString();
                    break;
                case "Trails":
                    type = Specification.Trails.ToString();
                    break;
                case "Wheels":
                    type = Specification.Wheels.ToString();
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
                itemsSort = itemsSort.Where(i => i.Type == type).ToList();
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