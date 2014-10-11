using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CJia.iSmartMedical.Win8.Common
{
    public class UI
    {
        public UI()
        {

        }
        public static SolidColorBrush NewSolidColorBrush(string color)
        {
            if (color == null)
                throw new ArgumentNullException("color");
            try
            {
                if (color.StartsWith("#"))
                    color = color.Substring(1);
                //将字符串解析成完整的int
                byte a, r, g, b;
                int integer = Int32.Parse(color, NumberStyles.HexNumber);
                //判断或解析Alpha
                if (color.Length == 6)
                    a = 255;
                else
                    a = (byte)((integer >> 24) & 255);
                //解析RGB
                r = (byte)((integer >> 16) & 255);
                g = (byte)((integer >> 8) & 255);
                b = (byte)(integer & 255);
                return new SolidColorBrush(ColorHelper.FromArgb(a, r, g, b));
            }
            catch (Exception ex)
            {
                throw new FormatException("无法解析的颜色", ex);
            }

        }
        static List<Button> FunctionList = new List<Button>();
        static List<Button> InitFunctionList()
        {
            FunctionList.Clear();
            //FunctionList.Add(NewButton("查看医嘱", "ViewAllAppBarButtonStyle", typeof(Doctor.AdviceListPage)));
            //FunctionList.Add(NewButton("查看病历", "ViewAllAppBarButtonStyle", typeof(Doctor.MedicalRecordPage)));
            //FunctionList.Add(NewButton("查房日志", "ViewAllAppBarButtonStyle", typeof(Doctor.CheckLogPage)));
           // FunctionList.Add(NewButton("检查报告", "ViewAllAppBarButtonStyle", typeof(Pages.CheckReportPage)));
           // FunctionList.Add(NewButton("化验报告", "ViewAllAppBarButtonStyle", typeof(Pages.LisResultPage)));
            //FunctionList.Add(NewButton("诊疗相册", "ViewAllAppBarButtonStyle", typeof(Doctor.CheckPhotoPage)));
           // FunctionList.Add(NewButton("新建医嘱", "ViewAllAppBarButtonStyle", typeof(Pages.AdviceInputPage)));
            return FunctionList;
        }

        static Button NewButton(string FunctonName, string StyleKeyName, Type TargetPage)
        {
            ResourceDictionary rd = App.Current.Resources.MergedDictionaries[0];
            Button bt = new Button { Style = rd[StyleKeyName] as Windows.UI.Xaml.Style };
            AutomationProperties.SetName(bt, FunctonName);
            bt.Tag = TargetPage;
            bt.Click += Function_Click;
            return bt;
        }

        static void Function_Click(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate((sender as Button).Tag as Type);
        }

        static Grid GetFunctionListByPage(Page page)
        {
            Grid gridFunction = new Grid();
            gridFunction.Width = 100;
            gridFunction.Height = 600;
            gridFunction.Margin = new Thickness(15, -65, 1262, 10);
            Grid.SetRow(gridFunction, 1);
            gridFunction.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40) });
            gridFunction.RowDefinitions.Add(new RowDefinition());
            StackPanel spFunction = new StackPanel();
            Image imgHeader = new Image();
            imgHeader.Source = new BitmapImage(new Uri("ms-appx:///Images/Doctor/CheckFunction.png"));
            imgHeader.Tag = spFunction;
            imgHeader.Tapped += imgHeader_Tapped;
            Grid.SetRow(imgHeader, 0);
            gridFunction.Children.Add(imgHeader);

            InitFunctionList();
            string pageName = page.ToString();
            foreach (Button bt in FunctionList)
            {
                if ((bt.Tag as Type).FullName != pageName)
                    spFunction.Children.Add(bt);
            }

            spFunction.Visibility = Visibility.Collapsed;
            Grid.SetRow(spFunction, 1);
            gridFunction.Children.Add(spFunction);
            return gridFunction;
        }
        
        static void imgHeader_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            StackPanel sp = (sender as Image).Tag as StackPanel;
            if (sp.Visibility == Visibility.Collapsed)
                sp.Visibility = Visibility.Visible;
            else
                sp.Visibility = Visibility.Collapsed;
        }
    }
}
