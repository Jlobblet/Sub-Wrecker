namespace Sub_Wrecker
{
    partial class WreckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WreckForm));
            this.BrowseButton = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.WreckButton = new System.Windows.Forms.Button();
            this.PreserveColourCheckBox = new System.Windows.Forms.CheckBox();
            this.ContainerTagsCheckBox = new System.Windows.Forms.CheckBox();
            this.InplaceCheckBox = new System.Windows.Forms.CheckBox();
            this.DeleteWiresCheckBox = new System.Windows.Forms.CheckBox();
            this.DeleteComponentsCheckBox = new System.Windows.Forms.CheckBox();
            this.doorBehaviourComboBox = new System.Windows.Forms.ComboBox();
            this.RenameCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(368, 12);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(155, 38);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputBox.Location = new System.Drawing.Point(12, 56);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(511, 340);
            this.OutputBox.TabIndex = 1;
            this.OutputBox.Text = "";
            // 
            // FilePathBox
            // 
            this.FilePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePathBox.Location = new System.Drawing.Point(12, 20);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(350, 22);
            this.FilePathBox.TabIndex = 2;
            // 
            // WreckButton
            // 
            this.WreckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WreckButton.Location = new System.Drawing.Point(529, 12);
            this.WreckButton.Name = "WreckButton";
            this.WreckButton.Size = new System.Drawing.Size(312, 38);
            this.WreckButton.TabIndex = 3;
            this.WreckButton.Text = "Wreck";
            this.WreckButton.UseVisualStyleBackColor = true;
            this.WreckButton.Click += new System.EventHandler(this.WreckButton_Click);
            // 
            // PreserveColourCheckBox
            // 
            this.PreserveColourCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PreserveColourCheckBox.AutoSize = true;
            this.PreserveColourCheckBox.Checked = true;
            this.PreserveColourCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PreserveColourCheckBox.Location = new System.Drawing.Point(531, 89);
            this.PreserveColourCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.PreserveColourCheckBox.Name = "PreserveColourCheckBox";
            this.PreserveColourCheckBox.Size = new System.Drawing.Size(176, 21);
            this.PreserveColourCheckBox.TabIndex = 4;
            this.PreserveColourCheckBox.Text = "Preserve sprite colours";
            this.PreserveColourCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PreserveColourCheckBox.UseVisualStyleBackColor = true;
            this.PreserveColourCheckBox.CheckedChanged += new System.EventHandler(this.SpriteColourCheckBox_CheckedChanged);
            // 
            // ContainerTagsCheckBox
            // 
            this.ContainerTagsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ContainerTagsCheckBox.AutoSize = true;
            this.ContainerTagsCheckBox.Checked = true;
            this.ContainerTagsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContainerTagsCheckBox.Location = new System.Drawing.Point(536, 120);
            this.ContainerTagsCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.ContainerTagsCheckBox.Name = "ContainerTagsCheckBox";
            this.ContainerTagsCheckBox.Size = new System.Drawing.Size(302, 21);
            this.ContainerTagsCheckBox.TabIndex = 5;
            this.ContainerTagsCheckBox.Text = "Change container tags to wrecked versions";
            this.ContainerTagsCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ContainerTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // InplaceCheckBox
            // 
            this.InplaceCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InplaceCheckBox.AutoSize = true;
            this.InplaceCheckBox.Location = new System.Drawing.Point(536, 247);
            this.InplaceCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.InplaceCheckBox.Name = "InplaceCheckBox";
            this.InplaceCheckBox.Size = new System.Drawing.Size(141, 21);
            this.InplaceCheckBox.TabIndex = 7;
            this.InplaceCheckBox.Text = "Wreck file inplace";
            this.InplaceCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InplaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeleteWiresCheckBox
            // 
            this.DeleteWiresCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteWiresCheckBox.AutoSize = true;
            this.DeleteWiresCheckBox.Location = new System.Drawing.Point(535, 151);
            this.DeleteWiresCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.DeleteWiresCheckBox.Name = "DeleteWiresCheckBox";
            this.DeleteWiresCheckBox.Size = new System.Drawing.Size(107, 21);
            this.DeleteWiresCheckBox.TabIndex = 8;
            this.DeleteWiresCheckBox.Text = "Delete wires";
            this.DeleteWiresCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteWiresCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeleteComponentsCheckBox
            // 
            this.DeleteComponentsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteComponentsCheckBox.AutoSize = true;
            this.DeleteComponentsCheckBox.Location = new System.Drawing.Point(535, 182);
            this.DeleteComponentsCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.DeleteComponentsCheckBox.Name = "DeleteComponentsCheckBox";
            this.DeleteComponentsCheckBox.Size = new System.Drawing.Size(152, 21);
            this.DeleteComponentsCheckBox.TabIndex = 9;
            this.DeleteComponentsCheckBox.Text = "Delete components";
            this.DeleteComponentsCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteComponentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // doorBehaviourComboBox
            // 
            this.doorBehaviourComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doorBehaviourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doorBehaviourComboBox.FormattingEnabled = true;
            this.doorBehaviourComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.doorBehaviourComboBox.Items.AddRange(new object[] {
            "Replace door and hatch ids with wreck_id",
            "Set canbepicked to False",
            "Leave doors and hatches alone"});
            this.doorBehaviourComboBox.Location = new System.Drawing.Point(531, 213);
            this.doorBehaviourComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.doorBehaviourComboBox.Name = "doorBehaviourComboBox";
            this.doorBehaviourComboBox.Size = new System.Drawing.Size(292, 24);
            this.doorBehaviourComboBox.TabIndex = 10;
            // 
            // RenameCheckBox
            // 
            this.RenameCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RenameCheckBox.AutoSize = true;
            this.RenameCheckBox.Checked = true;
            this.RenameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RenameCheckBox.Location = new System.Drawing.Point(535, 58);
            this.RenameCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.RenameCheckBox.Name = "RenameCheckBox";
            this.RenameCheckBox.Size = new System.Drawing.Size(110, 21);
            this.RenameCheckBox.TabIndex = 11;
            this.RenameCheckBox.Text = "Rename sub";
            this.RenameCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RenameCheckBox.UseVisualStyleBackColor = true;
            // 
            // WreckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 407);
            this.Controls.Add(this.RenameCheckBox);
            this.Controls.Add(this.doorBehaviourComboBox);
            this.Controls.Add(this.DeleteComponentsCheckBox);
            this.Controls.Add(this.DeleteWiresCheckBox);
            this.Controls.Add(this.InplaceCheckBox);
            this.Controls.Add(this.ContainerTagsCheckBox);
            this.Controls.Add(this.PreserveColourCheckBox);
            this.Controls.Add(this.WreckButton);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.BrowseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(871, 454);
            this.Name = "WreckForm";
            this.Text = "Sub Wrecker";
            this.Load += new System.EventHandler(this.WreckForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Button WreckButton;
        private System.Windows.Forms.CheckBox PreserveColourCheckBox;
        private System.Windows.Forms.CheckBox ContainerTagsCheckBox;
        private System.Windows.Forms.CheckBox InplaceCheckBox;
        private System.Windows.Forms.CheckBox DeleteWiresCheckBox;
        private System.Windows.Forms.CheckBox DeleteComponentsCheckBox;
        private System.Windows.Forms.ComboBox doorBehaviourComboBox;
        private System.Windows.Forms.CheckBox RenameCheckBox;
    }
}

