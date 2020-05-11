using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CValeurSequenceNumerotationServeur.
	/// </summary>
	public class CValeurSequenceNumerotationServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CValeurSequenceNumerotationServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CValeurSequenceNumerotationServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CValeurSequenceNumerotation.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CValeurSequenceNumerotation ValeurSequenceNumerotation = (CValeurSequenceNumerotation)objet;

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
			return typeof(CValeurSequenceNumerotation);
		}
		//-------------------------------------------------------------------
	}
}
