using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using tiag.client;

namespace spv.data
{
    [Table(CSpvFamille.c_nomTable, CSpvFamille.c_nomTableInDb, new string[] { CSpvFamille.c_champFAMILLE_ID })]
    [ObjetServeurURI("CSpvFamilleServeur")]
    [DynamicClass("Spv Family")]
    public class CSpvFamille : CObjetHierarchique, IObjetSansVersion
    {
        public const string c_nomTable = "SPV_FAMILLE";
        public const string c_nomTableInDb = "FAMILLE";
        public const string c_champFAMILLE_ID = "FAMILLE_ID";
        public const string c_champFAMILLE_BINDINGID = "FAMILLE_BINDINGID";
        public const string c_champFAMILLE_NOM = "FAMILLE_NOM";
        public const string c_champFAMILLE_CLASSID = "FAMILLE_CLASSID";
        public const string c_champFAMILLE_TYPE = "FAMILLE_TYPE";
        public const string c_champFAMILLE_CPTDOC = "FAMILLE_CPTDOC";
        public const string c_champFAMILLE_CRITERE = "FAMILLE_CRITERE";
        public const string c_champCodePartiel = "FAMILLE_PARTIAL_SYSCODE";
        public const string c_champCodeComplet = "FAMILLE_FULL_SYSCODE";
        public const string c_champNiveau = "FAMILLE_LEVEL";

        ///////////////////////////////////////////////////////////////
        public CSpvFamille(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        ///////////////////////////////////////////////////////////////
        public CSpvFamille(DataRow row)
            : base(row)
        {
        }

        ///////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            //TODO : Insérer ici le code d'initalisation
        }

        ///////////////////////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champNiveau, c_champFAMILLE_NOM };
        }

        ///////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Spv family @1|30022",Libelle);
            }
        }

        public override int NbCarsParNiveau
        {
            get
            {
                return 2;
            }
        }
        
        //-------------------------------------------------------------------
        public override string ChampLibelle
        {
            get
            {
                return c_champFAMILLE_NOM;
            }
        }

        //-------------------------------------------------------------------
        public override string ChampCodeSystemePartiel
        {
            get
            {
                return c_champCodePartiel;
            }
        }

        //-------------------------------------------------------------------
        public override string ChampCodeSystemeComplet
        {
            get
            {
                return c_champCodeComplet;
            }
        }

        //-------------------------------------------------------------------
        public override string ChampNiveau
        {
            get
            {
                return c_champNiveau;
            }
        }

        //-------------------------------------------------------------------
        public override string ChampIdParent
        {
            get
            {
                return c_champFAMILLE_BINDINGID;
            }
        }
        
        //-------------------------------------------------------------------
        /// <summary>
        /// Système Code partiel de la famille ( code dans sa famille principale )
        /// </summary>
        [
        TableFieldProperty(c_champCodePartiel, 2),
        DynamicField("Partial system code")
        ]
        [TiagField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get
            {
                string strVal = "";
                if (Row[c_champCodePartiel] != DBNull.Value)
                    strVal = (string)Row[c_champCodePartiel];
                strVal = strVal.Trim().PadLeft(2, '0');
                //return (string)Row[c_champCodePartiel];
                return strVal;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Système : Code complet de la famille, incluant les codes
        /// des familles de niveau supérieur
        /// </summary>
        [TableFieldProperty(c_champCodeComplet, 64)]
        [DynamicField("Full system code")]
        [TiagField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeComplet];
            }
        }

      

        //-------------------------------------------------------------------
        /// <summary>
        /// Niveau de la famille. La famille 'root' est au niveau 0.
        /// </summary>
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


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFAMILLE_NOM, 40)]
        [DynamicField("Family name")]
        [TiagField("Label")]
        [DescriptionField]
        public override System.String Libelle
        {
            get
            {
                return (System.String)Row[c_champFAMILLE_NOM];
            }
            set
            {
                Row[c_champFAMILLE_NOM, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFAMILLE_CLASSID)]
        [DynamicField("Class ID")]
        public System.Double ClassId
        {
            get
            {
                return (System.Double)Row[c_champFAMILLE_CLASSID];
            }
            set
            {
                Row[c_champFAMILLE_CLASSID, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFAMILLE_TYPE)]
        [DynamicField("Type")]
        public System.Int32 Type
        {
            get
            {
                return (System.Int32)Row[c_champFAMILLE_TYPE];
            }
            set
            {
                Row[c_champFAMILLE_TYPE, true] = value;
            }
        }
    }
}
