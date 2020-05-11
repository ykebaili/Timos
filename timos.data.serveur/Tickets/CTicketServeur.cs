using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.acteurs;
using timos.data;
using timos.securite;

namespace timos.data.serveur
{
	/// <summary>
	/// Description rÃƒÆ’Ã‚Â©sumÃƒÆ’Ã‚Â©e de CTicketServeur.
	/// </summary>
	public class CTicketServeur : CObjetDonneeServeurAvecCache, ITicketServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CTicketServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTicketServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTicket.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTicket ticket = (CTicket)objet;

				//On vÃƒÆ’Ã‚Â©rifi qu'il n'y a aucun des esclaves qui est dÃƒÆ’Ã‚Â©jÃƒÆ’Ã‚Â  maitre de ce ticket
				foreach (CDependanceTicket dep in ticket.RelationsEsclavesListe)
					if (dep.TicketEsclave.IsMaitre(ticket))
						result.EmpileErreur(I.T( "The slave ticket @1 is already defined as a master of this ticket|229", dep.TicketEsclave.Numero));

				//On vÃƒÆ’Ã‚Â©rifi qu'il n'y a aucun des maitres qui est dÃƒÆ’Ã‚Â©jÃƒÆ’Ã‚Â  esclave de ce ticket
				foreach (CDependanceTicket dep in ticket.RelationsMaitresListe)
					if (ticket.IsMaitre(dep.TicketMaitre))
						result.EmpileErreur(I.T( "The master ticket @1 is already defined as a slave of this ticket|230", dep.TicketMaitre.Numero));

                if(ticket.Responsable == null)
                    result.EmpileErreur(I.T("A person  in charge of this ticket must be affected|231"));

                // Saisie des dÃƒÆ’Ã‚Â©tails
                if (ticket.Client == null)
                    result.EmpileErreur(I.T("The Customer cannot be empty|232"));
                if (ticket.Contrat == null)
                    result.EmpileErreur(I.T("The Contract cannot be empty|233"));
                if(ticket.TypeTicket == null)
                    result.EmpileErreur(I.T("The Ticket Type cannot be empty|234"));

                // Le Tikcet doit avoir au moins une phase de rÃƒÆ’Ã‚Â©solution
                //if (ticket.PhasesListe.Count == 0)
                  //  result.EmpileErreur(I.T("The ticket must have at least one resolution phase|235"));

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
			return typeof(CTicket);
		}

        public const string c_numTikcet = "TICKET_NUM";
        //-------------------------------------------------------------------
        /// <summary>
        /// Retrourne un nouveau numÃƒÆ’Ã‚Â©ro de Ticket unique sous forme d'un entier
        /// </summary>
        /// <returns></returns>
        public int GetNewTicketNumber()
        {
            lock (typeof(CTicketServeur))
            {
                CDatabaseRegistre reg = new CDatabaseRegistre(IdSession);
                long nNumero = reg.GetValeurLong(c_numTikcet, 100000);
                nNumero++;
                if (!reg.SetValeur(c_numTikcet, nNumero.ToString()))
                    return -1;
                
                return (int)nNumero;
            }

        }

        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexte"></param>
        /// <returns></returns>
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            DataTable table = contexte.Tables[GetNomTable()];
			ArrayList lst = new ArrayList(table.Rows );
            foreach (DataRow row in lst)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    CTicket ticket = new CTicket(row);

                    DataRowVersion currentVersion = ticket.VersionToReturn;
                    CDonneesActeurUtilisateur respApresModif = ticket.Responsable;
                    DateTime? dateClotureTechApres = ticket.DateClotureTechnique;

                    ticket.VersionToReturn = DataRowVersion.Original;
                    CDonneesActeurUtilisateur respAvantModif = ticket.Responsable;
                    DateTime? dateClotureTechAvant = ticket.DateClotureTechnique;

                    ticket.VersionToReturn = currentVersion;

                    // Si le Responsable a ÃƒÆ’Ã‚Â©tÃƒÆ’Ã‚Â© modifiÃƒÆ’Ã‚Â©, crÃƒÆ’Ã‚Â©ation d'un Historique
                    if (respApresModif != null)
                    {
                        if (respAvantModif == null || respApresModif != respAvantModif)
                        {
                            if (respApresModif.Acteur != null)
                                ticket.CreerHistorique(ticket.PhaseEnCours, I.T("Ticket assigned to : |406") + respApresModif.Acteur.IdentiteComplete);
                        }
                    }
                    // Si la date de cloture technique change
                    if (dateClotureTechApres != null && dateClotureTechApres != dateClotureTechAvant)
                        ticket.CreerHistorique(ticket.PhaseEnCours, I.T("Technical closing date set to @1|407", dateClotureTechApres.ToString()));
                }
            }

            return result;
        }
    }
}
