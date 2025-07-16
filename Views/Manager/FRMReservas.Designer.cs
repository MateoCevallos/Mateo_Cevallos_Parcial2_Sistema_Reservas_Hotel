namespace MC_Reservas_Hotel.Views.Manager
{
    partial class FRMReservas
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
            this.cbNombreCliente = new System.Windows.Forms.ComboBox();
            this.dtpFechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbla = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalirReserva = new System.Windows.Forms.Button();
            this.btnEliminarReserva = new System.Windows.Forms.Button();
            this.btnEditarReserva = new System.Windows.Forms.Button();
            this.btnAgregarReserva = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.txtNumeroHabitacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNombreCliente
            // 
            this.cbNombreCliente.FormattingEnabled = true;
            this.cbNombreCliente.Location = new System.Drawing.Point(62, 103);
            this.cbNombreCliente.Name = "cbNombreCliente";
            this.cbNombreCliente.Size = new System.Drawing.Size(244, 21);
            this.cbNombreCliente.TabIndex = 102;
            // 
            // dtpFechaEntrada
            // 
            this.dtpFechaEntrada.Location = new System.Drawing.Point(61, 194);
            this.dtpFechaEntrada.Name = "dtpFechaEntrada";
            this.dtpFechaEntrada.Size = new System.Drawing.Size(245, 20);
            this.dtpFechaEntrada.TabIndex = 101;
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancelarReserva.Location = new System.Drawing.Point(342, 357);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(121, 60);
            this.btnCancelarReserva.TabIndex = 99;
            this.btnCancelarReserva.Text = "Cancelar";
            this.btnCancelarReserva.UseVisualStyleBackColor = false;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "RESERVAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 97;
            this.label5.Text = "Fecha de Salida";
            // 
            // lbla
            // 
            this.lbla.AutoSize = true;
            this.lbla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbla.Location = new System.Drawing.Point(59, 177);
            this.lbla.Name = "lbla";
            this.lbla.Size = new System.Drawing.Size(104, 15);
            this.lbla.TabIndex = 95;
            this.lbla.Text = "Fecha de Entrada";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(59, 132);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(144, 15);
            this.lbl.TabIndex = 94;
            this.lbl.Text = "Número de la Habitación";
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(365, 77);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.Size = new System.Drawing.Size(377, 259);
            this.dgvReservas.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 92;
            this.label1.Text = "Nombre del Cliente";
            // 
            // btnSalirReserva
            // 
            this.btnSalirReserva.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSalirReserva.Location = new System.Drawing.Point(621, 357);
            this.btnSalirReserva.Name = "btnSalirReserva";
            this.btnSalirReserva.Size = new System.Drawing.Size(121, 60);
            this.btnSalirReserva.TabIndex = 91;
            this.btnSalirReserva.Text = "Salir";
            this.btnSalirReserva.UseVisualStyleBackColor = false;
            this.btnSalirReserva.Click += new System.EventHandler(this.btnSalirReserva_Click);
            // 
            // btnEliminarReserva
            // 
            this.btnEliminarReserva.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminarReserva.Location = new System.Drawing.Point(480, 357);
            this.btnEliminarReserva.Name = "btnEliminarReserva";
            this.btnEliminarReserva.Size = new System.Drawing.Size(121, 60);
            this.btnEliminarReserva.TabIndex = 90;
            this.btnEliminarReserva.Text = "Eliminar";
            this.btnEliminarReserva.UseVisualStyleBackColor = false;
            this.btnEliminarReserva.Click += new System.EventHandler(this.btnEliminarReserva_Click);
            // 
            // btnEditarReserva
            // 
            this.btnEditarReserva.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEditarReserva.Location = new System.Drawing.Point(205, 357);
            this.btnEditarReserva.Name = "btnEditarReserva";
            this.btnEditarReserva.Size = new System.Drawing.Size(121, 60);
            this.btnEditarReserva.TabIndex = 89;
            this.btnEditarReserva.Text = "Editar";
            this.btnEditarReserva.UseVisualStyleBackColor = false;
            this.btnEditarReserva.Click += new System.EventHandler(this.btnEditarReserva_Click);
            // 
            // btnAgregarReserva
            // 
            this.btnAgregarReserva.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAgregarReserva.Location = new System.Drawing.Point(61, 357);
            this.btnAgregarReserva.Name = "btnAgregarReserva";
            this.btnAgregarReserva.Size = new System.Drawing.Size(122, 60);
            this.btnAgregarReserva.TabIndex = 88;
            this.btnAgregarReserva.Text = "Agregar";
            this.btnAgregarReserva.UseVisualStyleBackColor = false;
            this.btnAgregarReserva.Click += new System.EventHandler(this.btnAgregarReserva_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(62, 290);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(244, 21);
            this.cbEstado.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 103;
            this.label2.Text = "Estado";
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Location = new System.Drawing.Point(61, 240);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(245, 20);
            this.dtpFechaSalida.TabIndex = 105;
            // 
            // txtNumeroHabitacion
            // 
            this.txtNumeroHabitacion.Location = new System.Drawing.Point(62, 150);
            this.txtNumeroHabitacion.Name = "txtNumeroHabitacion";
            this.txtNumeroHabitacion.Size = new System.Drawing.Size(244, 20);
            this.txtNumeroHabitacion.TabIndex = 106;
            // 
            // FRMReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNumeroHabitacion);
            this.Controls.Add(this.dtpFechaSalida);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNombreCliente);
            this.Controls.Add(this.dtpFechaEntrada);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbla);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalirReserva);
            this.Controls.Add(this.btnEliminarReserva);
            this.Controls.Add(this.btnEditarReserva);
            this.Controls.Add(this.btnAgregarReserva);
            this.Name = "FRMReservas";
            this.Text = "FRMReservas";
            this.Load += new System.EventHandler(this.FRMReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNombreCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrada;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbla;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalirReserva;
        private System.Windows.Forms.Button btnEliminarReserva;
        private System.Windows.Forms.Button btnEditarReserva;
        private System.Windows.Forms.Button btnAgregarReserva;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.TextBox txtNumeroHabitacion;
    }
}