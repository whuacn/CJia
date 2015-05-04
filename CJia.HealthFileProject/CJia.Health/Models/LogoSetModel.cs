using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class LogoSetModel : Tools.Model
    {
        /// <summary>
        /// 修改水印内容和水印倾斜度
        /// </summary>
        /// <param name="content"></param>
        /// <param name="batter"></param>
        /// <returns></returns>
        public bool ModifyLogoInfo(string content, string batter)
        {
            object[] sqlParams1 = new object[] { content };
            object[] sqlParams2 = new object[] { batter };
            bool bol1 = CJia.DefaultOleDb.Execute(SqlTools.SqlModifyLogoContent, sqlParams1) > 0 ? true : false;
            bool bol2 = CJia.DefaultOleDb.Execute(SqlTools.SqlModifyLogoInclination, sqlParams2) > 0 ? true : false;
            if (bol1 && bol2)
                return true;
            else
                return false;
        }
    }
}
