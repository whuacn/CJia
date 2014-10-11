using CJia.Evaluation.Views.FrontStage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CJia.Evaluation.Web.FrontStage
{
    public partial class FirstOne : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.FrontStage.IFirstOne
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session.Clear();
                RemoveAllSession();
                if (Request.QueryString["id"] != null)
                {
                    args.treeID = CJia.Evaluation.Tools.Utils.AESDecrypt(Request.QueryString["id"].Replace(' ', '+'));
                    OnInit(null, args);
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.FrontStage.FirstOnePresenter(this);
        }
        FirstOneArgs args = new FirstOneArgs();
        public event EventHandler<FirstOneArgs> OnInit;
        public event EventHandler<FirstOneArgs> OnGetTreeByPatID;
        public event EventHandler<FirstOneArgs> OnGetZLByID;
        public event EventHandler<FirstOneArgs> OnGetAnotherZLByID;
        public event EventHandler<FirstOneArgs> OnGetParentByID;
        public void ExeBindParentData(DataTable data)
        {
            Session["ParentData"] = new DataTable();
            Session["ParentData"] = data;
        }
        public void ExeBindAnotherZLData(DataTable data)
        {
            Session["AnotherZLData"] = new DataTable();
            Session["AnotherZLData"] = data;
        }
        public void ExeBindZLData(DataTable data)
        {
            dataRep1.DataSource = data;
            dataRep1.DataBind();
        }
        public void ExeBindABCData(DataTable data, DataTable selfData)
        {
            if (Session["ZiLiao"] == null && data != null)
            {
                Session["ZiLiao"] = new DataTable();//存放评审资料
                Session["ZiLiao"] = data.Clone();
            }
            if (Session["ZiLiao"] == null && selfData != null)
            {
                Session["ZiLiao"] = new DataTable();//存放评审资料
                Session["ZiLiao"] = selfData.Clone();
            }
            if (data != null)
            {
                DataTable newData = Session["ZiLiao"] as DataTable;
                foreach (DataRow dr in data.Rows)
                {
                    newData.Rows.Add(dr.ItemArray);
                }
                Session["ZiLiao"] = newData;
            }
            if (selfData != null)
            {
                DataTable newData = Session["ZiLiao"] as DataTable;
                foreach (DataRow dr in selfData.Rows)
                {
                    newData.Rows.Add(dr.ItemArray);
                }
                Session["ZiLiao"] = newData;
            }
            Session["ABCData"] = new DataTable();
            Session["ABCData"] = data;
        }
        public void ExeBindData(DataTable data, DataTable patdata)
        {
            Session["TreeData"] = new DataTable();
            Session["TreeData"] = data;
            title.InnerText = patdata.Rows[0]["COLUMN_TREE_NAME"].ToString() + " " + patdata.Rows[0]["COLUMN_DESCRIPTION"].ToString();
            if (data == null) return;
            DataRow[] drs = data.Select(" LV='1'");
            if (drs.Length > 0)
                myli.InnerHtml = "&nbsp;" + drs[0]["COLUMN_TREE_NAME"].ToString() + " " + drs[0]["COLUMN_DESCRIPTION"].ToString();
            DataRow[] drs1 = data.Select(" LV='2'");
            if (drs1.Length > 0)
            {
                if (drs1[0]["COLUMN_GRADE"].ToString() == "1102")
                    subContent.InnerHtml = "<span>" + drs1[0]["COLUMN_TREE_NAME"].ToString() + "</span>" + drs1[0]["COLUMN_DESCRIPTION"].ToString() + "(★)";
                else
                    subContent.InnerHtml = "<span>" + drs1[0]["COLUMN_TREE_NAME"].ToString() + "</span>" + drs1[0]["COLUMN_DESCRIPTION"].ToString();
            }
            DataRow[] drs2 = data.Select(" LV='3'");
            if (drs2.Length > 0)
            {
                DataTable abcData = data.Clone();
                foreach (DataRow dr in drs2)
                {
                    abcData.Rows.Add(dr.ItemArray);
                }
                abcRep.DataSource = abcData;
                abcRep.DataBind();
            }
            if (Session["ZiLiao"] != null)//评审资料目录
            {
                DataTable ZLData = Session["ZiLiao"] as DataTable;
                FirstContent = ZLData.Rows[0]["COLUMN_TREE_NAME"].ToString();
                args.treeID = ZLData.Rows[0]["COLUMN_TREE_ID"].ToString();
                OnGetZLByID(null, args);//获得资料
                ZLData.Rows.RemoveAt(0);
                sub_list2.DataSource = ZLData;
                sub_list2.DataBind();
                dataRep2.DataSource = ZLData;
                dataRep2.DataBind();
            }
        }
        public string FirstContent;
        public int SubNum = 1;
        public int GetSubNum()
        {
            int i = SubNum;
            SubNum++;
            return i;
        }
        public string GetHref(string id, string content, string name)
        {
            StringBuilder str = new StringBuilder("当前位置:");
            args.treeID = id;
            OnGetParentByID(null, args);
            DataTable data = Session["ParentData"] as DataTable;
            if (data != null && data.Rows.Count > 0)
            {
                data.Rows.RemoveAt(0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (i == 1)
                    {
                        str.Append(data.Rows[i]["COLUMN_TREE_NAME"].ToString() + "&nbsp;" + data.Rows[i]["COLUMN_DESCRIPTION"].ToString() + "&nbsp;" + "&gt;&gt;" + "&nbsp;");
                    }
                    else
                    {
                        str.Append(data.Rows[i]["COLUMN_TREE_NAME"].ToString() + "&nbsp;" + "&gt;&gt;" + "&nbsp;");
                    }
                }
                str.Append("正文");
            }
            string title = CJia.Evaluation.Tools.Utils.AESEncrypt(str.ToString());
            content = CJia.Evaluation.Tools.Utils.AESEncrypt(content);
            name = CJia.Evaluation.Tools.Utils.AESEncrypt(name);
            return "DownLoad.aspx?title=" + title + "&txt=" + content + "&name=" + name;
        }
        public void RemoveAllSession()
        {
            Session["ZiLiao"] = null;
            Session["TreeData"] = null;
            Session["AnotherZLData"] = null;
            Session["ABCData"] = null;
            Session["ParentData"] = null;
        }
        public string GetABC(string treeID)
        {
            StringBuilder content = new StringBuilder("");
            if (Session["TreeData"] != null)
            {
                DataTable data = Session["TreeData"] as DataTable;
                DataRow[] dr1 = data.Select(" COLUMN_TREE_ID='" + treeID + "'");
                content.Append("<label class='ontitle' style='cursor:pointer' title='" + dr1[0]["CHECK_WAY"] + "'>【" + dr1[0]["COLUMN_TREE_NAME"].ToString() + "】" + dr1[0]["COLUMN_DESCRIPTION"].ToString() + "</label>" + "<br />");
            }
            args.treeID = treeID;
            OnGetTreeByPatID(null, args);
            DataTable abcData = Session["ABCData"] as DataTable;
            if (abcData != null && abcData.Rows.Count > 0)
            {
                for (int i = 0; i < abcData.Rows.Count; i++)
                {
                    if (i == abcData.Rows.Count - 1)
                    {
                        content.Append("<label class='ontitle' style='cursor:pointer' title='" + abcData.Rows[i]["SCR_STD"] + "'>" + abcData.Rows[i]["COLUMN_NO"].ToString() + "." + abcData.Rows[i]["COLUMN_DESCRIPTION"].ToString() + "</label>");
                    }
                    else
                    {
                        content.Append("<label class='ontitle' style='cursor:pointer' title='" + abcData.Rows[i]["SCR_STD"] + "'>" + abcData.Rows[i]["COLUMN_NO"].ToString() + "." + abcData.Rows[i]["COLUMN_DESCRIPTION"].ToString() + "</label>" + "<br />");
                    }
                }
            }
            return content.ToString();
        }
        protected void dataRep2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = (Repeater)e.Item.FindControl("dataRep");
                string id = ((DataRowView)e.Item.DataItem)["COLUMN_TREE_ID"].ToString();
                args.treeID = id;
                OnGetAnotherZLByID(null, args);
                rep.DataSource = Session["AnotherZLData"] as DataTable;
                rep.DataBind();
            }
        }
    }
}