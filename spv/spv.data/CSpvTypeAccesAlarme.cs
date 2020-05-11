using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using System.Data;


namespace spv.data
{
    [Table(CSpvTypeAccesAlarme.c_nomTable,
        CSpvTypeAcces.c_nomTableInDb,
        new string[] { CSpvTypeAcces.c_champACCES_ID },
       ModifiedByTrigger = true)]
    [DynamicClass("Spv alarm access type")]
    [ObjetServeurURI("CSpvTypeAccesAlarmeServeur")]
    public class CSpvTypeAccesAlarme : CSpvTypeAcces
    {
        public const string c_nomTable = "SPV_TYPE_ACCES_ALARME";
        public const string c_champACCES_IDENT = "ACCES_IDENT";
        public const string c_champTYPEQ_ID = "TYPEQ_ID";
        public const string c_champSITE_ID = "SITE_ID";
        public const string c_champLIAI_ID = "LIAI_ID";
        const int c_classID = 1019;		//Accès alarme

        ////////////////////////////////////
        public CSpvTypeAccesAlarme(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// ////////////////////////////////
        public CSpvTypeAccesAlarme(DataRow row)
            : base(row)
        {
        }

        /// ////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            Row[c_champACCES_CLASSID] = c_classID;
        }

        /// ////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champACCES_NOM };
        }

        /// ////////////////////////////////
        public override string DescriptionElement
        {
            get { return I.T("Alarm access type @1|8",NomAcces ); }
        }

