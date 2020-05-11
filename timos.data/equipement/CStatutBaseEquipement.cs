using System;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CStatutBaseEquipement.
	/// </summary>
	public enum StatutBaseEquipement
	{
		EnProduction = 0,
		EnReserve = 10,
		EnPanne = 20,
		Detruit = 30
	}
	public class CStatutBaseEquipement : CEnumALibelle<StatutBaseEquipement>
	{
		/// //////////////////////////////////////////////////////
		public CStatutBaseEquipement(StatutBaseEquipement statut)
			:base(statut)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				switch (Code)
				{
					case StatutBaseEquipement.EnProduction:
						return I.T( "Working|108");
					case StatutBaseEquipement.EnReserve:
						return I.T( "Spare|109");
					case StatutBaseEquipement.EnPanne:
						return I.T( "Out of order|110");
					case StatutBaseEquipement.Detruit:
						return I.T( "Destroyed|113");
				}
				return "";
			}
		}
	}
}
