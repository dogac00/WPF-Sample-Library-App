using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CetLibrary.Service
{
    public class DataValidator
    {
        public readonly struct ErrorInfo
        {
            public string Property { get; }
            public string Message { get; }

            public ErrorInfo(string property, string message)
            {
                this.Property = property;
                this.Message = message;
            }
        }

        public static IEnumerable<ErrorInfo> Validate(object instance)
        {
            return from prop in instance.GetType().GetProperties()
                   from attribute in prop.GetCustomAttributes(typeof(ValidationAttribute), true).OfType<ValidationAttribute>()
                   where !attribute.IsValid(prop.GetValue(instance, null))
                   select new ErrorInfo(prop.Name, attribute.FormatErrorMessage(string.Empty));
        }
    }

}
