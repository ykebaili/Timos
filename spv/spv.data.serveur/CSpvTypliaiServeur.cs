using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;

using timos.data;

using spv.data;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
    public class CSpvTypliaiServeur : CMappableTimosServeur<CTypeLienReseau, CSpvTypliai>
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvTypliaiServeur ( int nIdSession )
			:base(nIdSession)
		{
		}

        ///////////////////////////////////////////////////////////////
        public static void Autoexec()
        {
            RegisterPropagation();
        }

		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvTypliai.c_nomTable;
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
			return typeof(CSpvTypliai);
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

                if (row.RowState == DataRowState.Modified)
                {
                    if ((string)row[CSpvTypliai.c_champTYPLIAI_NOM, DataRowVersion.Original] !=
                        (string)row[CSpvTypliai.c_champTYPLIAI_NOM, DataRowVersion.Current])
                    {
                        CSpvTypliai spvTypliai = new CSpvTypliai(row);
                        foreach (CSpvLiai spvLiai in spvTypliai.SpvLiais)
                            spvLiai.NomTypeLiaison = spvTypliai.Libelle;
                    }
                }
            }

            return result;
        }


        //////////////////////////////////////////////////////////////////
        protected override bool ShouldAutoCreateObjetSpv(CTypeLienReseau objetTimos)
        {
            ///La supervision d'un type de lien est volontaire
            return false;
        }
	}
}
