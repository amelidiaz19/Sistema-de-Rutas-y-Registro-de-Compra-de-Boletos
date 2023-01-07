namespace Proyecto
{
    partial class RutaCorta
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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBuscarDestino = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscarOrigen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richRutaCorta = new System.Windows.Forms.RichTextBox();
            this.txtDijkstra = new System.Windows.Forms.TextBox();
            this.btnRutaCorta = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Items.AddRange(new object[] {
            "[0] Municipalidad de Los Olivos [1] Mega Plaza           [2] Plaza Norte",
            "[3] Aeropuerto Jorge Chavez     [4] Plaza San Miguel     [5] Av. Brasil",
            "[6] Campo de Marte"});
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(821, 73);
            this.listBox1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBuscarDestino);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.txtBuscarOrigen);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.richRutaCorta);
            this.groupBox2.Location = new System.Drawing.Point(13, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(821, 399);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ruta más corta";
            // 
            // txtBuscarDestino
            // 
            this.txtBuscarDestino.Location = new System.Drawing.Point(636, 151);
            this.txtBuscarDestino.Multiline = true;
            this.txtBuscarDestino.Name = "txtBuscarDestino";
            this.txtBuscarDestino.Size = new System.Drawing.Size(111, 32);
            this.txtBuscarDestino.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(543, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Destino";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(547, 231);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(200, 32);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar Ruta";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscarOrigen
            // 
            this.txtBuscarOrigen.Location = new System.Drawing.Point(636, 83);
            this.txtBuscarOrigen.Multiline = true;
            this.txtBuscarOrigen.Name = "txtBuscarOrigen";
            this.txtBuscarOrigen.Size = new System.Drawing.Size(111, 32);
            this.txtBuscarOrigen.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(543, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = "Origen";
            // 
            // richRutaCorta
            // 
            this.richRutaCorta.Location = new System.Drawing.Point(38, 41);
            this.richRutaCorta.Name = "richRutaCorta";
            this.richRutaCorta.Size = new System.Drawing.Size(451, 340);
            this.richRutaCorta.TabIndex = 0;
            this.richRutaCorta.Text = "";
            // 
            // txtDijkstra
            // 
            this.txtDijkstra.Location = new System.Drawing.Point(51, 546);
            this.txtDijkstra.Multiline = true;
            this.txtDijkstra.Name = "txtDijkstra";
            this.txtDijkstra.Size = new System.Drawing.Size(451, 32);
            this.txtDijkstra.TabIndex = 13;
            // 
            // btnRutaCorta
            // 
            this.btnRutaCorta.Location = new System.Drawing.Point(51, 498);
            this.btnRutaCorta.Name = "btnRutaCorta";
            this.btnRutaCorta.Size = new System.Drawing.Size(451, 32);
            this.btnRutaCorta.TabIndex = 12;
            this.btnRutaCorta.Text = "Mostrar Ruta más corta";
            this.btnRutaCorta.UseVisualStyleBackColor = true;
            this.btnRutaCorta.Click += new System.EventHandler(this.btnRutaCorta_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(630, 532);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(204, 46);
            this.btnRegresar.TabIndex = 13;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RutaCorta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 587);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.txtDijkstra);
            this.Controls.Add(this.btnRutaCorta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RutaCorta";
            this.Text = "RutaCorta";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBuscarDestino;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBuscarOrigen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richRutaCorta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDijkstra;
        private System.Windows.Forms.Button btnRutaCorta;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}