using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public class GestorComandos
    {
        private readonly Stack<IComando> _pilaDeshacer = new Stack<IComando>();

        private readonly Stack<IComando> _pilaRehacer = new Stack<IComando>();
        public readonly List<string> _historial = new List<string>();

        public event Action HistorialCambiado;

        public bool PuedeDeshacer => _pilaDeshacer.Count > 0;
        public bool PuedeRehacer => _pilaRehacer.Count > 0;

        public IReadOnlyList<string> Historial => _historial;

        public bool EjecutarComando(IComando comando)
        {
            if (!comando.Ejecutar())
                return false;

            _pilaDeshacer.Push(comando);
            _pilaRehacer.Clear();
            _historial.Add("-> " + comando.Descripcion);
            HistorialCambiado?.Invoke();
            return true;
        }

        public void DeshacerAccion()
        {
            if (!PuedeDeshacer)
                return;
            var comando = _pilaDeshacer.Pop();
            comando.Deshacer();
            _pilaRehacer.Push(comando);
            _historial.Add("Deshecho " + comando.Descripcion);
            HistorialCambiado?.Invoke();
        }

        public void RehacerAccion()
        {
            if (!PuedeRehacer)
                return;
            var comando = _pilaRehacer.Pop();
            comando.Ejecutar();
            _pilaDeshacer.Push(comando);
            _historial.Add("Rehecho " + comando.Descripcion);
            HistorialCambiado?.Invoke();

        }
    }
}
