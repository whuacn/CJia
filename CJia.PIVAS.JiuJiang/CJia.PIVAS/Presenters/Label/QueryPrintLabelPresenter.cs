using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace CJia.PIVAS.Presenters.Label
{
    /// <summary>
    /// ��ѯƿ��Presenter��
    /// </summary>
    public class QueryPrintLabelPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.Label.QueryPrintLabelModel, CJia.PIVAS.Views.Label.IQueryPrintLabelView>
    {
        /// <summary>
        /// ��ѯƿ��Presenter�㹹�캯��
        /// </summary>
        /// <param name="view"></param>
        public QueryPrintLabelPresenter(CJia.PIVAS.Views.Label.IQueryPrintLabelView view)
            : base(view)
        {
            this.View.OnInitIffield += View_OnInitIffield;
            this.View.OnInitBacth += View_OnInitBacth;
            this.View.OnInitUsage += View_OnInitUsage;
            //this.View.OnQueryArrangeEvent += View_QueryArrangeEvent;
            //this.View.OnModifFilterArrange += View_ModifFilterArrange;
            //this.View.OnQueryLabelCollect += View_QueryLabelCollect;
            this.View.OnQueryLabelDetails += View_QueryLabelDetails;
            this.View.OnQueryLabelDetailsInfo += View_QueryLabelDetailsInfo;

            this.View.OnUpdateLabelExeStatus += View_OnUpdateLabelExeStatus;
            //this.View.OnQueryAlllIffieldBachLabelCollect += View_QueryAlllIffieldBachLabelCollect;
            this.View.OnQueryPharmCollect += View_OnQueryPharmCollect;
            this.View.OnGetLabelBarcode += View_OnGetLabelBarcode;
            this.View.OnUpdateLabelPrintStatus += View_OnUpdateLabelPrintStatus;
            this.View.OnUpdateBarCode += View_OnUpdateBarCode;
            this.View.OnDeleteLabel += View_OnDeleteLabel;
            this.View.OnPharmFee += View_OnPharmFee;
            this.View.OnFeeTIME += View_OnFeeTIME;


            this.View.OnGenLabel += View_OnGenLabel;
            this.View.OnLabelIsFee += View_OnLabelIsFee;

            this.View.OnLabelPharmCount += View_OnLabelPharmCount;
        }









        /// <summary>
        /// ���¹�View��
        /// </summary>
        protected override void OnInitView()
        {
            base.OnInitView();
        }

        #region �����¼�

        /// <summary>
        /// ����ƿ���᲻��ʹҩƷ��治��
        /// </summary>
        /// <param name="labelId"></param>
        object View_OnLabelPharmCount(object labelId)
        {
            return this.Model.QueryLabelPharmCount(labelId.ToString());
        }

        //�޸�ƿ����ҩ״̬
        void View_OnUpdateLabelExeStatus(object labelId)
        {
            CJia.PIVAS.Models.PIVASModel.ExecuteLabelFee(labelId.ToString());
        }

        // ��ѯƿ���Ŀ۷Ѵ���
        object View_OnLabelIsFee(object labelId)
        {
            return this.Model.QueryLabelTimes(labelId.ToString());
        }

        //����ƿ��
        void View_OnGenLabel(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            //this.Model.InserLabel(e.IllfieldId, e.batchid, e.printType);
            DataTable result = this.Model.InserLabel(e.selectDate, e.grOrDr, e.groupIndexBatchid);
            //this.View.ExeBindingLabelDetailsInfo(result);
        }

        //��ʼ�������¼��󶨷���
        void View_OnInitBacth(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitBacth(Common.GetBatch());
        }

        //��ʼ�������¼��󶨷���
        void View_OnInitIffield(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitIffield(Common.GetIllfield());
        }

        //��ʼ����ҩ;���¼��󶨷���
        void View_OnInitUsage(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitUsage(Common.GetUsage());
        }

        //��ѯƿ������
        void View_QueryLabelDetails(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            DataTable result = this.Model.QueryLabelDetail(e.grOrDr, e.selectDate, e.IllfieldId, e.batchid, e.printType, e.longTemporary, e.useCheckData, e.CheckDataStart, e.CheckDataEnd,e.UsageId);
            this.View.ExeBindingLabelDetails(result);
        }

        //��ѯҩƷ������Ϣ
        void View_OnQueryPharmCollect(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            //DataTable result = this.Model.QueryPharmCollect(e.IllfieldId, e.batchid, e.printType);
            DataTable result = this.Model.QueryPharmCollect(e.grOrDr, e.selectDate, e.IllfieldId, e.batchid, e.printType, e.longTemporary, e.useCheckData, e.CheckDataStart, e.CheckDataEnd,e.UsageId);
            this.View.ExeBindingPharmCollect(result);
        }

        //public DataTable OnQueryPharmCollect(Views.Label.QueryPrintLabelViewEventArgs e)
        //{
        //    //DataTable result = this.Model.QueryPharmCollect(e.IllfieldId, e.batchid, e.printType);
        //    DataTable result = this.Model.QueryPharmCollect(e.grOrDr, e.selectDate, e.IllfieldId, e.batchid, e.printType, e.longTemporary, e.useCheckData, e.CheckDataStart, e.CheckDataEnd);
        //    return result;
        //}

        //��ѯƿ��������Ϣ ���ڴ�ӡƿ��
        void View_QueryLabelDetailsInfo(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            DataTable result = this.Model.QueryGenLabel(e.selectDate, e.grOrDr, e.IllfieldId, e.batchid, e.printType, e.useCheckData, e.CheckDataStart, e.CheckDataEnd);
            this.View.ExeBindingLabelDetailsInfo(result);
        }





        //��ȡ�۷�ʱ��
        object View_OnFeeTIME(object feeTime)
        {
            return CJia.PIVAS.Models.PIVASModel.QueryFeeTime(feeTime.ToString());
        }

        //�۷ѿۿ��
        object View_OnPharmFee(object groupIndex, object openDate, object count)
        {
            return CJia.PIVAS.Models.PIVASModel.ExecuteGroupIndexFee(groupIndex.ToString(), CJia.PIVAS.User.hisUserId.ToString(), (DateTime)openDate, (int)count, 0);
        }

        //����ƿ��
        void View_OnDeleteLabel(object parameter1)
        {
            string labelId = parameter1.ToString();
            this.Model.DeleteLabel(labelId, CJia.PIVAS.User.UserId);
        }

        //�޸�������״̬
        void View_OnUpdateBarCode(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            this.Model.UpdateBarCodeStatus(e.LabelId);
        }

        //��ƿ����Ϣ���������������������id
        object View_OnGetLabelBarcode(object parameter1, object parameter2, object parameter3)
        {
            return this.Model.GetLabelBarcode(parameter1, parameter2, parameter3, CJia.PIVAS.User.UserId);
        }

        //�޸�ƿ����ӡ״̬
        void View_OnUpdateLabelPrintStatus(object labelId, object date)
        {
            this.Model.UpdateLabelPrintStatus(labelId, (DateTime)date);
        }

        //��ѯ���в������εİ�ҩ����Ϣ
        void View_QueryAlllIffieldBachLabelCollect(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.PharmType != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.PharmType.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        PharmTypes.Add(a.Value);
                    }
                }
            }

            List<object> Bacths = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bacths.Add(a.Value);
                    }
                }
            }

            List<object> Bens = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.IllfileBens != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bens.Add(a.Value);
                    }
                }
            }

            List<object> OrderBy = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.UseOrderBy != null)
            {
                foreach (string a in CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items)
                {
                    if (a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type asc ");
                    else if (a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type desc ");
                    else if (a == "ƿ������[����]")
                        OrderBy.Add(" spl.batch_id asc ");
                    else if (a == "ƿ������[����]")
                        OrderBy.Add("  spl.batch_id desc ");
                    else if (a == "��������[����]")
                        OrderBy.Add(" spl.illfield_name asc ");
                    else if (a == "��������[����]")
                        OrderBy.Add(" spl.illfield_name desc ");
                }
            }
            OrderBy.Add(" spl.LABEL_ID asc ");
            DataTable result = this.Model.QueryAllIllfieldBacthLabelCollectByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens, OrderBy);
            this.View.ExeBindingAlllIffieldBachLabelCollect(result);
        }

        //�޸Ĺ�������
        void View_ModifFilterArrange(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            CJia.PIVAS.Tools.LabelFilter.ArrangeIds = e.SelectArrangeIdList;
            this.InitIffieldBen(this.Model.QuseryIffieldBed(e.SelectArrangeIdList));
        }

        //��ʼ��ʱ��󶨷���
        void View_Load(object sender, EventArgs e)
        {
            this.InitFilter();
            this.InitIffieldBen(null);
        }





        //��ѯƿ������
        void View_QueryLabelCollect(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = this.GetPharmTypeFilter();
            List<object> Bacths = this.GetBacthsFilter();
            List<object> Bens = this.GetBensFilter();
            DataTable result = this.Model.QueryLabelCollectByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens);
            this.View.ExeBindingLabelCollect(result);
        }

        //��ѯ��ҩ���¼��󶨷���
        void View_QueryArrangeEvent(object sender, Views.Label.QueryPrintLabelViewEventArgs e)
        {
            CJia.PIVAS.Tools.LabelFilter.SelectDate = e.QueryTime;
            DataTable result = this.Model.QueryArrangeCollect(e.QueryTime);
            this.View.ExeBindingArrange(result);
        }

        #endregion

        #region ��������

        /// <summary>
        /// ��ȡҩƷ���͹�������
        /// </summary>
        /// <returns></returns>
        public List<object> GetPharmTypeFilter()
        {
            List<object> PharmTypes = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.PharmType != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.PharmType.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        PharmTypes.Add(a.Value);
                    }
                }
            }
            return PharmTypes;
        }

        /// <summary>
        /// ��ȡ���ι�������
        /// </summary>
        /// <returns></returns>
        public List<object> GetBacthsFilter()
        {
            List<object> Bacths = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bacths.Add(a.Value);
                    }
                }
            }
            return Bacths;
        }

        /// <summary>
        /// ��ȡ��λ��������
        /// </summary>
        /// <returns></returns>
        public List<object> GetBensFilter()
        {
            List<object> Bens = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.IllfileBens != null)
            {
                foreach (CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items)
                {
                    if (a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bens.Add(a.Value);
                    }
                }
            }
            return Bens;
        }

        /// <summary>
        /// ��ȡ����ʽ
        /// </summary>
        /// <returns></returns>
        public List<object> GetOrderByFilter()
        {
            List<object> OrderBy = new List<object>();
            if (CJia.PIVAS.Tools.LabelFilter.UseOrderBy != null)
            {
                foreach (string a in CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items)
                {
                    if (a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type asc ");
                    else if (a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type desc ");
                    else if (a == "ƿ������[����]")
                        OrderBy.Add(" spl.batch_id asc ");
                    else if (a == "ƿ������[����]")
                        OrderBy.Add("  spl.batch_id desc ");
                    else if (a == "��������[����]")
                        OrderBy.Add(" spl.illfield_name asc ");
                    else if (a == "��������[����]")
                        OrderBy.Add(" spl.illfield_name desc ");
                }
            }
            return OrderBy;
        }




        // ��ʼ��������Ϣ
        void InitFilter()
        {
            DataTable allPharmType = this.Model.QueryAllPharmType();
            DataTable allBacth = this.Model.QueryAllBacth();
            CJia.PIVAS.Tools.LabelFilter.IsInit = true;
            CJia.PIVAS.Tools.LabelFilter.ArrangeIds = new List<object>();
            CJia.PIVAS.Tools.LabelFilter.PharmType = new DevExpress.XtraEditors.CheckedListBoxControl();
            foreach (DataRow pharmType in allPharmType.Rows)
            {
                CJia.PIVAS.Tools.LabelFilter.PharmType.Items.Add(pharmType["CODE"].ToString(), pharmType["NAME"].ToString(), System.Windows.Forms.CheckState.Checked, true);
            }

            CJia.PIVAS.Tools.LabelFilter.LabelBacth = new DevExpress.XtraEditors.CheckedListBoxControl();
            foreach (DataRow batch in allBacth.Rows)
            {
                CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items.Add(batch["BATCH_ID"].ToString(), batch["BATCH_NAME"].ToString(), System.Windows.Forms.CheckState.Checked, true);
            }
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy = new DevExpress.XtraEditors.ListBoxControl();
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("ҩƷ����[����]");
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("ҩƷ����[����]");
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("ƿ������[����]");
            CJia.PIVAS.Tools.LabelFilter.NoUseOrderBy.Items.Add("��������[����]");
            CJia.PIVAS.Tools.LabelFilter.UseOrderBy = new DevExpress.XtraEditors.ListBoxControl();
            CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items.Add("��������[����]");
            CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items.Add("ƿ������[����]");
        }

        //��ʼ��������λ
        void InitIffieldBen(DataTable result)
        {
            CJia.PIVAS.Tools.LabelFilter.IllfileBens = new DevExpress.XtraEditors.CheckedListBoxControl();
            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    string value = "\'" + row["ILLFIELD_ID"].ToString() + "\'," + (row["BED_ID"].ToString() == "" ? "null" : row["BED_ID"].ToString());
                    string text = row["ILLFIELD_NAME"].ToString() + " " + (row["BED_NAME"].ToString() == "" ? "�ղ���" : row["BED_NAME"].ToString());
                    if (CJia.PIVAS.Tools.LabelFilter.IllfileBens.FindString(text) == -1)
                    {
                        CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items.Add(value, text, System.Windows.Forms.CheckState.Checked, true);
                    }
                }
            }
        }

        #endregion

    }
}