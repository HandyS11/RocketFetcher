using Modèle;
using RocketFetcher.Views;
using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    /// <summary>
    /// Interaction logic for ItemBind.xaml
    /// </summary>
    public partial class ItemBind : UserControl
    {
        private Manager m => (App.Current as App).m;

        public ItemBind()
        {
            InitializeComponent();
        }

        private void ItemDetail(object sender, RoutedEventArgs e)
        {
            PagePrincipale pp = (App.Current.MainWindow as MainWindow).mainPart.Content as PagePrincipale;

            pp.fetcher.Content = new ItemsDetails();

            pp.fetcher.DataContext = this.DataContext as Item;
            m.SelectedItem = this.DataContext as Item;
        }
    }
}
