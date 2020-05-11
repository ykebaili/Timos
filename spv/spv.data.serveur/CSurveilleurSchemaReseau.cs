using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.data;
using System.Data;
using System.Collections;

namespace spv.data.serveur
{
    /// <summary>
    /// Surveille les schéma réseau pour la mise à jour des données dans SPV
    /// </summary>
    [AutoExec("Autoexec")]
    public class CSurveilleurSchemaReseau
    {
        public static void Autoexec()
        {
            //CGestionnaireHookTimos.RegisterHook(typeof(CElementDeSchemaReseau), OnModificationSchemaReseau);
        }

        public static void OnModificationSchemaReseau(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
            DataTable table = contexte.Tables[CElementDeSchemaReseau.c_nomTable];
            if (table == null)
                return;
            //Id de schéma->true si modifié
            Dictionary<int, bool> dicSchemasModifies = new Dictionary<int, bool>();
            foreach (DataRow row in table.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                    case DataRowState.Modified:
                        if (row[CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens] != DBNull.Value)
                            dicSchemasModifies[(int)row[CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens]] = true;
                        break;
                    case DataRowState.Deleted:
                        if (row[CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens, DataRowVersion.Original] != DBNull.Value)
                            dicSchemasModifies[(int)row[CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens, DataRowVersion.Original]] = true;
                        break;
                }
            }
            foreach (int nIdSchema in dicSchemasModifies.Keys)
            {
                CSchemaReseau schema = new CSchemaReseau(contexte);
                if (schema.ReadIfExists(nIdSchema))
                {
                    if (schema.LienReseau != null)
                    {
                        if (CSpvLiai.CanSupervise(schema.LienReseau))
                        {
                            CSpvLiai spvLien = CSpvLiai.GetSpvLiaiFromLienReseauAvecCreation(schema.LienReseau);
                            if (spvLien != null)
                            {
                                result = spvLien.UpdateCablages();
                                if (result)
                                    spvLien.UpdateSupportants();
                                    
                                if (!result)
                                    return ;
                            }
                        }
                    }
                }
            }
            return ;
        }
    }
}
