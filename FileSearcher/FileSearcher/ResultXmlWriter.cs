using System;
using System.IO;
using System.Text;
using System.Xml;
using FileSearchr.Composite;
using Directory = FileSearchr.Composite.Directory;
using File = FileSearchr.Composite.File;

namespace FileSearchr
{
    public class ResultXmlWriter : IComponentWriter
    {
        private string _xmlString;

        public void Write(Component root, string saveFile)
        {
            Write(root as Directory);
            Save(saveFile);
        }

        public XmlWriterSettings XmlWriterSettings(Encoding encoding = null)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = encoding ?? Encoding.GetEncoding("utf-8");
            return settings;
        }

        public void Write(Directory root)
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(sw, XmlWriterSettings()))
                    {
                        xmlWriter.WriteStartElement("Folders");

                        Write(xmlWriter, root);

                        xmlWriter.WriteEndElement();
                    }
                    _xmlString = sw.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void Write(XmlWriter xmlWriter, Directory root)
        {
            if (root == null)
            {
                return;
            }

            foreach (var component in root.Children)
            {
                switch (component)
                {
                    case Directory folder:
                        xmlWriter.WriteStartElement("Folder");
                        xmlWriter.WriteAttributeString("name", folder.Name);
                        Write(xmlWriter, folder);
                        xmlWriter.WriteEndElement();
                        break;
                    case File leapfile:
                        xmlWriter.WriteStartElement("File");
                        xmlWriter.WriteAttributeString("name", leapfile.Name);
                        xmlWriter.WriteAttributeString("updated", leapfile.GetUpdatedDateString());
                        xmlWriter.WriteEndElement();
                        break;
                }
            }
        }

        public void Save(string saveFile)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(_xmlString);
            xmlDocument.Save(saveFile);
        }
    }
}
