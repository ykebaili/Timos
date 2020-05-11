using System;
using System.Collections;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;

using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.acteurs;


namespace sc2i.workflow
{
	/// <summary>
	/// Indique une synchronisation d'une entrée d'agenda avec un système externe
	/// </summary>
	[DynamicClass("Diary entry synchronization")]
	[ObjetServeurURI("CEntreeAgenda_SynchroExtServeur")]
	[Table(CEntreeAgenda_SynchroExt.c_nomTable, CEntreeAgenda_SynchroExt.c_champId,true)]
	public class CEntreeAgenda_SynchroExt : CObjetDonneeAIdNumeriqueAuto
	{

		#region Déclaration des constantes
		public const string c_nomTable = "DIARY_ENTRY_SYNC_EX";
		public const string c_champId = "DRYENSEX_ID";
		public const string c_champTypeEx = "DRYENSEXTYPE_EX";
		public const string c_champIdEx = "DRYENSEX_ID_EX";
		#endregion
		
		//-------------------------------------------------------------------
		public CEntreeAgenda_SynchroExt( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CEntreeAgenda_SynchroExt( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Synchronization of Diary Entry @1 @2|308",TypeExterne,IdExterne);
			}
		}
		
		
		//-------------------------------------------------------------------
        /// <summary>
        /// Chaîne de caractère qui nomme le Type d'entité externe à synchroniser
        /// </summary>
		[TableFieldProperty(c_champTypeEx, 255),
		DynamicField("Type Externe")]
		public string TypeExterne
		{
			get
			{
				return (string)Row[c_champTypeEx];
			}
			set
			{
				Row[c_champTypeEx] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// Chaîne de caractère qui donne l'Identifiant du Type d'entité externe à synchroniser
		/// </summary>
        [TableFieldProperty(c_champIdEx, 255),
		DynamicField("Id Externe")]
		public string IdExterne
		{
			get
			{
				return (string)Row[c_champIdEx];
			}
			set
			{
				Row[c_champIdEx] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'Entrée d'agenda à synchroniser
        /// </summary>
		[Relation ( 
			 CRelationEntreeAgenda_ElementAAgenda.c_nomTable,
			 CRelationEntreeAgenda_ElementAAgenda.c_champId,
			 CRelationEntreeAgenda_ElementAAgenda.c_champId,
			 true,
			 true,
			 true )]
		[DynamicField("Diary entry relation")]
		public CRelationEntreeAgenda_ElementAAgenda RelationEntreeAgenda
		{
			get
			{
				return (CRelationEntreeAgenda_ElementAAgenda)GetParent ( CRelationEntreeAgenda_ElementAAgenda.c_champId, typeof ( CRelationEntreeAgenda_ElementAAgenda ) );
			}
			set
			{
				SetParent ( CRelationEntreeAgenda_ElementAAgenda.c_champId, value );
			}
		}

				
	}
}
