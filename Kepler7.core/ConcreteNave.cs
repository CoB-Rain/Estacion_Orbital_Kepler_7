using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kepler7.core
{
    public class ConcreteNave : INaveBuilder
    {
        public ConcreteNave()
        {
            Reset();
        }

        private Nave _productNave;

        public void Reset()
        {
            _productNave = new Nave();
        }

        public void ColocarArmas(string armas)
        {
            _productNave.Armas = armas;
        }

        public void ColocarCasco(string casco)
        {
            _productNave.Casco = casco;
        }

        public void ColocarEscudo(string escudo)
        {
            _productNave.Escudo = escudo;
        }

        public void ColocarIA(string ia)
        {
            _productNave.InteligenciaArtificial = ia;
        }

        public void ColocarMotor(string motor)
        {
            _productNave.Motor = motor;
        }

        public void ColocarRadar(string radar)
        {
            _productNave.Radar = radar;
        }

        public void ColocarTanques(string tanquesCombustible)
        {
            _productNave.TanquesCombustible = tanquesCombustible;
        }

        public Nave GetResultNave()
        {
            Nave nave = _productNave;
            Reset();
            return nave;
        }
    }
}