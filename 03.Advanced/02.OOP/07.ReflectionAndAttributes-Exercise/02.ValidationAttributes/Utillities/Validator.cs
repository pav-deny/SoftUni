using System;
using System.Collections.Generic;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utillities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();

            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> validationAttributes = property.GetCustomAttributes<MyValidationAttribute>();
            
                foreach (MyValidationAttribute validationAttribute in validationAttributes)
                {
                    object value = property.GetValue(obj);

                    if (!validationAttribute.IsValid(value))
                        return false;
                }
            }

            return true;
        }
    }
}
