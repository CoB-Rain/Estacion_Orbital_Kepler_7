using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.core.Modelos;

namespace Kepler7.core.TemplateMethod
{
    public abstract class TurnoUnidad
    {
        protected Unidad Unidad { get; }
        protected CampoBatalla Campo
        { get;
        }
        private readonly RegistroTurnos _registro;

        protected TurnoUnidad (Unidad unidad, CampoBatalla campo, RegistroTurnos registro)
        {
            Unidad = unidad;
            Campo = campo;
            _registro = registro;
        }


        public void EjecutarTurno()
        {
            Registrar("Inicio", Iniciar());

            if (PuedeActuar())
            {
                Registrar("Decision", Decidir());
                Registrar("Accion", Actuar());
            }
            else
            {
                Registrar("Decision", "no puede actuar este turno");
            }
            Registrar("Finalizacion", Finalizar());
        }

        //Pasos obligatorios
        protected abstract string Decidir();
        protected abstract string Actuar();
        protected abstract string TipoUnidad
        {
            get;
        }

        //Pasos opcionales
        protected virtual string Iniciar() => $"{Unidad.Nombre} comienza su turno";
        protected virtual string Finalizar() => $"{Unidad.Nombre}" termina su turno;

        //Punto de decision
        protected virtual bool PuedeActuar() => Unidad.Vida > 0;

        protected int DistanciaA(Unidad otra) => Math.Abs(Unidad.X - otra.X) + Math.Abs(Unidad.Y - otra.Y);

        protected string EjecutarAccion(IComando comando) => comando.Ejecutar() ? comando.Descripcion : "no pudo completar la accion";
        private void Registrar(string etapa, string detalle) => _registro.Agregar($"[{TipoUnidad}] {etapa}: {detalle}");
    }
}
