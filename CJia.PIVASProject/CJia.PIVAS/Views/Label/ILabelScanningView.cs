﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.Label
{
    /// <summary>
    /// 瓶贴扫描接口
    /// </summary>
    public interface ILabelScanningView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化病区
        /// </summary>
        event EventHandler<LabelScanningEventArgs> OnInitIffield;

        /// <summary>
        /// 初始化批次
        /// </summary>
        event EventHandler<LabelScanningEventArgs> OnInitBacth;

        /// <summary>
        /// 获取瓶贴列表
        /// </summary>
        event EventHandler<LabelScanningEventArgs> OnQueryLabeList;

        /// <summary>
        /// 获取某条条形码对应的瓶贴
        /// </summary>
        event EventHandler<LabelScanningEventArgs> OnQueryBarCodeLabe;

        /// <summary>
        /// 修改瓶贴条形码状态
        /// </summary>
        event EventHandler<LabelScanningEventArgs> OnUpdateBarCode;

        /// <summary>
        /// 瓶贴从新打印
        /// </summary>
        event EventHandler<LabelScanningEventArgs> OnAnewPrintLabel; 

        /// <summary>
        /// 初始化病区绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitIffield(DataTable result);

        /// <summary>
        /// 初始化批次绑定回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeInitBacth(DataTable result);

        /// <summary>
        /// 查询打印了的瓶贴列表
        /// </summary>
        /// <param name="result"></param>
        void ExeQueryLabelList(DataTable result);

        /// <summary>
        /// 获取某条条形码对应的瓶贴
        /// </summary>
        /// <param name="result"></param>
        void ExeQueryBarCodeLabel(DataTable result);

    }

    /// <summary>
    /// 瓶贴扫描参数类
    /// </summary>
    public class LabelScanningEventArgs : EventArgs
    {

        /// <summary>
        /// 打印时间
        /// </summary>
        public string Date;

        /// <summary>
        /// 扫描类型 0 入仓扫描   1 出仓扫描
        /// </summary>
        public string ScenningType;

        /// <summary>
        /// 病区id
        /// </summary>
        public string IffieldID;

        /// <summary>
        /// 批次id
        /// </summary>
        public string BacthID;

        /// <summary>
        /// 瓶贴条形码号
        /// </summary>
        public string BarCode;

        /// <summary>
        /// 修改的瓶贴状态
        /// </summary>
        public string BarCodeStatus;
    }
}