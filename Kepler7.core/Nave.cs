using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kepler7.core
{
    public class Nave
    {
		private string _casco;

		public string Casco
		{
			get { return _casco; }
			set { _casco = value; }
		}

		private string _motor;

		public string Motor
		{
			get { return _motor; }
			set { _motor = value; }
		}

		private string _escudo;

		public string Escudo
		{
			get { return _escudo; }
			set { _escudo = value; }
		}

		private string _armas;

		public string Armas
		{
			get { return _armas; }
			set { _armas = value; }
		}

		private string _radar;

		public string Radar
		{
			get { return _radar; }
			set { _radar = value; }
		}

		private string _inteligenciaArtificial;

		public string InteligenciaArtificial
        {
			get { return _inteligenciaArtificial; }
			set { _inteligenciaArtificial = value; }
		}

		private string _tanquesCombustible;

		public string TanquesCombustible
		{
			get { return _tanquesCombustible; }
			set { _tanquesCombustible = value; }
		}
	}
}