using Modèle;
using RocketFetcher.Views;
using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    public partial class ItemsDetails : UserControl
    {
        private Manager m => (App.Current as App).m;

        public ItemsDetails()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
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

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            PagePrincipale pp = (App.Current.MainWindow as MainWindow).mainPart.Content as PagePrincipale;

            m.SelectedAccount.SetActif.SetAdd(m.SelectedItem, true);

            ActifSet set = new ActifSet();
            pp.CurrentSet.Content = set;
        }
    }
}
