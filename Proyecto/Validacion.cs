using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public class Validacion
    {
        public bool Vacio(string valor)
        {
            if (valor == "" || valor == null || valor.Trim().Length == 0)
            {
                return true;
            }
            return false;
        }

        public bool SoloLetras(string valor)
        {
            foreach (var c in valor)
            {
                if (!Char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SoloNumeros(string valor)
        {
            foreach (char c in valor)
            {
                if (Char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Rango(string valor)
        {
            if(float.Parse(valor)>= 0 && float.Parse(valor)<= 6)
            {
                return false;
            }
            return true;
        }
    }
}
