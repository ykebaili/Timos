using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using sc2i.custom;

namespace sc2i.custom.serveur
{
	/// <summary>
	/// Description résumée de CMenuCustomServeur.
	/// </summary>
	public class CMenuCustomServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CMenuCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CMenuCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CMenuCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CMenuCustom menu = (CMenuCustom)objet;

				if ( menu.Libelle == "")
					result.EmpileErreur(I.T("Custom Menu label connot be empty|320"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CMenuCustom);
		}
		//-------------------------------------------------------------------
	}
}
