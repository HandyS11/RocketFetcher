using Modèle;
using RocketFetcher.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    /// <summary>
    /// Interaction logic for Sets.xaml
    /// </summary>
    public partial class Sets : UserControl
    {
        public Manager m => (App.Current as App).m;

        public Sets()
        {
            InitializeComponent();

            DataContext = m;
        }

        private void NewSet(object sender, RoutedEventArgs e)
        {
            if (m.SelectedAccount.Login == "Guest")
            {
                MessageBox.Show("You must create an account to save \"Items Sets\" !");
            }
            else
            {
                string setName = SetName.Text;
                string error = "Fill this field !";

                if (setName == "" || setName == error)
                {
                    SetName.Text = error;
                    SetName.Focus();
                }
                else
                {
                    Set activeSet = new Set(setName);
                    

                    foreach (var v in m.SelectedAccount.SetActif.SetItems)
                    {    
                        activeSet.SetAdd(v.Key, true);
                    }


                    m.SelectedAccount.CompteAdd(activeSet);
                    
                    PagePrincipale pp = (App.Current.MainWindow as MainWindow).mainPart.Content as PagePrincipale;
                    pp.fetcher.Content = new Sets();

                    m.SelectedAccount.SetActif = new Set("Set Actif");
                    pp.CurrentSet.Content = m.SelectedAccount.SetActif;

                    m.SauvegardeDonnées();
                }
            }
        }

        private void Set_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m.SelectedSet = e.AddedItems[0] as Set;
        }

        private void Back2Menu_Click(object sender, RoutedEventArgs e)
        {
            PagePrincipale pp = (App.Current.MainWindow as MainWindow).mainPart.Content as PagePrincipale;

            if (m.SelectedFetch == 0)
            {
                pp.fetcher.Content = new Categorie();
            }
            else
            {
                pp.fetcher.Content = new Rarity();
            }
        }
    }
}