using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using System.IO;

namespace CJia.iSmartMedical.Win8.Common
{
    public class ByteImageConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;
            byte[] imageData = value as byte[];
            var bitmapImage = new BitmapImage();
            using (var stream = new InMemoryRandomAccessStream())
            {
                stream.WriteAsync(imageData.AsBuffer());
                stream.FlushAsync();
                stream.Seek(0);
                //DataWriter datawriter = new DataWriter(stream.GetOutputStreamAt(0));
                //datawriter.WriteBytes(imageData);
                //datawriter.StoreAsync();
                bitmapImage.SetSource(stream);
            }
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
