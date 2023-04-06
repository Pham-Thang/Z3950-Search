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
            var dic = new Dictionary<PropertyInfo, MARCDataFieldAttribute>();
            foreach (var prop in properties)
            {
                var marcFieldAttr = prop.GetCustomAttribute<MARCDataFieldAttribute>();
                if (marcFieldAttr != null)
                {
                    dic.Add(prop, marcFieldAttr);
                }
            }
            // Get leader field
            var leaderProp = properties.FirstOrDefault(x => x.GetCustomAttribute<MARCLeaderFieldAttribute>() != null);

            var models = new List<TEntity>();
            for (int i = 0; i < reader.Count; i++)
            {
                var record = reader[i];
                var model = (TEntity)Activator.CreateInstance(typeof(TEntity));
                leaderProp?.SetValue(model, record.Leader);
                foreach (var (prop, attr) in dic)
                {
                    var values = new List<string>();
                    if (record[attr.Tag]?.IsControlField() == true)
                    {
                        var field = (ControlField)record[attr.Tag];
                        values.Add(field.Data);
                    } 
                    else if (record[attr.Tag]?.IsDataField() == true)
                    {
                        var isList = true;
                        var fields = record.GetFields(attr.Tag);
                        foreach (var field in fields)
                        {
                            var subfields = ((DataField)field).GetSubfields(attr.Code);
                            foreach (var subfield in subfields)
                            {
                                values.Add(subfield.Data);
                            }
                        }
                    }
                    prop.SetValue(model, string.Join(" --- ", values));
                }
                models.Add(model);
            }
            return models;
        }
    }
}
