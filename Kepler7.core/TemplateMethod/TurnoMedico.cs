using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.TemplateMethod
{
    public class TurnoMedico : TurnoUnidad
    {
        private Unidad _paciente;

        public TurnoMedico(Unidad unidad, CampoBatalla campo, RegistroTurnos registro)
            : base(unidad, campo, registro) { }

        protected override string TipoUnidad => "Médico";

        protected override string Iniciar() =>
            $"{Unidad.Nombre} revisa el estado del escuadrón";

        protected override string Decidir()
        {
            _paciente = Campo.AliadosVivos
                .Where(a => a.Vida < a.VidaMaxima)
                .OrderBy(a => (double)a.Vida / a.VidaMaxima)
                .FirstOrDefault();

            return _paciente == null
                ? "todos los aliados están sanos"
                : $"atiende al más herido: {_paciente.Nombre} ({_paciente.Vida}/{_paciente.VidaMaxima})";
        }

        protected override string Actuar()
        {
            if (_paciente == null)
                return "no hace falta curar a nadie";
            return EjecutarAccion(new CurarComando(_paciente, 30));
        }
    }
}
