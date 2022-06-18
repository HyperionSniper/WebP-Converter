namespace Webp_converter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FilesInputTextbox = new System.Windows.Forms.TextBox();
            this.FilesInputButton = new System.Windows.Forms.Button();
            this.convertTextbox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.outputType = new System.Windows.Forms.ComboBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DirsInputTextbox = new System.Windows.Forms.TextBox();
            this.DirsInputButton = new System.Windows.Forms.Button();
            this.DeleteConverted = new System.Windows.Forms.CheckBox();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilesInputTextbox
            // 
            this.FilesInputTextbox.Location = new System.Drawing.Point(18, 18);
            this.FilesInputTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FilesInputTextbox.Name = "FilesInputTextbox";
            this.FilesInputTextbox.Size = new System.Drawing.Size(620, 26);
            this.FilesInputTextbox.TabIndex = 0;
            this.FilesInputTextbox.TextChanged += new System.EventHandler(this.InputTextbox_TextChanged);
            // 
            // FilesInputButton
            // 
            this.FilesInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesInputButton.Location = new System.Drawing.Point(662, 18);
            this.FilesInputButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FilesInputButton.Name = "FilesInputButton";
            this.FilesInputButton.Size = new System.Drawing.Size(112, 35);
            this.FilesInputButton.TabIndex = 1;
            this.FilesInputButton.Text = "Browse Files";
            this.FilesInputButton.UseVisualStyleBackColor = true;
            this.FilesInputButton.Click += new System.EventHandler(this.FilesInputButton_Click);
            // 
            // convertTextbox
            // 
            this.convertTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.convertTextbox.Enabled = false;
            this.convertTextbox.Location = new System.Drawing.Point(18, 170);
            this.convertTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.convertTextbox.Name = "convertTextbox";
            this.convertTextbox.Size = new System.Drawing.Size(620, 26);
            this.convertTextbox.TabIndex = 2;
            this.convertTextbox.Visible = false;
            this.convertTextbox.TextChanged += new System.EventHandler(this.convertTextbox_TextChanged);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertButton.Location = new System.Drawing.Point(664, 166);
            this.ConvertButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(112, 35);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // outputType
            // 
            this.outputType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outputType.FormattingEnabled = true;
            this.outputType.Location = new System.Drawing.Point(664, 124);
            this.outputType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outputType.Name = "outputType";
            this.outputType.Size = new System.Drawing.Size(110, 28);
            this.outputType.TabIndex = 4;
            this.outputType.SelectedIndexChanged += new System.EventHandler(this.outputType_SelectedIndexChanged);
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 217);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.StatusStrip.Size = new System.Drawing.Size(795, 22);
            this.StatusStrip.TabIndex = 5;
            this.StatusStrip.Text = "statusStrip1";
            this.StatusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.StatusStrip_ItemClicked);
            // 
            // StatusStripLabel
            // 
            this.StatusStripLabel.Name = "StatusStripLabel";
            this.StatusStripLabel.Size = new System.Drawing.Size(0, 15);
            this.StatusStripLabel.Click += new System.EventHandler(this.StatusStripLabel_Click);
            // 
            // DirsInputTextbox
            // 
            this.DirsInputTextbox.Location = new System.Drawing.Point(18, 63);
            this.DirsInputTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DirsInputTextbox.Name = "DirsInputTextbox";
            this.DirsInputTextbox.Size = new System.Drawing.Size(620, 26);
            this.DirsInputTextbox.TabIndex = 6;
            this.DirsInputTextbox.TextChanged += new System.EventHandler(this.DirsInputTextbox_TextChanged);
            // 
            // DirsInputButton
            // 
            this.DirsInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DirsInputButton.Location = new System.Drawing.Point(664, 63);
            this.DirsInputButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DirsInputButton.Name = "DirsInputButton";
            this.DirsInputButton.Size = new System.Drawing.Size(112, 35);
            this.DirsInputButton.TabIndex = 7;
            this.DirsInputButton.Text = "Browse Dirs";
            this.DirsInputButton.UseVisualStyleBackColor = true;
            this.DirsInputButton.Click += new System.EventHandler(this.DirsInputButton_Click);
            // 
            // DeleteConverted
            // 
            this.DeleteConverted.AutoSize = true;
            this.DeleteConverted.Location = new System.Drawing.Point(18, 124);
            this.DeleteConverted.Name = "DeleteConverted";
            this.DeleteConverted.Size = new System.Drawing.Size(159, 24);
            this.DeleteConverted.TabIndex = 8;
            this.DeleteConverted.Text = "Delete Converted";
            this.DeleteConverted.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 239);
            this.Controls.Add(this.DeleteConverted);
            this.Controls.Add(this.DirsInputButton);
            this.Controls.Add(this.DirsInputTextbox);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.outputType);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.convertTextbox);
            this.Controls.Add(this.FilesInputButton);
            this.Controls.Add(this.FilesInputTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "WebP converter";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilesInputTextbox;
        private System.Windows.Forms.Button FilesInputButton;
        private System.Windows.Forms.TextBox convertTextbox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.ComboBox outputType;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripLabel;
        private System.Windows.Forms.TextBox DirsInputTextbox;
        private System.Windows.Forms.Button DirsInputButton;
        private System.Windows.Forms.CheckBox DeleteConverted;
    }
}

