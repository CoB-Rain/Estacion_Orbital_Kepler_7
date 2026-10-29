using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public class Estacion
    {
        public int Creditos
        {
            get; private set;
        }

        public List<string> Modulos
        {
            get;
        } = new List<string>();

        public Estacion(int creditos)
        {
            Creditos = creditos;
        }

        public bool ConstruirModulos(string nombre, int costo)
        {
            if (Creditos < costo)
                return false;

            Creditos -= costo;

            Modulos.Add(nombre);

            return true;
        }

        public void DemolerModulo(string nombre, int reintegro)
        {
            Modulos.Remove(nombre);
            Creditos += reintegro;
        }
    }
}
