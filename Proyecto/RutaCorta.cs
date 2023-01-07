using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto
{
    public partial class RutaCorta : Form
    {
        public RutaCorta(Grafo grafo)
        {
            InitializeComponent();
            this.grafo = grafo;
            btnRutaCorta.Enabled = false;
            txtDijkstra.Enabled = false;
            richRutaCorta.Enabled = false;
        }

        public Grafo grafo;
        public Validacion val = new Validacion();

        public int inicio = 0;
        public int final = 0;
        public int distancia = 0;
        public int n = 0;
        public int actual = 0;
        public int columna = 0;
        public int[,] tabla;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool flag = true;

            errorProvider.SetError(txtBuscarOrigen, "");
            errorProvider.SetError(txtBuscarDestino, "");

            try
            {
                if (val.Vacio(txtBuscarOrigen.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtBuscarOrigen.Text)) { throw new Exception("Solo numeros."); }
                if (val.Rango(txtBuscarOrigen.Text)) { throw new Exception("Solo numeros de 0 a 6."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtBuscarOrigen, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(txtBuscarDestino.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtBuscarDestino.Text)) { throw new Exception("Solo numeros."); }
                if (val.Rango(txtBuscarDestino.Text)) { throw new Exception("Solo numeros de 0 a 6."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtBuscarDestino, ex.Message); flag = false; }

            try
            {
                richRutaCorta.Clear();

                inicio = int.Parse(txtBuscarOrigen.Text);
                final = int.Parse(txtBuscarDestino.Text);

                tabla = new int[7, 3];

                for (n = 0; n < 7; n++)
                {
                    tabla[n, 0] = 0;
                    tabla[n, 1] = 99; // int.MaxValue;
                    tabla[n, 2] = 0;
                }
                tabla[inicio, 1] = 0;

                MostrarTabla(tabla);

                //Dijkstra
                richRutaCorta.Text += "\nDistancias después de Dijkstra\n";
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

                MostrarTabla(tabla);

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

                int distanciaa = 0;

                foreach (int posicion in ruta)
                {
                    if (posicion == final)
                    {
                        distanciaa = tabla[posicion, 1];
                    }

                    ac += posicion + " => ";
                }

                if (distanciaa > 0 && distanciaa != 99)
                {
                    ex = true;
                }
                else
                {
                    throw new Exception("No existe ruta de Origen:" + txtBuscarDestino.Text + " a " + txtBuscarDestino.Text);
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); flag = false; }

            if (flag)
            {
                richRutaCorta.Clear();

                inicio = int.Parse(txtBuscarOrigen.Text);
                final = int.Parse(txtBuscarDestino.Text);

                tabla = new int[7, 3];

                for (n = 0; n < 7; n++)
                {
                    tabla[n, 0] = 0;
                    tabla[n, 1] = 99; // int.MaxValue;
                    tabla[n, 2] = 0;
                }
                tabla[inicio, 1] = 0;

                MostrarTabla(tabla);

                //Dijkstra
                richRutaCorta.Text += "\nDistancias después de Dijkstra\n";
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

                MostrarTabla(tabla);

                btnRutaCorta.Enabled = true;
                txtBuscarOrigen.Text = String.Empty;
                txtBuscarDestino.Text = String.Empty;
            }
        }

        private void btnRutaCorta_Click(object sender, EventArgs e)
        {
            try
            {
                bool ex = false;
                txtDijkstra.Clear();

                List<int> ruta = new List<int>();
                int nodo = final;

                while (nodo != inicio)
                {
                    ruta.Add(nodo);
                    nodo = tabla[nodo, 2];
                }

                ruta.Add(inicio);
                ruta.Reverse();

                int distancia = 0;

                foreach (int posicion in ruta)
                {
                    if (posicion == final)
                    {
                        distancia = tabla[posicion, 1];
                    }

                    txtDijkstra.Text += posicion + " => ";
                }

                if (distancia != 0)
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
                MessageBox.Show("No existe ruta de: " +
                                txtBuscarOrigen.Text + " a " + txtBuscarDestino.Text);
            }
        }

        private void MostrarTabla(int[,] pTabla)
        {
            int n = 0;

            for (n = 0; n < pTabla.GetLength(0); n++)
            {
                richRutaCorta.Text += n + "=> \t" + pTabla[n, 0] +
                    "\t" + pTabla[n, 1] + "\t" + pTabla[n, 2] + "\n";
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formPrincipal.Show();
        }
    }
}
