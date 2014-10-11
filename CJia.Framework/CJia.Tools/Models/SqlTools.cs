using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Tools.Models
{
    public class SqlTools
    {
        public static string SqlQueryTable = @"
Select Aat.Table_Name As 表名, '数据表' As 类别
  From Sys.All_All_Tables Aat
 Where Aat.Owner = :1
Union All
Select Av.View_Name As 表名, '视图' As 类别
  From Sys.All_Views Av
 Where Av.Owner = :1
";
        public static string SqlQueryTableStruct = @"
Select Atc.Column_Name,
       '' As Propertyname,
       Atc.Data_Type,
       Atc.Data_Length,
       ATC.DATA_DEFAULT,
       Atc.Nullable,
       Ao.Constraint_Type,
       Acc.Comments As Chinese_Name,
       Acc.Comments
  From Sys.All_Tab_Columns Atc,
       Sys.All_Col_Comments Acc,
       (Select Ac.Owner || Ac.Table_Name || Aco.Column_Name As Otc,
               Ac.Constraint_Type
          From Sys.All_Constraints Ac, Sys.All_Cons_Columns Aco
         Where Ac.Owner = Aco.Owner
           And Ac.Table_Name = Aco.Table_Name
           And Ac.Constraint_Name = Aco.Constraint_Name
           And Ac.Constraint_Type = 'P') Ao
 Where Atc.Owner = Acc.Owner
   And Atc.Table_Name = Acc.Table_Name
   And Atc.Column_Name = Acc.Column_Name
   And Atc.Owner || Atc.Table_Name || Atc.Column_Name = Ao.Otc(+)
   And Atc.Owner = :1
   And Atc.Table_Name = :2
 Order By Atc.Column_Id
";
        public static string SqlQueryCols = @" select
    A.column_name 字段名,c.是否主键,A.data_type 数据类型,A.data_length 长度,A.data_precision 整数位,
    A.Data_Scale 小数位,A.nullable 允许空值,A.Data_default 缺省值,B.comments 备注
from
    all_tab_columns A,all_col_comments B,(select A.TABLE_NAME,B.COLUMN_NAME,'Y' 是否主键 from ALL_CONSTRAINTS A,ALL_cons_columns B
    where b.CONSTRAINT_NAME = A.CONSTRAINT_NAME
    AND A.TABLE_NAME = B.TABLE_NAME
    AND A.OWNER = B.OWNER
    AND A.CONSTRAINT_TYPE ='P'
    AND A.TABLE_NAME = :2
    AND A.OWNER = :1) c
where
    A.Table_Name = B.Table_Name
    AND A.OWNER = B.OWNER
    AND B.Table_Name = C.Table_Name(+)
    and a.column_name = b.COLUMN_NAME
    and B.column_name = C.COLUMN_NAME(+)
    and A.Table_Name =  :2
    and a.OWNER = :1";

        public static string GetTable = " select * from all_tab_comments atc where atc.OWNER = :1 and atc.TABLE_NAME = :2";

        public static string GetUserById = "select * from gm_user where user_id = :1";
    }
}
