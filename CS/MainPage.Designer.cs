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
            this.label1 = new System.Windows.Forms.Label();
            this.ChoiceIn = new System.Windows.Forms.Button();
            this.ChoiceShow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ChoiceIn);
            this.panel1.Controls.Add(this.ChoiceShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 684);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoEllipsis = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(19, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите опцию:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChoiceIn
            // 
            this.ChoiceIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChoiceIn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.ChoiceIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.ChoiceIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoiceIn.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceIn.ForeColor = System.Drawing.Color.DarkBlue;
            this.ChoiceIn.Location = new System.Drawing.Point(51, 436);
            this.ChoiceIn.Name = "ChoiceIn";
            this.ChoiceIn.Size = new System.Drawing.Size(503, 90);
            this.ChoiceIn.TabIndex = 3;
            this.ChoiceIn.Text = "Ввести свои свойства металла";
            this.ChoiceIn.UseVisualStyleBackColor = true;
            this.ChoiceIn.Click += new System.EventHandler(this.ChoiceIn_Click);
            // 
            // ChoiceShow
            // 
            this.ChoiceShow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChoiceShow.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.ChoiceShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.ChoiceShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoiceShow.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceShow.ForeColor = System.Drawing.Color.DarkBlue;
            this.ChoiceShow.Location = new System.Drawing.Point(51, 187);
            this.ChoiceShow.Name = "ChoiceShow";
            this.ChoiceShow.Size = new System.Drawing.Size(503, 90);
            this.ChoiceShow.TabIndex = 2;
            this.ChoiceShow.Text = "Выбрать металл из списка";
            this.ChoiceShow.UseVisualStyleBackColor = true;
            this.ChoiceShow.Click += new System.EventHandler(this.ChoiceShow_Click_1);
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
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChoiceIn;
        private System.Windows.Forms.Button ChoiceShow;
    }
}
