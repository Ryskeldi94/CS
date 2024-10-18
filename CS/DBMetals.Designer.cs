using CS.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;

namespace Version2
{
    partial class DBMetals
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBMetals));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DelMetal = new System.Windows.Forms.Button();
            this.AlphaBox = new System.Windows.Forms.TextBox();
            this.SpecificHeatBox = new System.Windows.Forms.TextBox();
            this.DensityBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ShowItems = new System.Windows.Forms.Button();
            this.SelectThis = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AddMetal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMetals = new System.Windows.Forms.ComboBox();
            this.back = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.DelMetal);
            this.panel1.Controls.Add(this.AlphaBox);
            this.panel1.Controls.Add(this.SpecificHeatBox);
            this.panel1.Controls.Add(this.DensityBox);
            this.panel1.Controls.Add(this.NameBox);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.ShowItems);
            this.panel1.Controls.Add(this.SelectThis);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.AddMetal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxMetals);
            this.panel1.Controls.Add(this.back);
            this.panel1.Name = "panel1";
            // 
            // DelMetal
            // 
            resources.ApplyResources(this.DelMetal, "DelMetal");
            this.DelMetal.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.DelMetal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.DelMetal.ForeColor = System.Drawing.Color.DarkBlue;
            this.DelMetal.Name = "DelMetal";
            this.DelMetal.UseVisualStyleBackColor = true;
            this.DelMetal.Click += new System.EventHandler(this.DelMetal_Click);
            // 
            // AlphaBox
            // 
            resources.ApplyResources(this.AlphaBox, "AlphaBox");
            this.AlphaBox.Name = "AlphaBox";
            // 
            // SpecificHeatBox
            // 
            resources.ApplyResources(this.SpecificHeatBox, "SpecificHeatBox");
            this.SpecificHeatBox.Name = "SpecificHeatBox";
            // 
            // DensityBox
            // 
            resources.ApplyResources(this.DensityBox, "DensityBox");
            this.DensityBox.Name = "DensityBox";
            // 
            // NameBox
            // 
            resources.ApplyResources(this.NameBox, "NameBox");
            this.NameBox.Name = "NameBox";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
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
            // ShowItems
            // 
            resources.ApplyResources(this.ShowItems, "ShowItems");
            this.ShowItems.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.ShowItems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.ShowItems.ForeColor = System.Drawing.Color.DarkBlue;
            this.ShowItems.Name = "ShowItems";
            this.ShowItems.Click += new System.EventHandler(this.ShowItems_Click);
            // 
            // SelectThis
            // 
            resources.ApplyResources(this.SelectThis, "SelectThis");
            this.SelectThis.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.SelectThis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.SelectThis.ForeColor = System.Drawing.Color.DarkBlue;
            this.SelectThis.Name = "SelectThis";
            this.SelectThis.Click += new System.EventHandler(this.SelectThis_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.ForeColor = System.Drawing.Color.DarkBlue;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddMetal
            // 
            resources.ApplyResources(this.AddMetal, "AddMetal");
            this.AddMetal.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.AddMetal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.AddMetal.ForeColor = System.Drawing.Color.DarkBlue;
            this.AddMetal.Name = "AddMetal";
            this.AddMetal.UseVisualStyleBackColor = true;
            this.AddMetal.Click += new System.EventHandler(this.AddMetal_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // comboBoxMetals
            // 
            resources.ApplyResources(this.comboBoxMetals, "comboBoxMetals");
            this.comboBoxMetals.FormattingEnabled = true;
            this.comboBoxMetals.Name = "comboBoxMetals";
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
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            // 
            // textBox7
            // 
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            // 
            // DBMetals
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DBMetals";
            this.Load += new System.EventHandler(this.DBMetals_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxMetals;
        private System.Windows.Forms.Button AddMetal;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label1;

        private void Update_Fore(object sender, EventArgs e)
        {
            if (Program.GlobalVariables.selectedMethod == true)
            {
                this.button2.ForeColor = System.Drawing.Color.DarkBlue;
                this.button1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.button1.ForeColor = System.Drawing.Color.DarkBlue;
                this.button2.ForeColor = System.Drawing.Color.Red;
            }
        }


        private Button ChoiceShow;
        private Button SelectThis;
        private Button button2;
        private Button button1;
        private Button ShowItems;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox NameBox;
        private TextBox AlphaBox;
        private TextBox SpecificHeatBox;
        private TextBox DensityBox;
        private Button DelMetal;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
    }
}
