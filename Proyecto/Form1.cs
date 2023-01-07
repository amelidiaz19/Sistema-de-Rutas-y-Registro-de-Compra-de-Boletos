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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            grafo.AsignarRuta(rutas);
            colaPrincipal.DatosCargados(clientes);
        }

        Grafo grafo = new Grafo(7);
        Cola colaPrincipal = new Cola(48);

        public string rutas = "Rutas.txt";
        public string clientes = "Clientes.txt";
        private void btnRuta_Click(object sender, EventArgs e)
        {
            AgregarRuta formAñadirRuta = new AgregarRuta(grafo, rutas);
            formAñadirRuta.Show();
            formAñadirRuta.DatosRegistrados();
        }

        private void btnMostrarAdyacencia_Click(object sender, EventArgs e)
        {
            Adyacencia formAdyacencia = new Adyacencia(grafo);
            formAdyacencia.Show();
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            Rutas formRutas = new Rutas(rutas);
            formRutas.Show();
        }

        private void btnRutaMasCorta_Click(object sender, EventArgs e)
        {
            RutaCorta formCorta = new RutaCorta(grafo);
            formCorta.Show();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Comprar_Boleto formBoleto = new Comprar_Boleto(colaPrincipal, rutas, grafo, clientes);
            formBoleto.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar formBuscar = new Buscar(colaPrincipal, clientes);
            formBuscar.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar formModificar = new Modificar(colaPrincipal,clientes);
            formModificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar formEliminar = new Eliminar(colaPrincipal, clientes);
            formEliminar.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
