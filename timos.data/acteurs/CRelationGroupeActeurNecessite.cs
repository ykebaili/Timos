using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;

namespace timos.acteurs
{
	/// <summary>
    /// Relation entre un <see cref="CGroupeActeur">Groupe d'Acteur nécessaire</see> et un
    /// <see cref="CGroupeActeur">un groupe d'Acteur requérant</see>.
	/// </summary>
    /// <remarks>
    /// Lorsqu'un groupe d'acteur GA est nécessaire à un groupe d'acteur GB,
    /// le groupe d'acteur GA est un groupe nécessaire vis à vis du groupe d'acteur GB
    /// et le groupe d'acteur GB est un groupe requérant vis à vis du groupe d'acteur GA
    /// </remarks>
    [DynamicClass("Necessary member group relation")]
	[Table(CRelationGroupeActeurNecessite.c_nomTable, CRelationGroupeActeurNecessite.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationGroupeActeurNecessiteServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_GroupesActeurs_ID)]
    public class CRelationGroupeActeurNecessite : CObjetDonneeAIdNumeriqueAuto, IRelationGroupeGroupeNecessaire
	{
		public const string c_nomTable = "MEMBER_GRP_NEEDS";

		public const string c_champId = "MEMBER_GRP_NEEDS_ID";
		public const string c_champIdGroupeNecessitant = "MBERGRP_REQUIRING";
		public const string c_champIdGroupeNecessaire = "MBERGRP_NECESSARY";

		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeurNecessite()
			:base()
		{
		}
#endif
		//---------------------------------------------------------------------------
		public CRelationGroupeActeurNecessite( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//---------------------------------------------------------------------------
		public CRelationGroupeActeurNecessite(DataRow row )
			:base(row)
		{
		}

		//---------------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champId};
		}

		//---------------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Membership Need between Group @1 and @2|287" ,GroupeNecessitant.Libelle,GroupeNecessaire.Libelle);
			}
		}

		//---------------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}
		//---------------------------------------------------------------------------
		public CGroupeStructurant GroupeNecessitant
		{
			get
			{
				return GroupeActeurNecessitant;
			}
			set
			{
				GroupeActeurNecessitant = (CGroupeActeur)value;
			}
		}
		//---------------------------------------------------------------------------
		public CGroupeStructurant GroupeNecessaire
		{
			get
			{
				return GroupeActeurNecessaire;
			}
			set
			{
				GroupeActeurNecessaire = (CGroupeActeur)value;
			}
		}
		//---------------------------------------------------------------------------
        /// <summary>
        /// Groupe requérant
        /// </summary>
		[RelationAttribute(CGroupeActeur.c_nomTable, CGroupeActeur.c_champId, c_champIdGroupeNecessitant, true, true,true)]
		[DynamicField("Requiring group")]
		public CGroupeActeur GroupeActeurNecessitant
		{
			get
			{
				return (CGroupeActeur)GetParent ( c_champIdGroupeNecessitant, typeof(CGroupeActeur));
			}
			set
			{
				SetParent ( c_champIdGroupeNecessitant, value );
			}
		}
		//---------------------------------------------------------------------------
        /// <summary>
        /// Groupe nécessaire
        /// </summary>
		[RelationAttribute(CGroupeActeur.c_nomTable, CGroupeActeur.c_champId, c_champIdGroupeNecessaire, true, false,true)]
		[DynamicField("Necessary group")]
		public CGroupeActeur GroupeActeurNecessaire
		{
			get
			{
				return ( CGroupeActeur)GetParent ( c_champIdGroupeNecessaire, typeof(CGroupeActeur));
			}
			set
			{
				SetParent ( c_champIdGroupeNecessaire, value );
			}
		}
		//---------------------------------------------------------------------------
		
	}
}
