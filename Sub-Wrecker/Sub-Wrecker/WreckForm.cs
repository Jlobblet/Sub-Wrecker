using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using BaroLib;
// ReSharper disable LocalizableElement

namespace Sub_Wrecker
{
    public partial class WreckForm : Form
    {
        private readonly string defaultOpenLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam", "steamapps", "common", "Barotrauma");
        private IEnumerable<string> subFilePaths;
        public WreckForm()
        {
            InitializeComponent();
            ContainerTagsCheckBox.Checked = (bool)Properties.Settings.Default["ContainerTags"];
            DeleteComponentsCheckBox.Checked = (bool)Properties.Settings.Default["DeleteComponents"];
            DeleteWiresCheckBox.Checked = (bool)Properties.Settings.Default["DeleteWires"];
            DoorBehaviourComboBox.SelectedIndex = (int)Properties.Settings.Default["DoorBehaviour"];
            InplaceCheckBox.Checked = (bool)Properties.Settings.Default["Inplace"];
            LightingShadowsCheckBox.Checked = (bool)Properties.Settings.Default["LightingShadows"];
            LightingTurnOffCheckBox.Checked = (bool)Properties.Settings.Default["LightingTurnOff"];
            PreserveColourCheckBox.Checked = (bool)Properties.Settings.Default["PreserveColour"];
            RenameCheckBox.Checked = (bool)Properties.Settings.Default["RenameSub"];
            SpawnpointComboBox.SelectedIndex = (int)Properties.Settings.Default["SpawnpointBehaviour"];
            Console.SetOut(new MultiTextWriter(new ControlWriter(OutputBox), Console.Out));
            Console.Out.NewLine = "\n";
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog()
                         {
                             InitialDirectory = defaultOpenLocation,

                             Multiselect = true,

                             EnsureFileExists = true,
                             EnsurePathExists = true,

                             DefaultExtension = "save",

                             ShowHiddenItems = true,
                         };

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;
            subFilePaths = dialog.FileNames.ToList();
            int length = subFilePaths.Count();
            string filePathBox;
            if (length > 1)
            {
                filePathBox = "";
                for (var i = 0; i < length; i++)
                {
                    filePathBox += $"\"{subFilePaths.ElementAt(i)}\"";
                    if (i + 1 != length)
                    {
                        filePathBox += ",";
                    }
                }
            }
            else
            {
                filePathBox = subFilePaths.ElementAt(0);
            }
            FilePathBox.Text = filePathBox;
        }

        private void WreckButton_Click(object sender, EventArgs e)
        {
            var settings = new WreckerSettings(
                                               ConditionCheckBox.Checked,
                                               ContainerTagsCheckBox.Checked,
                                               DeleteComponentsCheckBox.Checked,
                                               DeleteWiresCheckBox.Checked,
                                               DoorBehaviourComboBox.SelectedIndex,
                                               InplaceCheckBox.Checked,
                                               LightingShadowsCheckBox.Checked,
                                               LightingTurnOffCheckBox.Checked,
                                               PreserveColourCheckBox.Checked,
                                               RenameCheckBox.Checked,
                                               SpawnpointComboBox.SelectedIndex);
            foreach (string fileName in subFilePaths)
            {
                string extension = Path.GetExtension(fileName);
                if (extension != ".sub")
                {
                    Console.WriteLine($"File {fileName} has an unsupported extension, skipping.");
                    continue;
                }
                Console.WriteLine($"Loading {fileName}...");
                XDocument sub = IoUtil.LoadSub(fileName);
                Console.WriteLine("...loaded.");
                XDocument wreckedSub = Wrecker.Wreck_Sub(sub, settings);
                string outFileName = InplaceCheckBox.Checked ? fileName : Path.Combine(Path.GetDirectoryName(fileName) ?? "",
                                         $"{Path.GetFileNameWithoutExtension(fileName)}_Wrecked.sub");
                Console.WriteLine($"Saving to {outFileName}...");
                wreckedSub.SaveSub(outFileName);
                Console.WriteLine("...saved.");
            }
        }

        private void WreckForm_Load(object sender, EventArgs e)
        {
            DoorBehaviourComboBox.SelectedIndex = 0;
            SpawnpointComboBox.SelectedIndex = 0;
        }

        private void SpawnpointComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {
            OutputBox.SelectionStart = OutputBox.Text.Length;
            OutputBox.ScrollToCaret();
        }
    }
}

