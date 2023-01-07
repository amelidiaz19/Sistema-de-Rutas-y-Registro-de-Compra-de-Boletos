using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public class Grafo
    {
        int[,] mAdyacencia;
        int nodos;
        public Grafo(int Nodos)
        {
            nodos = Nodos;
            mAdyacencia = new int[nodos, nodos];
        }

        public void AdicionarArista(int Origen, int Destino, int Distancia)
        {
            mAdyacencia[Origen, Destino] = Distancia;
        }

        public void MostrarAdyacencia(RichTextBox txtAdy)
        {
            for (int n = 0; n < nodos; n++)
                txtAdy.Text += "\t" + n;

            txtAdy.Text += "\n";

            for (int n = 0; n < nodos; n++)
            {
                txtAdy.Text += n + "\t";
                for (int m = 0; m < nodos; m++)
                {
                    txtAdy.Text += mAdyacencia[n, m] + "\t";
                }
                txtAdy.Text += "\n";
            }

        }

        public int ObtenAdyacencia(int Fila, int Columna)
        {
            return mAdyacencia[Fila, Columna];
        }

        public void AsignarRuta(string rutas)
        {
            try
            {
                StreamReader leer = new StreamReader(rutas);

                while (!leer.EndOfStream)
                {
                    string linea = leer.ReadLine();
                    if (linea != null)
                    {
                        string[] campos = linea.Split('|');
                        AdicionarArista(
                            int.Parse(campos[0]),
                            int.Parse(campos[1]),
                            int.Parse(campos[2]));
                    }
                }
                leer.Close();
            }
            catch (Exception) { }
        }
    }
}
