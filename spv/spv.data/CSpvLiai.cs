using System;
using System.Data;
using sc2i.data;
using sc2i.common;

using timos.data;
using sc2i.expression;
using System.Collections.Generic;

namespace spv.data
{
	[Table(CSpvLiai.c_nomTable,CSpvLiai.c_nomTableInDb,new string[]{ CSpvLiai.c_champLIAI_ID})]
	[ObjetServeurURI("CSpvLiaiServeur")]
	[DynamicClass("Spv Network link")]
    [AutoExec("CompleteProprietesLienTimos")]
 //   public class CSpvLiai : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion, ISpvObjetAvecAccesAlarmeCable
    public class CSpvLiai : 
        CMappableAvecTimos<CLienReseau, CSpvLiai>, 
        IObjetSansVersion, 
        ISpvObjetAvecAccesAlarmeCable,
        IElementACoeffOperationnel
	{
		public const string c_nomTable = "SPV_LIAI";
		public const string c_nomTableInDb = "LIAI";
		public const string c_champLIAI_ID ="LIAI_ID";
		public const string c_champLIAI_EXTAID ="LIAI_EXTAID";//Sync Timos
		public const string c_champLIAI_EXTBID ="LIAI_EXTBID";//Sync Timos
		public const string c_champLIAI_DIR ="LIAI_DIR";//Sync Timos
		public const string c_champTYPLIAI_ID ="TYPLIAI_ID";//Sync Timos
		public const string c_champLIAI_NUM ="LIAI_NUM";
		public const string c_champLIAI_CLASSID ="LIAI_CLASSID";
		public const string c_champLIAI_DEBIT ="LIAI_DEBIT";
		public const string c_champLIAI_CDRP ="LIAI_CDRP";
		public const string c_champLIAI_CDRM ="LIAI_CDRM";
		public const string c_champLIAI_CDRS ="LIAI_CDRS";
		public const string c_champLIAI_ADMIN ="LIAI_ADMIN";
		public const string c_champLIAI_OPER ="LIAI_OPER";
		public const string c_champLIAI_USE ="LIAI_USE";
		public const string c_champLIAI_COMMENT ="LIAI_COMMENT";
		public const string c_champSITE_ORIGID ="SITE_ORIGID";//Sync Timos
		public const string c_champSITE_DESTID ="SITE_DESTID";//Sync Timos
		public const string c_champLIAI_MASQUE ="LIAI_MASQUE";
		public const string c_champLIAI_UDEBIT ="LIAI_UDEBIT";
		public const string c_champTYPLIAI_NOM ="TYPLIAI_NOM";
		public const string c_champLIAI_DEBITOCC ="LIAI_DEBITOCC";
		public const string c_champLIAI_DEBITRESER ="LIAI_DEBITRESER";
        public const string c_champLIAI_EQUIPSOURCE = "LIAI_EQUIPORIG";
        public const string c_champLIAI_EQUIPDEST = "LIAI_EQUIPDEST";
        public const string c_champSmtLienReseau_Id = "SMTLIENRESEAU_ID";
        public const int c_classID = 1004;
		
		///////////////////////////////////////////////////////////////
		public CSpvLiai( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvLiai( DataRow row )
			:base(row)
		{
		}

        //////////////////////////////////////////////////////////////
        public static void CompleteProprietesLienTimos()
        {
            CMappableAvecTimos<CLienReseau, CSpvLiai>.CompleteProprietesObjetTimos("Supervision datas");
        }
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Row[c_champLIAI_CLASSID] = c_classID;
            Row[c_champLIAI_DEBIT] = 0;
            Row[c_champLIAI_UDEBIT] = 0;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champLIAI_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Spv network link @1|30025", NomLiaison);
			}
		}


        ///////////////////////////////////////////////////////////////
        // Champ laissé pour compatibilité SPV mais mis à 0 systématiquement
        [TableFieldProperty(c_champLIAI_DEBIT)]
        public int Debit
        {
            get
            {
                return (int)Row[c_champLIAI_DEBIT];
            }
        }

