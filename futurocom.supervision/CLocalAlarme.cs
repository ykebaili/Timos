using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using sc2i.expression;
using sc2i.common;
using System.Data;
using sc2i.multitiers.client;

namespace futurocom.supervision
{
    [MemoryTable(CLocalAlarme.c_nomTable, CLocalAlarme.c_champId)]
    public class CLocalAlarme : CEntiteDeMemoryDbAIdAuto, IAlarme
    {
        public static ITraiteurAcquittementAlarme m_traiteurAcquittement;
        public static ITraiteurRetombeeManuelleAlarme m_traiteurRetombee;

        public const string c_nomTable = "ALARM";
        public const string c_champId = "ALARM_ID";
        public const string c_champDateDebut = "ALRM_START";
        public const string c_champDateFin = "ALRM_END";
        public const string c_champDateAcquittement = "ALRM_ACK_DATE";
        public const string c_champEtat = "ALRM_STATE";
        public const string c_champIdParent = "ALRM_PARENT_ID";
        public const string c_champDicValeursChamps = "ALRM_FIELD_VALUES";
        public const string c_champLibelle = "ALRM_LABEL";
        public const string c_champIsHS = "ALRM_IS_OOO";
        public const string c_champNiveauMasquage = "ALRM_MASK_LEVEL";

        public const string c_champIdSite = "ALRM_SITE_ID";
        public const string c_champIdEquipementLogique = "ALRM_EQPT_ID";
        public const string c_champIdLienReseau = "ALRM_LINK_ID";
        public const string c_champIdEntiteSnmp = "ALRM_SNMPETT_ID";
        public const string c_champIdMasquagePropre = "ALRM_OWN_MASK_ID";
        public const string c_champIdMasquageHerite = "ALRM_HER_MASK_ID";


        private bool m_bPreventPropagationsAutomatiques = false;


        //-------------------------------------------
        public CLocalAlarme ( CMemoryDb db )
            :base ( db )
        {
        }

        //-------------------------------------------
        public CLocalAlarme ( DataRow row )
            :base ( row )
        {
        }

        //-------------------------------------------
        public bool PreventPropagationsAutomatiques
        {
            get
            {
                return m_bPreventPropagationsAutomatiques;
            }
            set
            {
                m_bPreventPropagationsAutomatiques = value;
            }
        }

        //-------------------------------------------
        public override void  MyInitValeursParDefaut()
        {
 	        DateDebut = DateTime.Now;
            EtatCode = EEtatAlarme.Unknown;
            IsHS = false;
        }
        
        //------------------------------------------------------------------
        [MemoryParent(false)]
        [DynamicField("Alarm Type")]
        public CLocalTypeAlarme TypeAlarme
        {
            get
            {
                return GetParent<CLocalTypeAlarme>();
            }
            set
            {
                SetParent<CLocalTypeAlarme>(value);
                if (Severite == null)
                {
                    Severite = TypeAlarme.Severite;
                    if (Severite != null)
                        IsHS = Severite.IsHS;
                }
            }
        }

        //------------------------------------------------------------------
        public CDbKey TypeAlarmeId
        {
            get
            {
                CLocalTypeAlarme tp = TypeAlarme;
                if (tp != null)
                {
                    try
                    {
                        return CDbKey.CreateFromStringValue(tp.Id);
                    }
                    catch { }
                }
                return null;
            }
        }


        //------------------------------------------------------------------
        [MemoryParent(false)]
        [DynamicField("Severity")]
        public CLocalSeveriteAlarme Severite
        {
            get
            {
                return GetParent<CLocalSeveriteAlarme>();
            }
            set
            {
                SetParent<CLocalSeveriteAlarme>(value);
            }
        }

        //------------------------------------------------------------------
        [DynamicField("Severity Id")]
        public string IdSeverite
        {
            get
            {
                return Row.Get<string>(CLocalSeveriteAlarme.c_champId);
            }
            set
            {
                Row[CLocalSeveriteAlarme.c_champId] = value;
                if (value != null)
                {
                    CLocalSeveriteAlarme sev = new CLocalSeveriteAlarme(Database);
                    sev.ReadIfExist(value);
                }
            }
        }

        //------------------------------------------------------------------
        [MemoryField(c_champIsHS)]
        [DynamicField("Is out of Service")]
        public bool IsHS
        {
            get
            {
                return (bool)Row[c_champIsHS];
            }
            set
            {
                Row[c_champIsHS] = value;
            }
        }


        //-----------------------------------------------------------------
        [MemoryField(c_champDateDebut)]
        [DynamicField("Start Date")]
        public DateTime DateDebut
        {
            get
            {
                return Row.Get<DateTime>(c_champDateDebut);
            }
            set
            {
                Row[c_champDateDebut] = value;
            }
        }

