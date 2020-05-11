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


namespace timos.data.supervision
{
    /// <summary>
    /// Catégorie de masquage d'alarme.<br/>
    /// </summary>
    [DynamicClass("Masking Category")]
    [Table(CCategorieMasquageAlarme.c_nomTable, CCategorieMasquageAlarme.c_champId, true)]
    [ObjetServeurURI("CCategorieMasquageAlarmeServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSupervision_ID)]
    public class CCategorieMasquageAlarme : CObjetDonneeAIdNumeriqueAuto, IElementADonneePourMediationSNMP
    {
        public const string c_nomTable = "MASKING_CATEGORY";
        public const string c_champId = "MASKCAT_ID";
        public const string c_champLibelle = "MASKCAT_LABEL";
        public const string c_champPriorite = "MASKCAT_PRIO";
        public const string c_champCode = "MASKCAT_CODE";

        public CCategorieMasquageAlarme(CContexteDonnee contexte)
            : base(contexte)
        {

        }

        public CCategorieMasquageAlarme(DataRow row)
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
        /// Libellé de la catégorie de masquage
        /// </summary>
        [TableFieldProperty(c_champLibelle, 128)]
        [DynamicField("Label")]
        [DescriptionField]
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
        /// Code de la catégorie de masquage, permet de faciliter les statistiques
        /// </summary>
        [TableFieldProperty(c_champCode, 256)]
        [DynamicField("Code")]
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
        /// Niveau de priorité. Si une alarme est potentiellement
        /// concernée par plusieurs masques, c'est celui dont la catégorie
        /// a la plus haute priorité qui est appliqué
        /// </summary>
        [TableFieldProperty(c_champPriorite)]
        [DynamicField("Priority")]
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


        //-------------------------------------------------------------
        public CLocalCategorieMasquageAlarme GetLocalCategorieForSupervision(CMemoryDb database)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);

            CLocalCategorieMasquageAlarme categorie = new CLocalCategorieMasquageAlarme(database);
            if (!categorie.ReadIfExist(Id.ToString(), false))
                categorie.CreateNew(Id.ToString());
            else
                if (!categorie.IsToRead())
                    return categorie;
            categorie.Row[CMemoryDb.c_champIsToRead] = false;
            categorie.Libelle = Libelle;
            categorie.Code = Code;
            categorie.Priorite = Priorite;
            

            return categorie;
        
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
