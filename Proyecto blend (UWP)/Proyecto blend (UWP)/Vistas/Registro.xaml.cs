using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_blend__UWP_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registro : Page
    {
        public Registro()
        {
            this.InitializeComponent();
        }

        private async void addProfileImage(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (IRandomAccessStream filestream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Application now has read/write access to the picked file
                    BitmapImage fondo = new BitmapImage();
                    ImageBrush ib = new ImageBrush();
                    fondo.DecodePixelHeight = 600;
                    await fondo.SetSourceAsync(filestream);
                    ib.ImageSource = fondo;
                    btnFotoPerfil.Background = ib;
                } 
            }
        }

        private async void goLogInAsync(object sender, RoutedEventArgs e)
        {
            int id = 0;
            var secundaria = CoreApplication.CreateNewView();
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
