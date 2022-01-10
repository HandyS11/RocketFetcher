using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    public partial class ArgsDetails : UserControl
    {
        public string itemSpecification
        {
            get { return (string)GetValue(itemSpecificationProperty); }
            set { SetValue(itemSpecificationProperty, value); }
        }
        // Using a DependencyProperty as the backing store for itemSpecification.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty itemSpecificationProperty =
            DependencyProperty.Register("itemSpecification", typeof(string), typeof(ArgsDetails), new PropertyMetadata("A113"));

        public string itemSpecValue
        {
            get { return (string)GetValue(itemSpecValueProperty); }
            set { SetValue(itemSpecValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for itemSpecValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty itemSpecValueProperty =
            DependencyProperty.Register("itemSpecValue", typeof(string), typeof(ArgsDetails), new PropertyMetadata("A113"));

        public ArgsDetails()
        {
            InitializeComponent();
        }
    }
}
