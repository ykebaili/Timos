using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.data;
using System.Collections;
using sc2i.formulaire;
using System.Drawing;
using sc2i.common.sig;

namespace futurocom.sig
{
    public delegate void ExecuteActionMapItemDelegate ( CActionSur2iLink action, IMapItem item );

    public class CMapDatabaseGenerator : IElementAVariableInstance,
        IElementAVariablesDynamiquesAvecContexteDonnee, 
        I2iSerializable
    {
        private const string c_strIdVariableObjetSource = "1";

        private C2iWndFenetre m_formulaireEdition;
        private List<IVariableDynamique> m_listeVariables = new List<IVariableDynamique>();
        private int m_nNextIdVariable = 10;

        //Non sérializée
        private Dictionary<string, object> m_tableValeursChamps = new Dictionary<string, object>();

        [NonSerialized]
        private CContexteDonnee m_contexteDonnee = null;

        private Type m_typeSource = null;

        private string m_strLayerId = "";

        private List<IMapItemGenerator> m_listeGenerateurs = new List<IMapItemGenerator>();

        private ExecuteActionMapItemDelegate m_executeurActions = null;

        public CMapDatabaseGenerator()
        {
            m_formulaireEdition = new C2iWndFenetre();
            m_formulaireEdition.Size = new Size(350, 100);
            m_strLayerId = Guid.NewGuid().ToString();
        }

        //-------------------------------------------------
        public string LayerId
        {
            get
            {
                return m_strLayerId;
            }
        }

        //-------------------------------------------------
        public Type TypeSource
        {
            get
            {
                return m_typeSource;
            }
            set
            {
                m_typeSource = value;
                AssureVariablesSysteme();
            }
        }

        //-------------------------------------------------
        public C2iWndFenetre Formulaire
        {
            get
            {
                if (m_formulaireEdition == null)
                {
                    m_formulaireEdition = new C2iWndFenetre();
                    m_formulaireEdition.Size = new Size(100, 40);
                }
                return m_formulaireEdition;
            }
            set
            {
                m_formulaireEdition = value;
            }
        }

        //-------------------------------------------------
        public CVariableDynamiqueSysteme VariableObjetSource
        {
            get
            {
                return GetVariable(c_strIdVariableObjetSource) as CVariableDynamiqueSysteme;
            }
        }

        //-------------------------------------------------
        private void AssureVariablesSysteme()
        {
            if (m_typeSource != null)
            {
                CVariableDynamiqueSysteme varSource = VariableObjetSource;
                if (varSource == null)
                {
                    varSource = new CVariableDynamiqueSysteme(this);
                    varSource.IdVariable = c_strIdVariableObjetSource;
                    varSource.Nom = "Source";
                    m_listeVariables.Add(varSource);
                }
                varSource.SetTypeDonnee(new CTypeResultatExpression(m_typeSource, false));
            }
        }

        //-------------------------------------------------
        public CContexteDonnee ContexteDonnee
        {
            get { return m_contexteDonnee; }
            set
            {
                m_contexteDonnee = value;
            }
        }

        //-------------------------------------------------
        public IContexteDonnee IContexteDonnee
        {
            get
            {
                return ContexteDonnee;
            }
        }

        //-------------------------------------------------
        public int IdSession
        {
            get
            {
                if (m_contexteDonnee != null)
                    return m_contexteDonnee.IdSession;
                return -1;
            }
        }


        //-------------------------------------------------
        public void AddVariable(IVariableDynamique variable)
        {
            m_listeVariables.Add(variable);
        }

        //-------------------------------------------------
        public string GetNewIdForVariable()
        {
            return CUniqueIdentifier.GetNew();
        }

        //-------------------------------------------------
        public CVariableDynamique GetVariable(string strIdVariable)
        {
            foreach (IVariableDynamique variable in m_listeVariables)
                if (variable.IdVariable == strIdVariable)
                    return variable as CVariableDynamique;
            return null;
        }

        //-------------------------------------------------
        public bool IsVariableUtilisee(IVariableDynamique variable)
        {
            if (variable is CVariableDynamiqueSysteme)
                return true;
            //A FAIRE
            return false;
        }

        //-------------------------------------------------
        public IVariableDynamique[] ListeVariables
        {
            get
            {
                AssureVariablesSysteme();
                return m_listeVariables.ToArray();
            }
        }

        //-------------------------------------------------
        public void OnChangeVariable(IVariableDynamique variable)
        {

        }

        //-------------------------------------------------
        public void RemoveVariable(IVariableDynamique variable)
        {
            if (!(variable is CVariableDynamiqueSysteme))
                m_listeVariables.Remove(variable);
        }



        //-------------------------------------------------
        public object GetValeurChamp(string strIdVariable)
        {
            object val = null;
            IVariableDynamique variable = GetVariable(strIdVariable);
            if (variable is CVariableDynamiqueCalculee)
                return ((CVariableDynamiqueCalculee)variable).GetValeur(this);
            m_tableValeursChamps.TryGetValue(strIdVariable, out val);
            if (val == null)
            {
                if (!m_tableValeursChamps.ContainsKey(strIdVariable))
                {
                    foreach (IVariableDynamique v in ListeVariables)
                    {
                        if (v.IdVariable == strIdVariable)
                        {
                            IVariableDynamiqueAValeurParDefaut vAvecDef = v as IVariableDynamiqueAValeurParDefaut;
                            if (vAvecDef != null)
                            {
                                val = vAvecDef.GetValeurParDefaut();
                            }
                            break;
                        }
                    }
                }
                m_tableValeursChamps[strIdVariable] = val;
            }
            return val;
        }

        //-------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable != null)
                return GetValeurChamp(variable.IdVariable);
            return null;
        }

