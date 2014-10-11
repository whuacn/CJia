using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditUnit : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.EditUnitArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.EditUnitArgs> OnSave;

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="unitType">类型</param>
        /// <param name="IDType">证件类型</param>
        /// <param name="ecoType">经济类型</param>
        /// <param name="applyType">申请类别</param>
        void ExeBindDropDown(DataTable unitType, DataTable IDType, DataTable ecoType, DataTable applyType);

        /// <summary>
        /// 绑定控件值
        /// </summary>
        /// <param name="dtUnit">根据单位ID所查出的单位信息</param>
        void ExeBindControl(DataTable dtUnit);

         /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        void ExeMessageBox(string message, bool isCloseWindow);
    }

    public class EditUnitArgs : EventArgs
    {
        /// <summary>
        /// 所编辑单位ID
        /// </summary>
        public string UnitId;

        /// <summary>
        /// 许可证号
        /// </summary>
        public string XukeZhenhao;

        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName;

        /// <summary>
        /// 单位类型
        /// </summary>
        public string UnitType;

        /// <summary>
        /// 是否户源
        /// </summary>
        public string IsHuYuan;

        /// <summary>
        /// 户类型
        /// </summary>
        public string HuType;

        /// <summary>
        /// 所属区县
        /// </summary>
        public string QuXianNO;

        /// <summary>
        /// 注册地址
        /// </summary>
        public string ZhuCeAddress;

        /// <summary>
        /// 代码
        /// </summary>
        public string DaiMa;

        /// <summary>
        /// 法人
        /// </summary>
        public string FaRen;

        /// <summary>
        /// 法人证型
        /// </summary>
        public string FaRenType;

        /// <summary>
        /// 法人证号
        /// </summary>
        public string FaRenNO;

        /// <summary>
        /// 负责人
        /// </summary>
        public string FuZeRen;

        /// <summary>
        /// 负责人证型
        /// </summary>
        public string FuZeRenType;

        /// <summary>
        /// 负责人证号
        /// </summary>
        public string FuZeRenNO;

        /// <summary>
        /// 经济类型（国有全资，股份合作，私有。。。）
        /// </summary>
        public string JingjiType;

        /// <summary>
        /// 联系人
        /// </summary>
        public string LianxiRen;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string LianxiTelePhone;

        /// <summary>
        /// 邮编
        /// </summary>
        public string YouBian;

        /// <summary>
        /// 地址
        /// </summary>
        public string Address;

        /// <summary>
        /// 发证机构名称
        /// </summary>
        public string FaZhenName;

        /// <summary>
        /// 申请类别
        /// </summary>
        public string ShenQingType;

        /// <summary>
        /// 许可日期
        /// </summary>
        public DateTime? XuKeData;

        /// <summary>
        /// 有效期始
        /// </summary>
        public DateTime? StartData;

        /// <summary>
        /// 有效期至
        /// </summary>
        public DateTime? EndData;

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable User;
    }
}
