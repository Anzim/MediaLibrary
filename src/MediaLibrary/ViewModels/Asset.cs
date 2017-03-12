using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MediaLibrary.ViewModels
{
    public class Asset
    {
        public void CopyFrom<T>(T source)
        {
            var type = typeof(T);
            IEnumerable<string> propertyNames = type.GetProperties().Select(p => p.Name);
            CopyFrom(source, propertyNames);
        }

        public void CopyFrom<T>(T source, IEnumerable<string> propertyNames)//, bool ignoreErrors = true)
        {
            var sourceType = typeof(T);
            var type = GetType();
            foreach (var sourcePropertyName in propertyNames)
            {
                var targetProperty = type.GetProperty(sourcePropertyName);
                targetProperty?.SetValue(this, sourceType.GetProperty(sourcePropertyName).GetValue(source, null), null);
            }
            //foreach (var sourceField in type.GetFields())
        }
    }
}