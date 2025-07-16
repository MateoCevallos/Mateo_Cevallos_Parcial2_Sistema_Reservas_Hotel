namespace MC_Reservas_Hotel.Views.Manager
{
    partial class FRMHabitaciones
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
            this.btnCancelarHabitacion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioNoche = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumHabitacion = new System.Windows.Forms.TextBox();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalirHabitacion = new System.Windows.Forms.Button();
            this.btnEliminarHabitacion = new System.Windows.Forms.Button();
            this.btnEditarHabitacion = new System.Windows.Forms.Button();
            this.btnAgregarHabitacion = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelarHabitacion
            // 
            this.btnCancelarHabitacion.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancelarHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarHabitacion.Location = new System.Drawing.Point(342, 356);
            this.btnCancelarHabitacion.Name = "btnCancelarHabitacion";
            this.btnCancelarHabitacion.Size = new System.Drawing.Size(121, 60);
            this.btnCancelarHabitacion.TabIndex = 68;
            this.btnCancelarHabitacion.Text = "Cancelar";
            this.btnCancelarHabitacion.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(352, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "HABITACIONES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 65;
            this.label5.Text = "Estado";
            // 
            // txtPrecioNoche
            // 
            this.txtPrecioNoche.Location = new System.Drawing.Point(62, 191);
            this.txtPrecioNoche.Name = "txtPrecioNoche";
            this.txtPrecioNoche.Size = new System.Drawing.Size(244, 20);
            this.txtPrecioNoche.TabIndex = 64;
            this.txtPrecioNoche.Text = "0,0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 63;
            this.label3.Text = "Precio por Noche";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 61;
            this.label2.Text = "Tipo";
            // 
            // txtNumHabitacion
            // 
            this.txtNumHabitacion.Location = new System.Drawing.Point(62, 102);
            this.txtNumHabitacion.Name = "txtNumHabitacion";
            this.txtNumHabitacion.Size = new System.Drawing.Size(244, 20);
            this.txtNumHabitacion.TabIndex = 60;
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(365, 76);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.Size = new System.Drawing.Size(377, 259);
            this.dgvHabitaciones.TabIndex = 59;
            this.dgvHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 15);
            this.label1.TabIndex = 58;
            this.label1.Text = "Numero de Habitación";
            // 
            // btnSalirHabitacion
            // 
            this.btnSalirHabitacion.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSalirHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirHabitacion.Location = new System.Drawing.Point(621, 356);
            this.btnSalirHabitacion.Name = "btnSalirHabitacion";
            this.btnSalirHabitacion.Size = new System.Drawing.Size(121, 60);
            this.btnSalirHabitacion.TabIndex = 57;
            this.btnSalirHabitacion.Text = "Salir";
            this.btnSalirHabitacion.UseVisualStyleBackColor = false;
            this.btnSalirHabitacion.Click += new System.EventHandler(this.btnSalirHabitacion_Click);
            // 
            // btnEliminarHabitacion
            // 
            this.btnEliminarHabitacion.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminarHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarHabitacion.Location = new System.Drawing.Point(480, 356);
            this.btnEliminarHabitacion.Name = "btnEliminarHabitacion";
            this.btnEliminarHabitacion.Size = new System.Drawing.Size(121, 60);
            this.btnEliminarHabitacion.TabIndex = 56;
            this.btnEliminarHabitacion.Text = "Eliminar";
            this.btnEliminarHabitacion.UseVisualStyleBackColor = false;
            // 
            // btnEditarHabitacion
            // 
            this.btnEditarHabitacion.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEditarHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarHabitacion.Location = new System.Drawing.Point(205, 356);
            this.btnEditarHabitacion.Name = "btnEditarHabitacion";
            this.btnEditarHabitacion.Size = new System.Drawing.Size(121, 60);
            this.btnEditarHabitacion.TabIndex = 55;
            this.btnEditarHabitacion.Text = "Editar";
            this.btnEditarHabitacion.UseVisualStyleBackColor = false;
            // 
            // btnAgregarHabitacion
            // 
            this.btnAgregarHabitacion.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAgregarHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarHabitacion.Location = new System.Drawing.Point(61, 356);
            this.btnAgregarHabitacion.Name = "btnAgregarHabitacion";
            this.btnAgregarHabitacion.Size = new System.Drawing.Size(122, 60);
            this.btnAgregarHabitacion.TabIndex = 54;
            this.btnAgregarHabitacion.Text = "Agregar";
            this.btnAgregarHabitacion.UseVisualStyleBackColor = false;
            this.btnAgregarHabitacion.Click += new System.EventHandler(this.btnAgregarHabitacion_Click_1);
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(61, 147);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(245, 21);
            this.cbTipo.TabIndex = 69;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(62, 236);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(244, 21);
            this.cbEstado.TabIndex = 70;
            // 
            // FRMHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.btnCancelarHabitacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecioNoche);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumHabitacion);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalirHabitacion);
            this.Controls.Add(this.btnEliminarHabitacion);
            this.Controls.Add(this.btnEditarHabitacion);
            this.Controls.Add(this.btnAgregarHabitacion);
            this.Name = "FRMHabitaciones";
            this.Text = "FRMHabitaciones";
            this.Load += new System.EventHandler(this.FRMHabitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarHabitacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioNoche;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumHabitacion;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalirHabitacion;
        private System.Windows.Forms.Button btnEliminarHabitacion;
        private System.Windows.Forms.Button btnEditarHabitacion;
        private System.Windows.Forms.Button btnAgregarHabitacion;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ComboBox cbEstado;
    }
}