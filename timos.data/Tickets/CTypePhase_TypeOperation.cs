using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypePhase">Type de phase</see> et un
	/// <see cref="CTypeOperation">Type d'Opération</see>
	/// </summary>
	[DynamicClass("Ticket Phase type / Operation type")]
	[Table(CTypePhase_TypeOperation.c_nomTable, CTypePhase_TypeOperation.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypePhase_TypeOperationServeur")]
	public class CTypePhase_TypeOperation : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "PHASE_TYPE_OP_TYPE";
		

		public const string c_champId = "PHTP_OPTP_ID";
        public const string c_champOptionnel = "PHTP_OPTP_OPTIONAL";
        public const string c_champIndex = "PHTP_OPTP_INDEX";

		/// /////////////////////////////////////////////
		public CTypePhase_TypeOperation( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypePhase_TypeOperation(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Task type/Operation type|136");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			Optionnel = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champIndex};
		}

		/// /////////////////////////////////////////////
		/// <summary>
		/// Booléen indiquant que cette relation est optionnelle (si VRAI)
		/// </summary>
		[TableFieldProperty(c_champOptionnel)]
		[DynamicField("Optionnal")]
		public bool Optionnel
		{
			get
			{
				return (bool)Row[c_champOptionnel];
			}
			set
			{
				Row[c_champOptionnel] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Index de la relation
		/// </summary>
		[TableFieldProperty(c_champIndex)]
		[DynamicField("Index")]
		public int Index
		{
			get
			{
				return (int)Row[c_champIndex];
			}
			set
			{
				Row[c_champIndex] = value;
			}
		}


		
		//-------------------------------------------------------------------
		/// <summary>
		/// Type de phase objet de la relation
		/// </summary>
		[Relation(
			CTypePhase.c_nomTable,
			CTypePhase.c_champId,
			CTypePhase.c_champId,
			true,
			true,
			false)]
		[DynamicField("Phase type")]
		public CTypePhase TypePhase
		{
			get
			{
				return (CTypePhase)GetParent(CTypePhase.c_champId, typeof(CTypePhase));
			}
			set
			{
				SetParent(CTypePhase.c_champId, value);
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Type d'opération objet de la relation
		/// </summary>
		[Relation(
			CTypeOperation.c_nomTable,
			CTypeOperation.c_champId,
			CTypeOperation.c_champId,
			true,
			false,
			false)]
		[DynamicField("Operation type")]
		public CTypeOperation TypeOperation
		{
			get
			{
				return (CTypeOperation)GetParent(CTypeOperation.c_champId, typeof(CTypeOperation));
			}
			set
			{
				SetParent(CTypeOperation.c_champId, value);
			}
		}


	}
}
