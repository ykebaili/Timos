using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;
using spv.data;

namespace spv.data.serveur
{
   [AutoExec("Autoexec")]
	public class CSpvSchemaReseauServeur : CMappableTimosServeur<CSchemaReseau, CSpvSchemaReseau>
	{

        public static void Autoexec()
        {
            RegisterPropagation();
        }

		///////////////////////////////////////////////////////////////
		public CSpvSchemaReseauServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvSchemaReseau.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                CSpvSchemaReseau spvSchemaReseau = objet as CSpvSchemaReseau;

                if (spvSchemaReseau.Libelle == null)
                    result.EmpileErreur(I.T("Network diagram name should be defined|20011"));
                
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
            return typeof(CSpvSchemaReseau);
        }


        //////////////////////////////////////////////////////////////////
        protected override bool ShouldAutoCreateObjetSpv(CSchemaReseau objetTimos)
        {
           return true;//Création systématique de SchemaReseau dans SPV à partir d'un SchemaReseau Timos
        }


        //////////////////////////////////////////////////////////////////
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
                    CSpvSchemaReseau spvSchemaReseau = new CSpvSchemaReseau(row);
                    if (row.RowState == DataRowState.Added)
                    {
                        CSpvSchemaReseau_Rep spvSchemaReseauRep = new CSpvSchemaReseau_Rep(contexte);
                        if (!spvSchemaReseauRep.ReadIfExists(spvSchemaReseau.Id))
                        {
                            spvSchemaReseauRep.CreateNewInCurrentContexte(new object[] { spvSchemaReseau.Id });
                            spvSchemaReseauRep.CoefficientOperationnel = 1.0;
                            spvSchemaReseauRep.SpvSchema = spvSchemaReseau;
                            lstCrees.Add(row);
                        }
                    }
                }
            }
            return result;
        }
	}
}
