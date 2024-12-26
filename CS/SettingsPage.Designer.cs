namespace CS
{
    partial class SettingsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BrowseButtonServer = new System.Windows.Forms.Button();
            this.BrowseButtonJson = new System.Windows.Forms.Button();
            this.serverPathTextBox = new System.Windows.Forms.TextBox();
            this.JsonPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ThemeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.BrowseButtonServer);
            this.panel1.Controls.Add(this.BrowseButtonJson);
            this.panel1.Controls.Add(this.serverPathTextBox);
            this.panel1.Controls.Add(this.JsonPathTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.ThemeComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.languageComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BrowseButtonServer
            // 
            resources.ApplyResources(this.BrowseButtonServer, "BrowseButtonServer");
            this.BrowseButtonServer.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.BrowseButtonServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.BrowseButtonServer.ForeColor = System.Drawing.Color.DarkBlue;
            this.BrowseButtonServer.Name = "BrowseButtonServer";
            this.BrowseButtonServer.UseVisualStyleBackColor = true;
            this.BrowseButtonServer.Click += new System.EventHandler(this.BrowsButtonServer_Click);
            // 
            // BrowseButtonJson
            // 
            resources.ApplyResources(this.BrowseButtonJson, "BrowseButtonJson");
            this.BrowseButtonJson.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.BrowseButtonJson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.BrowseButtonJson.ForeColor = System.Drawing.Color.DarkBlue;
            this.BrowseButtonJson.Name = "BrowseButtonJson";
            this.BrowseButtonJson.UseVisualStyleBackColor = true;
            this.BrowseButtonJson.Click += new System.EventHandler(this.BrowsButtonJson_Click);
            // 
            // serverPathTextBox
            // 
            resources.ApplyResources(this.serverPathTextBox, "serverPathTextBox");
            this.serverPathTextBox.Name = "serverPathTextBox";
            // 
            // JsonPathTextBox
            // 
            resources.ApplyResources(this.JsonPathTextBox, "JsonPathTextBox");
            this.JsonPathTextBox.Name = "JsonPathTextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.AutoEllipsis = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.AutoEllipsis = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancerButton_Click);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.SaveButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ThemeComboBox
            // 
            resources.ApplyResources(this.ThemeComboBox, "ThemeComboBox");
            this.ThemeComboBox.FormattingEnabled = true;
            this.ThemeComboBox.Items.AddRange(new object[] {
            resources.GetString("ThemeComboBox.Items"),
            resources.GetString("ThemeComboBox.Items1"),
            resources.GetString("ThemeComboBox.Items2")});
            this.ThemeComboBox.Name = "ThemeComboBox";
            this.ThemeComboBox.SelectedIndexChanged += new System.EventHandler(this.ThemeComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.AutoEllipsis = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // languageComboBox
            // 
            resources.ApplyResources(this.languageComboBox, "languageComboBox");
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            resources.GetString("languageComboBox.Items"),
            resources.GetString("languageComboBox.Items1")});
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.AutoEllipsis = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // SettingsPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "SettingsPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ThemeComboBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox JsonPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButtonServer;
        private System.Windows.Forms.Button BrowseButtonJson;
        private System.Windows.Forms.TextBox serverPathTextBox;
    }
}
