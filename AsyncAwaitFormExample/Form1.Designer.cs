namespace AsyncAwaitFormExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblresult = new System.Windows.Forms.Label();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(349, 151);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(365, 87);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(38, 15);
            this.lblresult.TabIndex = 1;
            this.lblresult.Text = "label1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(796, 517);
            this.Controls.Add(this.lblresult);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.Button btnCalculate;
    }
}

