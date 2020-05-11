using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.doccode;
using tiag.client;

namespace timos.data
{
    /*
    /// <summary>
    /// Ce sont les causes de gel possibles pour une <see cref="CPhaseTicket"> Phase de ticket </see>ou
    ///  pour une <see cref="CIntervention">Intervention</see>.
    /// </summary>
    /// <remarks>Lorsqu'une Phase de Ticket ou une Intervention est gelée, il est obligatoire de saisir
    /// une cause de gel</remarks>
    [DynamicClass("Freezing cause")]
    [Table(CCauseGel.c_nomTable, CCauseGel.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CCauseGelServeur")]
    [Unique(false, "Ce Libellé de Cause de Gel est déjà utilisé", CCauseGel.c_champLibelle)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CCauseGel.c_nomTiag,"Id", true)]
    public class CCauseGel : CObjetDonneeAIdNumeriqueAuto, 
	                         IObjetALectureTableComplete
    {
        public const string c_nomTiag = "Freezing cause";
        public const string c_nomTable = "FREEZ_CAUSE";

		public const string c_champId = "FREEZ_CAUSE_ID";
		public const string c_champLibelle = "FREEZ_CAUSE_LABEL";
		public const string c_champCode = "FREEZ_CAUSE_CODE";

        /// /////////////////////////////////////////////
        public CCauseGel(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CCauseGel(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "Freezing Cause @1|30062",Libelle);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }


        /// <summary>
        /// Le libellé de la Cause de gel<br/>(obligatoire)
        /// </summary>
        [TableFieldProperty(c_champLibelle, 100)]
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


        //-----------------------------------------------------------
        /// <summary>
        /// Le code de la cause de gel<br/>Ce champ n'est pas obligatoire
        /// </summary>
        [TableFieldProperty(c_champCode, 100)]
        [DynamicField("Code")]
        [TiagField("Code")]
        public string Code
        {
            get
            {
                return (string)Row[c_champCode];
            }
            set
            {
                Row[c_champCode] = value;
            }
        }

	}*/
}
