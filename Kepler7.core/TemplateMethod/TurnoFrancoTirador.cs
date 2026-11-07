using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.TemplateMethod
{
    public class TurnoFrancoTirador : TurnoUnidad
    {
        private const int DistanciaMinima = 3;
        private Unidad _objetivo;

        public TurnoFrancotirador(Unidad unidad, CampoBatalla campo, RegistroTurnos registro)
            : base(unidad, campo, registro) { }

        protected override string TipoUnidad => "Francotirador";

       //Solo si el enemigo esta lejos
        protected override bool PuedeActuar() =>
            base.PuedeActuar() && Campo.EnemigosVivos.Any(e => DistanciaA(e) >= DistanciaMinima);

        protected override string Decidir()
        {
            _objetivo = Campo.EnemigosVivos
                .Where(e => DistanciaA(e) >= DistanciaMinima)
                .OrderBy(e => e.Vida)
                .First();   
            return $"apunta al enemigo más débil: {_objetivo.Nombre} ({_objetivo.Vida} de vida)";
        }

        protected override string Actuar() =>
            EjecutarAccion(new AtacarComando(Unidad, _objetivo));
    }
}
