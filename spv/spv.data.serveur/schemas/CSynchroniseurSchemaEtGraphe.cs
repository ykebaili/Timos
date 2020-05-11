using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;
using System.Collections;
using System.Data;
using sc2i.common;
using sc2i.data.serveur;
using timos.data.reseau.graphe;

namespace spv.data.serveur
{
    /// <summary>
    /// Se charge de synchroniser les donn�es d'un sch�ma avec les donn�es
    /// de supervision de ce sch�ma
    /// </summary>
    [AutoExec("Autoexec")]
    public class CSynchroniseurSchemaEtGraphe
    {
        public static void Autoexec()
        {
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CSchemaReseau), SynchroSchemaToSpv);
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CElementDeSchemaReseau), SynchroSchemaToSpv);
        }

        //////////////////////////////////////////////////////////////////
        private static void SynchroSchemaToSpv(
            CContexteDonnee contexte,
            Hashtable tableData,
            ref CResultAErreur result)
        {
            if (!result)
                return;
            //Emp�che de passer plusieurs fois
            if (tableData.ContainsKey(typeof(CSynchroniseurSchemaEtGraphe)))
                return;
            //Pour empecher de passer plusieurs fois
            tableData[typeof(CSynchroniseurSchemaEtGraphe)] = true;

            //S'assure que les liens sont biens cr��s et que leurs sch�mas aussi !
            CSpvLiaiServeur.PropagerCLienReseau(contexte, tableData, ref result);
            if (!result)
                return;
            //Cr�e les services correspondants aux sch�mas modifi�s
            
            //Toute modification d'un sch�ma est une modification du sch�ma auquel il appartient
            CListeObjetsDonnees lstSchemas = new CListeObjetsDonnees(contexte, typeof(CSchemaReseau), false);
            lstSchemas.InterditLectureInDB = true;
            foreach (CSchemaReseau schema in lstSchemas.ToArrayList())
            {
                CSchemaReseau tmp = schema;
                while (tmp != null && tmp.Row.RowState == DataRowState.Modified)
                {
                    tmp = tmp.SchemaParent;
                    if (tmp != null)
                        tmp.ForceChangementSyncSession();
                }
            }

            DataTable table = contexte.Tables[CSchemaReseau.c_nomTable];
            if ( table == null )
            {
                //S'il n'y a pas de sch�ma, mais qu'il y a des �l�ments de sch�ma,
                //force la v�rification des sch�mas

                if ( contexte.Tables.Contains ( CElementDeSchemaReseau.c_nomTable ) )
                    table = contexte.GetTableSafe ( CSchemaReseau.c_nomTable );
            }
            if (table != null)
            {
                #region Recherche des sch�mas modifi�s
                ArrayList lst = new ArrayList(table.Rows);
                //Cherche les sch�mas � v�rifier
                Dictionary<DataRow, bool> dicSchemasAVerifier = new Dictionary<DataRow,bool>();
                foreach (DataRow row in lst)
                    if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                        dicSchemasAVerifier[row] = true;
                DataTable tableElts = contexte.Tables[CElementDeSchemaReseau.c_nomTable];
                if (tableElts != null)
                {
                    lst = new ArrayList(tableElts.Rows);
                    foreach (DataRow row in lst)
                    {
                        if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified || row.RowState == DataRowState.Deleted)
                        {
                            CElementDeSchemaReseau elt = new CElementDeSchemaReseau(row);
                            if (row.RowState == DataRowState.Deleted)
                                elt.VersionToReturn = DataRowVersion.Original;
                            CSchemaReseau schema = elt.SchemaReseau;
                            if (schema != null && schema.IsValide() )
                                dicSchemasAVerifier[schema.Row] = true;
                            while (schema != null && schema.IsValide() && schema.SchemaParent != null)
                            {
                                dicSchemasAVerifier[schema.SchemaParent.Row] = true;
                                schema = schema.SchemaParent;
                            }
                        }

                    }
                }
                #endregion

                //Passe sur tous les sch�mas modifi�s
                foreach (DataRow row in dicSchemasAVerifier.Keys)
                {
                    #region Cr�ation du service, cr�ation des cablages
                    CSchemaReseau schema = new CSchemaReseau(row);
                    //Synchronisation du service avec le sch�ma
                    CSpvSchemaReseau spvSchema = CSpvSchemaReseau.GetObjetSpvFromObjetTimosAvecCreation(schema);
                    
                    //Si le sch�ma correspond � un lien, force la modification de ce lien
                    //Pour passer dans le traitement avant sauvegarde du lien
                    if (schema.LienReseau != null)
                    {
                        if (schema.LienReseau.Row.RowState == DataRowState.Unchanged)
                        {
                            schema.LienReseau.ForceChangementSyncSession();//Force la modification du lien pour qu'il soit resynchronis�
                        }
                    }
                    #endregion
                }
            }
            
            


            //Pour tous les sch�mas qui ont des �l�ments modifi�s, s'assure que les
            //Graphes des services concern�s sont � jour
            //Id de sch�ma -> true
            Dictionary<int, bool> schemasAGrapheObsolete = new Dictionary<int, bool>();
            table = contexte.Tables[CElementDeSchemaReseau.c_nomTable];
            if (table != null)
            {
                ArrayList lstRows = new ArrayList(table.Rows);
                foreach (DataRow row in lstRows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted)
                    {
                        CElementDeSchemaReseau elt = new CElementDeSchemaReseau(row);
                        DataRowVersion version = DataRowVersion.Current;
                        if (row.RowState == DataRowState.Deleted)
                            version = DataRowVersion.Original;
                        schemasAGrapheObsolete[(int)row[CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens, version]] = true;
                    }
                }
            }
            table = contexte.Tables[CSchemaReseau.c_nomTable];
            if (table != null)
            {
                ArrayList lstRows = new ArrayList(table.Rows);
                foreach (DataRow row in lstRows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                        schemasAGrapheObsolete[(int)row[CSchemaReseau.c_champId]] = true;
                }
            }

            CBaseGraphesReseau baseGraphes = new CBaseGraphesReseau();
            foreach ( int nIdSchema in schemasAGrapheObsolete.Keys )
            {
                CSchemaReseau schema = new CSchemaReseau ( contexte );
                if ( 
                    schema.ReadIfExists ( nIdSchema ) && 
                    schema.IsValide() && 
                    (schema.SchemaParent == null || schema.SiteApparenance != null)) //Ne calcule pas les graphes des sch�mas fils, ils sont d�j� integr�s dans le graphe du sch�ma parent!
                {
                    CSpvSchemaReseau spvSchema = CSpvSchemaReseau.GetObjetSpvFromObjetTimosAvecCreation(schema);
                    if ( spvSchema != null )
                    {
                        result = spvSchema.RecalculeArbreOperationnelInContexte( baseGraphes );
                        if ( !result )
                            return;
                    }
                }
            }
        }

    }
}
