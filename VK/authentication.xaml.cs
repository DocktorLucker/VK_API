using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VK
{
    /// <summary>
    /// Логика взаимодействия для authentication.xaml
    /// </summary>
    public partial class authentication : Window
    {
        public authentication()
        {
            InitializeComponent();
        }

        private void AuthenticationBox_Loaded(object sender, RoutedEventArgs e)
        {
            AuthenticationBox.Navigate("https://oauth.vk.com/authorize?client_id=5858085&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=friends&response_type=token&v=5.52");
        }

        private void AuthenticationBox_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {

        }

        private void AuthenticationBox_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                string url = AuthenticationBox.Source.ToString();
                string l = url.Split('#')[1];
                if (l[0] == 'a')
                {
                    Settings1.Default.token = l.Split('&')[0].Split('=')[1];
                    Settings1.Default.id = l.Split('=')[3];
                    Settings1.Default.auth = true;
                    System.Windows.MessageBox.Show(Settings1.Default.token + " " + Settings1.Default.id + " ");
                    Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
