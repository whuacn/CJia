using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// SqlText
/// </summary>
public class SqlText
{
    public SqlText()
    {
    }
    /// <summary>
    /// 门诊人数
    /// </summary>
    public static string SqlMCRS1 = @"select to_char(fdate, 'mm') fm,
                                     sum(decode(to_char(fdate, 'yyyy'), 2011, t.fzjrs, 0)) a,
                                     sum(decode(to_char(fdate, 'yyyy'), 2012, t.fzjrs, 0)) b,
                                     sum(decode(to_char(fdate, 'yyyy'), 2013, t.fzjrs, 0)) c,
                                     sum(decode(to_char(fdate, 'yyyy'), 2014, t.fzjrs, 0)) d
                                      from TOPSI t, TOFFIM a
                                     where t.foffi = a.foffn
                                       and t.fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                     group by to_char(fdate, 'mm') order by fm";
    public static string SqlMCRS2 = @"select to_char(fdate, 'yyyy') fm,
                                     sum(decode(to_char(fdate, 'mm'), 01, t.fczrs+t.fjzrs+t.fzjrs, 0)) a,
                                     sum(decode(to_char(fdate, 'mm'), 02, t.fczrs+t.fjzrs+t.fzjrs, 0)) b,
                                     sum(decode(to_char(fdate, 'mm'), 03, t.fczrs+t.fjzrs+t.fzjrs, 0)) c,
                                     sum(decode(to_char(fdate, 'mm'), 04, t.fczrs+t.fjzrs+t.fzjrs, 0)) d,
                                     sum(decode(to_char(fdate, 'mm'), 05, t.fczrs+t.fjzrs+t.fzjrs, 0)) e,
                                     sum(decode(to_char(fdate, 'mm'), 06, t.fczrs+t.fjzrs+t.fzjrs, 0)) f,
                                     sum(decode(to_char(fdate, 'mm'), 07, t.fczrs+t.fjzrs+t.fzjrs, 0)) g,
                                     sum(decode(to_char(fdate, 'mm'), 08, t.fczrs+t.fjzrs+t.fzjrs, 0)) h,
                                     sum(decode(to_char(fdate, 'mm'), 09, t.fczrs+t.fjzrs+t.fzjrs, 0)) i,
                                     sum(decode(to_char(fdate, 'mm'), 10, t.fczrs+t.fjzrs+t.fzjrs, 0)) j,
                                     sum(decode(to_char(fdate, 'mm'), 11, t.fczrs+t.fjzrs+t.fzjrs, 0)) k,
                                     sum(decode(to_char(fdate, 'mm'), 12, t.fczrs+t.fjzrs+t.fzjrs, 0)) l
                                      from TOPSI t, TOFFIM a
                                     where t.foffi = a.foffn
                                       and t.fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                     group by to_char(fdate, 'yyyy') order by fm";
    public static string SqlMCRS3 = @"select to_char(fdate,'yyyy') yy,to_char(fdate,'mm') mm ,sum(t.fczrs+t.fjzrs+t.fzjrs) total
                                  from TOPSI t,TOFFIM a
                                  where t.foffi=a.foffn
                                 and t.fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                   group by to_char(fdate,'yyyy'),to_char(fdate,'mm')";
    public static string SqlRYRS1 = @"Select to_char(Fdate,'yyyy') yy,to_char(Fdate,'mm') mm
                                  ,Nvl(sum(Fryrs),0)  Fc03  --入院人数
                                   ,Nvl(sum(Fcyrsj),0)  Fc04  --出院人数FCYRSJ
                                  ,Nvl(sum(Fkfcs),0)  Fc15  --实际开放床数
                                  ,Nvl(sum(Fsjcs),0)  Fc18  --实际占用床日数
                                   ,decode(Nvl(sum(Fkfcs),0),0,'', round(Nvl(sum(Fsjcs),0)/Nvl(sum(Fkfcs),0),4)*100) gl --病床使用率*100%
                                  ,Sum(Nvl(Fbrkc,0))  Fc25  --本日空床数
                                  ,Sum(Nvl(Fsjcsj,0))  Fc26  --本日加床数
                                  ,round(Sum(Nvl(Fcyrsj,0))/Sum(Nvl(Fkfcs,0))*to_char(last_day(Fdate),'dd'),2) bczz --病床周转次数
                                  ,round(Sum(Nvl(Fsjcs,0))/Sum(Nvl(Fkfcs,0))*to_char(last_day(Fdate),'dd'),2) pjzy --平均住院天数
                                  From TIPSI
                                 where fdate>=to_date('2011-01-01','yyyy-mm-dd')
                                 Group by to_char(Fdate,'yyyy'),to_char(Fdate,'mm'),to_char(last_day(Fdate),'dd')";
    public static string SqlRYRS2 = @"select to_char(fdate, 'yyyy') fm,
                                     sum(decode(to_char(fdate, 'mm'), 01, t.Fryrs, 0)) a,
                                     sum(decode(to_char(fdate, 'mm'), 02, t.Fryrs, 0)) b,
                                     sum(decode(to_char(fdate, 'mm'), 03, t.Fryrs, 0)) c,
                                     sum(decode(to_char(fdate, 'mm'), 04, t.Fryrs, 0)) d,
                                     sum(decode(to_char(fdate, 'mm'), 05, t.Fryrs, 0)) e,
                                     sum(decode(to_char(fdate, 'mm'), 06, t.Fryrs, 0)) f,
                                     sum(decode(to_char(fdate, 'mm'), 07, t.Fryrs, 0)) g,
                                     sum(decode(to_char(fdate, 'mm'), 08, t.Fryrs, 0)) h,
                                     sum(decode(to_char(fdate, 'mm'), 09, t.Fryrs, 0)) i,
                                     sum(decode(to_char(fdate, 'mm'), 10, t.Fryrs, 0)) j,
                                     sum(decode(to_char(fdate, 'mm'), 11, t.Fryrs, 0)) k,
                                     sum(decode(to_char(fdate, 'mm'), 12, t.Fryrs, 0)) l
                                      from TIPSI t
                                     where t.fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                     group by to_char(t.fdate, 'yyyy') order by fm";
    public static string SqlCYRS = @"select to_char(fdate, 'yyyy') fm,
                                     sum(decode(to_char(fdate, 'mm'), 01, t.Fcyrsj, 0)) a,
                                     sum(decode(to_char(fdate, 'mm'), 02, t.Fcyrsj, 0)) b,
                                     sum(decode(to_char(fdate, 'mm'), 03, t.Fcyrsj, 0)) c,
                                     sum(decode(to_char(fdate, 'mm'), 04, t.Fcyrsj, 0)) d,
                                     sum(decode(to_char(fdate, 'mm'), 05, t.Fcyrsj, 0)) e,
                                     sum(decode(to_char(fdate, 'mm'), 06, t.Fcyrsj, 0)) f,
                                     sum(decode(to_char(fdate, 'mm'), 07, t.Fcyrsj, 0)) g,
                                     sum(decode(to_char(fdate, 'mm'), 08, t.Fcyrsj, 0)) h,
                                     sum(decode(to_char(fdate, 'mm'), 09, t.Fcyrsj, 0)) i,
                                     sum(decode(to_char(fdate, 'mm'), 10, t.Fcyrsj, 0)) j,
                                     sum(decode(to_char(fdate, 'mm'), 11, t.Fcyrsj, 0)) k,
                                     sum(decode(to_char(fdate, 'mm'), 12, t.Fcyrsj, 0)) l
                                      from TIPSI t
                                     where t.fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                     group by to_char(t.fdate, 'yyyy') order by fm";
    public static string SqlBCSYL = @"select yy fm,
                                       sum(decode(mm, '01', gl, 0)) a,
                                       sum(decode(mm, '02', gl, 0)) b,
                                       sum(decode(mm, '03', gl, 0)) c,
                                       sum(decode(mm, '04', gl, 0)) d,
                                       sum(decode(mm, '05', gl, 0)) e,
                                       sum(decode(mm, '06', gl, 0)) f,
                                       sum(decode(mm, '07', gl, 0)) g,
                                       sum(decode(mm, '08', gl, 0)) h,
                                       sum(decode(mm, '09', gl, 0)) i,
                                       sum(decode(mm, '10', gl, 0)) j,
                                       sum(decode(mm, '11', gl, 0)) k,
                                       sum(decode(mm, '12', gl, 0)) l
                                  from (select to_char(Fdate, 'yyyy') yy,
                                               to_char(Fdate, 'mm') mm,
                                               decode(Sum(Nvl(Fkfcs, 0)),
                                                      0,
                                                      '',
                                                      round(Sum(Nvl(Fsjcs, 0)) / Sum(Nvl(Fkfcs, 0)), 4) * 100) gl --增加一个床位使用率 (计处方式：实际占用床日数/实际开放床数 ）
                                          From TIPSI
                                         where fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                         group by to_char(Fdate, 'yyyy'), to_char(Fdate, 'mm'))
                                 group by yy
                                 order by yy";
    public static string SqlBCZZ = @"select yy fm,
                              sum(decode(mm, '01', bczz, 0)) a,
                              sum(decode(mm, '02', bczz, 0)) b,
                              sum(decode(mm, '03', bczz, 0)) c,
                              sum(decode(mm, '04', bczz, 0)) d,
                              sum(decode(mm, '05', bczz, 0)) e,
                              sum(decode(mm, '06', bczz, 0)) f,
                              sum(decode(mm, '07', bczz, 0)) g,
                              sum(decode(mm, '08', bczz, 0)) h,
                              sum(decode(mm, '09', bczz, 0)) i,
                              sum(decode(mm, '10', bczz, 0)) j,
                              sum(decode(mm, '11', bczz, 0)) k,
                              sum(decode(mm, '12', bczz, 0)) l
                         from (select to_char(Fdate, 'yyyy') yy,
                                      to_char(Fdate, 'mm') mm,
                                      round(Sum(Nvl(Fcyrsj,0))/Sum(Nvl(Fkfcs,0))*to_char(last_day(Fdate),'dd'),2) bczz--病床周转次数
                                 From TIPSI
                                where fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                group by to_char(Fdate, 'yyyy'), to_char(Fdate, 'mm'),to_char(last_day(Fdate),'dd'))
                        group by yy
                        order by yy";
    public static string SqlPJZY = @"select yy fm,
                              sum(decode(mm, '01', pjzy, 0)) a,
                              sum(decode(mm, '02', pjzy, 0)) b,
                              sum(decode(mm, '03', pjzy, 0)) c,
                              sum(decode(mm, '04', pjzy, 0)) d,
                              sum(decode(mm, '05', pjzy, 0)) e,
                              sum(decode(mm, '06', pjzy, 0)) f,
                              sum(decode(mm, '07', pjzy, 0)) g,
                              sum(decode(mm, '08', pjzy, 0)) h,
                              sum(decode(mm, '09', pjzy, 0)) i,
                              sum(decode(mm, '10', pjzy, 0)) j,
                              sum(decode(mm, '11', pjzy, 0)) k,
                              sum(decode(mm, '12', pjzy, 0)) l
                         from (select to_char(Fdate, 'yyyy') yy,
                                      to_char(Fdate, 'mm') mm,
                                      round(Sum(Nvl(Fsjcs,0))/Sum(Nvl(Fkfcs,0))*to_char(last_day(Fdate),'dd'),2) pjzy--平均住院天数
                                 From TIPSI
                                where fdate >= to_date('2011-01-01', 'yyyy-mm-dd')
                                group by to_char(Fdate, 'yyyy'), to_char(Fdate, 'mm'),to_char(last_day(Fdate),'dd'))
                        group by yy
                        order by yy";
    /// <summary>
    /// 新生儿人数
    /// </summary>
    public static string SqlSSRRS = @"select  to_char(birth_date, 'yyyy') yy ,to_char(birth_date, 'mm') mm ,count(visit_id) total
 from sub_pat_visit where birth_date>=to_date('2011-01-01','yyyy-mm-dd')
 and birth_date<sysdate
group by to_char(birth_date, 'yyyy'),to_char(birth_date, 'mm') order by yy";
    public static string SqlSSRRS2 = @"select yy fm,
       sum(decode(mm, '01', total, 0)) a,
       sum(decode(mm, '02', total, 0)) b,
       sum(decode(mm, '03', total, 0)) c,
       sum(decode(mm, '04', total, 0)) d,
       sum(decode(mm, '05', total, 0)) e,
       sum(decode(mm, '06', total, 0)) f,
       sum(decode(mm, '07', total, 0)) g,
       sum(decode(mm, '08', total, 0)) h,
       sum(decode(mm, '09', total, 0)) i,
       sum(decode(mm, '10', total, 0)) j,
       sum(decode(mm, '11', total, 0)) k,
       sum(decode(mm, '12', total, 0)) l
  from (select to_char(birth_date, 'yyyy') yy,
               to_char(birth_date, 'mm') mm,
               count(visit_id) total
          from sub_pat_visit
         where birth_date >= to_date('2011-01-01', 'yyyy-mm-dd')
           and birth_date < sysdate
         group by to_char(birth_date, 'yyyy'), to_char(birth_date, 'mm')
         order by yy)
 group by yy
 order by yy";
    /// <summary>
    /// 手术台数
    /// </summary>
    public static string SqlSSTS = @"select to_char(fdate, 'yyyy') yy,to_char(fdate, 'mm') mm,sum(fopsn+fipsn) total  from tteci t where fdate>=to_date('2011-01-01','yyyy-mm-dd') 
and foffi='901'
and fitem='901000'
group by to_char(fdate, 'yyyy'),to_char(fdate, 'mm')
order by yy,mm";
    public static string SqlSSTS2 = @"select yy fm,
       sum(decode(mm, '01', total, 0)) a,
       sum(decode(mm, '02', total, 0)) b,
       sum(decode(mm, '03', total, 0)) c,
       sum(decode(mm, '04', total, 0)) d,
       sum(decode(mm, '05', total, 0)) e,
       sum(decode(mm, '06', total, 0)) f,
       sum(decode(mm, '07', total, 0)) g,
       sum(decode(mm, '08', total, 0)) h,
       sum(decode(mm, '09', total, 0)) i,
       sum(decode(mm, '10', total, 0)) j,
       sum(decode(mm, '11', total, 0)) k,
       sum(decode(mm, '12', total, 0)) l
  from (select to_char(fdate, 'yyyy') yy,to_char(fdate, 'mm') mm,sum(fopsn+fipsn) total  from tteci t where fdate>=to_date('2011-01-01','yyyy-mm-dd') 
and foffi='901'
and fitem='901000'
group by to_char(fdate, 'yyyy'),to_char(fdate, 'mm')
order by yy,mm)
group by yy
 order by yy
";
    /// <summary>
    /// 平均住院天数
    /// </summary>
    public static string SqlPJZYTS = @"SELECT to_char(fdate,'yyyy') yy,to_char(fdate,'mm') mm,
 SUM(FC05),--出院人数
       SUM(FC14),--出院者占总床日数
       SUM(FC15),--实际开放总床日数
       SUM(FC18),--实际占用总床日数
       round(decode(SUM(FC05),0,'', SUM(FC14)/ SUM(FC05)),2) gl
  FROM VMRD550REP001
 WHERE Fdate >= to_date('20110101', 'yyyymmdd')
    GROUP BY to_char(fdate,'yyyy'),to_char(fdate,'mm')
    order by yy,mm";
    public static string SqlPJZYTS2 = @"select yy fm,
       sum(decode(mm, '01', gl, 0)) a,
       sum(decode(mm, '02', gl, 0)) b,
       sum(decode(mm, '03', gl, 0)) c,
       sum(decode(mm, '04', gl, 0)) d,
       sum(decode(mm, '05', gl, 0)) e,
       sum(decode(mm, '06', gl, 0)) f,
       sum(decode(mm, '07', gl, 0)) g,
       sum(decode(mm, '08', gl, 0)) h,
       sum(decode(mm, '09', gl, 0)) i,
       sum(decode(mm, '10', gl, 0)) j,
       sum(decode(mm, '11', gl, 0)) k,
       sum(decode(mm, '12', gl, 0)) l
  from (SELECT to_char(fdate, 'yyyy') yy,
               to_char(fdate, 'mm') mm,
               round(decode(SUM(FC05), 0, '', SUM(FC14) / SUM(FC05)), 2) gl
          FROM VMRD550REP001
         WHERE Fdate >= to_date('20110101', 'yyyymmdd')
         GROUP BY to_char(fdate, 'yyyy'), to_char(fdate, 'mm')
         order by yy, mm)
 group by yy
 order by yy
";
}
