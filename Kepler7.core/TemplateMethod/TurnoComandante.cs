using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.TemplateMethod
{
    public class TurnoComandante : TurnoUnidad
    {
        private Unidad _objetivo;
        private bool _retirarse;

        public TurnoComandante(Unidad unidad, CampoBatalla campo, RegistroTurnos registro)
            : base(unidad, campo, registro) { }

        protected override string TipoUnidad => "Comandante";

        protected override string Decidir()
        {
            int aliados = Campo.AliadosVivos.Count();
            int enemigos = Campo.EnemigosVivos.Count();

            _retirarse = enemigos > aliados;
            if (_retirarse)
                return $"desventaja ({aliados} vs {enemigos}): ordena retirada";

            _objetivo = Campo.EnemigosVivos.OrderByDescending(e => e.Vida).FirstOrDefault();
            return _objetivo == null
                ? "no quedan enemigos"
                : $"ventaja ({aliados} vs {enemigos}): ataca a la mayor amenaza, {_objetivo.Nombre}";
        }

        protected override string Actuar()
        {
            if (_retirarse)
                return EjecutarAccion(new MoverComando(Unidad, Unidad.X - 1, Unidad.Y));
            if (_objetivo == null)
                return "mantiene la posición";
            return EjecutarAccion(new AtacarComando(Unidad, _objetivo));
        }

        protected override string Finalizar() =>
            $"{Unidad.Nombre} da nuevas órdenes al escuadrón";
    }
}
