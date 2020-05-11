using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.acteurs
{
	/// <summary>
	/// Relation entre un <see cref="CGroupeActeur">Groupe d'Acteur</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Member group Form relation")]
	[ObjetServeurURI("CRelationGroupeActeur_FormulaireServeur")]
	[Table(CRelationGroupeActeur_Formulaire.c_nomTable, CRelationGroupeActeur_Formulaire.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_GroupesActeurs_ID)]
    public class CRelationGroupeActeur_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "MEMBER_GROUP_FORM";
        public const string c_champId = "MEMBER_GROUP_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeur_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationGroupeActeur_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationGroupeActeur_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		[Relation(CGroupeActeur.c_nomTable,CGroupeActeur.c_champId,CGroupeActeur.c_champId,true,true,true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return ( IDefinisseurChampCustom )GetParent ( CGroupeActeur.c_champId, typeof(CGroupeActeur));
			}
			set
			{
				SetParent ( CGroupeActeur.c_champId, (CGroupeActeur)value );
			}
		}
	}
}
