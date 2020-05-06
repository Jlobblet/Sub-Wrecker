using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sub_Wrecker
{
    class Data
    {
        public static Dictionary<string, string> Identifiers = XElement
            .Parse(File.ReadAllText("Resources/Identifiers.xml"))
            .Elements()
            .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());

        public static Dictionary<string, string> ContainerTags = XElement
            .Parse(File.ReadAllText("Resources/ContainerTags.xml"))
            .Elements()
            .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());

        public static List<string> SignalComponents = XElement
            .Parse(File.ReadAllText("Resources/SignalComponents.xml"))
            .Descendants()
            .Select(XElement => XElement.Name.ToString())
            .ToList();

        public static List<string> Wires = XElement
            .Parse(File.ReadAllText("Resources/Wires.xml"))
            .Descendants()
            .Select(XElement => XElement.Name.ToString())
            .ToList();

        public static List<string> Doors = XElement
            .Parse(File.ReadAllText("Resources/Doors.xml"))
            .Descendants()
            .Select(XElement => XElement.Name.ToString())
            .ToList();
    }
}
