using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;

namespace timos.acteurs
{
	/// <summary>
	/// Relation entre un <see cref="CGroupeActeur">Groupe d'Acteur</see> et un
    /// autre <see cref="CGroupeActeur">groupe d'Acteur</see>.
	/// </summary>
    [DynamicClass("Member group Member group relation")]
	[Table(CRelationGroupeActeur_GroupeActeur.c_nomTable, CRelationGroupeActeur_GroupeActeur.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationGroupeActeur_GroupeActeurServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_GroupesActeurs_ID)]
    public class CRelationGroupeActeur_GroupeActeur : CObjetDonneeAIdNumeriqueAuto, 
		IRelationGroupeStructurantGroupeParent
	{
        public const string c_nomTable = "MEMBER_GRP_MEMBER_GRP_REL";

		public const string c_champId = "MBERGRP_REL_ID";
        public const string c_champIdGroupeContenant = "MBERGRP_CONTAINER";
		public const string c_champIdGroupeContenu = "MBERGRP_INCLUDED";
        public const string c_champRelationAD = "MBERGRP_AD_RELATION";
		//Si un groupe A appartient à un groupe B qui appartient à un groupe C
		//il existe une relation A/B sans relation source.
		//par transitivité, A appartient à C (mais seulement parce qu'il appartient à B),
		//On créera donc une relation A/C ayant pour relation source la relation A/B.
		//Si on supprimer A/B, A/C sera automatiquement supprimée, cette relation
		//est également conditionnée par la relation B/C, si on supprime BC, il faut
		//supprime A/B.
		/*
		 * Autrement DIT :
		 * On a les relations suivantes  : AB BC
		 * on en déduit la relation AC, avec RelationSourceParent = BC et
		 * relation sourceFille = AB*/
        public const string c_champIdRelationSourceParent = "MBERGRP_REL_PARENT_SOURCE";
        public const string c_champIdRelationSourceFille = "MBERGRP_REL_CHILD_SOURCE";

		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeur_GroupeActeur()
			:base()
		{
		}
#endif
		//////////////////////////////////////////////////////////////////////////
		public CRelationGroupeActeur_GroupeActeur( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationGroupeActeur_GroupeActeur(DataRow row )
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
				return I.T("Membership relation between Group @1 and @2|286",GroupeContenant.Libelle,GroupeContenu.Libelle);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		
		

		//////////////////////////////////////////////////////////////////////////
		public CGroupeStructurant GroupeContenant
		{
			get
			{
				return GroupeActeurContenant;
			}
			set
			{
				GroupeActeurContenant = (CGroupeActeur)value;
			}
		}
		//---------------------------------------------------------------------------
		public CGroupeStructurant GroupeContenu
		{
			get
			{
				return GroupeActeurContenu;
			}
			set
			{
				GroupeActeurContenu = (CGroupeActeur)value;
			}
		}
		//---------------------------------------------------------------------------
        /// <summary>
        /// Groupe contenant
        /// </summary>
			[RelationAttribute(CGroupeActeur.c_nomTable, CGroupeActeur.c_champId, c_champIdGroupeContenant, true, false,true)]
			[DynamicField("Container group")]
			public CGroupeActeur GroupeActeurContenant
		{
			get
			{
				return (CGroupeActeur)GetParent ( c_champIdGroupeContenant, typeof(CGroupeActeur));
			}
			set
			{
				SetParent ( c_champIdGroupeContenant, value );
			}
		}

		

		//////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Groupe contenu
        /// </summary>
		[RelationAttribute(CGroupeActeur.c_nomTable, CGroupeActeur.c_champId, c_champIdGroupeContenu, true, true,true)]
		[DynamicField("Inside group")]
		public CGroupeActeur GroupeActeurContenu
		{
			get
			{
				return ( CGroupeActeur)GetParent ( c_champIdGroupeContenu, typeof(CGroupeActeur));
			}
			set
			{
				SetParent ( c_champIdGroupeContenu, value );
			}
		}

		//////////////////////////////////////////////////////////////////////////
		public bool IsRelationDirecte()
		{
			return RelationSourceParent == null;
		}

		//////////////////////////////////////////////////////////////////////////
		///Relations induites (crées dans l'objetServeur TraitementAvantSauvegarde)
		[Relation(c_nomTable, c_champId, c_champIdRelationSourceParent, false, true)]
		public IRelationGroupeStructurantGroupeParent RelationSourceParent
		{
			get
			{
				return (CRelationGroupeActeur_GroupeActeur)GetParent(c_champIdRelationSourceParent, typeof(CRelationGroupeActeur_GroupeActeur));
			}
			set
			{
				SetParent ( c_champIdRelationSourceParent, (CRelationGroupeActeur_GroupeActeur)value );
			}
		}

		//////////////////////////////////////////////////////////////////////////
		[Relation(c_nomTable, c_champId, c_champIdRelationSourceFille, false, true)]
		public IRelationGroupeStructurantGroupeParent RelationSourceFille
		{
			get
			{
				return (CRelationGroupeActeur_GroupeActeur)GetParent(c_champIdRelationSourceFille, typeof(CRelationGroupeActeur_GroupeActeur));
			}
			set
			{
				SetParent ( c_champIdRelationSourceFille, (CRelationGroupeActeur_GroupeActeur)value );
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override CResultAErreur MyCanDelete()
		{
			CResultAErreur result = base.MyCanDelete();
			
			return result;
		}

		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdRelationSourceParent; }
		}

		public string ProprieteListeFils
		{
			get { return ""; }
		}

		#endregion
		
	}
}
