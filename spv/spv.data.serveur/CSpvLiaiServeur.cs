using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;

using timos.data;

using spv.data;
using System.Collections.Generic;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
	public class CSpvLiaiServeur : CObjetServeur
	{

        public static void Autoexec()
        {
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CLienReseau), PropagerCLienReseau);            
        }

		///////////////////////////////////////////////////////////////
		public CSpvLiaiServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvLiai.c_nomTable;
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
			return typeof(CSpvLiai);
		}

        private static CSpvLiai GetSpvLiai(DataRow row)
        {
            CSpvLiai spvLiai;
            CLienReseau lienReseau = new CLienReseau(row);
            spvLiai = CSpvLiai.GetSpvLiaiFromLienReseau(lienReseau) as CSpvLiai;
            if (spvLiai == null)
            {
                spvLiai = CSpvLiai.GetSpvLiaiFromLienReseauAvecCreation(lienReseau);
            }
           // spvLiai.CopyFromLienReseau(lienReseau);
            spvLiai.CopyFromObjetTimos(lienReseau);
            return spvLiai;
        }

   

        ////////////////////////////////////////////////////////////////////
        public static void PropagerCLienReseau(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
            ///Pour éviter de traiter plusieurs fois une liaisons lors d'une sauvegarde
           Dictionary<DataRow, bool> rowsDejaTraitees = (Dictionary<DataRow, bool>)tableData[typeof(CSpvLiaiServeur)];
            if (rowsDejaTraitees == null)
            {
                rowsDejaTraitees = new Dictionary<DataRow, bool>();
                tableData[typeof(CSpvLiaiServeur)] = rowsDejaTraitees;
            }

            DataTable dt = contexte.Tables[CLienReseau.c_nomTable];
            if (dt != null)
            {
                ArrayList rows = new ArrayList(dt.Rows);

                foreach (DataRow row in rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        if (!rowsDejaTraitees.ContainsKey(row))
                        {
                            rowsDejaTraitees[row] = true;
                            switch (row.RowState)
                            {
                                case DataRowState.Added:
                                case DataRowState.Modified:
                                    CLienReseau lienTimos = new CLienReseau(row);
                                    //force la création du schéma pour qu'il se synchronise 
                                    lienTimos.GetSchemaReseauADessiner(true);
                                    CSpvLiai lienSpv = CSpvLiai.GetSpvLiaiFromLienReseau(lienTimos) as CSpvLiai;

                                    result = CSpvLiai.CanSupervise(lienTimos);
                                    if (lienSpv != null)
                                    {
                                        if (row.HasVersion(DataRowVersion.Original))
                                        {
                                            if (!row[CTypeLienReseau.c_champId].Equals(row[CTypeLienReseau.c_champId, DataRowVersion.Original]))
                                            {
                                                //CSpvTypliai typeLiai = CSpvTypliai.GetSpvTypliaiFromTypeLienReseau(lienTimos.TypeLienReseau) as CSpvTypliai;
                                                CSpvTypliai typeLiai = CSpvTypliai.GetObjetSpvFromObjetTimos(lienTimos.TypeLienReseau) as CSpvTypliai;
                                                if (typeLiai == null)
                                                {
                                                    result = lienSpv.Delete(true);
                                                    if (!result)
                                                    {
                                                        result.EmpileErreur("Can not cancel supervision of link @1|20005", lienTimos.Libelle);
                                                        return;
                                                    }
                                                }
                                                else
                                                    lienSpv.NomTypeLiaison = typeLiai.Libelle;
                                            }
                                        }
                                        if (!result)
                                        {
                                            result.EmpileErreur(I.T("Invalide properties for supervised link @1|20004", lienTimos.Libelle));
                                            return;
                                        }
                                        if (lienSpv != null && lienSpv.IsValide())
                                         //   lienSpv.CopyFromLienReseau(lienTimos);
                                            lienSpv.CopyFromObjetTimos(lienTimos);
                                    }
                                    else
                                    {

                                        if (result)
                                        {
                                            //Création de la liaison SPV
                                            CSpvLiai liai = GetSpvLiai(row);
                                        }
                                        else
                                        {
                                            //CSpvTypliai typeLiai = CSpvTypliai.GetSpvTypliaiFromTypeLienReseau(lienTimos.TypeLienReseau) as CSpvTypliai;
                                            /*CSpvTypliai typeLiai = CSpvTypliai.GetObjetSpvFromObjetTimos(lienTimos.TypeLienReseau) as CSpvTypliai;
                                            if (typeLiai == null)*/
                                                result = CResultAErreur.True;
                                        }
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
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
                if (row.RowState == DataRowState.Added)
                {
                    CSpvLiai spvLiai = new CSpvLiai(row);
                    CSpvLiai_Rep spvLiaiRep = new CSpvLiai_Rep(contexte);
                    if (!spvLiaiRep.ReadIfExists(new CFiltreData(CSpvLiai_Rep.c_champLIAI_ID + "=@1", spvLiai.Id)))
                    {
                        spvLiaiRep.CreateNewInCurrentContexte(new object[] { spvLiai.Id });
                        spvLiaiRep.SpvLiai = spvLiai;
                        spvLiaiRep.CodeEtatOperationnel = (Int32?)EEtatOperationnel.OK;
                    }
                }
            }
            return result;
        }
    }
}
