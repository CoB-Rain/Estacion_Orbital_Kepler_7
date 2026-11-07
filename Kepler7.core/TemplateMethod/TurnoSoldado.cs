using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.core.Modelos;

namespace Kepler7.core.TemplateMethod
{
    public class TurnoSoldado : TurnoUnidad
    {
        private Unidad _objetivo;

        public TurnoSoldado(Unidad unidad, CampoBatalla campo, RegistroTurnos registro) : base(unidad, campo, registro)
        {
        }

        protected override string TipoUnidad => "Soldado";

        protected override string Decidir()
        {
            _objetivo = Campo.EnemigosVivos.OrderBy(e => DistanciaA(e)).FirstOrDefault();
            return _objetivo == null ? "no hay enemigos a la vista" : $"elige al enemigo mas cercano : {_objetivo.Nombre}";
         }

        protected override string Actuar()
        {
            if (_objetivo == null)
                return "se queda en guardia";
            return EjecutarAccion(new AtacarComando(Unidad, _objetivo));
        }
    }
}
