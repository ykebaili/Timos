using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="CIntervention">Intervention</see>, une
	/// <see cref="CContrainte">Contrainte</see> et une
	/// <see cref="CRessourceMaterielle">Ressource materielle</see>.<br/><br/>
	/// Permet de lier une intervention avec une contrainte et de spécifier la 
	/// ressource nécessaire qu'il faut pour lever cette contrainte.
	/// </summary>
	[DynamicClass("Intervention / resource")]
	[Table(CIntervention_Ressource.c_nomTable, CIntervention_Ressource.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CIntervention_RessourceServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CIntervention_Ressource : CObjetDonneeAIdNumeriqueAuto, IEntreePlanning_Ressource
	{
		public const string c_nomTable = "INTER_RESOURCE";
		
		public const string c_champId = "TAC_RES_ID";
		public const string c_champIsChecked = "TAC_RES_CHECKED";

		/// /////////////////////////////////////////////
		public CIntervention_Ressource( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CIntervention_Ressource(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Intervention/Resource|206");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}



		//-------------------------------------------------------------------
		/// <summary>
		/// Intervention concernée par la relation<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CIntervention.c_nomTable,
			CIntervention.c_champId,
			CIntervention.c_champId,
			true,
			true,
			true)]
		[DynamicField("Intervention")]
		public CIntervention Intervention
		{
			get
			{
				return (CIntervention)GetParent(CIntervention.c_champId, typeof(CIntervention));
			}
			set
			{
				SetParent(CIntervention.c_champId, value);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Ressource matérielle concernée par la relation<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CRessourceMaterielle.c_nomTable,
		    CRessourceMaterielle.c_champId,
		    CRessourceMaterielle.c_champId,
			false,
			false,
			true)]
		[DynamicField("Resource")]
		public CRessourceMaterielle RessourceMaterielle
		{
			get
			{
				return (CRessourceMaterielle)GetParent(CRessourceMaterielle.c_champId, typeof(CRessourceMaterielle));
			}
			set
			{
				SetParent(CRessourceMaterielle.c_champId, value);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Contrainte concernée<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CContrainte.c_nomTable,
			CContrainte.c_champId,
			CContrainte.c_champId,
			true,
			true,
			true)]
		[DynamicField("Constraint")]
		public CContrainte Contrainte
		{
			get
			{
				return (CContrainte)GetParent(CContrainte.c_champId, typeof(CContrainte));
			}
			set
			{
				SetParent(CContrainte.c_champId, value);
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Pour une contrainte de type CheckList, indique
		/// que la contrainte a été cochée dans la checkList
		/// </summary>
		[TableFieldProperty ( c_champIsChecked)]
		[DynamicField("Is checked")]
		public bool IsChecked
		{
			get
			{
				return (bool)Row[c_champIsChecked];
			}
			set
			{
				Row[c_champIsChecked] = value;
			}
		}

	


		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public IEntreePlanning EntreePlanning
		{
			get
			{
				return Intervention;
			}
			set
			{
				if (value is CIntervention)
					Intervention = (CIntervention)value;
			}
		}

		//-------------------------------------------------------------------
		public IRessourceEntreePlanning Ressource
		{
			get
			{
				return RessourceMaterielle;
			}
			set
			{
				if ( value is CRessourceMaterielle )
					RessourceMaterielle = (CRessourceMaterielle)value;
			}
		}
	}
}
