namespace cours10appwindowsform
{
    partial class Form1
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
            this.btn1 = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Parcourir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(56, 80);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(131, 23);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "CLIQUE MOE ESTI";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(40, 15);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(216, 20);
            this.txt1.TabIndex = 1;
            this.txt1.TextChanged += new System.EventHandler(this.txt1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Parcourir
            // 
            this.Parcourir.Location = new System.Drawing.Point(181, 210);
            this.Parcourir.Name = "Parcourir";
            this.Parcourir.Size = new System.Drawing.Size(75, 23);
            this.Parcourir.TabIndex = 3;
            this.Parcourir.Text = "Parcourir";
            this.Parcourir.UseVisualStyleBackColor = true;
            this.Parcourir.Click += new System.EventHandler(this.Parcourir_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Parcourir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.btn1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Parcourir;
    }
}

