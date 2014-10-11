//***************************************************
// 文件名（File Name）:      IProjectView.cs
//
// 表（Tables）:          
//                          
// 视图（Views）:           
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.4.8
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Views
{
    /// <summary>
    /// 项目接口层
    /// </summary>
    public interface IProjectView:CJia.PEIS.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<ProjectEventArgs> OnInit;

        /// <summary>
        /// 添加项目事件
        /// </summary>
        event EventHandler<ProjectEventArgs> OnAddPro;

        /// <summary>
        /// 插入项目事件
        /// </summary>
        event EventHandler<ProjectEventArgs> OnInsertPro;

        /// <summary>
        /// 添加控件预设值
        /// </summary>
        event EventHandler<ProjectEventArgs> OnAddControlDefault;

        /// <summary>
        /// 修改项目事件
        /// </summary>
        event EventHandler<ProjectEventArgs> OnUpdatePro;

        /// <summary>
        /// 停用项目事件
        /// </summary>
        event EventHandler<ProjectEventArgs> OnStopPro;

        /// <summary>
        /// 启用项目事件
        /// </summary>
        event EventHandler<ProjectEventArgs> OnReStartPro;

        /// <summary>
        /// 单击网格事件
        /// </summary>
        event EventHandler<ProjectEventArgs> OnGridProjectClick;

        /// <summary>
        /// 删除控件预设值
        /// </summary>
        event EventHandler<ProjectEventArgs> OnDeleteControlValue;

        /// <summary>
        /// 点击树状结构查询所选中科室下属项目
        /// </summary>
        event EventHandler<ProjectEventArgs> OnAfterFocusNodeDeptPro;

        /// <summary>
        /// 绑定科室项目
        /// </summary>
        /// <param name="dtDeptProInfo">科室及所属项目信息</param>
        void ExeDeptProBindTree(DataTable dtDeptProInfo);

        /// <summary>
        /// 绑定排序号
        /// </summary>
        /// <param name="dtProSortNo"></param>
        void ExeBindProSortNo(long proSortNo);

        /// <summary>
        /// 绑定Grid项目数据
        /// </summary>
        /// <param name="dtGridPro"></param>
        void ExeBindGridProject(DataTable dtGridPro);

        /// <summary>
        /// 网格所选项目状态
        /// </summary>
        /// <param name="proStatus"></param>
        void ExeSelectProStatus(string proStatus);

        /// <summary>
        /// 显示控件预设值
        /// </summary>
        /// <param name="dtControlValue"></param>
        void ExeShowControlValue(DataTable dtControlValue);

        #region 下拉框绑定
        /// <summary>
        /// 项目类型
        /// </summary>
        /// <param name="dtProType"></param>
        void ExeBindProType(DataTable dtProType);

        /// <summary>
        /// 短信设置
        /// </summary>
        /// <param name="dtSmsSet"></param>
        void ExeBindSmsSet(DataTable dtSmsSet);

        /// <summary>
        /// 是否餐前项目
        /// </summary>
        /// <param name="dtBeforeMeal"></param>
        void ExeBindBeforeMeal(DataTable dtBeforeMeal);

        /// <summary>
        /// 适用性别
        /// </summary>
        /// <param name="dtApplyGender"></param>
        void ExeBindApplyGender(DataTable dtApplyGender);

        /// <summary>
        /// 费用类别
        /// </summary>
        /// <param name="dtCostType"></param>
        void ExeBindCostType(DataTable dtCostType);

        /// <summary>
        /// 标本种类
        /// </summary>
        /// <param name="dtSpeciesType"></param>
        void ExeBindSpeciesType(DataTable dtSpeciesType);

        /// <summary>
        /// 计量单位
        /// </summary>
        /// <param name="dtUnitMeasurement"></param>
        void ExeBindUnitMeasurement(DataTable dtUnitMeasurement);

        /// <summary>
        /// 常用项目类别
        /// </summary>
        /// <param name="dtCommonProType"></param>
        void ExeBindCommonProType(DataTable dtCommonProType);

        /// <summary>
        /// 控件类型
        /// </summary>
        /// <param name="dtControlType"></param>
        void ExeBindControlType(DataTable dtControlType);
        #endregion
    }

    /// <summary>
    /// 参数类
    /// </summary>
    public class ProjectEventArgs : EventArgs
    {
        #region gm_project表数据
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProName = "";

        /// <summary>
        /// 排序号
        /// </summary>
        public long SortNo = 0;

        /// <summary>
        /// 项目首拼
        /// </summary>
        public string ProFirstPinyin = "";

        /// <summary>
        /// 项目英文名
        /// </summary>
        public string ProEnglishName = "";

        /// <summary>
        /// 项目类别
        /// </summary>
        public int ProType = 0;

        /// <summary>
        /// 项目所属科室
        /// </summary>
        public long DeptId = 0;

        /// <summary>
        /// 项目执行科室
        /// </summary>
        public long ExecuteId = 0;

        /// <summary>
        /// 常用项目类别
        /// </summary>
        public int CommonProType = 0;

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue = "";

        /// <summary>
        /// 计量单位
        /// </summary>
        public int UnitMeasurement = 0;

        /// <summary>
        /// 适用性别
        /// </summary>
        public int ApplyGender = 0;

        /// <summary>
        /// 费用类别（费用归类）
        /// </summary>
        public int CostType = 0;

        /// <summary>
        /// 控件类型
        /// </summary>
        public int ControlType = 0;

        /// <summary>
        /// 新添加控件预设值名称
        /// </summary>
        public string ControlDefaultName = "";

        /// <summary>
        /// 控件宽度
        /// </summary>
        public double ControlTypeWidth = 0;

        /// <summary>
        /// 是否是输入项目（0代表否，1代表是）
        /// </summary>
        public string IsInputPro = "0";

        /// <summary>
        /// 父节点ID
        /// </summary>
        public long ParentId = 0;

        /// <summary>
        /// 是否为收费项目（0代表否，1代表是）
        /// </summary>
        public string IsFeePro = "0";

        /// <summary>
        /// 是否为餐前项目
        /// </summary>
        public int BeroreMeal = 0;
        
        /// <summary>
        /// 是否有短信设置
        /// </summary>
        public int SmsSet = 0;

        /// <summary>
        /// 是否直接从Lis或Ris读取数据（0代表否，1代表是）
        /// </summary>
        public string IsReadDataDirect = "0";

        /// <summary>
        /// Lis对应项目ID
        /// </summary>
        public long LisCorrespondProId = 0;

        /// <summary>
        /// Lis对应项目名称
        /// </summary>
        public string LisCorresPondProName = "";
        
        /// <summary>
        /// Lis项目ID
        /// </summary>
        public long LisProId = 0;

        /// <summary>
        /// Lis项目名称
        /// </summary>
        public string LisProName = "";

        /// <summary>
        /// His对应项目ID
        /// </summary>
        public long HisCorrespondProId = 0;

        /// <summary>
        /// His对应项目名称
        /// </summary>
        public string HisCorresPondProName = "";

        /// <summary>
        /// His项目ID
        /// </summary>
        public long HisProId = 0;

        /// <summary>
        /// His项目名称
        /// </summary>
        public string HisProName = "";

        /// <summary>
        /// His首拼
        /// </summary>
        public string HisFirstPinyin = "";

        /// <summary>
        /// 参考价格
        /// </summary>
        public double ReferencePrice = 0;

        /// <summary>
        /// 执行价格
        /// </summary>
        public double ExecutePrice = 0;

        /// <summary>
        /// 是否为数值型项目（0代表否，1代表是）
        /// </summary>
        public string IsNumericalPro = "0";

        /// <summary>
        /// 标本种类
        /// </summary>
        public int SpeciesType = 0;

        /// <summary>
        /// 综述时是否必须显示（0代表否，1代表是）
        /// </summary>
        public string IsSumMust = "0";

        /// <summary>
        /// 参考上限（男）
        /// </summary>
        public double RefUpMail = 0;

        /// <summary>
        /// 参考上限（女）
        /// </summary>
        public double RefUpFemail = 0;

        /// <summary>
        /// 参考上限提示
        /// </summary>
        public string RefUpPrompt = "";

        /// <summary>
        /// 参考下限（男）
        /// </summary>
        public double RefLowerMail = 0;

        /// <summary>
        /// 参考下限（女）
        /// </summary>
        public double RefLowerFemail = 0;

        /// <summary>
        /// 参考下限提示
        /// </summary>
        public string RefLowerPrompt = "";

        /// <summary>
        /// 报警上限（男）
        /// </summary>
        public double AlarmUpMail = 0;

        /// <summary>
        /// 报警上限（女）
        /// </summary>
        public double AlarmUpFemail = 0;

        /// <summary>
        /// 报警上限提示
        /// </summary>
        public string AlarmUpPrompt = "";

        /// <summary>
        /// 报警下限（男）
        /// </summary>
        public double AlarmLowerMail = 0;

        /// <summary>
        /// 报警下限（女）
        /// </summary>
        public double AlarmLowerFemail = 0;

        /// <summary>
        /// 报警下限提示
        /// </summary>
        public string AlarmLowerPrompt = "";

        #endregion

        #region gm_controls_default控件预设值表数据

        /// <summary>
        /// 所属项目ID
        /// </summary>
        public long ProId = 0;

        /// <summary>
        /// 是否为项目默认值（0代表否，1代表是）
        /// </summary>
        public string IsDefaultValue = "0";

        /// <summary>
        /// 是否被勾选中（0代表否，1代表是）
        /// </summary>
        public string IsChecked = "0";

       
        /// <summary>
        /// 所添加控件预设值
        /// </summary>
        public DataTable AddControlValue = new DataTable();

        /// <summary>
        /// 删除控件预设值
        /// </summary>
        public DataTable DeleteControlValue = new DataTable();

        /// <summary>
        /// 修改控件预设值
        /// </summary>
        public DataTable UpdateControlValue = new DataTable();
        #endregion
    }
}
