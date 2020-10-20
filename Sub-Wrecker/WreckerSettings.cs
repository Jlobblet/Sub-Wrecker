namespace Sub_Wrecker
{
    internal readonly struct WreckerSettings
    {
        public bool ConditionTo0 { get; }
        public bool ContainerTags { get; }
        public bool DeleteComponents { get; }
        public bool DeleteWires { get; }
        public int DoorBehaviour { get; }
        public bool Inplace { get; }
        public bool LightingShadows { get; }
        public bool LightingTurnOff { get; }
        public bool PreserveColour { get; }
        public bool RenameSub { get; }
        public int SpawnpointBehaviour { get; }

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

            SaveDefaultSettings(this);
        }

        private static void SaveDefaultSettings(WreckerSettings settings)
        {
            Properties.Settings.Default["ConditionTo0"] = settings.ConditionTo0;
            Properties.Settings.Default["ContainerTags"] = settings.ContainerTags;
            Properties.Settings.Default["DeleteComponents"] = settings.DeleteComponents;
            Properties.Settings.Default["DeleteWires"] = settings.DeleteWires;
            Properties.Settings.Default["DoorBehaviour"] = settings.DoorBehaviour;
            Properties.Settings.Default["Inplace"] = settings.Inplace;
            Properties.Settings.Default["LightingShadows"] = settings.LightingShadows;
            Properties.Settings.Default["LightingTurnOff"] = settings.LightingTurnOff;
            Properties.Settings.Default["PreserveColour"] = settings.PreserveColour;
            Properties.Settings.Default["RenameSub"] = settings.RenameSub;
            Properties.Settings.Default["SpawnpointBehaviour"] = settings.SpawnpointBehaviour;
            Properties.Settings.Default.Save();
        }
    }
}
