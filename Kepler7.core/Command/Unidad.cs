using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.core.Command
{
    public class Unidad
    {
        public string Nombre
        {
            get; private set;
        }

        public int X
        {
            get; private set;
        }

        public int Y { get; private set; }

        public int Vida
        {
            get; private set;
        }

        public int VidaMaxima
        { get; private set;
        }

        public int Ataque
        {
            get; private set;
        }

        public Unidad(string nombre, int vidaMax, int ataque, int x, int y){
            Nombre = nombre;
            VidaMaxima = vidaMax;
            Vida = vidaMax;
            Ataque = ataque;
            X = x;
            Y = y;
        }

        public void MoverA(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int RecibirDanio(int cantidad)
        {
            int real = Math.Min(cantidad, Vida);

            Vida -= real;

            return real;
        }

        public int Curar(int cantidad)
        {
            int real = Math.Min(cantidad, VidaMaxima - Vida);

            Vida += real;

            return real;
        }
    }
}
