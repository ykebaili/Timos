using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

using timos.data;
using timos.acteurs;
using timos.securite;

namespace sc2i.workflow
{

    /// <summary>
    /// Représente une relation entre une EO planifiée et un Acteur
    /// </summary>
    [DynamicClass("Planified OE / Member")]
    [Table(CEOplanifiee_Acteur.c_nomTable, CEOplanifiee_Acteur.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CEOplanifiee_ActeurServeur")]
	[NoRelationTypeId]
    public class CEOplanifiee_Acteur : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete,
								IElementAEO
    {
        public const string c_nomTable = "PLANOE_MEMBER";
        public const string c_champId = "PLANOEMEMBER_ID";
        public const string c_champDate = "PLANOEMEMBER_DATE";

        /// /////////////////////////////////////////////
        public CEOplanifiee_Acteur(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CEOplanifiee_Acteur(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "|");
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }


        
		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty (c_champDate)]
		[DynamicField("Date")]
		public DateTime Date
		{
			get
			{
                return (DateTime)Row[c_champDate];
			}
			set
			{
                Row[c_champDate] = value.Date;
			}
		}



        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CActeur.c_champId,
            true,
            false,
            true)]
        [DynamicField("Member")]
        public CActeur Acteur
        {
            get
            {
                return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
            }
            set
            {
                SetParent(CActeur.c_champId, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CEntiteOrganisationnelle.c_nomTable,
            CEntiteOrganisationnelle.c_champId,
            CEntiteOrganisationnelle.c_champId,
            true,
            false,
            true)]
        [DynamicField("Organisational Entity")]
        public CEntiteOrganisationnelle EntiteOrganisationnelle
        {
            get
            {
                return (CEntiteOrganisationnelle)GetParent(CEntiteOrganisationnelle.c_champId, typeof(CEntiteOrganisationnelle));
            }
            set
            {
                SetParent(CEntiteOrganisationnelle.c_champId, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CHoraireJournalier_Tranche.c_nomTable,
            CHoraireJournalier_Tranche.c_champId,
            CHoraireJournalier_Tranche.c_champId,
            true,
            false,
            true)]
        [DynamicField("Time Slot")]
        public CHoraireJournalier_Tranche TrancheHoraire
        {
            get
            {
                return (CHoraireJournalier_Tranche)GetParent(CHoraireJournalier_Tranche.c_champId, typeof(CHoraireJournalier_Tranche));
            }
            set
            {
                SetParent(CHoraireJournalier_Tranche.c_champId, value);
            }
        }





		#region IElementAEO Membres
		//-----------------------------------------------------------------
		[TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
		[DynamicField("Organisational entities codes")]
		public string CodesEntitesOrganisationnelles
		{
			get
			{
				return (string)Row[CUtilElementAEO.c_champEO];
			}
			set
			{
				Row[CUtilElementAEO.c_champEO] = value;
			}
		}

		//-----------------------------------------------------------------
		public IElementAEO[] DonnateursEO
		{
			get { return null; }
		}

		//-----------------------------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get 
			{
				if (Date.Date == DateTime.Now.Date && Acteur != null)
				{
					double fHeure = DateTime.Now.Hour*60 + DateTime.Now.Minute;
					if (TrancheHoraire != null && TrancheHoraire.HeureDebut <= fHeure &&
						TrancheHoraire.HeureFin >= fHeure)
						return new IElementAEO[] { Acteur };
				}
				return new IElementAEO[0];
			}
		}

		//-----------------------------------------------------------------
		public CListeObjetsDonnees EntiteOrganisationnellesDirectementLiees
		{
			get
			{
				CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CEntiteOrganisationnelle));
				if (EntiteOrganisationnelle != null)
					liste.Filtre = new CFiltreData(CEntiteOrganisationnelle.c_champId + "=@1",
						EntiteOrganisationnelle.Id);
				else
					liste.Filtre = new CFiltreDataImpossible();
				return liste;
			}
		}


        //-----------------------------------------------------------------
        [DynamicMethod(
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        [DynamicMethod(
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }

        //----------------------------------------------------------------
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

		#endregion

		#region IObjetARestrictionSurEntite Membres

		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}
