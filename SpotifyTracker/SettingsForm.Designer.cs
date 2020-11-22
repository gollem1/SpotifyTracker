namespace SpotifySongTracker
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.OutputTypeComboBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FontButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BackgroundColorBox = new System.Windows.Forms.PictureBox();
            this.BackgroundTransparentCheckBox = new System.Windows.Forms.CheckBox();
            this.OutlineTransparentCheckBox = new System.Windows.Forms.CheckBox();
            this.OutlineColorBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxSizeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Type:";
            // 
            // OutputTypeComboBox
            // 
            this.OutputTypeComboBox.FormattingEnabled = true;
            this.OutputTypeComboBox.Items.AddRange(new object[] {
            "GIF",
            "PNG",
            "TXT"});
            this.OutputTypeComboBox.Location = new System.Drawing.Point(121, 6);
            this.OutputTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OutputTypeComboBox.Name = "OutputTypeComboBox";
            this.OutputTypeComboBox.Size = new System.Drawing.Size(121, 28);
            this.OutputTypeComboBox.TabIndex = 1;
            this.OutputTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.OutputType_SelectedIndexChanged);
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(165, 288);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(84, 31);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(75, 288);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(82, 31);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Font:";
            // 
            // FontButton
            // 
            this.FontButton.Location = new System.Drawing.Point(66, 48);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(176, 35);
            this.FontButton.TabIndex = 5;
            this.FontButton.Text = "...";
            this.FontButton.UseVisualStyleBackColor = true;
            this.FontButton.Click += new System.EventHandler(this.FontButton_Click);
            this.FontButton.MouseEnter += new System.EventHandler(this.FontButton_MouseEnter);
            this.FontButton.MouseLeave += new System.EventHandler(this.FontButton_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Background Color:";
            // 
            // BackgroundColorBox
            // 
            this.BackgroundColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackgroundColorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackgroundColorBox.Location = new System.Drawing.Point(158, 97);
            this.BackgroundColorBox.Name = "BackgroundColorBox";
            this.BackgroundColorBox.Size = new System.Drawing.Size(25, 25);
            this.BackgroundColorBox.TabIndex = 7;
            this.BackgroundColorBox.TabStop = false;
            this.BackgroundColorBox.Click += new System.EventHandler(this.BackgroundColorBox_Click);
            // 
            // BackgroundTransparentCheckBox
            // 
            this.BackgroundTransparentCheckBox.AutoSize = true;
            this.BackgroundTransparentCheckBox.Location = new System.Drawing.Point(69, 128);
            this.BackgroundTransparentCheckBox.Name = "BackgroundTransparentCheckBox";
            this.BackgroundTransparentCheckBox.Size = new System.Drawing.Size(114, 24);
            this.BackgroundTransparentCheckBox.TabIndex = 8;
            this.BackgroundTransparentCheckBox.Text = "Transparent";
            this.BackgroundTransparentCheckBox.UseVisualStyleBackColor = true;
            this.BackgroundTransparentCheckBox.CheckedChanged += new System.EventHandler(this.BackgroundTransparentCheckBox_CheckedChanged);
            // 
            // OutlineTransparentCheckBox
            // 
            this.OutlineTransparentCheckBox.AutoSize = true;
            this.OutlineTransparentCheckBox.Location = new System.Drawing.Point(70, 196);
            this.OutlineTransparentCheckBox.Name = "OutlineTransparentCheckBox";
            this.OutlineTransparentCheckBox.Size = new System.Drawing.Size(114, 24);
            this.OutlineTransparentCheckBox.TabIndex = 11;
            this.OutlineTransparentCheckBox.Text = "Transparent";
            this.OutlineTransparentCheckBox.UseVisualStyleBackColor = true;
            this.OutlineTransparentCheckBox.CheckedChanged += new System.EventHandler(this.OutlineTransparentCheckBox_CheckedChanged);
            // 
            // OutlineColorBox
            // 
            this.OutlineColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutlineColorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OutlineColorBox.Location = new System.Drawing.Point(123, 165);
            this.OutlineColorBox.Name = "OutlineColorBox";
            this.OutlineColorBox.Size = new System.Drawing.Size(25, 25);
            this.OutlineColorBox.TabIndex = 10;
            this.OutlineColorBox.TabStop = false;
            this.OutlineColorBox.Click += new System.EventHandler(this.OutlineColorBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Outline Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Max Size (px): ";
            // 
            // MaxSizeTextBox
            // 
            this.MaxSizeTextBox.Location = new System.Drawing.Point(123, 229);
            this.MaxSizeTextBox.Name = "MaxSizeTextBox";
            this.MaxSizeTextBox.Size = new System.Drawing.Size(119, 26);
            this.MaxSizeTextBox.TabIndex = 13;
            this.MaxSizeTextBox.TextChanged += new System.EventHandler(this.MaxSizeTextBox_TextChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 333);
            this.Controls.Add(this.MaxSizeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OutlineTransparentCheckBox);
            this.Controls.Add(this.OutlineColorBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BackgroundTransparentCheckBox);
            this.Controls.Add(this.BackgroundColorBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FontButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.OutputTypeComboBox);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SettingsForm";
            this.Text = "Spotify Song Tracker Settings";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineColorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OutputTypeComboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox BackgroundColorBox;
        private System.Windows.Forms.CheckBox BackgroundTransparentCheckBox;
        private System.Windows.Forms.CheckBox OutlineTransparentCheckBox;
        private System.Windows.Forms.PictureBox OutlineColorBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MaxSizeTextBox;
    }
}