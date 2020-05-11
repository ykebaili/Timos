using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CGelServeur.
	/// </summary>
	public class CGelServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CGelServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGelServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGel.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGel gel = (CGel)objet;

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
			return typeof(CGel);
		}
		
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lst = new ArrayList(table.Rows);
			Hashtable tableInterventionsAVerifier = new Hashtable();
			Hashtable tablePhasesAVerifier = new Hashtable();
			foreach ( DataRow row in table.Rows )
			{
				if ( row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted)
				{
					CGel gel = new CGel ( row );
                    if (row.RowState == DataRowState.Deleted)
                        gel.VersionToReturn = DataRowVersion.Original;
					if ( gel.Intervention != null && gel.Intervention.IsValide())
						tableInterventionsAVerifier[gel.Intervention] = true;
					if ( gel.PhaseTicket != null && gel.PhaseTicket.IsValide())
						tablePhasesAVerifier[gel.PhaseTicket] = true;
                    if (row.RowState == DataRowState.Deleted)
                        gel.VersionToReturn = DataRowVersion.Current;
				}	
			}
            
			foreach ( CIntervention inter in tableInterventionsAVerifier.Keys )
			{
                //if ( tache.PhaseTicket != null && tablePhasesAVerifier.Contains ( tache.PhaseTicket ) )
                //    tablePhasesAVerifier.Remove ( tache.PhaseTicket );
				inter.RecalculeEtatGel();
			}
			foreach ( CPhaseTicket phase in tablePhasesAVerifier.Keys )
			{
				phase.RecalculeEtatGel();
			}
			return result;
		}
	}
}
