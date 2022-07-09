
namespace WinFormsApp
{
    partial class FormMenu
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
            this.btn_GenerarLlamada = new System.Windows.Forms.Button();
            this.btn_FactTotal = new System.Windows.Forms.Button();
            this.btn_FactLocal = new System.Windows.Forms.Button();
            this.btn_FactProv = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GenerarLlamada
            // 
            this.btn_GenerarLlamada.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_GenerarLlamada.Location = new System.Drawing.Point(103, 23);
            this.btn_GenerarLlamada.Name = "btn_GenerarLlamada";
            this.btn_GenerarLlamada.Size = new System.Drawing.Size(138, 51);
            this.btn_GenerarLlamada.TabIndex = 0;
            this.btn_GenerarLlamada.Text = "Generar Llamada";
            this.btn_GenerarLlamada.UseVisualStyleBackColor = true;
            this.btn_GenerarLlamada.Click += new System.EventHandler(this.btn_GenerarLlamada_Click);
            // 
            // btn_FactTotal
            // 
            this.btn_FactTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_FactTotal.Location = new System.Drawing.Point(103, 104);
            this.btn_FactTotal.Name = "btn_FactTotal";
            this.btn_FactTotal.Size = new System.Drawing.Size(138, 51);
            this.btn_FactTotal.TabIndex = 1;
            this.btn_FactTotal.Text = "Facturacion Total";
            this.btn_FactTotal.UseVisualStyleBackColor = true;
            this.btn_FactTotal.Click += new System.EventHandler(this.btn_FactTotal_Click);
            // 
            // btn_FactLocal
            // 
            this.btn_FactLocal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_FactLocal.Location = new System.Drawing.Point(103, 190);
            this.btn_FactLocal.Name = "btn_FactLocal";
            this.btn_FactLocal.Size = new System.Drawing.Size(138, 51);
            this.btn_FactLocal.TabIndex = 2;
            this.btn_FactLocal.Text = "Facturacion Local";
            this.btn_FactLocal.UseVisualStyleBackColor = true;
            this.btn_FactLocal.Click += new System.EventHandler(this.btn_FactLocal_Click);
            // 
            // btn_FactProv
            // 
            this.btn_FactProv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_FactProv.Location = new System.Drawing.Point(103, 271);
            this.btn_FactProv.Name = "btn_FactProv";
            this.btn_FactProv.Size = new System.Drawing.Size(138, 51);
            this.btn_FactProv.TabIndex = 3;
            this.btn_FactProv.Text = "Facturacion Provincial";
            this.btn_FactProv.UseVisualStyleBackColor = true;
            this.btn_FactProv.Click += new System.EventHandler(this.btn_FactProv_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Salir.Location = new System.Drawing.Point(103, 352);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(138, 51);
            this.btn_Salir.TabIndex = 4;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(346, 435);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_FactProv);
            this.Controls.Add(this.btn_FactLocal);
            this.Controls.Add(this.btn_FactTotal);
            this.Controls.Add(this.btn_GenerarLlamada);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GenerarLlamada;
        private System.Windows.Forms.Button btn_FactTotal;
        private System.Windows.Forms.Button btn_FactLocal;
        private System.Windows.Forms.Button btn_FactProv;
        private System.Windows.Forms.Button btn_Salir;
    }
}

