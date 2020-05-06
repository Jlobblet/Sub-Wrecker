﻿namespace Sub_Wrecker
{
    internal class WreckerSettings
    {
        public bool ContainerTags { get; set; }
        public bool DeleteComponents { get; set; }
        public bool DeleteWires { get; set; }
        public int DoorBehaviour { get; set; }
        public bool Inplace { get; set; }
        public bool PreserveColour { get; set; }
        public bool RenameSub { get; set; }
        public int SpawnpointBehaviour { get; set; }

        public WreckerSettings(bool containerTags, bool deleteComponents, bool deleteWires, int doorBehaviour, bool inplace, bool preserveColour, bool renameSub, int spawnpointBehaviour)
        {

            ContainerTags = containerTags;
            DeleteComponents = deleteComponents;
            DeleteWires = deleteWires;
            DoorBehaviour = doorBehaviour;
            Inplace = inplace;
            PreserveColour = preserveColour;
            RenameSub = renameSub;
            SpawnpointBehaviour = spawnpointBehaviour;
        }
    }
}
