using Modèle;
using System.Windows;

namespace RocketFetcher.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager m => (App.Current as App).m;

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
