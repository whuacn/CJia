using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CJia.HISOLAP.Tools
{
    /// <summary>
    /// 消息提示
    /// </summary>
    public sealed class Message
    {
        /// <summary>
        /// 显示按钮
        /// </summary>
        public enum Button
        {
            /// <summary>
            /// 是/否
            /// </summary>
            YesNo = 1,
            /// <summary>
            /// 是/否/取消
            /// </summary>
            YesNoCancel = 2,
            /// <summary>
            /// 确定/取消
            /// </summary>
            OkCancel = 3,
            /// <summary>
            /// 重试/取消
            /// </summary>
            RetryCancel = 4
        }
        /// <summary>
        /// 消息结果
        /// </summary>
        public enum Result
        {
            /// <summary>
            /// 是
            /// </summary>
            Yes = 1,
            /// <summary>
            /// 否
            /// </summary>
            No = 2,
            /// <summary>
            /// 确定
            /// </summary>
            Ok = 3,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel = 4,
            /// <summary>
            /// 重试
            /// </summary>
            Retry = 5,
            /// <summary>
            /// 空
            /// </summary>
            None = 6
        }
        private Message()
        { 
        
        }
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="MsgHint">提示信息</param>
        public static void Show(string MsgHint)
        {
            MessageBox.Show(MsgHint, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="MsgWarning">警告信息</param>
        public static void ShowWarning(string MsgWarning)
        {
            MessageBox.Show(MsgWarning, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// 显示停止信息
        /// </summary>
        /// <param name="MsgStop">停止信息</param>
        public static void ShowStop(string MsgStop)
        {
            MessageBox.Show(MsgStop, "停止", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        /// <summary>
        /// 显示询问消息(缺省显示Ok/Cancel)
        /// </summary>
        /// <param name="MsgQuery">询问消息</param>
        /// <returns>消息结果</returns>
        public static Result ShowQuery(string MsgQuery)
        {
            return ShowQuery(MsgQuery, Button.OkCancel);
        }
        /// <summary>
        /// 显示询问消息
        /// </summary>
        /// <param name="MsgQuery">询问消息</param>
        /// <param name="ShowButton">消息类型</param>
        /// <returns>消息结果</returns>
        public static Result ShowQuery(string MsgQuery, Button ShowButton)
        {
            DialogResult result = DialogResult.None;
            switch (ShowButton)
            {
                case Button.OkCancel:
                    result = MessageBox.Show(MsgQuery, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    break;
                case Button.YesNo:
                    result = MessageBox.Show(MsgQuery, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case Button.YesNoCancel:
                    result = MessageBox.Show(MsgQuery, "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    break;
                case Button.RetryCancel:
                    result = MessageBox.Show(MsgQuery, "确认", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                    break;
                default:
                    result = MessageBox.Show(MsgQuery, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    break;
            }
            switch (result)
            {
                case DialogResult.OK: return Result.Ok;
                case DialogResult.Cancel: return Result.Cancel;
                case DialogResult.Yes: return Result.Yes;
                case DialogResult.No: return Result.No;
                case DialogResult.Retry: return Result.Retry;
                case DialogResult.None: return Result.None;
                default: return Result.None;
            }
        }
    }   
}
