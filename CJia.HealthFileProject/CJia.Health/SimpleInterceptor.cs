using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health
{
    public class SimpleInterceptor : StandardInterceptor
    {
        //protected override void PreProceed(IInvocation invocation)
        //{
        //    Console.WriteLine("调用前的拦截器，方法名是：{0}。", invocation.Method.Name);
        //    base.PreProceed(invocation);

        //}

        //protected override void PerformProceed(IInvocation invocation)
        //{
        //    Console.WriteLine("拦截的方法返回时调用的拦截器，方法名是：{0}。", invocation.Method.Name);
        //    base.PerformProceed(invocation);

        //}


        protected override void PostProceed(IInvocation invocation)
        {
            //Console.WriteLine("调用后的拦截器，方法名是：{0}。", invocation.Method.Name);
            switch (invocation.Method.Name)
            {
                case "view_OnLogin":
                    Views.LoginEventArgs e = (Views.LoginEventArgs)invocation.Arguments[1];
                    Tools.Help.TraceContext("view_OnLogin", "登入系统", "【" + e.UserNo + "】登入系统", e.UserNo, e.UserNo);
                    break;
                case "View_OnSavePatientInfo":
                    Views.NewPatientInfoInputEventArgs e2 = (Views.NewPatientInfoInputEventArgs)invocation.Arguments[1];
                    Tools.Help.TraceContext("View_OnSavePatientInfo", "病人信息录入", "【2】录入病人信息", e2.PatientId, e2.PatientName);
                    break;
                default:
                    break;
            }
            base.PostProceed(invocation);

        }
    }
}
