using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.common;
using timos.data;
using sc2i.expression;

namespace spv.data
{
	[Table(CSpvTypeq.c_nomTable,CSpvTypeq.c_nomTableInDb,new string[]{ CSpvTypeq.c_champTYPEQ_ID})]
	[ObjetServeurURI("CSpvTypeqServeur")]
	[DynamicClass("Spv Equipment Typeq")]
    [AutoExec("Autoexec")]
	public class	CSpvTypeq : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPEQ";
		public const string c_nomTableInDb = "TYPEQ";
		public const string c_champTYPEQ_ID ="TYPEQ_ID";
		public const string c_champTYPEQ_NOM ="TYPEQ_NOM";
		public const string c_champTYPEQ_CLASSID ="TYPEQ_CLASSID";
		public const string c_champTYPEQ_COMMUT ="TYPEQ_COMMUT";
		public const string c_champTYPEQ_REFSNMP ="TYPEQ_REFSNMP";
		public const string c_champTYPEQ_BSYMBVIEW ="TYPEQ_BSYMBVIEW";
		public const string c_champTYPEQ_TOSURV ="TYPEQ_TOSURV";
		public const string c_champCOMMUT_OID ="COMMUT_OID";
		public const string c_champTYPEQ_IDENTOID ="TYPEQ_IDENTOID";
		public const string c_champTYPEQ_IDENTVALEUR ="TYPEQ_IDENTVALEUR";
		public const string c_champTYPEQ_IDENTNOM ="TYPEQ_IDENTNOM";
		public const string c_champTYPEQ_MIBAUTO ="TYPEQ_MIBAUTO";
        public const string c_champSmtTypeEquipement_Id = "SMTTYPEEQUIPEMENT_ID";
        public const string c_champTYPEQ_NEWDECOUVERT = "TYPEQ_NEWDECOUVERT";

        const int c_classID = 1024;		// Type d'équipement
        const int c_ExistSymbole = 1;   // La vue symbolique existe

		public const string c_SATURNE_IS = "SATURNE IS";
		public const string c_IP2PORT = "IP2PORT";
		public const string c_GSITE = "GSITE";
		public const string c_CARTE_GTR = "CARTE GTR";
		public const string c_strTypeEquipMediation = "EQUIP MEDIATION";

		public const Int32 c_TypeEquipMediationId = 3;
        public const Int32 c_TypeCarteGTRId = 1;
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq( DataRow row )
			:base(row)
		{
		}

