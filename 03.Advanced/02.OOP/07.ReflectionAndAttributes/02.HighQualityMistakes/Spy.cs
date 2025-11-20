using System.Text;
using System.Reflection;

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
    }
}
