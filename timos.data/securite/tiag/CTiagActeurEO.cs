using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using tiag.client;
using sc2i.data;
using timos.data;
using timos.securite;
using timos.data.tiag;
using timos.acteurs;

namespace timos.data.securite.tiag
{

	[TiagClass ( CTiagActeurEO.c_nomTiag, "Id", true )]
	public class CTiagActeurEO : CRelationElement_EO,
								IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Member_OE";
		
		//---------------------------------------------------
		public CTiagActeurEO(CContexteDonnee contexte)
			:base ( contexte )
		{
		}

		//---------------------------------------------------
		public CTiagActeurEO(DataRow row)
			: base(row)
		{
		}


		//-----------------------------------------------------------------
		public void TiagSetMemberKeys(object[] keys)
		{
			CActeur acteur = new CActeur(ContexteDonnee);
			if (acteur.ReadIfExists(keys))
				Acteur = acteur;
		}

		//-----------------------------------------------------------------
        [TiagRelation(typeof(CActeur), "TiagSetMemberKeys")]
		public CActeur Acteur
		{
			get
			{
				object obj = ElementLie;
				if (obj is CActeur)
					return (CActeur)obj;
				return null;
			}
			set
			{
				if (value == null || value is CActeur)
					ElementLie = value;
			}
		}

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}
		
	}
}
