
namespace AutoBooter
{
    partial class root
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
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.prepare_btn = new System.Windows.Forms.Button();
            this.boot_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.status_txt = new System.Windows.Forms.Label();
            this.port_select = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(9, 46);
            this.progress_bar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(268, 28);
            this.progress_bar.TabIndex = 0;
            // 
            // prepare_btn
            // 
            this.prepare_btn.Location = new System.Drawing.Point(9, 88);
            this.prepare_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.prepare_btn.Name = "prepare_btn";
            this.prepare_btn.Size = new System.Drawing.Size(134, 31);
            this.prepare_btn.TabIndex = 1;
            this.prepare_btn.Text = "Подготовить";
            this.prepare_btn.UseVisualStyleBackColor = true;
            this.prepare_btn.Click += new System.EventHandler(this.prepare_btn_Click);
            // 
            // boot_btn
            // 
            this.boot_btn.Enabled = false;
            this.boot_btn.Location = new System.Drawing.Point(147, 88);
            this.boot_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boot_btn.Name = "boot_btn";
            this.boot_btn.Size = new System.Drawing.Size(130, 31);
            this.boot_btn.TabIndex = 2;
            this.boot_btn.Text = "Обновить";
            this.boot_btn.UseVisualStyleBackColor = true;
            this.boot_btn.Click += new System.EventHandler(this.boot_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Статус: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // status_txt
            // 
            this.status_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status_txt.Location = new System.Drawing.Point(73, 7);
            this.status_txt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.status_txt.Name = "status_txt";
            this.status_txt.Size = new System.Drawing.Size(205, 29);
            this.status_txt.TabIndex = 4;
            this.status_txt.Text = "ожидание запуска";
            this.status_txt.Click += new System.EventHandler(this.label2_Click);
            // 
            // port_select
            // 
            this.port_select.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.port_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.port_select.ForeColor = System.Drawing.SystemColors.InfoText;
            this.port_select.Location = new System.Drawing.Point(160, 80);
            this.port_select.Name = "port_select";
            this.port_select.Size = new System.Drawing.Size(116, 21);
            this.port_select.TabIndex = 5;
            this.port_select.Tag = "Выберите порт устройства";
            this.port_select.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выберете порт устройства:";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // root
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.port_select);
            this.Controls.Add(this.status_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prepare_btn);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.boot_btn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(304, 170);
            this.MinimumSize = new System.Drawing.Size(304, 170);
            this.Name = "root";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "AutoBooter";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Button prepare_btn;
        private System.Windows.Forms.Button boot_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label status_txt;
        private System.Windows.Forms.ComboBox port_select;
        private System.Windows.Forms.Label label2;
    }
}

