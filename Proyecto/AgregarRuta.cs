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
    public partial class AgregarRuta : Form
    {
        Grafo grafo;
        public string rutas = "";
        Validacion val = new Validacion();

        public AgregarRuta(Grafo grafo, string rutas)
        {
            InitializeComponent();
            this.grafo = grafo;
            this.rutas = rutas;
        }

        public void DatosRegistrados()
        {
            if (File.Exists(rutas))
            {
                string[] n_datos = new string[2];
                string registro2 = "";

                StreamReader leer = File.OpenText(rutas);
                StreamReader leer2 = File.OpenText(rutas);

                dataGridView1.Rows.Clear();

                while (!leer.EndOfStream && !leer2.EndOfStream)
                {
                    registro2 = leer2.ReadLine();
                    n_datos = registro2.Split('|');

                    if (n_datos[0].Trim() == "0")
                    {
                        n_datos[0] = "Municipalidad de Los Olivos";
                    }
                    else if (n_datos[1].Trim() == "0")
                    {
                        n_datos[1] = "Municipalidad de Los Olivos";
                    }

                    if (n_datos[0].Trim() == "1")
                    {
                        n_datos[0] = "Mega Plaza";
                    }
                    else if (n_datos[1].Trim() == "1")
                    {
                        n_datos[1] = "Mega Plaza";
                    }

                    if (n_datos[0].Trim() == "2")
                    {
                        n_datos[0] = "Plaza Norte";
                    }
                    else if (n_datos[1].Trim() == "2")
                    {
                        n_datos[1] = "Plaza Norte";
                    }

                    if (n_datos[0].Trim() == "3")
                    {
                        n_datos[0] = "Aeropuerto Jorge Chavez";
                    }
                    else if (n_datos[1].Trim() == "3")
                    {
                        n_datos[1] = "Aeropuerto Jorge Chavez";
                    }

                    if (n_datos[0].Trim() == "4")
                    {
                        n_datos[0] = "Plaza San Miguel";
                    }
                    else if (n_datos[1].Trim() == "4")
                    {
                        n_datos[1] = "Plaza San Miguel";
                    }

                    if (n_datos[0].Trim() == "5")
                    {
                        n_datos[0] = "Av. Brasil";
                    }
                    else if (n_datos[1].Trim() == "5")
                    {
                        n_datos[1] = "Av. Brasil";
                    }

                    if (n_datos[0].Trim() == "6")
                    {
                        n_datos[0] = "Campo de Marte";
                    }
                    else if (n_datos[1].Trim() == "6")
                    {
                        n_datos[1] = "Campo de Marte";
                    }

                    dataGridView1.Rows.Add(n_datos[0].Trim(),
                                           n_datos[1].Trim(),
                                           n_datos[2].Trim() + " km");
                }

                leer.Close();
                leer2.Close();
            }
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            bool flag = true;

            errorProvider.SetError(txtOrigen, "");
            errorProvider.SetError(txtDestino, "");
            errorProvider.SetError(txtDistancia, "");

            try
            {
                if (val.Vacio(txtOrigen.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtOrigen.Text)) { throw new Exception("Solo numeros."); }
                if (val.Rango(txtOrigen.Text)) { throw new Exception("Solo numeros de 0 a 6."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtOrigen, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(txtDestino.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtDestino.Text)) { throw new Exception("Solo numeros."); }
                if (val.Rango(txtDestino.Text)) { throw new Exception("Solo numeros de 0 a 6."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtDestino, ex.Message); flag = false; }

            try
            {
                if (val.Vacio(txtDistancia.Text)) { throw new Exception("No puede estar vacio."); }
                if (val.SoloNumeros(txtDistancia.Text)) { throw new Exception("Solo numeros."); }
            }
            catch (Exception ex) { errorProvider.SetError(txtDistancia, ex.Message); flag = false; }

            if (flag)
            {
                int Origen = int.Parse(txtOrigen.Text);
                int Destino = int.Parse(txtDestino.Text);
                int Dis = int.Parse(txtDistancia.Text);

                string dO = "", dD = "";

                grafo.AdicionarArista(Origen, Destino, Dis);

                #region OrigenDestino

                if (Origen == 0)
                {
                    dO = "Municipalidad de Los Olivos";
                }
                else if (Destino == 0)
                {
                    dD = "Municipalidad de Los Olivos";
                }

                if (Origen == 1)
                {
                    dO = "Mega Plaza";
                }
                else if (Destino == 1)
                {
                    dD = "Mega Plaza";
                }

                if (Origen == 2)
                {
                    dO = "Plaza Norte";
                }
                else if (Destino == 2)
                {
                    dD = "Plaza Norte";
                }

                if (Origen == 3)
                {
                    dO = "Aeropuerto Jorge Chavez";
                }
                else if (Destino == 3)
                {
                    dD = "Aeropuerto Jorge Chavez";
                }

                if (Origen == 4)
                {
                    dO = "Plaza San Miguel";
                }
                else if (Destino == 4)
                {
                    dD = "Plaza San Miguel";
                }

                if (Origen == 5)
                {
                    dO = "Av. Brasil";
                }
                else if (Destino == 5)
                {
                    dD = "Av. Brasil";
                }

                if (Origen == 6)
                {
                    dO = "Campo de Marte";
                }
                else if (Destino == 6)
                {
                    dD = "Campo de Marte";
                }

                #endregion

                dataGridView1.Rows.Add(dO, dD, Dis + " km");

                try
                {
                    if (File.Exists(rutas))
                    {
                        StreamWriter escribir = new StreamWriter(rutas, append: true);

                        escribir.WriteLine(Origen + "|" + Destino + "|" + Dis);
                        escribir.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el registro: " + ex.Message);
                }

                txtOrigen.Text = String.Empty;
                txtDestino.Text = String.Empty;
                txtDistancia.Text = String.Empty;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formPrincipal.Show();
        }
    }
}
