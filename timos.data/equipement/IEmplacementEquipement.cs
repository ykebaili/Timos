using System;
using System.Collections.Generic;
using System.Text;
using timos.securite;

using sc2i.common;
using sc2i.data;

namespace timos.data
{
    /// <summary>
    /// Emplacement d'�quipement
    /// </summary>
	[DynamicClass("Equipment place")]
	public interface IEmplacementEquipement : IElementAEO
	{
		[DynamicField("Label")]
		string Libelle { get;}

        CListeObjetsDonnees Equipements { get; }
	}
}
 