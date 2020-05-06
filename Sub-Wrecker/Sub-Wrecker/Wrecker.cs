using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Sub_Wrecker
{
    internal class Wrecker
    {
        public static XDocument Wreck_Sub(XDocument sub, WreckerSettings settings)
        {
            // Set some values to 0 for statistics when finished.
            int wreckedItems = 0;
            int deletedComponents = 0;
            int adjustedSpawnpoints = 0;
            int deletedWires = 0;
            int adjustedDoors = 0;
            int adjustedContainerTags = 0;
            string identifier;
            string re;
            Console.WriteLine("Wrecking " + sub.Root.Attribute("name").Value.ToString() + "...");
            if (settings.RenameSub)
            {
                sub.Root.Attribute("name").Value += "_Wrecked";
            }
            // Reversed so that deleted parent elements won't cause crashes when it should iterate over their children
            foreach (XElement xe in sub.Root.Descendants().Reverse())
            {
                if (xe.Attribute("identifier") != null)
                {
                    // Attempt to wreck an item based on its identifier
                    identifier = xe.Attribute("identifier").Value;
                    if (Data.Identifiers.ContainsKey(identifier))
                    {
                        // Wreck it
                        xe.SetAttributeValue("identifier", Data.Identifiers[identifier]);
                        if (!settings.PreserveColour)
                        {
                            // Reset its colour
                            xe.SetAttributeValue("spritecolor", null);
                            xe.SetAttributeValue("SpriteColor", "255,255,255,255");
                        }
                        wreckedItems++;
                    }
                    // Kill wiring components
                    if (settings.DeleteComponents && Data.SignalComponents.Contains(identifier))
                    {
                        deletedComponents++;
                        xe.Remove();
                        continue;
                    }
                    // Kill wires
                    if (settings.DeleteWires && Data.Wires.Contains(identifier))
                    {
                        deletedWires++;
                        xe.Remove();
                        continue;
                    }
                    // Door behaviour
                    if (Data.Doors.Contains(identifier))
                    {
                        switch (settings.DoorBehaviour)
                        {

                            //Replace door and hatch ids with wreck_id
                            case 0:
                                foreach (XElement cxe in xe.Descendants())
                                {
                                    if (cxe.Attribute("items") == null || cxe.Name.ToString() != "requireditem") { continue; }
                                    re = @"(?:(?<=,)|^)"
                                            + @"id(card|_(assistant|captain|engineer|mechanic|medic|security))"
                                            + @"(?:(?=,)|$)";
                                    if (Regex.IsMatch(cxe.Attribute("items").Value, re))
                                    {
                                        adjustedDoors++;
                                        cxe.SetAttributeValue("items", Regex.Replace(cxe.Attribute("items").Value, re, "wreck_id", RegexOptions.IgnoreCase));
                                    }
                                }
                                break;
                            //Set canbepicked to False
                            case 1:
                                foreach (XElement cxe in xe.Descendants())
                                {
                                    if (cxe.Attribute("canbepicked") == null || cxe.Name.ToString() != "Door") { continue; }
                                    adjustedDoors++;
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
                if (xe.Attribute("tags") != null)
                {
                    string tags = xe.Attribute("tags").Value;
                    // Adjust tags on containers
                    if (settings.ContainerTags)
                    {
                        foreach (KeyValuePair<string, string> kv in Data.ContainerTags)
                        {
                            re = @"(?:(?<=,)|^)" + kv.Key + @"(?:(?=,)|$)";
                            if (Regex.IsMatch(tags, re))
                            {
                                adjustedContainerTags++;
                                tags = Regex.Replace(tags, re, kv.Value, RegexOptions.IgnoreCase);
                            }
                        }
                        xe.SetAttributeValue("tags", tags);
                    }

                }
                if (xe.Name.ToString().ToLower() == "waypoint")
                {
                    if (xe.Attribute("spawn") != null)
                    {
                        if (xe.Attribute("spawn").Value.ToString().ToLower() != "path")
                        {
                            switch (settings.SpawnpointBehaviour)
                            {
                                // Delete spawnpoints
                                case 0:
                                    adjustedSpawnpoints++;
                                    xe.Remove();
                                    break;
                                // Turn into corpse spawnpoint
                                case 1:
                                    adjustedSpawnpoints++;
                                    xe.SetAttributeValue("spawn", "corpse");
                                    break;
                                // Leave it alone
                                case 2:
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            // Print out statistics
            Console.WriteLine("Wrecked " + wreckedItems.ToString() + " items.");
            if (settings.DeleteComponents) { Console.WriteLine("Deleted " + deletedComponents.ToString() + " components."); }
            if (settings.DeleteWires) { Console.WriteLine("Deleted " + deletedWires.ToString() + " wires."); }
            if (settings.DoorBehaviour == 1 || settings.DoorBehaviour == 2) { Console.WriteLine("Adjusted " + adjustedDoors.ToString() + " doors."); }
            if (settings.ContainerTags) { Console.WriteLine("Adjusted " + adjustedContainerTags.ToString() + " tags on containers."); }
            switch (settings.SpawnpointBehaviour)
            {
                case 0:
                    Console.WriteLine("Deleted " + adjustedSpawnpoints.ToString() + " spawnpoints.");
                    break;
                case 1:
                    Console.WriteLine("Turned " + adjustedSpawnpoints.ToString() + " spawnpoints into corpse spawnpoints.");
                    break;
            }    
            Console.WriteLine("...wrecked.");
            return sub;
        }
    }
}
