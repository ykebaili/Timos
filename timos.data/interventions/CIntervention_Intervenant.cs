using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;
using tiag.client;

namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="CIntervention">Intervention</see> et un
	/// <see cref="CActeur">Intervenant</see>
	/// </summary>
	[DynamicClass("Intervention / Operator")]
	[Table(CIntervention_Intervenant.c_nomTable, CIntervention_Intervenant.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CIntervention_IntervenantServeur")]
	[Unique ( true, "Another assocation for this type/Operator/Partner already exists|161", CTypeIntervention.c_champId, CTypeIntervention_ProfilIntervenant.c_champId, CActeur.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CIntervention_Intervenant.c_nomTiag, "Id", true)]
    public class CIntervention_Intervenant : CObjetDonneeAIdNumeriqueAuto, IEntreePlanning_Ressource
	{
        public const string c_nomTable = "INTERVENTION_OPERATOR";
        public const string c_nomTiag = "Intervention/Operator relation";
		
		public const string c_champId = "INTER_OP_ID";

		/// /////////////////////////////////////////////
		public CIntervention_Intervenant( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CIntervention_Intervenant(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Intervention/Operator|160");
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



        public void TiagSetInterventionKeys(object[] lstCles)
        {
            CIntervention inter = new CIntervention(ContexteDonnee);
            if (inter.ReadIfExists(lstCles))
                Intervention = inter;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Intervention, objet de la relation<br/>
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
        [TiagRelation(typeof(CIntervention), "TiagSetInterventionKeys")]
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


        public void TiagSetProfilIntervenantKeys(object[] lstCles)
        {
            CTypeIntervention_ProfilIntervenant profil = new CTypeIntervention_ProfilIntervenant(ContexteDonnee);
            if (profil.ReadIfExists(lstCles))
                RelationProfil = profil;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit le Profil de l'intervenant<br/>
		/// (facultatif)
		/// </summary>
		[Relation(
			CTypeIntervention_ProfilIntervenant.c_nomTable,
		    CTypeIntervention_ProfilIntervenant.c_champId,
		    CTypeIntervention_ProfilIntervenant.c_champId,
			false,
			false,
			false)]
		[DynamicField("Profile relation")]
        [TiagRelation(typeof(CTypeIntervention_ProfilIntervenant), "TiagSetProfilIntervenantKeys")]
		public CTypeIntervention_ProfilIntervenant RelationProfil
		{
			get
			{
				return (CTypeIntervention_ProfilIntervenant)GetParent(CTypeIntervention_ProfilIntervenant.c_champId, typeof(CTypeIntervention_ProfilIntervenant));
			}
			set
			{
				SetParent(CTypeIntervention_ProfilIntervenant.c_champId, value);
			}
		}


        public void TiagSetIntervenantKeys(object[] lstCles)
        {
            CActeur acteur = new CActeur(ContexteDonnee);
            if (acteur.ReadIfExists(lstCles))
                Intervenant = acteur;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'intervenant, objet de la relation<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CActeur.c_nomTable,
			CActeur.c_champId,
			CActeur.c_champId,
			true,
			false,
			true)]
		[DynamicField("Operator")]
        [TiagRelation(typeof(CActeur), "TiagSetIntervenantKeys")]
        public CActeur Intervenant
		{
			get
			{
				return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
			}
			set
			{
                CActeur old = Intervenant;
				SetParent(CActeur.c_champId, value);
                if (old != value && Intervention != null)
                {
                    Intervention.InvalideLeCoutDesSourcesDeCout(true, true);
                }
			}
		}

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
				return Intervenant;
			}
			set
			{
				if (value is CActeur)
					Intervenant = (CActeur)value;
			}
		}
	}
}
