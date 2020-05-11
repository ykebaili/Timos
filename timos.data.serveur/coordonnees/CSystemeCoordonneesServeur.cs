using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using sc2i.data.dynamic;


using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using sc2i.workflow;

namespace timos.data
{
	//<summary>
	//Description résumée de CSystemeCoordonneesServeur.
	//</summary>
	public class CSystemeCoordonneesServeur : CObjetDonneeServeurAvecCache, ISystemeCoordonneesServeur
	{
	    //-------------------------------------------------------------------
	    public CSystemeCoordonneesServeur ( int nIdSession )
	        :base ( nIdSession )
	    {
	    }

	    //-------------------------------------------------------------------
	    public override string GetNomTable ()
	    {
	        return CSystemeCoordonnees.c_nomTable;
	    }

	    //-------------------------------------------------------------------
	    public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
	    {
	        CResultAErreur result = CResultAErreur.True;
	        try
	        {
	            CSystemeCoordonnees systemeCoordonnees = (CSystemeCoordonnees)objet;

				//Verif label
	            if ( systemeCoordonnees.Libelle == "")
	                result.EmpileErreur(I.T("The label of the Coordinate system cannot be empty|177"));
				if (!CObjetDonneeAIdNumerique.IsUnique(systemeCoordonnees, CSystemeCoordonnees.c_champLibelle, systemeCoordonnees.Libelle))
	                result.EmpileErreur(I.T("The Coordinate system '@1' already exists|178",systemeCoordonnees.Libelle ));

				//Verification de la coohérence des positions des Formats de numérotation
				CListeObjetsDonnees lstcrscfn = systemeCoordonnees.RelationFormatsNumerotation;
				lstcrscfn.Tri = CRelationSystemeCoordonnees_FormatNumerotation.c_champPosition;
				for ( int i = 0; i < lstcrscfn.Count; i++)
				{
					CRelationSystemeCoordonnees_FormatNumerotation crscfn = (CRelationSystemeCoordonnees_FormatNumerotation)lstcrscfn[i];
					if(crscfn.Position != i)
						result.EmpileErreur(I.T("The numbering format @1 is at the position @2 instead of the position @3|180",crscfn.FormatNumerotation.Libelle,crscfn.Position.ToString(), i.ToString()));
				}
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
	        return typeof(CSystemeCoordonnees);
	    }



		//-------------------------------------------------------------------
		public bool IsUsed ( int[] nIdsSystemesCoordonnees )
		{
			if ( nIdsSystemesCoordonnees == null ||
				nIdsSystemesCoordonnees.Length == 0 )
				return false;
			C2iRequeteAvancee requete = new C2iRequeteAvancee(-1);
			requete.TableInterrogee = CParametrageSystemeCoordonnees.c_nomTable;
			string strIds ="";
			foreach ( int nId in nIdsSystemesCoordonnees )
				strIds += nId.ToString()+",";
			strIds = strIds.Substring(0, strIds.Length-1);

			requete.FiltreAAppliquer = new CFiltreData ( 
								CSystemeCoordonnees.c_champId+" in ("+strIds+")");

			requete.ListeChamps.Add(new C2iChampDeRequete("ID", new CSourceDeChampDeRequete(CParametrageSystemeCoordonnees.c_champId), typeof(int), OperationsAgregation.None, true));
			CResultAErreur  result = requete.ExecuteRequete(IdSession);
			if ( !result )
				return true;
			DataTable table = (DataTable)result.Data;
			List<int> idsParametrage = new List<int>();
			foreach ( DataRow row in table.Rows )
				idsParametrage.Add ( (int)row[0] );
			CParametrageSystemeCoordonneesServeur paramServeur = new CParametrageSystemeCoordonneesServeur(IdSession );
			return paramServeur.IsUsed ( idsParametrage.ToArray() );
		}





		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result =base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
            bool bIsAdmin = CUtilSession.GetDonneeDroitForSession(contexte.IdSession, CDroitDeBaseSC2I.c_droitAdministration) != null;
            
			ArrayList listRows = new ArrayList(table.Rows);
			foreach (DataRow row in listRows)
			{
				if (row.RowState == DataRowState.Modified)
				{

					if (!bIsAdmin && IsUsed(new int[] { (int)row[CSystemeCoordonnees.c_champId] }))
					{
						result.EmpileErreur(I.T("Impossible to modify the Coordinate System because it is currently used(administrator can do this modification)|244"));
						return result;
					}
				}
			}
			return result;
		}

        #region ISystemeCoordonneesServeur Membres

        public bool IsUsed(int nId)
        {
            return IsUsed(new int[] { nId });
        }

        #endregion
    }
}
