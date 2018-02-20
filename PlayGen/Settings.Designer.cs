namespace PlayGen
{
    partial class Settings
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
            this.setttingFormats = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkOpenFolder = new System.Windows.Forms.CheckBox();
            this.buttonSaveSetting = new System.Windows.Forms.Button();
            this.checkBoxMP3 = new System.Windows.Forms.CheckBox();
            this.checkBoxWAV = new System.Windows.Forms.CheckBox();
            this.checkBoxFLAC = new System.Windows.Forms.CheckBox();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabAudioFormat = new System.Windows.Forms.TabPage();
            this.tabAdvertising = new System.Windows.Forms.TabPage();
            this.tabLanguage = new System.Windows.Forms.TabPage();
            this.tabSettings.SuspendLayout();
            this.tabAudioFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // setttingFormats
            // 
            this.setttingFormats.AutoSize = true;
            this.setttingFormats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setttingFormats.Location = new System.Drawing.Point(14, 34);
            this.setttingFormats.Name = "setttingFormats";
            this.setttingFormats.Size = new System.Drawing.Size(95, 16);
            this.setttingFormats.TabIndex = 0;
            this.setttingFormats.Text = "Audio Formats";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "To open folders";
            // 
            // checkOpenFolder
            // 
            this.checkOpenFolder.AutoSize = true;
            this.checkOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkOpenFolder.Location = new System.Drawing.Point(123, 90);
            this.checkOpenFolder.Name = "checkOpenFolder";
            this.checkOpenFolder.Size = new System.Drawing.Size(73, 20);
            this.checkOpenFolder.TabIndex = 2;
            this.checkOpenFolder.Tag = "3";
            this.checkOpenFolder.Text = "Yes/No";
            this.checkOpenFolder.UseVisualStyleBackColor = true;
            this.checkOpenFolder.CheckedChanged += new System.EventHandler(this.checkBoxFLAC_CheckedChanged);
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.Location = new System.Drawing.Point(112, 136);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(99, 23);
            this.buttonSaveSetting.TabIndex = 3;
            this.buttonSaveSetting.Text = "OK";
            this.buttonSaveSetting.UseVisualStyleBackColor = true;
            this.buttonSaveSetting.Click += new System.EventHandler(this.buttonSaveSetting_Click);
            // 
            // checkBoxMP3
            // 
            this.checkBoxMP3.AutoSize = true;
            this.checkBoxMP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxMP3.Location = new System.Drawing.Point(123, 34);
            this.checkBoxMP3.Name = "checkBoxMP3";
            this.checkBoxMP3.Size = new System.Drawing.Size(53, 20);
            this.checkBoxMP3.TabIndex = 2;
            this.checkBoxMP3.Tag = "0";
            this.checkBoxMP3.Text = "mp3";
            this.checkBoxMP3.UseVisualStyleBackColor = true;
            this.checkBoxMP3.CheckedChanged += new System.EventHandler(this.checkBoxFLAC_CheckedChanged);
            // 
            // checkBoxWAV
            // 
            this.checkBoxWAV.AutoSize = true;
            this.checkBoxWAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxWAV.Location = new System.Drawing.Point(182, 34);
            this.checkBoxWAV.Name = "checkBoxWAV";
            this.checkBoxWAV.Size = new System.Drawing.Size(51, 20);
            this.checkBoxWAV.TabIndex = 2;
            this.checkBoxWAV.Tag = "1";
            this.checkBoxWAV.Text = "wav";
            this.checkBoxWAV.UseVisualStyleBackColor = true;
            this.checkBoxWAV.CheckedChanged += new System.EventHandler(this.checkBoxFLAC_CheckedChanged);
            // 
            // checkBoxFLAC
            // 
            this.checkBoxFLAC.AutoSize = true;
            this.checkBoxFLAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFLAC.Location = new System.Drawing.Point(241, 33);
            this.checkBoxFLAC.Name = "checkBoxFLAC";
            this.checkBoxFLAC.Size = new System.Drawing.Size(48, 20);
            this.checkBoxFLAC.TabIndex = 2;
            this.checkBoxFLAC.Tag = "2";
            this.checkBoxFLAC.Text = "flac";
            this.checkBoxFLAC.UseVisualStyleBackColor = true;
            this.checkBoxFLAC.CheckedChanged += new System.EventHandler(this.checkBoxFLAC_CheckedChanged);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabAudioFormat);
            this.tabSettings.Controls.Add(this.tabAdvertising);
            this.tabSettings.Controls.Add(this.tabLanguage);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(559, 394);
            this.tabSettings.TabIndex = 4;
            // 
            // tabAudioFormat
            // 
            this.tabAudioFormat.Controls.Add(this.setttingFormats);
            this.tabAudioFormat.Controls.Add(this.buttonSaveSetting);
            this.tabAudioFormat.Controls.Add(this.checkBoxMP3);
            this.tabAudioFormat.Controls.Add(this.checkOpenFolder);
            this.tabAudioFormat.Controls.Add(this.checkBoxFLAC);
            this.tabAudioFormat.Controls.Add(this.label2);
            this.tabAudioFormat.Controls.Add(this.checkBoxWAV);
            this.tabAudioFormat.Location = new System.Drawing.Point(4, 22);
            this.tabAudioFormat.Name = "tabAudioFormat";
            this.tabAudioFormat.Padding = new System.Windows.Forms.Padding(3);
            this.tabAudioFormat.Size = new System.Drawing.Size(551, 368);
            this.tabAudioFormat.TabIndex = 0;
            this.tabAudioFormat.Text = "Аудио формат";
            this.tabAudioFormat.UseVisualStyleBackColor = true;
            // 
            // tabAdvertising
            // 
            this.tabAdvertising.Location = new System.Drawing.Point(4, 22);
            this.tabAdvertising.Name = "tabAdvertising";
            this.tabAdvertising.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvertising.Size = new System.Drawing.Size(551, 368);
            this.tabAdvertising.TabIndex = 1;
            this.tabAdvertising.Text = "Реклама";
            this.tabAdvertising.UseVisualStyleBackColor = true;
            // 
            // tabLanguage
            // 
            this.tabLanguage.Location = new System.Drawing.Point(4, 22);
            this.tabLanguage.Name = "tabLanguage";
            this.tabLanguage.Size = new System.Drawing.Size(551, 368);
            this.tabLanguage.TabIndex = 2;
            this.tabLanguage.Text = "Язык";
            this.tabLanguage.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 394);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabSettings.ResumeLayout(false);
            this.tabAudioFormat.ResumeLayout(false);
            this.tabAudioFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label setttingFormats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkOpenFolder;
        private System.Windows.Forms.Button buttonSaveSetting;
        private System.Windows.Forms.CheckBox checkBoxMP3;
        private System.Windows.Forms.CheckBox checkBoxWAV;
        private System.Windows.Forms.CheckBox checkBoxFLAC;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabAudioFormat;
        private System.Windows.Forms.TabPage tabAdvertising;
        private System.Windows.Forms.TabPage tabLanguage;
    }
}