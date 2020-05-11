using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvParamServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvParamServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvParam.c_nomTable;
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
			return typeof(CSpvParam);
		}

        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);

            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {

                if (row.RowState == DataRowState.Deleted)
                {
                    Int32 nId = (int)row[CSpvParamSysteme.c_champPARAM_ID, DataRowVersion.Original];
                    CSpvAccesAlarme spvAccesAlarme = new CSpvAccesAlarme(contexte);
                    if (spvAccesAlarme.ReadIfExists(new CFiltreData(CSpvAcces.c_champACCES_CATEGORIE + "=@1", nId)))
                        result.EmpileErreur(I.T("This parameter cannot be deleted because it is used in access|50020"));

                }
            }
            return result;
        }
	}
}
