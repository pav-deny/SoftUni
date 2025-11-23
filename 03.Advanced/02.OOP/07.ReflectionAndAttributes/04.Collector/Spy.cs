using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldssToInvestigate)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(f => fieldssToInvestigate.Contains(f.Name)).ToArray();
            Hacker instance = (Hacker)Activator.CreateInstance(classType);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fields)
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");

            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new();

            foreach (FieldInfo field in fields)
            {
                if (field.IsPublic)
                    sb.AppendLine($"{field.Name} must be private!");
            }

            PropertyInfo[] properties = classType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                MethodInfo method = property.GetGetMethod(true);
                if (!method.IsPublic)
                    sb.AppendLine($"{method.Name} have to be public!");


                method = property.GetSetMethod(true);
                if (method.IsPublic)
                    sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            StringBuilder sb = new();
            sb.AppendLine($"All Private Methods of Class: {className}");

            Type baseType = classType.BaseType;
            sb.AppendLine($"Base Class: {baseType.Name}");

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
                sb.AppendLine(method.Name);

            return sb.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            StringBuilder sb = new();

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo getter in methods.Where(g => g.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (MethodInfo setter in methods.Where(g => g.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString();
        }
    }
}
