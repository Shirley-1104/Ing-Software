namespace Sistema_Control_Acceso_Empleados
{
    partial class frmQR
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
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnSolicitarAcceso = new System.Windows.Forms.Button();
            this.pbScanner = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnIgnorar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbScanner)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(357, 211);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(127, 62);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            // 
            // btnSolicitarAcceso
            // 
            this.btnSolicitarAcceso.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSolicitarAcceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolicitarAcceso.ForeColor = System.Drawing.Color.White;
            this.btnSolicitarAcceso.Location = new System.Drawing.Point(357, 124);
            this.btnSolicitarAcceso.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolicitarAcceso.Name = "btnSolicitarAcceso";
            this.btnSolicitarAcceso.Size = new System.Drawing.Size(127, 62);
            this.btnSolicitarAcceso.TabIndex = 4;
            this.btnSolicitarAcceso.Text = "Solicitar inicio de sesion manual";
            this.btnSolicitarAcceso.UseVisualStyleBackColor = false;
            // 
            // pbScanner
            // 
            this.pbScanner.BackColor = System.Drawing.Color.AliceBlue;
            this.pbScanner.Image = global::Sistema_Control_Acceso_Empleados.Properties.Resources.Camara;
            this.pbScanner.Location = new System.Drawing.Point(27, 91);
            this.pbScanner.Name = "pbScanner";
            this.pbScanner.Size = new System.Drawing.Size(298, 211);
            this.pbScanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScanner.TabIndex = 5;
            this.pbScanner.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTitulo.Location = new System.Drawing.Point(21, 56);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 32);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Lector QR";
            // 
            // btnIgnorar
            // 
            this.btnIgnorar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIgnorar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIgnorar.ForeColor = System.Drawing.Color.White;
            this.btnIgnorar.Location = new System.Drawing.Point(443, 11);
            this.btnIgnorar.Margin = new System.Windows.Forms.Padding(2);
            this.btnIgnorar.Name = "btnIgnorar";
            this.btnIgnorar.Size = new System.Drawing.Size(73, 29);
            this.btnIgnorar.TabIndex = 7;
            this.btnIgnorar.Text = "Finalizar";
            this.btnIgnorar.UseVisualStyleBackColor = false;
            this.btnIgnorar.Click += new System.EventHandler(this.btnIgnorar_Click);
            // 
            // frmQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistema_Control_Acceso_Empleados.Properties.Resources.Prototipo_6_log_in;
            this.ClientSize = new System.Drawing.Size(537, 324);
            this.Controls.Add(this.btnIgnorar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pbScanner);
            this.Controls.Add(this.btnSolicitarAcceso);
            this.Controls.Add(this.btnCerrarSesion);
            this.Name = "frmQR";
            this.Text = "frmQR";
            ((System.ComponentModel.ISupportInitialize)(this.pbScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnSolicitarAcceso;
        private System.Windows.Forms.PictureBox pbScanner;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnIgnorar;
    }
}