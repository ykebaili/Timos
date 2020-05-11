using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using timos.data;
using sc2i.expression;

namespace spv.data
{
	[Table(CSpvTypsite.c_nomTable,CSpvTypsite.c_nomTableInDb,new string[]{ CSpvTypsite.c_champTYPSITE_ID})]
	[ObjetServeurURI("CSpvTypsiteServeur")]
	[DynamicClass("SPV site type")]
    [RechercheRapide(CSpvTypsite.c_champTYPSITE_NOM)]
    public class CSpvTypsite : 
        CMappableAvecTimos<CTypeSite, CSpvTypsite>, 
        IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPSITE";
		public const string c_nomTableInDb = "TYPSITE";
		public const string c_champTYPSITE_ID ="TYPSITE_ID";
		public const string c_champTYPSITE_NOM ="TYPSITE_NOM";
		public const string c_champTYPSITE_CLASSID ="TYPSITE_CLASSID";
		public const string c_champTYPSITE_NATURE ="TYPSITE_NATURE";
        public const string c_champSmtTypeSite_Id = "SMTTYPSITE_ID";
        const int c_classID = 1053;		// Type de sites
		
		///////////////////////////////////////////////////////////////
		public CSpvTypsite( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypsite( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Row[c_champTYPSITE_CLASSID] = c_classID;
            Row[c_champTYPSITE_NATURE, true] = ETypeSiteNature.PS;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champTYPSITE_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return ("SPV site type @1|30048");
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPSITE_NOM,40)]
        [DynamicField("Type Site Name")]
		public System.String TypeSiteNom
		{
			get
			{
				return (System.String)Row[c_champTYPSITE_NOM];
            }
            set
			{
                Row[c_champTYPSITE_NOM, true] = value;
			}
				
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPSITE_CLASSID)]
        [DynamicField("Site Class ID")]
		public System.Int32 TypeSiteClassId
		{
			get
			{
                return (System.Int32)Row[c_champTYPSITE_CLASSID];
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPSITE_NATURE)]
        [DynamicField("Type Site nature code")]
        public System.Int32? TypeSiteNatureCode
		{
			get
			{
				if (Row[c_champTYPSITE_NATURE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPSITE_NATURE];
			}
			set
			{
				Row[c_champTYPSITE_NATURE,true]=value;
			}
		}

        ///////////////////////////////////////////////////////////////
        [DynamicField("Type Site nature")]
        public CTypeSiteNature TypeSiteNature
        {
            get
            {
                if (Enum.IsDefined(typeof(ETypeSiteNature), TypeSiteNatureCode))
                {
                    try
                    {
                        return new CTypeSiteNature((ETypeSiteNature)TypeSiteNatureCode);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                TypeSiteNatureCode = (int)value.Code;
            }
        }	
				
		
		///////////////////////////////////////////////////////////////
	/*	[RelationFille(typeof(CSpvDessin),"SpvTypsite")]
		public CListeObjetsDonnees SpvDessins
		{
			get
			{
				return GetDependancesListe(CSpvDessin.c_nomTable,c_champTYPSITE_ID);
			}
		}*/
		
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvSite),"TypeSite")]
		public CListeObjetsDonnees SpvSites
		{
			get
			{
				return GetDependancesListe(CSpvSite.c_nomTable,c_champTYPSITE_ID);
			}
		}


        public override string GetChampIdObjetTimos()
        {
            return c_champSmtTypeSite_Id;
        }


        [Relation(
           CTypeSite.c_nomTable,
           CTypeSite.c_champId,
           c_champSmtTypeSite_Id,
            true,
            true)]
        [DynamicField("Corresponding SMT type site")]
        public override CTypeSite ObjetTimosAssocie
        {
            get
            {
                return ObjetTimosAssocieProtected;
            }
            set
            {
                ObjetTimosAssocieProtected = value;
            }
        }


        public override void CopyFromObjetTimos(CTypeSite objetTimos)
        {
            TypeSiteNom = objetTimos.Libelle;
        }
	}
}