        ///////////////////////////////////
        public CSpvAlarmGeree AlarmeGeree
        {
            get
            {
                if (AlarmeGerees.Count > 0)
                    return AlarmeGerees[0] as CSpvAlarmGeree;
                return null;
            }
        }


        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvAlarmGeree), "TypeAccesAlarme")]
        public CListeObjetsDonnees AlarmeGerees
        {
            get
            {
                return GetDependancesListe(CSpvAlarmGeree.c_nomTable, c_champACCES_ID);
            }
        }


        ///////////////////////////////////////////////////////////////
        [Relation(CSpvTypeq.c_nomTable, new string[] { CSpvTypeq.c_champTYPEQ_ID }, new string[] { CSpvTypeAccesAlarme.c_champTYPEQ_ID }, false, true)]
        [DynamicField("Equipment type")]
        public CSpvTypeq SpvTypeq
        {
            get
            {
                return (CSpvTypeq)GetParent(new string[] { c_champTYPEQ_ID }, typeof(CSpvTypeq));
            }
            set
            {
                SetParent(new string[] { c_champTYPEQ_ID }, value);
                //CalculeUnicite();
            }
        }


        ///////////////////////////////////////////////////////////////
        [Relation(CSpvSite.c_nomTable, new string[] { CSpvSite.c_champSITE_ID }, new string[] { CSpvTypeAccesAlarme.c_champSITE_ID }, false, true)]
        [DynamicField("SpvSite")]
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
        [Relation(CSpvLiai.c_nomTable, new string[] { CSpvLiai.c_champLIAI_ID }, new string[] { CSpvTypeAccesAlarme.c_champLIAI_ID }, false, true)]
        [DynamicField("SpvLiai")]
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
        }

        /// ////////////////////////////////
        public void SetInfosTrap(int? nIana, int? nTrapGenerique, int? nTrapSpecifique)
        {
            string strVal = null;
            if (nIana != null && nTrapGenerique != null && nTrapGenerique != null)
                strVal = nIana.Value + ";" + nTrapGenerique.Value + ";" + nTrapSpecifique.Value + ";";
            Row[c_champACCES_IDENT] = strVal;
        }

        /// ////////////////////////////////
        public void DecomposeInfosTrap(ref int? nIana, ref int? nTrapGenerique, ref int? nTrapSpecifique)
        {
            if (TrapIdent != null)
            {
                string[] strData = Row[c_champACCES_IDENT].ToString().Split(';');
                if (strData.Length >= 3)
                {
                    try
                    {
                        nIana = Int32.Parse(strData[0]);
                        nTrapGenerique = Int32.Parse(strData[1]);
                        nTrapSpecifique = Int32.Parse(strData[2]);
                        return;
                    }
                    catch
                    {
                    }
                }
            }
            nIana = null;
            nTrapSpecifique = null;
            nTrapGenerique = null;
        }


        /// ////////////////////////////////
        [DynamicField("IANA number")]
        public int? NumeroIANA
        {
            get
            {
                int? nIana = null;
                int? nDummy = null;
                DecomposeInfosTrap(ref nIana, ref nDummy, ref nDummy);
                return nIana;
            }
        }

        /// ////////////////////////////////
        [DynamicField("Generic trap")]
        public int? TrapGenerique
        {
            get
            {
                int? nTrapGenerique = null;
                int? nDummy = null;
                DecomposeInfosTrap(ref nDummy, ref nTrapGenerique, ref nDummy);
                return nTrapGenerique;
            }
        }

        ///////////////////////////////////
        [DynamicField("Specific trap")]
        public int? TrapSpecifique
        {
            get
            {
                int? nTrapSpecifique = null;
                int? nDummy = null;
                DecomposeInfosTrap(ref nDummy, ref nDummy, ref nTrapSpecifique);
                return nTrapSpecifique;
            }
        }


        ///////////////////////////////////////////////////////////////
        
        /*
		public override void  CalculeUnicite()
        {
            if (SpvTypeq != null)
                Row[c_champACCES_UNICITE] = CSpvTypeq.c_nomTableInDb + "/" + SpvTypeq.Id.ToString() + "/" + NomAcces;
            else if (SpvSite != null)
                Row[c_champACCES_UNICITE] = CSpvSite.c_nomTableInDb + "/" + SpvSite.Id.ToString() + "/" + NomAcces;
            else if (SpvLiai != null)
                Row[c_champACCES_UNICITE] = CSpvLiai.c_nomTableInDb + "/" + SpvLiai.Id.ToString() + "/" + NomAcces;
            else
				throw new Exception(I.T("Unknown case in computing unicity|50008")); ;
        }*/

        //////////////////////////////////////////////////////////////
        public virtual CResultAErreur GenAccesAlarmeEquips()
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CSpvTypeq spvTypeq = SpvTypeq;
                if (spvTypeq != null)
                {
                    CSpvAccesAlarme spvAccesAlarme;
                    foreach (CSpvEquip spvEquip in spvTypeq.Equipements)
                    {
                        spvAccesAlarme = new CSpvAccesAlarme(ContexteDonnee);
                        spvAccesAlarme.CreateNewInCurrentContexte();
                        spvAccesAlarme.InitFromTypeAccesAlarme(this);
                        spvAccesAlarme.SpvEquip = spvEquip;
                    }
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        public virtual CResultAErreur MajAccesAlarmeEquips()
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CSpvTypeq spvTypeq = SpvTypeq;
                string strNom;
                if (spvTypeq != null)
                {
                    CSpvAccesAlarme spvAccesAlarme;
                    strNom = (string)Row[c_champACCES_NOM, DataRowVersion.Original];
                    foreach (CSpvEquip spvEquip in spvTypeq.Equipements)
                    {
                        spvAccesAlarme = spvEquip.GetAccesAlarme(strNom);
                        if (spvAccesAlarme != null)
                            spvAccesAlarme.InitFromTypeAccesAlarme(this);
                    }

                    // Les données "alarme fréquente" sont-elles modifiées ?
                    bool bChangeFreq = false;
                    if (this.AlarmeGeree != null && this.AlarmeGeree.Row.RowState == DataRowState.Modified)
                    {
                        Int32 nFreqnOld = (Int32)this.AlarmeGeree.Row[CSpvAlarmGeree.c_champALARMGEREE_FREQN, DataRowVersion.Original];
                        Int32 nFreqpOld = (Int32)this.AlarmeGeree.Row[CSpvAlarmGeree.c_champALARMGEREE_FREQD, DataRowVersion.Original];
                        if (nFreqnOld != this.AlarmeGeree.AlarmgereeFreqNb || nFreqpOld != this.AlarmeGeree.AlarmgereeFreqPeriod)
                            bChangeFreq = true;
                    }

                    if (this.AlarmeGeree != null && (this.AlarmeGeree.PropagerAuxEquipements || bChangeFreq))
                    {
                        foreach (CSpvLienAccesAlarme accesAccesc in this.AlarmeGeree.SpvAcces_Accescs)
                        {
                            if (this.AlarmeGeree.PropagerAuxEquipements)
                                accesAccesc.MajFromAlarmeGeree(this.AlarmeGeree);

                            // La partie "Alarme fréquente" n'est modifiable
                            // qu'au niveau de l'alarme gérée
                            if (bChangeFreq)
                                accesAccesc.MajFrequenceFromAlarmeGeree(this.AlarmeGeree);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }


        public CResultAErreur DeleteAccesAlarmeEquips()
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CListeObjetsDonnees listeEquip = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvEquip));
                Int32 nTypeqId = (Int32)Row[c_champTYPEQ_ID, DataRowVersion.Original];
                listeEquip.Filtre = new CFiltreData(CSpvEquip.c_champTYPEQ_ID + "=@1", nTypeqId);
                if (listeEquip.Count > 0)
                {
                    string strNomAcces = (string)Row[c_champACCES_NOM, DataRowVersion.Original];
                    foreach (CSpvEquip spvEquip in listeEquip)
                    {
                        CListeObjetsDonnees listeAcces = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvAccesAlarme));
                        listeAcces.Filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + "=@1 AND " + CSpvAccesAlarme.c_champACCES_NOM + "=@2",
                                                             spvEquip.Id, strNomAcces);
                        CSpvAccesAlarme spvAcces;
                        if (listeAcces.Count > 0)
                        {
                            spvAcces = (CSpvAccesAlarme)listeAcces[0];
                            spvAcces.Delete(true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }


        public CResultAErreur TraitementDelete()
        {
            if (Row[c_champTYPEQ_ID, DataRowVersion.Original].ToString().Length > 0)
                return DeleteAccesAlarmeEquips();
            else
                return CResultAErreur.True;

        }

        public static bool HasAlarmeGeree(int code)
        {
            return (code == (int)ECategorieAccesAlarme.SortieBoucle ||
                 code == (int)ECategorieAccesAlarme.TrapSnmp);
        }

        protected override void CodeCategorieAccesChanged()
        {
            GetAlarmeGereeAvecCreationSuppression();
        }

        //////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////

        public CSpvAlarmGeree GetAlarmeGereeAvecCreationSuppression()
        {
            CSpvAlarmGeree spvAlarmGeree = AlarmeGeree;
            if (!HasAlarmeGeree(CodeCategorieAcces))
            {
                if (spvAlarmGeree != null)
                    spvAlarmGeree.Delete(true);

                return null;
            }
            else
            {
                if (spvAlarmGeree == null)
                {
                    spvAlarmGeree = new CSpvAlarmGeree(ContexteDonnee);
                    spvAlarmGeree.CreateNewInCurrentContexte();
                    spvAlarmGeree.TypeAccesAlarme = this;
                    spvAlarmGeree.Alarmgeree_Name = NomAcces;
                }

                return spvAlarmGeree;
            }
        }
    }
}
