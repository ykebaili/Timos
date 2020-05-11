using System;
using System.Data;
using sc2i.data;
using sc2i.common;

using timos.data;
using sc2i.expression;

namespace spv.data
{
	[Table(CSpvTypliai.c_nomTable,CSpvTypliai.c_nomTableInDb,new string[]{ CSpvTypliai.c_champTYPLIAI_ID})]
	[ObjetServeurURI("CSpvTypliaiServeur")]
	[DynamicClass("Spv link type")]
    public class CSpvTypliai : 
        CMappableAvecTimos<CTypeLienReseau, CSpvTypliai>, 
        IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPLIAI";
		public const string c_nomTableInDb = "TYPLIAI";
		public const string c_champTYPLIAI_ID ="TYPLIAI_ID";
		public const string c_champTYPLIAI_NOM ="TYPLIAI_NOM";
		public const string c_champTYPLIAI_CLASSID ="TYPLIAI_CLASSID";
		public const string c_champTYPLIAI_DEBITMIN ="TYPLIAI_DEBITMIN";
		public const string c_champTYPLIAI_DEBITMAX ="TYPLIAI_DEBITMAX";
		public const string c_champTYPLIAI_ADMIN ="TYPLIAI_ADMIN";
		public const string c_champTYPLIAI_USE ="TYPLIAI_USE";
		public const string c_champTYPLIAI_UDEBITMIN ="TYPLIAI_UDEBITMIN";
		public const string c_champTYPLIAI_UDEBITMAX ="TYPLIAI_UDEBITMAX";
		public const string c_champTYPLIAI_MODULEMIB ="TYPLIAI_MODULEMIB";
		public const string c_champTYPLIAI_DIFF ="TYPLIAI_DIFF";
		public const string c_champTYPLIAI_RING ="TYPLIAI_RING";
        public const string c_champSmtTypeLienReseau_Id = "SMTTYPELIENRESEAU_ID";
        public const int c_classID = 1003; 
		
