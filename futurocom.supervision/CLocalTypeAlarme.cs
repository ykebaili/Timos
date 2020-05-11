using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.expression;
using sc2i.common;
using System.Drawing;

namespace futurocom.supervision
{
    [MemoryTable(CLocalTypeAlarme.c_nomTable, CLocalTypeAlarme.c_champId)]
    public class CLocalTypeAlarme : CEntiteDeMemoryDb, IFournisseurProprietesDynamiques
    {
        public const string c_nomTable = "ALARM_TYPE";
        public const string c_champId = "ALTP_ID";
        public const string c_champLibelle = "ALTP_LABEL";
        public const string c_champIdParent = "ALTP_PARENT_ID";
        public const string c_champActionsSurParent = "ALTP_PARENT_ACTION";
        public const string c_champFormuleLibelle = "ALTP_LABEL_FORMULA";
        public const string c_champEtatParDefaut = "ALTP_DEFAULT_STATE";
        public const string c_champModeCalculEtat = "ALTP_STATE_MODE";
        public const string c_champRegrouperSurLaCle = "ALTP_GROUP_ON_KEY";
        public const string c_champAAcquitter = "ALTP_TO_ACK";
        public const string c_champTypeElementSupervise = "ALTP_SUP_TYPE";

        //-------------------------------------------
        public CLocalTypeAlarme(CMemoryDb db) :
            base(db)
        {
        }

        //-------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            EtatDefaut = EEtatAlarme.Open;
            ModeCalculEtat = EModeCalculEtatParent.AllChildsClosed;
            RegrouperSurLaCle = true;
        }

