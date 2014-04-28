using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace ComHub
{
    /// partner = Roadwire
    /// vendor = Roadwire
    /// merchant = costco

    public class MessageBatch
    {
        protected string xsdFile;

        public static T Deserialize<T>(string path)
        {
            XDocument doc = XDocument.Load(path);
            return SerializationUtil.Deserialize<T>(doc);
        }

        public XDocument Serialize()
        {
            Type t = this.GetType();
            return SerializationUtil.Serialize(t, this);
        }

        public void ValidateXml()
        {
            SerializationUtil.ValidateXml(Serialize(), this.xsdFile);
        }

        public FileInfo SaveFile(string path)
        {
            XDocument doc = Serialize();
            doc.Save(path);
            return new FileInfo(path);
        }
    }

}
