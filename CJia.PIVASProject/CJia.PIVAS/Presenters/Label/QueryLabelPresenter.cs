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
    public class QueryLabelPresenter:CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.Label.QueryLabelModel,CJia.PIVAS.Views.Label.IQueryLabelView>
    {
        /// <summary>
        /// ��ѯƿ��Presenter�㹹�캯��
        /// </summary>
        /// <param name="view"></param>
        public QueryLabelPresenter(CJia.PIVAS.Views.Label.IQueryLabelView view)
            : base(view)
        {
            this.View.Load += View_Load;
            this.View.OnQueryArrangeEvent += View_QueryArrangeEvent;
            this.View.OnModifFilterArrange += View_ModifFilterArrange;
            this.View.OnQueryLabelCollect += View_QueryLabelCollect;
            this.View.OnQueryLabelDetails += View_QueryLabelDetails;
            this.View.OnQueryLabelDetailsInfo += View_QueryLabelDetailsInfo;
            this.View.OnQueryAlllIffieldBachLabelCollect += View_QueryAlllIffieldBachLabelCollect;
            this.View.OnQueryPharmCollect += View_OnQueryPharmCollect;
            this.View.OnGetLabelBarcode += View_OnGetLabelBarcode;
            this.View.OnUpdateLabelPrintStatus += View_OnUpdateLabelPrintStatus;
        }





        /// <summary>
        /// ���¹�View��
        /// </summary>
        protected override void OnInitView()
        {
              base.OnInitView();
        }

        #region �����¼�
        
        //��ƿ����Ϣ���������������������id
        object View_OnGetLabelBarcode(object parameter1, object parameter2, object parameter3)
        {
            return this.Model.GetLabelBarcode(parameter1, parameter2, parameter3, CJia.PIVAS.User.UserId);
        }

        //�޸�ƿ����ӡ״̬
        void View_OnUpdateLabelPrintStatus(object parameter1)
        {
            this.Model.UpdateLabelPrintStatus(parameter1);
        }

        //��ѯҩƷ������Ϣ
        void View_OnQueryPharmCollect(object sender, Views.Label.QueryLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = this.GetPharmTypeFilter();
            List<object> Bacths = this.GetBacthsFilter();
            List<object> Bens = this.GetBensFilter();
            List<object> OrderBy = this.GetOrderByFilter();
            OrderBy.Add(" spl.LABEL_ID asc ");
            DataTable result = this.Model.QueryPharmCollect(SelectArrangeIdList, PharmTypes, Bacths, Bens, OrderBy);
            this.View.ExeBindingPharmCollect(result);

        }

        //��ѯ���в������εİ�ҩ����Ϣ
        void View_QueryAlllIffieldBachLabelCollect(object sender, Views.Label.QueryLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = new List<object>();
            if(CJia.PIVAS.Tools.LabelFilter.PharmType != null)
            {
                foreach(CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.PharmType.Items)
                {
                    if(a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        PharmTypes.Add(a.Value);
                    }
                }
            }

            List<object> Bacths = new List<object>();
            if(CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach(CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if(a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bacths.Add(a.Value);
                    }
                }
            }

            List<object> Bens = new List<object>();
            if(CJia.PIVAS.Tools.LabelFilter.IllfileBens != null)
            {
                foreach(CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items)
                {
                    if(a.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        Bens.Add(a.Value);
                    }
                }
            }

            List<object> OrderBy = new List<object>();
            if(CJia.PIVAS.Tools.LabelFilter.UseOrderBy != null)
            {
                foreach(string a in CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items)
                {
                    if(a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type asc ");
                    else if(a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type desc ");
                    else if(a == "ƿ������[����]")
                        OrderBy.Add(" spl.batch_id asc ");
                    else if(a == "ƿ������[����]")
                        OrderBy.Add("  spl.batch_id desc ");
                    else if(a == "��������[����]")
                        OrderBy.Add(" spl.illfield_name asc ");
                    else if(a == "��������[����]")
                        OrderBy.Add(" spl.illfield_name desc ");
                }
            }
            OrderBy.Add(" spl.LABEL_ID asc ");
            DataTable result = this.Model.QueryAllIllfieldBacthLabelCollectByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens, OrderBy);
            this.View.ExeBindingAlllIffieldBachLabelCollect(result);
        }

        //�޸Ĺ�������
        void View_ModifFilterArrange(object sender, Views.Label.QueryLabelViewEventArgs e)
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
        void View_QueryLabelDetails(object sender, Views.Label.QueryLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = this.GetPharmTypeFilter();
            List<object> Bacths = this.GetBacthsFilter();
            List<object> Bens = this.GetBensFilter();
            List<object> OrderBy = this.GetOrderByFilter();
            OrderBy.Add(" spl.LABEL_ID asc ");
            DataTable result = this.Model.QueryLabelDetailByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens, OrderBy);
            this.View.ExeBindingLabelDetails(result);
        }

        //��ѯƿ��������Ϣ ���ڴ�ӡƿ��
        void View_QueryLabelDetailsInfo(object sender, Views.Label.QueryLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = this.GetPharmTypeFilter();
            List<object> Bacths = this.GetBacthsFilter();
            List<object> Bens = this.GetBensFilter();
            List<object> OrderBy = this.GetOrderByFilter();
            OrderBy.Add(" spl.LABEL_ID asc ");
            OrderBy.Add(" spld.his_advice_id  asc ");
            DataTable result = this.Model.QueryLabelDetailInfoByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens, OrderBy);
            this.View.ExeBindingLabelDetailsInfo(result);
        }

        //��ѯƿ������
        void View_QueryLabelCollect(object sender, Views.Label.QueryLabelViewEventArgs e)
        {
            List<object> SelectArrangeIdList = CJia.PIVAS.Tools.LabelFilter.ArrangeIds;
            List<object> PharmTypes = this.GetPharmTypeFilter();
            List<object> Bacths = this.GetBacthsFilter();
            List<object> Bens = this.GetBensFilter();
            DataTable result = this.Model.QueryLabelCollectByArrangeId(SelectArrangeIdList, PharmTypes, Bacths, Bens);
            this.View.ExeBindingLabelCollect(result);
        }

        //��ѯ��ҩ���¼��󶨷���
        void View_QueryArrangeEvent(object sender, Views.Label.QueryLabelViewEventArgs e)
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
            if(CJia.PIVAS.Tools.LabelFilter.PharmType != null)
            {
                foreach(CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.PharmType.Items)
                {
                    if(a.CheckState == System.Windows.Forms.CheckState.Checked)
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
            if(CJia.PIVAS.Tools.LabelFilter.LabelBacth != null)
            {
                foreach(CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.LabelBacth.Items)
                {
                    if(a.CheckState == System.Windows.Forms.CheckState.Checked)
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
            if(CJia.PIVAS.Tools.LabelFilter.IllfileBens != null)
            {
                foreach(CheckedListBoxItem a in CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items)
                {
                    if(a.CheckState == System.Windows.Forms.CheckState.Checked)
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
            if(CJia.PIVAS.Tools.LabelFilter.UseOrderBy != null)
            {
                foreach(string a in CJia.PIVAS.Tools.LabelFilter.UseOrderBy.Items)
                {
                    if(a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type asc ");
                    else if(a == "ҩƷ����[����]")
                        OrderBy.Add(" spl.pivas_pharm_type desc ");
                    else if(a == "ƿ������[����]")
                        OrderBy.Add(" spl.batch_id asc ");
                    else if(a == "ƿ������[����]")
                        OrderBy.Add("  spl.batch_id desc ");
                    else if(a == "��������[����]")
                        OrderBy.Add(" spl.illfield_name asc ");
                    else if(a == "��������[����]")
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
            foreach(DataRow pharmType in allPharmType.Rows)
            {
                CJia.PIVAS.Tools.LabelFilter.PharmType.Items.Add(pharmType["CODE"].ToString(), pharmType["NAME"].ToString(), System.Windows.Forms.CheckState.Checked, true);
            }

            CJia.PIVAS.Tools.LabelFilter.LabelBacth = new DevExpress.XtraEditors.CheckedListBoxControl();
            foreach(DataRow batch in allBacth.Rows)
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
            if(result != null && result.Rows.Count > 0)
            {
                foreach(DataRow row in result.Rows)
                {
                    string value = "\'" + row["ILLFIELD_ID"].ToString() + "\'," + (row["BED_ID"].ToString() == "" ? "null" : row["BED_ID"].ToString());
                    string text = row["ILLFIELD_NAME"].ToString() + " " + (row["BED_NAME"].ToString() == "" ? "�ղ���" : row["BED_NAME"].ToString());
                    if(CJia.PIVAS.Tools.LabelFilter.IllfileBens.FindString(text) == -1)
                    {
                        CJia.PIVAS.Tools.LabelFilter.IllfileBens.Items.Add(value, text, System.Windows.Forms.CheckState.Checked, true);
                    }
                }
            }
        }

        #endregion

    }
}