		///////////////////////////////////////////////////////////////
		public CSpvTypliai( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypliai( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champTYPLIAI_CLASSID] = 1003;
            Row[c_champTYPLIAI_DEBITMIN] = 0;
            Row[c_champTYPLIAI_DEBITMAX] = 0;
            Row[c_champTYPLIAI_UDEBITMIN] = 0;
            Row[c_champTYPLIAI_UDEBITMAX] = 0;
            Row[c_champTYPLIAI_DIFF] = 0;
            Row[c_champTYPLIAI_RING] = 0;
            Row[c_champTYPLIAI_ADMIN] = 1;
            Row[c_champTYPLIAI_USE] = 0;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champTYPLIAI_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Spv link type @1|30048",Libelle);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_NOM,40)]
        [DynamicField("Label")]
		public System.String Libelle
		{
			get
			{
				return (System.String)Row[c_champTYPLIAI_NOM];
			}
			set
			{
				Row[c_champTYPLIAI_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_CLASSID)]
        [DynamicField("Class ID")]
		public System.Double TYPLIAI_CLASSID
		{
			get
			{
				return (System.Double)Row[c_champTYPLIAI_CLASSID];
			}
			set
			{
				Row[c_champTYPLIAI_CLASSID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_DEBITMIN)]
		[DynamicField("Minimum rate")]
		public System.Double DebitMinimum
		{
			get
			{
				return (System.Double)Row[c_champTYPLIAI_DEBITMIN];
			}
			set
			{
				Row[c_champTYPLIAI_DEBITMIN,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_DEBITMAX)]
		[DynamicField("Maximum rate")]
		public System.Double DebitMaximum
		{
			get
			{
				return (System.Double)Row[c_champTYPLIAI_DEBITMAX];
			}
			set
			{
				Row[c_champTYPLIAI_DEBITMAX,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_ADMIN)]
		[DynamicField("Administrative state")]
		public System.Int32? EtatAdministratif
		{
			get
			{
				if (Row[c_champTYPLIAI_ADMIN] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPLIAI_ADMIN];
			}
			set
			{
				Row[c_champTYPLIAI_ADMIN,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_USE)]
		[DynamicField("Usage state")]
		public System.Int32? EtatUsage
		{
			get
			{
				if (Row[c_champTYPLIAI_USE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPLIAI_USE];
			}
			set
			{
				Row[c_champTYPLIAI_USE,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_UDEBITMIN)]
		[DynamicField("Minimum rate units")]
		public System.Double UnitesDebitMin
		{
			get
			{
				return (System.Double)Row[c_champTYPLIAI_UDEBITMIN];
			}
			set
			{
				Row[c_champTYPLIAI_UDEBITMIN,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_UDEBITMAX)]
		[DynamicField("Maximum rate units")]
		public System.Double UnitesDebitMax
		{
			get
			{
				return (System.Double)Row[c_champTYPLIAI_UDEBITMAX];
			}
			set
			{
				Row[c_champTYPLIAI_UDEBITMAX,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_MODULEMIB,80)]
		[DynamicField("MIB module")]
		public System.String TYPLIAI_MODULEMIB
		{
			get
			{
				if (Row[c_champTYPLIAI_MODULEMIB] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPLIAI_MODULEMIB];
			}
			set
			{
				Row[c_champTYPLIAI_MODULEMIB,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_DIFF)]
		[DynamicField("Broadcasting flag")]
		public System.Int32? IndicateurDiffusion
		{
			get
			{
				if (Row[c_champTYPLIAI_DIFF] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPLIAI_DIFF];
			}
			set
			{
				Row[c_champTYPLIAI_DIFF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_RING)]
		[DynamicField("Ring flag")]
		public System.Int32? IndicateurAnneau
		{
			get
			{
				if (Row[c_champTYPLIAI_RING] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPLIAI_RING];
			}
			set
			{
				Row[c_champTYPLIAI_RING,true]=value;
			}
		}


        ///////////////////////////////////////////////////////////////
        [Relation(
            CTypeLienReseau.c_nomTable,
           CTypeLienReseau.c_champId,
           CSpvTypliai.c_champSmtTypeLienReseau_Id,
            true,
            true,
            false)]
        [DynamicField("Corresponding SMT link type")]
        public CTypeLienReseau TypeLienReseauSmt
        {
            get
            {
                return GetParent(c_champSmtTypeLienReseau_Id, typeof(CTypeLienReseau)) as CTypeLienReseau;
            }
            set
            {
                SetParent(c_champSmtTypeLienReseau_Id, value);
            }
        }
		
	/*	///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvTypliai_Typliai),"SpvTypliai")]
		public CListeObjetsDonnees SpvTypliai_Typliais
		{
			get
			{
				return GetDependancesListe(CSpvTypliai_Typliai.c_nomTable,c_champTYPLIAI_ID);
			}
		}*/
		
				
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLiai), "Typeliaison")]
		public CListeObjetsDonnees SpvLiais
		{
			get
			{
				return GetDependancesListe(CSpvLiai.c_nomTable,c_champTYPLIAI_ID);
			}
		}	
			
		
		///////////////////////////////////////////////////////////////
	/*	[RelationFille(typeof(CSpvTypliai_Typliai),"SpvTypliai")]
		public CListeObjetsDonnees SpvTypliai_Typliais1
		{
			get
			{
				return GetDependancesListe(CSpvTypliai_Typliai.c_nomTable,c_champTYPLIAI_ID);
			}
		}*/
      

        //------------------------------------------------
        public override string GetChampIdObjetTimos()
        {
            return c_champSmtTypeLienReseau_Id;
        }

        ///////////////////////////////////////////////////////////////////////////////
        [Relation(
            CTypeLienReseau.c_nomTable, 
            CTypeLienReseau.c_champId, 
            c_champSmtTypeLienReseau_Id, 
            false, 
            true)]
        [DynamicField("Corresponding SMT link type")]
        public override CTypeLienReseau ObjetTimosAssocie
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

        public override void CopyFromObjetTimos(CTypeLienReseau typeLienReseau)
        {
            CResultAErreur result = CResultAErreur.True;
            result = CanSupervise(typeLienReseau);
            if (!result)
                throw new CExceptionErreur(result.Erreur);                
            Libelle = typeLienReseau.Libelle;
        }

        
        /// <summary>
        /// Indique s'il est possible de superviser un type de lien.
        /// Le result est true si c'est possible, faux avec une erreur sinon.
        /// </summary>
        /// <param name="typeLienReseau"></param>
        /// <returns></returns>
        public static CResultAErreur CanSupervise(CTypeLienReseau typeLienReseau)
        {
            CResultAErreur result = CResultAErreur.True;
            if (typeLienReseau == null)
            {
                result = CResultAErreur.False;
                return result;
            }
            /*if (typeLienReseau.TypeElement1 != typeof(CSite) ||
                typeLienReseau.TypeElement2 != typeof(CSite))
            {
                result.EmpileErreur(I.T("Can only supervise as Site to site link|20006"));
                return result;
            }
            CListeObjetsDonnees liste = new CListeObjetsDonnees(typeLienReseau.ContexteDonnee,
                typeof(CLienReseau));
            liste.Filtre = new CFiltreData(CTypeLienReseau.c_champId + "=@1 and (" +
                CLienReseau.c_champExtremiteSite1 + " is null or " +
                CLienReseau.c_champExtremiteSite2 + " is null)",
                typeLienReseau.Id);
            if ( liste.CountNoLoad > 0 )
            {
                result.EmpileErreur(I.T("Can not supervise that type of link while some existing links are not link to Link end on site|20007"));
            }*/
            return result;
        }
	}
}
