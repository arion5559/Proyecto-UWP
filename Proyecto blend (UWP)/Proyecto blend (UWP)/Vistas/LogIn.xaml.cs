using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Proyecto_blend__UWP_.Clases;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_blend__UWP_
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

            if (idUsuario == 0)
            {
                if (Usuarios.matchesPassword(password, idUsuario))
                {
                    int id = 0;
                    var secundaria = CoreApplication.CreateNewView();
                    Principal principal = new Principal(idUsuario);
                    await secundaria.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        Frame frame = new Frame();
                        frame.Navigate(typeof(Principal), principal);
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
