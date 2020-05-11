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
using System.IO;


namespace MiseAJourBaseTibcoAlgerie
{
	[AutoExec("Autoexec")]
    public class CActionRequalificationTickets : IActionSurServeur
    {

        public CActionRequalificationTickets()
			: base()
		{
		}

		public static void Autoexec()
		{
            CDeclencheurActionSurServeur.RegisterAction(new CActionRequalificationTickets());
		}


        #region IActionSurServeur Membres

        public string CodeType
        {
            get { return "REQUALIF_TICKETS_TIBCO_ALGERIE"; }
        }

        public string Description
        {
            get { return "Requalification des Tickets de Tibco Algérie par import d'un ficher CSV" ; }
        }

        public CResultAErreur Execute(int nIdSession, Hashtable valeursParametres)
        {
			CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee contexte = new CContexteDonnee(nIdSession, true, false))
            {
                StreamReader reader = null;
                try
                {
                    CHandlerEvenementServeur.SuspendGestionnaire(true);
                    contexte.EnableTraitementsAvantSauvegarde = false;

                    // Charges tous les tickets
                    CListeObjetsDonnees listeTicketsACharger = new CListeObjetsDonnees(contexte, typeof(CTicket));
                    listeTicketsACharger.ReadDependances("RelationsChampsCustom");

                    // Lire le CSV
                    string strFichierImport = "c:\\TimosData\\IMPORT_JANVIER_MARS_2009.csv";
                    reader = new StreamReader(strFichierImport);

                    // Lit l'entête de colonnes
                    string strLine = reader.ReadLine();
                    // Lit la première ligne
                    strLine = reader.ReadLine();
                    while (strLine != null)
                    {
                        // Pour chaque ligne du ficher
                        string[] strChamps = strLine.Split(';');
                        string strNumeroTicket = strChamps[0];
                        string strIdQualif = strChamps[2];

                        // Traitement
                        CTicket ticket = new CTicket(contexte);
                        if (ticket.ReadIfExists(new CFiltreData(
                            CTicket.c_champNumero + " = @1",
                            strNumeroTicket)))
                        {
                            CQualificationTicket qualif = new CQualificationTicket(contexte);
                            if (qualif.ReadIfExists(new CFiltreData(
                                CQualificationTicket.c_champId + " = @1",
                                Int32.Parse(strIdQualif))))
                            {
                                // Affecte la valeur du champs custom 147 : Requalification
                                ticket.SetValeurChamp(147, qualif);
                            }

                        }
                        
                        // Lit la ligne suivante
                        strLine = reader.ReadLine();

                    }

                    reader.Close();

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
                    if (reader != null)
                        reader.Close();
                }
            }

            return result;
        }

        public string Libelle
        {
            get { return "Import des Requalifications de Tickets" ; }
        }

        public string[] NomsParametres
        {
            get { return new string[] { }; }
        }

        #endregion
    }
}
