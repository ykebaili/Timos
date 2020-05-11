using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using timos.data;
using sc2i.expression;
using System.Collections.Generic;

namespace spv.data
{
	[Table(CSpvSite.c_nomTable, CSpvSite.c_nomTableInDb, new string[] { CSpvSite.c_champSITE_ID })]
	[ObjetServeurURI("CSpvSiteServeur")]
	[DynamicClass("Spv Site")]
    [AutoExec("CompleteProprietesSite")]
	[RechercheRapide(CSpvSite.c_champSITE_NOM)]
    public class CSpvSite : 
        CMappableAvecTimos<CSite, CSpvSite>, 
        IObjetSansVersion, 
        ISpvObjetAvecAccesAlarmeCable,
        IElementACoeffOperationnel
	{
		public const string c_nomTable = "SPV_SITE";
		public const string c_nomTableInDb = "SITE";
		public const string c_champSITE_ID = "SITE_ID";
		public const string c_champSITE_NOM = "SITE_NOM";
		public const string c_champSITE_CLASSID = "SITE_CLASSID";
		public const string c_champSITE_DOMAINE = "SITE_DOMAINE";
		public const string c_champSITE_CMNTE = "SITE_CMNTE";
		public const string c_champSITE_EMNAME = "SITE_EMNAME";
        public const string c_champSITE_ECRAN = "SITE_ECRAN";
		public const string c_champTYPSITE_ID = "TYPSITE_ID";
        //may be used later		public const string c_champSITE_TYPEINC = "SITE_TYPEINC";//Nature des sites inclus
		public const string c_champSITE_CODE = "SITE_CODE";
	    public const string c_champSmtSite_Id = "SMTSITE_ID";
        public const int c_classID = 1008;		// Site
        public const int c_ecran = 1;

        public const int c_SiteFuturocom = 1;

 
		///////////////////////////////////////////////////////////////
		public CSpvSite(CContexteDonnee ctx)
			: base(ctx)
		{
            
		}

		//////////////////////////////////////////////////////////////
		public CSpvSite(DataRow row)
			: base(row)
		{
		}

        //////////////////////////////////////////////////////////////
        public static void CompleteProprietesSite()
        {
            CMappableAvecTimos<CSite, CSpvSite>.CompleteProprietesObjetTimos("Supervision datas");
        }

		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			Row[c_champSITE_CLASSID] = c_classID;
            Row[c_champSITE_ECRAN]   = c_ecran;
		}

		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champSITE_ID };
		}

		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Spv Site @1|30043", SiteNom);
			}
		}

        


		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_NOM, 40)]
		[DynamicField("Name")]
		public System.String SiteNom
		{
			get
			{
				return (System.String)Row[c_champSITE_NOM];
			}
			set
			{
				Row[c_champSITE_NOM, true] = value;
			}
		}

		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_CLASSID)]
		[DynamicField("Class ID")]
		public System.Int32 ClassId
        {
			get
			{
                return (System.Int32)Row[c_champSITE_CLASSID];
			}
		}

	    ///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_DOMAINE, 80, NullAutorise = true)]
        [DynamicField("IP Domain")]
		public System.String DomaineIP
		{
			get
			{
				if (Row[c_champSITE_DOMAINE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champSITE_DOMAINE];
			}
			set
			{
				Row[c_champSITE_DOMAINE, true] = value;
			}
		}

		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_CMNTE, 80)]
        [DynamicField("SNMP Community")]
		public System.String SNMP_Community
        {
			get
			{
				if (Row[c_champSITE_CMNTE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champSITE_CMNTE];
			}
			set
			{
				Row[c_champSITE_CMNTE, true] = value;
			}
		}

		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_EMNAME, 80)]
        [DynamicField("Mediation Equipment")]
		public System.String EmName
		{
			get
			{
				if (Row[c_champSITE_EMNAME] == DBNull.Value)
					return null;
				return (System.String)Row[c_champSITE_EMNAME];
			}
			set
			{
				Row[c_champSITE_EMNAME, true] = value;
			}
		}

		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_CODE, 40, NullAutorise=true)]
		[DynamicField("Code")]
		public System.String SiteCode
		{
			get
			{
				if (Row[c_champSITE_CODE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champSITE_CODE];
			}
			set
			{
				Row[c_champSITE_CODE, true] = value;
			}
		}


		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypsite.c_nomTable, new string[] { CSpvTypsite.c_champTYPSITE_ID }, new string[] { CSpvSite.c_champTYPSITE_ID }, false, false)]
		[DynamicField("Spv Site Type")]
		public CSpvTypsite TypeSite
		{
			get
			{
				return (CSpvTypsite)GetParent(new string[] { c_champTYPSITE_ID }, typeof(CSpvTypsite));
			}
			set
			{
				SetParent(new string[] { c_champTYPSITE_ID }, value);
			}
		}
        /*
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvService_NoeudDeGraphe), "SpvSite")]
        [DynamicChilds("Service graph nodes", typeof(CSpvService_NoeudDeGraphe))]
		public CListeObjetsDonnees SpvProg_Opers
		{
			get
			{
				return GetDependancesListe(CSpvService_NoeudDeGraphe.c_nomTable, c_champSITE_ID);
			}
		}*/

	
		
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLiai), "SiteOrigine")]
        [DynamicChilds("Starting links", typeof(CSpvLiai))]
		public CListeObjetsDonnees SpvStartingLiais
		{
			get
			{
                return GetDependancesListe(CSpvLiai.c_nomTable, CSpvLiai.c_champSITE_ORIGID);
			}
		}

				
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvAccesAlarme), "SpvSite")]
        [DynamicChilds("Alarm ports", typeof(CSpvAccesAlarme))]
        public CListeObjetsDonnees AccesAlarme
		{
			get
			{
                return GetDependancesListe(CSpvAccesAlarme.c_nomTable, c_champSITE_ID);
			}
		}

        public CListeObjetsDonnees AccesAlarmeBoucle
        {
            get
            {
                return AccesAlarme;
            }
        }

        public CListeObjetsDonnees AccesAlarmeBoucleNonCable
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvAccesAlarme));
                liste.Filtre = new CFiltreData(CSpvAccesAlarme.c_champSITE_ID + "=@1 AND " +
                                               CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@2 AND " +
                                               CSpvAccesAlarme.c_champACCES_ETAT + " IN (" + CSpvAccesAlarme.c_accesNonCable + ")", this.Id,
                                               (int) ECategorieAccesAlarme.SortieBoucle);
                return liste;
            }
        }


        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvTypeAccesAlarme), "SpvSite")]
        [DynamicChilds("Alarm access types", typeof(CSpvTypeAccesAlarme))]
        public CListeObjetsDonnees SpvTypeAccessAlarm
        {
            get
            {
                return GetDependancesListe(CSpvTypeAccesAlarme.c_nomTable, c_champSITE_ID);
            }
        }

		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLiai), "SiteDestination")]
        [DynamicChilds("Ending links", typeof(CSpvLiai))]
		public CListeObjetsDonnees SpvEndingLiais
		{
			get
			{
                return GetDependancesListe(CSpvLiai.c_nomTable, CSpvLiai.c_champSITE_DESTID);
			}
		}

		/*
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvExt), "SpvSite")]
        [DynamicChilds("Site extremities", typeof(CSpvExt))]
		public CListeObjetsDonnees SpvExts
		{
			get
			{
				return GetDependancesListe(CSpvExt.c_nomTable, c_champSITE_ID);
			}
		}*/

        /*
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvCablequ), "SpvSite")]
        [DynamicChilds("Wirings", typeof(CSpvCablequ))]
        public CListeObjetsDonnees SpvCablequs
		{
			get
			{
				return GetDependancesListe(CSpvCablequ.c_nomTable, c_champSITE_ID);
			}
		}*/

		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvEquip), "SpvSite")]
        [DynamicChilds("SPV equipments", typeof(CSpvEquip))]
		public CListeObjetsDonnees SpvEquips
		{
			get
			{
				return GetDependancesListe(CSpvEquip.c_nomTable, c_champSITE_ID);
			}
		}

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvSite_Rep), "SpvSite")]
        [DynamicChilds("Operational state", typeof(CSpvSite_Rep))]
        public CListeObjetsDonnees SpvSite_Rep
        {
            get
            {
                return GetDependancesListe(CSpvSite_Rep.c_nomTable, c_champSITE_ID);
            }
        }

		
        /*
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvService), "SpvSite")]
        [DynamicChilds("Services", typeof(CSpvService))]
		public CListeObjetsDonnees SpvProgs
		{
			get
			{
				return GetDependancesListe(CSpvService.c_nomTable, c_champSITE_ID);
			}
		}*/


				
        //------------------------------------------------
        public override string GetChampIdObjetTimos()
        {
            return c_champSmtSite_Id;
        }

        ///////////////////////////////////////////////////////////////////////////////
        [Relation(
            CSite.c_nomTable, 
            CSite.c_champId, 
            c_champSmtSite_Id, 
            true, 
            true)]
        [DynamicField("Corresponding SMT site")]
        public override CSite ObjetTimosAssocie
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


        public override void CopyFromObjetTimos(CSite objetTimos)
        {
            SiteNom = objetTimos.Libelle;
            CSpvTypsite spvTypeSite = CSpvTypsite.GetObjetSpvFromObjetTimos(objetTimos.TypeSite);
            this.TypeSite = spvTypeSite;
            //SITE_TYPEINC = site;
            //SiteCode = site.Code == "" ? null : site.Code;
        }


        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme), "SpvSite")]
        [DynamicChilds("Alarm wiring", typeof(CSpvLienAccesAlarme))]
        public CListeObjetsDonnees AlarmesCables
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme.c_nomTable, c_champSITE_ID);
            }
        }

        ///////////////////////////////////////////////////////////////
        public CSpvSite[] SitesPouvantContenirLeCollecteur
        {
            get
            {
                return new CSpvSite[] { this };
            }
        }

        /*
        ///////////////////////////////////////////////////////////////
        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CSpvService_DependanceSite), "SpvSite")]
        [DynamicChilds("Service dependancies", typeof(CSpvService_DependanceSite))]
        public CListeObjetsDonnees DependancesService
        {
            get
            {
                return GetDependancesListe(CSpvService_DependanceSite.c_nomTable, CSpvService_DependanceSite.c_champSITE_ID);
            }
        }*/

        /*
        [RelationFille(typeof(CSpvService_DependanceCablage), "SpvSite")]
        [DynamicChilds("Service wiring dependancies", typeof(CSpvService_DependanceCablage))]
        public CListeObjetsDonnees DependancesCablageService
        {
            get
            {
                return GetDependancesListe(CSpvService_DependanceCablage.c_nomTable, CSpvService_DependanceCablage.c_champSITE_ID);
            }
        }*/

        /*
        [RelationFille(typeof(CSpvService_DependanceCablage_Rep), "SpvSite")]
        [DynamicChilds("Service wiring dependancy state ", typeof(CSpvService_DependanceCablage_Rep))]       
        public CListeObjetsDonnees DependancesCablageServiceRep
        {
            get
            {
                return GetDependancesListe(CSpvService_DependanceCablage_Rep.c_nomTable, CSpvService_DependanceCablage_Rep.c_champSITE_ID);
            }
        }*/


        public string GetName()
        {
            return SiteNom;
        }

        public string GetTypeName()
        {
            return TypeSite.TypeSiteNom;
        }
        
        public CListeObjetsDonnees PrestationsConcernees
        {
            get
            {
                
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvSchemaReseau));
                /*
                string clauseWhere = "DependancesSites." +
                    CSpvService_DependanceSite.c_champSITE_ID + " =@1";            

                liste.Filtre = new CFiltreDataAvance(CSpvService.c_nomTable, clauseWhere, Id );
                int i = liste.Count;
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvSchemaReseau));*/

                string clauseWhere = "ElementsDeGraphe." +
                    CSpvSite.c_champSITE_ID + " =@1";

                liste.Filtre = new CFiltreDataAvance(CSpvSchemaReseau.c_nomTable, clauseWhere, Id);
                
                int i = liste.Count;
                return liste;
            }
        }

        /// <summary>
        /// Retourne le coefficient opérationnel de l'élément
        /// </summary>
        public double CoefficientOperationnel
        {
            get
            {
                CSpvSite_Rep spvSiteRep = new CSpvSite_Rep(ContexteDonnee);
                if (spvSiteRep.ReadIfExists(Id))
                    return spvSiteRep.CoefficientOperationnel;
                return 1.0;
            }
        }
    }

}