using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;
using timos.data.supervision;
using timos.data.snmp;
using sc2i.data.dynamic;

namespace timos.data.serveur
{
    /// <summary>
    /// Description rÃ©sumÃ©e 
    /// </summary>
    public class CTypeEntiteSnmpServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CTypeEntiteSnmpServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeEntiteSnmp.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeEntiteSnmp TypeEntiteSnmp = (CTypeEntiteSnmp)objet;

                // Verifie le champ "Libelle"
                if (TypeEntiteSnmp.Libelle == "")
					result.EmpileErreur(I.T("Snmp entity type label cannot be empty|20152"));

                
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
            return typeof(CTypeEntiteSnmp);
		}


        //-------------------------------------------------------------------
        [Serializable]
        private class CMapChampEntiteToRowCustom : Dictionary<string, DataRow>
        {
        }
            

		//-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result =  base.TraitementAvantSauvegarde(contexte);
            if (result)
                result = SObjetHierarchiqueServeur.TraitementAvantSauvegarde(contexte, GetNomTable());
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            ArrayList lst = new ArrayList(table.Rows);
            Dictionary<int, CMapChampEntiteToRowCustom> dicEntitesToChamps = new Dictionary<int,CMapChampEntiteToRowCustom>();

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    CTypeEntiteSnmp typeEntite = new CTypeEntiteSnmp(row);
                    CMapChampEntiteToRowCustom map = null;
                    foreach (CChampEntiteFromQueryToChampCustom champ in typeEntite.ChampsFromQuery)
                    {
                        if (champ.IdChampCustom != null && champ.IdChampCustom.Value < 0)
                        {
                            CChampCustom champCustom = new CChampCustom(contexte);
                            if (champCustom.ReadIfExists(champ.IdChampCustom.Value, false))
                            {
                                if (map == null)
                                {
                                    map = new CMapChampEntiteToRowCustom();
                                    dicEntitesToChamps[typeEntite.Id] = map;
                                }
                                map[champ.Champ.Id] = champCustom.Row.Row;
                            }
                        }
                    }
                }
            }
            if (dicEntitesToChamps.Count > 0)
                table.ExtendedProperties[GetType()] = dicEntitesToChamps;
            return result;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur BeforeSave(CContexteSauvegardeObjetsDonnees contexte, IDataAdapter adapter, DataRowState etatsAPrendreEnCompte)
        {
            CResultAErreur result = base.BeforeSave(contexte, adapter, etatsAPrendreEnCompte);
            if ( !result )
                return result;

            DataTable table = contexte.ContexteDonnee.Tables[GetNomTable()];
            if (table == null)
                return result;

            //Recale les mappages de champs custom avec les nouveaux ids de champs
            Dictionary<int, CMapChampEntiteToRowCustom> dicEntitesToChamps = 
                table.ExtendedProperties[GetType()] as Dictionary<int, CMapChampEntiteToRowCustom>;
            if (dicEntitesToChamps == null)
                return result;
            foreach (KeyValuePair<int, CMapChampEntiteToRowCustom> maps in dicEntitesToChamps)
            {
                CTypeEntiteSnmp te = new CTypeEntiteSnmp(contexte.ContexteDonnee);
                if (te.ReadIfExists(maps.Key))
                {
                    foreach (KeyValuePair<string, DataRow> map in maps.Value)
                    {
                        CChampEntiteFromQueryToChampCustom champ = te.GetChamp(map.Key);
                        champ.IdChampCustom = (int)map.Value[CChampCustom.c_champId];
                    }
                }

                te.CommitChampsFromQuery();
            }
            table.ExtendedProperties.Remove ( GetType() );
            return result;
        }

    }
}
