using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using System.Text;

namespace spv.data
{
    [Table(CSpvAlarmGeree.c_nomTable, CSpvAlarmGeree.c_nomTableInDb, new string[] { CSpvAlarmGeree.c_champALARMGEREE_ID }, ModifiedByTrigger = true)]
	[ObjetServeurURI("CSpvAlarmgereeServeur")]
	[DynamicClass("Alarm access type extension")]
	public class	CSpvAlarmGeree : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARMGEREE";
		public const string c_nomTableInDb = "ALARMGEREE";
		public const string c_champALARMGEREE_ID ="ALARMGEREE_ID";
		public const string c_champACCES_ID ="ACCES_ID";
		public const string c_champALARMGEREE_CLASSID ="ALARMGEREE_CLASSID";
		public const string c_champALARMGEREE_NOM ="ALARMGEREE_NOM";
		public const string c_champALARMGEREE_ACQ ="ALARMGEREE_ACQ";
		public const string c_champALARMGEREE_SON ="ALARMGEREE_SON";
		public const string c_champALARMGEREE_TYPSON ="ALARMGEREE_TYPSON";
		public const string c_champALARMGEREE_MIN ="ALARMGEREE_MIN";
		public const string c_champALARMGEREE_TYPAL ="ALARMGEREE_TYPAL";
		public const string c_champALARMGEREE_FREQN ="ALARMGEREE_FREQN";
		public const string c_champALARMGEREE_FREQD ="ALARMGEREE_FREQD";
		public const string c_champALARMGEREE_GRAVE ="ALARMGEREE_GRAVE";
		public const string c_champALARMGEREE_LOCAL ="ALARMGEREE_LOCAL";
		public const string c_champALARMGEREE_NSEUIL ="ALARMGEREE_NSEUIL";
		public const string c_champALARMGEREE_SEUILB ="ALARMGEREE_SEUILB";
		public const string c_champALARMGEREE_SEUILH ="ALARMGEREE_SEUILH";
		public const string c_champALARMGEREE_CORR ="ALARMGEREE_CORR";
		public const string c_champALARMGEREE_COMMENT ="ALARMGEREE_COMMENT";
		public const string c_champALARMGEREE_PROTOCOL ="ALARMGEREE_PROTOCOL";
		public const string c_champALARMGEREE_UNICITE ="ALARMGEREE_UNICITE";
		public const string c_champALARMGEREE_TOSURV ="ALARMGEREE_TOSURV";
		public const string c_champALARMGEREE_TOAFF ="ALARMGEREE_TOAFF";
		public const string c_champALARMGEREE_SEUILOID ="ALARMGEREE_SEUILOID";
		public const string c_champALARMGEREE_MIBAUTO ="ALARMGEREE_MIBAUTO";
        public const string c_champALARMGEREE_PROPAGER = "ALARMGEREE_PROPAGER";
        const int c_classID = 4;

