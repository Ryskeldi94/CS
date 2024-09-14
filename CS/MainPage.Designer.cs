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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ThemeComboBox = new System.Windows.Forms.ComboBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChoiceShow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ThemeComboBox);
            this.panel1.Controls.Add(this.languageComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ChoiceShow);
            this.panel1.Name = "panel1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.AutoEllipsis = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.AutoEllipsis = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
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
            this.ThemeComboBox.SelectedIndexChanged += new System.EventHandler(this.Change);
            // 
            // languageComboBox
            // 
            resources.ApplyResources(this.languageComboBox, "languageComboBox");
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            resources.GetString("languageComboBox.Items"),
            resources.GetString("languageComboBox.Items1"),
            resources.GetString("languageComboBox.Items2")});
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
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
            this.MinimizeBox = false;
            this.Name = "MainPage";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private void Change(object sender, EventArgs e)
        {

            if (ThemeComboBox.SelectedIndex == 2)
            {
                
                if (ThemeHelper.IsDarkModeEnabled())
                {
                    Program.GlobalVariables.Theme = "dark";
                }
                else
                {
                    Program.GlobalVariables.Theme = "white";
                }
            }
            else if (ThemeComboBox.SelectedIndex == 1)
            {
                Program.GlobalVariables.Theme = "dark";
            }
            else if (ThemeComboBox.SelectedIndex == 0)
            {
                Program.GlobalVariables.Theme = "White";
            }

            ThemeHelper.UpdateTheme(this);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChoiceShow;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.ComboBox ThemeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
