using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using System.Collections;
using System.Collections.Generic;

namespace spv.data.serveur
{
    public class CSpvEquip_Msk_SourceServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
        public CSpvEquip_Msk_SourceServeur(int nIdSession)
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
            return CSpvEquip_Msk_Source.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée
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
            return typeof(CSpvEquip_Msk_Source);
		}

        ///////////////////////////////////////////////////////////////
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            
            bool bHasDeleteMsk = true;
            while (bHasDeleteMsk)
            {
                bHasDeleteMsk = false;
                ArrayList lstRows = new ArrayList(table.Rows);
                Dictionary<CSpvEquip_Msk, bool> depMskAController = new Dictionary<CSpvEquip_Msk, bool>();
                foreach (DataRow row in lstRows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        //On a supprimé une source de CSpvEquip_Msk_Source, il faut
                        //donc vérifier que le CSpvEquip_Msk a toujours des raisons d'exister
                        CSpvEquip_Msk_Source source = new CSpvEquip_Msk_Source(row);
                        source.VersionToReturn = DataRowVersion.Original;
                        CSpvEquip_Msk depMsk = source.Equip_Msk;
                        if (depMsk != null && depMsk.IsValide())
                            depMskAController[depMsk] = true;
                    }
                }
                foreach (CSpvEquip_Msk depMsk in depMskAController.Keys)
                {
                    bool bToDelete = depMsk.Sources.Count == 0;
                    if (bToDelete)
                    {
                        result = depMsk.Delete(true);
                        bHasDeleteMsk = true;
                        if (!result)
                            return result;
                    }
                }
            }
            return result;
        }
	}
}
