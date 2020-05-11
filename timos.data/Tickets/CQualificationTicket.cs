using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;

namespace timos.data
{
    /// <summary>
    /// Une qualification de <see cref="CTicket">ticket</see> permet de préciser par exemple la cause de l'ouverture du ticket.<br/>
    /// Le fait de créer des qualifications à priori, permet de normaliser les causes et d'extraire ensuite<br/>
    /// des statistiques sur les tickets en fonction de ces qualifications.<br/>
    /// Une qualification est un objet hiérarchique permettant d'aller du global au détail.<br/>
    /// Exemple : 
    /// FH
    ///     Interférence
    ///     Propagation
    ///     Câbles
    /// Groupe électrogène
    ///     Batterie
    ///     Purge gasoil
    ///     Pompe
    ///     etc.
    /// </summary>
	// Donne un nom convivial à la classe CQualificationTicket
	[DynamicClass("Ticket qualification")]
	// Definit une table dont le nom est c_nomTable
	[Table(CQualificationTicket.c_nomTable, CQualificationTicket.c_champId, true)]
	// Donne le nom de l'objet serveur associé à CQualificationTicket
	[ObjetServeurURI("CQualificationTicketServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    [TiagClass(CQualificationTicket.c_nomTiag, "Id", true)]
    public class CQualificationTicket : CObjetHierarchique, IObjetALectureTableComplete
	{

        public const string c_nomTiag = "Ticket Qualification";
        public const string c_nomTable = "TICKET_QUALIFICATION";
        
        public const string c_champId = "TKTQUAL_ID";
		public const string c_champLibelle = "TKTQUAL_LABEL";

		public const string c_champIdParent = "TKTQUAL_PARENT";
		public const string c_champCodeSystemePartiel = "TKTQUAL_PARTIAL_SYS_CODE";
		public const string c_champCodeSystemeComplet = "TKTQUAL_FULL_SYS_CODE";
		public const string c_champNiveau = "TKTQUAL_LEVEL";


		/// /////////////////////////////////////////////
		public CQualificationTicket(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CQualificationTicket(DataRow row)
			: base(row)
		{
		}


		/// /////////////////////////////////////////////
		// Propriété de la classe 
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Ticket Qualification @1 |218",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			base.MyInitValeurDefaut();
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champLibelle };
		}

		#region CObjetHierarchique


		//----------------------------------------------------
		public override int NbCarsParNiveau
		{
			get
			{
				return 2;
			}
		}

		//----------------------------------------------------
		public override string ChampCodeSystemePartiel
		{
			get
			{
				return c_champCodeSystemePartiel;
			}
		}

		//----------------------------------------------------
		public override string ChampCodeSystemeComplet
		{
			get
			{
				return c_champCodeSystemeComplet;
			}
		}
		//----------------------------------------------------
		/// <summary>
		/// Indique le niveau hiérarchique( nombre de parents ) de la qualification
		/// </summary>
		/// <remarks>
		/// Le niveau d'une qualification sans parent est 0.
        /// Exemple : FH -> Propagation. 'FH' a pour niveau 0, 'Propagation' a pour niveau 1.
		/// </remarks>
		[TableFieldProperty(c_champNiveau)]
		[DynamicField("Level")]
        [TiagField("Level")]
		public override int Niveau
		{
			get
			{
				return (int)Row[c_champNiveau];
			}
		}
		//----------------------------------------------------
		public override string ChampNiveau
		{
			get
			{
				return c_champNiveau;
			}
		}

		//----------------------------------------------------
		public override string ChampLibelle
		{
			get
			{
				return c_champLibelle;
			}
		}

		//----------------------------------------------------
		public override string ChampIdParent
		{
			get
			{
				return c_champIdParent;
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Donne le code système de la Qualification.<br/>
        /// Ce code est unique dans son parent.<br/>
        /// Ce code est exprimé sur 2 caractères alphanumériques.
		/// </summary>
		[TableFieldProperty(c_champCodeSystemePartiel, 4)]
		[DynamicField("Partial system code")]
        [TiagField("Partial system code")]
		public override string CodeSystemePartiel
		{
			get
			{
				string strVal = "";
				if (Row[c_champCodeSystemePartiel] != DBNull.Value)
					strVal = (string)Row[c_champCodeSystemePartiel];
				strVal = strVal.Trim().PadLeft(2, '0');
				return (string)Row[c_champCodeSystemePartiel];
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Indique le code stystème complet de la Qualification
		/// </summary>
		/// <remarks>
		/// Le code système complet est composé :<br/>
        /// du code système complet de la qualification parente,<br/>
        /// et du code système (partiel) de la qualification courante.<br/>
		/// <BR/>
        /// Exemple : FH -> Propagation<br/>
        /// Si 02 est le code complet de 'FH' et 0A le code partiel de 'Propagation',<br/>
        /// 020A est le code système complet de 'Propagation'.<br/>
		/// </remarks>
		[TableFieldProperty(c_champCodeSystemeComplet, 400)]
		[DynamicField("Full system code")]
        [TiagField("Full system code")]
		public override string CodeSystemeComplet
		{
			get
			{
				return (string)Row[c_champCodeSystemeComplet];
			}
		}
		

		//-----------------------------------------------------------
		/// <summary>
		/// Libellé de la qualification
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[RechercheRapide]
        [DescriptionField]
        [TiagField("Label")]
        public override string Libelle
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

		#endregion


        public void TiagSetQualificationParenteKeys(object[] lstCles)
        {
            CQualificationTicket qualif = new CQualificationTicket(ContexteDonnee);
            if (qualif.ReadIfExists(lstCles))
                QualificationTicketParent = qualif;
        }
        //----------------------------------------------------
		///<summary>
		/// Obtient ou définit la Qualification de Ticket parente dans la hiérarchie<br/>
        /// Une qualification de ticket ne peut avoir qu'un seul parent.
		/// </summary>
		[Relation(
		    c_nomTable,
		    c_champId,
		    c_champIdParent,
		    false,
		    false)]
		[DynamicField("Parent ticket qualification")]
        [TiagRelation(typeof(CQualificationTicket), "TiagSetQualificationParenteKeys")]
		public CQualificationTicket QualificationTicketParent
		{
		    get
		    {
		        return (CQualificationTicket)ObjetParent;
		    }
		    set
		    {
		        if (value != null)
		            ObjetParent = value;
		    }
		}

		//----------------------------------------------------
		/// <summary>
		/// Donne la liste des Qualifications de Ticket filles dans la hiérarchie
		/// </summary>
		[RelationFille(typeof(CQualificationTicket), "QualificationTicketParent")]
		[DynamicChilds("Child ticket qualification", typeof(CQualificationTicket))]
		public CListeObjetsDonnees QualificationTicketFils
		{
			get
			{
				return ObjetsFils;
			}
		}
	}
}
