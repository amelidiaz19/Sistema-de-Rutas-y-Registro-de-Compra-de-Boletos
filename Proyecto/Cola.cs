using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto
{
    public class Cola
    {
        private Nodo primero = new Nodo();
        private Nodo ultimo = new Nodo();

        public int tope=0, limite=0;
        public int Codigo = 100;

        public Cola(int Limite)
        {
            primero = ultimo = null;
            tope = 0;
            limite = Limite;
        }

        public bool estaVacia()
        {
            return tope == 0;
        }

        public bool estaLlena()
        {
            return tope == limite;
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

                    EncolarDatos(
                        int.Parse(datos[1].Trim()),
                        datos[2].Trim(),
                        datos[3].Trim(),
                        datos[4].Trim(),
                        datos[5].Trim(),
                        datos[6].Trim(),
                        double.Parse(datos[7].Trim()),
                        datos[8].Trim(),
                        datos[9].Trim());
                }

                leer.Close();
            }
        }

        public void EncolarDatos(int dni, string nombre, string apellido, string tipo, string piso, string asiento, double pagar, string origen, string destino)
        {
            bool existeono = true;

            if (!estaLlena())
            {
                Nodo nuevo = new Nodo();

                if (existeono == true)
                {
                    #region Origen_Destino

                    if (origen == "0")
                    {
                        origen = "Municipalidad de Los Olivos";
                    }
                    else if (destino == "0")
                    {
                        destino = "Municipalidad de Los Olivos";
                    }

                    if (origen == "1")
                    {
                        origen = "Mega Plaza";
                    }
                    else if (destino == "1")
                    {
                        destino = "Mega Plaza";
                    }

                    if (origen == "2")
                    {
                        origen = "Plaza Norte";
                    }
                    else if (destino == "2")
                    {
                        destino = "Plaza Norte";
                    }

                    if (origen == "3")
                    {
                        origen = "Aeropuerto Jorge Chavez";
                    }
                    else if (destino == "3")
                    {
                        destino = "Aeropuerto Jorge Chavez";
                    }

                    if (origen == "4")
                    {
                        origen = "Plaza San Miguel";
                    }
                    else if (destino == "4")
                    {
                        destino = "Plaza San Miguel";
                    }

                    if (origen == "5")
                    {
                        origen = "Av. Brasil";
                    }
                    else if (destino == "5")
                    {
                        destino = "Av. Brasil";
                    }

                    if (origen == "6")
                    {
                        origen = "Campo de Marte";
                    }
                    else if (destino == "6")
                    {
                        destino = "Campo de Marte";
                    }

                    #endregion

                    nuevo.Codigo_pasaje = Codigo;
                    nuevo.Dni = dni;
                    nuevo.Nombre = nombre;
                    nuevo.Apellido = apellido;
                    nuevo.Tipo = tipo;
                    nuevo.Piso = piso;
                    nuevo.Asiento = asiento;
                    nuevo.Total_pagar = pagar;

                    nuevo.Origen = origen;
                    nuevo.Destino = destino;

                    if (primero == null)
                    {
                        primero = nuevo;
                        primero.Siguiente = null;
                        ultimo = nuevo;
                    }
                    else
                    {
                        ultimo.Siguiente = nuevo;
                        nuevo.Siguiente = null;
                        ultimo = nuevo;
                    }

                    Codigo++;
                    tope++;
                }
            }
            else
            {
                MessageBox.Show("Cola llena.");
            }
        }       

        public void Mostrar(DataGridView dgv, DataGridView dgv2)
        {
            if (!estaVacia())
            {
                Nodo actual = new Nodo();

                actual = primero;
                dgv.Rows.Clear();
                dgv2.Rows.Clear();

                if (primero != null)
                {
                    while (actual != null)
                    {
                        dgv.Rows.Add(
                        actual.Codigo_pasaje,
                        actual.Dni,
                        actual.Nombre,
                        actual.Apellido,
                        actual.Tipo,
                        actual.Piso,
                        actual.Asiento,
                        actual.Total_pagar);

                        dgv2.Rows.Add(actual.Origen, actual.Destino);

                        actual = actual.Siguiente;
                    }
                }
            }
            else
            {
                MessageBox.Show("Cola vacia.");
            }
        }

        public void Buscar(int codigo, DataGridView dgv, DataGridView dgv2)
        {
            Nodo actual = new Nodo();
            actual = primero;
            bool encontrado = false;
            int nodoBuscado = codigo;

            dgv.Rows.Clear();
            dgv2.Rows.Clear();

            if (primero != null)
            {
                while (actual != null && encontrado != true)
                {
                    if (actual.Codigo_pasaje == nodoBuscado)
                    {
                        MessageBox.Show("Codigo del Cliente: " + nodoBuscado + " encontrado.");

                        dgv.Rows.Add(actual.Codigo_pasaje, actual.Dni, actual.Nombre, actual.Apellido,
                                     actual.Tipo, actual.Piso, actual.Asiento, actual.Total_pagar);

                        dgv2.Rows.Add(actual.Origen, actual.Destino);

                        encontrado = true;
                    }
                    actual = actual.Siguiente;
                }
                if (!encontrado)
                {
                    MessageBox.Show("Codigo del Cliente: " + nodoBuscado + " no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Cola Vacia.");
            }
        }

        public void ModificarTipo(int buscar_codigo, string clientes)
        {
            Nodo actual = new Nodo();
            actual = primero;
            bool encontrado = false;

            int nodoBuscado = buscar_codigo;
            string modificar_tipo = "Pagado";

            if (primero != null)
            {
                while (actual != null && encontrado != true)
                {
                    if (actual.Codigo_pasaje == nodoBuscado)
                    {
                        actual.Tipo = modificar_tipo;

                        MessageBox.Show("Recibo Pagado.");

                        encontrado = true;

                    }
;
                    actual = actual.Siguiente;
                }

                if (!encontrado)
                {
                    MessageBox.Show("Codigo del Cliente: " + nodoBuscado + " no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Cola Vacia.");
            }
        }

        public void EliminarCliente(int c_pasaje)
        {
            Nodo actual = new Nodo();
            actual = primero;
            Nodo anterior = new Nodo();
            anterior = null;
            bool encontrado = false;

            int nodoBuscado = c_pasaje;

            if (primero != null)
            {
                while (actual != null && encontrado != true)
                {
                    if (actual.Codigo_pasaje == nodoBuscado)
                    {
                        if (actual == primero)
                        {
                            primero = primero.Siguiente;
                        }
                        else if (actual == ultimo)
                        {
                            anterior.Siguiente = null;
                            ultimo = anterior;
                        }
                        else
                        {
                            anterior.Siguiente = actual.Siguiente;
                        }

                        MessageBox.Show("Codigo del Cliente: " + nodoBuscado + " eliminado.");
                        encontrado = true;
                    }
                    anterior = actual;
                    actual = actual.Siguiente;
                }

                if (encontrado == true)
                {
                   tope--;
                }

                if (!encontrado)
                {
                    MessageBox.Show("Codigo del Cliente: " + nodoBuscado + " no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Cola Vacia.");
            }
        }
    }
}
