using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using System.Reflection;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.FileProperties;
using CJia.iSmartMedical.Win8.Common;
using System.Collections.ObjectModel;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.iSmartMedical.Win8.Doctor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CheckLogDetailPage : BasePage, Views.ICheckLogDetailPageView
    {
        #region 画图参数
        InkManager MedcialInkManager = new InkManager();
        string DrawingTool;
        double X1, X2, Y1, Y2, StrokeThickness = 1;
        Point StartPoint, PreviousContactPoint, CurrentContactPoint;
        Polyline Pencil;
        Color BorderColor = Colors.Black;
        uint PenID, TouchID;
        #endregion

        public CheckLogDetailPage()
        {
            this.InitializeComponent();
            InitColor();
            InitCanvas();
            BasePage.BeforeClose += BasePage_BeforeClose;
        }

        async void BasePage_BeforeClose(object sender, EventArgs e)
        {
            if (clDetail.CheckLog != null)
            {
                clDetail.CheckLog.MedicalLog = await GetImage();
                OnSaveCheckLog(null, clDetail);
            }
        }

        #region 初始化
        void InitCanvas()
        {
            MedicalCanvas.PointerMoved += Canvas_PointerMoved;
            MedicalCanvas.PointerReleased += Canvas_PointerReleased;
            MedicalCanvas.PointerPressed += Canvas_PointerPressed;
            MedicalCanvas.PointerExited += Canvas_PointerExited;
        }

        void InitColor()
        {
            cbStrokeThickness.Items.Clear();
            cbBorderColor.Items.Clear();
            //绑定画笔粗细值
            for (int i = 1; i < 7; i++)
            {
                ComboBoxItem Items = new ComboBoxItem();
                Items.Content = i;
                cbStrokeThickness.Items.Add(Items);
            }
            cbStrokeThickness.SelectedIndex = 2;

            DrawingTool = "Pencil";
            //绑定颜色
            var colors = typeof(Colors).GetTypeInfo().DeclaredProperties;
            foreach (var item in colors)
            {
                cbBorderColor.Items.Add(item);
                if (item.Name == "Black")
                    cbBorderColor.SelectedItem = item;
            }
            ToolButtonList.Clear();
            ToolButtonList.AddRange(new Button[] { btnPencil, btnEraser });
            ShowToolColor(btnPencil);
        }
        #endregion

        #region 画布事件
        void Canvas_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        }

        void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (DrawingTool != "Eraser")
                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Cross, 1);
            else
                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.UniversalNo, 1);
            Canvas canvas = sender as Canvas;
            InkManager inkManager = MedcialInkManager;

            switch (DrawingTool)
            {

                case "Pencil":
                    {
                        var MyDrawingAttributes = new InkDrawingAttributes();
                        MyDrawingAttributes.Size = new Size(StrokeThickness, StrokeThickness);
                        MyDrawingAttributes.Color = BorderColor;
                        MyDrawingAttributes.FitToCurve = true;
                        inkManager.SetDefaultDrawingAttributes(MyDrawingAttributes);

                        PreviousContactPoint = e.GetCurrentPoint(canvas).Position;
                        if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed)
                        {
                            // Pass the pointer information to the InkManager.
                            inkManager.ProcessPointerDown(e.GetCurrentPoint(canvas));
                            PenID = e.GetCurrentPoint(canvas).PointerId;
                            e.Handled = true;
                        }
                    }
                    break;

                case "Eraser":
                    {
                        Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.UniversalNo, 1);
                        StartPoint = e.GetCurrentPoint(canvas).Position;
                        Pencil = new Polyline();
                        Pencil.Stroke = new SolidColorBrush(Colors.White);
                        Pencil.StrokeThickness = 10;
                        canvas.Children.Add(Pencil);
                    }
                    break;
                default:
                    break;
            }
        }

        void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (DrawingTool != "Eraser")
                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Cross, 1);
            else
                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.UniversalNo, 1);
            Canvas canvas = sender as Canvas;
            InkManager inkManager = MedcialInkManager;
            switch (DrawingTool)
            {
                case "Pencil":
                    {
                        if (e.Pointer.PointerId == PenID || e.Pointer.PointerId == TouchID)
                        {
                            // Distance() is an application-defined function that tests
                            // whether the pointer has moved far enough to justify 
                            // drawing a new line.
                            CurrentContactPoint = e.GetCurrentPoint(canvas).Position;
                            X1 = PreviousContactPoint.X;
                            Y1 = PreviousContactPoint.Y;
                            X2 = CurrentContactPoint.X;
                            Y2 = CurrentContactPoint.Y;

                            if (Distance(X1, Y1, X2, Y2) > 0.5)
                            {
                                Line line = new Line()
                                {
                                    X1 = X1,
                                    Y1 = Y1,
                                    X2 = X2,
                                    Y2 = Y2,
                                    StrokeThickness = StrokeThickness,
                                    Stroke = new SolidColorBrush(BorderColor)
                                };

                                PreviousContactPoint = CurrentContactPoint;
                                canvas.Children.Add(line);
                                inkManager.ProcessPointerUpdate(e.GetCurrentPoint(canvas));
                            }
                        }
                    }
                    break;

                case "Eraser":
                    {
                        if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed == true)
                        {
                            if (StartPoint != e.GetCurrentPoint(canvas).Position)
                            {
                                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.UniversalNo, 1);
                                Pencil.Points.Add(e.GetCurrentPoint(canvas).Position);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            double d = 0;
            d = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return d;
        }
        private void cbBorderColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbBorderColor.SelectedIndex != -1)
            {
                var pi = cbBorderColor.SelectedItem as PropertyInfo;
                BorderColor = (Color)pi.GetValue(null);
            }
        }
        void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            InkManager inkManager = MedcialInkManager;
            if (e.Pointer.PointerId == PenID || e.Pointer.PointerId == TouchID)
                inkManager.ProcessPointerUp(e.GetCurrentPoint(canvas));

            TouchID = 0;
            PenID = 0;
            e.Handled = true;
            //Pencil = null;
        }
        #endregion

        #region 画笔工具事件
        List<Button> ToolButtonList = new List<Button>();
        private void btnEraser_Click(object sender, RoutedEventArgs e)
        {
            DrawingTool = "Eraser";
            ShowToolColor(sender as Button);
        }
        private void btnPencil_Click(object sender, RoutedEventArgs e)
        {
            DrawingTool = "Pencil";
            ShowToolColor(sender as Button);
        }
        private void btnClearMedicalLog_Click(object sender, RoutedEventArgs e)
        {
            this.MedicalCanvas.Children.Clear();
        }
        private void cbStrokeThickness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StrokeThickness = Convert.ToDouble(cbStrokeThickness.SelectedIndex + 1);
        }
        private void ShowToolColor(Button button)
        {
            foreach (Button btn in ToolButtonList)
            {
                btn.BorderBrush = new SolidColorBrush(Colors.White);
            }
            button.BorderBrush = new SolidColorBrush(Colors.Blue);
        }
        #endregion

        protected override object CreatePresenter()
        {
            return new Presenters.CheckLogDetailPagePresenter(this);
        }

        Views.CheckLogDetailEventArgs clDetail = new Views.CheckLogDetailEventArgs();

        Data.DoctorCheckLog logParam = null;
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            OnQueryCheckLog(null, new Views.CheckLogDetailEventArgs(iCommon.Patient.InhosID));
        }

        protected async override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (clDetail.CheckLog != null)
            {
                clDetail.CheckLog.MedicalLog = await GetImage();
                OnSaveCheckLog(null, clDetail);
            }
        }

        private void gridLogList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridLogList.SelectedItem == null) return;
            Data.DoctorCheckLog log = gridLogList.SelectedItem as Data.DoctorCheckLog;
            ShowLog(log);
        }

        private async void ShowLog(Data.DoctorCheckLog log)
        {
            if (clDetail.CheckLog != null)
            {
                clDetail.CheckLog.MedicalLog = await GetImage();
                OnSaveCheckLog(null, clDetail);
            }

            SetImage(log.MedicalLog);
            clDetail.CheckLog = log;
        }
        private async Task<byte[]> GetImage()
        {
            InkManager inkMgr = MedcialInkManager;
            if (inkMgr.GetStrokes().Count == 0) return null;
            using (var stream = new InMemoryRandomAccessStream())
            {
                await inkMgr.SaveAsync(stream);
                await stream.FlushAsync();
                stream.Seek(0);
                byte[] bytes = new byte[stream.Size];
                IBuffer buffer = bytes.AsBuffer();
                await stream.ReadAsync(buffer, (uint)stream.Size, InputStreamOptions.None);
                return bytes;
            }
        }
        XamlInkRenderer renderer = null;
        private async void SetImage(byte[] ImageData)
        {
            MedicalCanvas.Children.Clear();
            if (ImageData == null)
            {
                MedcialInkManager = new InkManager();
                return;
            }
            InkManager inkMgr = MedcialInkManager;
            renderer = new XamlInkRenderer(MedicalCanvas);

            using (var stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(ImageData.AsBuffer());
                await stream.FlushAsync();
                stream.Seek(0);

                await inkMgr.LoadAsync(stream);

                var iskList = inkMgr.GetStrokes();
                int iskCount = iskList.Count;
                renderer.Clear();
                renderer.AddInk(iskList);
            }
        }

        public event EventHandler<Views.CheckLogDetailEventArgs> OnSaveCheckLog;

        private void btnDeleteCheckLog_Click(object sender, RoutedEventArgs e)
        {
            if (this.gridLogList.SelectedItem == null) return;
            Data.DoctorCheckLog log = gridLogList.SelectedItem as Data.DoctorCheckLog;
            OnDeleteCheckLog(null, new Views.CheckLogDetailEventArgs(iCommon.Patient.InhosID, log));
        }

        public event EventHandler<Views.CheckLogDetailEventArgs> OnDeleteCheckLog;

        public void ExeDeleteCheckLog(Data.DoctorCheckLog CheckLog)
        {
            PatientCheckLog.Remove(CheckLog);
            ExeShowCheckLogList(PatientCheckLog);
        }

        List<Data.DoctorCheckLog> PatientCheckLog;

        public event EventHandler<Views.CheckLogDetailEventArgs> OnQueryCheckLog;

        public void ExeShowCheckLogList(List<Data.DoctorCheckLog> LogList)
        {
            if (LogList.FindAll(log => log.CheckDate == iCommon.Today).Count == 0)
            {
                LogList.Insert(0, NewLog());
            }

            var groupData = from log in LogList group log by log.CheckDate;

            this.cvsCheckLog.Source = groupData;
            var DateList = cvsCheckLog.View.CollectionGroups;
            (this.mmSZoom.ZoomedOutView as ListViewBase).ItemsSource = DateList;

            if (logParam != null)
            {
                Data.DoctorCheckLog log = LogList.Find(c => c.DCLID == logParam.DCLID);
                if (log != null)
                    gridLogList.SelectedItem = log;
            }

            if (gridLogList.SelectedItem != null)
            {
                ShowLog(gridLogList.SelectedItem as Data.DoctorCheckLog);
            }
            PatientCheckLog = LogList;
        }

        Data.DoctorCheckLog NewLog()
        {
            Data.DoctorCheckLog nLog = new Data.DoctorCheckLog();
            nLog.DCLID = Guid.NewGuid().ToString();
            nLog.DeviceID = iCommon.DeviceID;
            nLog.DoctorID = iCommon.DoctorID;
            nLog.DoctorName = iCommon.DoctorName;
            nLog.InhosID = iCommon.Patient.InhosID;
            nLog.LogType = "日志";
            nLog.CheckDate = iCommon.Today;
            nLog.CheckTime = iCommon.NowTime;
            nLog.LastSaveDate = iCommon.DateNow;
            return nLog;
        }

        private void btnNewLog_Click(object sender, RoutedEventArgs e)
        {
            PatientCheckLog.Insert(0, NewLog());
            ExeShowCheckLogList(PatientCheckLog);
        }
    }
}
