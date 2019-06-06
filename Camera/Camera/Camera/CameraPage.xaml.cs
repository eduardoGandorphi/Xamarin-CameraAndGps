using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

namespace Camera
{
    public partial class CameraPage : ContentPage
    {
        Foto_BL bl = new Foto_BL();

        public CameraPage()
        {
            InitializeComponent();
            CameraButton.Clicked += CameraButton_Clicked;

            if (bl.TemFoto())
               AtualizaFotos(bl.LastOrDefault());
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var md = new Foto_MD();

            var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                Name = "test.jpg",
                Directory = "myDir",
                SaveToAlbum = true,
                CompressionQuality = 50,
                
            });

            md.ExternalPath = photo.AlbumPath;
            md.InternalPath = photo.Path;
            md.Foto = photo.GetStream().ToByteArray();
            
            bl.Insert(md);

            AtualizaFotos(md);
        }

        private void AtualizaFotos(Foto_MD md)
        {
            this.externalImg.Source = md.ExternalPath;
            this.internalImg.Source = md.InternalPath;
            this.bancoImg.Source = md.Foto.ToImageSource();
        }
    }
}
