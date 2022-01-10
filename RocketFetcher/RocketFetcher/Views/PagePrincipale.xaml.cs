using Modèle;
using RocketFetcher.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.Views
{
    /// <summary>
    /// Interaction logic for PagePrincipale.xaml
    /// </summary>
    public partial class PagePrincipale : UserControl
    {
        public Manager m => (App.Current as App).m;


        public Sets set;
        public Categorie categ;
        public UserControls.Rarity rarity;


        public PagePrincipale()
        {
            InitializeComponent();

            DataContext = this;


            categ = new Categorie();
            rarity = new UserControls.Rarity();


            fetcher.Content = categ;
            m.SelectedFetch = 0;


            Group_by.SelectionChanged += Group_by_SelectionChanged;
            Sort_by.SelectionChanged += Sort_SelectionChanged;
            Search.TextChanged += Search_Changed;
        }

        private void Group_by_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox group = (ComboBox)sender;

            if (group.SelectedIndex == 0)
            {
                fetcher.Content = categ;
                m.SelectedFetch = 0;
            }
            else
            {
                fetcher.Content = rarity;
                m.SelectedFetch = 1;
            }
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox sort = (ComboBox)sender;

            if (m.SelectedFetch == 0)
            {
                if (sort.SelectedIndex == 0)
                {
                    m.SelectedSort = 0;
                }
                else
                {
                    m.SelectedSort = 1;
                }
                fetcher.Content = categ;
            }
            else
            {
                if (sort.SelectedIndex == 0)
                {
                    m.SelectedSort = 0;
                }
                else
                {
                    m.SelectedSort = 1;
                }
                fetcher.Content = rarity;
            }
        }

        private void Search_Changed(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (m.SelectedFetch == 0)
            {
                fetcher.Content = categ;
            }
            else
            {
                fetcher.Content = rarity;
            }
            m.SearchValue = txt.Text;
        }

        private void GestionCompte(object sender, EventArgs e)
        {
            if (m.SelectedAccount.Login == "Guest")
            {
                (App.Current.MainWindow as MainWindow).mainPart.Content = new CreationCompte();
            }
            else
            {
                (App.Current.MainWindow as MainWindow).mainPart.Content = new Connexion();
            }
        }

        private void ImportPage(object sender, EventArgs e)
        {
            MessageBox.Show("Not aviable for the moment..");
        }

        private void SharePage(object sender, EventArgs e)
        {
            MessageBox.Show("Not aviable for the moment..");
        }

        private void Management(object sender, EventArgs e)
        {
            m.SelectedSet = m.SelectedAccount.Sets[0];

            fetcher.Content = new Sets();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            m.SelectedSet = m.SelectedAccount.SetActif;

            fetcher.Content = new Sets();
        }

        private void Clear_Set(object sender, RoutedEventArgs e)
        {
            m.SelectedAccount.SetActif = new Set("Set Actif");

            CurrentSet.Content = new ActifSet();
        }
    }
}
