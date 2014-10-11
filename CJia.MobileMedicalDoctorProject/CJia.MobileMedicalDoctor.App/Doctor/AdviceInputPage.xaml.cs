using CJia.MobileMedicalDoctor.App.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.MobileMedicalDoctor.App.Doctor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AdviceInputPage : BasePage, Views.IAdviceInputPageView
    {
        int CurrentInputIndex;
        List<TextBox> InputDict = new List<TextBox>();
        List<ListView> ListDict = new List<ListView>();
        bool isFirstInput = false;
        Views.AdviceInputEventArgs AdviceArgs = new Views.AdviceInputEventArgs();
        public AdviceInputPage()
        {
            this.InitializeComponent();
        }

        #region 初始化
        protected override object CreatePresenter()
        {
            return new Presenters.AdviceInputPagePresenter(this);
        }
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                BindAdviceType();
                OnQueryUsage(null, null);
                OnQueryFrequence(null, null);
                InitInputDict();
            }
        }

        void InitInputDict()
        {
            InputDict.Add(txtStandingFlag);
            InputDict.Add(txtAdviceType);
            InputDict.Add(txtAdviceName);
            InputDict.Add(txtDosage);
            InputDict.Add(txtUsage);
            InputDict.Add(txtFrequence);

            ListDict.Add(listStandingFlag);
            ListDict.Add(listAdviceType);
            ListDict.Add(listAdvice);
            ListDict.Add(null);
            ListDict.Add(listUsage);
            ListDict.Add(listFrequancy);

            CurrentInputIndex = 0;
            SetCurrentInput(CurrentInputIndex);
        }

        void BindAdviceType()
        {
            listAdviceType.ItemsSource = iCommon.iCodeList.FindAll(c => c.GroupName == "医嘱类别");
            listStandingFlag.ItemsSource = iCommon.iCodeList.FindAll(c => c.GroupName == "医嘱长临标志");
        }

        void SetCurrentInput(int inputIndex)
        {
            for (int i = 0; i < InputDict.Count; i++)
            {
                if (i == inputIndex)
                    InputDict[i].Background = UI.NewSolidColorBrush("FF00ABB7");
                else
                    InputDict[i].Background = new SolidColorBrush(Colors.White);

                if (ListDict[i] != null)
                    ListDict[i].Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            isFirstInput = true;
        }

        #endregion

        #region 字母按键
        private void ButtonChar_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputIndex == 0) return;//持续标志
            Button btn = sender as Button;
            string buttonText = btn.Content.ToString();
            TextBox inputBox = InputDict[CurrentInputIndex];

            if (isFirstInput)
            {
                inputBox.Text = "";
                isFirstInput = false;
            }

            if (buttonText == "退格")
            {
                inputBox.Text = inputBox.Text.Substring(0, inputBox.Text.Length - 1);

            }
            else if (buttonText == "清空")
            {
                inputBox.Text = "";
                inputBox.Tag = null;
            }
            else
            {
                if (CurrentInputIndex == 3)
                { //剂量
                    if (btn.Tag == null) return;
                    if (inputBox.Text == "0" && buttonText != ".") return;
                    if (buttonText == ".")
                    {
                        if (inputBox.Text.Length == 0 || inputBox.Text.IndexOf(".") > 0)
                            return;
                        else
                            inputBox.Text += buttonText;
                    }
                    else
                        inputBox.Text += buttonText;
                }
                else
                {
                    inputBox.Text += buttonText;
                }
            }
            if (ListDict[CurrentInputIndex] != null && ListDict[CurrentInputIndex].Visibility == Windows.UI.Xaml.Visibility.Collapsed)
                ListDict[CurrentInputIndex].Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        #endregion

        #region 显示医嘱
        private void listSubType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FilterAdvice();
        }

        public event EventHandler<Views.AdviceInputEventArgs> OnQueryAdvice;

        public void ExeShowAdviceList(List<Data.iAdvice> AdviceList)
        {
            this.listAdvice.ItemsSource = AdviceList;
        }
        #endregion

        #region 医嘱过滤
        private void FilterAdvice()
        {
            if (this.txtStandingFlag.Tag == null) return;
            if (this.txtAdviceType.Tag == null) return;

            AdviceArgs.AdviceTypeID = (this.txtAdviceType.Tag as Data.iCode).Code;

            AdviceArgs.StandingFlag = (txtStandingFlag.Tag as Data.iCode).Code == "901111" ? "1" : "0";

            AdviceArgs.AdviceFilter = txtAdviceName.Text;

            OnQueryAdvice(null, AdviceArgs);
        }
        #endregion

        #region 用法
        public event EventHandler OnQueryUsage;
        List<Data.iUsage> UsageData;
        public void ExeShowUsage(List<Data.iUsage> listUsage)
        {
            UsageData = listUsage;
            this.listUsage.ItemsSource = listUsage;
        }
        #endregion

        #region 频率
        public event EventHandler OnQueryFrequence;
        List<Data.iFrequency> FrequenceData = null;
        public void ExeShowFrequence(List<Data.iFrequency> listFrequence)
        {
            FrequenceData = listFrequence;
            this.listFrequancy.ItemsSource = listFrequence;
        }
        #endregion

        #region 组输入
        string GroupIndex = "0";
        private void tsGroup_Toggled(object sender, RoutedEventArgs e)
        {
            if (tsGroup == null) return;
            if (tsGroup.IsOn)
            {
                GroupIndex = Guid.NewGuid().ToString();
            }
            else
            {
                GroupIndex = "0";
            }
        }
        #endregion

        #region 添加医嘱
        bool IsInputRight()
        {
            if (txtStandingFlag.Tag == null)
            {
                this.SetCurrentInput(0);
                return false;
            }
            if (this.txtAdviceType.Tag == null)
            {
                this.SetCurrentInput(1);
                return false;
            }
            if (this.txtAdviceName.Tag == null)
            {
                this.SetCurrentInput(2);
                return false;
            }
            Data.iCode AdvictType = txtAdviceType.Tag as Data.iCode;
            if (AdvictType.Code == "901001" || AdvictType.Code == "901003")
            {
                if (txtDosage.Text.Trim().Length == 0)
                {
                    this.SetCurrentInput(3);
                    return false;
                }
                else if (txtUsage.Tag == null)
                {
                    this.SetCurrentInput(4);
                    return false;
                }
                else if (this.txtFrequence.Tag == null)
                {
                    this.SetCurrentInput(5);
                    return false;
                }
            }
            return true;
        }
        private void btnAddAdvice_Click(object sender, RoutedEventArgs e)
        {
            if (!IsInputRight()) return;
            AddAdvice();
        }
        ObservableCollection<Data.PadAdvice> AdviceList = new ObservableCollection<Data.PadAdvice>();
        void AddAdvice()
        {
            Data.PadAdvice padAdvice = new Data.PadAdvice();
            padAdvice.PAID = Guid.NewGuid().ToString();
            padAdvice.DeviceID = CJia.MobileMedicalDoctor.iCommon.DeviceID;
            padAdvice.InhosID = iCommon.Patient.InhosID;
            padAdvice.PatientName = iCommon.Patient.PatientName;
            padAdvice.DoctorID = CJia.MobileMedicalDoctor.iCommon.DoctorID;
            padAdvice.DoctorName = CJia.MobileMedicalDoctor.iCommon.DoctorName;
            Data.iCode AdviceType = txtAdviceType.Tag as Data.iCode;
            padAdvice.AdviceTypeCode = AdviceType.Code;
            padAdvice.AdviceTypeName = AdviceType.Name;
            Data.iCode StandingFlag = this.txtStandingFlag.Tag as Data.iCode;
            padAdvice.StandingTypeCode = StandingFlag.Code;
            padAdvice.StandingTypeName = StandingFlag.Name;
            Data.iAdvice Advice = this.txtAdviceName.Tag as Data.iAdvice;
            padAdvice.AdviceID = Advice.AID;
            padAdvice.HiSAdviceID = Advice.AdviceID;
            padAdvice.AdviceName = Advice.AdviceName;
            padAdvice.CommonName = Advice.CommonName;
            padAdvice.Spec = Advice.Spec;
            padAdvice.GroupIndex = GroupIndex;
            padAdvice.Dosage = txtDosage.Text.Trim();
            padAdvice.DosageUnit = Advice.Unit;
            padAdvice.Amount = "1";
            padAdvice.AmountUnit = Advice.Unit;
            Data.iUsage iu = txtUsage.Tag as Data.iUsage;
            if (iu != null)
            {
                padAdvice.UsageID = iu.UsageID;
                padAdvice.UsageName = iu.UsageName;
            }
            Data.iFrequency iq = txtFrequence.Tag as Data.iFrequency;
            if (iq != null)
            {
                padAdvice.FrequenceID = iq.FrequencyID;
                padAdvice.FrequenceName = iq.FrequencyName;
            }
            padAdvice.PreStartDate = "";
            padAdvice.PreStopDate = "";
            padAdvice.Notes = txtNotes.Text.Trim();
            padAdvice.AdviceShowName = padAdvice.AdviceName + " (" + padAdvice.Spec + ") " + padAdvice.Dosage + padAdvice.DosageUnit;
            padAdvice.CreateDate = CJia.MobileMedicalDoctor.iCommon.DateNow;
            padAdvice.Status = "有效";
            padAdvice.SyncStatus = "未同步";
            padAdvice.SyncDate = "";
            AdviceList.Add(padAdvice);
            listNewAdvice.ItemsSource = AdviceList;
            ClearAdvice();
            txtAdviceName.Focus(FocusState.Programmatic);
        }

        void ClearAdvice()
        {
            txtUsage.Tag = txtFrequence.Tag = null;
            txtAdviceName.Text = txtDosage.Text = txtUsage.Text = txtFrequence.Text = txtSpec.Text = txtUnit.Text = txtNotes.Text = "";
            this.SetCurrentInput(2);
        }
        private void btnDeleteAdvice_Click(object sender, RoutedEventArgs e)
        {
            if (listNewAdvice.SelectedItem == null) return;
            Data.PadAdvice advice = listNewAdvice.SelectedItem as Data.PadAdvice;
            AdviceList.Remove(advice);
        }
        #endregion

        #region 保存医嘱
        private void btnSaveAdvice_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SaveAdvice();
        }

        private void SaveAdvice()
        {
            AdviceArgs.ListNewAdvice = AdviceList;
            OnSaveAdvice(null, AdviceArgs);
        }
        public event EventHandler<Views.AdviceInputEventArgs> OnSaveAdvice;

        public void ExeEndSaveAdvice(bool Result, string SaveMsg)
        {
            if (Result)
            {
                ClearAdvice();
                AdviceList.Clear();
                ShowMessage("保存成功。");
            }
            else
            {
                ShowMessage("保存失败。" + Environment.NewLine + SaveMsg);
            }
        }
        #endregion

        private void btnNextInput_Click(object sender, RoutedEventArgs e)
        {
            NextInput();
        }

        private void NextInput()
        {
            if (CurrentInputIndex == InputDict.Count - 1)
            {
                ListDict[CurrentInputIndex].Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnAddAdvice.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                return;
            }
            CurrentInputIndex++;
            SetCurrentInput(CurrentInputIndex);
        }

        private void btnPrevInput_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputIndex == 0) return;
            CurrentInputIndex--;
            SetCurrentInput(CurrentInputIndex);
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (ListDict[CurrentInputIndex] != null)
            {
                if (ListDict[CurrentInputIndex].Visibility == Windows.UI.Xaml.Visibility.Collapsed)
                {
                    ListDict[CurrentInputIndex].Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    if (ListDict[CurrentInputIndex].ItemsSource == null || ListDict[CurrentInputIndex].Items.Count == 0)
                        return;

                    if (ListDict[CurrentInputIndex].SelectedIndex == ListDict[CurrentInputIndex].Items.Count - 1)
                    {
                        ListDict[CurrentInputIndex].SelectedIndex = 0;
                    }
                    else
                        ListDict[CurrentInputIndex].SelectedIndex++;
                }
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (ListDict[CurrentInputIndex] != null)
            {
                if (ListDict[CurrentInputIndex].Visibility == Windows.UI.Xaml.Visibility.Collapsed)
                {
                    ListDict[CurrentInputIndex].Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    if (ListDict[CurrentInputIndex].ItemsSource == null || ListDict[CurrentInputIndex].Items.Count == 0)
                        return;

                    if (ListDict[CurrentInputIndex].SelectedIndex > 0)
                        ListDict[CurrentInputIndex].SelectedIndex--;
                }
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            ConfirmSelectItem();
        }

        private void ConfirmSelectItem()
        {
            if (ListDict[CurrentInputIndex] != null)
            {
                if (ListDict[CurrentInputIndex].SelectedItem != null)
                {
                    InputDict[CurrentInputIndex].Tag = ListDict[CurrentInputIndex].SelectedItem;
                    InputDict[CurrentInputIndex].Text = ListDict[CurrentInputIndex].SelectedItem.ToString();
                    if (CurrentInputIndex == 2)
                    { //医嘱
                        Data.iAdvice advice = InputDict[CurrentInputIndex].Tag as Data.iAdvice;
                        this.txtSpec.Text = advice.Spec;
                        this.txtUnit.Text = advice.Unit;
                        if (advice.DefaultDosage.Length > 0 && Convert.ToDecimal(advice.DefaultDosage) > 0)
                            this.txtDosage.Text = advice.DefaultDosage;
                        if (advice.DefaultUsage.Length > 0)
                        {
                            Data.iUsage iu = this.UsageData.Find(ud => ud.UsageID == advice.DefaultUsage);
                            if (iu != null)
                            {
                                this.txtUsage.Text = iu.UsageName;
                                this.txtUsage.Tag = iu;
                            }
                        }
                        if (advice.DefaultFrequency.Length > 0)
                        {
                            Data.iFrequency fq = this.FrequenceData.Find(fd => fd.FrequencyID == advice.DefaultFrequency);
                            if (fq != null)
                            {
                                this.txtFrequence.Text = fq.FrequencyName;
                                this.txtUsage.Tag = fq;
                            }
                        }
                    }
                    NextInput();
                }
            }
        }

        private void txtAdviceType_TextChanged(object sender, TextChangedEventArgs e)
        {
            listAdviceType.ItemsSource = iCommon.iCodeList.FindAll(c => c.GroupName == "医嘱类别" && c.Code2.IndexOf(txtAdviceType.Text) >= 0);
        }

        private void txtAdviceName_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterAdvice();
        }

        private void txtUsage_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.listUsage.ItemsSource = UsageData.FindAll(ud => ud.UsageFilter.IndexOf(txtUsage.Text) >= 0);
        }

        private void txtFrequence_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.listFrequancy.ItemsSource = FrequenceData.FindAll(fd => fd.FrequencyFilter.IndexOf(txtFrequence.Text) >= 0);
        }

        private void gridMain_Tapped(object sender, TappedRoutedEventArgs e)
        {
            object o = e.OriginalSource;
            if (o is Windows.UI.Xaml.Controls.Grid)
            {
                if (ListDict[CurrentInputIndex] != null)
                    ListDict[CurrentInputIndex].Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void TextInput_GotFocus(object sender, RoutedEventArgs e)
        {
            this.CurrentInputIndex = (sender as TextBox).TabIndex;
            SetCurrentInput(CurrentInputIndex);
            if (ListDict[CurrentInputIndex] != null)
            {
                ListDict[CurrentInputIndex].Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ConfirmSelectItem();
        }
    }
}
