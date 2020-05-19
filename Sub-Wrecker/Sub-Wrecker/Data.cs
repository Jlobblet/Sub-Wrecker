using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Sub_Wrecker
{
    internal class Data
    {
        private readonly static Dictionary<string, string> containerTags = XElement
            .Parse(File.ReadAllText("Resources/ContainerTags.xml"))
            .Elements()
            .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());

        private readonly static List<string> doors = XElement
            .Parse(File.ReadAllText("Resources/Doors.xml"))
            .Descendants()
            .Select(XElement => XElement.Name.ToString())
            .ToList();

        private readonly static Dictionary<string, string> identifiers = XElement
            .Parse(File.ReadAllText("Resources/Identifiers.xml"))
            .Elements()
            .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());

        private readonly static List<string> lights = XElement
            .Parse(File.ReadAllText("Resources/Lights.xml"))
            .Elements()
            .Select(XElement => XElement.Name.ToString())
            .ToList();

        private readonly static List<string> signalComponents = XElement
           .Parse(File.ReadAllText("Resources/SignalComponents.xml"))
           .Descendants()
           .Select(XElement => XElement.Name.ToString())
           .ToList();

        private readonly static List<string> wires = XElement
            .Parse(File.ReadAllText("Resources/Wires.xml"))
            .Descendants()
            .Select(XElement => XElement.Name.ToString())
            .ToList();

        private readonly static List<string> condition = XElement
            .Parse(File.ReadAllText("Resources/Condition.xml"))
            .Descendants()
            .Select(XElement => XElement.Name.ToString())
            .ToList();

        public static Dictionary<string, string> ContainerTags { get => containerTags; }
        public static List<string> Doors { get => doors; }
        public static Dictionary<string, string> Identifiers { get => identifiers; }
        public static List<string> Lights { get => lights; }
        public static List<string> SignalComponents { get => signalComponents; }
        public static List<string> Wires { get => wires; }
        public static List<string> Condition { get => condition; }
    }
}
