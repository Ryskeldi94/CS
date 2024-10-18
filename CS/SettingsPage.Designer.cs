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
            this.BrowsButtonServer = new System.Windows.Forms.Button();
            this.BrowsButtonJson = new System.Windows.Forms.Button();
            this.serverPathTextBox = new System.Windows.Forms.TextBox();
            this.JsonPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CancerButton = new System.Windows.Forms.Button();
            this.SaveButon = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.BrowsButtonServer);
            this.panel1.Controls.Add(this.BrowsButtonJson);
            this.panel1.Controls.Add(this.serverPathTextBox);
            this.panel1.Controls.Add(this.JsonPathTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CancerButton);
            this.panel1.Controls.Add(this.SaveButon);
            this.panel1.Controls.Add(this.ThemeComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.languageComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Name = "panel1";
            // 
            // BrowsButtonServer
            // 
            resources.ApplyResources(this.BrowsButtonServer, "BrowsButtonServer");
            this.BrowsButtonServer.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.BrowsButtonServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.BrowsButtonServer.ForeColor = System.Drawing.Color.DarkBlue;
            this.BrowsButtonServer.Name = "BrowsButtonServer";
            this.BrowsButtonServer.UseVisualStyleBackColor = true;
            this.BrowsButtonServer.Click += new System.EventHandler(this.BrowsButtonServer_Click);
            // 
            // BrowsButtonJson
            // 
            resources.ApplyResources(this.BrowsButtonJson, "BrowsButtonJson");
            this.BrowsButtonJson.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.BrowsButtonJson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.BrowsButtonJson.ForeColor = System.Drawing.Color.DarkBlue;
            this.BrowsButtonJson.Name = "BrowsButtonJson";
            this.BrowsButtonJson.UseVisualStyleBackColor = true;
            this.BrowsButtonJson.Click += new System.EventHandler(this.BrowsButtonJson_Click);
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
            // CancerButton
            // 
            resources.ApplyResources(this.CancerButton, "CancerButton");
            this.CancerButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.CancerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.CancerButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.CancerButton.Name = "CancerButton";
            this.CancerButton.UseVisualStyleBackColor = true;
            this.CancerButton.Click += new System.EventHandler(this.CancerButton_Click);
            // 
            // SaveButon
            // 
            resources.ApplyResources(this.SaveButon, "SaveButon");
            this.SaveButon.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.SaveButon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.SaveButon.ForeColor = System.Drawing.Color.DarkBlue;
            this.SaveButon.Name = "SaveButon";
            this.SaveButon.UseVisualStyleBackColor = true;
            this.SaveButon.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ThemeComboBox
            // 
            resources.ApplyResources(this.ThemeComboBox, "ThemeComboBox");
            this.ThemeComboBox.FormattingEnabled = true;
            this.ThemeComboBox.Items.AddRange(new object[] {
            resources.GetString("ThemeComboBox.Items"),
            resources.GetString("ThemeComboBox.Items1"),
            resources.GetString("ThemeComboBox.Items2"),
            resources.GetString("ThemeComboBox.Items3"),
            resources.GetString("ThemeComboBox.Items4")});
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
        private System.Windows.Forms.Button SaveButon;
        private System.Windows.Forms.Button CancerButton;
        private System.Windows.Forms.TextBox JsonPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowsButtonServer;
        private System.Windows.Forms.Button BrowsButtonJson;
        private System.Windows.Forms.TextBox serverPathTextBox;
    }
}
