using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Version2
{
    partial class LoadData_TD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadData_TD));
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.line10 = new System.Windows.Forms.TextBox();
            this.line9 = new System.Windows.Forms.TextBox();
            this.line8 = new System.Windows.Forms.TextBox();
            this.line7 = new System.Windows.Forms.TextBox();
            this.line6 = new System.Windows.Forms.TextBox();
            this.line5 = new System.Windows.Forms.TextBox();
            this.line4 = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.line3 = new System.Windows.Forms.TextBox();
            this.line2 = new System.Windows.Forms.TextBox();
            this.line1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.line10);
            this.panel1.Controls.Add(this.line9);
            this.panel1.Controls.Add(this.line8);
            this.panel1.Controls.Add(this.line7);
            this.panel1.Controls.Add(this.line6);
            this.panel1.Controls.Add(this.line5);
            this.panel1.Controls.Add(this.line4);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.line3);
            this.panel1.Controls.Add(this.line2);
            this.panel1.Controls.Add(this.line1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Name = "panel1";
            // 
            // back
            // 
            resources.ApplyResources(this.back, "back");
            this.back.BackColor = System.Drawing.Color.White;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Name = "back";
            this.back.Image = Image.FromFile("C:\\My projects\\CS\\Resources\\back.png");
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.Paint += new System.Windows.Forms.PaintEventHandler(this.back_Paint);
            // 
            // line10
            // 
            resources.ApplyResources(this.line10, "line10");
            this.line10.Name = "line10";
            this.line10.ReadOnly = true;
            // 
            // line9
            // 
            resources.ApplyResources(this.line9, "line9");
            this.line9.Name = "line9";
            this.line9.ReadOnly = true;
            // 
            // line8
            // 
            resources.ApplyResources(this.line8, "line8");
            this.line8.Name = "line8";
            this.line8.ReadOnly = true;
            // 
            // line7
            // 
            resources.ApplyResources(this.line7, "line7");
            this.line7.Name = "line7";
            this.line7.ReadOnly = true;
            // 
            // line6
            // 
            resources.ApplyResources(this.line6, "line6");
            this.line6.Name = "line6";
            this.line6.ReadOnly = true;
            // 
            // line5
            // 
            resources.ApplyResources(this.line5, "line5");
            this.line5.Name = "line5";
            this.line5.ReadOnly = true;
            // 
            // line4
            // 
            resources.ApplyResources(this.line4, "line4");
            this.line4.Name = "line4";
            this.line4.ReadOnly = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // line3
            // 
            resources.ApplyResources(this.line3, "line3");
            this.line3.Name = "line3";
            this.line3.ReadOnly = true;
            // 
            // line2
            // 
            resources.ApplyResources(this.line2, "line2");
            this.line2.Name = "line2";
            this.line2.ReadOnly = true;
            // 
            // line1
            // 
            resources.ApplyResources(this.line1, "line1");
            this.line1.Name = "line1";
            this.line1.ReadOnly = true;
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Name = "numericUpDown1";
            // 
            // LoadData_TD
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "LoadData_TD";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void back_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(btn.Width - 21, 0, 20, 20, 270, 90);
            path.AddArc(btn.Width - 21, btn.Height - 21, 20, 20, 0, 90);
            path.AddArc(0, btn.Height - 21, 20, 20, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(btn.Width - 21, 0, 20, 20, 270, 90);
            path.AddArc(btn.Width - 21, btn.Height - 21, 20, 20, 0, 90);
            path.AddArc(0, btn.Height - 21, 20, 20, 90, 90);
            path.CloseAllFigures();
            btn.FlatAppearance.BorderSize = 0;
            btn.Region = new Region(path);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox line3;
        private System.Windows.Forms.TextBox line2;
        private System.Windows.Forms.TextBox line1;
        private System.Windows.Forms.TextBox line10;
        private System.Windows.Forms.TextBox line9;
        private System.Windows.Forms.TextBox line8;
        private System.Windows.Forms.TextBox line7;
        private System.Windows.Forms.TextBox line6;
        private System.Windows.Forms.TextBox line5;
        private System.Windows.Forms.TextBox line4;
        private System.Windows.Forms.Button back;
    }
}