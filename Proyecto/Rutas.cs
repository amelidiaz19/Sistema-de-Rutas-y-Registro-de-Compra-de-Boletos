using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Rutas : Form
    {
        string ruta = "";

        public Rutas(string rutaprincipal)
        {
            InitializeComponent();
            ruta = rutaprincipal;
            DatosRegistrados();
        }

        public void DatosRegistrados()
        {
            if (File.Exists(ruta))
            {

                string[] datos = new string[2];
                string registro = "";

                string[] n_datos = new string[2];
                string registro2 = "";

                StreamReader leer = File.OpenText(ruta);
                StreamReader leer2 = File.OpenText(ruta);

                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

                while (!leer.EndOfStream && !leer2.EndOfStream)
                {
                    registro = leer.ReadLine();
                    datos = registro.Split('|');

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

                    dataGridView1.Rows.Add(datos[0].Trim(),
                                           datos[1].Trim(),
                                           datos[2].Trim() + " km");

                    dataGridView2.Rows.Add(n_datos[0].Trim(),
                                           n_datos[1].Trim(),
                                           n_datos[2].Trim() + " km");
                }

                leer.Close();
            }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Program.formPrincipal.Show();
        }
    }
}
