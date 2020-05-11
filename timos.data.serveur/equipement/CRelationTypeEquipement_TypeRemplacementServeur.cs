using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using sc2i.workflow.serveur;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeEquipement_TypeRemplacementServeur.
	/// </summary>
	public class CRelationTypeEquipement_TypeRemplacementServeur : CObjetServeur
	{

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_TypesIncluablesServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_TypeRemplacementServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEquipement_TypeRemplacement relation = (CRelationTypeEquipement_TypeRemplacement)objet;
				if ( relation.TypeRemplacable == null )
					result.EmpileErreur(I.T( "The Replaceable Type must be defined|131"));
				if ( relation.TypeRemplacant == null )
                    result.EmpileErreur(I.T( "The Substitute Type must be defined|132"));

                // La relation entre deux types d'équipements doit être unique
                CListeObjetsDonnees listeRel = new CListeObjetsDonnees(relation.ContexteDonnee,
                    typeof(CRelationTypeEquipement_TypeRemplacement));

                listeRel.Filtre = new CFiltreData("(" +
					"("+
                    CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacable + " = @1 AND " +
                    CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacant + " = @2) OR (" +
                    CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacable + " = @2 AND " +
                    CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacant + " = @1)) and "+
					CRelationTypeEquipement_TypeRemplacement.c_champId+"<>@3",
                    relation.TypeRemplacable.Id,
                    relation.TypeRemplacant.Id,
					relation.Id);
                
                listeRel.InterditLectureInDB = true;
                if (listeRel.Count != 0)
                {
                    result.EmpileErreur(I.T( "This relation already exists in the Relation List|133"));
                }


			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException(e));
			}
			return result;
		}

		/// ////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationTypeEquipement_TypeRemplacement.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipement_TypeRemplacement);
		}

		

	}
}
