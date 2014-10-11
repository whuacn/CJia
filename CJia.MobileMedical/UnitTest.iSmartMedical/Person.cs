using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.iSmartMedical
{
    class DataModel
    {
        public Person NewPerson()
        {
            Person p = new Person();
            p.Id = "1";
            p.Name = "张三";
            p.Archives = new List<Archive>();
            //MoogoDB.Save(p);//保存到数据库
            return p;
        }

        public void SavePersonArchive(Person p)
        { 
            PersonArchive pa = new PersonArchive();
            pa.病史 = "...";
            p.Archives.Add(pa);
            //MoogoDB.Save(p);//保存到数据库
        }

        public void SaveChild2_3Archive(Person p)
        {
            Child2_3Archive ca = new Child2_3Archive();
            ca.身高 = "...";
            p.Archives.Add(ca);
            //MoogoDB.Save(p);//保存到数据库
        }
    }

    class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public List<Archive> Archives { get; set; }
    }

    class Archive
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime 创建时间 { get; set; }
        public string 创建人 { get; set; }
        public DateTime 修改时间 { get; set; }
        public string 修改人 { get; set; }
    }
    //个人档案
    class PersonArchive : Archive
    {
        public string 民族 { get; set; }
        public string 病史 { get; set; }
        public string 身高 { get; set; }
        public string 体重 { get; set; }

    }
    //健康体检档案
    class HealthArchive : Archive
    {
        public string 血压 { get; set; }
    }
    //儿童1-2岁档案
    class Child1_2Archive : Archive
    {
        public string 身高 { get; set; }
        public string 体重 { get; set; }
    }
    //儿童2-3岁档案
    class Child2_3Archive : Archive
    {
        public string 身高 { get; set; }
        public string 体重 { get; set; }
    }
    //高血压档案
    class GXYArchive : Archive
    {
        public string 血压 { get; set; }
        public string 体重 { get; set; }
    }
    //心脏病档案
    class XZBArchive : Archive
    {
        public string 用药情况 { get; set; }
        public string 是否吸烟 { get; set; }
    }
}
