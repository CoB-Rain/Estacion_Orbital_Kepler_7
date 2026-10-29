using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public class ConstruirComando : IComando
    {
        private readonly Estacion _estacion;

        private readonly string _modulo;
        private readonly int _costo;

        public ConstruirComando(Estacion estacion, string modulo, int costo)
        {
            _estacion = estacion;
            _modulo = modulo;
            _costo = costo;
        }

        public string Descripcion => $"Construir {_modulo} (-{_costo} Creditos)";

        public void Deshacer() =>
            _estacion.DemolerModulo(_modulo, _costo);
        

        public bool Ejecutar() =>
            _estacion.ConstruirModulos(_modulo, _costo);
       
    }
}
