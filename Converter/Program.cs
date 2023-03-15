// See https://aka.ms/new-console-template for more information
using Converter.Data;
using MARC;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

// Create Stream
//var stream = new MemoryStream();
//var writer = new StreamWriter(stream);
//writer.Write(MARCXMLString.Single);
//writer.Flush();
//stream.Position = 0;
XDocument doc = new XDocument(MARCXMLString.Single);

var reader = new FileMARCXML(doc);

foreach (var element in reader)
{
    Console.WriteLine(JsonConvert.SerializeObject(element));
}
//reader.GetEnumerator();
