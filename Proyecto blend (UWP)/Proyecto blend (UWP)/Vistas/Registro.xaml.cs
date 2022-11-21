using Proyecto_blend__UWP_.Clases;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_blend__UWP_.Vistas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class Registro : Page
    {
        private static string imagePath = "";

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
                imagePath = "..\\img\\" + file.Path.Substring(file.Path.LastIndexOf("\\" + 1));

                using (IRandomAccessStream filestream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
                {
                    // Application now has read/write access to the picked file
                    BitmapImage fondo = new BitmapImage();
                    ImageBrush ib = new ImageBrush();
                    fondo.DecodePixelHeight = 600;
                    await fondo.SetSourceAsync(filestream);
                    ib.ImageSource = fondo;
                    btnFotoPerfil.Background = ib;
                    await SaveImageToFileAsync(file.Path);
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

        private async void register(object sender, RoutedEventArgs e)
        {
            var bitmap = new RenderTargetBitmap();
            var dialog = new MessageDialog("");
            if (txtNombre.Text != "" && txtEmail.Text != "" && bornDate.Date != null && psw.Password != "" && pswConfirm.Password != "")
            {
                if (psw.Password == pswConfirm.Password)
                {
                    Usuarios.AddUser(new Usuario(txtNombre.Text, psw.Password, bornDate.Date, txtEmail.Text, session: true, imagePath));
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
                    dialog = new MessageDialog("Las contraseñas no coinciden");
                    await dialog.ShowAsync();
                }
            }
            else
            {
                dialog = new MessageDialog("Falta algún campo");
                await dialog.ShowAsync();
            }
        }

        public async Task SaveImageToFileAsync(string fileName)
        {
            Image img = new Image();
            var rtb = new RenderTargetBitmap();
            BitmapImage bit = new BitmapImage();
            Uri uri = new Uri(fileName);
            bit.UriSource = uri;
            img.Source = bit;
            await rtb.RenderAsync(img);

            StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync("..\\img");
            StorageFile storageFile = await storageFolder.CreateFileAsync(fileName);

            if (storageFile == null)
                return;

            var pixels = await rtb.GetPixelsAsync();
            using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await
                BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                byte[] bytes = pixels.ToArray();
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore,
                    (uint)rtb.PixelWidth, (uint)rtb.PixelHeight, 200, 200, bytes);
                await encoder.FlushAsync();
            }
        }
    }
}
