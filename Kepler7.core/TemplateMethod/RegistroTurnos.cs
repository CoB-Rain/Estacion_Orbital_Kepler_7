using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.TemplateMethod
{
    public class RegistroTurnos
    {
        private readonly List<string> _entradas = new List<string>();
        public event Action RegistroCambiado;

        public IReadOnlyList<string> Entradas => _entradas;

        public void Agregar(string texto)
        {
            _entradas.Add(texto);
            RegistroCambiado?.Invoke();
        }
    }
}
