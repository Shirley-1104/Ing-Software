namespace SistemControlAccesoEmpleados
{
    partial class FrmAutorizacionManual
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
            this.lblCorreoUser = new System.Windows.Forms.Label();
            this.txtCorreoUser = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCorreoUser
            // 
            this.lblCorreoUser.AutoSize = true;
            this.lblCorreoUser.Location = new System.Drawing.Point(151, 94);
            this.lblCorreoUser.Name = "lblCorreoUser";
            this.lblCorreoUser.Size = new System.Drawing.Size(145, 20);
            this.lblCorreoUser.TabIndex = 0;
            this.lblCorreoUser.Text = "Correo del Usuario:";
            this.lblCorreoUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCorreoUser
            // 
            this.txtCorreoUser.Location = new System.Drawing.Point(384, 87);
            this.txtCorreoUser.Name = "txtCorreoUser";
            this.txtCorreoUser.Size = new System.Drawing.Size(168, 26);
            this.txtCorreoUser.TabIndex = 1;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(151, 171);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(173, 20);
            this.lblMotivo.TabIndex = 2;
            this.lblMotivo.Text = "Motivo de Autorización:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(384, 171);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(156, 26);
            this.txtMotivo.TabIndex = 3;
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Location = new System.Drawing.Point(155, 335);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(155, 60);
            this.btnAutorizar.TabIndex = 4;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.UseVisualStyleBackColor = true;
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(435, 317);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(21, 20);
            this.lblResultado.TabIndex = 5;
            this.lblResultado.Text = "\"\"";
            // 
            // FrmAutorizacionManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnAutorizar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtCorreoUser);
            this.Controls.Add(this.lblCorreoUser);
            this.Name = "FrmAutorizacionManual";
            this.Text = "FrmAutorizacionManual";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCorreoUser;
        private System.Windows.Forms.TextBox txtCorreoUser;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.Label lblResultado;
    }
}