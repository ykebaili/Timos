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
	/// L'Etat de cl�ture d'un <see cref="CTicket">Ticket</see> Ticket. Cette information fait partie des
    /// informations de cl�ture obligatoires d'un Ticket.
	/// </summary>
    /// <remarks>
    /// L'�tat de cl�ture d'un ticket est toujours d�riv� d'un �tat de base<br/>
    /// qui indique si les op�rations sp�cifi�es dans le ticket ont �t� r�alis�es, annul�es<br/>
    /// ou si elles ne rentrent pas dans le cadre du contrat.<br/>
    /// L'�tat de base li� � un �tat de cl�ture est � choisir parmi les trois valeurs suivantes :<br/>
    /// <ul>
    /// <li>R�solu : toutes les op�rations pr�vues ont �t� r�alis�es</li>
    /// <li>Annul� : l'ex�cution du ticket a �t� annul�e par l'utilisateur ou le client</li>
    /// <li>Hors contrat : les op�rations � effectuer n'ont pas �t� r�alis�es parce qu'elles<br/>
    /// n'entrent pas dans le cadre du contrat client.</li>
    /// </ul>
    /// </remarks>
	[DynamicClass("Closing state")]
	[Table(CEtatCloture.c_nomTable, CEtatCloture.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CEtatClotureServeur")]
    [Unique(false, "Ce Libell� d'Etat de cloture est d�j� utilis�", CEtatCloture.c_champLibelle)]
    [Unique(false, "Ce Code d'Etat de cloture est d�j� utilis�", CEtatCloture.c_champCode)]
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
		/// Libelle de l'Etat de cl�ture
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
        /// Le code de l'Etat de cl�ture
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
        /// Les Etats de cl�ture de base sont pr�d�finis dans l'Application.<br/>
        /// L'Etat de cl�ture doit se baser sur un des Etats de base suivants:<br/>
        /// <list type="bullet">
        /// <item><term>R�solue</term><description>Code 0</description></item>
        /// <item><term>Annul�</term><description>Code 10</description></item>
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
        /// Obtient ou d�finit l'Etat de base sur lequel l'�tat de cl�ture s'appuie
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
