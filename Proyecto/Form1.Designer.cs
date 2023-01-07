namespace Proyecto
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRuta = new System.Windows.Forms.Button();
            this.btnMostrarAdyacencia = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnRutaMasCorta = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRuta
            // 
            this.btnRuta.Location = new System.Drawing.Point(17, 13);
            this.btnRuta.Margin = new System.Windows.Forms.Padding(4);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(249, 44);
            this.btnRuta.TabIndex = 0;
            this.btnRuta.Text = "Agregar Ruta";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // btnMostrarAdyacencia
            // 
            this.btnMostrarAdyacencia.Location = new System.Drawing.Point(17, 118);
            this.btnMostrarAdyacencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnMostrarAdyacencia.Name = "btnMostrarAdyacencia";
            this.btnMostrarAdyacencia.Size = new System.Drawing.Size(249, 44);
            this.btnMostrarAdyacencia.TabIndex = 4;
            this.btnMostrarAdyacencia.Text = "Mostrar Adyacencia";
            this.btnMostrarAdyacencia.UseVisualStyleBackColor = true;
            this.btnMostrarAdyacencia.Click += new System.EventHandler(this.btnMostrarAdyacencia_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(200, 253);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(190, 44);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRutas
            // 
            this.btnRutas.Location = new System.Drawing.Point(17, 65);
            this.btnRutas.Margin = new System.Windows.Forms.Padding(4);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(249, 44);
            this.btnRutas.TabIndex = 11;
            this.btnRutas.Text = "Ver Rutas Tabla";
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // btnRutaMasCorta
            // 
            this.btnRutaMasCorta.Location = new System.Drawing.Point(17, 170);
            this.btnRutaMasCorta.Margin = new System.Windows.Forms.Padding(4);
            this.btnRutaMasCorta.Name = "btnRutaMasCorta";
            this.btnRutaMasCorta.Size = new System.Drawing.Size(249, 44);
            this.btnRutaMasCorta.TabIndex = 12;
            this.btnRutaMasCorta.Text = "Ruta más corta";
            this.btnRutaMasCorta.UseVisualStyleBackColor = true;
            this.btnRutaMasCorta.Click += new System.EventHandler(this.btnRutaMasCorta_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(320, 13);
            this.btnComprar.Margin = new System.Windows.Forms.Padding(4);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(249, 44);
            this.btnComprar.TabIndex = 13;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(320, 65);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(249, 44);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar Cliente";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(320, 118);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(249, 44);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar Pago";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(320, 170);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(249, 44);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 324);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.btnRutaMasCorta);
            this.Controls.Add(this.btnRutas);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.btnMostrarAdyacencia);
            this.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.Button btnMostrarAdyacencia;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnRutas;
        private System.Windows.Forms.Button btnRutaMasCorta;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
    }
}

