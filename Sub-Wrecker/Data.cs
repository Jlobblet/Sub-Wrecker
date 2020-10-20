using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Sub_Wrecker
{
    internal static class Data
    {
        static Data()
        {
            Doors = XElement
                    .Parse(File.ReadAllText("Resources/Doors.xml"))
                    .Descendants()
                    .Select(elt => elt.Name.ToString())
                    .ToList();
            
            ContainerTags = XElement
                            .Parse(File.ReadAllText("Resources/ContainerTags.xml"))
                            .Elements()
                            .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());
            
            Identifiers = XElement
                          .Parse(File.ReadAllText("Resources/Identifiers.xml"))
                          .Elements()
                          .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());
            
            Lights = XElement
                        .Parse(File.ReadAllText("Resources/Lights.xml"))
                        .Elements()
                        .Select(elt => elt.Name.ToString())
                        .ToList();
            
            SignalComponents = XElement
                               .Parse(File.ReadAllText("Resources/SignalComponents.xml"))
                               .Descendants()
                               .Select(elt => elt.Name.ToString())
                               .ToList();
            
            Wires = XElement
                    .Parse(File.ReadAllText("Resources/Wires.xml"))
                    .Descendants()
                    .Select(elt => elt.Name.ToString())
                    .ToList();
            
            Condition = XElement
                        .Parse(File.ReadAllText("Resources/Condition.xml"))
                        .Descendants()
                        .Select(elt => elt.Name.ToString())
                        .ToList();
        }

        public static Dictionary<string, string> ContainerTags { get; }
        public static List<string> Doors { get; }
        public static Dictionary<string, string> Identifiers { get; }
        public static List<string> Lights { get; }
        public static List<string> SignalComponents { get; }
        public static List<string> Wires { get; }
        public static List<string> Condition { get; }
    }
}
