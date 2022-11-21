using Proyecto_blend__UWP_.Clases;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_blend__UWP_.Vistas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogIn : Page
    {
        public LogIn()
        {
            this.InitializeComponent();
        }

        private async void goRegisterAsync(object sender, RoutedEventArgs e)
        {
            int id = 0;
            var secundaria = CoreApplication.CreateNewView();
            await secundaria.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(Registro), null);
                Window.Current.Content = frame;
                Window.Current.Activate();

                id = ApplicationView.GetForCurrentView().Id;
            });
            await ApplicationViewSwitcher.SwitchAsync(id);
        }

        private async void clickCheckEnter(object sender, RoutedEventArgs e)
        {
            String username = txtNombre.Text;
            String password = txtPsw.Password.ToString();
            int idUsuario = 0;
            var dialog = new MessageDialog("");

            idUsuario = Usuarios.LookForUser(username);

            if (idUsuario != -1)
            {
                System.Diagnostics.Debug.WriteLine(password);
                if (Usuarios.matchesPassword(password, idUsuario))
                {
                    int id = 0;
                    var secundaria = CoreApplication.CreateNewView();
                    Principal principal = new Principal();
                    await secundaria.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        Frame frame = new Frame();
                        frame.Navigate(typeof(Principal), null);
                        Window.Current.Content = frame;
                        Window.Current.Activate();

                        id = ApplicationView.GetForCurrentView().Id;
                    });
                    await ApplicationViewSwitcher.SwitchAsync(id);
                }
                else
                {
                    dialog = new MessageDialog("Contraseña incorrecta");
                }
            }
            else
            {
                dialog = new MessageDialog("Usuario no existe");
            }
        }
    }
}
