using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Version2
{
    partial class Singl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Singl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ambientTemperature = new System.Windows.Forms.TextBox();
            this.initialTemperature = new System.Windows.Forms.TextBox();
            this.highTempLocation = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.calculate);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ambientTemperature);
            this.panel1.Controls.Add(this.initialTemperature);
            this.panel1.Controls.Add(this.highTempLocation);
            this.panel1.Name = "panel1";
            // 
            // back
            // 
            resources.ApplyResources(this.back, "back");
            this.back.BackColor = System.Drawing.Color.White;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Name = "back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.Paint += new System.Windows.Forms.PaintEventHandler(this.back_Paint);
            // 
            // calculate
            // 
            resources.ApplyResources(this.calculate, "calculate");
            this.calculate.Name = "calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ambientTemperature
            // 
            resources.ApplyResources(this.ambientTemperature, "ambientTemperature");
            this.ambientTemperature.Name = "ambientTemperature";
            // 
            // initialTemperature
            // 
            resources.ApplyResources(this.initialTemperature, "initialTemperature");
            this.initialTemperature.Name = "initialTemperature";
            // 
            // highTempLocation
            // 
            resources.ApplyResources(this.highTempLocation, "highTempLocation");
            this.highTempLocation.Name = "highTempLocation";
            // 
            // Singl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Singl";
            this.Load += new System.EventHandler(this.Singl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox highTempLocation;
        private System.Windows.Forms.TextBox initialTemperature;
        private System.Windows.Forms.TextBox ambientTemperature;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button back;
    }
}