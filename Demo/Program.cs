
using System;
using Zoom.Net.YazSharp;
using Zoom.Net;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using MARC;
using Demo.Models;
using System.Reflection;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//create a connection and provide the server details. Here I have used the LOC server
Connection cnn = new Connection("z3950.nlv.gov.vn", 9999);
//provide the name of the database on the server
cnn.DatabaseName = "biblios";
//define the syntax type that will be required. Here i am defining XML viz MarcXml
cnn.Syntax = RecordSyntax.XML;
//Connect to the server
cnn.Connect();
//Declare your query
// https://nlv.gov.vn/tai-lieu-nghiep-vu/xml-metadata-va-dublin-core-metadata.html
// Title - Nhan đề của tài liệu
// Creator - Tác giả của tài liệu, bao gồm cả tác giả cá nhân và tác giả tập thể.
// Subject
// Description
// Publisher
// Date
// Format
// Identifier=\"9786046482307\" - Các thông tin về định danh tài liệu, các nguồn tham chiếu đến, hoặc chuỗi ký tự để định vị tài nguyên
// Language

//var query = "Title=\"thang\" OR Creator=\"p\" OR Subject=\"p\" OR Description=\"p\" OR Publisher=\"p\" OR Identifier=\"p\"";
var query = "Title=\"Canberra\"";
//Create the object for query. 
CQLQuery q = new CQLQuery(query);
IResultSet results;
//perform search
results = (ResultSet)cnn.Search(q);
// Now iterate through to the results and get the xml of each record fetched and derive from it the needed values.
var reader = new FileMARCXML();
for (uint i = 0; i < results.Size; i++)
{
    string temp = Encoding.UTF8.GetString(results[i].Content);
    //This string is having the xml in string format. Convert it into the xml via XmlDocument
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(temp);
    //perform the needful operations
    //............... 
    //...............
    //............... 
    Console.WriteLine("-------------------");
    Console.WriteLine(doc.InnerXml);

    reader.Add(doc.InnerXml);
}
var properties = typeof(DocumentEntity).GetProperties();
var dic = new Dictionary<PropertyInfo, MARCFieldAttribute>();
foreach (var prop in properties)
{
    var marcFieldAttr = prop.GetCustomAttribute<MARCFieldAttribute>();
    if (marcFieldAttr != null)
    {
        dic.Add(prop, marcFieldAttr);
    }
}

var models = new List<DocumentEntity>();
for (int i = 0; i < reader.Count; i++)
{
    var record = reader[i];
    var model = new DocumentEntity();
    foreach (var item in dic)
    {
        var prop = item.Key;
        var attr = item.Value;
        var value = ((DataField)(record)[attr.Tag])?.GetSubfields(attr.Char)?.FirstOrDefault()?.Data;
        prop.SetValue(model, value);
    }
    models.Add(model);
}
Console.WriteLine(models);