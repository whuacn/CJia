using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Views
{
    /// <summary>
    /// 操作员管理IView层
    /// </summary>
    public interface IAdminHandleView : CJia.PEIS.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<AdminHandleEventArgs> OnLoad;
        /// <summary>
        /// 删除用户事件
        /// </summary>
        event EventHandler<AdminHandleEventArgs> OnDelete;
        /// <summary>
        /// 保存修改用户事件
        /// </summary>
        event EventHandler<AdminHandleEventArgs> OnSave;
        /// <summary>
        /// 重置密码事件
        /// </summary>
        event EventHandler<AdminHandleEventArgs> OnResetPassword;
        /// <summary>
        /// 用户数据网格点击事件
        /// </summary>
        event EventHandler<AdminHandleEventArgs> OnGridClick;
        /// <summary>
        /// 是否显示停用用户事件
        /// </summary>
        event EventHandler<AdminHandleEventArgs> OnCheck;
        /// <summary>
        /// 搜索框按钮点击事件
        /// </summary>
        event EventHandler<AdminHandleEventArgs> OnBtnSearchClick;
        /// <summary>
        /// 初始化
        /// </summary>
        void ExeInitialize(DataTable genderData, DataTable userData, DataTable userStausData);
        /// <summary>
        /// 绑定用户信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindUserInfo(DataTable data);
        /// <summary>
        /// 绑定所有用户
        /// </summary>
        /// <param name="data"></param>
        void ExeBindAllUser(DataTable data);
        /// <summary>
        /// 工号输入框获得焦点
        /// </summary>
        void ExeTxtUserNOFocus();
    }
    /// <summary>
    /// 操作员管理参数
    /// </summary>
    public class AdminHandleEventArgs : EventArgs
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID = 0;
        /// <summary>
        /// 用户工号
        /// </summary>
        public string UserNo;
        /// <summary>
        /// 修改之前的工号
        /// </summary>
        public string OldUserNo;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName;
        /// <summary>
        /// 性别
        /// </summary>
        public int UserGender;
        /// <summary>
        /// 状态(正常或者停用)
        /// </summary>
        public int UserStatus;
        /// <summary>
        /// 电话号码
        /// </summary>
        public string UserPhone;
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UserWorkUnit;
        /// <summary>
        /// 签名图片
        /// </summary>
        public byte[] UserSignImage;
        /// <summary>
        /// 头像
        /// </summary>
        public byte[] UserImage;
        /// <summary>
        /// 用户名拼音
        /// </summary>
        public string UserNameSpell;
        /// <summary>
        /// 是否显示停用用户
        /// </summary>
        public bool isShowNoUse = false;
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keys = "";
    }
}
