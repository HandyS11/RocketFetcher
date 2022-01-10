using Modèle;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    /// <summary>
    /// Interaction logic for ActifSet.xaml
    /// </summary>
    public partial class ActifSet : UserControl
    {
        public Manager m => (App.Current as App).m;

        public ActifSet()
        {
            InitializeComponent();

            //// Trie du SetActif pour que ça soit mieux présenté (par type d'objet)

            //m.SelectedAccount.SetActif.SetItems as Item;
            //IEnumerable<Item> allItems = ; 
            //Cette ligne pose problème, elle ne peut pas marcher à cause du dictionnaire, il va falloir trouver comment la contourner..

            //List<Item> items = allItems.ToList();
            //List<Item> itemsSort = new List<Item>();

            //itemsSort.AddRange(items.OrderBy(Item => Item.Type));

            //DataContext = itemsSort;

            DataContext = m.SelectedAccount.SetActif.SetItems;
        }
    }
}
