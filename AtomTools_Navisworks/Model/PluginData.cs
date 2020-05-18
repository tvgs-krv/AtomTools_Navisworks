using System;
using System.Xml.Serialization;

namespace AtomTools_Navisworks.Model
{
    [Serializable]
    public class PluginData
    {
        [XmlElement("AppName")]
        public string AppName { get; set; }
        [XmlElement("AppPath")]
        public string AppPath { get; set; }
        [XmlIgnore]
        public bool IsInstalled { get; set; }   
        [XmlElement("AppDescription")]
        public string AppDescription { get; set; }
        [XmlElement("AppVersion")]
        public string AppVersion { get; set; }
        [XmlElement("Author")]
        public string Author { get; set; }
        [XmlElement("NavisworksVersion")]
        public string NavisworksVersion { get; set; }


    }
}
