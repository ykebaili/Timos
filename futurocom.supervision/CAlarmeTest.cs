using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.supervision
{
    [Serializable]
    public class CAlarmeTest : IAlarme
    {
        private CLocalTypeAlarme m_typeAlarme = null;
        private Dictionary<string, object> m_dicValeursVariables = new Dictionary<string, object>();
        private DateTime m_dateDebut;
        private DateTime? m_dateFin = null;

        private CEtatAlarme m_etat = null;

        private List<IAlarme> m_listeAlarmesFilles = new List<IAlarme>();
        private IAlarme m_alarmeParente;
        private string m_strId = Guid.NewGuid().ToString();

        //----------------------------------------------
        private IGestionnaireAlarmes m_gestionnaireAlarmes;

        //----------------------------------------------
        public CAlarmeTest( )
            :this ( null )
        {
        }

        //----------------------------------------------
        public string Id
        {
            get
            {
                return m_strId;
            }
        }

        //----------------------------------------------
        public CAlarmeTest ( IGestionnaireAlarmes gestionnaireAlarmes )
        {
            m_dateDebut = DateTime.Now;
            m_etat = new CEtatAlarme(EEtatAlarme.Unknown);
            m_gestionnaireAlarmes = gestionnaireAlarmes;
        }

        //----------------------------------------------
        public IGestionnaireAlarmes Gestionnaire
        {
            get
            {
                return m_gestionnaireAlarmes;
            }
        }
        
        //----------------------------------------------
        [DynamicField("Alarm type")]
        public CLocalTypeAlarme TypeAlarme
        {
            get
            {
                return m_typeAlarme;    
            }
            set
            {
                if (m_typeAlarme == null && value != null)
                    EtatInt = (int)value.EtatDefaut;
                m_typeAlarme = value;
                
            }
        }

        //----------------------------------------------
        [DynamicField("Start date")]
        public DateTime DateDebut
        {
            get
            {
                return m_dateDebut;
            }
            set
            {
                m_dateDebut = value;
            }
        }

        //----------------------------------------------
        [DynamicField("End date")]
        public DateTime? DateFin
        {
            get
            {
                return m_dateFin;
            }
            set
            {
                m_dateFin = value;
            }
        }

        //----------------------------------------------
        [DynamicField("State")]
        public CEtatAlarme Etat
        {
            get
            {
                if ( m_etat == null )
                    return new CEtatAlarme (EEtatAlarme.Unknown );
                return m_etat;
            }
            set
            {
                m_etat = value;
                if (value == null)
                    m_etat = new CEtatAlarme(EEtatAlarme.Unknown);
                else
                {
                    if (value.Code == EEtatAlarme.Close)
                    {
                        m_dateFin = DateTime.Now;
                        foreach (IAlarme fille in Childs)
                            fille.CloseFromParent();
                    }
                    else
                        m_dateFin = null;
                }
                if (Parent != null)
                    Parent.CalculeEtatFromChilds();
            }
        }

        //----------------------------------------------
        public void CloseFromParent()
        {
            if (m_etat.Code != EEtatAlarme.Close)
            {
                m_etat = new CEtatAlarme(EEtatAlarme.Close);
                m_dateFin = DateTime.Now;
            }
        }
            

        //----------------------------------------------
        [DynamicField("State code")]
        public int EtatInt
        {
            get
            {
                return Etat.CodeInt;
            }
            set
            {
                Etat = new CEtatAlarme ((EEtatAlarme)value);
            }
        }

        //----------------------------------------------
        public string Libelle
        {
            get
            {
                if (TypeAlarme != null)
                {
                    C2iExpression formule = TypeAlarme.FormuleLibelle;
                    if (formule != null)
                    {
                        CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                        CResultAErreur result = formule.Eval(ctx);
                        if (result && result.Data != null)
                            return result.Data.ToString();
                    }
                }
                string strLib = DateDebut.ToShortDateString() + " " + DateDebut.ToShortTimeString();
                if (TypeAlarme != null)
                    strLib = TypeAlarme.Libelle + " " + strLib;
                return strLib;
            }
        }
                        



        //----------------------------------------------
        public object GetValeurChamp(string strIdChamp)
        {
            if (strIdChamp == null)
                return null;
            object valeur = null;
            m_dicValeursVariables.TryGetValue(strIdChamp, out valeur);
            return valeur;
        }

        //----------------------------------------------
        public void SetValeurChamp(string strIdChamp, object value)
        {
            if (strIdChamp != null)
                m_dicValeursVariables[strIdChamp] = value;
        }




        //----------------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            if ( TypeAlarme != null )
            {
                return TypeAlarme.GetDefinitionsChamps(typeof(CLocalTypeAlarme));
            }
            return new CDefinitionProprieteDynamique[0];
        }

        //----------------------------------------------
        public IEnumerable<IAlarme> Childs
        {
            get
            {
                return m_listeAlarmesFilles.AsReadOnly();
            }
        }

        //----------------------------------------------
        public void AddChild(IAlarme alarme)
        {
            m_listeAlarmesFilles.Add(alarme);
            if (alarme.Parent != this)
                alarme.Parent= this;
        }

        //----------------------------------------------
        public void RemoveChild(IAlarme alarme)
        {
            m_listeAlarmesFilles.Remove(alarme);
            if (alarme.Parent == this)
                alarme.Parent = null;
        }

        //----------------------------------------------
        public IAlarme Parent
        {
            get
            {
                return m_alarmeParente;
            }
            set
            {
                if (value != m_alarmeParente)
                {
                    if (m_alarmeParente != null)
                        m_alarmeParente.RemoveChild (this);
                }
                m_alarmeParente = value;
                if (value != null && !value.Childs.Contains(this))
                    value.AddChild(this);
            }
        }

        //----------------------------------------------
        public void CalculeEtatFromChilds()
        {
            if (TypeAlarme == null || m_listeAlarmesFilles.Count == 0 )
                return;

            switch (TypeAlarme.ModeCalculEtat)
            {
                case EModeCalculEtatParent.AllChildsClosed:
                    bool bAllClose = true;
                    foreach (IAlarme alrm in m_listeAlarmesFilles)
                    {
                        if (alrm.Etat.Code == EEtatAlarme.Open)
                        {
                            bAllClose = false;
                            break;
                        }
                    }
                    if (bAllClose)
                    {
                        EtatInt = (int)EEtatAlarme.Close;
                    }
                    break;
                case EModeCalculEtatParent.OneChildClosed :
                    foreach (IAlarme alrm in m_listeAlarmesFilles)
                    {
                        if (alrm.Etat.Code == EEtatAlarme.Close)
                        {
                            EtatInt = (int)EEtatAlarme.Close;
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
        private string CalcKey(CLocalTypeAlarme type, IAlarme alarmePossédantLesChamps)
        {
            if (type == null)
                return alarmePossédantLesChamps.Id;
            StringBuilder bl = new StringBuilder();
            bl.Append(type.Id);
            bl.Append('~');
            foreach (CLocalChampTypeAlarme champ in type.TousLesChampsCles)
            {
                object val = GetValeurChamp(champ.NomChamp);
                string strVal = val == null ? "null" : val.ToString();
                bl.Append(strVal);
                bl.Append('~');
            }
            if (bl.Length == 0)
                bl.Append(alarmePossédantLesChamps.Id);
            return bl.ToString();
        }

        //----------------------------------------------
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
        



        
    }
}
