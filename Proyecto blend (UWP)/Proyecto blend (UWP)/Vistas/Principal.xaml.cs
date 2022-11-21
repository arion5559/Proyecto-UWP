using Proyecto_blend__UWP_.Clases;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_blend__UWP_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Principal : Page
    {
        Usuario Usuario;
        public Principal()
        {
            this.InitializeComponent();
            foreach (Usuario user in Usuarios.Users)
            {
                if (user.session)
                {
                    Usuario = user;
                    break;
                }
            }

            if (Usuario != null)
            {
                Image img = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri(img.BaseUri, Usuario.photo);
                img.Source = bitmapImage;
                imgUser.Source = img.Source;
                txtUser.Text = Usuario.username;
            }
        }

        private void goBuy(object sender, DoubleTappedRoutedEventArgs e)
        {

        }

        private async void logOut(object sender, DoubleTappedRoutedEventArgs e)
        {
            foreach (Usuario user in Usuarios.Users)
            {
                if (user.Equals(Usuario))
                {
                    user.session = false;
                    break;
                }
            }
            int id = 0;
            var secundaria = CoreApplication.CreateNewView();
            Principal principal = new Principal();
            await secundaria.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(LogIn), null);
                Window.Current.Content = frame;
                Window.Current.Activate();

                id = ApplicationView.GetForCurrentView().Id;
            });
            await ApplicationViewSwitcher.SwitchAsync(id);
        }
    }


}
