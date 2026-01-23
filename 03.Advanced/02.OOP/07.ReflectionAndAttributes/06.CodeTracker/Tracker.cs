using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        public Tracker()
        {

        }

        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    
                    foreach (AuthorAttribute attribute in attributes.Where(a => a.GetType() == typeof(AuthorAttribute)))
                    {
                        Console.WriteLine("{0} is wirtten by {1}", method.Name, attribute.Name);
                    }
                }
            }

            ////Second way
            
            //Type[] allTypes = typeof(Tracker).Assembly.GetTypes();

            //foreach (Type type in allTypes)
            //{
            //    var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //    foreach (var method in methods)
            //    {
            //        var authorAttribute = method.GetCustomAttributes<AuthorAttribute>()
            //            .Select(attr => attr.Name).ToList();

            //        if (authorAttribute.Any())
            //        Console.WriteLine($"{method.Name} is written by {string.Join(", " , authorAttribute)}");
            //    }
            //}
        }
    }
}

