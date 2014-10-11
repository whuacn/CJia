using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Xml.Dom;
using System.Reflection;

namespace CJia.MobileMedicalDoctor
{
    public class Entity
    {
        /// <summary>
        /// 把Xml转为DIctionary
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static List<Dictionary<string, string>> XmlToListDic(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            XmlNodeList de = doc.SelectNodes("NewDataSet");
            XmlNodeList xnl = de[0].SelectNodes("table");
            List<Dictionary<string, string>> listDoc = new List<Dictionary<string, string>>();
            foreach(IXmlNode xn in xnl)
            {
                IXmlNode Project = xn;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                for(int i = 1; i < Project.ChildNodes.Count; i=i+2)
                {
                    string jj = "";
                    if (Project.ChildNodes[i].FirstChild != null)
                    {
                        jj = Project.ChildNodes[i].FirstChild.NodeValue.ToString();
                    }
                   
                    string ss = Project.ChildNodes[i].NodeName.ToString();
                    dic.Add(ss, jj);
                }
                listDoc.Add(dic);
            }
            return listDoc;
        }

        /// <summary>
        /// 把用户数据的字典转为用户实体类
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static CJia.MobileMedicalDoctor.Data.User dicToUser(Dictionary<string,string> dic)
        {
            CJia.MobileMedicalDoctor.Data.User user = new Data.User();
            for (int i = 0; i < dic.Count; i++)
            {
                user.ID = dic["ID"].ToString();
                user.Code = dic["Code"].ToString();
                user.Password = dic["Password"].ToString();
                user.Name = dic["Name"].ToString();
                user.DeptID = dic["DeptID"].ToString();
                user.DeptName = dic["DeptName"].ToString();
                user.Status = dic["Status"].ToString();
            }
                return user;
        }

        /// <summary>
        /// 把病人数据的字典转为病人实体类
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static CJia.MobileMedicalDoctor.Data.Patient dicToPatient(Dictionary<string,string> dic)
        {
            Data.Patient patient=new Data.Patient();
            if(dic!=null&&dic.Count>0)
            {
                for(int i = 0; i < dic.Count; i++)
                {
                    
                }
            }
            return patient;
        }

        /// <summary>
        /// 自动把字典转换为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDic"></param>
        /// <returns></returns>
        public static List<T> GetEntity<T>(List<Dictionary<string, string>> listDic) where T : new() 
        {
            List<T> listEntity = new List<T>();
            var typet = typeof(T);
            var propList = typet.GetRuntimeProperties();
            foreach (Dictionary<string, string> dic in listDic)
            {
                T t = new T();
                foreach (var p in propList)
                {
                    if(dic.ContainsKey(p.Name))
                    {
                        p.SetValue(t, dic[p.Name], null);
                    }
                }
                listEntity.Add(t);
            }
            return listEntity;
           
        }

        public class KyeNameAttribute : Attribute
        {
            public KyeNameAttribute(string a)
            {
                this.DictKeyName = a;
            }
            public string DictKeyName { get; set; }
        }

        //public static List<Data.Patient> GetPatient(List<Dictionary<string, string>> listDic)
        //{
        //    var patient = new Data.Patient();
        //    var t = patient.GetType();
        //    var propList = t.GetProperties();
        //}
    }
}
