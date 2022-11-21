using Proyecto_blend__UWP_.Clases;
using System;
using System.Reflection;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_blend__UWP_.Vistas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Principal : Page
    {
        private NavigationViewItem _lastItem;
        Usuario sessionUser;
        public Principal()
        {
            foreach (Usuario user in Usuarios.Users)
            {
                if (user.session == true)
                {
                    sessionUser = new Usuario(username: user.username, user.password, user.bornDate, user.email, user.session, user.photo);
                    break;
                }
            }

            if (sessionUser != null)
            {
                Image img = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri(img.BaseUri, sessionUser.photo);
                img.Source = bitmapImage;
                imgUser.Source = img.Source;
                txtUser.Text = sessionUser.username;
            }
            this.InitializeComponent();
        }

        private async void logOut(object sender, DoubleTappedRoutedEventArgs e)
        {
            foreach (Usuario user in Usuarios.Users)
            {
                if (user.Equals(sessionUser))
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

        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            System.Diagnostics.Debug.WriteLine(args.InvokedItemContainer);
            if (item == null || item == _lastItem) return;

            var clickedView = item.Tag?.ToString() ?? "SettingsView";
            System.Diagnostics.Debug.WriteLine(item.Tag?.ToString());
            if (NavigateToView(clickedView) == false) return;
            _lastItem = item;
        }

        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly().GetType($"Proyecto_blend__UWP_.Vistas.{clickedView}");
            System.Diagnostics.Debug.WriteLine(Assembly.GetExecutingAssembly().GetType($"{clickedView}"));
            System.Diagnostics.Debug.WriteLine($"Aquí llega {clickedView}");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null) return false;

            System.Diagnostics.Debug.WriteLine(view);
            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        //private void NavigationViewControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    foreach(NavigationViewItemBase item in NavigationViewControl.MenuItems)
        //    {
        //        if (item is NavigationView && item.Tag.ToString() == "PaginaPrincipal")
        //        {
        //            NavigationViewControl.SelectedItem = item;
        //            break;
        //        }
        //    }
        //    ContentFrame.Navigate(typeof(Principal));
        //}

        private void NavigationViewControl_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }

        private void NavigationViewControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }
    }


}
