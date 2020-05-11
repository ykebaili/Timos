using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    [Table(CSpvAccesAlarme.c_nomTable, CSpvAccesAlarme.c_nomTableInDb, new string[] { CSpvAccesAlarme.c_champACCES_ID }, ModifiedByTrigger = true)]
	[ObjetServeurURI("CSpvAccesAlarmeServeur")]
	[DynamicClass("Alarm access")]
	public class CSpvAccesAlarme  : CSpvAcces
	{
		public const string c_nomTable = "SPV_ACCES_ALARM";
		public const string c_champSITE_ID = "SITE_ID";
		public const string c_champLIAI_ID = "LIAI_ID";
		public const string c_champTYPLIAI_ID = "TYPLIAI_ID";
	//	public const string c_champMODELLIAI_ID = "MODELLIAI_ID";
	//    public const string c_champMESS_ID = "MESS_ID";
		public const string c_champACCES_IDENT = "ACCES_IDENT";
        const int c_classID = 1019;		//Accès alarme
        public const string c_accesNonCable = "0,2,4,6,8,10,12,14";
        public const int c_TrapGeneriqueMin = 0;
        public const int c_TrapGeneriqueMax = 6;

		///////////////////////////////////////////////////////////////
		public CSpvAccesAlarme(CContexteDonnee ctx)
			: base(ctx)
		{
		}


        ///////////////////////////////////////////////////////////////
        public void InitFromTypeAccesAlarme(CSpvTypeAccesAlarme spvTypeAl)
        {
            Nature = spvTypeAl.Nature;
            NatureAccesConnexion = spvTypeAl.NatureAccesConnexion;
            NomAcces = spvTypeAl.NomAcces;
            TrapIdent = spvTypeAl.TrapIdent;
            ConnectionsNumber = spvTypeAl.ConnectionsNumber;
            CategorieAccesAlarme = spvTypeAl.CategorieAccesAlarme;
        }

		///////////////////////////////////////////////////////////////
        public CSpvAccesAlarme(DataRow row)
			: base(row)
		{
		}

		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Row[c_champACCES_CLASSID] = c_classID;
		}

		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champACCES_NOM };
		}

		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm access @1|30006", NomAcces);
			}
		}
		
	
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCES_IDENT, 80)]
        [DynamicField("Trap ident")]
		public System.String TrapIdent
		{
			get
			{
				if (Row[c_champACCES_IDENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champACCES_IDENT];
			}
			set
			{
				Row[c_champACCES_IDENT, true] = value;
			}
		}

        public System.Int32? TrapIANA
        {
            get
            {
                System.Int32? nIANA = null;
                if (CodeCategorieAcces == (int)ECategorieAccesAlarme.TrapSnmp)
                {
                    string[] TrapIdentTab = TrapIdent.Split(';');
                    if (TrapIdentTab.Length > 0)
                        nIANA = Convert.ToInt32(TrapIdentTab[0]);
                }
                return nIANA;
            }
        }


        public System.Int32? TrapGenerique
        {
            get
            {
                System.Int32? nGenerique = null;
                if (CodeCategorieAcces == (int)ECategorieAccesAlarme.TrapSnmp)
                {
                    string[] TrapIdentTab = TrapIdent.Split(';');
                    if (TrapIdentTab.Length > 1)
                        nGenerique = Convert.ToInt32(TrapIdentTab[1]);
                }
                return nGenerique;
            }
        }

        public System.Int32? TrapSpecifique
        {
            get
            {
                System.Int32? nSpecifique = null;
                if (CodeCategorieAcces == (int)ECategorieAccesAlarme.TrapSnmp)
                {
                    string[] TrapIdentTab = TrapIdent.Split(';');
                    if (TrapIdentTab.Length > 2)
                        nSpecifique = Convert.ToInt32(TrapIdentTab[2]);
                }
                return nSpecifique;
            }
        }

		///////////////////////////////////////////////////////////////
        [Relation(CSpvSite.c_nomTable, new string[] { CSpvSite.c_champSITE_ID }, new string[] { CSpvAccesAlarme.c_champSITE_ID }, false, true)]
		[DynamicField("Spv Site")]
		public CSpvSite SpvSite
		{
			get
			{
				return (CSpvSite)GetParent(new string[] { c_champSITE_ID }, typeof(CSpvSite));
			}
			set
			{
				SetParent(new string[] { c_champSITE_ID }, value);
                //CalculeUnicite();
			}
		}


		///////////////////////////////////////////////////////////////
        [Relation(CSpvEquip.c_nomTable, new string[] { CSpvEquip.c_champEQUIP_ID }, new string[] { CSpvAccesAlarme.c_champEQUIP_ID }, false, true)]
		[DynamicField("Spv Equipment")]
		public CSpvEquip SpvEquip
		{
			get
			{
				return (CSpvEquip)GetParent(new string[] { c_champEQUIP_ID }, typeof(CSpvEquip));
			}
			set
			{
				SetParent(new string[] { c_champEQUIP_ID }, value);
                //CalculeUnicite();
			}
		}


		///////////////////////////////////////////////////////////////
        [Relation(CSpvLiai.c_nomTable, new string[] { CSpvLiai.c_champLIAI_ID }, new string[] { CSpvAccesAlarme.c_champLIAI_ID }, false, true)]
		[DynamicField("Spv Link")]
		public CSpvLiai SpvLiai
		{
			get
			{
				return (CSpvLiai)GetParent(new string[] { c_champLIAI_ID }, typeof(CSpvLiai));
			}
			set
			{
				SetParent(new string[] { c_champLIAI_ID }, value);
                //CalculeUnicite();
			}
		}


        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme), "AccesAlarmeOne")]
        [DynamicChilds("Alarm access link 1", typeof(CSpvLienAccesAlarme))]
        public CListeObjetsDonnees Acces_AccescsOne
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme.c_nomTable, CSpvLienAccesAlarme.c_champACCES1_ID);
            }
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme), "AccesAlarmeTwo")]
        [DynamicChilds("Alarm access link 2", typeof(CSpvLienAccesAlarme))]
        public CListeObjetsDonnees Acces_AccescsTwo
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme.c_nomTable, CSpvLienAccesAlarme.c_champACCES2_ID);
            }
        }


        public CSpvTypeAccesAlarme TypeAccesAlarme()
        {
            if (SpvEquip != null)
            {
                CSpvTypeq spvTypeq = this.SpvEquip.TypeEquipement;
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvTypeAccesAlarme));
                liste.Filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champTYPEQ_ID + "=@1 AND " +
                                                CSpvTypeAccesAlarme.c_champACCES_NOM + "=@2",
                                                spvTypeq.Id, this.NomAcces);
                if (liste.Count != 1)
                    return null;

                return (CSpvTypeAccesAlarme)liste[0];
            }
            else
            {
                CSpvTypeAccesAlarme typeAccesAlarm = new CSpvTypeAccesAlarme(ContexteDonnee);
                if (typeAccesAlarm.ReadIfExists(Id))
                    return typeAccesAlarm;
                else
                    return null;
            }
        }


        public CSpvAlarmGeree AlarmeGeree()
        {
            CSpvTypeAccesAlarme spvTypeAccesAlarme = TypeAccesAlarme();
            if (spvTypeAccesAlarme != null)
                return spvTypeAccesAlarme.AlarmeGeree;

            return null;
        }



        public CResultAErreur GenAccesAccescForTrap()
        {
            CResultAErreur result = CResultAErreur.True;
            if (this.SpvEquip == null || this.CategorieAccesAlarme != ECategorieAccesAlarme.TrapSnmp)
                return result;

            try
            {
                // Recherche de l'alarme gérée correspondante
                CSpvAlarmGeree spvAlarmeGeree = AlarmeGeree();
                if (spvAlarmeGeree != null)
                {
                    /*
                    CSpvLienAccesAlarme spvAccesAccesc = new CSpvLienAccesAlarme(ContexteDonnee);
                    CFiltreData filtre = new CFiltreData (
                        CSpvLienAccesAlarme.c_champACCES_BINDINGID + "=@1 AND " +
                        CSpvLienAccesAlarme.c_champACCES_BINDINGCLASSID + "=8 AND " +
                        CSpvLienAccesAlarme.c_champACCES1_ID + "=@2", 
                        this.SpvEquip.Id,
                        this.Id);

                    if (!spvAccesAccesc.ReadIfExists(filtre))
                    {*/
                        CSpvLienAccesAlarme spvLienAccesAlarme = new CSpvLienAccesAlarme(ContexteDonnee);
                        spvLienAccesAlarme.CreateNewInCurrentContexte();
                        spvLienAccesAlarme.InitFromAccesAndAlarmeGeree(this, spvAlarmeGeree);
                    //}
                }
                else
                    result.EmpileErreur(I.T("Managed alarm not found|50000"));
            }
            catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
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
                CodeCategorieAcces = (int)value.Code;
            }
        }

	}
}
