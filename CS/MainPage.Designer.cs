using CS.Properties;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Version2
{
    partial class MainPage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.  
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChoiceShow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.SettingsButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ChoiceShow);
            this.panel1.Name = "panel1";
            // 
            // SettingsButton
            // 
            resources.ApplyResources(this.SettingsButton, "SettingsButton");
            this.SettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.SettingsButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.AutoEllipsis = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // ChoiceShow
            // 
            resources.ApplyResources(this.ChoiceShow, "ChoiceShow");
            this.ChoiceShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.ChoiceShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.ChoiceShow.ForeColor = System.Drawing.Color.DarkBlue;
            this.ChoiceShow.Name = "ChoiceShow";
            this.ChoiceShow.UseVisualStyleBackColor = true;
            this.ChoiceShow.Click += new System.EventHandler(this.ChoiceShow_Click_1);
            // 
            // MainPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChoiceShow;
        private Button SettingsButton;
    }
}
