using DataContractPersistance;
using Microsoft.Win32;
using Modèle;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RocketFetcher.Views
{
    /// <summary>
    /// Logique d'interaction pour CreationCompte.xaml
    /// </summary>
    public partial class CreationCompte : UserControl
    {
        public Manager m => (App.Current as App).m;

        public CreationCompte()
        {
            InitializeComponent();
        }

        private void OuvrirImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            bool? result = file.ShowDialog();

            if (result == true)
            {
                FileInfo fi = new FileInfo(file.FileName);
                string filename = file.FileName;
                int i = 0;
                while (File.Exists(System.IO.Path.Combine("ImagesSources", filename)))
                {
                    i++;
                    filename = $"{fi.Name.Remove(fi.Name.LastIndexOf('.'))}_{i}{fi.Extension}";
                }
                string d = Directory.GetCurrentDirectory();
                string filePath = System.IO.Path.Combine("ImagesSources", filename);
                File.Copy(file.FileName, filePath);

                img.Source = new BitmapImage(new Uri(file.FileName));
            }
        }

        private void Log(object sender, RoutedEventArgs e)
        {
            string mail = textBoxMail.Text;
            string login = textBoxLogin.Text;
            string password = BoxPassword.Password;
            string password2 = BoxPassword2.Password;
            string image = "../ImagesSources/icone_profile.png";

            if (img.Source != null)
            {
                image = img.Source.ToString();
            }

            

            if (mail.Length <= 7)
            {
                if (mail.Length == 0)
                {
                    errorMessage.Text = "Entrez un email!";
                    textBoxMail.Focus();
                }
                // Rajouter le test de l'@
                else
                {
                    errorMessage.Text = "Email non valide !";
                    textBoxLogin.Focus();
                }
            }

            else if (login.Length <= 4)
            {
                if (login.Length == 0)
                {
                    errorMessage.Text = "Entrez un login !";
                    textBoxLogin.Focus();
                }
                else
                {
                    errorMessage.Text = "5 caractères miniumum !";
                    textBoxLogin.Focus();
                }
            }

            else if (password.Length <= 4)
            {
                if (password.Length == 0)
                {
                    errorMessage.Text = "Entrez un mot de passe !";
                    BoxPassword.Focus();
                }
                else
                {
                    errorMessage.Text = "5 caractères miniumum !";
                    BoxPassword.Focus();
                }
            }

            else if (password2.Length <= 4)
            {
                errorMessage.Text = "Confirmez votre mot de passe !";
                BoxPassword2.Focus();
            }

            else if (password != password2)
            {
                errorMessage.Text = "Vos mots de passe de coïncide pas !!";
                BoxPassword2.Focus();
            }

            else
            {
                Compte newcompte = new Compte(login, password, mail, image);

                foreach (var v in m.AllComptes)
                {
                    if (v.Login == login || v.Email == mail)
                    {
                        errorMessage.Text = "Compte existant !";
                        return;
                    }
                }

                m.AddCompte(newcompte);
                m.Persistance = new DataContractPers();
                m.SauvegardeDonnées();

                m.SelectedAccount = newcompte;

                (App.Current.MainWindow as MainWindow).mainPart.Content = new PagePrincipale();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            (App.Current.MainWindow as MainWindow).mainPart.Content = new Connexion();
        }
    }
}
