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

namespace timos.data
{
    /// <summary>
    /// Description résumée de CFamilleSymbole
    /// </summary>
    // Donne un nom convivial à la classe CFamilleSymbole
    [DynamicClass("Symbol family")]
    // Definit une table dont le nom est c_nomTable
    [Table(CFamilleSymbole.c_nomTable, CFamilleSymbole.c_champId, true)]
    // Donne le nom de l'objet serveur associé à CFamilleSymbole
    [ObjetServeurURI("CFamilleSymboleServeur")]
    //[sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iSymbole)]
   // [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
   // [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CFamilleSymbole : CObjetHierarchique, IObjetALectureTableComplete
    {

        public const string c_nomTable = "SYMBOL_FAMILY";
        public const string c_champId = "SYMBFAM_ID";
        public const string c_champLibelle = "SYMBFAM_LABEL";

        public const string c_champIdParent = "SYMBFAM_PARENT";
        public const string c_champCodeSystemePartiel = "SYMBFAM_PARTIAL_SYS_CODE";
        public const string c_champCodeSystemeComplet = "SYMBFAM_FULL_SYS_CODE";
        public const string c_champNiveau = "SYMBFAM_LEVEL";


        /// /////////////////////////////////////////////
        public CFamilleSymbole(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CFamilleSymbole(DataRow row)
            : base(row)
        {
        }


        /// /////////////////////////////////////////////
        // Propriété de la classe 
        public override string DescriptionElement
        {
            get
            {
                return I.T("Symbol family @1 |30033",Libelle);
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
        /// Indique le niveau hiérarchique( nombre de parents ) du site
        /// </summary>
        /// <remarks>
        /// Le niveau d'un site sans parent est 0
        /// </remarks>
        [TableFieldProperty(c_champNiveau)]
        [DynamicField("Level")]
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
        /// Indique le code (unique pour son parent) de la famille de symboles
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 4)]
        [DynamicField("Partial system code")]
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
        /// Indique le code complet de la famille de symboles
        /// </summary>
        /// <remarks>
        /// Le code complet est composé du code de l'entité parente, et du code partiel.<BR>
        /// </BR>
        /// </remarks>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeSystemeComplet];
            }
        }


        //-----------------------------------------------------------
        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
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

        //----------------------------------------------------
        //<summary>
        //Qualification Ticket parent dans la hiérarchie
        //</summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdParent,
            false,
            false)]
        [DynamicField("Parent symbol family")]
        public CFamilleSymbole FamilleSymboleParent
        {
            get
            {
                return (CFamilleSymbole)ObjetParent;
            }
            set
            {
                if (value != null)
                    ObjetParent = value;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// FamilleSymbole fille dans la hiérarchie
        /// </summary>
        [RelationFille(typeof(CFamilleSymbole), "FamilleSymboleParent")]
        [DynamicChilds("Child symbol family", typeof(CFamilleSymbole))]
        public CListeObjetsDonnees FamilleSymboleFille
        {
            get
            {
                return ObjetsFils;
            }
        }
    }
}