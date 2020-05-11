using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using System.Data;
using System.Drawing;
using futurocom.supervision;
using sc2i.common.memorydb;
using timos.data.snmp;
using tiag.client;


namespace timos.data.supervision
{
    /// <summary>
    /// La sévérité d'alarme permet de définir le niveau de criticité d'une alarme;<br/>
    /// En fonction du niveau de priorité associé, les liens et les équipements<br/>,
    /// concernés par une alarme de cette sévérité sont déclarés hors service<br/>
    /// (priorité > 49) ou non.<br/>
    /// A la sévérité est associée une couleur qui sera la couleur d'affichage des alarmes<br/>
    /// de cette sévérité, dans les vues de supervision (listes et vues graphiques).
    /// </summary>
    [DynamicClass("Alarme Severity")]
    [Table(CSeveriteAlarme.c_nomTable, CSeveriteAlarme.c_champId, true)]
    [ObjetServeurURI("CSeveriteAlarmeServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSupervision_ID)]
    [TiagClass("Alarm severity", "Id", true)]
    public class CSeveriteAlarme : CObjetDonneeAIdNumeriqueAuto, IElementADonneePourMediationSNMP
    {
        public const string c_nomTable = "ALARM_SEVERITY";
        public const string c_champId = "ALRMSEVERITY_ID";
        public const string c_champLibelle = "ALRMSEVERITY_LABEL";
        public const string c_champPriorite = "ALRMSEVERITY_PRIO";
        public const string c_champCode = "ALRMSEVERITY_CODE";
        public const string c_champCodeCouleur = "ALRMSEVERITY_COLOR";

        public CSeveriteAlarme(CContexteDonnee contexte)
            : base(contexte)
        {

        }

        public CSeveriteAlarme(DataRow row)
            : base(row)
        {

        }

        //-----------------------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Alarm Severity @1|10023", Libelle);
            }
        }

        //-----------------------------------------------------------
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champPriorite };
        }

        //-----------------------------------------------------------
        protected override void MyInitValeurDefaut()
        {
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Libellé de la sévérité
        /// </summary>
        [TableFieldProperty(c_champLibelle, 128)]
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
        /// Code de la sévérité (pour faciliter les statistiques)
        /// </summary>
        [TableFieldProperty(c_champCode, 256)]
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

        //-----------------------------------------------------------
        /// <summary>
        /// Niveau de priorité; si > 49, une alarme de cette sévérité
        /// fait que l'équipement ou le lien associé est déclaré hors service.
        /// </summary>
        [TableFieldProperty(c_champPriorite)]
        [DynamicField("Priority")]
        [TiagField("Priority")]
        public int Priorite
        {
            get
            {
                return (int)Row[c_champPriorite];
            }
            set
            {
                Row[c_champPriorite] = value;
            }
        }

        //-----------------------------------------------------------
        public bool IsHS
        {
            get
            {
                return CConvertisseurSeveriteAlarmeToHs.IsPrioriteSeveriteHS(Priorite);
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Code couleur associé, utilisé pour l'affichage des alarmes<br/>
        /// de cette sévérité
        /// </summary>
        [TableFieldProperty(c_champCodeCouleur)]
        [DynamicField("Color Code")]
        public int CouleurInt
        {
            get
            {
                return (int)Row[c_champCodeCouleur];
            }
            set
            {
                Row[c_champCodeCouleur] = value;
            }
        }

        //------------------------------------------------------------
        /// <summary>
        /// Couleur d'affichage des alarmes de cette sévérité
        /// </summary>
        [DynamicField("Color")]
        public Color Couleur
        {
            get
            {
                return Color.FromArgb(CouleurInt);
            }
            set
            {
                CouleurInt = value.ToArgb();
            }
        }



        //-------------------------------------------------------------
        public CLocalSeveriteAlarme GetTypeForSupervision(CMemoryDb database)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);

            CLocalSeveriteAlarme severite = new CLocalSeveriteAlarme(database);
            if (!severite.ReadIfExist(Id.ToString(), false))
                severite.CreateNew(Id.ToString());
            else
                if (!severite.IsToRead())
                    return severite;
            severite.Row[CMemoryDb.c_champIsToRead] = false;
            severite.Libelle = Libelle;
            severite.Code = Code;
            severite.Priorite = Priorite;
            severite.CouleurInt = CouleurInt;

            return severite;
        
        }

        //------------------------------------------------------
        /// <summary>
        /// Mise à jour de tous les agents
        /// </summary>
        public int[] IdsProxysConcernesParDonneesMediation
        {
            get { return null; }
        }

        //------------------------------------------
        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                return new int[0];
            }
        }
    }



}
