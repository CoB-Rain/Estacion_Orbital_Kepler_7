using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public class CurarComando : IComando
    {
        private readonly Unidad _objetivo;
        private readonly int _cantidad;
        private int _curado;

        public CurarComando(Unidad objetivo, int cantidad)
        {
            _objetivo = objetivo;
            _cantidad = cantidad;
        }

        public string Descripcion => $"{_objetivo.Nombre} recupera {_curado} de vida";

        public void Deshacer()
        {
            _objetivo.RecibirDanio(_curado);
        }

        public bool Ejecutar()
        {
            _curado = _objetivo.Curar(_cantidad);
            return _curado > 0;
        }
    }
}
