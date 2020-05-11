using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using tiag.client;
using sc2i.data;
using timos.data;
using timos.securite;
using timos.data.tiag;

namespace timos.data.securite.tiag
{

	[TiagClass ( CTiagSiteEO.c_nomTiag, "Id", true )]
	public class CTiagSiteEO : CRelationElement_EO,
								IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Site_OE";
		
		//---------------------------------------------------
		public CTiagSiteEO(CContexteDonnee contexte)
			:base ( contexte )
		{
		}

		//---------------------------------------------------
		public CTiagSiteEO(DataRow row)
			: base(row)
		{
		}


		//-----------------------------------------------------------------
		public void TiagSetSiteKeys(object[] keys)
		{
			CSite site = new CSite(ContexteDonnee);
			if (site.ReadIfExists(keys))
				Site = site;
		}

		//-----------------------------------------------------------------
		[TiagRelation(typeof(CSite), "TiagSetSiteKeys")]
		public CSite Site
		{
			get
			{
				object obj = ElementLie;
				if (obj is CSite)
					return (CSite)obj;
				return null;
			}
			set
			{
				if (value == null || value is CSite)
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
