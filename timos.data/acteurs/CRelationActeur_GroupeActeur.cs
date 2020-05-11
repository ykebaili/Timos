using System;
using sc2i.data;
using sc2i.common;

using sc2i.process;

using sc2i.workflow;
using tiag.client;

namespace timos.acteurs
{
	/// <summary>
    /// Relation entre un <see cref="CActeur">Acteur</see> et un 
    /// <see cref="CGroupeActeur">Groupe d'acteurs</see>.
	/// </summary>
	[ObjetServeurURI("CRelationActeur_GroupeActeurServeur")]
	[DynamicClass("Member group relation")]
	[Table(CRelationActeur_GroupeActeur.c_nomTable, CRelationActeur_GroupeActeur.c_champId,true)]
	[FullTableSync]
    [TiagClass(CRelationActeur_GroupeActeur.c_nomTiag, "Id", true)]
    public class CRelationActeur_GroupeActeur : CObjetDonneeAIdNumeriqueAuto, IRelationGroupe, IElementAInterfaceTiag
	{
		#region Déclaration des constantes
		public const string c_nomTable = "MEMBER_MEMBER_GROUP";
        public const string c_champId = "MEMBER_MEMBER_GROUP_ID";

        public const string c_nomTiag = "Member/MemberGroup";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationActeur_GroupeActeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationActeur_GroupeActeur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationActeur_GroupeActeur( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
		public override string GetChampId()
		{
			return c_champId;
		}
		/// ///////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Relation between @1 and @2|284",Acteur.DescriptionElement, GroupeActeur.DescriptionElement);
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Utilisé par TIAG pour affecter le groupe par ses clés
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetMemberGroup(object[] lstCles)
        {
            CGroupeActeur groupe = new CGroupeActeur(ContexteDonnee);
            if (groupe.ReadIfExists(lstCles))
                GroupeActeur = groupe;
        }

		/// <summary>
		/// Groupe d'acteurs
		/// </summary>
		[Relation(CGroupeActeur.c_nomTable,CGroupeActeur.c_champId,CGroupeActeur.c_champId,true,false,true)]
		[DynamicField("Members group")]
        [TiagRelation(typeof(CGroupeActeur),"TiagSetMemberGroup")]
		public CGroupeActeur GroupeActeur
		{
			get
			{
				CGroupeActeur groupe = new CGroupeActeur(ContexteDonnee);
				groupe.Id = (int) Row[CGroupeActeur.c_champId];
				return groupe;
			}
			set
			{
				AssureExiste(value);
				Row[CGroupeActeur.c_champId] = value.Id;
			}
		}
		//-------------------------------------------------------------------
		public CGroupeStructurant Groupe
		{
			get
			{
				return GroupeActeur;
			}
			set
			{
				GroupeActeur = (CGroupeActeur) value;
			}
		}
		//-------------------------------------------------------------------
		public CObjetDeGroupe ObjetDeGroupe
		{
			get
			{
				return Acteur;
			}
			set
			{
				Acteur = (CActeur) value;
			}
		}

        /// <summary>
        /// Utilisé par TIAG pour affecter le groupe par ses clés
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetMember(object[] lstCles)
        {
            CActeur acteur = new CActeur(ContexteDonnee);
            if (acteur.ReadIfExists(lstCles))
                Acteur = acteur;
        }

		/// <summary>
		/// Acteur
		/// </summary>
		[Relation(CActeur.c_nomTable,CActeur.c_champId,CActeur.c_champId,true,true,true)]
		[DynamicField("Member")]
        [TiagRelation(typeof(CActeur),"TiagSetMember")]
		public CActeur Acteur
		{
			get
			{
				CActeur acteur = new CActeur(ContexteDonnee);
				acteur.Id = (int) Row[CActeur.c_champId];
				return acteur;
			}
			set
			{
				AssureExiste(value);
				Row[CActeur.c_champId] = value.Id;
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override CResultAErreur MyCanDelete()
		{
			CResultAErreur result = base.MyCanDelete();
			
			return result;
		}
		//-------------------------------------------------------------------

        #region IElementAInterfaceTiag Membres

        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        public string TiagType
        {
            get { return c_nomTiag; }
        }

        #endregion
    }
}
