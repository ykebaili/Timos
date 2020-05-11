using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;

namespace timos.data
{
    /// <summary>
    /// Description résumée de CProjetServeur.
    /// </summary>
    public class CLienDeProjetServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
		public CLienDeProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
			return CLienDeProjet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
				CLienDeProjet lienDeProjet = (CLienDeProjet)objet;
				if (lienDeProjet.ElementA == null)
					result.EmpileErreur(I.T("A Element is required|398"));
				if (lienDeProjet.ElementB == null)
					result.EmpileErreur(I.T("B Element is required|399"));


            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }
        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
			return typeof(CLienDeProjet);
        }

        //-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if ( !result )
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            ArrayList lstRows = new ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    CLienDeProjet lien = new CLienDeProjet(row);
                    result = lien.ControleCoherenceLien();
                    if (!result)
                        return result;
                }
            }
            return result;
        }
    }
}
