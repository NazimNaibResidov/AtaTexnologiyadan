using System;
using System.Linq;
using System.Reflection;

namespace AtaTexnologiyadan.Extensions
{
    public static class CustomerMapper
    {
        public static T Mapped<T>(this object query)
        {
            if (query != null)
            {
                Type TargetType = typeof(T);
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }

        public static T Mapped<T>(this object query, object obj)
        {
            if (query != null)
            {
                Type TargetType = obj.GetType();
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }

        public static T Mapped<T>(this IQueryable<T> query)
        {
            if (query != null)
            {
                Type TargetType = query.GetType();
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }
    }
}