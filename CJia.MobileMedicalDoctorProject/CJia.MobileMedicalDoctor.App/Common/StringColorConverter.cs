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
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace CJia.MobileMedicalDoctor.App.Common
{
    public class StringColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush scBrush = new SolidColorBrush(Colors.White);
            if (value.ToString() == "1")
                scBrush.Color = Colors.Red;
            return scBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