        ///////////////////////////////////////////////////////////////
        // Champ laissé pour compatibilité SPV mais mis à 0 systématiquement
        [TableFieldProperty(c_champLIAI_UDEBIT)]
        public int UniteDebit
        {
            get
            {
                return (int)Row[c_champLIAI_UDEBIT];
            }
        }


		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIAI_DIR)]
		[DynamicField("Link direction code")]
		public int CodeDirection
		{
			get
			{
				return (int)Row[c_champLIAI_DIR];
			}
			set
			{
				Row[c_champLIAI_DIR,true]=value;
			}
		}


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champLIAI_DIR)]
        public bool CodeDirectionBool
        {
            get
            {
                return (bool)Row[c_champLIAI_DIR];
            }
            set
            {
                Row[c_champLIAI_DIR, true] = value;
            }
        }

        
        ///////////////////////////////////////////////////////////////
        [DynamicField("Link direction")]
        public CSensLiaison Direction
        {
            get
            {
                if (Enum.IsDefined(typeof(ESensLiaison), CodeDirection))
                {
                    try
                    {
                        return new CSensLiaison((ESensLiaison)CodeDirection);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeDirection = (int)value.Code;
            }
        }

		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIAI_NUM,20)]
		[DynamicField("Link name")]
		public System.String NomLiaison
		{
			get
			{
				return (System.String)Row[c_champLIAI_NUM];
			}
			set
			{
                if (value.Length > 20)
                    Row[c_champLIAI_NUM] = value.Substring(0, 20);
                else
				    Row[c_champLIAI_NUM,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIAI_CLASSID)]
        [DynamicField("Class ID")]
        public System.Int32 ClassId
		{
			get
			{
                return (System.Int32)Row[c_champLIAI_CLASSID];
			}			
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIAI_CDRP,40, NullAutorise = true)]
		[DynamicField("Leading production center")]
		public System.String CentreDirecteurProduction
		{
			get
			{
				if (Row[c_champLIAI_CDRP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champLIAI_CDRP];
			}
			set
			{
				Row[c_champLIAI_CDRP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champLIAI_CDRM, 40, NullAutorise = true)]
		[DynamicField("Leading maintenance center")]
		public System.String CentreDirecteurMaintenance
		{
			get
			{
				if (Row[c_champLIAI_CDRM] == DBNull.Value)
					return null;
				return (System.String)Row[c_champLIAI_CDRM];
			}
			set
			{
				Row[c_champLIAI_CDRM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champLIAI_CDRS, 40, NullAutorise = true)]
		[DynamicField("Leading monitoring center")]
		public System.String CentreDirecteurSupervision
		{
			get
			{
				if (Row[c_champLIAI_CDRS] == DBNull.Value)
					return null;
				return (System.String)Row[c_champLIAI_CDRS];
			}
			set
			{
				Row[c_champLIAI_CDRS,true]=value;
			}
		}
				
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIAI_MASQUE, true)]
		[DynamicField("Mask alarms")]
		public System.Int32? MasquerAlarmes
		{
			get
			{
				if (Row[c_champLIAI_MASQUE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champLIAI_MASQUE];
			}
			set
			{
				Row[c_champLIAI_MASQUE,true]=value;
			}
		}
		
				
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_NOM,40)]
		[DynamicField("Type link name")]
		public System.String NomTypeLiaison
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

        [DynamicField("Complete link name")]
        public System.String NomComplet
        {
            get
            {
                string strNom;
                /*
                if (ExtremiteA != null)
                    strNom = ExtremiteA.ExtNom;
                else*/
                    strNom = this.SiteOrigine.SiteNom;

                strNom += Direction.Libelle;
                /*
                if (ExtremiteB != null)
                    strNom += ExtremiteB.ExtNom;
                else*/
                    strNom += this.SiteDestination.SiteNom;

                strNom += " " + NomLiaison;
                return strNom;
            }
        }
		/*
		///////////////////////////////////////////////////////////////
		[Relation(
            CSpvExt.c_nomTable,
            CSpvExt.c_champEXT_ID,
            CSpvLiai.c_champLIAI_EXTBID,
            false,
            true)]
		[DynamicField("B end")]
		public CSpvExt ExtremiteB
		{
			get
			{
				return (CSpvExt) GetParent(new string[]{c_champLIAI_EXTBID},typeof(CSpvExt));
			}
			set
			{
				SetParent(new string[]{c_champLIAI_EXTBID}, value);
			}
		}
		*/
		///////////////////////////////////////////////////////////////
		[Relation(
            CSpvSite.c_nomTable,
            CSpvSite.c_champSITE_ID,
            CSpvLiai.c_champSITE_ORIGID,
            false,
            true)]
		[DynamicField("Beginning Site")]
		public CSpvSite SiteOrigine
		{
			get
			{
				return (CSpvSite) GetParent(new string[]{c_champSITE_ORIGID},typeof(CSpvSite));
			}
			set
			{
				SetParent(new string[]{c_champSITE_ORIGID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(
            CSpvSite.c_nomTable,
            CSpvSite.c_champSITE_ID,
            CSpvLiai.c_champSITE_DESTID,
            false,
            true)]
		[DynamicField("Ending Site")]
		public CSpvSite SiteDestination
		{
			get
			{
				return (CSpvSite) GetParent(new string[]{c_champSITE_DESTID},typeof(CSpvSite));
			}
			set
			{
				SetParent(new string[]{c_champSITE_DESTID}, value);
			}
		}

        ///////////////////////////////////////////////////////////////
		[Relation ( 
            CSpvEquip.c_nomTable,
            CSpvEquip.c_champEQUIP_ID,
            CSpvLiai.c_champLIAI_EQUIPSOURCE,
            false,
            true)]
        [DynamicField("Beginning equipment")]
        public CSpvEquip EquipementOrigine
        {
            get
            {
                return GetParent ( c_champLIAI_EQUIPSOURCE, typeof(CSpvEquip)) as CSpvEquip;
            }
            set
            {
                SetParent ( c_champLIAI_EQUIPSOURCE, value );
            }
        }

        ///////////////////////////////////////////////////////////////
        [Relation(
            CSpvEquip.c_nomTable,
            CSpvEquip.c_champEQUIP_ID,
            CSpvLiai.c_champLIAI_EQUIPDEST,
            false,
            true)]
        [DynamicField("Ending equipment")]
        public CSpvEquip EquipementDestination
        {
            get
            {
                return GetParent(c_champLIAI_EQUIPDEST, typeof(CSpvEquip)) as CSpvEquip;
            }
            set
            {
                SetParent(c_champLIAI_EQUIPDEST, value);
            }
        }

		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypliai.c_nomTable,new string[]{CSpvTypliai.c_champTYPLIAI_ID}, new string[]{CSpvLiai.c_champTYPLIAI_ID},true,true, true)]
		[DynamicField("Link type")]
		public CSpvTypliai Typeliaison
		{
			get
			{
				return (CSpvTypliai) GetParent(new string[]{c_champTYPLIAI_ID},typeof(CSpvTypliai));
			}
			set
			{
				SetParent(new string[]{c_champTYPLIAI_ID}, value);
			}
		}
		/*
		///////////////////////////////////////////////////////////////
		[Relation(
            CSpvExt.c_nomTable,
            CSpvExt.c_champEXT_ID, 
            CSpvLiai.c_champLIAI_EXTAID,
            false,
            true)]
		[DynamicField("A end")]
		public CSpvExt ExtremiteA
		{
			get
			{
				return (CSpvExt) GetParent(new string[]{c_champLIAI_EXTAID},typeof(CSpvExt));
			}
			set
			{
				SetParent(new string[]{c_champLIAI_EXTAID}, value);
			}
		}*/
		
		/*
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvService),"SpvLiai")]
        [DynamicChilds("Corresponding services", typeof(CSpvService))]
		public CListeObjetsDonnees EnregistrementProgrammeCorrespondant
		{
			get
			{
                return GetDependancesListe(CSpvService.c_nomTable, CSpvService.c_champPROG_LIAIBOUND);
			}
		}*/
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvLiai_Liaic),"LiaisonSupportee")]
        [DynamicChilds("Supporting links",typeof(CSpvLiai_Liaic))]
		public CListeObjetsDonnees LiaisonsSupportants
		{
			get
			{
				return GetDependancesListe(CSpvLiai_Liaic.c_nomTable,CSpvLiai_Liaic.c_champIdLiaisonSupportée);
			}
		}
        
        //---------------------------------------------
        public CSpvLiai[] TousLesSupportants
        {
            get
            {
                Dictionary<CSpvLiai, bool> dic = new Dictionary<CSpvLiai, bool>();
                FillDicSupportants(dic);
                List<CSpvLiai> lstRetour = new List<CSpvLiai>();
                foreach (CSpvLiai liai in dic.Keys)
                    lstRetour.Add(liai);
                return lstRetour.ToArray();
            }
        }
        
        //---------------------------------------------
        private void FillDicSupportants(Dictionary<CSpvLiai, bool> dic)
        {
            foreach (CSpvLiai_Liaic link in LiaisonsSupportants)
            {
                dic[link.LiaisonSupportant] = true;
                link.LiaisonSupportant.FillDicSupportants(dic);
            }
        }
        
        //---------------------------------------------
        public CSpvLiai[] TousLesSupportes
        {
            get
            {
                Dictionary<CSpvLiai, bool> dic = new Dictionary<CSpvLiai, bool>();
                FillDicSupportes(dic);
                List<CSpvLiai> lstRetour = new List<CSpvLiai>();
                foreach (CSpvLiai liai in dic.Keys)
                    lstRetour.Add(liai);
                return lstRetour.ToArray();
            }
        }
        
        //---------------------------------------------
        private void FillDicSupportes(Dictionary<CSpvLiai, bool> dic)
        {
            foreach (CSpvLiai_Liaic link in LiaisonsSupportées)
            {
                dic[link.LiaisonSupportee] = true;
                link.LiaisonSupportee.FillDicSupportants(dic);
            }
        }
		
	
		/*
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvLiai_Cablequ),"SpvLiai")]
        [DynamicChilds("Wirings",typeof(CSpvLiai_Cablequ))]
		public CListeObjetsDonnees RelationsCablages
		{
			get
			{
				return GetDependancesListe(CSpvLiai_Cablequ.c_nomTable,c_champLIAI_ID);
			}
		}*/
        /*
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Retourne le cablage pour le site donné
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public CSpvLiai_Cablequ GetCablagePourSite ( CSpvSite site )
        {
            foreach ( CSpvLiai_Cablequ cab in RelationsCablages )
            {
                if ( cab.Cablage != null && cab.Cablage.SpvSite != null &&
                    cab.Cablage.SpvSite == site )
                    return cab;
            }
            return null;
        }*/
		
		
				
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvAccesAlarme), "SpvLiai")]
        [DynamicChilds("Alarm ports", typeof(CSpvAccesAlarme))]
        public CListeObjetsDonnees AccesAlarme
		{
			get
			{
				return GetDependancesListe(CSpvAccesAlarme.c_nomTable,c_champLIAI_ID);
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
                liste.Filtre = new CFiltreData(CSpvAccesAlarme.c_champLIAI_ID + "=@1 AND " +
                                               CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@2 AND " +
                                               CSpvAccesAlarme.c_champACCES_ETAT + " IN (" + CSpvAccesAlarme.c_accesNonCable + ")", this.Id,
                                               (int)ECategorieAccesAlarme.SortieBoucle);     
                
                return liste;
            }
        }

		
        
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLiai_Liaic), "LiaisonSupportant")]
        [DynamicChilds("Supported links",typeof(CSpvLiai_Liaic))]
		public CListeObjetsDonnees LiaisonsSupportées
		{
			get
			{
                return GetDependancesListe(CSpvLiai_Liaic.c_nomTable, CSpvLiai_Liaic.c_champIdLiaisonSupportant);
			}
		}
		
						
				
        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvTypeAccesAlarme), "SpvLiai")]
        [DynamicChilds("Alarm access types", typeof(CSpvTypeAccesAlarme))]
        public CListeObjetsDonnees SpvTypeAccessAlarm
        {
            get
            {
                return GetDependancesListe(CSpvTypeAccesAlarme.c_nomTable, c_champLIAI_ID);
            }
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme), "SpvLiai")]
        [DynamicChilds("Alarm wiring", typeof(CSpvLienAccesAlarme))]
        public CListeObjetsDonnees AlarmesCables
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme.c_nomTable, c_champLIAI_ID);
            }
        }

        public CSpvSite[] SitesPouvantContenirLeCollecteur
        {
            get
            {
                List<CSpvSite> lst = new List<CSpvSite>();
                if (SiteOrigine != null)
                    lst.Add(SiteOrigine);
                else if (EquipementOrigine != null && EquipementOrigine.SpvSite != null)
                    lst.Add(EquipementOrigine.SpvSite);
                if (SiteDestination != null)
                    lst.Add(SiteDestination);
                else if (EquipementDestination != null && EquipementDestination.SpvSite != null)
                    lst.Add(EquipementDestination.SpvSite);
                return lst.ToArray();
            }
        }


        public override string GetChampIdObjetTimos()
        {
            return c_champSmtLienReseau_Id;
        }

        public static void CompleteProprietesLienReseau()
        {
            CMappableAvecTimos<CLienReseau, CSpvLiai>.CompleteProprietesObjetTimos("Spv datas");
        }

        ///////////////////////////////////////////////////////////////
        [Relation(
          CLienReseau.c_nomTable,
          CLienReseau.c_champId,
          CSpvLiai.c_champSmtLienReseau_Id,
            true,
            true,
            false,
            IsInDb=false)]
        [DynamicField("Corresponding SMT network link")]
        public override CLienReseau ObjetTimosAssocie
        {
            get
            {
                return GetParent(c_champSmtLienReseau_Id, typeof(CLienReseau)) as CLienReseau;
            }
            set
            {
                SetParent(c_champSmtLienReseau_Id, value);
            }
        }

        public static object GetSpvLiaiFromLienReseau(object objet)
        {
            CLienReseau lienReseau = objet as CLienReseau;
            if (lienReseau != null)
            {
                CSpvLiai spvLiai = new CSpvLiai(lienReseau.ContexteDonnee);
                if (spvLiai.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", lienReseau.Id)))
                    return spvLiai;
            }
            return null;
        }


        public static CResultAErreur SetSpvLiaiFromLienReseau(object objet, object valeur)
        {
            CSpvLiai spvLiai = valeur as CSpvLiai;
            CLienReseau lienReseau = objet as CLienReseau;
            if (spvLiai != null && lienReseau != null)
                spvLiai.ObjetTimosAssocie = lienReseau;
            return CResultAErreur.True;
        }


        public static CSpvLiai GetSpvLiaiFromLienReseauAvecCreation(CLienReseau lienReseau)
        {
            CSpvLiai spvLiai = GetSpvLiaiFromLienReseau(lienReseau) as CSpvLiai;
            if (spvLiai == null)
            {
                spvLiai = new CSpvLiai(lienReseau.ContexteDonnee);
                spvLiai.CreateNewInCurrentContexte();
                spvLiai.ObjetTimosAssocie = lienReseau;
               // spvLiai.CopyFromLienReseau(lienReseau);
                spvLiai.CopyFromObjetTimos(lienReseau);
            }
            return spvLiai;
        }

      //  public void CopyFromLienReseau(CLienReseau lienReseau)
        public override void CopyFromObjetTimos (CLienReseau lienReseau)
        {
            CResultAErreur result = CanSupervise(lienReseau);
            if (!result)
                throw new CExceptionErreur(result.Erreur);
            NomTypeLiaison = lienReseau.TypeLienReseau.Libelle;
            Typeliaison = CSpvTypliai.GetObjetSpvFromObjetTimos(lienReseau.TypeLienReseau) as CSpvTypliai;
            if ( lienReseau.Site1 != null )
                SiteOrigine = CSpvSite.GetObjetSpvFromObjetTimosAvecCreation(lienReseau.Site1);
            if ( lienReseau.Site2 != null )
                SiteDestination = CSpvSite.GetObjetSpvFromObjetTimosAvecCreation(lienReseau.Site2);
            
            if (lienReseau.Equipement1 != null)
                EquipementOrigine = CSpvEquip.GetObjetSpvFromObjetTimosAvecCreation(lienReseau.Equipement1);
            if (lienReseau.Equipement2 != null)
                EquipementDestination = CSpvEquip.GetObjetSpvFromObjetTimosAvecCreation(lienReseau.Equipement2);

            result = UpdateMasquagesEquipements();

            NomLiaison = lienReseau.Libelle;
                    
            switch (lienReseau.Direction.Code)
            {
                case EDirectionLienReseau.UnVersDeux:
                    Direction = new CSensLiaison(ESensLiaison.AVersB);
                    break;
                case EDirectionLienReseau.DeuxVersUn:
                    Direction = new CSensLiaison(ESensLiaison.BVersA);
                    break;
            }
            /*UpdateSupportants();
            UpdateSupportés();*/
        }

        /// <summary>
        /// Sources de masquage liées à cette liaison
        /// </summary>
        [DynamicChilds("Equipment mask source", typeof(CSpvEquip_Msk_Source))]
        [RelationFille(typeof(CSpvEquip_Msk_Source), "LiaiSource")]
        public CListeObjetsDonnees EquipMaskSources
        {
            get
            {
                return GetDependancesListe(CSpvEquip_Msk_Source.c_nomTable, CSpvLiai.c_champLIAI_ID);
            }
        }

        protected CResultAErreur UpdateMasquagesEquipements()
        {
            CResultAErreur result = CResultAErreur.True;
            if (EquipementOrigine == null || EquipementDestination == null)
            {
                //Pas de masquage
                CObjetDonneeAIdNumerique.Delete ( EquipMaskSources, true );
                return result;
            }
            //Trouve le masquage entre ces deux equipements
            CSpvEquip_Msk msk = new CSpvEquip_Msk(ContexteDonnee );
            CFiltreData filtre = new CFiltreData ( CSpvEquip_Msk.c_champEQUIP_MASQUANT_ID+"=@1 and "+
                CSpvEquip_Msk.c_champEQUIP_MASQUE_ID+"=@2",
                EquipementOrigine.Id, EquipementDestination.Id );
            if ( !msk.ReadIfExists ( filtre ) )
            {
                msk.CreateNewInCurrentContexte();
                msk.EquipementMasquant = EquipementOrigine;
                msk.EquipementMasque = EquipementDestination;
            }
            //S'assure que je suis bien source de ce masquage
            CListeObjetsDonnees lstSources = msk.Sources;
            lstSources.Filtre = new CFiltreData ( CSpvLiai.c_champLIAI_ID +"=@1",
                Id );
            if ( lstSources.Count == 0 )
            {
                CSpvEquip_Msk_Source src = new CSpvEquip_Msk_Source(ContexteDonnee);
                src.CreateNewInCurrentContexte();
                src.Equip_Msk = msk;
                src.LiaiSource = this;
            }
            return msk.PropageMasquage();
        }

        public static CResultAErreur CanSupervise ( CLienReseau lienTimos )
        {
            CResultAErreur result = CResultAErreur.True;
            if ( lienTimos == null )
            {
                result = CResultAErreur.False;
                return result;
            }
            if ( lienTimos.TypeLienReseau == null )
            {
                result.EmpileErreur(I.T("Can not supervise a link without type|20008"));
                return result;
            }
            /*if ( lienTimos.Direction.Code != EDirectionLienReseau.DeuxVersUn &&
                lienTimos.Direction.Code != EDirectionLienReseau.UnVersDeux )
            {
                result.EmpileErreur(I.T("Can not supervise a link with '@1' direction|20011", lienTimos.Direction.Libelle));
                return result;
            }*/
            CSpvTypliai typeLiaison = CSpvTypliai.GetObjetSpvFromObjetTimosAvecCreation(lienTimos.TypeLienReseau) as CSpvTypliai;
            //CSpvTypliai typeLiaison = CSpvTypliai.GetSpvTypliaiFromTypeLienReseau ( lienTimos.TypeLienReseau ) as CSpvTypliai;
            if ( typeLiaison == null )
            {
                result.EmpileErreur(I.T("Can not supervise link of type @1|20009", lienTimos.TypeLienReseau.Libelle ));
                return result;
            }
            if ( lienTimos.Element1 == null ||
                lienTimos.Element2 == null )
            {
                result.EmpileErreur(I.T("Can not supervise link without link end|20010"));
                return result;
            }
            return result;
        }
        
        //----------------------------------------------------
        public void UpdateSupportants()
        {
            CLienReseau lienTimos = ObjetTimosAssocie;
            CListeObjetsDonnees supportants = LiaisonsSupportants;
            Dictionary<CSpvLiai, bool> dicSupportantsExistants = new Dictionary<CSpvLiai, bool>();
            foreach (CSpvLiai_Liaic liaiC in supportants)
                dicSupportantsExistants[liaiC.LiaisonSupportant] = true;
            foreach (CLienReseau lienSupportant in lienTimos.LiensSupportants.ToArrayList())
            {
                if (CanSupervise(lienSupportant))
                {
                    CSpvLiai liaiSupportant = CSpvLiai.GetSpvLiaiFromLienReseau(lienSupportant) as CSpvLiai;
                    if (liaiSupportant == null)
                    {
                        liaiSupportant = CSpvLiai.GetSpvLiaiFromLienReseauAvecCreation(lienSupportant);
                        foreach (CSpvLiai_Liaic liaiC in supportants)
                            dicSupportantsExistants[liaiC.LiaisonSupportant] = true;
                    }
                        //Recalcule le dico, car ça a pu bouger
                    if (liaiSupportant != null)
                    {
                        if (!dicSupportantsExistants.ContainsKey(liaiSupportant))
                        {
                            CSpvLiai_Liaic liaic = new CSpvLiai_Liaic(ContexteDonnee);
                            liaic.CreateNewInCurrentContexte(new object[] { Id, liaiSupportant.Id });
                        }
                        else
                            dicSupportantsExistants[liaiSupportant] = false;
                    }
                }
            }
            //Supprime les supportants inutiles
            foreach (CSpvLiai_Liaic supportant in LiaisonsSupportants)
            {
                bool bDelete;
                if (dicSupportantsExistants.TryGetValue(supportant.LiaisonSupportant, out bDelete))
                {
                    if (bDelete)
                         supportant.Delete(true);
                }
            }

        }

        //----------------------------------------------------
        public void UpdateSupportés()
        {
            CLienReseau lienTimos = ObjetTimosAssocie;
            CListeObjetsDonnees supportés = LiaisonsSupportées;
            Dictionary<CSpvLiai, bool> dicSupportésExistants = new Dictionary<CSpvLiai, bool>();
            foreach (CSpvLiai_Liaic liaiC in supportés)
                dicSupportésExistants[liaiC.LiaisonSupportee] = true;
            foreach (CLienReseau lienSupporté in lienTimos.LiensSupportes.ToArrayList())
            {
                if (CanSupervise(lienSupporté))
                {
                    CSpvLiai liaiSupportée = CSpvLiai.GetSpvLiaiFromLienReseau(lienSupporté) as CSpvLiai;
                    if (liaiSupportée == null)
                    {
                        liaiSupportée = CSpvLiai.GetSpvLiaiFromLienReseauAvecCreation(lienSupporté);
                        foreach (CSpvLiai_Liaic liaiC in supportés)
                            dicSupportésExistants[liaiC.LiaisonSupportee] = true;
                    }
                    if (liaiSupportée != null)
                    {
                        if (!dicSupportésExistants.ContainsKey(liaiSupportée))
                        {
                            CSpvLiai_Liaic liaic = new CSpvLiai_Liaic(ContexteDonnee);
                            liaic.CreateNewInCurrentContexte(new object[] {liaiSupportée.Id, Id });
                        }
                        else
                            dicSupportésExistants[liaiSupportée] = false;
                    }
                }
            }
            //Supprime les supportés inutiles
            foreach (CSpvLiai_Liaic supporté in LiaisonsSupportées)
            {
                bool bDelete;
                if (dicSupportésExistants.TryGetValue(supporté.LiaisonSupportee, out bDelete))
                {
                    if (bDelete)
                        supporté.Delete(true);
                }
            }

        }



        /*
        ///////////////////////////////////////////////////////////////
        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CSpvService_DependanceLiaison), "SpvLiai")]
        [DynamicChilds("Service dependancies", typeof(CSpvService_DependanceLiaison))]
        public CListeObjetsDonnees DependancesService
        {
            get
            {
                return GetDependancesListe(CSpvService_DependanceLiaison.c_nomTable, CSpvService_DependanceLiaison.c_champLIAI_ID);
            }
        }*/

        public string GetName()
        {
            return NomLiaison;
        }

        public string GetTypeName()
        {
            return NomTypeLiaison;
        }

        
        public CListeObjetsDonnees PrestationsConcernees
        {
            get
            {
                
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvSchemaReseau));
                /*
                string clauseWhere = "DependancesLiaisons." +
                     CSpvService_DependanceLiaison.c_champLIAI_ID + " =@1";

                liste.Filtre = new CFiltreDataAvance(CSpvService.c_nomTable, clauseWhere, Id);
                */
                return liste;
            }
        }

        /// <summary>
        /// Retourne le coefficient opérationnel de la liaison
        /// </summary>
        public double CoefficientOperationnel
        {
            get 
            {
                CSpvLiai_Rep liaiRep = new CSpvLiai_Rep ( ContexteDonnee );
                if ( liaiRep.ReadIfExists ( Id ) )
                    return liaiRep.CoefficientOperationnel;
                return 1.0;
            }
        }
    }
}
