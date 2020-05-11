using System;
using System.Data;
using sc2i.data;
using sc2i.common;


namespace spv.data
{
//	[Table(CSpvAcces.c_nomTable, CSpvAcces.c_nomTableInDb, new string[] { CSpvAcces.c_champACCES_ID })]
//	[ObjetServeurURI("CSpvAccesServeur")]
//	[DynamicClass("SpvAcces")]
//	public class CSpvAcces : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
    public abstract class CSpvAcces : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
//		public const string c_nomTable = "SPV_ACCES";
        public const string c_nomTableInDb = "ACCES";
 //       public const string c_nomTableInDb = "ACCES_VUE";
		public const string c_champACCES_ID = "ACCES_ID";
		public const string c_champACCES_CLASSID = "ACCES_CLASSID";
		public const string c_champACCES_NOM = "ACCES_NOM";
//        public const string c_champACCES_UNICITE = "ACCES_UNICITE";
        public const string c_champACCES_CATEGORIE = "ACCES_TYPE";
        public const string c_champACCES_NATURE = "ACCES_NATURE";
		public const string c_champACCES_ETAT = "ACCES_ETAT";
        public const string c_champACCES_NBCXION = "ACCES_NBCXION";
		public const string c_champACCES_NATCXION = "ACCES_NATCXION";
		public const string c_champACCES_NBOCC = "ACCES_NBOCC";
		public const string c_champACCES_NBMAXOCC = "ACCES_NBMAXOCC";
        public const string c_champTYPEQ_ID = "TYPEQ_ID";
   //     public const string c_champMODELEQUIP_ID = "MODELEQUIP_ID";
        public const string c_champEQUIP_ID = "EQUIP_ID";
   //     public const string c_champACCES_ETAT_BIT0 = "ACCES_ETAT_BIT0";

		///////////////////////////////////////////////////////////////
		public CSpvAcces(CContexteDonnee ctx)
			: base(ctx)
		{
		}

		///////////////////////////////////////////////////////////////
		public CSpvAcces(DataRow row)
			: base(row)
		{
		}

		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            AccesEtat = 0;
		}

		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champACCES_ID };
		}

		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Access @1|30004", NomAcces);
			}
		}
		


        [TableFieldProperty(c_champACCES_CLASSID)]
        [DynamicField("Class Id")]
        public System.Int32 ClassId
        {
            get
            {
                return (System.Int32)Row[c_champACCES_CLASSID];
            }
        }
        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_NOM, 40)]
        [DynamicField("Access name")]
        public System.String NomAcces
        {
            get
            {
                return (System.String)Row[c_champACCES_NOM];
            }
            set
            {
                Row[c_champACCES_NOM, true] = value;
                //CalculeUnicite();
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_CATEGORIE)]
        [DynamicField("Access category code")]
        public int CodeCategorieAcces
        {
            get
            {
                return (int)Row[c_champACCES_CATEGORIE];
            }
            set
            {
                Row[c_champACCES_CATEGORIE] = value;
            }
        }

        


		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCES_ETAT)]
		[DynamicField("Access State")]
		public System.Int32 AccesEtat
		{
			get
			{
				return (System.Int32)Row[c_champACCES_ETAT];
			}
			set
			{
				Row[c_champACCES_ETAT, true] = value;
			}
		}

        

		 ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_NATURE, 10)]
        [DynamicField("Access nature")]
        public System.String Nature
        {
            get
            {
                if (Row[c_champACCES_NATURE] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champACCES_NATURE];
            }
            set
            {
                Row[c_champACCES_NATURE, true] = value;
            }
        }


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_NATCXION, 10)]
        [DynamicField("Access connection nature")]
        public System.String NatureAccesConnexion
        {
            get
            {
                if (Row[c_champACCES_NATCXION] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champACCES_NATCXION];
            }
            set
            {
                Row[c_champACCES_NATCXION, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_NBCXION, NullAutorise = true)]
        [DynamicField("Connections number")]
        public int? ConnectionsNumber
        {
            get
            {
                if (Row[c_champACCES_NBCXION] == DBNull.Value)
                    return null;
                return (int?)Row[c_champACCES_NBCXION];
            }
            set
            {
                Row[c_champACCES_NBCXION, true] = value;
            }
        }

        /*
        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_UNICITE, 70)]
        [DynamicField("Access unicity")]
        public System.String UniciteAcces
        {
            get
            {
                return (System.String)Row[c_champACCES_UNICITE];
            }
        }*/


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_NBMAXOCC)]
        [DynamicField("Max equipment number")]
        public int? MaxOcc
        {
            get
            {
                if (Row[c_champACCES_NBMAXOCC] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champACCES_NBMAXOCC];
            }
            set
            {
                Row[c_champACCES_NBMAXOCC, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        /*
        public virtual void CalculeUnicite()
        {
            Row[c_champACCES_UNICITE] = "//" + NomAcces;
        }*/
	}
}