        //-------------------------------------------
        [MemoryField (c_champDateFin)]
        [DynamicField("End Date")]
        public DateTime? DateFin
        {
            get
            {
                return Row.Get<DateTime?>(c_champDateFin);
            }
            set
            {
                Row[c_champDateFin] = value;
                //Propage la date de fin sur tous les fils
                if ( value != null && !PreventPropagationsAutomatiques)
                    PropageDateFinSurFils(value.Value);
            }
        }

        //-------------------------------------------
        private void PropageDateFinSurFils(DateTime dt)
        {
            if (!PreventPropagationsAutomatiques)
            {
                foreach (CLocalAlarme alarmeFille in Childs)
                {
                    if (alarmeFille.DateFin == null)
                        alarmeFille.Row[c_champDateFin] = dt;
                    alarmeFille.PropageDateFinSurFils(dt);
                }
            }
        }

        //-------------------------------------------
        [MemoryField(c_champDateAcquittement)]
        [DynamicField("Acknowledge Date")]
        public DateTime? DateAcquittement
        {
            get
            {
                return Row.Get<DateTime?>(c_champDateAcquittement);
            }
            set
            {
                Row[c_champDateAcquittement] = value;
            }
        }

        //-------------------------------------------
        [DynamicField("State")]
        public CEtatAlarme Etat
        {
            get
            {
                return new CEtatAlarme(EtatCode);
            }
            set
            {
                if ( value != null )
                    EtatCode = value.Code;
            }
        }

        //-----------------------------------------------------------------------
        [MemoryField(c_champEtat)]
        public EEtatAlarme EtatCode
        {
            get
            {
                return Row.Get<EEtatAlarme>(c_champEtat);
            }
            set
            {
                if (Row.Row[c_champEtat] == DBNull.Value  || value != EtatCode)
                {
                    Row[c_champEtat] = value;
                    if (value == EEtatAlarme.Close)
                    {
                        DateFin = DateTime.Now;
                        if (Parent != null && !PreventPropagationsAutomatiques)
                            Parent.CalculeEtatFromChilds();
                    }
                }
            }
        }

        //-----------------------------------------------------------------------
        [DynamicField("State Code")]
        public int EtatCodeInt
        {
            get
            {
                return (int)EtatCode;
            }
            set
            {
                EtatCode = (EEtatAlarme)value;
            }
        }


        //---------------------------------------------------------------------
        [MemoryParent(c_champIdParent, true)]
        [DynamicField("Parent Alarm")]
        public CLocalAlarme Parent
        {
            get
            {
                return GetParent<CLocalAlarme>(c_champIdParent);
            }
            set
            {
                SetParent<CLocalAlarme>(value, c_champIdParent);
            }
        }

        //--------------------------------------------------------------------
        [MemoryChild]
        [DynamicChilds("Child Alarms", typeof(CLocalAlarme))]
        public CListeEntitesDeMemoryDb<CLocalAlarme> Childs
        {
            get
            {
                return GetFils<CLocalAlarme>(c_champIdParent);
            }
        }

        
        //----------------------------------------------
        public void CloseFromParent()
        {
            if (EtatCode != EEtatAlarme.Close)
            {
                EtatCode = EEtatAlarme.Close;
                DateFin = DateTime.Now;
            }
        }

        //----------------------------------------------
        [MemoryField(c_champDicValeursChamps)]
        public Dictionary<string, object> DicValeursChamps
        {
            get{
                Dictionary<string, object> dic = Row.Get<Dictionary<string, object>>(c_champDicValeursChamps);
                if ( dic == null )
                {
                    dic = new Dictionary<string,object>();
                    Row[c_champDicValeursChamps] = dic;
                }
                return dic;
            }
            set{
                Row[c_champDicValeursChamps] = value;
            }
        }


        //-------------------------------------------
        public void SetValeurChamp(string strIdChamp, object valeur)
        {
            if (strIdChamp != null)
                DicValeursChamps[strIdChamp] = valeur;
        }

        //-------------------------------------------
        public object GetValeurChamp(string strIdChamp)
        {
            if (strIdChamp == null)
                return null;
            object valeur = null;
            DicValeursChamps.TryGetValue(strIdChamp, out valeur);
            return valeur;
        }

