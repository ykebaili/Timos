using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.common;
using sc2i.process;
using sc2i.process.serveur;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.data.serveur;
using System.Collections;
using sc2i.data.dynamic;
using timos.data;
using timos.acteurs;


namespace MiseAJourBaseTibcoAlgerie
{
	[AutoExec("Autoexec")]
    public class CActionMiseAJourBaseTibcoAlgerie : IActionSurServeur
    {

        public CActionMiseAJourBaseTibcoAlgerie()
			: base()
		{
		}

		public static void Autoexec()
		{
            CDeclencheurActionSurServeur.RegisterAction(new CActionMiseAJourBaseTibcoAlgerie());
		}


        #region IActionSurServeur Membres

        public string CodeType
        {
            get { return "MAJ_BDD_TIBCO_ALGERIE"; }
        }

        public string Description
        {
            get { return "Met à jour la base de données de Tibco Algérie pour compatibilité avec le nouveau paramétrage" ; }
        }

        public CResultAErreur Execute(int nIdSession, Hashtable valeursParametres)
        {
			CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee contexte = new CContexteDonnee(nIdSession, true, false))
            {
                try
                {
                    CHandlerEvenementServeur.SuspendGestionnaire(true);
                    contexte.EnableTraitementsAvantSauvegarde = false;

                    CListeObjetsDonnees lstInterventions = new CListeObjetsDonnees(contexte, typeof(CIntervention));
                    //*** DEBUG ***
                    //lstInterventions.Filtre = new CFiltreData(
                    //    CIntervention.c_champId + " > @1 ",
                    //    8500);
                    int compteur = lstInterventions.CountNoLoad;
                    // FIN DEBUG
                    lstInterventions.ReadDependances("PhaseTicket.Ticket.RelationsChampsCustom");
                    lstInterventions.ReadDependances("RelationsIntervenants");
                    foreach (CIntervention inter in lstInterventions)
                    {
                        compteur--;
                        CPhaseTicket phase = inter.PhaseTicket;
                        if (phase != null)
                        {
                            // Copier les compte rendu pour OTA depuis l'intervention vers le ticket
                            CTicket ticketLié = phase.Ticket;
                            // 113 = Id du champ [Compte rendu d'Intervention modifié]
                            string strCompteRendu = (string)inter.GetValeurChamp(113);
                            // 114 = Id du champ [Compte rendu résumé pour OTA]
                            ticketLié.SetValeurChamp(144, strCompteRendu);

                            // Affecter le technicien sur les Phases de ticket
                            CActeur acteur = null;
                            if (phase.GetValeurChamp(146) == null)
                            {
                                foreach (CIntervention_Intervenant rel in inter.RelationsIntervenants)
                                {
                                    acteur = rel.Intervenant;
                                    // 146 = Id du champ [Technicien affecté] sur Phase
                                    if (acteur != null)
                                    {
                                        phase.SetValeurChamp(146, acteur);
                                        break;
                                    }
                                }
                            }

                        }
                    }

                    result = contexte.SaveAll(true);
                    if (!result)
                    {
                        result.EmpileErreur("Erreur de sauvegarde des données");
                        return result;
                    }

                }
                catch (Exception e)
                {
                    result.EmpileErreur(new CErreurException(e));
                }
                finally
                {
                    CHandlerEvenementServeur.SuspendGestionnaire(false);
                }
            }

            return result;
        }

        public string Libelle
        {
            get { return "Mise à jour BDD Tibco Algérie" ; }
        }

        public string[] NomsParametres
        {
            get { return new string[] { }; }
        }

        #endregion
    }
}
