namespace MC_Reservas_Hotel.Views.Manager
{
    partial class FRMPagos
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
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.btnCancelarPago = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMontoPagado = new System.Windows.Forms.TextBox();
            this.lbla = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalirPago = new System.Windows.Forms.Button();
            this.btnEliminarPago = new System.Windows.Forms.Button();
            this.btnEditarPago = new System.Windows.Forms.Button();
            this.btnAgregarPago = new System.Windows.Forms.Button();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(62, 238);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(244, 21);
            this.cbMetodoPago.TabIndex = 85;
            // 
            // btnCancelarPago
            // 
            this.btnCancelarPago.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancelarPago.Location = new System.Drawing.Point(342, 356);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(121, 60);
            this.btnCancelarPago.TabIndex = 83;
            this.btnCancelarPago.Text = "Cancelar";
            this.btnCancelarPago.UseVisualStyleBackColor = false;
            this.btnCancelarPago.Click += new System.EventHandler(this.btnCancelarPago_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(391, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "PAGOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(59, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 81;
            this.label5.Text = "Método de Pago";
            // 
            // txtMontoPagado
            // 
            this.txtMontoPagado.Location = new System.Drawing.Point(62, 193);
            this.txtMontoPagado.Name = "txtMontoPagado";
            this.txtMontoPagado.Size = new System.Drawing.Size(244, 20);
            this.txtMontoPagado.TabIndex = 80;
            // 
            // lbla
            // 
            this.lbla.AutoSize = true;
            this.lbla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbla.Location = new System.Drawing.Point(59, 175);
            this.lbla.Name = "lbla";
            this.lbla.Size = new System.Drawing.Size(88, 15);
            this.lbla.TabIndex = 79;
            this.lbla.Text = "Monto Pagado";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbl.Location = new System.Drawing.Point(59, 131);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(90, 15);
            this.lbl.TabIndex = 78;
            this.lbl.Text = "Fecha de Pago";
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Location = new System.Drawing.Point(365, 76);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.Size = new System.Drawing.Size(377, 259);
            this.dgvPagos.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(59, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 75;
            this.label1.Text = "Nombre del Cliente";
            // 
            // btnSalirPago
            // 
            this.btnSalirPago.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSalirPago.Location = new System.Drawing.Point(621, 356);
            this.btnSalirPago.Name = "btnSalirPago";
            this.btnSalirPago.Size = new System.Drawing.Size(121, 60);
            this.btnSalirPago.TabIndex = 74;
            this.btnSalirPago.Text = "Salir";
            this.btnSalirPago.UseVisualStyleBackColor = false;
            this.btnSalirPago.Click += new System.EventHandler(this.btnSalirPago_Click);
            // 
            // btnEliminarPago
            // 
            this.btnEliminarPago.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminarPago.Location = new System.Drawing.Point(480, 356);
            this.btnEliminarPago.Name = "btnEliminarPago";
            this.btnEliminarPago.Size = new System.Drawing.Size(121, 60);
            this.btnEliminarPago.TabIndex = 73;
            this.btnEliminarPago.Text = "Eliminar";
            this.btnEliminarPago.UseVisualStyleBackColor = false;
            this.btnEliminarPago.Click += new System.EventHandler(this.btnEliminarPago_Click);
            // 
            // btnEditarPago
            // 
            this.btnEditarPago.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEditarPago.Location = new System.Drawing.Point(205, 356);
            this.btnEditarPago.Name = "btnEditarPago";
            this.btnEditarPago.Size = new System.Drawing.Size(121, 60);
            this.btnEditarPago.TabIndex = 72;
            this.btnEditarPago.Text = "Editar";
            this.btnEditarPago.UseVisualStyleBackColor = false;
            this.btnEditarPago.Click += new System.EventHandler(this.btnEditarPago_Click);
            // 
            // btnAgregarPago
            // 
            this.btnAgregarPago.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAgregarPago.Location = new System.Drawing.Point(61, 356);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(122, 60);
            this.btnAgregarPago.TabIndex = 71;
            this.btnAgregarPago.Text = "Agregar";
            this.btnAgregarPago.UseVisualStyleBackColor = false;
            this.btnAgregarPago.Click += new System.EventHandler(this.btnAgregarPago_Click);
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Location = new System.Drawing.Point(61, 149);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(245, 20);
            this.dtpFechaPago.TabIndex = 86;
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(62, 104);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(244, 21);
            this.cbCliente.TabIndex = 87;
            // 
            // FRMPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.dtpFechaPago);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.btnCancelarPago);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMontoPagado);
            this.Controls.Add(this.lbla);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalirPago);
            this.Controls.Add(this.btnEliminarPago);
            this.Controls.Add(this.btnEditarPago);
            this.Controls.Add(this.btnAgregarPago);
            this.Name = "FRMPagos";
            this.Text = "FRMPagos";
            this.Load += new System.EventHandler(this.FRMPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Button btnCancelarPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMontoPagado;
        private System.Windows.Forms.Label lbla;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalirPago;
        private System.Windows.Forms.Button btnEliminarPago;
        private System.Windows.Forms.Button btnEditarPago;
        private System.Windows.Forms.Button btnAgregarPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.ComboBox cbCliente;
    }
}