using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public class MoverComando : IComando
    {
        private readonly Unidad _unidad;
        private readonly int _destX, _destY;

        private int _prevX, _prevY;

        public MoverComando(Unidad unidad, int x, int y)
        {
            _unidad = unidad;
            _destX = x;
            _destY = y;
        }
        public string Descripcion => $"{_unidad.Nombre} se mueve a ({_destX}, {_destY})";

        public void Deshacer()
        {
            _unidad.MoverA(_prevX, _prevY);
        }

        public bool Ejecutar()
        {
            _prevX = _unidad.X;
            _prevY = _unidad.Y;

            _unidad.MoverA(_destX, _destY);

            return true;
        }
    }
}
