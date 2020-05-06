using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sub_Wrecker
{
    public partial class WreckForm : Form
    {
        readonly string DefaultOpenLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam", "steamapps", "common", "Barotrauma");
        protected IEnumerable<string> SubFilePaths;
        public WreckForm()
        {
            InitializeComponent();
            Console.SetOut(new MultiTextWriter(new ControlWriter(OutputBox), Console.Out));
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                InitialDirectory = DefaultOpenLocation,

                Multiselect = true,

                EnsureFileExists = true,
                EnsurePathExists = true,

                DefaultExtension = "save",

                ShowHiddenItems = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SubFilePaths = dialog.FileNames;
                int length = SubFilePaths.Count();
                string filePathBox;
                if (length > 1)
                {
                    filePathBox = "";
                    for (int i = 0; i < length; i++)
                    {
                        filePathBox += "\"" + SubFilePaths.ElementAt(i) + "\"";
                        if (i + 1 != length)
                        {
                            filePathBox += ",";
                        }
                    }
                }
                else
                {
                    filePathBox = SubFilePaths.ElementAt(0);
                }
                FilePathBox.Text = filePathBox;

            }
        }

        private void WreckButton_Click(object sender, EventArgs e)
        {
            foreach (string fileName in SubFilePaths)
            {
                string extension = Path.GetExtension(fileName);
                if (extension != ".sub")
                {
                    Console.WriteLine("File " + fileName + " has an unsupported extension, skipping."); 
                    continue;
                }
                Console.WriteLine("Loading " + fileName + "...");
                XDocument sub = SaveUtils.LoadSub(fileName);
                Console.WriteLine("...loaded.");
                WreckerSettings settings = new WreckerSettings(
                    ContainerTagsCheckBox.Checked,
                    DeleteComponentsCheckBox.Checked,
                    DeleteWiresCheckBox.Checked,
                    doorBehaviourComboBox.SelectedIndex,
                    InplaceCheckBox.Checked,
                    PreserveColourCheckBox.Checked,
                    RenameCheckBox.Checked);
                XDocument wreckedSub = Wrecker.Wreck_Sub(sub, settings);
                string outFileName;
                if (InplaceCheckBox.Checked)
                {
                    outFileName = fileName;
                }
                else
                {
                    outFileName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + "_Wrecked.sub");
                }
                Console.WriteLine("Saving to " + outFileName + "...");
                SaveUtils.SaveSub(wreckedSub, outFileName);
                Console.WriteLine("...saved.");
            }
        }

        private void SpriteColourCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WreckForm_Load(object sender, EventArgs e)
        {

        }
    }
}

