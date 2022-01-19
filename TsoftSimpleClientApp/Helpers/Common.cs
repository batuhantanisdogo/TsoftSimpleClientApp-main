using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using RestSharp;

namespace TsoftSimpleClientApp.Helpers
{
    public static class Common
    {

        public static void SetParameter<T>(this T obj, bool includeNullData,ref RestRequest request) where T:class,new()
        {
            var type = typeof(T);
            var props = type.GetProperties().Where(x => x.CanRead).ToList();
            foreach (var prop in props)
            {
                var jsonIgnoreAttr = prop.GetCustomAttributes<JsonIgnoreAttribute>(true).ToList();
                
                if(jsonIgnoreAttr.Any())
                    continue;
                
                var jsonAttr = prop.GetCustomAttributes<JsonPropertyAttribute>(true).ToList();
                var name = "";
                
                
                if (jsonAttr.Any())
                {
                    name = jsonAttr.FirstOrDefault()?.PropertyName ?? prop.Name;
                }
                else
                {
                    name = prop.Name;
                }

                
                var converter = TypeDescriptor.GetConverter(prop.PropertyType);
                // if(!converter.CanConvertFrom(prop.PropertyType))
                //     continue;
                try
                {
                    var val = converter.ConvertFromInvariantString(prop.GetValue(obj)?.ToString()??"");
                    // var jsonValue= prop.GetCustomAttributes<JsonConverterAttribute>(true).ToList();
                    // JsonConvert.
                    
                    if(val==null||string.IsNullOrEmpty(val?.ToString()))
                        continue;
                    
                    // var noneNullableParam = val;
                    request.AddParameter<>(name,val);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static T GetTsoftColumnValue<T, TClass>(this TClass obj, string tsoftColumn)
        {
            var type = typeof(TClass);
            var props = type.GetProperties().Where(x => x.CanRead).ToList();
            var rt = default(T);
            foreach (var prop in props)
            {
                var jsonIgnoreAttr = prop.GetCustomAttributes<JsonIgnoreAttribute>(true).ToList();
                
                if(jsonIgnoreAttr.Any())
                    continue;
                
                var jsonAttr = prop.GetCustomAttributes<JsonPropertyAttribute>(true).ToList();
                var name = "";
                
                if (jsonAttr.Any())
                {
                    name = jsonAttr.FirstOrDefault()?.PropertyName ?? prop.Name;
                }
                else
                {
                    name = prop.Name;
                }

                if (name!=tsoftColumn)
                {
                    continue;
                }
                
                var converter = TypeDescriptor.GetConverter(typeof(T));
                
                try
                {
                    var val = converter.ConvertFromInvariantString(prop.GetValue(obj)?.ToString()??"");
                    
                    rt= ((T)val).IsNullDefault();
                }
                catch (Exception e)
                {
                    rt= default(T);
                }
                
                break;
                
            }

            return rt;
        }

        public static IEnumerable<string> GetTsoftColumns<T>(this T obj)where T:class,new()
        {
            var columnsList = new List<string>();
            var type = typeof(T);
            var props = type.GetProperties().Where(x => x.CanRead).ToList();
            foreach (var prop in props)
            {
                var jsonIgnoreAttr = prop.GetCustomAttributes<JsonIgnoreAttribute>(true).ToList();
                
                if(jsonIgnoreAttr.Any())
                    continue;
                
                var jsonAttr = prop.GetCustomAttributes<JsonPropertyAttribute>(true).ToList();
                var name = "";
                
                
                if (jsonAttr.Any())
                {
                    name = jsonAttr.FirstOrDefault()?.PropertyName ?? prop.Name;
                }
                else
                {
                    name = prop.Name;
                }
                
                columnsList.Add(name);
            }

            return columnsList;
        }
        
        public static string GetTsoftColumnName<T>(this T obj, string fieldName)
        {
            var type = typeof(T);
            var prop = type.GetProperties().FirstOrDefault(x => x.CanRead&&x.Name.Equals(fieldName));
            
            if (prop is null) return string.Empty;
            
            var jsonAttr = prop.GetCustomAttributes<JsonPropertyAttribute>(true).ToList();
            var name = "";
            if (jsonAttr.Any())
            {
                name = jsonAttr.FirstOrDefault()?.PropertyName ?? prop.Name;
            }
            else
            {
                name = prop.Name;
            }

            return name;

        }
        
        public static IEnumerable<T> GetAttributes<T>(this Type type) where T : Attribute
        {
            foreach (T customAttribute in CustomAttributeExtensions.GetCustomAttributes(type.GetTypeInfo(), typeof (T), false))
                yield return customAttribute;
        }
        
        
        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(this string source)
        {
            return Regex.Replace(source.ToSafeString(), "<.*?>", string.Empty);
        }
    
        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
    
        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            return _htmlRegex.Replace(source, string.Empty);
        }
        
        public static string ToSafeString(this object obj)
        {
            if (obj == null)
                return string.Empty;

            return obj.ToString();
        }

        public static string ToSafeString(this object obj, string defaultValue = null)
        {
            if (obj == null)
                return (defaultValue ?? string.Empty);

            return obj.ToString();
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsDbNull(this object obj)
        {
            return obj == DBNull.Value;
        }

        public static bool IsEmpty<T>(this ICollection<T> source)
        {
            return (source == null || source.Count == 0);
        }

        public static T IsNullDefault<T>(this T obj)
        {
            if (obj == null)
                return default(T);
            else
                return obj;
        }

        public static T IsNullDefault<T>(this T obj, object defaultValue)
        {
            if (obj == null)
                return (T)defaultValue;

            return obj;
        }
        
        public static string ToBase64(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string FromBase64(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(text));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ToCapitalize(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text.ToLowerInvariant());
        }

        public static string ClearText(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text.Trim().ToLowerInvariant().ToSafeString();
        }
       
        public static DateTime ConvertIstanbulDateTime(DateTime dateTime)
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            var istanbulTimeZone = timeZones.FirstOrDefault(x => x.Id.Contains("Turkey") || x.Id.Contains("Istanbul"));
            var localTime = TimeZoneInfo.ConvertTime(new DateTime(dateTime.Ticks, DateTimeKind.Local),
                TimeZoneInfo.Local,
                istanbulTimeZone!);
            return localTime;
        }

        public static string ClearTextForCsvColumn(this string text,string csvSeparator=",")
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            var escapedString = text.ToSafeString().Replace(csvSeparator, string.Empty);
            escapedString = Regex.Replace(escapedString, @"\r\n?|\n", string.Empty);
            return escapedString.ToSafeString();
        }
        
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}