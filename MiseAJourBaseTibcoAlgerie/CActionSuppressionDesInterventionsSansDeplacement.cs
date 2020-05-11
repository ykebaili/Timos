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
    public class CActionSuppressionDesInterventionsSansDeplacement : IActionSurServeur
    {

        public CActionSuppressionDesInterventionsSansDeplacement()
			: base()
		{
		}

		public static void Autoexec()
		{
            CDeclencheurActionSurServeur.RegisterAction(new CActionSuppressionDesInterventionsSansDeplacement());
		}


        #region IActionSurServeur Membres

        public string CodeType
        {
            get { return "SUPR_INTER_SANS_DEPLACEMENT"; }
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

                    // Supprimer les interventions SANS DEPLACEMENT
                    CListeObjetsDonnees listeIntersASupprimer = new CListeObjetsDonnees(contexte, typeof(CIntervention));
                    listeIntersASupprimer.Filtre = new CFiltreDataAvance(
                        CIntervention.c_nomTable,
                        //CIntervention.c_champId + " > @1 AND " + // DEBUG
                        CFractionIntervention.c_nomTable + "." +
                        COperation.c_nomTable + "." +
                        CTypeOperation.c_champId + " = @1",
                        //8900, // DEBUG
                        30); // 30 = Id du type d'opération SANS DEPLACEMENT

                    //int nbASupprimer = listeIntersASupprimer.CountNoLoad;
                    CObjetDonneeAIdNumerique.DeleteAvecCascadeSansControleDoncIlFautEtreSurDeSoi(listeIntersASupprimer);

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
            get { return "BDD Tibco Algérie - Suppression des Interventions sans déplacement" ; }
        }

        public string[] NomsParametres
        {
            get { return new string[] { }; }
        }

        #endregion
    }
}
