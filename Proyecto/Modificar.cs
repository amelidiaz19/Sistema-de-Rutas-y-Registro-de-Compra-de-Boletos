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
using static System.Collections.Specialized.BitVector32;

namespace Proyecto
{
    public partial class Modificar : Form
    {

        public string clientes = "";
        public string valor = "";
        public Cola cola;
        public Validacion val = new Validacion();

        public Modificar(Cola principal, string clientes)
        {
            this.clientes = clientes;
            cola = principal;
            InitializeComponent();

            cola.Mostrar(dataGridView1, dataGridView2);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool flag = true;
            bool flag2 = true;

            try
            {
                if (val.Vacio(txtCodigo.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtCodigo.Text)){ throw new Exception("Solo numeros.");}

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
                        txtTipo.Text = "Pagado";
                    }
                }

                string codigo = dataGridView1.Rows[posicion].Cells[0].Value.ToString();
                string dni = dataGridView1.Rows[posicion].Cells[1].Value.ToString();
                string nombre = dataGridView1.Rows[posicion].Cells[2].Value.ToString();
                string apellido = dataGridView1.Rows[posicion].Cells[3].Value.ToString();
                string tipo = dataGridView1.Rows[posicion].Cells[4].Value.ToString();
                string piso = dataGridView1.Rows[posicion].Cells[5].Value.ToString();
                string asiento = dataGridView1.Rows[posicion].Cells[6].Value.ToString();
                string total = dataGridView1.Rows[posicion].Cells[7].Value.ToString();

                string origen = dataGridView2.Rows[posicion].Cells[0].Value.ToString();
                string destino = dataGridView2.Rows[posicion].Cells[1].Value.ToString();

                EditarTXT(codigo + "|" +
                          dni + "|" +
                          nombre + "|" +
                          apellido + "|" +
                          tipo + "|" +
                          piso + "|" +
                          asiento + "|" +
                          total + "|" +

                          origen + "|" +
                          destino
                          ,
                          codigo + "|" +
                          dni + "|" +
                          nombre + "|" +
                          apellido + "|" +
                          txtTipo.Text + "|" +
                          piso + "|" +
                          asiento + "|" +
                          total + "|" +
                          origen + "|" +
                          destino);

                cola.ModificarTipo(int.Parse(txtCodigo.Text), clientes);
                cola.Mostrar(dataGridView1, dataGridView2);

                txtTipo.Text = String.Empty;
                txtCodigo.Text = String.Empty;
            }
        }

        //Metodo modificar
        public void EditarTXT(string Anterior, string Nuevo)
        {
            StreamReader sr = new StreamReader(clientes);
            string txt = "";
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (!line.Equals(Anterior))
                {
                    txt += line + "\r\n";
                }
                else
                {
                    txt += Nuevo + "\r\n";
                }
            }
            sr.Close();
            File.WriteAllText(clientes, txt);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formPrincipal.Show();
        }
    }
}
