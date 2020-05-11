using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using tiag.client;

namespace timos.data
{
	/// <summary>
	/// L'Etat de clôture d'un <see cref="CTicket">Ticket</see> Ticket. Cette information fait partie des
    /// informations de clôture obligatoires d'un Ticket.
	/// </summary>
    /// <remarks>
    /// L'état de clôture d'un ticket est toujours dérivé d'un état de base<br/>
    /// qui indique si les opérations spécifiées dans le ticket ont été réalisées, annulées<br/>
    /// ou si elles ne rentrent pas dans le cadre du contrat.<br/>
    /// L'état de base lié à un état de clôture est à choisir parmi les trois valeurs suivantes :<br/>
    /// <ul>
    /// <li>Résolu : toutes les opérations prévues ont été réalisées</li>
    /// <li>Annulé : l'exécution du ticket a été annulée par l'utilisateur ou le client</li>
    /// <li>Hors contrat : les opérations à effectuer n'ont pas été réalisées parce qu'elles<br/>
    /// n'entrent pas dans le cadre du contrat client.</li>
    /// </ul>
    /// </remarks>
	[DynamicClass("Closing state")]
	[Table(CEtatCloture.c_nomTable, CEtatCloture.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CEtatClotureServeur")]
    [Unique(false, "Ce Libellé d'Etat de cloture est déjà utilisé", CEtatCloture.c_champLibelle)]
    [Unique(false, "Ce Code d'Etat de cloture est déjà utilisé", CEtatCloture.c_champCode)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    [TiagClass(CEtatCloture.c_nomTiag, "Id", true)]
    public class CEtatCloture : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete
                                
	{
        public const string c_nomTiag = "Closing State";
        public const string c_nomTable = "CLOSING_STATE";
		public const string c_champId = "CLOSINGSTATE_ID";

		public const string c_champLibelle = "CLOSINGSTATE_LABEL";
		public const string c_champCode = "CLOSINGSTATE_CODE";
		public const string c_champEtatBase = "CLOSINGSTATE_BASE";
        
        /// /////////////////////////////////////////////
		public CEtatCloture( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CEtatCloture(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Closing state @1|30063", Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champCode };
		}


        
        //--------------------------------------------------------------------------
		/// <summary>
		/// Libelle de l'Etat de clôture
		/// </summary>
		[TableFieldProperty ( c_champLibelle, 128 )]
		[DynamicField("Label")]
        [DescriptionField]
        [TiagField("Label")]
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


        //---------------------------------------------------------------------------
        /// <summary>
        /// Le code de l'Etat de clôture
        /// </summary>
        [TableFieldProperty(c_champCode)]
        [DynamicField("Code")]
        [TiagField("Code")]
        public int Code
        {
            get
            {
                return (int)Row[c_champCode];
            }
            set
            {
                Row[c_champCode] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Les Etats de clôture de base sont prédéfinis dans l'Application.<br/>
        /// L'Etat de clôture doit se baser sur un des Etats de base suivants:<br/>
        /// <list type="bullet">
        /// <item><term>Résolue</term><description>Code 0</description></item>
        /// <item><term>Annulé</term><description>Code 10</description></item>
        /// <item><term>Hors Contrat</term><description>Code 20</description></item>
        /// </list>
        /// </summary>
        [TableFieldProperty(c_champEtatBase)]
        [DynamicField("Base state code")]
        [TiagField("Base state code")]
        public int EtatBaseInt
        {
            get
            {
                return (int)Row[c_champEtatBase];
            }
            set
            {
                Row[c_champEtatBase] = value;
            }
        }

        /// <summary>
        /// Obtient ou définit l'Etat de base sur lequel l'état de clôture s'appuie
        /// </summary>
        [DynamicField("Base state")]
        public CEtatClotureBase EtatBase
        {
            get
            {
                return new CEtatClotureBase((EtatClotureBase)EtatBaseInt);
            }
            set
            {
                if (value != null)
                    EtatBaseInt = value.CodeInt;
            }
        }
    }
}
