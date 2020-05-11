using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.serveur;
using timos.data.equipement.consommables;
using sc2i.common;
using sc2i.data;
using System.Data;
using System.Collections;

namespace timos.data.serveur.equipement.consommables
{
    public class CTypeConsommableServeur : CObjetServeur
    {
        public CTypeConsommableServeur(int nIdSesion)
            : base(nIdSesion)
        {
        }
        
        public override string GetNomTable()
        {
            return CTypeConsommable.c_nomTable;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CTypeConsommable);
        }

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            CTypeConsommable typeConsom = objet as CTypeConsommable;
            if(typeConsom != null)
            {
                if (typeConsom.Libelle == string.Empty)
                    result.EmpileErreur(I.T("Consumable Type Label connot be empty|10030"));
                if (typeConsom.Famille == null)
                    result.EmpileErreur(I.T("Consumable Type Family connot be null|10035"));
            }

            return result;
        }

        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            foreach (DataRow row in new ArrayList(table.Rows))
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    //S'assure que les unités et les classes sont en adéquation
                    CTypeConsommable tp = new CTypeConsommable(row);
                    if (tp.Unite != null)
                        tp.ClasseUnite = tp.Unite.Classe;
                }
            }
            return result;
        }
    }
}
