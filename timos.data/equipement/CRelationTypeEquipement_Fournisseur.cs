using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;
using timos.acteurs;
using System.Text;
using timos.data.commandes;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeEquipement">Type d'Equipement</see> et un 
	/// <see cref="CDonneesActeurFournisseur">Fournisseur</see>.
	/// </summary>
    [DynamicClass("Equipment type / Supplier")]
	[Table(CRelationTypeEquipement_Fournisseurs.c_nomTable, CRelationTypeEquipement_Fournisseurs.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_FournisseursServeur")]
    [RechercheRapide(CDonneesActeurFournisseur.c_nomTable+"."+
        CActeur.c_nomTable+"."+
        CActeur.c_champNom)]
    [RechercheRapide(CTypeEquipement.c_nomTable+"."+
        CTypeEquipement.c_champLibelle)]
	public class CRelationTypeEquipement_Fournisseurs : 
        CObjetDonneeAIdNumeriqueAuto,
        IReferenceElementCommandable
	{
		public const string c_nomTable = "EQUIPMENT_TYPE_SUPPLIER";

		public const string c_champId = "EQTTP_SUPP_ID";
		public const string c_champReference = "EQTTP_SUPP_REF";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Fournisseurs( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Fournisseurs(DataRow row )
			:base(row)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champId};
		}

		//////////////////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Supplier|104") + " " + Fournisseur != null ? Fournisseur.Acteur.Nom : "";
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Type d'équipement concerné par la relation
        /// </summary>
		[RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId,
		    CTypeEquipement.c_champId,
			true,
			true,
			false)]
		[DynamicField("Equipment type")]
		public CTypeEquipement TypeEquipement
		{
			get
			{
				return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
			}
			set
			{
				SetParent(CTypeEquipement.c_champId, value);
			}
		}

		

		//------------------------------------------------------------
        /// <summary>
        /// Fournisseur concerné par la relation
        /// </summary>
		[RelationAttribute(
			CDonneesActeurFournisseur.c_nomTable,
		   CDonneesActeurFournisseur.c_champId,
		   CDonneesActeurFournisseur.c_champId, 
			true, 
			false)]
		[DynamicField("Supplier")]
		public CDonneesActeurFournisseur Fournisseur
		{
			get
			{
				return (CDonneesActeurFournisseur)GetParent(CDonneesActeurFournisseur.c_champId, typeof(CDonneesActeurFournisseur));
			}
			set
			{
				SetParent(CDonneesActeurFournisseur.c_champId, value);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Référence de l'équipement chez le fournisseur
		/// </summary>
		[TableFieldProperty ( CRelationTypeEquipement_Fournisseurs.c_champReference, 128)]
		[DynamicField("Reference")]
        [RechercheRapide]
		public string Reference
		{
			get
			{
				return (string)Row[c_champReference];
			}
			set
			{
				Row[c_champReference] = value;
			}
		}

        //----------------------------------------------------------------------
        /// <summary>
        /// Libellé : est normalement constitué du libellé du type d'équipement/
        /// de l'identité complète du fournisseur/de la référence chez le fournisseur
        /// </summary>
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                if (TypeEquipement != null)
                {
                    bl.Append(TypeEquipement.Libelle);
                }
                if (Fournisseur != null)
                {
                    bl.Append("/");
                    bl.Append(Fournisseur.Acteur.IdentiteComplete);
                }
                bl.Append("/");
                bl.Append(Reference);
                return bl.ToString();
            }
        }



        #region IReferenceElementCommandable Membres
        //----------------------------------------------------------
        public IElementCommandable ElementCommandable
        {
            get
            {
                return TypeEquipement;
            }
        }

        #endregion
    }
}
