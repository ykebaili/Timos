using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CSequenceNumerotationServeur.
	/// </summary>
	public class CSequenceNumerotationServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CSequenceNumerotationServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CSequenceNumerotationServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CSequenceNumerotation.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CSequenceNumerotation SequenceNumerotation = (CSequenceNumerotation)objet;

				if ( SequenceNumerotation.Libelle == "")
					result.EmpileErreur(I.T("Sequence Label cannot be empty|20175"));
				if (!CObjetDonneeAIdNumerique.IsUnique(SequenceNumerotation, CSequenceNumerotation.c_champLibelle, SequenceNumerotation.Libelle))
					result.EmpileErreur(I.T( "Sequence '@1' already exist|20176",SequenceNumerotation.Libelle));
                if (SequenceNumerotation.FormatNumerotation == null)
                    result.EmpileErreur(I.T("Select a numbering format|20177"));
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
			return typeof(CSequenceNumerotation);
		}
		//-------------------------------------------------------------------
	}
}
