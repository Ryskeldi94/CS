using CS.Properties;
using System.Globalization;
using System.Threading;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ThemeComboBox = new System.Windows.Forms.ComboBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChoiceShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ThemeComboBox);
            this.panel1.Controls.Add(this.languageComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ChoiceShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 684);
            this.panel1.TabIndex = 0;
            // 
            // ThemeComboBox
            // 
            this.ThemeComboBox.FormattingEnabled = true;
          
            this.ThemeComboBox.Location = new System.Drawing.Point(437, 427);
            this.ThemeComboBox.Name = "ThemeComboBox";
            this.ThemeComboBox.Size = new System.Drawing.Size(255, 28);
            this.ThemeComboBox.TabIndex = 6;
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "Қазақша",
            "Русский",
            "English"});
            this.languageComboBox.Location = new System.Drawing.Point(45, 427);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(255, 28);
            this.languageComboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoEllipsis = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(291, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 60);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChoiceShow
            // 
            this.ChoiceShow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChoiceShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.ChoiceShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.ChoiceShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoiceShow.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceShow.ForeColor = System.Drawing.Color.DarkBlue;
            this.ChoiceShow.Location = new System.Drawing.Point(770, 560);
            this.ChoiceShow.Name = "ChoiceShow";
            this.ChoiceShow.Size = new System.Drawing.Size(430, 90);
            this.ChoiceShow.TabIndex = 2;
            this.ChoiceShow.UseVisualStyleBackColor = true;
            this.ChoiceShow.Click += new System.EventHandler(this.ChoiceShow_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoEllipsis = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(35, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 60);
            this.label2.TabIndex = 7;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoEllipsis = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(449, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(505, 60);
            this.label3.TabIndex = 8;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 684);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Свойства Металлов";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChoiceShow;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.ComboBox ThemeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
