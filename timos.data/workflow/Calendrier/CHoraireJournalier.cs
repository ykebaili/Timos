using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace sc2i.workflow
{
	/// <summary>
	/// Un horaire journalier permet de définir aucune, une ou plusieurs tranches horaires.<br/>
    /// <list type="bullet">
    /// <item><term>S'il ne possède pas de tranche horaire cela indique que la journée (de 0H00 à 23H59) n'est pas travaillée.</term></item>
    /// <item><term>S'il possède une ou des tranches horaires, cela indique que la journée est travaillée entre chaque horaire d'ouverture et de fermeture.</term></item>
    /// <item><term>Le recouvrement de deux tranches horaires n'est pas autorisé.</term></item>
    /// </list>
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [DynamicClass("Daily schdule")]
	[Table(CHoraireJournalier.c_nomTable, CHoraireJournalier.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CHoraireJournalierServeur")]
    [Unique(true, "A Daily Schedule using this Label already exist|167", CHoraireJournalier.c_champLibelle)]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_HoraireJournalier_ID)]
    public class CHoraireJournalier : CObjetDonneeAIdNumeriqueAuto,
                                        IObjetALectureTableComplete,
                                        IElementATrancheHoraire
	{
		public const string c_nomTable = "DAILY_SCHEDULE";
		
		public const string c_champId = "DAILYSCH_ID";
		public const string c_champLibelle = "DAILYSCH_LABEL";

		/// /////////////////////////////////////////////
		public CHoraireJournalier( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CHoraireJournalier(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Daily schdule @1|313", Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


		

		////////////////////////////////////////////////
        /// <summary>
        /// Libellé convivial de l'Horaire journalier
        /// </summary>
		[TableFieldProperty(c_champLibelle, 30)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}



        //------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des tranches horaires de cet horaire journalier
        /// </summary>
        [RelationFille(typeof(CHoraireJournalier_Tranche), "HoraireJournalier")]
        [DynamicChilds("Parts", typeof(CHoraireJournalier_Tranche))]
        public CListeObjetsDonnees TranchesHorairesListe
        {
            get
            {
                return GetDependancesListeProgressive(CHoraireJournalier_Tranche.c_nomTable, c_champId);
            }
        }


        //-------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le type d'occupation horaire par défaut de cet horaire journalier
        /// </summary>
        [Relation(
            CTypeOccupationHoraire.c_nomTable,
            CTypeOccupationHoraire.c_champId,
            CTypeOccupationHoraire.c_champId,
            false,
            false,
            true)]
        [DynamicField("Diary occupation type")]
        public CTypeOccupationHoraire TypeOccupationHoraire
        {
            get
            {
                return (CTypeOccupationHoraire)GetParent(CTypeOccupationHoraire.c_champId, typeof(CTypeOccupationHoraire));
            }
            set
            {
                SetParent(CTypeOccupationHoraire.c_champId, value);
            }
        }

		//---------------------------------------------
		public CTypeOccupationHoraire TypeOccupationHoraireAppliquee
		{
			get
			{
				CTypeOccupationHoraire occ = TypeOccupationHoraire;
				return occ;
			}
		}

		//---------------------------------------------
		public IElementATrancheHoraire ElementATrancheHoraireApplique
		{
			get
			{
				return this;
			}
		}




   }
}
