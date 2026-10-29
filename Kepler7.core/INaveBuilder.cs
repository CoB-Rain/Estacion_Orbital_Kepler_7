using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kepler7.core
{
    public interface INaveBuilder
    {
        void Reset();
        void ColocarCasco(string casco);
        void ColocarMotor(string motor);
        void ColocarEscudo(string escudo);
        void ColocarArmas(string armas);
        void ColocarRadar(string radar);
        void ColocarIA(string ia);
        void ColocarTanques(string tanquesCombustible);
    }
}