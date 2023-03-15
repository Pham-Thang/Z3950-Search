using MARC;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Text;
using System.Xml;
using Z3950.Api.Attrs;
using Zoom.Net;
using Zoom.Net.YazSharp;

namespace Z3950.Api.Services
{
    public class MARCXmlReader : IMARCXmlReader
    {
        public MARCXmlReader()
        {

        }

        public List<TEntity> ReadMARCXmlStrings<TEntity>(List<string> marcxmls)
            where TEntity : class
        {
            if (marcxmls == null)
            {
                return null;
            };

            // Now iterate through to the results and get the xml of each record fetched and derive from it the needed values.
            var reader = new FileMARCXML();
            for (int i = 0; i < marcxmls.Count; i++)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(marcxmls[i]);
                reader.Add(doc.InnerXml);
            }
            var properties = typeof(TEntity).GetProperties();
            var dic = new Dictionary<PropertyInfo, MARCFieldAttribute>();
            foreach (var prop in properties)
            {
                var marcFieldAttr = prop.GetCustomAttribute<MARCFieldAttribute>();
                if (marcFieldAttr != null)
                {
                    dic.Add(prop, marcFieldAttr);
                }
            }

            var models = new List<TEntity>();
            for (int i = 0; i < reader.Count; i++)
            {
                var record = reader[i];
                var model = (TEntity)Activator.CreateInstance(typeof(TEntity));
                foreach (var item in dic)
                {
                    var prop = item.Key;
                    var attr = item.Value;
                    var values = ((DataField)(record)[attr.Tag])?.GetSubfields(attr.Code);
                    var value = values?.FirstOrDefault()?.Data;
                    if (value != null)
                    {
                        prop.SetValue(model, value);
                    }
                }
                models.Add(model);
            }
            return models;
        }
    }
}
