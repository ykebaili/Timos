using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data;

namespace timos.data
{
	public interface IElementAOperationsRealisees: IObjetDonneeAIdNumeriqueAuto
	{
		string Libelle { get;}
        DateTime? DateDebut { get; set;}
        DateTime? DateFin { get; set;}

        CListeObjetsDonnees Operations { get;}
	}

 
}
