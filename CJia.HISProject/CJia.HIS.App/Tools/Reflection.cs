using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CJia.HIS.App.Tools
{
    public static class Reflection
    {
        public static object GetInstance(string assemblyName, string typeName, object[] parameters)
        {
            Assembly assembly = assemblyName == "CJia.HIS.App.dll"
                ? Assembly.GetCallingAssembly() : Assembly.LoadFrom(assemblyName);
            Type type = assembly.GetType(typeName);
            Type[] types = new Type[parameters.Length];
            for(int i = 0; i < parameters.Length ; i++)
            {
                types[i] = parameters[i].GetType();
            }
            ConstructorInfo constructorInfo = type.GetConstructor(types);
            return constructorInfo.Invoke(parameters);
        }

    }
}
