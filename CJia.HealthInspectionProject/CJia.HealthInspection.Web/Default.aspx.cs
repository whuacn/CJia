using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExtAspNet;

namespace CJia.HealthInspection.Web
{
    public partial class Default :CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IDefault
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    tbt_Clock.Text = DateTime.Now.ToString();
                    tbt_Info.Text = "【用户：" + (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString() + "】";
                    btn_ChangePassword.OnClientClick = this.win_ChangePassword.GetShowReference();
                    btn_EndLogin.Click+=btn_EndLogin_Click;
                    //btn_EndLogin.OnClientClick = "top.location='LoginView.aspx';";
                }
            }
        }
        
        protected override object CreatePresenter()
        {
            return new Presenters.DefaultPresenter(this);
        }

        #region Events事件

        protected void btn_EndLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginView.aspx");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Ok", "top.location='LoginView.aspx';", true);
            //Response.Write("  <script type='text/javascript'>alert('123')</script>");
        }
        protected void btn_ReloadMenu_Click(object sender, EventArgs e)
        {
           
        }
        protected void btn_Reload_Click(object sender, EventArgs e)
        {
            
        }
        protected void tir_Main_Tick(object sender, EventArgs e)
        {
            
        }

        Views.DefaultArgs defaultArgs = new Views.DefaultArgs();

        // 菜单加载
        protected void ren_Left_Init(object sender, EventArgs e)
        {
            DataTable dtUser = (DataTable)Session["User"];
            if (dtUser != null)
            {
                if (dtUser.Rows.Count > 0)
                {
                    defaultArgs.LoginUserId = dtUser.Rows[0]["user_id"].ToString();
                    OnQueryFunctionByUserId(null, defaultArgs);
                    DataTable dtFun = defaultArgs.UserFunction;
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    if (dtFun != null && dtFun.Rows.Count > 0)
                    {
                        tree_MBasic.Nodes.Clear();
                        tree_MBusiness.Nodes.Clear();
                        tree_MArticle.Nodes.Clear();
                        tree_MInfo.Nodes.Clear();
                        tree_MGoods.Nodes.Clear();
                        tree_MDept.Nodes.Clear();
                        tree_MUser.Nodes.Clear();
                        tree_MSystem.Nodes.Clear();
                        tree_Suppter.Nodes.Clear();

                        for (int i = 0; i < dtFun.Rows.Count; i++)
                        {
                            switch (dtFun.Rows[i]["function_id"].ToString())
                            {
                                // 单位
                                case "1":
                                    
                                    break;
                                // 新增单位
                                case "21":
                                    CreateTree("2_1", tree_MBasic, ap_MBasic, "新增单位", "Icons/world_connect.png", "UI/Unit/AddUnit.aspx");
                                    break;
                                // 单位管理
                                case "22":
                                    CreateTree("2_2", tree_MBasic, ap_MBasic, "单位管理", "Icons/textfield_key.png", "UI/Unit/UnitSelect.aspx");
                                    break;
                                // 行政处罚
                                case "2":
                                   
                                    break;
                                // 执行监督
                                case "23":
                                    CreateTree("2_3", tree_MBusiness, ap_MBusiness, "执行监督", "Icons/world_connect.png", "UI/Supervise/ExeCheck.aspx");
                                    break;
                                // 执行任务
                                case "24":
                                    CreateTree("2_4", tree_MBusiness, ap_MBusiness, "执行任务", "Icons/textfield_key.png", "UI/ExeTask/ExeTask.aspx");
                                    break;
                                // 监督记录
                                case "25":
                                    CreateTree("2_5", tree_MBusiness, ap_MBusiness, "监督记录", "Icons/world_connect.png", "UI/QueryCheckTask/QueryCheck.aspx");
                                    break;
                                // 任务记录
                                case "26":
                                    CreateTree("2_6", tree_MBusiness, ap_MBusiness, "任务记录", "Icons/textfield_key.png", "UI/QueryCheckTask/QueryExeTask.aspx");
                                    break;
                                // 模版
                                case "3":
                                    
                                    break;
                                // 新增模版
                                case "27":
                                    CreateTree("2_7", tree_MArticle, ap_MArticle, "新增模版", "Icons/world_connect.png", "UI/Template/AddTemplate.aspx");
                                    break;
                                // 模版管理
                                case "28":
                                    CreateTree("2_8", tree_MArticle, ap_MArticle, "模版管理", "Icons/textfield_key.png", "UI/Template/TemplateManage.aspx");
                                    break;
                                // 任务
                                case "4":
                                   
                                    break;
                                // 任务下达
                                case "29":
                                    CreateTree("2_9", tree_MInfo, ap_MInfo, "任务下达", "Icons/build.png", "UI/Task/PublishTask.aspx");
                                    break;
                                // 任务查询
                                case "30":
                                    CreateTree("3_0", tree_MInfo, ap_MInfo, "任务查询", "Icons/brick_magnify.png", "UI/Task/QueryTask.aspx");
                                    break;
                                // 题目
                                case "5":
                                   
                                    break;
                                // 新增题目
                                case "31":
                                    CreateTree("3_1", tree_MGoods, ap_MGoods, "新增题目", "Icons/textfield_key.png", "UI/CheckTitle/AddCheckTitle.aspx");
                                    break;
                                // 题目管理
                                case "32":
                                    CreateTree("3_2", tree_MGoods, ap_MGoods, "题目管理", "Icons/textfield_key.png", "UI/CheckTitle/CheckTitleSelect.aspx");
                                    break;
                                // 部门
                                case "7":
                                    
                                    break;
                                // 新增部门
                                case "36":
                                    CreateTree("3_6", tree_MDept, ap_MDept, "新增部门", "Icons/textfield_key.png", "UI/Dept/AddDept.aspx");
                                    break;
                                // 部门查询
                                case "37":
                                    CreateTree("3_7", tree_MDept, ap_MDept, "部门查询", "Icons/textfield_key.png", "UI/Dept/QueryDept.aspx");
                                    break;
                                //法律法规
                                case "8":
                                    
                                    break;
                                // 查看法律法规
                                case "41":
                                    CreateTree("4_1", tree_MUser, ap_MUser, "查看法律法规", "Icons/textfield_key.png", "UI/Low/Low.aspx");
                                    break;
                                // 上传法律法规
                                case "42":
                                    CreateTree("4_2", tree_MUser, ap_MUser, "上传法律法规", "Icons/textfield_key.png", "UI/Low/UpLoadLowFile.aspx");
                                    break;
                                // 系统设置
                                case "9":
                                    
                                    break;
                                // 角色管理
                                case "45":
                                    CreateTree("4_5", tree_MSystem, ap_MSystem, "角色管理", "Icons/key.png", "UI/Role/QueryRole.aspx");
                                    break;
                                case "46":
                                    CreateTree("4_6", tree_MSystem, ap_MSystem, "人员管理", "Icons/group.png", "UI/User/QueryUser.aspx");
                                    break;
                                // 超级设置
                                case "10":
                                  
                                    break;
                                // 组织管理
                                case "43":
                                    CreateTree("4_3", tree_Suppter, ap_Suppter, "组织管理", "Icons/chart_organisation.png", "UI/Organ/QueryOrgan.aspx");
                                    break;
                                // 用户管理
                                case "44":
                                    CreateTree("4_4", tree_Suppter, ap_Suppter, "用户管理", "Icons/user_suit.png", "UI/User/QuerySupervise.aspx");
                                    break;
                            }
                        }
                    }
                }
               
            }
        }
        #endregion

        #region【自定义方法】

        /// <summary>
        /// 设置菜单栏
        /// </summary>
        /// <param name="tree"></param>
        void SetTreeNull(Tree tree)
        {
            tree.Nodes.Clear();
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="tree">对应菜单树</param>
        /// <param name="ap">对应菜单选项卡</param>
        /// <param name="title">菜单名称</param>
        /// <param name="iconUrl">图标路径</param>
        /// <param name="navigateUrl">导航路径</param>
        private void CreateTree(string nodeId, Tree tree, AccordionPane ap, string title, string iconUrl, string navigateUrl)
        {
           
            ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            node.NodeID = nodeId;
            node.Text = title;
            node.IconUrl = iconUrl;
            node.NavigateUrl = navigateUrl;
            tree.Nodes.Add(node);
            ap.Hidden = false;
            ap.Expanded = false;
            ap.Expanded = true;
        }
        #endregion

        #region【接口事件】

        /// <summary>
        /// 查询登录用户所拥有功能
        /// </summary>
        public event EventHandler<Views.DefaultArgs> OnQueryFunctionByUserId;
        #endregion

    }
}