namespace Proyecto
{
    partial class Adyacencia
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
            this.richAdyacencia = new System.Windows.Forms.RichTextBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richAdyacencia
            // 
            this.richAdyacencia.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richAdyacencia.Location = new System.Drawing.Point(16, 17);
            this.richAdyacencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richAdyacencia.Name = "richAdyacencia";
            this.richAdyacencia.Size = new System.Drawing.Size(416, 259);
            this.richAdyacencia.TabIndex = 6;
            this.richAdyacencia.Text = "";
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(228, 284);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(204, 46);
            this.btnRegresar.TabIndex = 13;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // Adyacencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 338);
            this.ControlBox = false;
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.richAdyacencia);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Adyacencia";
            this.Text = "Adyacencia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richAdyacencia;
        private System.Windows.Forms.Button btnRegresar;
    }
}