        //----------------------------------------------
        private string CalcKey(CLocalTypeAlarme type, CLocalAlarme alarmePossédantLesChamps)
        {
            if (type == null)
                return null;
            if (!type.RegrouperSurLaCle)
                return alarmePossédantLesChamps.Id;
            if (type == null)
                return alarmePossédantLesChamps.Id;
            StringBuilder bl = new StringBuilder();
            bl.Append(type.Id);

            bl.Append('~');
            switch (type.TypeElementSupervise)
            {
                case ETypeElementSupervise.Site:
                    bl.Append(SiteId == null ? "" : SiteId.StringValue);
                    bl.Append('~');
                    break;
                case ETypeElementSupervise.Equipement:
                    bl.Append(SiteId == null ? "" : SiteId.StringValue);
                    bl.Append('~');
                    bl.Append(EquipementId == null ? "" : EquipementId.StringValue);
                    bl.Append('~');
                    break;
                case ETypeElementSupervise.Lien:
                    bl.Append(LienId == null ? "" : LienId.StringValue);
                    bl.Append('~');
                    break;
                case ETypeElementSupervise.EntiteSnmp :
                    bl.Append(SiteId == null ? "" : SiteId.StringValue);
                    bl.Append('~');
                    bl.Append(EntiteSnmpId == null ? "" : EntiteSnmpId.StringValue);
                    bl.Append('~');
                    break;
                default:
                    break;
            }
            

            foreach (CLocalChampTypeAlarme champ in type.TousLesChampsCles)
            {
                object val = GetValeurChamp(champ.Id);
                string strVal = val == null ? "null" : val.ToString();
                bl.Append(strVal);
                bl.Append('~');
            }
            if (bl.Length == 0)
                bl.Append(alarmePossédantLesChamps.Id);
            return bl.ToString();
        }

        //----------------------------------------------
        [DynamicMethod("Returns the unique Alarm Identifier Key")]
        public string GetKey(  )
        {

            return CalcKey(TypeAlarme, this);
        }

        //----------------------------------------------
        public string CalcParentKey()
        {
            return CalcKey(TypeAlarme.TypeParent, this);
        }

        //----------------------------------------------
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        //----------------------------------------------
        public void AgitSurParent()
        {
            if (Parent == null || TypeAlarme == null)
                return;
            Parent.CalculeEtatFromChilds();
            
            C2iExpression formule = TypeAlarme.ActionsSurParent;
            if (formule != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                CResultAErreur result = formule.Eval(ctx);
            }
        }

        //----------------------------------------------
        public void CalculeEtatFromChilds()
        {
            CListeEntitesDeMemoryDb<CLocalAlarme> lstFils = Childs;
            if (TypeAlarme == null || lstFils.Count() == 0 )
                return;

            switch (TypeAlarme.ModeCalculEtat)
            {
                case EModeCalculEtatParent.AllChildsClosed:
                    bool bAllClose = true;
                    foreach (CLocalAlarme alrm in lstFils)
                    {
                        if (alrm.Etat.Code == EEtatAlarme.Open)
                        {
                            bAllClose = false;
                            break;
                        }
                    }
                    if (bAllClose)
                    {
                        EtatCode = EEtatAlarme.Close;
                    }
                    break;
                case EModeCalculEtatParent.OneChildClosed :
                    foreach (CLocalAlarme alrm in lstFils)
                    {
                        if (alrm.Etat.Code == EEtatAlarme.Close)
                        {
                            EtatCode = EEtatAlarme.Close;
                            break;
                        }
                    }
                    break;
                case EModeCalculEtatParent.Manual:
                    break;
                default:
                    break;
            }
        }

