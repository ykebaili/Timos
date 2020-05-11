using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data;

namespace timos.data
{
	public interface IElementAIntervention : IObjetDonneeAIdNumeriqueAuto, IElementAEO
	{
		string Libelle { get;}
	}
}
