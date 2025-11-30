namespace AnalisisProg
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
            this.groupBoxRegistros = new System.Windows.Forms.GroupBox();
            this.lstDatos2 = new System.Windows.Forms.ListBox();
            this.lstDatos = new System.Windows.Forms.ListBox();
            this.lblTiempoInicio = new System.Windows.Forms.Label();
            this.lblTiempoFin = new System.Windows.Forms.Label();
            this.btnGenerarNumeros = new System.Windows.Forms.Button();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.btnInsertionSort = new System.Windows.Forms.Button();
            this.btnQuickSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.btnBusquedaSecuencial = new System.Windows.Forms.Button();
            this.btnBusquedaBinaria = new System.Windows.Forms.Button();
            this.lblDuracion2 = new System.Windows.Forms.Label();
            this.lblTiempoFin2 = new System.Windows.Forms.Label();
            this.lblTiempoInicio2 = new System.Windows.Forms.Label();
            this.groupBoxRegistros.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRegistros
            // 
            this.groupBoxRegistros.Controls.Add(this.lstDatos2);
            this.groupBoxRegistros.Controls.Add(this.lstDatos);
            this.groupBoxRegistros.Location = new System.Drawing.Point(12, 268);
            this.groupBoxRegistros.Name = "groupBoxRegistros";
            this.groupBoxRegistros.Size = new System.Drawing.Size(362, 225);
            this.groupBoxRegistros.TabIndex = 0;
            this.groupBoxRegistros.TabStop = false;
            this.groupBoxRegistros.Text = "Registros: 0";
            // 
            // lstDatos2
            // 
            this.lstDatos2.FormattingEnabled = true;
            this.lstDatos2.ItemHeight = 16;
            this.lstDatos2.Location = new System.Drawing.Point(188, 21);
            this.lstDatos2.Name = "lstDatos2";
            this.lstDatos2.Size = new System.Drawing.Size(167, 196);
            this.lstDatos2.TabIndex = 1;
            // 
            // lstDatos
            // 
            this.lstDatos.FormattingEnabled = true;
            this.lstDatos.ItemHeight = 16;
            this.lstDatos.Location = new System.Drawing.Point(6, 21);
            this.lstDatos.Name = "lstDatos";
            this.lstDatos.Size = new System.Drawing.Size(167, 196);
            this.lstDatos.TabIndex = 0;
            // 
            // lblTiempoInicio
            // 
            this.lblTiempoInicio.AutoSize = true;
            this.lblTiempoInicio.Location = new System.Drawing.Point(6, 517);
            this.lblTiempoInicio.Name = "lblTiempoInicio";
            this.lblTiempoInicio.Size = new System.Drawing.Size(161, 16);
            this.lblTiempoInicio.TabIndex = 1;
            this.lblTiempoInicio.Text = "Tiempo de inicio: 00:00:00";
            // 
            // lblTiempoFin
            // 
            this.lblTiempoFin.AutoSize = true;
            this.lblTiempoFin.Location = new System.Drawing.Point(6, 546);
            this.lblTiempoFin.Name = "lblTiempoFin";
            this.lblTiempoFin.Size = new System.Drawing.Size(143, 16);
            this.lblTiempoFin.TabIndex = 2;
            this.lblTiempoFin.Text = "Tiempo de fin: 00:00:00";
            this.lblTiempoFin.Click += new System.EventHandler(this.lblTiempoFin_Click);
            // 
            // btnGenerarNumeros
            // 
            this.btnGenerarNumeros.Location = new System.Drawing.Point(356, 35);
            this.btnGenerarNumeros.Name = "btnGenerarNumeros";
            this.btnGenerarNumeros.Size = new System.Drawing.Size(54, 168);
            this.btnGenerarNumeros.TabIndex = 3;
            this.btnGenerarNumeros.Text = "Generar Numeros";
            this.btnGenerarNumeros.UseVisualStyleBackColor = true;
            this.btnGenerarNumeros.Click += new System.EventHandler(this.btnGenerarNumeros_Click);
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.Location = new System.Drawing.Point(11, 24);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(141, 16);
            this.lblCantidadRegistros.TabIndex = 5;
            this.lblCantidadRegistros.Text = "Cantidad de Registros";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(158, 21);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(174, 22);
            this.tbCantidad.TabIndex = 6;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(6, 571);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(139, 16);
            this.lblDuracion.TabIndex = 7;
            this.lblDuracion.Text = "Duracion: 0 Segundos";
            // 
            // btnInsertionSort
            // 
            this.btnInsertionSort.Location = new System.Drawing.Point(173, 76);
            this.btnInsertionSort.Name = "btnInsertionSort";
            this.btnInsertionSort.Size = new System.Drawing.Size(146, 52);
            this.btnInsertionSort.TabIndex = 4;
            this.btnInsertionSort.Text = "Insertion Sort";
            this.btnInsertionSort.UseVisualStyleBackColor = true;
            this.btnInsertionSort.Click += new System.EventHandler(this.btnInsertionSort_Click_1);
            // 
            // btnQuickSort
            // 
            this.btnQuickSort.Location = new System.Drawing.Point(21, 76);
            this.btnQuickSort.Name = "btnQuickSort";
            this.btnQuickSort.Size = new System.Drawing.Size(146, 52);
            this.btnQuickSort.TabIndex = 8;
            this.btnQuickSort.Text = "Quick Sort";
            this.btnQuickSort.UseVisualStyleBackColor = true;
            this.btnQuickSort.Click += new System.EventHandler(this.btnQuickSort_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Numero a Buscar:";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(157, 149);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(162, 22);
            this.tbBuscar.TabIndex = 10;
            // 
            // btnBusquedaSecuencial
            // 
            this.btnBusquedaSecuencial.Location = new System.Drawing.Point(24, 199);
            this.btnBusquedaSecuencial.Name = "btnBusquedaSecuencial";
            this.btnBusquedaSecuencial.Size = new System.Drawing.Size(157, 52);
            this.btnBusquedaSecuencial.TabIndex = 11;
            this.btnBusquedaSecuencial.Text = "Busqueda Secuencial";
            this.btnBusquedaSecuencial.UseVisualStyleBackColor = true;
            this.btnBusquedaSecuencial.Click += new System.EventHandler(this.btnBusquedaSecuencial_Click_1);
            // 
            // btnBusquedaBinaria
            // 
            this.btnBusquedaBinaria.Location = new System.Drawing.Point(193, 199);
            this.btnBusquedaBinaria.Name = "btnBusquedaBinaria";
            this.btnBusquedaBinaria.Size = new System.Drawing.Size(157, 52);
            this.btnBusquedaBinaria.TabIndex = 12;
            this.btnBusquedaBinaria.Text = "Busqueda Binaria";
            this.btnBusquedaBinaria.UseVisualStyleBackColor = true;
            this.btnBusquedaBinaria.Click += new System.EventHandler(this.btnBusquedaBinaria_Click_1);
            // 
            // lblDuracion2
            // 
            this.lblDuracion2.AutoSize = true;
            this.lblDuracion2.Location = new System.Drawing.Point(197, 571);
            this.lblDuracion2.Name = "lblDuracion2";
            this.lblDuracion2.Size = new System.Drawing.Size(139, 16);
            this.lblDuracion2.TabIndex = 15;
            this.lblDuracion2.Text = "Duracion: 0 Segundos";
            // 
            // lblTiempoFin2
            // 
            this.lblTiempoFin2.AutoSize = true;
            this.lblTiempoFin2.Location = new System.Drawing.Point(197, 546);
            this.lblTiempoFin2.Name = "lblTiempoFin2";
            this.lblTiempoFin2.Size = new System.Drawing.Size(143, 16);
            this.lblTiempoFin2.TabIndex = 14;
            this.lblTiempoFin2.Text = "Tiempo de fin: 00:00:00";
            // 
            // lblTiempoInicio2
            // 
            this.lblTiempoInicio2.AutoSize = true;
            this.lblTiempoInicio2.Location = new System.Drawing.Point(197, 517);
            this.lblTiempoInicio2.Name = "lblTiempoInicio2";
            this.lblTiempoInicio2.Size = new System.Drawing.Size(161, 16);
            this.lblTiempoInicio2.TabIndex = 13;
            this.lblTiempoInicio2.Text = "Tiempo de inicio: 00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 603);
            this.Controls.Add(this.lblDuracion2);
            this.Controls.Add(this.lblTiempoFin2);
            this.Controls.Add(this.lblTiempoInicio2);
            this.Controls.Add(this.btnBusquedaBinaria);
            this.Controls.Add(this.btnBusquedaSecuencial);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuickSort);
            this.Controls.Add(this.btnInsertionSort);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.tbCantidad);
            this.Controls.Add(this.lblCantidadRegistros);
            this.Controls.Add(this.btnGenerarNumeros);
            this.Controls.Add(this.lblTiempoFin);
            this.Controls.Add(this.lblTiempoInicio);
            this.Controls.Add(this.groupBoxRegistros);
            this.Name = "Form1";
            this.Text = " ";
            this.groupBoxRegistros.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRegistros;
        private System.Windows.Forms.ListBox lstDatos;
        private System.Windows.Forms.Label lblTiempoInicio;
        private System.Windows.Forms.Label lblTiempoFin;
        private System.Windows.Forms.Button btnGenerarNumeros;
        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Button btnInsertionSort;
        private System.Windows.Forms.Button btnQuickSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.Button btnBusquedaSecuencial;
        private System.Windows.Forms.Button btnBusquedaBinaria;
        private System.Windows.Forms.ListBox lstDatos2;
        private System.Windows.Forms.Label lblDuracion2;
        private System.Windows.Forms.Label lblTiempoFin2;
        private System.Windows.Forms.Label lblTiempoInicio2;
    }
}

