namespace Version2
{
    partial class TDimen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TDimen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.highTempY = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.calculate = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.highTempX = new System.Windows.Forms.TextBox();
            this.ambientTemperature = new System.Windows.Forms.TextBox();
            this.initialTemperature = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.highTempY);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.calculate);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.highTempX);
            this.panel1.Controls.Add(this.ambientTemperature);
            this.panel1.Controls.Add(this.initialTemperature);
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
            // 
            // highTempY
            // 
            resources.ApplyResources(this.highTempY, "highTempY");
            this.highTempY.Name = "highTempY";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            // 
            // calculate
            // 
            resources.ApplyResources(this.calculate, "calculate");
            this.calculate.Name = "calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.button1_Click_1);
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
            // highTempX
            // 
            resources.ApplyResources(this.highTempX, "highTempX");
            this.highTempX.Name = "highTempX";
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
            // TDimen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TDimen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox highTempX;
        private System.Windows.Forms.TextBox ambientTemperature;
        private System.Windows.Forms.TextBox initialTemperature;
        private System.Windows.Forms.TextBox highTempY;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button back;
    }
}