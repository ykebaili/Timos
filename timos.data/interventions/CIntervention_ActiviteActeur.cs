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
	/// Relation entre une <see cref="CIntervention">Intervention</see> et une
	/// <see cref="CActiviteActeur">Activite d'Acteur</see>
	/// </summary>
	[DynamicClass("Intervention / Member activity")]
	[Table(CIntervention_ActiviteActeur.c_nomTable, CIntervention_ActiviteActeur.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CIntervention_ActiviteActeurServeur")]
	[Unique ( true, "This relation Interveiont/Activity already exist", CIntervention.c_champId, CActiviteActeur.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    public class CIntervention_ActiviteActeur : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "INTERVENTION_ACTIVITY_ACT";
		public const string c_champId = "INTER_ACTIVACT_ID";

		public const string c_champDureeImputee = "INTER_ACTIACT_DURATION";

		/// /////////////////////////////////////////////
		public CIntervention_ActiviteActeur( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CIntervention_ActiviteActeur(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Intervention Part/Member activity|30038");
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
		/// L'intervention, objet de la relation
		/// </summary>
		[Relation(
			CFractionIntervention.c_nomTable,
		   CFractionIntervention.c_champId,
		   CFractionIntervention.c_champId,
			true,
			true,
			true)]
		[DynamicField("Intervention Part")]
		public CFractionIntervention FractionIntervention
		{
			get
			{
				return (CFractionIntervention)GetParent(CFractionIntervention.c_champId, typeof(CFractionIntervention));
			}
			set
			{
				SetParent(CFractionIntervention.c_champId, value);
			}
		}


		
		//-------------------------------------------------------------------
		/// <summary>
		/// L'activité d'acteur, objet de la relation
		/// </summary>
		/// Laisser en composition car, sinon, on ne peut pas supprimer
		/// un CActiviteActeur après avoir supprimé  un CInterventionActiviteActeur
		/// qui n'a pas encore été viré de la base ! Le MyCanDelete du CActiviteActeur
		/// se charge de vérifier qu'il n'y a pas de liens vers des interventions
		/// non suprimés
		[Relation(
		   CActiviteActeur.c_nomTable,
		   CActiviteActeur.c_champId,
		  CActiviteActeur.c_champId,
			true,
			true,
			true)]

		[DynamicField("Member Activity")]
		public CActiviteActeur ActiviteActeur
		{
			get
			{
                return (CActiviteActeur)GetParent(CActiviteActeur.c_champId, typeof(CActiviteActeur));
			}
			set
			{
                SetParent(CActiviteActeur.c_champId, value);
			}
		}

		//-------------------------------------------------------------------


		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la durée de l'activité
		/// </summary>
		[TableFieldProperty(c_champDureeImputee)]
		[DynamicField("Charged duration")]
		public double DureeImputee
		{
			get
			{
				return (double)Row[c_champDureeImputee];
			}
			set
			{
				Row[c_champDureeImputee] = value;
			}
		}


	}
}
