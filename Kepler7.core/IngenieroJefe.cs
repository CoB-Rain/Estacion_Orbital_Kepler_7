using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kepler7.core
{
    public class IngenieroJefe
    {
        public IngenieroJefe(INaveBuilder nave)
        {
            CambiarNave(nave);
        }

        private INaveBuilder _nave;

        private void CambiarNave(INaveBuilder nave)
        {
            if (nave == null)
                throw new Exception("La nave no puede ser nula");

            _nave = nave;
        }

        public Nave ConstruirNave(TipoNave tipo)
        {
            ConcreteNave nuevaNave = new ConcreteNave();

            if (tipo == TipoNave.RecetaExploradora)
            {
                nuevaNave.ColocarCasco("Casco explorador");
                nuevaNave.ColocarMotor("Motor explorador");
                nuevaNave.ColocarEscudo("Escudo explorador");
                nuevaNave.ColocarArmas("Armas de largo alcance");
                nuevaNave.ColocarRadar("Radar ampliado");
                nuevaNave.ColocarIA("IA especializada en exploración");
                nuevaNave.ColocarTanques("Tanques de combustible de alta capacidad");
                return nuevaNave.GetResultNave();
            }
            else if (tipo == TipoNave.RecetaCombate)
            {
                nuevaNave.ColocarCasco("Casco de combate");
                nuevaNave.ColocarMotor("Motor de combate");
                nuevaNave.ColocarEscudo("Escudo de combate");
                nuevaNave.ColocarArmas("Armas tacticas especializadas");
                nuevaNave.ColocarRadar("Radar tactico");
                nuevaNave.ColocarIA("IA especializada en combate");
                nuevaNave.ColocarTanques("Tanques de combustible de alta capacidad");
                return nuevaNave.GetResultNave();
            }
            else
            {
                nuevaNave.ColocarCasco("Casco de carga");
                nuevaNave.ColocarMotor("Motor de carga");
                nuevaNave.ColocarEscudo("Escudo de carga");
                nuevaNave.ColocarArmas("Sin armas");
                nuevaNave.ColocarRadar("Radar de control");
                nuevaNave.ColocarIA("IA especializada en carga");
                nuevaNave.ColocarTanques("Tanques de combustible de alta capacidad");
                return nuevaNave.GetResultNave();
            }
        }
    }
}