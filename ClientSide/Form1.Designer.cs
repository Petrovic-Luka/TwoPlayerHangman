namespace ClientSide
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
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.lblPokusaji = new System.Windows.Forms.Label();
            this.lblZivoti = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtGuess
            // 
            this.txtGuess.Location = new System.Drawing.Point(47, 146);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(43, 20);
            this.txtGuess.TabIndex = 5;
            // 
            // lblPokusaji
            // 
            this.lblPokusaji.AutoSize = true;
            this.lblPokusaji.Location = new System.Drawing.Point(166, 136);
            this.lblPokusaji.Name = "lblPokusaji";
            this.lblPokusaji.Size = new System.Drawing.Size(88, 13);
            this.lblPokusaji.TabIndex = 6;
            this.lblPokusaji.Text = "Promasena slova";
            // 
            // lblZivoti
            // 
            this.lblZivoti.AutoSize = true;
            this.lblZivoti.Location = new System.Drawing.Point(166, 166);
            this.lblZivoti.Name = "lblZivoti";
            this.lblZivoti.Size = new System.Drawing.Size(94, 13);
            this.lblZivoti.TabIndex = 7;
            this.lblZivoti.Text = "Broj pokusaja 0|10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Pogadjaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt1
            // 
            this.txt1.Enabled = false;
            this.txt1.Location = new System.Drawing.Point(47, 53);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(100, 20);
            this.txt1.TabIndex = 9;
            this.txt1.Text = ".....";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblZivoti);
            this.Controls.Add(this.lblPokusaji);
            this.Controls.Add(this.txtGuess);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.Label lblPokusaji;
        private System.Windows.Forms.Label lblZivoti;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt1;
    }
}

