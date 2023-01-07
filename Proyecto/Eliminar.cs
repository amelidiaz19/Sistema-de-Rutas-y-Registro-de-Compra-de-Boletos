using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Eliminar : Form
    {
        public string clientes = "";
        public string valor = "";
        public Cola cola;
        public Validacion val = new Validacion();

        public Eliminar(Cola principal, string clientes)
        {
            this.clientes = clientes;
            cola = principal;
            InitializeComponent();

            cola.Mostrar(dataGridView1, dataGridView2);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool flag = true;
            bool flag2 = true;

            try
            {
                if (val.Vacio(txtCodigo.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtCodigo.Text)) { throw new Exception("Solo numeros."); }

                for (int y = 0; y < dataGridView1.Rows.Count; y++)
                {
                    if (txtCodigo.Text == dataGridView1.Rows[y].Cells[0].Value.ToString())
                    {
                        flag2 = false; //si hay
                    }
                }

                if (flag2 == true) { throw new Exception("No existe registro de un Cliente con ese codigo."); }
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show(ex.Message);
            }

            if (flag && flag2 == false)
            {
                int posicion = 0;

                for (int y = 0; y < dataGridView1.Rows.Count; y++)
                {
                    if (txtCodigo.Text == dataGridView1.Rows[y].Cells[0].Value.ToString())
                    {
                        posicion = dataGridView1.Rows[y].Index;
                    }
                }

                cola.EliminarCliente(int.Parse(txtCodigo.Text));
                Eliminar_EnArchivo(clientes, posicion);

                cola.Mostrar(dataGridView1, dataGridView2);
                txtCodigo.Text = String.Empty;
            }
        }

        //Metodo eliminar en archivo
        public void Eliminar_EnArchivo(string rutaguia, int posicion)
        {
            StreamReader leer = new StreamReader(rutaguia);

            int contador = 0;
            string cadena = "";

            while (!leer.EndOfStream)
            {
                string registro = leer.ReadLine();

                if (contador != posicion)
                {

                    cadena += registro + "\r\n";
                }

                contador++;
            }

            leer.Close();
            File.WriteAllText(rutaguia, cadena);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formPrincipal.Show();
        }
    }
}
