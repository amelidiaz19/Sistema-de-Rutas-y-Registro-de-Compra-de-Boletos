using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Comprar_Boleto : Form
    {
        public string ruta = "";
        public string clientes = "";
        Cola colaPrincipal;
        public string origen = "", destino = "";
        public Grafo grafo;

        public string Asiento = "";


        public Comprar_Boleto(Cola principal, string rutaprincipial, Grafo grafo, string clientes)
        {
            colaPrincipal = principal;
            this.grafo = grafo;
            this.clientes = clientes;
            InitializeComponent();
            txtCodigo.Enabled = false;

            ruta = rutaprincipial;
            colaPrincipal.Mostrar(dataGridView1, dataGridView2);

            cbALetra.Enabled = false;
            txtCodigo.Text = colaPrincipal.Codigo.ToString();
            lblAsiento.Text = colaPrincipal.tope.ToString();
        }

        public int inicio = 0;
        public int final = 0;
        public int distancia = 0;
        public int n = 0;
        public int actual = 0;
        public int columna = 0;
        public int[,] tabla;

        public Validacion val = new Validacion();

        private void btnDiagrama_Click(object sender, EventArgs e)
        {
            Diagrama formDiagrama = new Diagrama();
            formDiagrama.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = colaPrincipal.Codigo.ToString();
            Asiento = cbALetra.Text + cbANumero.Text;

            bool existeono = true;
            bool flag = true;
            double pagar = 0;

            errorProvider.SetError(txtDni, "");
            errorProvider.SetError(txtNombre, "");
            errorProvider.SetError(txtApellido, "");
            errorProvider.SetError(cbTipo, "");
            errorProvider.SetError(cbPiso, "");
            errorProvider.SetError(cbALetra, "");
            errorProvider.SetError(cbANumero, "");

            int distancia = 0;

            //try catch comprar ruta si es q existe
            try
            {
                inicio = int.Parse(cbOrigen.Text);
                final = int.Parse(cbDestino.Text);

                tabla = new int[7, 3];

                for (n = 0; n < 7; n++)
                {
                    tabla[n, 0] = 0;
                    tabla[n, 1] = 99; // int.MaxValue;
                    tabla[n, 2] = 0;
                }
                tabla[inicio, 1] = 0;

                //Dijkstra
                actual = inicio;
                do
                {
                    tabla[actual, 0] = 1;
                    for (columna = 0; columna < 7; columna++)
                    {
                        if (grafo.ObtenAdyacencia(actual, columna) != 0)
                        {
                            distancia = grafo.ObtenAdyacencia(actual, columna) + tabla[actual, 1];
                            if (distancia < tabla[columna, 1])
                            {
                                tabla[columna, 1] = distancia;
                                tabla[columna, 2] = actual;
                            }
                        }
                    }

                    int indiceMenor = -1;
                    int distanciaMenor = 99;

                    for (int x = 0; x < 7; x++)
                    {
                        if (tabla[x, 1] < distanciaMenor && tabla[x, 0] == 0)
                        {
                            indiceMenor = x;
                            distanciaMenor = tabla[x, 1];
                        }
                        actual = indiceMenor;
                    }

                } while (actual != -1);

                bool ex = false;
                string ac = "";

                List<int> ruta = new List<int>();
                int nodo = final;

                while (nodo != inicio)
                {
                    ruta.Add(nodo);
                    nodo = tabla[nodo, 2];
                }

                ruta.Add(inicio);
                ruta.Reverse();

                foreach (int posicion in ruta)
                {
                    if (posicion == final)
                    {
                        distancia = tabla[posicion, 1];
                    }

                    ac += posicion + " => ";
                }

                if (distancia > 0 && distancia != 99)
                {
                    ex = true;
                }
                else
                {
                    throw new Exception("No existe");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe una ruta de : "
                                + cbOrigen.Text + " a " + cbDestino.Text + 
                                "\nTe recomiendo ver Rutas Tabla para comprar un pasaje.");
                existeono = false;
            }

            //try catch no repetir asientos comprados
            try
            {
                for (int y = 0; y < dataGridView1.Rows.Count; y++)
                {
                    if (Asiento == dataGridView1.Rows[y].Cells[6].Value.ToString())
                    {
                        throw new Exception("Existe");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Boleto ya comprado, elija otro asiento.");
                existeono = false;
            }

            try
            {
                if (val.Vacio(txtDni.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtDni.Text)) { throw new Exception("Solo numeros."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtDni, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(txtNombre.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloLetras(txtNombre.Text)) { throw new Exception("Solo letras."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtNombre, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(txtApellido.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloLetras(txtApellido.Text)) { throw new Exception("Solo letras."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtApellido, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(cbTipo.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloLetras(cbTipo.Text)) { throw new Exception("Solo letras."); }
            }
            catch (Exception ex) { errorProvider.SetError(cbTipo, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(cbPiso.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(cbPiso.Text)) { throw new Exception("Solo numeros."); }
            }
            catch (Exception ex) { errorProvider.SetError(cbPiso, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(cbALetra.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloLetras(cbALetra.Text)) { throw new Exception("Solo letras."); }
            }
            catch (Exception ex) { errorProvider.SetError(cbALetra, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(cbANumero.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(cbANumero.Text)) { throw new Exception("Solo numeros."); }
            }
            catch (Exception ex) { errorProvider.SetError(cbANumero, ex.Message); flag = false; }


            if (existeono && flag)
            {
                if (distancia == 1)
                {
                    pagar = 10;
                }
                else if (distancia >= 2 && distancia <= 4)
                {
                    pagar = 15;
                }
                else if (distancia >= 5 && distancia <= 6)
                {
                    pagar = 20;
                }
                else if (distancia >= 7 && distancia <= 9)
                {
                    pagar = 25;
                }
                else if (distancia == 10 || distancia >= 10)
                {
                    pagar = 30;
                }

                if (cbPiso.Text == "1")
                {
                    pagar = pagar + 10;
                }
                else if(cbPiso.Text == "2")
                {
                    pagar = pagar + 5;
                }

                colaPrincipal.EncolarDatos(
                                  int.Parse(txtDni.Text),
                                  txtNombre.Text,
                                  txtApellido.Text,
                                  cbTipo.Text,
                                  cbPiso.Text,
                                  Asiento,
                                  pagar,
                                  cbOrigen.Text,
                                  cbDestino.Text);

                //escribir
                StreamWriter escribir = new StreamWriter(clientes, append: true);

                #region Origen_Destino

                if (cbOrigen.Text == "0")
                {
                    origen = "Municipalidad de Los Olivos";
                }
                else if (cbDestino.Text == "0")
                {
                    destino = "Municipalidad de Los Olivos";
                }

                if (cbOrigen.Text == "1")
                {
                    origen = "Mega Plaza";
                }
                else if (cbDestino.Text == "1")
                {
                    destino = "Mega Plaza";
                }

                if (cbOrigen.Text == "2")
                {
                    origen = "Plaza Norte";
                }
                else if (cbDestino.Text == "2")
                {
                    destino = "Plaza Norte";
                }

                if (cbOrigen.Text == "3")
                {
                    origen = "Aeropuerto Jorge Chavez";
                }
                else if (cbDestino.Text == "3")
                {
                    destino = "Aeropuerto Jorge Chavez";
                }

                if (cbOrigen.Text == "4")
                {
                    origen = "Plaza San Miguel";
                }
                else if (cbDestino.Text == "4")
                {
                    destino = "Plaza San Miguel";
                }

                if (cbOrigen.Text == "5")
                {
                    origen = "Av. Brasil";
                }
                else if (cbDestino.Text == "5")
                {
                    destino = "Av. Brasil";
                }

                if (cbOrigen.Text == "6")
                {
                    origen = "Campo de Marte";
                }
                else if (cbDestino.Text == "6")
                {
                    destino = "Campo de Marte";
                }

                #endregion

                escribir.WriteLine(txtCodigo.Text + "|" +
                                   txtDni.Text + "|" +
                                   txtNombre.Text + "|" +
                                   txtApellido.Text + "|" +
                                   cbTipo.Text + "|" +
                                   cbPiso.Text + "|" +
                                   Asiento + "|" +
                                   pagar.ToString() + "|" +

                                   origen + "|" +
                                   destino);
                escribir.Close();

                colaPrincipal.Mostrar(dataGridView1, dataGridView2);
                txtCodigo.Text = colaPrincipal.Codigo.ToString();

                txtDni.Text = String.Empty;
                txtNombre.Text = String.Empty;
                txtApellido.Text = String.Empty;
                cbTipo.Text = String.Empty;
                cbPiso.Text = String.Empty;
                cbALetra.Text = String.Empty;
                cbANumero.Text = String.Empty;
                cbOrigen.Text = String.Empty;
                cbDestino.Text = String.Empty;
            }
        }

        private void cbPiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cbPiso.SelectedIndex;

            if (indice.ToString() == "0")
            {
                cbALetra.Items.Clear();
                cbALetra.Text = String.Empty;
                cbANumero.Text = String.Empty;

                cbALetra.Items.Add("A");
                cbALetra.Items.Add("B");
                cbALetra.Items.Add("C");
                cbALetra.Items.Add("D");
                cbALetra.Items.Add("E");
                cbALetra.Items.Add("F");

                cbALetra.Enabled = true;
            }
            else if (indice.ToString() == "1")
            {
                cbALetra.Items.Clear();
                cbALetra.Text = String.Empty;
                cbANumero.Text = String.Empty;

                cbALetra.Items.Add("G");
                cbALetra.Items.Add("H");
                cbALetra.Items.Add("I");
                cbALetra.Items.Add("J");
                cbALetra.Items.Add("K");
                cbALetra.Items.Add("L");

                cbALetra.Enabled = true;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formPrincipal.Show();
        }

        private void cbALetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbANumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
