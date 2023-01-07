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
    public partial class Buscar : Form
    {
        public string clientes = "";
        public Cola cola;
        public Validacion val = new Validacion();

        public Buscar(Cola principal, string clientes)
        {
            this.clientes = clientes;
            cola = principal;
            InitializeComponent();
            DatosCargados(clientes);
        }

        public void DatosCargados(string rutaclientes)
        {
            if (File.Exists(rutaclientes))
            {
                string[] datos = new string[9];
                string registro = "";

                StreamReader leer = File.OpenText(rutaclientes);

                while (!leer.EndOfStream)
                {
                    registro = leer.ReadLine();
                    datos = registro.Split('|');

                    dataGridView1.Rows.Add(int.Parse(datos[0].Trim()),
                        int.Parse(datos[1].Trim()),
                        datos[2].Trim(),
                        datos[3].Trim(),
                        datos[4].Trim(),
                        datos[5].Trim(),
                        datos[6].Trim(),
                        double.Parse(datos[7].Trim()));

                    dataGridView2.Rows.Add(datos[8].Trim(),
                        datos[9].Trim());
                }

                leer.Close();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formPrincipal.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
                cola.Buscar(int.Parse(txtCodigo.Text), dataGridView1, dataGridView2);
                txtCodigo.Text = String.Empty;
            }
        }

        private void btnCola_Click(object sender, EventArgs e)
        {
            cola.Mostrar(dataGridView1, dataGridView2);
        }
    }
}
