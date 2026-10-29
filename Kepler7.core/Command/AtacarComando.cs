using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public class AtacarComando : IComando
    {
        private readonly Unidad _atacante, _objetivo;
        private int _danioAplicado;

        public AtacarComando(Unidad atacante, Unidad objetivo)
        {
            _atacante = atacante;
            _objetivo = objetivo;
        }

        public string Descripcion => $"{_atacante.Nombre} ataca a {_objetivo.Nombre}. {_danioAplicado} de daño";

        public void Deshacer() => _objetivo.Curar(_danioAplicado);

        public bool Ejecutar()
        {
            if (_objetivo.Vida <= 0)
                return false;
            _danioAplicado = _objetivo.RecibirDanio(_atacante.Ataque);
            return true;
        }


    }
}
