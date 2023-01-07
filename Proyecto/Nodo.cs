using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Nodo
    {
        private int codigo_pasaje;
        private int dni;
        private string nombre;
        private string apellido;
        private string tipo; //pendiente - pago
        private string piso; //asiento primer / segundo piso
        private string asiento; // A-G | 1 - 4

        private string origen;
        private string destino;

        private double total_pagar; // de acuerdo al piso
        private Nodo siguiente;

        public int Codigo_pasaje
        {
            get { return codigo_pasaje; }
            set { codigo_pasaje = value; }
        }

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Piso
        {
            get { return piso; }
            set { piso = value; }
        }

        public string Asiento
        {
            get { return asiento; }
            set { asiento = value; }
        }

        public string Origen
        {
            get { return origen; }
            set { origen = value; }
        }

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public double Total_pagar
        {
            get { return total_pagar; }
            set { total_pagar = value; }
        }

        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
    }
}
