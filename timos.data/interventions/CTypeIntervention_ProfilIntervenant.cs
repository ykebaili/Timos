using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;
using timos.securite;
using tiag.client;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeIntervention">Type d'Intervention</see> et un
	/// <see cref="ProfilIntervenant">Profil d'Intervenant</see>
	/// </summary>
	[DynamicClass("Intervention type / Operator profile")]
	[Table(CTypeIntervention_ProfilIntervenant.c_nomTable, CTypeIntervention_ProfilIntervenant.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeIntervention_ProfilIntervenantServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeInterEtOps_ID)]
    [TiagClass(CTypeIntervention_ProfilIntervenant.c_nomTiag, "Id", true)]
    public class CTypeIntervention_ProfilIntervenant : 
		CObjetDonneeAIdNumeriqueAuto,
		ITypeRelationEntreePlanning_Ressource
	{
        public const string c_nomTable = "INTER_TYPE_PROFILE_TYPE";
        public const string c_nomTiag = "Intervention Type/Operator Profile";
		
		public const string c_champId = "TYPINTER_PROFINT_ID";
		public const string c_champLibelle = "TYPINTER_PROFINT_LIBELLE";
        public const string c_champMultiple = "TYPINTER_PROFINT_MULTIPLE";
        public const string c_champAfficherManquantDansPlanning = "TYPINTER_PROFINT_DISPMIS";

		/// /////////////////////////////////////////////
		public CTypeIntervention_ProfilIntervenant( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeIntervention_ProfilIntervenant(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Intervention Type / Operator profile|124");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            IsMultiple = false;
            AfficherManquantDansPlanning = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

		/// /////////////////////////////////////////////
		//-----------------------------------------------------------
		/// <summary>
		/// Libellé de la relation
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
        [TiagField("Label")]
		public string Libelle
		{
			get
			{
				string strVal = (string)Row[c_champLibelle];
				if (strVal == "")
				{
					if (ProfilIntervenant != null)
						strVal = ProfilIntervenant.Libelle;
				}
				return strVal;
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

        /// <summary>
        /// Indique s'il est possible de sélectionner plusieurs
        /// intervenants pour ce profil
        /// </summary>
        [TableFieldProperty(c_champMultiple)]
        [DynamicField("IsMultiple")]
        public bool IsMultiple
        {
            get
            {
                return (bool)Row[c_champMultiple];
            }
            set
            {
                Row[c_champMultiple] = value;
            }
        }

        /// <summary>
        /// Si vrai, la fenêtre de plannification présentera
        /// ce profil s'il n'est pas encore affecté.
        /// </summary>
        [TableFieldProperty(c_champAfficherManquantDansPlanning)]
        [DynamicField("Show missing in planner")]
        public bool AfficherManquantDansPlanning
        {
            get
            {
                return (bool)Row[c_champAfficherManquantDansPlanning];
            }
            set
            {
                Row[c_champAfficherManquantDansPlanning] = value;
            }
        }
		
        public void TiagSetTypeInterventionKeys(object[] lstCles)
        {
            CTypeIntervention tpInter = new CTypeIntervention(ContexteDonnee);
            if (tpInter.ReadIfExists(lstCles))
                TypeIntervention = tpInter;
        }
		//-------------------------------------------------------------------
		/// <summary>
		/// Type d'intervention, objet de la relation
		/// </summary>
		[Relation(
			CTypeIntervention.c_nomTable,
			CTypeIntervention.c_champId,
			CTypeIntervention.c_champId,
			true,
			true,
			false)]
		[DynamicField("Intervention type")]
        [TiagRelation(typeof(CTypeIntervention), "TiagSetTypeInterventionKeys")]
		public CTypeIntervention TypeIntervention
		{
			get
			{
				return (CTypeIntervention)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention));
			}
			set
			{
				SetParent(CTypeIntervention.c_champId, value);
			}
		}

		
		//-------------------------------------------------------------------
		/// <summary>
		/// ProfilElement, objet de la relation
		/// </summary>
		[Relation(
			CProfilElement.c_nomTable,
		    CProfilElement.c_champId,
		    CProfilElement.c_champId,
			false,
			true,
			false)]
		[DynamicField("Profile")]
		public CProfilElement ProfilIntervenant
		{
			get
			{
				return (CProfilElement)GetParent(CProfilElement.c_champId, typeof(CProfilElement));
			}
			set
			{
				SetParent(CProfilElement.c_champId, value);
			}
		}



		//---------------------------------------------
		public Type GetTypeAAssocier()
		{
			return typeof(CActeur);
		}


		#region ITypeRelationEntreePlanning_Ressource Membres
		public Type GetTypeRessource()
		{
			return typeof(CActeur);
		}

		public bool IsInCheckListApplique
		{
			get
			{
				return false;
			}
		}

		public Type TypeElementsProfiles
		{
			get
			{
				return typeof(CActeur);
			}
		}

		#endregion

        #region IProfilElement Membres

        public CProfilElement[] TousLesProfilsARemplir
        {
            get
            {
                return new CProfilElement[] {ProfilIntervenant };
            }
        }

        #endregion
    }

}
