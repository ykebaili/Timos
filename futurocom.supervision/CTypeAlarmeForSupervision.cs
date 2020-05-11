using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.supervision
{
    [Serializable]
    public class CLocalTypeAlarme : CLocalTypeAlarme, I2iSerializable
    {
        private string m_strLibelle = "";
        private List<CLocalChampTypeAlarme> m_listeChamps = new List<CLocalChampTypeAlarme>();
        private string m_strId = Guid.NewGuid().ToString();

        private List<CLocalTypeAlarme> m_typesFils = new List<CLocalTypeAlarme>();
        private CLocalTypeAlarme m_typeParent = null;


        private C2iExpression m_actionsSurParent = null;

        private C2iExpression m_formuleLibelle = null;

        private EEtatAlarme m_etatDefault = EEtatAlarme.Open;
        private EModeCalculEtatParent m_modeCalculEtat = EModeCalculEtatParent.AllChildsClosed;



        //-----------------------------
        public CLocalTypeAlarme()
        {
        }


        //-----------------------------
        public string Id
        {
            get
            {
                return m_strId;
            }
            set
            {
                m_strId = value;
            }
        }
        //-----------------------------
        public string Libelle
        {
            get
            {
                return m_strLibelle;
            }
            set
            {
                m_strLibelle = value;
            }
        }

        //-----------------------------
        public IEnumerable<CLocalChampTypeAlarme> TousLesChampsCles
        {
            get
            {
                List<CLocalChampTypeAlarme> lst = new List<CLocalChampTypeAlarme>();
                lst.AddRange(from c in Champs where c.IsKey select c);
                if (TypeParent != null)
                    lst.AddRange(TypeParent.TousLesChampsCles);
                lst.Sort((x, y) => x.NomChamp.CompareTo(y.NomChamp));
                return lst.ToArray();
            }
        }

        //-----------------------------
        public IEnumerable<CLocalChampTypeAlarme> TousLesChamps
        {
            get
            {
                List<CLocalChampTypeAlarme> lst = new List<CLocalChampTypeAlarme>();
                lst.AddRange(Champs);
                if (TypeParent != null)
                    lst.AddRange(TypeParent.TousLesChamps);
                return lst.ToArray();
            }
        }

        
        //-----------------------------
        public IEnumerable<CLocalChampTypeAlarme> Champs
        {
            get { return m_listeChamps.AsReadOnly(); }
        }

        //-----------------------------
        public bool AddChamp(CLocalChampTypeAlarme champ)
        {
            if ( champ == null )
                return false;
            if ( m_listeChamps.FirstOrDefault(c=>c.NomChamp.ToUpper() == champ.NomChamp ) != null )
                return false;
            m_listeChamps.Add(champ);
            return true;
        }

        //-----------------------------
        public void RemoveChamp(CLocalChampTypeAlarme champ)
        {
            if ( champ != null )
                m_listeChamps.Remove ( champ );
        }

        //-----------------------------
        public void ClearChamps()
        {
            m_listeChamps.Clear();
        }

        //----------------------------------------------
        public IEnumerable<CLocalTypeAlarme> TypesFils
        {
            get
            {
                return m_typesFils.ConvertAll(t=>t as CLocalTypeAlarme).AsReadOnly();
            }
        }

        //----------------------------------------------
        public void AddTypeFils(CLocalTypeAlarme type)
        {

            m_typesFils.Add(type as CLocalTypeAlarme);
            if (type.TypeParent != this)
                type.TypeParent = this;
        }

        //----------------------------------------------
        public void RemoveTypeFils(CLocalTypeAlarme type)
        {
            if (m_typesFils.Contains(type))
            {
                m_typesFils.Remove(type);
                if (type.TypeParent == this)
                    type.TypeParent = null;
            }
        }

        //----------------------------------------------
        public CLocalTypeAlarme TypeParent
        {
            get
            {
                return m_typeParent;
            }
            set
            {
                if (value != m_typeParent)
                {
                    if (m_typeParent != null)
                        m_typeParent.RemoveTypeFils(this);
                }
                m_typeParent = value;
                if (value != null && !value.TypesFils.Contains(this))
                    value.AddTypeFils(this);
            }
        }

        

        //----------------------------------------------
        public C2iExpression ActionsSurParent
        {
            get
            {
                return m_actionsSurParent;
            }
            set
            {
                m_actionsSurParent = value;
            }
        }


        //-----------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            List<CDefinitionProprieteDynamique> lstDefs = new List<CDefinitionProprieteDynamique>();
            if (typeof(IAlarme).IsAssignableFrom(objet.TypeAnalyse))
            {
                CLocalTypeAlarme typeAlarme = this;
                while (typeAlarme != null)
                {
                    foreach (CLocalChampTypeAlarme champ in typeAlarme.Champs)
                    {
                        lstDefs.Add(new CDefinitionProprieteDynamiqueChampAlarme(champ));
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
            return GetDefinitionsChamps ( objet, null );
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
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            serializer.TraiteString ( ref m_strId );
            serializer.TraiteString ( ref m_strLibelle );

            result = serializer.TraiteListe<CLocalChampTypeAlarme>( m_listeChamps );
            if ( result )
            {
                if (serializer.Mode == ModeSerialisation.Ecriture)
                {
                    List<CLocalTypeAlarme> lst = new List<CLocalTypeAlarme>(from t in TypesFils where t is CLocalTypeAlarme select t as CLocalTypeAlarme);
                    result = serializer.TraiteListe<CLocalTypeAlarme>(lst);
                }
                if (serializer.Mode == ModeSerialisation.Lecture)
                {
                    List<CLocalTypeAlarme> lst = new List<CLocalTypeAlarme>();
                    result = serializer.TraiteListe<CLocalTypeAlarme>(lst);
                    m_typesFils = new List<CLocalTypeAlarme>(lst.ConvertAll(t => t as CLocalTypeAlarme));
                    foreach (CLocalTypeAlarme type in m_typesFils)
                        type.TypeParent = this;
                }
            }
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_actionsSurParent);

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleLibelle);

            int nTmp = (int)ModeCalculEtat;
            serializer.TraiteInt(ref nTmp);
            ModeCalculEtat = (EModeCalculEtatParent)nTmp;

            nTmp = (int)m_etatDefault;
            serializer.TraiteInt(ref nTmp);
            m_etatDefault = (EEtatAlarme)nTmp;


            return result;

        }


        //-------------------------------------
        public C2iExpression FormuleLibelle
        {
            get
            {
                return m_formuleLibelle;
            }
            set
            {
                m_formuleLibelle = value;
            }
        }

        //-------------------------------------
        public EEtatAlarme EtatDefaut
        {
            get
            {
                return m_etatDefault;
            }
            set
            {
                m_etatDefault = value;
            }
        }


        //-------------------------------------
        public EModeCalculEtatParent ModeCalculEtat
        {
            get
            {
                return m_modeCalculEtat;
            }
            set
            {
                m_modeCalculEtat = value;
            }
        }
            
        


        
    }
}
