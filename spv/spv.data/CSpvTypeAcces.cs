using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	public abstract class CSpvTypeAcces : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTableInDb = "ACCES";
		public const string c_champACCES_ID = "ACCES_ID";
		public const string c_champACCES_CLASSID = "ACCES_CLASSID";
		public const string c_champACCES_NOM = "ACCES_NOM";
		public const string c_champACCES_CATEGORIE = "ACCES_TYPE";
		public const string c_champACCES_NATURE = "ACCES_NATURE";
		public const string c_champACCES_NBCXION = "ACCES_NBCXION";
		public const string c_champACCES_NATCXION = "ACCES_NATCXION";
//		public const string c_champACCES_UNICITE = "ACCES_UNICITE";
		public const string c_champACCES_NBMAXOCC = "ACCES_NBMAXOCC";
    //    public const string c_champACCES_ETAT = "ACCES_ETAT";
        

		///////////////////////////////////////////////////////////////
		public CSpvTypeAcces(CContexteDonnee ctx)
			: base(ctx)
		{
		}

		///////////////////////////////////////////////////////////////
		public CSpvTypeAcces(DataRow row)
			: base(row)
		{
		}

        ///////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
     //       Row[c_champACCES_ETAT] = 0;
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
                NomAccesChanged(value);
			}
		}

        protected virtual void NomAccesChanged(System.String nom)
        {
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
                CodeCategorieAccesChanged();
			}
		}

		///////////////////////////////////////////////////////////////
		[DynamicField("Acces Category")]
		public CCategorieAccesAlarme CategorieAccesAlarme
		{
			get
			{
                if (Enum.IsDefined(typeof(ECategorieAccesAlarme), CodeCategorieAcces))
				{
					try
					{
                        return new CCategorieAccesAlarme((ECategorieAccesAlarme)CodeCategorieAcces);
					}
					catch
					{
					}
				}
				return null;
			}
			set
			{
                if(value!=null)
				    CodeCategorieAcces = (int)value.Code;                
			}
		}

        protected virtual void CodeCategorieAccesChanged()
        {
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
		[DynamicField("Access connexion nature")]
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
                if (Row[c_champACCES_UNICITE] == DBNull.Value)
                    return null;
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
		}*/


		/*
        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_ETAT)]
        [DynamicField("Access type State")]
        public System.Int32 TypeAccesEtat
        {
            get
            {
                return (System.Int32)Row[c_champACCES_ETAT];
            }
            set
            {
                Row[c_champACCES_ETAT, true] = value;
            }
        }*/

	}
}
