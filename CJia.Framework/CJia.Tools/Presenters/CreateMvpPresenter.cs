using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace CJia.Tools.Presenters
{
    public class CreateMvpPresenter : CJia.Presenter<CJia.Tools.Views.ICreateMvpView>
    {
        private Models.CreateMvpModel Model
        {
            get;
            set;
        }

         public CreateMvpPresenter(Views.ICreateMvpView view)
            : base(view)
        {
            this.Model = new Models.CreateMvpModel();
        }

        protected override void OnViewSet()
        {
            this.View.Create += View_Create;
        }

        private void View_Create(object sender, EventArgs e)
        {
            string projectName = Path.GetFileName(this.View.ProjectPath);

            if(!File.Exists(this.View.ProjectPath + @"\" + projectName + ".csproj"))
            {
                this.View.ShowMessage("这不是项目文件夹！请选择正确的项目文件夹！");
                return;
            }

            if(File.Exists(this.View.ProjectPath + @"\UI\" + this.View.UIName.Trim() + "View.cs")
                || File.Exists(this.View.ProjectPath + @"\UI\" + this.View.UIName.Trim() + "View.Designer.cs")
                || File.Exists(this.View.ProjectPath + @"\Views\I" + this.View.UIName.Trim() + "View.cs")
                || File.Exists(this.View.ProjectPath + @"\Presenters\" + this.View.UIName.Trim() + "Presenter.cs")
                || File.Exists(this.View.ProjectPath + @"\Models\" + this.View.UIName.Trim() + "Model.cs"))
            {
                if(!this.View.ShowAwrn("项目中已经包含该该用户自定义控件的相关文件！强行继续的话将覆盖原文件！请确认是否继续！"))
                {
                    return;
                }
            }

            this.GetFile(this.View.ProjectName);

            this.EditCsproj(this.View.ProjectName);

            this.View.ShowMessage("在项目中增加用户自定义控件成功！");
        }

        private void GetFile(string projectName)
        {
            Directory.CreateDirectory(this.View.ProjectPath + @"\UI\");
            Directory.CreateDirectory(this.View.ProjectPath + @"\Views\");
            Directory.CreateDirectory(this.View.ProjectPath + @"\Presenters\");
            Directory.CreateDirectory(this.View.ProjectPath + @"\Models\");

            File.WriteAllText(this.View.ProjectPath + @"\UI\" + this.View.UIName.Trim() + "View.cs", Model.GetEntity(this.View.UIFormWork, projectName, this.View.UIName));
            File.WriteAllText(this.View.ProjectPath + @"\UI\" + this.View.UIName.Trim() + "View.Designer.cs", Model.GetDesigner(projectName, this.View.UIName));
            File.WriteAllText(this.View.ProjectPath + @"\Views\I" + this.View.UIName.Trim() + "View.cs", Model.GetEntity(this.View.ViewsFormWork,projectName, this.View.UIName));
            File.WriteAllText(this.View.ProjectPath + @"\Presenters\" + this.View.UIName.Trim() + "Presenter.cs", Model.GetEntity(this.View.PresentersFormWork, projectName, this.View.UIName));
            File.WriteAllText(this.View.ProjectPath + @"\Models\" + this.View.UIName.Trim() + "Model.cs", Model.GetEntity(this.View.ModelsFormWork, projectName, this.View.UIName));
        }

        private void EditCsproj(string projectName)
        {
            XmlDocument xmldoc = new XmlDocument();
            StreamReader reader = new StreamReader(this.View.ProjectPath + @"\" + projectName + ".csproj");
            xmldoc.Load(reader);
            XmlNode Project = xmldoc["Project"];
            XmlNode ItemGroup = null;
            int count = 0;
            for(int i = 0; i < Project.ChildNodes.Count; i++)
            {
                if(Project.ChildNodes[i].LocalName == "ItemGroup")
                {
                    count++;
                    if(count == 2)
                    {
                        ItemGroup = Project.ChildNodes[i];
                    }
                }
            }

            XmlElement Compile1 = xmldoc.CreateElement("Compile", xmldoc.NamespaceURI);
            Compile1.RemoveAttribute("xmls");
            Compile1.SetAttribute("Include", @"UI\" + this.View.UIName.Trim() + "View.cs");
            XmlElement SubType1 = xmldoc.CreateElement("SubType");
            SubType1.RemoveAttribute("xmls");
            SubType1.InnerText = "UserControl";
            Compile1.AppendChild(SubType1);
            ItemGroup.AppendChild(Compile1);

            XmlElement Compile2 = xmldoc.CreateElement("Compile", xmldoc.NamespaceURI);
            Compile2.RemoveAttribute("xmls");
            Compile2.SetAttribute("Include", @"UI\" + this.View.UIName.Trim() + "View.Designer.cs");
            XmlElement SubType2 = xmldoc.CreateElement("DependentUpon");
            SubType2.RemoveAttribute("xmls");
            SubType2.InnerText = this.View.UIName.Trim() + "View.cs";
            Compile2.AppendChild(SubType2);
            ItemGroup.AppendChild(Compile2);

            XmlElement Compile3 = xmldoc.CreateElement("Compile", xmldoc.NamespaceURI);
            Compile3.RemoveAttribute("xmls");
            Compile3.SetAttribute("Include", @"Views\I" + this.View.UIName.Trim() + "View.cs");
            ItemGroup.AppendChild(Compile3);

            XmlElement Compile4 = xmldoc.CreateElement("Compile", xmldoc.NamespaceURI);
            Compile4.RemoveAttribute("xmls");
            Compile4.SetAttribute("Include", @"Presenters\" + this.View.UIName.Trim() + "Presenter.cs");
            ItemGroup.AppendChild(Compile4);

            XmlElement Compile5 = xmldoc.CreateElement("Compile", xmldoc.NamespaceURI);
            Compile5.RemoveAttribute("xmls");
            Compile5.SetAttribute("Include", @"Models\" + this.View.UIName.Trim() + "Model.cs");
            ItemGroup.AppendChild(Compile5);
            reader.Dispose();
            xmldoc.Save(this.View.ProjectPath + @"\" + projectName + ".csproj");

            string HaveXmls = File.ReadAllText(this.View.ProjectPath + @"\" + projectName + ".csproj", Encoding.UTF8);
            string NoHaveXmls = HaveXmls.Replace("xmlns=\"\"", "");
            File.WriteAllText(this.View.ProjectPath + @"\" + projectName + ".csproj", NoHaveXmls, Encoding.UTF8);
        }
    }
}
