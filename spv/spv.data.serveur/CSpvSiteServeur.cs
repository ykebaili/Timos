using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;

namespace spv.data.serveur
{
   [AutoExec("Autoexec")]
	public class CSpvSiteServeur : CMappableTimosServeur<CSite, CSpvSite>
	{

        public static void Autoexec()
        {
            RegisterPropagation();
        }

		///////////////////////////////////////////////////////////////
		public CSpvSiteServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvSite.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                CSpvSite spvSite = objet as CSpvSite;

                if (spvSite.SiteNom == null)
                    result.EmpileErreur(I.T("Site name should be defined|60006"));
                
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}

			return result;
		}


        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CSpvSite);
        }


        //////////////////////////////////////////////////////////////////
        protected override bool ShouldAutoCreateObjetSpv(CSite objetTimos)
        {
           return true;//Création systématique de site dans SPV à partir d'un site Timos
        }


        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);

            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            List<DataRow> lstCrees = (List<DataRow>)table.ExtendedProperties[CDivers.c_cleRowCrees];
            if (lstCrees != null)
                table.ExtendedProperties.Clear();

            lstCrees = new List<DataRow>();

            ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    CSpvSite spvSite = new CSpvSite(row);
                    if (row.RowState == DataRowState.Added)
                    {
                        CSpvSite_Rep spvSiteRep = new CSpvSite_Rep(contexte);
                        if (!spvSiteRep.ReadIfExists(spvSite.Id))
                        {
                            spvSiteRep.CreateNewInCurrentContexte(new object[] { spvSite.Id });
                            spvSiteRep.CodeEtatOperationnel = (Int32?)EEtatOperationnel.OK;
                            spvSiteRep.SpvSite = spvSite;
                            lstCrees.Add(row);
                        }
                    }
                    else if (row.RowState == DataRowState.Modified)
                    {
                        string oldDomaine = CDivers.DbNullValue(row[CSpvSite.c_champSITE_DOMAINE, DataRowVersion.Original], null);
                        string oldEM = CDivers.DbNullValue(row[CSpvSite.c_champSITE_EMNAME, DataRowVersion.Original], null);
                        string newDomaine = spvSite.DomaineIP;
                        string newEM = spvSite.EmName;

                        if (((oldDomaine == null || oldEM == null) && newDomaine != null && newEM != null) ||
                             (oldDomaine != newDomaine || oldEM != newEM) ||
                            ((newDomaine == null || newEM == null) && oldDomaine != null && oldEM != null))
                        {
                            CSpvMessem messEM = new CSpvMessem(contexte);
                            messEM.CreateNewInCurrentContexte();
                            messEM.FormatMessModSite(spvSite.Id);
                        }
                    }
                    else if (row.RowState == DataRowState.Deleted)
                    {
                        Int32 nId = (Int32)spvSite.Row[CSpvSite.c_champSITE_ID, DataRowVersion.Original];
                        if (nId == CSpvSite.c_SiteFuturocom)
                            result.EmpileErreur(I.T("FUTUROCOM site could not be deleted|50017"));

                        if (result)
                        {
                            CSpvMessem messEM = new CSpvMessem(contexte);
                            messEM.CreateNewInCurrentContexte();
                            messEM.FormatMessDelSite((Int32)row[CSpvSite.c_champSITE_ID, DataRowVersion.Original]);
                        }
                    }
                }
            }

            table.ExtendedProperties.Add(CDivers.c_cleRowCrees, lstCrees);

            return result;
        }


        public override CResultAErreur TraitementApresSauvegarde(CContexteDonnee contexte, bool bOperationReussie)
        {
            CResultAErreur result = base.TraitementApresSauvegarde(contexte, bOperationReussie);

            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            List<DataRow> lstCrees = (List<DataRow>)table.ExtendedProperties[CDivers.c_cleRowCrees];
            if (lstCrees == null)
                return result;

            foreach (DataRow row in lstCrees)
            {
                CSpvSite spvSite = new CSpvSite(row);
                using (CContexteDonnee newContexte = new CContexteDonnee(IdSession, true, false))
                {
                    CSpvMessem messEM = new CSpvMessem(newContexte);
                    messEM.CreateNewInCurrentContexte();
                    messEM.FormatMessCreSite(spvSite.Id);
                    result = newContexte.SaveAll(true);
                }
            }
            return result;
        }
	}
}
