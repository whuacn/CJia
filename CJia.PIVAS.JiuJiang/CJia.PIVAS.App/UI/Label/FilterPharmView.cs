using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace CJia.PIVAS.App.UI.Label
{
    public partial class FilterPharmView : XtraUserControl
    {
        /// <summary>
        /// 赛选瓶贴用户控件
        /// </summary>
        public FilterPharmView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选着的药品
        /// </summary>
        public DataTable selectPharm
        {
            get
            {
                DataTable pharm = (DataTable)this.gcPatient.DataSource;
                if(pharm != null && pharm.Rows != null && pharm.Rows.Count > 0)
                {
                    DataTable selectPharm = this.GetDataSource(pharm.Select(" ISCHECK = true "));
                    return selectPharm;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 绑定所有病人
        /// </summary>
        /// <param name="patient"></param>
        public void BindData(DataTable Pharm)
        {
            if(Pharm != null && Pharm.Rows != null && Pharm.Rows.Count > 0)
            {
                int result = Pharm.Columns.IndexOf("ISCHECK");
                if(result == -1)
                {
                    DataColumn select = new DataColumn("ISCHECK", typeof(System.Boolean));
                    Pharm.Columns.Add(select);
                    for(int i = 0; i < Pharm.Rows.Count; i++)
                    {
                        Pharm.Rows[i]["ISCHECK"] = true;
                    }
                }
            }
            this.gcPatient.DataSource = Pharm;
        }

        /// <summary>
        /// 获取选着的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void txtPharmName_TextChanged(object sender, EventArgs e)
        {
            DataTable data = (DataTable)this.gcPatient.DataSource;
            if(data != null && data.Rows != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    int start;
                    if(data.Columns.Contains("FLAG"))
                    {
                        start = data.Rows[i]["FLAG"].ToString().ToUpper().IndexOf(this.txtPharmName.Text.Trim().ToUpper());
                    }
                    else
                    {
                        start = this.GetFirstLetter(data.Rows[i]["PHARM_NAME"].ToString()).ToUpper().IndexOf(this.txtPharmName.Text.Trim().ToUpper());
                    }
                    if(start != -1)
                    {
                        this.gvPatient.MoveFirst();
                        this.gvPatient.MoveBy(i);
                        return;
                    }
                }
            }
        }

        private void ckeBen_CheckedChanged(object sender, EventArgs e)
        {
            DataTable pharm = (DataTable)this.gcPatient.DataSource;
            if(pharm != null && pharm.Rows != null && pharm.Rows.Count > 0)
            {
                for(int i = 0; i < pharm.Rows.Count; i++)
                {
                    if(this.ckePharm.Checked)
                    {
                        pharm.Rows[i]["ISCHECK"] = true;
                    }
                    else
                    {
                        pharm.Rows[i]["ISCHECK"] = false;
                    }
                }
            }
        }

        private void txtPharmName_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyData == Keys.Enter)
            //{
            //    DataRow row = this.gvPatient.GetFocusedDataRow();
            //    row["ISCHECK"] = !((bool)row["ISCHECK"]);
            //}
            //if(e.KeyData == Keys.Up)
            //{
            //    this.gvPatient.MoveBy(-1);
            //}
            //if(e.KeyData == Keys.Down)
            //{
            //    this.gvPatient.MoveBy(1);                
            //}
        }

        private void FilterPharmView_Leave(object sender, EventArgs e)
        {

        }


        /// <summary>
        //　将ROW数组转成datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private DataTable GetDataSource(DataRow[] rows)
        {
            if(rows != null && rows.Length != 0)
            {
                DataTable result = rows[0].Table.Clone();
                for(int i = 0; i < rows.Length; i++)
                {
                    DataRow row = result.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    result.Rows.Add(row);
                }
                return result;
            }
            return null;
        }

        /// <summary>
        /// 获取中文首拼
        /// </summary>
        /// <param name="chineseStr"></param>
        /// <returns></returns>
        public string GetFirstLetter(string chineseStr)
        {
            byte[] _cBs = System.Text.Encoding.Default.GetBytes(chineseStr);

            if(_cBs.Length < 2)
                return chineseStr;

            byte ucHigh, ucLow;
            int nCode;

            string strFirstLetter = string.Empty;

            for(int i = 0; i < _cBs.Length; i++)
            {

                if(_cBs[i] < 0x80)
                {
                    strFirstLetter += Encoding.Default.GetString(_cBs, i, 1);
                    continue;
                }

                ucHigh = (byte)_cBs[i];
                ucLow = (byte)_cBs[i + 1];
                if(ucHigh < 0xa1 || ucLow < 0xa1)
                    continue;
                else
                    // Treat code by section-position as an int type parameter,
                    // so make following change to nCode.
                    nCode = (ucHigh - 0xa0) * 100 + ucLow - 0xa0;

                string str = FirstLetter(nCode);
                strFirstLetter += str != string.Empty ? str : Encoding.Default.GetString(_cBs, i, 2);
                i++;
            }
            return strFirstLetter;
        }

        /// <summary>
        /// Get the first letter of pinyin according to specified Chinese character code
        /// </summary>
        /// <param name="nCode">the code of the chinese character</param>
        /// <returns>receive the string of the first letter</returns>
        public string FirstLetter(int nCode)
        {
            string strLetter = string.Empty;

            if(nCode >= 1601 && nCode < 1637)
                strLetter = "A";
            if(nCode >= 1637 && nCode < 1833)
                strLetter = "B";
            if(nCode >= 1833 && nCode < 2078)
                strLetter = "C";
            if(nCode >= 2078 && nCode < 2274)
                strLetter = "D";
            if(nCode >= 2274 && nCode < 2302)
                strLetter = "E";
            if(nCode >= 2302 && nCode < 2433)
                strLetter = "F";
            if(nCode >= 2433 && nCode < 2594)
                strLetter = "G";
            if(nCode >= 2594 && nCode < 2787)
                strLetter = "H";
            if(nCode >= 2787 && nCode < 3106)
                strLetter = "J";
            if(nCode >= 3106 && nCode < 3212)
                strLetter = "K";
            if(nCode >= 3212 && nCode < 3472)
                strLetter = "L";
            if(nCode >= 3472 && nCode < 3635)
                strLetter = "M";
            if(nCode >= 3635 && nCode < 3722)
                strLetter = "N";
            if(nCode >= 3722 && nCode < 3730)
                strLetter = "O";
            if(nCode >= 3730 && nCode < 3858)
                strLetter = "P";
            if(nCode >= 3858 && nCode < 4027)
                strLetter = "Q";
            if(nCode >= 4027 && nCode < 4086)
                strLetter = "R";
            if(nCode >= 4086 && nCode < 4390)
                strLetter = "S";
            if(nCode >= 4390 && nCode < 4558)
                strLetter = "T";
            if(nCode >= 4558 && nCode < 4684)
                strLetter = "W";
            if(nCode >= 4684 && nCode < 4925)
                strLetter = "X";
            if(nCode >= 4925 && nCode < 5249)
                strLetter = "Y";
            if(nCode >= 5249 && nCode < 5590)
                strLetter = "Z";

            //if (strLetter == string.Empty)
            //    System.Windows.Forms.MessageBox.Show(String.Format("信息：/n{0}为非常用字符编码,不能为您解析相应匹配首字母！",nCode));
            return strLetter;
        }

        private void FilterPharmView_Enter(object sender, EventArgs e)
        {
            this.txtPharmName.Focus();
        }



    }
}
