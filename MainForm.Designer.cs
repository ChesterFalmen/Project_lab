
namespace Booking
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.button_exit = new System.Windows.Forms.LinkLabel();
            this.label_title = new System.Windows.Forms.Label();
            this.listBox_from = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_to = new System.Windows.Forms.ListBox();
            this.textBox_from = new System.Windows.Forms.TextBox();
            this.label_from = new System.Windows.Forms.Label();
            this.label_to = new System.Windows.Forms.Label();
            this.textBox_to = new System.Windows.Forms.TextBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.label_date = new System.Windows.Forms.Label();
            this.textBox_date_depart = new System.Windows.Forms.TextBox();
            this.textBox_class = new System.Windows.Forms.TextBox();
            this.label_class = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listBox_class = new System.Windows.Forms.ListBox();
            this.button_order = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_date = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_exit
            // 
            this.button_exit.AutoSize = true;
            this.button_exit.BackColor = System.Drawing.Color.White;
            this.button_exit.DisabledLinkColor = System.Drawing.Color.White;
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.ForeColor = System.Drawing.SystemColors.Control;
            this.button_exit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.button_exit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_exit.Location = new System.Drawing.Point(941, 9);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(21, 20);
            this.button_exit.TabIndex = 8;
            this.button_exit.TabStop = true;
            this.button_exit.Text = "X";
            this.button_exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_exit.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exit_LinkClicked);
            // 
            // label_title
            // 
            this.label_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title.ForeColor = System.Drawing.SystemColors.Control;
            this.label_title.Location = new System.Drawing.Point(343, 19);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(276, 32);
            this.label_title.TabIndex = 9;
            this.label_title.Text = "Меню бронювання";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_from
            // 
            this.listBox_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox_from.FormattingEnabled = true;
            this.listBox_from.ItemHeight = 25;
            this.listBox_from.Location = new System.Drawing.Point(40, 147);
            this.listBox_from.Name = "listBox_from";
            this.listBox_from.Size = new System.Drawing.Size(226, 129);
            this.listBox_from.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(45, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Звідки відправлятись";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(331, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Куди прибувати";
            // 
            // listBox_to
            // 
            this.listBox_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox_to.FormattingEnabled = true;
            this.listBox_to.ItemHeight = 25;
            this.listBox_to.Location = new System.Drawing.Point(302, 147);
            this.listBox_to.Name = "listBox_to";
            this.listBox_to.Size = new System.Drawing.Size(226, 129);
            this.listBox_to.TabIndex = 13;
            // 
            // textBox_from
            // 
            this.textBox_from.Enabled = false;
            this.textBox_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_from.Location = new System.Drawing.Point(797, 135);
            this.textBox_from.Name = "textBox_from";
            this.textBox_from.Size = new System.Drawing.Size(165, 26);
            this.textBox_from.TabIndex = 14;
            // 
            // label_from
            // 
            this.label_from.AutoSize = true;
            this.label_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_from.ForeColor = System.Drawing.SystemColors.Control;
            this.label_from.Location = new System.Drawing.Point(613, 135);
            this.label_from.Name = "label_from";
            this.label_from.Size = new System.Drawing.Size(124, 25);
            this.label_from.TabIndex = 15;
            this.label_from.Text = "Відправка з:";
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_to.ForeColor = System.Drawing.SystemColors.Control;
            this.label_to.Location = new System.Drawing.Point(613, 166);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(122, 25);
            this.label_to.TabIndex = 17;
            this.label_to.Text = "Відправка у:";
            // 
            // textBox_to
            // 
            this.textBox_to.Enabled = false;
            this.textBox_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_to.Location = new System.Drawing.Point(797, 167);
            this.textBox_to.Name = "textBox_to";
            this.textBox_to.Size = new System.Drawing.Size(165, 26);
            this.textBox_to.TabIndex = 16;
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.White;
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.Location = new System.Drawing.Point(821, 283);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(96, 37);
            this.button_clear.TabIndex = 20;
            this.button_clear.Text = "Очистити";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_date.ForeColor = System.Drawing.SystemColors.Control;
            this.label_date.Location = new System.Drawing.Point(580, 198);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(196, 25);
            this.label_date.TabIndex = 22;
            this.label_date.Text = "Дата відправлення:";
            // 
            // textBox_date_depart
            // 
            this.textBox_date_depart.Enabled = false;
            this.textBox_date_depart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_date_depart.Location = new System.Drawing.Point(797, 199);
            this.textBox_date_depart.Name = "textBox_date_depart";
            this.textBox_date_depart.Size = new System.Drawing.Size(165, 26);
            this.textBox_date_depart.TabIndex = 21;
            // 
            // textBox_class
            // 
            this.textBox_class.Enabled = false;
            this.textBox_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_class.Location = new System.Drawing.Point(797, 231);
            this.textBox_class.Name = "textBox_class";
            this.textBox_class.Size = new System.Drawing.Size(165, 26);
            this.textBox_class.TabIndex = 28;
            // 
            // label_class
            // 
            this.label_class.AutoSize = true;
            this.label_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_class.ForeColor = System.Drawing.SystemColors.Control;
            this.label_class.Location = new System.Drawing.Point(650, 232);
            this.label_class.Name = "label_class";
            this.label_class.Size = new System.Drawing.Size(62, 25);
            this.label_class.TabIndex = 27;
            this.label_class.Text = "Клас:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(118, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 25);
            this.label12.TabIndex = 33;
            this.label12.Text = "Клас";
            // 
            // listBox_class
            // 
            this.listBox_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox_class.FormattingEnabled = true;
            this.listBox_class.ItemHeight = 25;
            this.listBox_class.Location = new System.Drawing.Point(40, 358);
            this.listBox_class.Name = "listBox_class";
            this.listBox_class.Size = new System.Drawing.Size(226, 129);
            this.listBox_class.TabIndex = 32;
            // 
            // button_order
            // 
            this.button_order.Location = new System.Drawing.Point(797, 349);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(137, 41);
            this.button_order.TabIndex = 35;
            this.button_order.Text = "Замовити";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_name.ForeColor = System.Drawing.SystemColors.Control;
            this.label_name.Location = new System.Drawing.Point(598, 103);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(149, 25);
            this.label_name.TabIndex = 37;
            this.label_name.Text = "Ім\'я Прізвище:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(797, 107);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(165, 22);
            this.textBox_name.TabIndex = 38;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(302, 366);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(226, 24);
            this.comboBox1.TabIndex = 39;
            // 
            // button_date
            // 
            this.button_date.Location = new System.Drawing.Point(575, 366);
            this.button_date.Name = "button_date";
            this.button_date.Size = new System.Drawing.Size(123, 32);
            this.button_date.TabIndex = 40;
            this.button_date.Text = "Вибрати дату";
            this.button_date.UseVisualStyleBackColor = true;
            this.button_date.Click += new System.EventHandler(this.button_date_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(974, 865);
            this.Controls.Add(this.button_date);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_order);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listBox_class);
            this.Controls.Add(this.textBox_class);
            this.Controls.Add(this.label_class);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.textBox_date_depart);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.textBox_to);
            this.Controls.Add(this.label_from);
            this.Controls.Add(this.textBox_from);
            this.Controls.Add(this.listBox_to);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_from);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.button_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel button_exit;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.ListBox listBox_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_to;
        private System.Windows.Forms.TextBox textBox_from;
        private System.Windows.Forms.Label label_from;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.TextBox textBox_to;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.TextBox textBox_date_depart;
        private System.Windows.Forms.TextBox textBox_class;
        private System.Windows.Forms.Label label_class;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox_class;
        private System.Windows.Forms.Button button_order;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_date;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}