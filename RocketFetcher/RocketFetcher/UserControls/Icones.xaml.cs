using System;
using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.UserControls
{
    /// <summary>
    /// Interaction logic for Icones.xaml
    /// </summary>
    public partial class Icones : UserControl
    {
        public string path
        {
            get; set;
        }

        public Icones()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler<EventArgs> Click;
    }
}
