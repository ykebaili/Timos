using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;

using timos.acteurs;
using timos.securite;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CpostitServeur.
	/// </summary>
	public class CPostItServeur : CObjetServeur
	{
#if PDA
		public CPostitServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CPostItServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CPostIt.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CPostIt postIt = (CPostIt)objet;

				if ( postIt.ElementLie == null )
					result.EmpileErreur(I.T("The element related to the post-it is incorrect|323"));
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
			return typeof(CPostIt);
		}
		
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde (contexte);
			if ( !result )
				return result;

			DataTable table = contexte.Tables[GetNomTable()];
			if ( table == null )
				return result;

			ArrayList lst = new ArrayList ( table.Rows );

			CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(contexte);
			if ( user != null )
			{

				foreach ( DataRow row in lst )
				{
					if ( row.RowState == DataRowState.Modified )
					{
						CPostIt pt = new CPostIt ( row );
						if ( !pt.IsPublique && pt.Auteur != null &&
							pt.Auteur.Id != user.Id )
							row.RejectChanges();
					}
				}
			}
			return result;
		}


	}
}
