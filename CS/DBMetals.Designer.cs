using CS.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 684);
            this.panel1.TabIndex = 1;
            // 
            // DelMetal
            // 
            this.DelMetal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DelMetal.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.DelMetal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.DelMetal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelMetal.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelMetal.ForeColor = System.Drawing.Color.DarkBlue;
            this.DelMetal.Location = new System.Drawing.Point(442, 594);
            this.DelMetal.Name = "DelMetal";
            this.DelMetal.Size = new System.Drawing.Size(346, 61);
            this.DelMetal.TabIndex = 21;
            this.DelMetal.Text = "Удалить металл";
            this.DelMetal.UseVisualStyleBackColor = true;
            this.DelMetal.Click += new System.EventHandler(this.DelMetal_Click);
            // 
            // AlphaBox
            // 
            this.AlphaBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaBox.Location = new System.Drawing.Point(462, 434);
            this.AlphaBox.Name = "AlphaBox";
            this.AlphaBox.Size = new System.Drawing.Size(248, 40);
            this.AlphaBox.TabIndex = 20;
            // 
            // SpecificHeatBox
            // 
            this.SpecificHeatBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecificHeatBox.Location = new System.Drawing.Point(462, 344);
            this.SpecificHeatBox.Name = "SpecificHeatBox";
            this.SpecificHeatBox.Size = new System.Drawing.Size(248, 40);
            this.SpecificHeatBox.TabIndex = 19;
            // 
            // DensityBox
            // 
            this.DensityBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DensityBox.Location = new System.Drawing.Point(462, 265);
            this.DensityBox.Name = "DensityBox";
            this.DensityBox.Size = new System.Drawing.Size(248, 40);
            this.DensityBox.TabIndex = 18;
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameBox.Location = new System.Drawing.Point(462, 185);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(248, 40);
            this.NameBox.TabIndex = 17;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(35, 434);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(409, 40);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "Коэффициент теплопроводности";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(35, 344);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(409, 40);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Удельная теплоемкость";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(35, 265);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(409, 40);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "Плотность";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(35, 185);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(409, 40);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Название";
            // 
            // ShowItems
            // 
            this.ShowItems.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShowItems.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.ShowItems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.ShowItems.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowItems.ForeColor = System.Drawing.Color.DarkBlue;
            this.ShowItems.Location = new System.Drawing.Point(368, 106);
            this.ShowItems.Name = "ShowItems";
            this.ShowItems.Size = new System.Drawing.Size(342, 44);
            this.ShowItems.TabIndex = 12;
            this.ShowItems.Text = "Отобразить свойства";
            this.ShowItems.Click += new System.EventHandler(this.ShowItems_Click);
            // 
            // SelectThis
            // 
            this.SelectThis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SelectThis.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.SelectThis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.SelectThis.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectThis.ForeColor = System.Drawing.Color.DarkBlue;
            this.SelectThis.Location = new System.Drawing.Point(830, 591);
            this.SelectThis.Name = "SelectThis";
            this.SelectThis.Size = new System.Drawing.Size(346, 61);
            this.SelectThis.TabIndex = 11;
            this.SelectThis.Text = "Выбрать металл";
            this.SelectThis.Click += new System.EventHandler(this.SelectThis_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkBlue;
            this.button2.Location = new System.Drawing.Point(807, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(395, 90);
            this.button2.TabIndex = 10;
            this.button2.Text = "Решение на двухмерной плоскости";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Location = new System.Drawing.Point(807, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(395, 77);
            this.button1.TabIndex = 9;
            this.button1.Text = "Решение на одномерной плоскости";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // AddMetal
            // 
            this.AddMetal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddMetal.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.AddMetal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.AddMetal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMetal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMetal.ForeColor = System.Drawing.Color.DarkBlue;
            this.AddMetal.Location = new System.Drawing.Point(107, 594);
            this.AddMetal.Name = "AddMetal";
            this.AddMetal.Size = new System.Drawing.Size(299, 61);
            this.AddMetal.TabIndex = 8;
            this.AddMetal.Text = "Добавить металл";
            this.AddMetal.UseVisualStyleBackColor = true;
            this.AddMetal.Click += new System.EventHandler(this.AddMetal_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(88, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Данные из таблицы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxMetals
            // 
            this.comboBoxMetals.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMetals.FormattingEnabled = true;
            this.comboBoxMetals.Location = new System.Drawing.Point(35, 106);
            this.comboBoxMetals.Name = "comboBoxMetals";
            this.comboBoxMetals.Size = new System.Drawing.Size(313, 44);
            this.comboBoxMetals.TabIndex = 1;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(12, 584);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(87, 87);
            this.back.TabIndex = 7;
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.Paint += new System.Windows.Forms.PaintEventHandler(this.back_Paint);
            // 
            // DBMetals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 684);
            this.Controls.Add(this.panel1);
            this.Name = "DBMetals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AGDE";
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
    }
}
