using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Sub_Wrecker
{
    class Wrecker
    {
        public static XDocument Wreck_Sub(XDocument sub, WreckerSettings settings)
        {
            int wreckedItems = 0;
            int deletedComponents = 0;
            int deletedWires = 0;
            int adjustedDoors = 0;
            int adjustedContainerTags = 0;
            string identifier;
            string re;
            if (settings.RenameSub)
            {
                sub.Root.Attribute("Name").Value += "_Wrecked";
            }    
            foreach (XElement xe in sub.Root.Descendants().Reverse())
            {
                if (xe.Attribute("identifier") != null)
                {
                    identifier = xe.Attribute("identifier").Value;
                    if (Data.Identifiers.ContainsKey(identifier))
                    {
                        xe.SetAttributeValue("identifier", Data.Identifiers[identifier]);
                        if (!settings.PreserveColour)
                        {
                            xe.SetAttributeValue("spritecolor", null);
                            xe.SetAttributeValue("SpriteColor", "255,255,255,255");
                        }
                        wreckedItems++;
                    }
                    if (settings.DeleteComponents && Data.SignalComponents.Contains(identifier))
                    {
                        deletedComponents++;
                        xe.Remove();
                        continue;
                    }
                    if (settings.DeleteWires && Data.Wires.Contains(identifier))
                    {
                        deletedWires++;
                        xe.Remove();
                        continue;
                    }
                    if (Data.Doors.Contains(identifier))
                    {
                        switch (settings.DoorBehaviour)
                        {

                            //Replace door and hatch ids with wreck_id
                            case 0:
                                foreach (XElement cxe in xe.Descendants())
                                {
                                    if (cxe.Attribute("items") == null || cxe.Name.ToString() != "requireditem") { continue; }
                                    adjustedDoors++;
                                    re = @"(?:(?<=,)|^)"
                                            + @"id(card|_(assistant|captain|engineer|mechanic|medic|security))"
                                            + @"(?:(?=,)|$)";
                                    cxe.SetAttributeValue("items", Regex.Replace(cxe.Attribute("items").Value, re, "wreck_id", RegexOptions.IgnoreCase));
                                }
                                break;
                            //Set canbepicked to False
                            case 1:
                                foreach (XElement cxe in xe.Descendants())
                                {
                                    if (cxe.Attribute("canbepicked") == null || cxe.Name.ToString() != "Door") { continue; }
                                    adjustedDoors++;
                                    re = "(?<=canbepicked=\")True(?=\")";
                                    cxe.SetAttributeValue("canbepicked", "False");
                                }
                                break;
                            //Leave doors and hatches alone
                            case 2:
                                break;
                            default:
                                break;
                        }
                    }

                }
                if  (xe.Attribute("tags") != null)
                {
                    string tags = xe.Attribute("tags").Value;
                    if (settings.ContainerTags)
                    {
                        foreach (KeyValuePair<string, string> kv in Data.ContainerTags)
                        {
                            re = @"(?:(?<=,)|^)" + kv.Key + @"(?:(?=,)|$)";
                            tags = Regex.Replace(tags, re, kv.Value, RegexOptions.IgnoreCase);
                        }
                        adjustedContainerTags++;
                        xe.SetAttributeValue("tags", tags);
                    } 

                }
            }
            Console.WriteLine("Wrecked " + wreckedItems.ToString() + " items.");
            if (settings.DeleteComponents) { Console.WriteLine("Deleted " + deletedComponents.ToString() + " components."); }
            if (settings.DeleteWires) { Console.WriteLine("Deleted " + deletedWires.ToString() + " wires."); }
            if (settings.DoorBehaviour == 1 || settings.DoorBehaviour == 2) { Console.WriteLine("Adjusted " + adjustedDoors.ToString() + " doors."); }
            if (settings.ContainerTags) { Console.WriteLine("Changed tags on " + adjustedContainerTags.ToString() + " containers."); }
            return sub;
        }
    }
}
