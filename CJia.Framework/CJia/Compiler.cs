using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace CJia
{
    /// <summary>
    /// 编译器
    /// </summary>
    public static class Compiler
    {
        static CompilerParameters CompParams = new CompilerParameters();
        static CSharpCodeProvider csCompiler = new CSharpCodeProvider();
        //可以指定编译器版本
        //CSharpCodeProvider csCompiler = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });

        #region 编译
        /// <summary>
        /// 编译器
        /// </summary>
        static Compiler()
        {
            CompParams.IncludeDebugInformation = false;
            SetReferencedAssemblies();
        }
        /// <summary>
        /// 设置引用程序集
        /// </summary>
        public static void SetReferencedAssemblies()
        {
            CompParams.ReferencedAssemblies.Clear();
            CompParams.ReferencedAssemblies.Add("mscorlib.dll");
            CompParams.ReferencedAssemblies.Add("System.dll");
            CompParams.ReferencedAssemblies.Add("System.dll");
            CompParams.ReferencedAssemblies.Add("System.Data.dll");
            CompParams.ReferencedAssemblies.Add("System.Xml.dll");
            CompParams.ReferencedAssemblies.Add("System.configuration.dll");
            CompParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            //string Path = Application.StartupPath + "\\";
            //CompParams.ReferencedAssemblies.Add(Path + "CJia.dll");
            CompParams.ReferencedAssemblies.Add(@"E:\CJProject\CJia.Solution\Framework\CJia\bin\Debug\CJia.dll");
        }
        /// <summary>
        /// 编译可执行程序
        /// </summary>
        /// <param name="SourceCode"></param>
        /// <param name="OutputExeFileName"></param>
        /// <returns></returns>
        public static bool BuildApp(string SourceCode, string OutputExeFileName)
        {
            CompParams.GenerateInMemory = false;
            //CompParams.GenerateExecutable = true;
            CompParams.CompilerOptions = "/target:winexe /optimize";
            CompParams.OutputAssembly = OutputExeFileName;

            CompilerResults results = csCompiler.CompileAssemblyFromSource(CompParams, SourceCode);
            if (results.Errors.Count == 0)
                return true;
            else
            {
                StringBuilder sbError = new StringBuilder();
                foreach (CompilerError ce in results.Errors)
                {
                    sbError.AppendLine(ce.ErrorText);
                }
                throw new Exception(sbError.ToString());
            }
        }

        /// <summary>
        /// 编译源码，返回指定类型
        /// </summary>
        /// <param name="SourceCode">源码</param>
        /// <returns>报表实例</returns>
        public static dynamic BuildDynamicObject(string SourceCode)
        {
            CompParams.GenerateInMemory = true;
            CompParams.CompilerOptions = "/target:library /optimize";

            CompilerResults results = csCompiler.CompileAssemblyFromSource(CompParams, SourceCode);
            if (results.Errors.Count != 0)
            {
                StringBuilder sbError = new StringBuilder();
                foreach (CompilerError ce in results.Errors)
                {
                    sbError.AppendLine(ce.ErrorText);
                }
                throw new Exception(sbError.ToString());
            }
            Assembly asm = results.CompiledAssembly;

            Type[] repTypes = asm.GetTypes();
            if (repTypes.Length > 0)
            {
                object MyClass = asm.CreateInstance(repTypes[0].FullName);
                return MyClass;
            }

            return null;
        }
        #endregion
    }
}
