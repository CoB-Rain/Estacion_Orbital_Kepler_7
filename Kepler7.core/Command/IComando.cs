using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public interface IComando
    {
        string Descripcion { get; }

        bool Ejecutar();

        void Deshacer();
    }
}
