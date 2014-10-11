using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CJia.MobileMedicalDoctor.Data
{
    public class Tile : INotifyPropertyChanged
    {
        public Tile(string tileType, string title, string description, SolidColorBrush background, string imageName)
        {
            TileType = tileType;
            Title = title;
            Description1 = description;
            Background = background;
            Image = new BitmapImage(new Uri("ms-appx:///" + imageName));
        }
        public Tile(string tileType, string title, string description, string BgImagName, string imageName)
        {
            TileType = tileType;
            Title = title;
            Description1 = description;
            BgImage = new BitmapImage(new Uri("ms-appx:///" + BgImagName));
            Image = new BitmapImage(new Uri("ms-appx:///" + imageName));
        }
        public string TileType { get; set; }
        public string Title { get; set; }
        string description1, description2, description3, description4;
        public string Description1 { get { return description1; } set { description1 = value; OnPropertyChanged("Description1"); } }
        public string Description2 { get { return description2; } set { description2 = value; OnPropertyChanged("Description2"); } }
        public string Description3 { get { return description3; } set { description3 = value; OnPropertyChanged("Description3"); } }
        public string Description4 { get { return description4; } set { description4 = value; OnPropertyChanged("Description4"); } }
        public SolidColorBrush Background { get; set; }
        public ImageSource BgImage { get; set; }
        public ImageSource Image { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