        //----------------------------------------------
        [DynamicField("Label")]
        [MemoryField(c_champLibelle)]
        public string Libelle
        {
            get
            {
                string strLib = Row.Get<string>(c_champLibelle);
                if (strLib == null || strLib.Length == 0)
                {
                    if (TypeAlarme != null)
                    {
                        C2iExpression formule = TypeAlarme.FormuleLibelle;
                        if (formule != null)
                        {
                            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                            CResultAErreur result = formule.Eval(ctx);
                            if (result && result.Data != null)
                                strLib = result.Data.ToString();
                        }
                    }
                    if (strLib == null || strLib.Length == 0)
                    {
                        strLib = DateDebut.ToShortDateString() + " " + DateDebut.ToShortTimeString();
                        if (TypeAlarme != null)
                            strLib = TypeAlarme.Libelle + " " + strLib;
                    }
                    Row[c_champLibelle] = strLib;
                }
                return strLib;

            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        
        //----------------------------------------------
        [MemoryField(c_champIdSite)]
        [DynamicField("Site id")]
        public CDbKey SiteId
        {
            get
            {
                return Row.Get<CDbKey>(c_champIdSite);
            }
            set
            {
                Row[c_champIdSite] = value;
            }
        }

        //----------------------------------------------
        [MemoryField(c_champIdEquipementLogique)]
        [DynamicField("Logical equipment id")]
        public CDbKey EquipementId
        {
            get
            {
                return Row.Get<CDbKey>(c_champIdEquipementLogique);
            }
            set
            {
                Row[c_champIdEquipementLogique] = value;
            }
        }



        //----------------------------------------------
        [MemoryField(c_champIdLienReseau)]
        [DynamicField("Link Id")]
        public CDbKey LienId
        {
            get
            {
                return Row.Get<CDbKey>(c_champIdLienReseau);
            }
            set
            {
                Row[c_champIdLienReseau] = value;
            }
        }

        //----------------------------------------------
        [MemoryField(c_champIdEntiteSnmp)]
        [DynamicField("Snmp entity ID")]
        public CDbKey EntiteSnmpId
        {
            get
            {
                return Row.Get<CDbKey>(c_champIdEntiteSnmp);
            }
            set
            {
                Row[c_champIdEntiteSnmp] = value;
            }
        }
        
        //---------------------------------------------------------------
        public IEntiteDeclencheuseAlarme EntiteDeclencheuse
        {
            set
            {
                if (value != null)
                {
                    SiteId = value.IdSiteAssocie;
                    EquipementId = value.IdEquipementLogiqueAssocie;
                    LienId = value.IdLienReseauAssocie;
                    EntiteSnmpId = value.IdEntiteSnmpAssociee;
                }

            }
        }

        //----------------------------------------------
        [MemoryField(c_champNiveauMasquage)]
        [DynamicField("Masking Level")]
        public int? NiveauMasquage
        {
            get
            {
                return Row.Get<int?>(c_champNiveauMasquage);
            }
            set
            {
                Row[c_champNiveauMasquage] = value;
            }
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Indique quel Filrage (masquage) a été utilisé pour masquer cette Alarme
        /// </summary>
        [MemoryParent(c_champIdMasquagePropre, false)]
        [DynamicField("Proper Masking")]
        public CLocalParametrageFiltrageAlarmes MasquagePropre
        {
            get
            {
                return GetParent<CLocalParametrageFiltrageAlarmes>(c_champIdMasquagePropre);
            }
            set
            {
                SetParent<CLocalParametrageFiltrageAlarmes>(value, c_champIdMasquagePropre);
            }
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Indique quel Filrage (masquage) a été utilisé pour masquer cette Alarme
        /// </summary>
        [MemoryParent(c_champIdMasquageHerite, false)]
        [DynamicField("Inherited Masking")]
        public CLocalParametrageFiltrageAlarmes MasquageHerite
        {
            get
            {
                return GetParent<CLocalParametrageFiltrageAlarmes>(c_champIdMasquageHerite);
            }
            set
            {
                SetParent<CLocalParametrageFiltrageAlarmes>(value, c_champIdMasquageHerite);
            }
        }

        [DynamicField("Applied Masking")]
        public CLocalParametrageFiltrageAlarmes MasquageApplique
        {
            get
            {
                return MasquageHerite;
            }
        }

        //---------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            if (TypeAlarme != null)
            {
                return TypeAlarme.GetDefinitionsChamps(typeof(CLocalTypeAlarme));
            }
            return new CDefinitionProprieteDynamique[0];
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            //return 0;
            return 1;
        }

        //----------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champDateDebut,
                c_champDateFin,
                c_champEtat,
                c_champDicValeursChamps,
                c_champLibelle,
                c_champDateAcquittement,
                c_champIdSite,
                c_champIdEquipementLogique,
                c_champIdLienReseau,
                c_champIdEntiteSnmp,
                c_champNiveauMasquage,
                c_champIsHS);
            if (result)
                result = SerializeParent<CLocalTypeAlarme>(serializer);
            if (result)
                result = SerializeParent<CLocalSeveriteAlarme>(serializer);
            if (result)
                result = SerializeParent<CLocalAlarme>(serializer, c_champIdParent);
            if (result)
                result = SerializeChilds<CLocalAlarme>(serializer, c_champIdParent);
            if (result)
                result = SerializeParent<CLocalParametrageFiltrageAlarmes>(serializer, c_champIdMasquagePropre);
            if (result)
                result = SerializeParent<CLocalParametrageFiltrageAlarmes>(serializer, c_champIdMasquageHerite);
            return result;
        }

        //------------------------------------------------------------------------------
        public static ITraiteurAcquittementAlarme TraiteurAcquittement
        {
            get
            {
                return m_traiteurAcquittement;
            }
            set
            {
                m_traiteurAcquittement = value;
            }
        }

        
        
        //------------------------------------------------------------------------------
        public CResultAErreur Acquitter(int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                if (m_traiteurAcquittement != null)
                    result = m_traiteurAcquittement.AcquitteAlarme(Id, DateTime.Now, nIdSession);

            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException ( e ) );            
            }

            return result;
        }

        //------------------------------------------------------------------------------
        public static ITraiteurRetombeeManuelleAlarme TraiteurRetombee
        {
            get
            {
                return m_traiteurRetombee;
            }
            set
            {
                m_traiteurRetombee = value;
            }
        }


        //---------------------------------------------------------
        public CResultAErreur RetombageManuel(int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                if (m_traiteurRetombee != null)
                    result = m_traiteurRetombee.RetombageManuel(Id, nIdSession);
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

    }
}
