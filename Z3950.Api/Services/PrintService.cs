using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Reflection;
using Z3950.Api.Attrs;
using MARC;
using System.Linq;

namespace Z3950.Api.Services
{
    public class PrintService : IPrintService
    {
        public PrintService()
        {

        }

        public bool Print<TEntity>(List<TEntity> data, string filePath)
        {
            //before your loop
            //var csv = new StringBuilder();
            var fields = GetFields(typeof(TEntity));
            var rowFormat = new List<string>();

            var titles = new List<string>();
            for (var i = 0; i < fields.Count; ++i)
            {
                rowFormat.Add("{" + $"{i}" + "}");
                titles.Add(fields.ElementAt(i).Value.Name);
            }
            var rowFormatStr = string.Join(',', rowFormat);
            var titleLine = string.Format(rowFormatStr, titles.ToArray());


            Encoding encoding = Encoding.UTF8; //Or any other Encoding

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(fs, encoding))
                {
                    writer.WriteLine(titleLine);

                    //in your loop
                    foreach (var item in data)
                    {
                        var values = new List<string>();
                        foreach (var field in fields)
                        {
                            var prop = field.Key;
                            var attr = field.Value.Name;
                            var value = prop.GetValue(item) + "";
                            values.Add(value.Replace(",","-"));
                        }
                        //Suggestion made by KyleMit
                        var newLine = string.Format(rowFormatStr, values.ToArray());
                        writer.WriteLine(newLine);
                    }
                }
            }

            return true;
        }

        public Dictionary<PropertyInfo, FieldNameAttribute> GetFields(Type type)
        {
            var fields = new Dictionary<PropertyInfo, FieldNameAttribute>();
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                var marcFieldAttr = prop.GetCustomAttribute<FieldNameAttribute>();
                if (marcFieldAttr != null)
                {
                    fields.Add(prop, marcFieldAttr);
                }
            }
            return fields;
        }
    }
}
