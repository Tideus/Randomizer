namespace PlayGen
{
    partial class UIControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackMix = new System.Windows.Forms.CheckBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelMaxTime = new System.Windows.Forms.Label();
            this.labelNumer = new System.Windows.Forms.Label();
            this.numericHours = new System.Windows.Forms.NumericUpDown();
            this.numericMinutes = new System.Windows.Forms.NumericUpDown();
            this.directoryMix = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // trackMix
            // 
            this.trackMix.Appearance = System.Windows.Forms.Appearance.Button;
            this.trackMix.AutoSize = true;
            this.trackMix.BackColor = System.Drawing.Color.White;
            this.trackMix.Location = new System.Drawing.Point(603, 2);
            this.trackMix.Name = "trackMix";
            this.trackMix.Size = new System.Drawing.Size(32, 23);
            this.trackMix.TabIndex = 3;
            this.trackMix.Text = "TR";
            this.trackMix.UseVisualStyleBackColor = false;
            this.trackMix.CheckedChanged += new System.EventHandler(this.trackMix_CheckedChanged);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(39, 3);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(304, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // labelMaxTime
            // 
            this.labelMaxTime.AutoSize = true;
            this.labelMaxTime.Location = new System.Drawing.Point(471, 7);
            this.labelMaxTime.Name = "labelMaxTime";
            this.labelMaxTime.Size = new System.Drawing.Size(82, 13);
            this.labelMaxTime.TabIndex = 0;
            this.labelMaxTime.Text = "/ \"00:00:00:00\"";
            // 
            // labelNumer
            // 
            this.labelNumer.AutoSize = true;
            this.labelNumer.Location = new System.Drawing.Point(9, 6);
            this.labelNumer.Name = "labelNumer";
            this.labelNumer.Size = new System.Drawing.Size(13, 13);
            this.labelNumer.TabIndex = 0;
            this.labelNumer.Text = "1";
            // 
            // numericHours
            // 
            this.numericHours.BackColor = System.Drawing.SystemColors.Info;
            this.numericHours.Location = new System.Drawing.Point(361, 4);
            this.numericHours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericHours.Name = "numericHours";
            this.numericHours.Size = new System.Drawing.Size(36, 20);
            this.numericHours.TabIndex = 4;
            // 
            // numericMinutes
            // 
            this.numericMinutes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numericMinutes.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericMinutes.Location = new System.Drawing.Point(403, 4);
            this.numericMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericMinutes.Name = "numericMinutes";
            this.numericMinutes.Size = new System.Drawing.Size(36, 20);
            this.numericMinutes.TabIndex = 4;
            // 
            // directoryMix
            // 
            this.directoryMix.Appearance = System.Windows.Forms.Appearance.Button;
            this.directoryMix.AutoSize = true;
            this.directoryMix.BackColor = System.Drawing.Color.White;
            this.directoryMix.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.directoryMix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.directoryMix.Location = new System.Drawing.Point(559, 2);
            this.directoryMix.Name = "directoryMix";
            this.directoryMix.Size = new System.Drawing.Size(33, 23);
            this.directoryMix.TabIndex = 5;
            this.directoryMix.Text = "DR";
            this.directoryMix.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.directoryMix.UseVisualStyleBackColor = false;
            this.directoryMix.CheckedChanged += new System.EventHandler(this.directoryMix_CheckedChanged);
            // 
            // UIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.directoryMix);
            this.Controls.Add(this.numericMinutes);
            this.Controls.Add(this.numericHours);
            this.Controls.Add(this.trackMix);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelMaxTime);
            this.Controls.Add(this.labelNumer);
            this.Name = "UIControl";
            this.Size = new System.Drawing.Size(644, 26);
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox trackMix;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelMaxTime;
        private System.Windows.Forms.Label labelNumer;
        private System.Windows.Forms.NumericUpDown numericHours;
        private System.Windows.Forms.NumericUpDown numericMinutes;
        private System.Windows.Forms.CheckBox directoryMix;
    }
}
