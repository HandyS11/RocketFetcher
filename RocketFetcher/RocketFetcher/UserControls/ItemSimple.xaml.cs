using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    public partial class ItemSimple : UserControl
    {
        public string ItemName { get; set; }

        public string ImagePath { get; set; }

        public ItemSimple()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
