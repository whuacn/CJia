﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
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
    public static string SqlSelectPatient = @"select 
       V.FBIHID, --住院号
       V.FNAME PATIENT_NAME, --病人姓名
       V.FBIHID RECORD_NO, --病案号
       '' SHELFNO, --档案货架号
       '0' IS_SPECIAL, --是否为特殊病案
       DECODE(V.FSEX, '1', '4', '2', '5', '6') GENDER, --性别
       DECODE(V.FSEX,'1','男','2','女','未定') GENDER_NAME, --性别（男女）
       V.FBDATE BIRTHDAY, --出生日期
       DECODE(V.FMARRY, '1', '76', '2', '77','3','79','4','78','80') IS_MARRY, --婚姻状况
       V.FWORK JOB, --移入code
       V.FPROV PROVINCE, --出生省市（县）
       V.FIDCD ID_CARD, --身份证号
       '' IN_HOSPITAL_TYPE,--入院方式
       V.FBINCU IN_HOSPITAL_TIME, --入院次数
       V.FIHDAT IN_HOSPITAL_DATE, --入院时间
       V.FODATE OUT_HOSPITAL_DATE,--出院时间
       V.FIOFFI IN_HOSPITAL_DEPT,--入院科室
       (SELECT FDESC  FROM MHIS.TOFFIM WHERE FOFFN=V.FIOFFI) IN_HOSPITAL_DEPT_NAME ,--入院科室名称
       V.FOOFFI OUT_HOSPITAL_DEPT,--出院科室
       (SELECT FDESC  FROM MHIS.TOFFIM WHERE FOFFN=V.FOOFFI) OUT_HOSPITAL_DEPT_NAME,--出院科室名称
       V.FILOCA IN_HOSPITAL_ROOM, --入院病室
       V.FOLOCA OUT_HOSPITAL_ROOM,--出院病室
       DECODE((SELECT FDESC FROM MHIS.TGMYW WHERE FID=V.FGMYW),'',V.FGMYW,(SELECT FDESC FROM MHIS.TGMYW WHERE FID=V.FGMYW)) DRUG_ALLERGY, --过敏源
       DECODE(V.FBLTYP,'1','13','2','106','3','14','4','105') BLOOD_TYPE, --血型
       (SELECT CYZD.FICD  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=1 AND CYZD.FZDTYP='1' AND CYZD.FMRDID=V.FMRDID) ICD_OUTDIA1, --出院诊断1                                                     
       (SELECT TICD.FDESC  FROM MHIS.TMRDZD CYZD,MHIS.TICD10 TICD WHERE  CYZD.FSEQ=1 AND CYZD.FZDTYP='1' AND CYZD.FMRDID=V.FMRDID AND CYZD.FICD=TICD.FICD10 ) OUTDIA_NAME1,--出院诊断1名称
       (SELECT CYZD.FICD  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=2  AND CYZD.FMRDID=V.FMRDID) ICD_OUTDIA2,  --出院诊断2
       (SELECT TICD.FDESC  FROM MHIS.TMRDZD CYZD,MHIS.TICD10 TICD WHERE  CYZD.FSEQ=2 AND CYZD.FMRDID=V.FMRDID AND CYZD.FICD=TICD.FICD10 ) OUTDIA_NAME2,--出院诊断2名称
       (SELECT CYZD.FICD  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=3  AND CYZD.FMRDID=V.FMRDID) ICD_OUTDIA3,  --出院诊断3
       (SELECT TICD.FDESC  FROM MHIS.TMRDZD CYZD,MHIS.TICD10 TICD WHERE  CYZD.FSEQ=3 AND CYZD.FMRDID=V.FMRDID AND CYZD.FICD=TICD.FICD10 ) OUTDIA_NAME3,--出院诊断3名称
       (SELECT CYZD.FICD  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=4  AND CYZD.FMRDID=V.FMRDID)ICD_OUTDIA4,  --出院诊断4
       (SELECT TICD.FDESC  FROM MHIS.TMRDZD CYZD,MHIS.TICD10 TICD WHERE  CYZD.FSEQ=4 AND CYZD.FMRDID=V.FMRDID AND CYZD.FICD=TICD.FICD10 ) OUTDIA_NAME4,--出院诊断4名称
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=1 AND CYZD.FZDTYP='1' AND CYZD.FMRDID=V.FMRDID),'1','8','2','9','3','11','4','12','5','10','') TREAT_RESULT1,--治疗结果1
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=1 AND CYZD.FZDTYP='1' AND CYZD.FMRDID=V.FMRDID),'1','治愈','2','好转','3','未愈','4','死亡','5','其他','') TREAT_RESULT1_NAME,--治疗结果1名称
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=2  AND CYZD.FMRDID=V.FMRDID),'1','8','2','9','3','11','4','12','5','10','') TREAT_RESULT2,--治疗结果2
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=2  AND CYZD.FMRDID=V.FMRDID),'1','治愈','2','好转','3','未愈','4','死亡','5','其他','') TREAT_RESULT2_NAME,--治疗结果2名称
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=3 AND CYZD.FMRDID=V.FMRDID),'1','8','2','9','3','11','4','12','5','10','') TREAT_RESULT3,--治疗结果3
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=3 AND CYZD.FMRDID=V.FMRDID),'1','治愈','2','好转','3','未愈','4','死亡','5','其他','') TREAT_RESULT3_NAME,--治疗结果3名称
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=4  AND CYZD.FMRDID=V.FMRDID),'1','8','2','9','3','11','4','12','5','10','') TREAT_RESULT4,--治疗结果4
       DECODE((SELECT CYZD.FOTHST  FROM MHIS.TMRDZD CYZD WHERE CYZD.FSEQ=4  AND CYZD.FMRDID=V.FMRDID),'1','治愈','2','好转','3','未愈','4','死亡','5','其他','') TREAT_RESULT4_NAME,--治疗结果4名称
       (SELECT TROP.FOPID FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=1 AND V.FMRDID=TROP.FMRDID) ICD_SURGERY1,--手术编码1
       (SELECT TOP.FDESC FROM MHIS.TMRDOP TROP,MHIS.TOPSM TOP WHERE TROP.FSEQ=1 AND V.FMRDID=TROP.FMRDID AND TROP.FOPID=TOP.FID) SURGERY_NAME1,--手术名称1
       (SELECT TROP.Fopdat FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=1 AND V.FMRDID=TROP.FMRDID) SURGERY_DATE1,--手术1日期
       (SELECT TROP.FOPID FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=2 AND V.FMRDID=TROP.FMRDID) ICD_SURGERY2,--手术编码2
       (SELECT TOP.FDESC FROM MHIS.TMRDOP TROP,MHIS.TOPSM TOP WHERE TROP.FSEQ=2 AND V.FMRDID=TROP.FMRDID AND TROP.FOPID=TOP.FID) SURGERY_NAME2,--手术名称2
       (SELECT TROP.FOPDAT FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=2 AND V.FMRDID=TROP.FMRDID) SURGERY_DATE2,--手术编码2日期
       (SELECT TROP.FOPID FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=3 AND V.FMRDID=TROP.FMRDID) ICD_SURGERY3,--手术编码3
       (SELECT TOP.FDESC FROM MHIS.TMRDOP TROP,MHIS.TOPSM TOP WHERE TROP.FSEQ=3 AND V.FMRDID=TROP.FMRDID AND TROP.FOPID=TOP.FID) SURGERY_NAME3,--手术名称3
       (SELECT TROP.FOPDAT FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=3 AND V.FMRDID=TROP.FMRDID) SURGERY_DATE3,--手术编3码日期
       (SELECT TROP.FOPID FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=4 AND V.FMRDID=TROP.FMRDID) ICD_SURGERY4,--手术编码4
       (SELECT TOP.FDESC FROM MHIS.TMRDOP TROP,MHIS.TOPSM TOP WHERE TROP.FSEQ=4 AND V.FMRDID=TROP.FMRDID AND TROP.FOPID=TOP.FID) SURGERY_NAME4,--手术名称4
       (SELECT TROP.Fopdat FROM MHIS.TMRDOP TROP WHERE TROP.FSEQ=4 AND V.FMRDID=TROP.FMRDID) SURGERY_DATE4,--手术编码4日期
       V.FBLZKID ICD_BLZD1,--病理诊断1
       (SELECT FDESC FROM MHIS.VTKNUBM WHERE FID =V.FBLZKID) BLZD_NAME1,--病理诊断名称1
       '' ICD_BLZD2, --病理诊断2
       '' BLZD_NAME2, --病理诊断名称2
       '' ICD_YNGR1, --院内感染1
       '' YNGR_NAME1, --院内感染名称1
       '' ICD_YNGR2, --院内感染2
       '' YNGR_NAME2, --院内感染名称2
       DECODE(V.FMZYCY,'0','18','1','15','2','16','3','17','') OUTPATIENT_OUT_DIA, --门诊诊断与出院诊断
       DECODE(V.FRYYCY,'0','18','1','15','2','16','3','17','') IN_OUT_HOSPITAL_DIA,--入院诊断与出院诊断
       DECODE(V.FSQYSH,'0','18','1','15','2','16','3','17','') BEGORE_AFTER_SURGERY_DIA, --术前诊断与术后诊断
       DECODE(V.FFSYBL,'0','18','1','15','2','16','3','17','') RADIATION_AFTER_DIA, --放射诊断与病理诊断
       DECODE(V.FQJYBL,'0','18','1','15','2','16','3','17','') CLINICAL_PATHOLOGY_DIA, --临床诊断与病理诊断
       TRUNC(MONTHS_BETWEEN(SYSDATE,V.FBDATE)/12) PATIENT_AGE, --年龄
       V.FPADD PATIENT_ADDRESS, --病人户口地址
       V.FKZR DEPT_DIRECTOR, --科主任
       V.FZRYS DEPT_DOCTOR, --主任医师
       V.FZZYS MAIN_DOCTOR, --主治医师
       V.FZYYS IN_HOSPITAL_DOCTOR, --住院医师
       V.FJXYS ADVANCE_STUDY_DOCTOR,--进修医师
       V.FYJSYS GRADUATE_PRACTICE_DOCTOR,--  研究生实习医师
       V.FSXYS PRACTICE_DOCTOR, --实习医师
       V.FZKYS QC_DOCTOR, --质控医师
       V.FZKHS QC_NURSE,--质控护士
       DECODE(V.FBAZL,'1','A0001','2','A0002','3','A0003','') RECORD_QUALITY --病案质量                                    
  from MHIS.VTMRDDEPUB001 V where V.FBIHID=? and V.FBINCU=?";
}