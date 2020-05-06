using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sub_Wrecker
{
    class WreckerSettings
    {
        public bool ContainerTags { get; set; }
        public bool DeleteComponents { get; set; }
        public bool DeleteSpawnpoints { get; set; }
        public bool DeleteWires { get; set; }
        public int DoorBehaviour { get; set; }
        public bool Inplace { get; set; }
        public bool PreserveColour { get; set; }
        public bool RenameSub { get; set; }

        public WreckerSettings(bool containerTags, bool deleteComponents, bool deleteSpawnpoints, bool deleteWires, int doorBehaviour, bool inplace, bool preserveColour, bool renameSub)
        {

            this.ContainerTags = containerTags;
            this.DeleteComponents = deleteComponents;
            this.DeleteSpawnpoints = deleteSpawnpoints;
            this.DeleteWires = deleteWires;
            this.DoorBehaviour = doorBehaviour;
            this.Inplace = inplace;
            this.PreserveColour = preserveColour;
            this.RenameSub = renameSub;
        }
    }
}