        public const bool c_defautAlarmgeree_Acquitter = true;
        public const bool c_defautAlarmgereeSurveiller = true;
        public const bool c_defautAlarmgereeAfficher = true;
        public const bool c_defautAlarmgereeLocal = true;
        public const int c_defautSeuilBas = 0;
        public const int c_defautSeuilHaut = 0;
        public const bool c_defautAlarmgereeSon = false;
        public const bool c_defautAutomatic_MIB = false;
        public const int c_defautCodeAlarmgereeProtocol = (int)EProtocole.IS_GTR;
        public const int c_defautCodeAlarmgereeEvent = (int)EAlarmEvent.Communication;
        public const int c_defautCodeAlarmgereeGravite = (int)EGraviteAlarmeAvecMasquage.Warning;
        public const int c_defautCodeAlarmgereeTypeSon = (int)ETypeSon.Normal;
        public const int c_defautAlarmgereeFreqPeriod = 1;
        public const int c_defautAlarmgereeFreqNb = 0;
        public const int c_defautDureeMin = 0;
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmGeree( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmGeree( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{			
            Row[c_champALARMGEREE_CLASSID] = c_classID;
            Alarmgeree_Acquitter = c_defautAlarmgeree_Acquitter;
            AlarmgereeSurveiller = c_defautAlarmgereeSurveiller;
            AlarmgereeAfficher = c_defautAlarmgereeAfficher;
            AlarmgereeLocal = c_defautAlarmgereeLocal;
            SeuilBas = c_defautSeuilBas;
            SeuilHaut = c_defautSeuilHaut;
            AlarmgereeSon = c_defautAlarmgereeSon;
            Automatic_MIB = c_defautAutomatic_MIB;
            CodeAlarmgereeProtocol = c_defautCodeAlarmgereeProtocol;
            CodeAlarmgereeEvent = c_defautCodeAlarmgereeEvent;
            CodeAlarmgereeGravite = c_defautCodeAlarmgereeGravite;
            CodeAlarmgereeTypeSon = c_defautCodeAlarmgereeTypeSon;
            AlarmgereeFreqPeriod = c_defautAlarmgereeFreqPeriod;
            AlarmgereeFreqNb = c_defautAlarmgereeFreqNb;
            DureeMin = c_defautDureeMin;
      	}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champALARMGEREE_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm access type extension @1|30011", Alarmgeree_Name);
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_CLASSID)]
        [DynamicField("Alarm access type extension Class Id")]
        public System.Int32 AlarmgereeClassId
		{
			get
			{
                return (System.Int32)Row[c_champALARMGEREE_CLASSID];
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_NOM,40)]
        [DynamicField("Name")]
		public System.String Alarmgeree_Name
		{
			get
			{
				return (System.String)Row[c_champALARMGEREE_NOM];
			}
			set
			{
				Row[c_champALARMGEREE_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_ACQ)]
        [DynamicField("Alarm access type acknowledgement")]
        public System.Boolean Alarmgeree_Acquitter
		{
			get
			{
				if (Row[c_champALARMGEREE_ACQ] == DBNull.Value)
					return false;
				return (System.Boolean)Row[c_champALARMGEREE_ACQ];
			}
			set
			{
				Row[c_champALARMGEREE_ACQ,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_SON)]
        [DynamicField("Ring activated")]
		public System.Boolean AlarmgereeSon
		{
			get
			{
                if (Row[c_champALARMGEREE_SON] == DBNull.Value)
                    return false;
				return (System.Boolean)Row[c_champALARMGEREE_SON];
			}
			set
			{
				Row[c_champALARMGEREE_SON,true]=value;
			}
		}
		
		//////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_MIN)]
        [DynamicField("Confirmation length")]
		public System.Int32 DureeMin
		{
			get
			{
                return (System.Int32)Row[c_champALARMGEREE_MIN];
			}
			set
			{
				Row[c_champALARMGEREE_MIN,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_TYPAL)]
		[DynamicField("Event type code")]
        public int CodeAlarmgereeEvent
		{
			get
			{
				return (System.Int32)Row[c_champALARMGEREE_TYPAL];
			}
			set
			{
				Row[c_champALARMGEREE_TYPAL,true]=value;
			}
		}

        ///////////////////////////////////////////////////////////////
        [DynamicField("Event type")]
        public CAlarmEvent AlarmgereeEvent
        {
            get
            {
                if (Enum.IsDefined(typeof(EAlarmEvent), CodeAlarmgereeEvent))
                {
                    try
                    {
                        return new CAlarmEvent((EAlarmEvent)CodeAlarmgereeEvent);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeAlarmgereeEvent = (int)value.Code;
            }
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_FREQN)]
        [DynamicField("Alarm frequent number")]
		public System.Int32? AlarmgereeFreqNb
		{
			get
			{
				if (Row[c_champALARMGEREE_FREQN] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_FREQN];
			}
			set
			{
				Row[c_champALARMGEREE_FREQN,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_FREQD)]
        [DynamicField("Frequent period")]
        public System.Int32? AlarmgereeFreqPeriod
		{
			get
			{
				if (Row[c_champALARMGEREE_FREQD] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_FREQD];
			}
			set
			{
				Row[c_champALARMGEREE_FREQD,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_GRAVE)]
        [DynamicField("Alarm access type severity code")]
        public int CodeAlarmgereeGravite
		{
			get
			{
				return (int)Row[c_champALARMGEREE_GRAVE];
			}
			set
			{
				Row[c_champALARMGEREE_GRAVE,true]=value;
			}
		}

        ///////////////////////////////////////////////////////////////
        [DynamicField("Alarm access type severity")]
        public CGraviteAlarmeAvecMasquage AlarmgereeGravite
        {
            get
            {
                if (Enum.IsDefined(typeof(EGraviteAlarmeAvecMasquage), CodeAlarmgereeGravite))
                {
                    try
                    {
                        return new CGraviteAlarmeAvecMasquage((EGraviteAlarmeAvecMasquage)CodeAlarmgereeGravite);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeAlarmgereeGravite = (int)value.Code;
            }
        }
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_LOCAL)]
		[DynamicField("Local Alarm")]
        public Boolean AlarmgereeLocal
		{
			get
			{
                return (Boolean)Row[c_champALARMGEREE_LOCAL];
			}
			set
			{
				Row[c_champALARMGEREE_LOCAL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_NSEUIL,40)]
		[DynamicField("Threshold Name")]
        public System.String AlarmgereeSeuilNom
		{
			get
			{
				if (Row[c_champALARMGEREE_NSEUIL] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMGEREE_NSEUIL];
			}
			set
			{
				Row[c_champALARMGEREE_NSEUIL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_SEUILB)]
        [DynamicField("Threshold bottom level")]
        public System.Int32? SeuilBas
		{
			get
			{
				if (Row[c_champALARMGEREE_SEUILB] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_SEUILB];
			}
			set
			{
				Row[c_champALARMGEREE_SEUILB,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_SEUILH)]
        [DynamicField("Threshold hight level")]
        public System.Int32? SeuilHaut
		{
			get
			{
				if (Row[c_champALARMGEREE_SEUILH] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_SEUILH];
			}
			set
			{
				Row[c_champALARMGEREE_SEUILH,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_CORR,2000)]
		[DynamicField("Corrective Action")]
		public System.String Corrective_Action
		{
			get
			{
				if (Row[c_champALARMGEREE_CORR] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMGEREE_CORR];
			}
			set
			{
				Row[c_champALARMGEREE_CORR,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_COMMENT,2000)]
		[DynamicField("Comment")]
        public System.String Comment
		{
			get
			{
				if (Row[c_champALARMGEREE_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMGEREE_COMMENT];
			}
			set
			{
				Row[c_champALARMGEREE_COMMENT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_PROTOCOL)]
		[DynamicField("Protocol code")]
		public int CodeAlarmgereeProtocol
		{
			get
			{
				return (int)Row[c_champALARMGEREE_PROTOCOL];
			}
			set
			{
				Row[c_champALARMGEREE_PROTOCOL,true]=value;
			}
		}

  
        ///////////////////////////////////////////////////////////////
        [DynamicField("Protocol")]
        public CProtocole AlarmgereeProtocol
        {
            get
            {
                if (Enum.IsDefined(typeof(EProtocole), CodeAlarmgereeProtocol))
                {
                    try
                    {
                        return new CProtocole((EProtocole)CodeAlarmgereeProtocol);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeAlarmgereeProtocol = (int)value.Code;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_TYPSON)]
        [DynamicField("Type sound code")]
        public int? CodeAlarmgereeTypeSon
        {
            get
            {
                if (Row[c_champALARMGEREE_TYPSON] == DBNull.Value)
                    return null;

                return (int?)Row[c_champALARMGEREE_TYPSON];
            }
            set
            {
                Row[c_champALARMGEREE_TYPSON, true] = value;
            }
        }


        ///////////////////////////////////////////////////////////////
        [DynamicField("Ring type")]
        public CTypeSon AlarmgereeTypeSon
        {
            get
            {
                if (CodeAlarmgereeTypeSon == null)
                    return null;

                if (Enum.IsDefined(typeof(ETypeSon), CodeAlarmgereeTypeSon))
                {
                    try
                    {
                        return new CTypeSon((ETypeSon)CodeAlarmgereeTypeSon);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeAlarmgereeTypeSon = (int)value.Code;
            }
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_UNICITE,70)]
        [DynamicField("Unicity code")]
        public System.String AlarmgereeUnicity
		{
			get
			{
                if (Row[c_champALARMGEREE_UNICITE] == DBNull.Value)
                    return null;
				return (System.String)Row[c_champALARMGEREE_UNICITE];
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_TOSURV)]
        [DynamicField("Monitor alarm access type")]
        public Boolean AlarmgereeSurveiller
		{
			get
			{
                return (Boolean)Row[c_champALARMGEREE_TOSURV];
			}
			set
			{
				Row[c_champALARMGEREE_TOSURV,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_TOAFF)]
        [DynamicField("Display alarm access type")]
        public Boolean AlarmgereeAfficher
		{
			get
			{
                return (Boolean)Row[c_champALARMGEREE_TOAFF];
			}
			set
			{
				Row[c_champALARMGEREE_TOAFF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_SEUILOID,128)]
		[DynamicField("Threshold OID")]
		public System.String Threshold_OID
		{
			get
			{
				if (Row[c_champALARMGEREE_SEUILOID] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMGEREE_SEUILOID];
			}
			set
			{
				Row[c_champALARMGEREE_SEUILOID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_MIBAUTO)]
        [DynamicField("Automatic MIB")]
        public Boolean Automatic_MIB
		{
			get
			{
                if(Row[c_champALARMGEREE_MIBAUTO]==DBNull.Value)
                    return false;
				return (Boolean)Row[c_champALARMGEREE_MIBAUTO];
			}
			set
			{
				Row[c_champALARMGEREE_MIBAUTO,true]=value;
			}
		}


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_PROPAGER)]
        [DynamicField("Propagate to equipments")]
        public System.Boolean PropagerAuxEquipements
        {
            get
            {
                if (Row[c_champALARMGEREE_PROPAGER] == DBNull.Value)
                    return false;
                return (System.Boolean)Row[c_champALARMGEREE_PROPAGER];
            }
            set
            {
                Row[c_champALARMGEREE_PROPAGER, true] = value;
            }
        }
		
				
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeAccesAlarme.c_nomTable, new string[] { CSpvTypeAccesAlarme.c_champACCES_ID }, new string[] { CSpvAlarmGeree.c_champACCES_ID }, true, true)]
		[DynamicField("Alarm access type")]
		public CSpvTypeAccesAlarme TypeAccesAlarme
		{
			get
			{
				return (CSpvTypeAccesAlarme)GetParent(new string[] { c_champACCES_ID }, typeof(CSpvTypeAccesAlarme));
			}
			set
			{
				SetParent(new string[]{c_champACCES_ID}, value);
                if (TypeAccesAlarme != null)
                {
                    Alarmgeree_Name = TypeAccesAlarme.NomAcces;
                    //AlarmgereeUnicity = TypeAccesAlarme.UniciteAcces;
                }
			}
		}

		
	
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvAlarmg_Cause),"SpvAlarmgeree")]
        [DynamicChilds("Alarm causes", typeof(CSpvAlarmg_Cause))]
		public CListeObjetsDonnees Causes
		{
			get
			{
				return GetDependancesListe(CSpvAlarmg_Cause.c_nomTable,c_champALARMGEREE_ID);
			}
		}
				
		
        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme), "SpvAlarmgeree")]
        [DynamicChilds("Alarm access wirings", typeof(CSpvLienAccesAlarme))]
        public CListeObjetsDonnees SpvAcces_Accescs
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme.c_nomTable, c_champALARMGEREE_ID);
            }
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvEvenementReseau), "SpvAlarmgeree")]
        [DynamicChilds("Network events", typeof(CSpvEvenementReseau))]
        public CListeObjetsDonnees EvenementReseau
        {
            get
            {
                return GetDependancesListe(CSpvEvenementReseau.c_nomTable, c_champALARMGEREE_ID);
            }
        }

       
        protected override CResultAErreur MyCanDelete()
        {
            CResultAErreur result = CResultAErreur.True;
            // La suppression est autorisée si les acces_accesc ne sont pas câblés
            foreach (CSpvLienAccesAlarme svpAccesAccesc in SpvAcces_Accescs)
            {
                if (TypeAccesAlarme.SpvTypeq != null && svpAccesAccesc.AccesCable())
                {
                    result.EmpileErreur(I.T("Access alarm is wired. Equipment '@1'.|160", svpAccesAccesc.AccesAlarmeOne.SpvEquip.GetName()));
                }
            }


            return result;
        }


        public CResultAErreur MibAuto()
        {
            CResultAErreur result = CResultAErreur.True;

            if (Automatic_MIB && AlarmgereeSeuilNom != null && AlarmgereeSeuilNom.Length > 0 && TypeAccesAlarme.SpvTypeq.TypeqModulesMIB.Count > 0)
            {
                CSpvMibobj mibObj = CSpvMibmodule.GetVariable ( ContexteDonnee, AlarmgereeSeuilNom, (CSpvMibmodule[])TypeAccesAlarme.SpvTypeq.ModulesMIB.ToArray(typeof(CSpvMibmodule)));
                
                /*               
                string[] nomModules = new string[TypeAccesAlarme.SpvTypeq.ModulesMIB.Count];
                int index = 0;
                foreach (CSpvTypeq_Mibmodule typeqMibModule in TypeAccesAlarme.SpvTypeq.ModulesMIB)
                    nomModules[index++] = typeqMibModule.SpvMibmodule.NomModuleOfficiel;

                CSpvMibobj mibObj = CSpvMibmodule.GetVariable(ContexteDonnee, AlarmgereeSeuilNom, nomModules);*/
                if (mibObj != null)
                    this.Threshold_OID = mibObj.OidObjet;
                else
                    result.EmpileErreur (I.T("Threshold variable not found in the MIBs associated with the equipement type|50004"));

            }
            return result;
        }

        /*
        public override CResultAErreur DoDeleteInterneACObjetDonneeNePasUtiliserSansBonneRaison()
        {
            CResultAErreur result = base.DoDeleteInterneACObjetDonneeNePasUtiliserSansBonneRaison();
            if (!result)
                return result;

            try
            {
                // Supprimer les Acces_accesc correspondants
                foreach (CSpvAcces_Accesc spvAccesAccesc in SpvAcces_Accescs)
                {
                    if (spvAccesAccesc.AccesCable())
                    {
                        result.EmpileErreur(I.T("You can't delete a wired access|50002"));
                        return result;
                    }
                    spvAccesAccesc.Delete();
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }

            return result;
        }*/

        private bool GetTableMerePourUnicite(ref string strTable, ref int nIdObjet)
        {
            if (this.TypeAccesAlarme.SpvSite != null)
            {
                strTable = CSpvSite.c_nomTableInDb;
                nIdObjet = this.TypeAccesAlarme.SpvSite.Id;
                return true;
            }
            else if (this.TypeAccesAlarme.SpvTypeq != null)
            {
                strTable = CSpvTypeq.c_nomTableInDb;
                nIdObjet = this.TypeAccesAlarme.SpvTypeq.Id;
                return true;
            }
            else if (this.TypeAccesAlarme.SpvLiai != null)
            {
                strTable = CSpvLiai.c_nomTableInDb;
                nIdObjet = this.TypeAccesAlarme.SpvLiai.Id;
                return true;
            }
            return false;
        }


        public void CalculeUnicite()
        {
            string strTable = "";
            int nIdObjet = -1;
            if (! GetTableMerePourUnicite(ref strTable, ref nIdObjet))
                throw new Exception(I.T("Error in computing AlarmGeree unicity|50011"));

            Row[c_champALARMGEREE_UNICITE] = strTable + "/"
                                            + nIdObjet.ToString() + "/"
                                            + this.Alarmgeree_Name;
            
        }
    }
}
