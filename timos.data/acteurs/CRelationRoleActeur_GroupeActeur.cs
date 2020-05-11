using System;
using sc2i.data;
using sc2i.common;

namespace timos.acteurs
{
	/// <summary>
	/// Relation entre un <see cref="CGroupeActeur">Groupe d'Acteur</see> et un
	/// <see cref="CRoleActeur">Rôle d'Acteur</see>.
	/// </summary>
    [DynamicClass("Member group Member role relation")]
	[ObjetServeurURI("CRelationRoleActeur_GroupeActeurServeur")]
	[Table(CRelationRoleActeur_GroupeActeur.c_nomTable, CRelationRoleActeur_GroupeActeur.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_GroupesActeurs_ID)]
    public class CRelationRoleActeur_GroupeActeur : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		#region Déclaration des constantes
		public const string c_nomTable = "MEMBER_ROLE_MEMBER_GRP";
        public const string c_champId = "MEMBER_ROLE_MEMBER_GRP_ID";
		//public const string c_champRolePartNum = "ROLE_ACT_NUM";
		public const string c_champCodeRole = "ROLE_CODE";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationRoleActeur_GroupeActeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationRoleActeur_GroupeActeur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationRoleActeur_GroupeActeur( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		/// ///////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}
		//-------------------------------------------------------------------
		public override string GetChampId()
		{
			return c_champId;
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
				return I.T("Relation between @1 and @2|284", RoleActeur.Libelle, GroupeActeur.DescriptionElement);
			}
		}
		//-------------------------------------------------------------------
		#region Propriétés de CRelationRoleActeur_GroupeActeur (RoleActeur, GroupeActeur)

		[Relation(CGroupeActeur.c_nomTable,CGroupeActeur.c_champId,CGroupeActeur.c_champId,true,true)]
		[DynamicField("Member Group")]
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
		[
		TableFieldProperty(c_champCodeRole, 20)
		]
		public string CodeRole
		{
			get
			{
				return (string)Row[c_champCodeRole];
			}
			set
			{
				Row[c_champCodeRole] = value;
			}
		}
		//-------------------------------------------------------------------
		[DynamicField("Member Role")]
		public CRoleActeur RoleActeur
		{
			get
			{
				CRoleActeur role = CRoleActeur.GetRole((string)Row[c_champCodeRole]);
				return role;
			}
			set
			{
				//AssureExiste(value);
				Row[c_champCodeRole] = value.CodeRole;
			}
		}
		#endregion
		//-------------------------------------------------------------------
	}
}
