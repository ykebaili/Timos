using System;
using System.Collections.Generic;
using System.Text;
using tiag.client;

using sc2i.data.dynamic;
using sc2i.data;
using System.Data;
using System.ComponentModel;

namespace timos.data.tiag
{
	[TiagClass(CCaracteristiqueEntitePourTiag.c_nomTiag, "Id", true)]
	public class CCaracteristiqueEntitePourTiag : CCaracteristiqueEntite
	{
		private const string c_nomTiag = "Characteristic";

		public CCaracteristiqueEntitePourTiag(DataRow row)
			: base(row)
		{
		}

		public CCaracteristiqueEntitePourTiag(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		[TiagField("Label")]
		[TiagFakeField(CCaracteristiqueEntite.c_champLibelle)]
		public string LibelleTiag
		{
			get
			{
				return Libelle;
			}
			set
			{
				Libelle = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilisé par TIAG pour affecter le type de site par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		[TiagFieldAttribute("Characteristic type Id")]
		[TiagFakeField(CTypeCaracteristiqueEntite.c_champId)]
		public int IdTypeCaracteristique
		{
			get
			{
				if (TypeCaracteristique == null)
					return -1;
				return TypeCaracteristique.Id;
			}
			set
			{
				CTypeCaracteristiqueEntite typeCar = new CTypeCaracteristiqueEntite(ContexteDonnee);
				if (typeCar.ReadIfExists(value))
					TypeCaracteristique = typeCar;
			}
		}

		//-------------------------------------------------------------------
		[TiagField("Linked element id")]
		public int LinkedElementId
		{
			get
			{
				return IdElementLie;
			}
			set
			{
				IdElementLie = value;
			}
		}

		//-------------------------------------------------------------------
		[TiagField("Linked element type")]
		public string LinkedElementSystemType
		{
			get
			{
				return StringTypeElementLie;
			}
			set
			{
				StringTypeElementLie = value;
			}
		}
	}
		

}
