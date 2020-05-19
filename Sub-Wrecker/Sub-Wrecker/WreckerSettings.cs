namespace Sub_Wrecker
{
    internal class WreckerSettings
    {
        private bool conditionTo0;
        private bool containerTags;
        private bool deleteComponents;
        private bool deleteWires;
        private int doorBehaviour;
        private bool inplace;
        private bool lightingShadows;
        private bool lightingTurnOff;
        private bool preserveColour;
        private bool renameSub;
        private int spawnpointBehaviour;

        public bool ConditionTo0 { get => conditionTo0; set => conditionTo0 = value; }
        public bool ContainerTags { get => containerTags; set => containerTags = value; }
        public bool DeleteComponents { get => deleteComponents; set => deleteComponents = value; }
        public bool DeleteWires { get => deleteWires; set => deleteWires = value; }
        public int DoorBehaviour { get => doorBehaviour; set => doorBehaviour = value; }
        public bool Inplace { get => inplace; set => inplace = value; }
        public bool LightingShadows { get => lightingShadows; set => lightingShadows = value; }
        public bool LightingTurnOff { get => lightingTurnOff; set => lightingTurnOff = value; }
        public bool PreserveColour { get => preserveColour; set => preserveColour = value; }
        public bool RenameSub { get => renameSub; set => renameSub = value; }
        public int SpawnpointBehaviour { get => spawnpointBehaviour; set => spawnpointBehaviour = value; }

        public WreckerSettings(
            bool conditionTo0,
            bool containerTags,
            bool deleteComponents,
            bool deleteWires,
            int doorBehaviour,
            bool inplace,
            bool lightingShadows,
            bool lightingTurnOff,
            bool preserveColour,
            bool renameSub,
            int spawnpointBehaviour)
        {

            ConditionTo0 = conditionTo0;
            ContainerTags = containerTags;
            DeleteComponents = deleteComponents;
            DeleteWires = deleteWires;
            DoorBehaviour = doorBehaviour;
            Inplace = inplace;
            LightingShadows = lightingShadows;
            LightingTurnOff = lightingTurnOff;
            PreserveColour = preserveColour;
            RenameSub = renameSub;
            SpawnpointBehaviour = spawnpointBehaviour;

            Properties.Settings.Default["ConditionTo0"] = conditionTo0;
            Properties.Settings.Default["ContainerTags"] = containerTags;
            Properties.Settings.Default["DeleteComponents"] = deleteComponents;
            Properties.Settings.Default["DeleteWires"] = deleteWires;
            Properties.Settings.Default["DoorBehaviour"] = doorBehaviour;
            Properties.Settings.Default["Inplace"] = inplace;
            Properties.Settings.Default["LightingShadows"] = lightingShadows;
            Properties.Settings.Default["LightingTurnOff"] = lightingTurnOff;
            Properties.Settings.Default["PreserveColour"] = preserveColour;
            Properties.Settings.Default["RenameSub"] = renameSub;
            Properties.Settings.Default["SpawnpointBehaviour"] = spawnpointBehaviour;
            Properties.Settings.Default.Save();
        }
    }
}
