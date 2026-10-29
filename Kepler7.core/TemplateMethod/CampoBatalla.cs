using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.core.Modelos;

namespace Kepler7.core.TemplateMethod
{
    public class CampoBatalla
    {
        public List<Unidad> Aliados
        {
            get;
        } = new List<Unidad>();

        public List<Unidad> Enemigos
        {
            get;
        } = new List<Unidad>();

        public IEnumerable<Unidad> AliadosVivos => Aliados.Where(a => a.Vida > 0);
        public IEnumerable<Unidad> EnemigosVivos => Enemigos.Where(e => e.Vida > 0);
    }
}
