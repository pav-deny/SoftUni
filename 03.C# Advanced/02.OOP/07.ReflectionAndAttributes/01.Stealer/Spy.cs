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
    }
}
