using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.data.projet.gantt;

namespace timos.data.serveur.projet.gantt
{
	/// <summary>
	/// Description résumée de CParametrageGanttServeur.
	/// </summary>
	public class CParametrageGanttServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CParametrageGanttServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CParametrageGanttServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CParametrageGantt.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CParametrageGantt ParametrageGantt = (CParametrageGantt)objet;
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
			return typeof(CParametrageGantt);
		}
		//-------------------------------------------------------------------
	}
}