        //-------------------------------------------------
        public IEnumerable<KeyValuePair<string, object>> ValeursVariables
        {
            get
            {
                return m_tableValeursChamps.ToArray();
            }
        }

        //-------------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            m_tableValeursChamps[strIdVariable] = valeur;
            return CResultAErreur.True;
        }

        //-------------------------------------------------
        public object ElementEdite
        {
            get
            {
                return GetValeurChamp(c_strIdVariableObjetSource);
            }
            set
            {
                SetValeurChamp(c_strIdVariableObjetSource, value);
            }
        }

        //-------------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable != null)
            {
                SetValeurChamp(variable.IdVariable, valeur);
            }
            return CResultAErreur.True;
        }

        //// /////////////////////////////////////////////////////////////
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type tp, int nNbNiveaux)
        {
            return GetDefinitionsChamps(tp, nNbNiveaux, null);
        }

        /// /////////////////////////////////////////////////////////////

        ///Si la definition demandée est une de mes variables et
        ///que la valeur de cette variable fournit des propriétés,
        ///retourne la valeur de cette variable
        private IFournisseurProprietesDynamiques GetFournisseurPourDefinitionChamp(CDefinitionProprieteDynamique definition, Type tp)
        {
            ///si le type est un IFournisseurProprietes,
            ///Regarde dans mes variables si j'en ai une qui contient un objet de ce
            ///type. Si oui, c'est lui qui sera  utilisé
            ///La méthode n'est pas parfaite théoriquement, mais elle fonctionne
            if (typeof(IFournisseurProprietesDynamiques).IsAssignableFrom(tp))
            {
                foreach (object valeurVariable in m_tableValeursChamps.Values)
                    if (valeurVariable != null && tp.IsAssignableFrom(valeurVariable.GetType()))
                        return (IFournisseurProprietesDynamiques)valeurVariable;
            }
            return null;
        }

        /// /////////////////////////////////////////////////////////////
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();
            foreach (CVariableDynamique variable in ListeVariables)
            {
                bool bHasSubs = !variable.TypeDonnee.IsArrayOfTypeNatif && CFournisseurGeneriqueProprietesDynamiques.HasSubProperties(variable.TypeDonnee.TypeDotNetNatif);
                CDefinitionProprieteDynamique def = new CDefinitionProprieteDynamiqueVariableDynamique(variable, bHasSubs);
                lst.Add(def);
            }
            return lst.ToArray();
        }

        /// /////////////////////////////////////////////////////////////
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type tp, int nNbNiveaux, CDefinitionProprieteDynamique defParente)
        {
            return GetDefinitionsChamps(tp, defParente);
        }

        //-------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet)
        {
            return GetDefinitionsChamps(objet, null);
        }

        //-------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            CDefinitionProprieteDynamique[] defs = new CDefinitionProprieteDynamique[0];
            if (objet.TypeAnalyse == GetType())
                return GetProprietesInstance();
            CFournisseurPropDynStd four = new CFournisseurPropDynStd(true);
            return four.GetDefinitionsChamps ( objet, defParente );
        }

        //-------------------------------------------------
        public IEnumerable<IMapItemGenerator> ItemsGenerators
        {
            get
            {
                return m_listeGenerateurs.AsReadOnly();
            }
            set
            {
                m_listeGenerateurs.Clear();
                if (value != null)
                {
                    foreach (IMapItemGenerator item in value)
                    {
                        item.Generator = this;
                        m_listeGenerateurs.Add(item);
                    }
                }
            }
        }

        //-------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.AttacheObjet(typeof(IElementAVariablesDynamiquesBase), this);
            serializer.TraiteInt(ref m_nNextIdVariable);

            ArrayList lstVariables = new ArrayList(m_listeVariables);
            result = serializer.TraiteArrayListOf2iSerializable(lstVariables);
            if (!result)
                return result;
            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                m_listeVariables.Clear();
                foreach (IVariableDynamique variable in lstVariables)
                    m_listeVariables.Add(variable);
            }

            result = serializer.TraiteObject<C2iWndFenetre>(ref m_formulaireEdition);
            if (!result)
                return result;

            serializer.AttacheObjet(typeof(IElementAVariablesDynamiquesBase), this);




            serializer.TraiteType(ref m_typeSource);

            result = serializer.TraiteListe<IMapItemGenerator>(m_listeGenerateurs, new object[] { this });
            if (!result)
                return result;

            return result;
        }

        //-------------------------------------------------
        public CResultAErreur FillMapDatabase(
            object objetSource,
            CMapDatabase database,
            CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            if (objetSource != null)
            {
                AssureVariablesSysteme();
                SetValeurChamp(c_strIdVariableObjetSource, objetSource);
            }
            foreach (IMapItemGenerator generateur in ItemsGenerators)
            {
                result = generateur.GenereItems(database, ctxDonnee);
                if (!result)
                    return result;
            }
            return result;
        }

        //-----------------------------------------------------------------------------
        public ExecuteActionMapItemDelegate ExecuteurAction
        {
            get
            {
                return m_executeurActions;
            }
            set
            {
                m_executeurActions = value;
            }
        }

        //-----------------------------------------------------------------------------
        public void ExecuteAction(CActionSur2iLink actionSurClick, IMapItem itemClicked)
        {
            if (ExecuteurAction != null)
                ExecuteurAction(actionSurClick, itemClicked);
        }

        //-----------------------------------------------------------------------------
        public void ClearVariables()
        {
            m_tableValeursChamps.Clear();
        }
    }
}
