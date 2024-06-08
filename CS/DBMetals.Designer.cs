using System.Drawing;
using System;
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMetals = new System.Windows.Forms.ComboBox();
            this.ShowItems = new System.Windows.Forms.Button();
            this.AddMetal = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SelectThis = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 693);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxMetals, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ShowItems, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.AddMetal, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.SelectThis, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.back, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 693);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 103);
            this.label1.TabIndex = 0;
            this.label1.Text = "Данные из таблицы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxMetals
            // 
            this.comboBoxMetals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxMetals.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMetals.FormattingEnabled = true;
            this.comboBoxMetals.Location = new System.Drawing.Point(3, 106);
            this.comboBoxMetals.Name = "comboBoxMetals";
            this.comboBoxMetals.Size = new System.Drawing.Size(194, 44);
            this.comboBoxMetals.TabIndex = 1;
            // 
            // ShowItems
            // 
            this.ShowItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowItems.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowItems.Location = new System.Drawing.Point(203, 106);
            this.ShowItems.Name = "ShowItems";
            this.ShowItems.Size = new System.Drawing.Size(194, 97);
            this.ShowItems.TabIndex = 2;
            this.ShowItems.Text = "Отобразить свойства";
            this.ShowItems.UseVisualStyleBackColor = true;
            this.ShowItems.Click += new System.EventHandler(this.ShowItems_Click);
            // 
            // AddMetal
            // 
            this.AddMetal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.tableLayoutPanel1.SetColumnSpan(this.AddMetal, 2);
            this.AddMetal.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMetal.ForeColor = System.Drawing.Color.White;
            this.AddMetal.Location = new System.Drawing.Point(3, 209);
            this.AddMetal.Name = "AddMetal";
            this.AddMetal.Size = new System.Drawing.Size(394, 188);
            this.AddMetal.TabIndex = 3;
            this.AddMetal.Text = "Добавить металл";
            this.AddMetal.UseVisualStyleBackColor = false;
            this.AddMetal.Click += new System.EventHandler(this.AddMetal_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 132);
            this.button1.TabIndex = 4;
            this.button1.Text = "Решение на одномерной плоскости";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(203, 416);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 132);
            this.button2.TabIndex = 5;
            this.button2.Text = "Решение на двухмерной плоскости";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SelectThis
            // 
            this.SelectThis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.SelectThis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectThis.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectThis.ForeColor = System.Drawing.Color.White;
            this.SelectThis.Location = new System.Drawing.Point(203, 554);
            this.SelectThis.Name = "SelectThis";
            this.SelectThis.Size = new System.Drawing.Size(194, 136);
            this.SelectThis.TabIndex = 6;
            this.SelectThis.Text = "Выбрать металл";
            this.SelectThis.UseVisualStyleBackColor = false;
            this.SelectThis.Click += new System.EventHandler(this.SelectThis_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(130)))));
            this.back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(3, 554);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(194, 136);
            this.back.TabIndex = 7;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // DBMetals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 693);
            this.Controls.Add(this.panel1);
            this.Name = "DBMetals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AGDE";
            this.Load += new System.EventHandler(this.DBMetals_Load);
            this.Resize += new System.EventHandler(this.DBMetals_Resize);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxMetals;
        private System.Windows.Forms.Button SelectThis;
        private System.Windows.Forms.Button ShowItems;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button AddMetal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;

        private void DBMetals_Resize(object sender, EventArgs e)
        {
            AdjustFontSizes();
        }

        // Method to adjust font sizes based on the form's size
        private void AdjustFontSizes()
        {
            float fontSize = this.ClientSize.Width / 30f; // Adjust the divisor to suit your needs
            Font newFont = new Font("Times New Roman", fontSize, FontStyle.Regular);

            label1.Font = newFont;
            comboBoxMetals.Font = newFont;
            ShowItems.Font = newFont;
            AddMetal.Font = newFont;
            button1.Font = newFont;
            button2.Font = newFont;
            SelectThis.Font = newFont;
            back.Font = newFont;
        }
    }
}
