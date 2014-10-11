using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace CJia.HISOLAP.Presenters
{
    public class CheckReportPresenter : Tools.Presenter<Models.CheckReportModel, Views.ICheckReportView>
    {
        public CheckReportPresenter(Views.ICheckReportView view)
            : base(view)
        {
            view.OnInitView += view_OnInitView;
            view.OnSearch += view_OnSearch;
            view.OnCheckData += view_OnCheckData;
            view.OnReportData += view_OnReportData;
        }

        void view_OnReportData(object sender, Views.CheckReportArgs e)
        {
            //判断审核结果数据源中有无强制类型
            if (CanReport(e.CheckResultPatientData))
            {
                if (Message.ShowQuery("确定上报数据？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                    {
                        Tools.Loading load = new Tools.Loading();
                        Tools.Help.NewRedBorderShowFrom(load);
                        Application.DoEvents();
                        bool isSuccess = true;
                        foreach (DataRow dr in e.PatientData.Rows)
                        {
                            //将非强制类型病人copy到本地库
                            DataTable data = Model.GetMyPatient(dr["P3"].ToString(), dr["P2"].ToString());
                            if (data.Rows.Count == 0)  //本地库无此病人
                            {
                                Model.AddPatient(trans.ID, dr);
                            }
                            isSuccess = Model.ModifyPatientReportState(trans.ID, dr["P3"].ToString(), dr["P2"].ToString());
                            if (!isSuccess) break;
                        }
                        load.ParentForm.Close();
                        bool bol = View.ExeBindIsSuccessReport(isSuccess);
                        if (bol)
                        {
                            trans.Complete();
                            Message.Show("上报数据成功！");
                        }
                        else
                        {
                            Message.Show("上报数据失败！");
                        }
                    }
                }
            }
            //修改病人审核状态，上报过的不能继续上报
            //修改病人上报状态
            //生成DBF文件
        }

        void view_OnCheckData(object sender, Views.CheckReportArgs e)
        {
            if (e.PatientData != null && e.PatientData.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();
                Tools.Loading load = new Tools.Loading();
                Tools.Help.NewRedBorderShowFrom(load);
                Application.DoEvents();
                foreach (DataRow patDr in e.PatientData.Rows)
                {
                    Model.AddInToTemp(patDr);//将数据插入临时表
                }
                load.ParentForm.Close();
                //foreach (DataRow patDr in e.PatientData.Rows)
                //{
                //    DataTable data = Model.GetMyPatient(patDr["P3"].ToString(), patDr["P2"].ToString());
                //    if (data.Rows.Count > 0)  //本地库有此病人
                //    {
                //        string checkState = data.Rows[0]["CHECK_STATE"].ToString(); //审核状态
                //        if (checkState == "1") //已通过审核
                //        {
                //            drList.Add(patDr);  //去除已审核通过的病人
                //        }
                //        //调用此方法注意：视图中病人的字段顺序一定要和本地病人表中字段顺序一致
                //        //Model.AddPatient(trans.ID, patDr); //将此病人copy到本地库
                //    }
                //}
                DataTable data = Model.GetTempPatient();
                data.DefaultView.Sort = "P3";
                DataTable newData = data.DefaultView.ToTable();
                newData.Columns.Remove("CHECK_STATE");
                newData.Columns.Remove("REPORT_STATE");
                //if (drList != null && drList.Count > 0)
                //{
                //    foreach (DataRow dr in drList)
                //    {
                //        e.PatientData.Rows.Remove(dr);
                //    }
                //}
                //e.PatientData = data;
                DataTable resultData = CheckOut2(newData); //审核
                View.ExeBindCheckResult(resultData);
                Model.DeleteTable();//删除临时表数据
            }
        }

        void view_OnSearch(object sender, Views.CheckReportArgs e)
        {
            DataTable data = Model.GetPatient(e.StartDate, e.EndDate);//今创
            DataTable myDate = Model.GetMyPatient(e.StartDate, e.EndDate);//本地库
            List<DataRow> drList = new List<DataRow>();
            foreach (DataRow dr in data.Rows)
            {
                foreach (DataRow myDr in myDate.Rows)
                {
                    if (myDr["P3"].ToString() == dr["P3"].ToString() && myDr["P2"].ToString() == dr["P2"].ToString())
                    {
                        if (myDr["REPORT_STATE"].ToString() == "1")//过滤已上报的病人
                        {
                            drList.Add(dr);
                        }
                    }
                }
            }
            if (drList != null && drList.Count > 0)
            {
                foreach (DataRow dr in drList)
                {
                    data.Rows.Remove(dr);
                }
            }
            DataView view = data.DefaultView;
            view.Sort = "P3";
            data = view.ToTable();
            View.ExeBindSearchResult(data);
        }

        void view_OnInitView(object sender, EventArgs e)
        {
            DataTable data = Model.GetCheckType();
            View.ExeBindCheckType(data);
        }
        /// <summary>
        /// 执行审核脚本（校验规则）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable CheckOut(DataTable data)
        {
            DataColumn checkID = new DataColumn("CHECK_ID", typeof(string));
            DataColumn checkName = new DataColumn("CHECK_NAME", typeof(string));
            DataColumn error = new DataColumn("CS_ERROR", typeof(string));
            DataColumn classify = new DataColumn("CHECK_CLASSIFY", typeof(string));
            if (data != null && data.Rows.Count > 0)
            {
                DataTable result = data.Clone();
                result.Columns.Add(checkID);
                result.Columns.Add(checkName);
                result.Columns.Add(error);
                result.Columns.Add(classify);
                DataTable script = Model.GetAllScript();
                if (script != null && script.Rows.Count > 0)
                {
                    CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在努力审核....", 0, data.Rows.Count);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        bool isCheckSuccess = true;
                        foreach (DataRow scriptDr in script.Rows)
                        {
                            //DataTable dt = new DataTable();
                            //dt = data.Clone();
                            //dt.ImportRow(data.Rows[i]);  //将DataRow转换成DataTable
                            //DataRow[] drs = dt.Select(scriptDr["CS_TEXT"].ToString());
                            DataTable viewData = Model.GetPatientInView(data.Rows[i]["P3"].ToString(), data.Rows[i]["P2"].ToString(), scriptDr["CS_TEXT"].ToString());
                            if (viewData.Rows.Count == 0)  //根据脚本没查到，证明审核不过
                            {
                                DataRow resultDr = result.NewRow();
                                resultDr["P3"] = data.Rows[i]["P3"]; //病案号
                                resultDr["P2"] = data.Rows[i]["P2"]; //次数
                                resultDr["CHECK_ID"] = scriptDr["CHECK_ID"];
                                resultDr["CHECK_NAME"] = scriptDr["CHECK_NAME"];
                                resultDr["CS_ERROR"] = scriptDr["CS_ERROR"];
                                resultDr["CHECK_CLASSIFY"] = scriptDr["CHECK_CLASSIFY"];
                                result.Rows.Add(resultDr);
                                isCheckSuccess = false;
                            }
                        }
                        if (isCheckSuccess) //审核通过，修改此病人审核状态为审核通过
                        {
                            Model.AddPatient(data.Rows[i]); //将此病人copy到本地库
                            //Model.ModifyPatientCheckState(data.Rows[i]["P3"].ToString(), data.Rows[i]["P2"].ToString());
                        }
                        waitUC.Do("执行进度(" + i + "/" + data.Rows.Count + ")");
                    }
                    waitUC.ParentForm.Close();
                    return result;
                }
            }
            return null;
        }
        /// <summary>
        /// 判断是否可以上报
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CanReport(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["CHECK_ID"].ToString() == "1001")  //存在强制性的审核类型，不能上报
                    {
                        Message.Show("审核结果中存在强制性审核类型错误,不允许上报");
                        return false;
                    }
                }
            }
            return true;
        }
        public DataTable CheckOut2(DataTable data)
        {
            DataColumn checkID = new DataColumn("CHECK_ID", typeof(string));
            DataColumn checkName = new DataColumn("CHECK_NAME", typeof(string));
            DataColumn error = new DataColumn("CS_ERROR", typeof(string));
            DataColumn classify = new DataColumn("CHECK_CLASSIFY", typeof(string));
            if (data != null && data.Rows.Count > 0)
            {
                DataTable result = data.Clone();
                result.Columns.Add(checkID);
                result.Columns.Add(checkName);
                result.Columns.Add(error);
                result.Columns.Add(classify);
                DataTable script = Model.GetAllScript();
                if (script != null && script.Rows.Count > 0)
                {
                    CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在努力审核....", 0, data.Rows.Count);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        bool isCheckSuccess = true;
                        long k = Model.GetCheckResult(data.Rows[i]["P3"].ToString(), data.Rows[i]["P2"].ToString());
                        string str = Convert.ToString(k, 2);//十进制>>二进制
                        if (str.Length > 0 && str != "0")
                        {
                            char[] chars = str.ToCharArray();
                            for (int m = chars.Length - 1; m >= 0; m--)
                            {
                                if (chars[m] == '0')
                                {
                                    DataRow dr = script.Rows[chars.Length - m - 1];
                                    DataRow resultDr = result.NewRow();
                                    resultDr["P3"] = data.Rows[i]["P3"]; //病案号
                                    resultDr["P2"] = data.Rows[i]["P2"]; //次数
                                    resultDr["CHECK_ID"] = dr["CHECK_ID"];
                                    resultDr["CHECK_NAME"] = dr["CHECK_NAME"];
                                    resultDr["CS_ERROR"] = dr["CS_ERROR"];
                                    resultDr["CHECK_CLASSIFY"] = dr["CHECK_CLASSIFY"];
                                    result.Rows.Add(resultDr);
                                    isCheckSuccess = false;
                                }
                            }
                        }
                        else//返回值为0，表示所有审核脚本都不通过
                        {
                            foreach (DataRow dr in script.Rows)
                            {
                                DataRow resultDr = result.NewRow();
                                resultDr["P3"] = data.Rows[i]["P3"]; //病案号
                                resultDr["P2"] = data.Rows[i]["P2"]; //次数
                                resultDr["CHECK_ID"] = dr["CHECK_ID"];
                                resultDr["CHECK_NAME"] = dr["CHECK_NAME"];
                                resultDr["CS_ERROR"] = dr["CS_ERROR"];
                                resultDr["CHECK_CLASSIFY"] = dr["CHECK_CLASSIFY"];
                                result.Rows.Add(resultDr);
                                isCheckSuccess = false;
                            }
                        }
                        if (isCheckSuccess) //审核通过，修改此病人审核状态为审核通过
                        {
                            Model.AddPatient(data.Rows[i]); //将此病人copy到本地库
                        }
                        waitUC.Do("执行进度(" + i + "/" + data.Rows.Count + ")");
                    }
                    waitUC.ParentForm.Close();
                    return result;
                }
            }
            return null;
        }
    }
}
