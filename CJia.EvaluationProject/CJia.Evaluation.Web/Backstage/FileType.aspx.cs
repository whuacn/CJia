using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExtAspNet;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class FileType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshTemplate();
            }
        }

        protected void btn_Add_Type_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddEditFileType.aspx?OperType=Insert", "新增类型"));
        }

        private void initFileType(DataTable data)
        {
        }
        /// <summary>
        /// 获得类型列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable data = ad.Query(@"select * from GM_TYPE where type_code='10' and status='1'", null);
                return data;
            }
        }

        /// <summary>
        ///删除类型
        /// </summary>
        /// <returns></returns>
        bool DelFileTypeData(string TypeID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlParams = new object[1] { TypeID };
                return ad.Execute(@"update gm_type set status='0' where type_id=?", sqlParams) > 0 ? true : false;
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshTemplate()
        {
            //string nodeID = tree_Main.SelectedNodeID;
            DataTable data = GetData();
            gr_Main.RecordCount = data.Rows.Count;
            gr_Main.DataSource = data.DefaultView;
            gr_Main.DataBind();
        }


        protected void win_Edit_Close(object sender, WindowCloseEventArgs e)
        {
            RefreshTemplate();
        }

        protected void btn_Edit_Type_Click(object sender, EventArgs e)
        {
            int[] selectIndex = gr_Main.SelectedRowIndexArray;
            if (selectIndex.Length > 0)
            {
                object[] ob = gr_Main.DataKeys[selectIndex[0]];
                string TypeId = ob[0].ToString();
                string TypeValue = ob[1].ToString();
                PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddEditFileType.aspx?OperType=Update&TypeID=" + TypeId + "&TypeValue=" + TypeValue, "编辑"));
            }
            else
            {
                Alert.ShowInTop("请选择需要编辑的类型!", MessageBoxIcon.Warning);
            }
        }

        protected void btn_Delete_Type_Click(object sender, EventArgs e)
        {
            int[] selectIndex = gr_Main.SelectedRowIndexArray;
            if (selectIndex.Length > 0)
            {
                object[] ob = gr_Main.DataKeys[selectIndex[0]];
                string TypeId = ob[0].ToString();
                bool bol = DelFileTypeData(TypeId);
                if (bol)
                {
                    ExtAspNet.Alert.ShowInTop("删除成功！", ExtAspNet.MessageBoxIcon.Information);
                    RefreshTemplate();
                }
                else
                {
                    ExtAspNet.Alert.ShowInTop("删除失败！", ExtAspNet.MessageBoxIcon.Error);
                }
            }
            else
            {
                Alert.ShowInTop("请选择需要删除的类型!", MessageBoxIcon.Warning);
            }
        }
    }
}