        ///////////////////////////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireProprietesAjoutees.RegisterDynamicField(
                typeof(CTypeEquipement),
                "Supervision data",
                new CTypeResultatExpression(typeof(CSpvTypeq), false),
                new GetDynamicValueDelegate(GetSpvTypeqFromTypeEquipement),
                null, "");
        }		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champTYPEQ_CLASSID] = c_classID;
            FlagVueSymbolique = c_ExistSymbole;       // vue symbolique existe
			TypeCommutateur = EGenreCommutateur.NotCommut;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champTYPEQ_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("SPV Equipment type @30043", Libelle);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_NOM,40)]
		[DynamicField("Label")]
		public System.String Libelle
		{
			get
			{
				return (System.String)Row[c_champTYPEQ_NOM];
			}
			set
			{
				Row[c_champTYPEQ_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_CLASSID)]
		[DynamicField("Class ID")]
		public System.Int32 TYPEQ_CLASSID
		{
			get
			{
				return (System.Int32)Row[c_champTYPEQ_CLASSID];
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_COMMUT)]
		[DynamicField("Switch type")]
        public EGenreCommutateur TypeCommutateur
		{
			get
			{
                if (Row[c_champTYPEQ_COMMUT] == DBNull.Value)
                    return 0;
                return (EGenreCommutateur)Row[c_champTYPEQ_COMMUT];
			}
			set
			{
				Row[c_champTYPEQ_COMMUT,true]=value;
			}
		}

		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_REFSNMP,256)]
		[DynamicField("Snmp reference")]
		public System.String ReferenceSnmp
		{
			get
			{
				if (Row[c_champTYPEQ_REFSNMP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_REFSNMP];
			}
			set
			{
				Row[c_champTYPEQ_REFSNMP,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_BSYMBVIEW)]
        [DynamicField("Symbolic view flag")]
		public System.Int32 FlagVueSymbolique
		{
			get
			{
				return (System.Int32)Row[c_champTYPEQ_BSYMBVIEW];
			}
			set
			{
				Row[c_champTYPEQ_BSYMBVIEW,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_TOSURV)]
		[DynamicField("To supervise flag")]
		public bool ASurveiller
		{
			get
			{
				if (Row[c_champTYPEQ_TOSURV] == DBNull.Value)
					return false;
				return (bool) Row[c_champTYPEQ_TOSURV];
			}
			set
			{
				Row[c_champTYPEQ_TOSURV,true] = value;
			}
		}

        [TableFieldProperty(c_champTYPEQ_NEWDECOUVERT)]
        [DynamicField("Just discovered")]
        public bool NouvellementDecouvert
        {
            get
            {
                if (Row[c_champTYPEQ_NEWDECOUVERT] == DBNull.Value)
                    return false;
                return (bool)Row[c_champTYPEQ_NEWDECOUVERT];
            }
            set
            {
                Row[c_champTYPEQ_NEWDECOUVERT, true] = value;
            }
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCOMMUT_OID,128)]
		[DynamicField("Snmp switch OID")]
		public System.String OIDCommutateur
		{
			get
			{
				if (Row[c_champCOMMUT_OID] == DBNull.Value)
					return null;
				return (System.String)Row[c_champCOMMUT_OID];
			}
			set
			{
				Row[c_champCOMMUT_OID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_IDENTOID,128)]
		[DynamicField("Snmp identifier OID")]
		public System.String OIDIdentifiantSnmp
		{
			get
			{
				if (Row[c_champTYPEQ_IDENTOID] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_IDENTOID];
			}
			set
			{
				Row[c_champTYPEQ_IDENTOID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_IDENTVALEUR,256)]
		[DynamicField("Snmp identifier value")]
		public System.String ValeurIdentifiantSnmp
		{
			get
			{
				if (Row[c_champTYPEQ_IDENTVALEUR] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_IDENTVALEUR];
			}
			set
			{
				Row[c_champTYPEQ_IDENTVALEUR,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_IDENTNOM,128)]
		[DynamicField("Snmp identifier name")]
		public System.String NomIdentifiantSnmp
		{
			get
			{
				if (Row[c_champTYPEQ_IDENTNOM] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_IDENTNOM];
			}
			set
			{
				Row[c_champTYPEQ_IDENTNOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_MIBAUTO)]
		[DynamicField("Automatic OID search flag")]
		public bool ChercheOIDParMIB
		{
			get
			{
				if (Row[c_champTYPEQ_MIBAUTO] == DBNull.Value)
					return false;
                return (bool) Row[c_champTYPEQ_MIBAUTO];
			}
			set
			{
                Row[c_champTYPEQ_MIBAUTO, true] = value;
			}
		}

       		
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvTypeAccesAlarme), "SpvTypeq")]
        [DynamicChilds("Alarm access type", typeof(CSpvTypeAccesAlarme))]
		public CListeObjetsDonnees TypesAccesAlarme
		{
			get
			{
				return GetDependancesListe(CSpvTypeAccesAlarme.c_nomTable,c_champTYPEQ_ID);
			}
		}
        /*
        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvTypeAccesTrans), "SpvTypeq")]
        [DynamicChilds("Transmission access type", typeof(CSpvTypeAccesTrans))]
        public CListeObjetsDonnees TypesAccesTrans
        {
            get
            {
                return GetDependancesListe(CSpvTypeAccesTrans.c_nomTable, c_champTYPEQ_ID);
            }
        }*/
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvTypeq_Alarm),"SpvTypeq")]
        [DynamicChilds("Equipment type polling parameters", typeof(CSpvTypeq_Alarm))]
		public CListeObjetsDonnees SpvTypeq_Alarms
		{
			get
			{
				return GetDependancesListe(CSpvTypeq_Alarm.c_nomTable,c_champTYPEQ_ID);
			}
		}
		
		
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvTypeq_Mibmodule),"SpvTypeq")]
        [DynamicChilds("MIB modules", typeof(CSpvTypeq_Mibmodule))]
		public CListeObjetsDonnees TypeqModulesMIB
		{
			get
			{
				return GetDependancesListe(CSpvTypeq_Mibmodule.c_nomTable,c_champTYPEQ_ID);
			}
		}

        public ArrayList ModulesMIB
        {
            get
            {
                ArrayList arMibModule = new ArrayList();
                foreach (CSpvTypeq_Mibmodule typeqMib in TypeqModulesMIB)
                {
                    arMibModule.Add(typeqMib.SpvMibmodule);
                }

                return arMibModule;
            }
        }
		
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvEquip), "TypeEquipement")]
        [DynamicChilds("Equipments", typeof(CSpvEquip))]
		public CListeObjetsDonnees Equipements
		{
			get
			{
				return GetDependancesListe(CSpvEquip.c_nomTable,c_champTYPEQ_ID);
			}
		}
		
				
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvEquip), "TypeEquipementEnglobant")]
        [DynamicChilds("Contained equipments", typeof(CSpvEquip))]
		public CListeObjetsDonnees EquipementsEnglobes
		{
			get
			{
                return GetDependancesListe(CSpvEquip.c_nomTable, CSpvEquip.c_champTYPEQ_BINDINGID);
			}
		}
		

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvTypeqinc), "TypeEquipementEnglobant")]
        [DynamicChilds("Included SNMP families", typeof(CSpvTypeqinc))]
        public CListeObjetsDonnees SousFamillesSnmpIncluses
        {
            get
            {
                return GetDependancesListe(CSpvTypeqinc.c_nomTable, c_champTYPEQ_ID);
            }
        }


        [RelationFille(typeof(CSpvTypeqinc), "TypeEquipementAttache")]
        [DynamicChilds("Attached SNMP families", typeof(CSpvTypeqinc))]
        public CListeObjetsDonnees SousFamillesSnmpAttachees
        {
            get
            {
                return GetDependancesListe(CSpvTypeqinc.c_nomTable, CSpvTypeqinc.c_champTYPEQ2_ID);
            }
        }
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvTypeq_Typeq),"SpvTypeq")]
        [DynamicChilds("Contained types", typeof(CSpvTypeq_Typeq))]
		public CListeObjetsDonnees TypesInclus
		{
			get
			{
                return GetDependancesListe(CSpvTypeq_Typeq.c_nomTable, CSpvTypeq_Typeq.c_champTYPEQ_BINDINGID);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvTypeq_Typeq),"SpvTypeq1")]
        [DynamicChilds("Container types", typeof(CSpvTypeq_Typeq))]
		public CListeObjetsDonnees TypesEnglobant
		{
			get
			{
				return GetDependancesListe(CSpvTypeq_Typeq.c_nomTable,c_champTYPEQ_ID);
			}
		}
		

        ///////////////////////////////////////////////////////////////
		[Relation ( 
			CTypeEquipement.c_nomTable,
			CTypeEquipement.c_champId,
			CSpvTypeq.c_champSmtTypeEquipement_Id,
			true,
			true,
			false)]
		[DynamicField("Corresponding SMT equipment type")]
        public CTypeEquipement TypeEquipementSmt
        {
            get
            {
				return GetParent(c_champSmtTypeEquipement_Id, typeof(CTypeEquipement)) as CTypeEquipement;
            }
            set
            {
				SetParent(c_champSmtTypeEquipement_Id, value);
            }
        }

        
        ///////////////////////////////////////////////////////////////
        public static void CompleteProprietesTypeEquipement()
        {
            CGestionnaireProprietesAjoutees.RegisterDynamicField(
                typeof(CTypeEquipement),
                "Spv datas",
                new CTypeResultatExpression(typeof(CSpvTypeq), false),
                new GetDynamicValueDelegate(GetSpvTypeqFromTypeEquipement),
                new SetDynamicValueDelegate(SetSpvTypeqFromTypeEquipement), "");
        }

        public static object GetSpvTypeqFromTypeEquipement(object objet)
        {
            CTypeEquipement typeEquipement = objet as CTypeEquipement;
            if (typeEquipement != null)
            {
                CSpvTypeq spvTypeq = new CSpvTypeq(typeEquipement.ContexteDonnee);
                if (spvTypeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeEquipement.Id)))
                    return spvTypeq;
            }
            return null;
        }

        public static CResultAErreur SetSpvTypeqFromTypeEquipement(object objet, object valeur)
        {
            CSpvTypeq spvTypeq = valeur as CSpvTypeq;
            CTypeEquipement typeEquipement = objet as CTypeEquipement;
            if (spvTypeq != null && typeEquipement != null)
                spvTypeq.TypeEquipementSmt = typeEquipement;
            return CResultAErreur.True;
        }

        public static CSpvTypeq GetSpvTypeqFromTypeEquipementAvecCreation(CTypeEquipement typeEquipement)
        {
            CSpvTypeq spvTypeq = GetSpvTypeqFromTypeEquipement(typeEquipement) as CSpvTypeq;
            if (spvTypeq == null)
            {
                spvTypeq = new CSpvTypeq(typeEquipement.ContexteDonnee);
                spvTypeq.CreateNewInCurrentContexte();
                //spvTypeq.SiteSmt = site;
                spvTypeq.TypeEquipementSmt = typeEquipement;
                spvTypeq.CopyFromTypeEquipement(typeEquipement);
            }
            return spvTypeq;
        }


        /// <summary>
        /////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="typeEquipement"></param>
        public void CopyFromTypeEquipement(CTypeEquipement typeEquipement)
        {
            Libelle = typeEquipement.Libelle;
        }


        public CResultAErreur MibAuto()
        {
            CResultAErreur result = CResultAErreur.True;

            if (ChercheOIDParMIB && NomIdentifiantSnmp != null && NomIdentifiantSnmp.Length > 0 && TypeqModulesMIB.Count > 0)
            {
                CSpvMibobj mibObj = CSpvMibmodule.GetVariable(ContexteDonnee, NomIdentifiantSnmp, (CSpvMibmodule[])ModulesMIB.ToArray(typeof(CSpvMibmodule)));
                
                if (mibObj != null)
                    OIDIdentifiantSnmp = mibObj.OidObjet;
                else
                    result.EmpileErreur(I.T("<Secondary (Name)> not found (SNMP identification) in the MIBs associated with the equipement type|50005"));
            }
            return result;
        }


        /// <summary>
        /// Permet, lors des effacements, de récupérer l'ancien enregistrement
        /// afin de pouvoir déclencher les traitements métier en rapport
        /// avec celui-ci
        /// </summary>
        /// <param name="typeqEquipementId">ID du type d'équipement SMT</param>
        public Int32 GetOriginalTypeqId(Int32 typeqEquipementId, CContexteDonnee ctx)
        {
            Int32 nTypeqId = -1;        // ID du type SPV
 
            CListeObjetsDonnees liste = new CListeObjetsDonnees(ctx, typeof(CSpvTypeq));
            liste.InterditLectureInDB = true;
            liste.RowStateFilter = DataViewRowState.Deleted;
            liste.Filtre = new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeqEquipementId);
            if (liste.Count == 1)
            {
                CSpvTypeq spvTypeq = (CSpvTypeq)liste[0];
                nTypeqId = (Int32) spvTypeq.Row[CSpvTypeq.c_champSmtTypeEquipement_Id, DataRowVersion.Original];
            }

            return nTypeqId;
        }


        /// <summary>
        /// Indique si le type d'équipement SPV est modifié.
        /// Nécessaire lorsque la modification porte uniquement
        /// sur la partie SPV
        /// </summary>
        /// <param name="typeEquipementId">ID du type d'équipement SMT</param>
        /// <returns></returns>
        public static bool IsModified(Int32 typeEquipementId, CContexteDonnee ctx)
        {
            bool bRet = false;
            DataTable dt = ctx.Tables[CSpvTypeq.c_nomTable];
            if (dt != null)     // L'extension CSpvTypeq n'est pas chargée par exemple quand on travaille sur les équipements
            {
                ArrayList rows = new ArrayList(dt.Rows);

                foreach (DataRow row in rows)
                {
                    if (row.RowState == DataRowState.Modified && (Int32)row[CSpvTypeq.c_champSmtTypeEquipement_Id] == typeEquipementId)
                        bRet = true;
                }
            }
            return bRet;
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme), "SpvTypeq")]
        [DynamicChilds("Alarm wiring", typeof(CSpvLienAccesAlarme))]
        public CListeObjetsDonnees Acces_AccesC
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme.c_nomTable, c_champTYPEQ_ID);
            }
        }
    }
}
