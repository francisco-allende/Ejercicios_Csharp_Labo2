
namespace Ejercicio_exc_2
{
    partial class Calculador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculador));
            this.labelKM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLitro = new System.Windows.Forms.Label();
            this.txtBoxKM = new System.Windows.Forms.TextBox();
            this.txtBoxLit = new System.Windows.Forms.TextBox();
            this.buttonCalcular = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelKM
            // 
            this.labelKM.AutoSize = true;
            this.labelKM.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelKM.Location = new System.Drawing.Point(85, 9);
            this.labelKM.Name = "labelKM";
            this.labelKM.Size = new System.Drawing.Size(154, 40);
            this.labelKM.TabIndex = 1;
            this.labelKM.Text = "Kilómetros\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            // 
            // labelLitro
            // 
            this.labelLitro.AutoSize = true;
            this.labelLitro.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLitro.Location = new System.Drawing.Point(85, 183);
            this.labelLitro.Name = "labelLitro";
            this.labelLitro.Size = new System.Drawing.Size(160, 40);
            this.labelLitro.TabIndex = 3;
            this.labelLitro.Text = "Litros nafta";
            // 
            // txtBoxKM
            // 
            this.txtBoxKM.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxKM.Location = new System.Drawing.Point(85, 72);
            this.txtBoxKM.Name = "txtBoxKM";
            this.txtBoxKM.Size = new System.Drawing.Size(154, 33);
            this.txtBoxKM.TabIndex = 2;
            // 
            // txtBoxLit
            // 
            this.txtBoxLit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxLit.Location = new System.Drawing.Point(85, 235);
            this.txtBoxLit.Name = "txtBoxLit";
            this.txtBoxLit.Size = new System.Drawing.Size(160, 33);
            this.txtBoxLit.TabIndex = 4;
            // 
            // buttonCalcular
            // 
            this.buttonCalcular.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCalcular.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCalcular.ForeColor = System.Drawing.Color.Yellow;
            this.buttonCalcular.Location = new System.Drawing.Point(98, 296);
            this.buttonCalcular.Name = "buttonCalcular";
            this.buttonCalcular.Size = new System.Drawing.Size(135, 39);
            this.buttonCalcular.TabIndex = 5;
            this.buttonCalcular.Text = "Calcular";
            this.buttonCalcular.UseVisualStyleBackColor = false;
            this.buttonCalcular.Click += new System.EventHandler(this.buttonCalcular_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Enabled = false;
            this.richTextBox.Location = new System.Drawing.Point(381, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(213, 341);
            this.richTextBox.TabIndex = 6;
            this.richTextBox.Text = "";
            // 
            // Calculador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(595, 347);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.buttonCalcular);
            this.Controls.Add(this.txtBoxLit);
            this.Controls.Add(this.txtBoxKM);
            this.Controls.Add(this.labelLitro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelKM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Calculador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculador";
            this.Load += new System.EventHandler(this.Calculador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelLitro;
        private System.Windows.Forms.TextBox txtBoxKM;
        private System.Windows.Forms.TextBox txtBoxLit;
        private System.Windows.Forms.Button buttonCalcular;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

