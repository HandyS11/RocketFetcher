using Modèle;
using System.Windows;
using System.Windows.Controls;

namespace RocketFetcher.Views
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : UserControl
    {
        public Manager m => (App.Current as App).m;

        public Connexion()
        {
            InitializeComponent();

            textBoxLogin.Text = m.RememberLogin;
            Remember_Case.IsChecked = m.RememberMe;
        }

        private void Logining(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = BoxPassword.Password;

            if (login.Length <= 4)
            {
                errorMessage.Text = "Entrez votre Login !";
                textBoxLogin.Focus();
            }
            else if (password.Length <= 4)
            {
                errorMessage.Text = "Entrez votre mot de passe !";
                textBoxLogin.Focus();
            }
            else
            {
                foreach (var v in m.AllComptes)
                {
                    if (v.Login == login && v.Password == password)
                    {
                        m.SelectedAccount = v;

                        if (m.RememberMe)
                        {
                            m.RememberLogin = m.SelectedAccount.Login;
                            m.SauvegardeDonnées();
                        }

                        (App.Current.MainWindow as MainWindow).mainPart.Content = new PagePrincipale();
                    }
                    else
                    {
                        errorMessage.Text = "Compte/mdp introuvables !";
                    }
                }   
            }
        }

        private void Remember_Me(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.IsChecked == true)
            {
                m.RememberMe = true;
            }
            else
            {
                m.RememberMe = false;
            }
            m.SauvegardeDonnées();
        }

        private void Forgot_Password(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pas de chance ^^");
        }

        private void Create_an_account(object sender, RoutedEventArgs e)
        {
            (App.Current.MainWindow as MainWindow).mainPart.Content = new CreationCompte();
        }

        private void Guest_Mode(object sender, RoutedEventArgs e)
        {
            // C'est pas ouf mais ça marche ^^
            // On n'utilise pas CompteGuest comme initialement prévu pour éviter des contraintes inutiles !
            m.SelectedAccount = m.AllComptes[0];

            (App.Current.MainWindow as MainWindow).mainPart.Content = new PagePrincipale();
        }
    }
}