        //-------------------------------------------
        public CLocalTypeAlarme(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------
        [MemoryField(c_champLibelle)]
        [DynamicField("Label")]
        [DescriptionField]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-------------------------------------------
        public IEnumerable<CLocalChampTypeAlarme> TousLesChampsCles
        {
            get
            {
                List<CLocalChampTypeAlarme> lst = new List<CLocalChampTypeAlarme>();
                if (TypeParent != null)
                    lst.AddRange(TypeParent.TousLesChampsCles);
                foreach (CLocalRelationTypeAlarmeChampAlarme rel in RelationsChamps)
                    if (rel.IsKey)
                        lst.Add(rel.Champ);
                return lst.AsReadOnly();
            }
        }

        //-------------------------------------------
        public IEnumerable<CLocalChampTypeAlarme> TousLesChamps
        {
            get
            {
                List<CLocalChampTypeAlarme> lst = new List<CLocalChampTypeAlarme>();
                foreach (CLocalRelationTypeAlarmeChampAlarme rel in RelationsChamps)
                    lst.Add(rel.Champ);
                if (TypeParent != null)
                    lst.AddRange(TypeParent.TousLesChamps);
                return lst.AsReadOnly();
            }
        }

        //-------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CLocalRelationTypeAlarmeChampAlarme> RelationsChamps
        {
            get { return GetFils<CLocalRelationTypeAlarmeChampAlarme>(); }
        }


        //-------------------------------------
        [MemoryParent(c_champIdParent, true)]
        [DynamicField("Parent Type")]
        public CLocalTypeAlarme TypeParent
        {
            get
            {
                return GetParent<CLocalTypeAlarme>(c_champIdParent);
            }
            set
            {
                SetParent<CLocalTypeAlarme>(value, c_champIdParent);
            }
        }

        //-------------------------------------
        [MemoryChild]
        [DynamicChilds("Child Types", typeof(CLocalTypeAlarme))]
        public CListeEntitesDeMemoryDb<CLocalTypeAlarme> TypesFils
        {
            get { return GetFils<CLocalTypeAlarme>(c_champIdParent); }
        }

        //-------------------------------------
        [MemoryField(c_champActionsSurParent)]
        public C2iExpression ActionsSurParent
        {
            get
            {
                return Row.Get<C2iExpression>(c_champActionsSurParent);
            }
            set
            {
                Row[c_champActionsSurParent] = value;
            }
        }

        //-------------------------------------
        [MemoryField(c_champFormuleLibelle)]
        public C2iExpression FormuleLibelle
        {
            get
            {
                return Row.Get<C2iExpression>(c_champFormuleLibelle);
            }
            set
            {
                Row[c_champFormuleLibelle] = value;
            }
        }
        //-------------------------------------
        [MemoryField(c_champEtatParDefaut)]
        [DynamicField("Default State")]
        public EEtatAlarme EtatDefaut
        {
            get
            {
                return Row.Get<EEtatAlarme>(c_champEtatParDefaut);
            }
            set
            {
                Row[c_champEtatParDefaut] = value;
            }
        }

        //----------------------------------------------------------------------------
        [MemoryField(c_champRegrouperSurLaCle)]
        public bool RegrouperSurLaCle
        {
            get
            {
                if (TypesFils.Count() != 0)
                    return true;
                return Row.Get<bool>(c_champRegrouperSurLaCle);
            }
            set
            {
                Row[c_champRegrouperSurLaCle] = value;
            }
        }

        //----------------------------------------------------------------------------
        [MemoryField(c_champAAcquitter)]
        [DynamicField("To Acknowledge")]
        public bool AAcquitter
        {
            get
            {
                return Row.Get<bool>(c_champAAcquitter);
            }
            set
            {
                Row[c_champAAcquitter] = value;
            }
        }

        //----------------------------------------------------------------------------
        [MemoryField(c_champTypeElementSupervise)]
        public ETypeElementSupervise TypeElementSupervise
        {
            get
            {
                return Row.Get<ETypeElementSupervise>(c_champTypeElementSupervise);
            }
            set
            {
                Row[c_champTypeElementSupervise] = value;
            }
        }

        //----------------------------------------------------------------------------
        [MemoryField(c_champModeCalculEtat)]
        [DynamicField("Parent State Mode")]
        public EModeCalculEtatParent ModeCalculEtat
        {
            get
            {
                return Row.Get<EModeCalculEtatParent>(c_champModeCalculEtat);
            }
            set
            {
                Row[c_champModeCalculEtat] = value;
            }
        }

        //----------------------------------------------------------------------------
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

        //----------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            List<CDefinitionProprieteDynamique> lstDefs = new List<CDefinitionProprieteDynamique>();
            if (typeof(CLocalAlarme).IsAssignableFrom(objet.TypeAnalyse))
            {
                CLocalTypeAlarme typeAlarme = this;
                while (typeAlarme != null)
                {
                    foreach (CLocalRelationTypeAlarmeChampAlarme rel in typeAlarme.RelationsChamps)
                    {
                        lstDefs.Add(new CDefinitionProprieteDynamiqueChampAlarme(rel.Champ));
                    }
                    typeAlarme = typeAlarme.TypeParent;
                }
            }
            lstDefs.AddRange(new CFournisseurGeneriqueProprietesDynamiques().GetDefinitionsChamps(objet));
            return lstDefs.ToArray();
        }

        //-----------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet)
        {
            return GetDefinitionsChamps(objet, null);
        }

        //-----------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux, CDefinitionProprieteDynamique defParente)
        {
            return GetDefinitionsChamps(typeInterroge, null);
        }

        //-----------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux)
        {
            return GetDefinitionsChamps(typeInterroge, null);
        }

        //-----------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------
        protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = SerializeChamps(serializer,
                c_champLibelle,
                c_champActionsSurParent,
                c_champFormuleLibelle,
                c_champEtatParDefaut, 
                c_champModeCalculEtat,
                c_champRegrouperSurLaCle,
                c_champAAcquitter);
            if (result)
                result = SerializeParent<CLocalTypeAlarme>(serializer, c_champIdParent);
            if (result)
                result = SerializeChilds<CLocalTypeAlarme>(serializer, c_champIdParent);
            if (result)
                result = SerializeChilds<CLocalRelationTypeAlarmeChampAlarme>(serializer);
            if (!result)
                return result;

            result = SerializeParent<CLocalSeveriteAlarme>(serializer);


            return result;
        }
    }
}
