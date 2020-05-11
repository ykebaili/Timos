using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.formulaire;
using sc2i.expression;
using System.Drawing;
using sc2i.win32.data.dynamic;
using timos.data;
using sc2i.formulaire.win32.editor;

namespace sc2i.data.dynamic.Macro
{
    public class CMacro : I2iSerializable, IElementAVariablesDynamiquesAvecContexteDonnee
    {
        private static string m_strIdVariableCurrentElement = "-1721";
        private string m_strLibelle = "";
        private List<IVariableDynamique> m_listeVariables = new List<IVariableDynamique>();
        private C2iWndFenetre m_formulaire = null;
        private Dictionary<IVariableDynamique, object> m_dicValeursVariables = new Dictionary<IVariableDynamique, object>();
        private int m_nIdNextVariable = 1;

        private string m_strIdVariableTargetElement = "-1";

        private Dictionary<string, CDbKey> m_dicVariableToInitialId = new Dictionary<string, CDbKey>();

        private List<CMacroObjet> m_listeObjets = new List<CMacroObjet>();


        private CContexteDonnee m_contexteDonnee = null;

        //-------------------------------------------------------
        public CMacro()
        {
        }
        
        //-------------------------------------------------------
        public C2iWndFenetre Formulaire
        {
            get
            {
                if (m_formulaire == null)
                {
                    m_formulaire = new C2iWndFenetre();
                    m_formulaire.Size = new Size(300, 200);
                }
                return m_formulaire;
            }
            set
            {
                m_formulaire = value;
            }
        }

        //-------------------------------------------------------
        public void SetInitialValue(IVariableDynamique variable, CObjetDonneeAIdNumerique objet)
        {
            if (variable != null)
            {
                if (objet == null)
                    m_dicVariableToInitialId[variable.IdVariable] = null;
                else
                    m_dicVariableToInitialId[variable.IdVariable] = objet.DbKey;
            }
        }


        //-------------------------------------------------------
        public IEnumerable<IVariableDynamique> Variables
        {
            get
            {
                return m_listeVariables.AsReadOnly();
            }
        }

        //-------------------------------------------------------
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

        //-------------------------------------------------------
        public IVariableDynamique VariableCible
        {
            get
            {
                return m_listeVariables.FirstOrDefault(v => v.IdVariable == m_strIdVariableTargetElement);
            }
            set
            {
                if (value != null)
                    m_strIdVariableTargetElement = value.IdVariable;
            }
        }

        //-------------------------------------------------------
        public string IdVariableTargetElement
        {
            get
            {
                return m_strIdVariableTargetElement;
            }
        }

        //-------------------------------------------------------
        public CVariableDynamiqueSysteme VariableCurrentElement
        {
            get
            {
                return m_listeVariables.FirstOrDefault(v => v.IdVariable == m_strIdVariableCurrentElement) as CVariableDynamiqueSysteme;
            }
        }

        //-------------------------------------------------------
        public void AddVariable(IVariableDynamique variable)
        {
            m_listeVariables.Add(variable);
        }

        //-------------------------------------------------------
        public void RemoveVariable(IVariableDynamique variable)
        {
            m_listeVariables.Remove(variable);
        }

        //-------------------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            m_dicValeursVariables[variable] = valeur;
            return CResultAErreur.True;
        }

        //-------------------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            IVariableDynamique v = m_listeVariables.FirstOrDefault(var => var.IdVariable == strIdVariable);
            if (v != null)
                return SetValeurChamp(v, valeur);
            return CResultAErreur.True;
        }

        //-------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            object valeur = null;
            m_dicValeursVariables.TryGetValue(variable, out valeur);
            return valeur;
        }

        //-------------------------------------------------------
        public object GetValeurChamp(string strIdVariable)
        {
            IVariableDynamique v = m_listeVariables.FirstOrDefault(var => var.IdVariable == strIdVariable);
            if (v != null)
                return GetValeurChamp(v);
            return null;
        }

        //-------------------------------------------------------
        public IEnumerable<CMacroObjet> Objets
        {
            get
            {
                return m_listeObjets.AsReadOnly();
            }
        }

        //-------------------------------------------------------
        public void AddObjet(CMacroObjet macroObjet)
        {
            m_listeObjets.Add(macroObjet);
        }

        //-------------------------------------------------------
        public void RemoveObjet(CMacroObjet macroObjet)
        {
            m_listeObjets.Remove(macroObjet);
        }



        //-------------------------------------------------------
        private int GetNumVersion()
        {
            //return 0;
            return 1; // Passages des Ids en DbKey
        }

        //-------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strLibelle);
            serializer.TraiteInt(ref m_nIdNextVariable);
            
            //TESTDBKEYOK
            if (nVersion < 1 && serializer.Mode == ModeSerialisation.Lecture)
            {
                int nIdTemp = -1;
                serializer.TraiteInt(ref nIdTemp);
                m_strIdVariableTargetElement = nIdTemp.ToString();
            }
            else
                serializer.TraiteString(ref m_strIdVariableTargetElement);

            serializer.AttacheObjet(typeof(IElementAVariablesDynamiquesBase), this);
            List<I2iSerializable> lst = new List<I2iSerializable>(from v in m_listeVariables where v is I2iSerializable select (I2iSerializable)v);
            result = serializer.TraiteListe<I2iSerializable>(lst, new object[] { this });
            if (!result)
                return result;
            if (serializer.Mode == ModeSerialisation.Lecture)
                m_listeVariables = new List<IVariableDynamique>(from v in lst where v is IVariableDynamique select (IVariableDynamique)v);

            int nNbValeursInitiales = m_dicVariableToInitialId.Count;
            serializer.TraiteInt(ref nNbValeursInitiales);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (KeyValuePair<string, CDbKey> kv in m_dicVariableToInitialId)
                    {
                        string strIdVar = kv.Key;
                        CDbKey dbKeyIdObj = kv.Value;
                        serializer.TraiteString(ref strIdVar);
                        serializer.TraiteDbKey(ref dbKeyIdObj);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_dicVariableToInitialId.Clear();
                    for (int n = 0; n < nNbValeursInitiales; n++)
                    {
                        CDbKey dbKeyTmp = null;
                        if (nVersion < 1)
                        {
                            int nIdVarTmp = 0;
                            serializer.TraiteInt(ref nIdVarTmp);
                            serializer.ReadDbKeyFromOldId(ref dbKeyTmp, null);
                            if (dbKeyTmp != null)
                                m_dicVariableToInitialId[nIdVarTmp.ToString()] = dbKeyTmp;
                        }
                        else
                        {
                            string strIdVar = "";
                            serializer.TraiteString(ref strIdVar);
                            serializer.TraiteDbKey(ref dbKeyTmp);
                            if (dbKeyTmp != null)
                                m_dicVariableToInitialId[strIdVar] = dbKeyTmp;
                        }
                    }
                    break;
            }

            result = serializer.TraiteObject<C2iWndFenetre>(ref m_formulaire);
            if (result)
                result = serializer.TraiteListe<CMacroObjet>(m_listeObjets, new object[]{this});
            if ( m_contexteDonnee != null && serializer.Mode == ModeSerialisation.Lecture)
                m_contexteDonnee = serializer.GetObjetAttache(typeof(CContexteDonnee)) as CContexteDonnee;
            serializer.DetacheObjet(typeof(IElementAVariablesDynamiquesBase), this);
            return result;
        }


        //-------------------------------------------------------
        public static CResultAErreurType<CMacro> FromVersion(CVersionDonnees version)
        {
            CResultAErreurType<CMacro> result = new CResultAErreurType<CMacro>();
            using ( CContexteDonnee contexte = new CContexteDonnee ( version.ContexteDonnee.IdSession, true, false ) )
            {
                contexte.SetVersionDeTravail ( version.Id, false );
                CMacro macro = new CMacro();
                macro.m_contexteDonnee = version.ContexteDonnee;
                macro.Libelle = version.Libelle;

                CVariableDynamiqueSysteme variable = new CVariableDynamiqueSysteme();
                variable.SetTypeDonnee( new CTypeResultatExpression(typeof(string), false));
                variable.Nom = "CurrentElement";
                variable.IdVariable = m_strIdVariableCurrentElement;
                macro.AddVariable ( variable );

                Dictionary<int, CMacroObjet> dicMacrosObjets = new Dictionary<int, CMacroObjet>();
                Dictionary<CObjetDonneeAIdNumerique, CMacroObjet> dicObjetToMacros = new Dictionary<CObjetDonneeAIdNumerique, CMacroObjet>();
                foreach (CVersionDonneesObjet vo in version.VersionsObjets)
                {
                    if (!typeof(CRelationElementAChamp_ChampCustom).IsAssignableFrom(vo.TypeElement) && vo.TypeElement.GetCustomAttributes(typeof(NoMacroAttribute), true).Length == 0)
                    {
                        CMacroObjet mo = new CMacroObjet(macro);
                        mo.TypeObjet = vo.TypeElement;
                        mo.IdObjet = vo.IdElement;
                        mo.TypeOperation = vo.TypeOperation;
                        macro.AddObjet(mo);

                        dicMacrosObjets[vo.Id] = mo;
                        CObjetDonneeAIdNumerique objet = Activator.CreateInstance(vo.TypeElement, new object[] { contexte }) as CObjetDonneeAIdNumerique;
                        if (objet.ReadIfExists(vo.IdElement))
                            dicObjetToMacros[objet] = mo;
                        mo.CreateVariable(objet);
                    }
                   
                }
                foreach ( CVersionDonneesObjet vo in version.VersionsObjets )
                {
                    if (!typeof(CRelationElementAChamp_ChampCustom).IsAssignableFrom(vo.TypeElement) && vo.TypeElement.GetCustomAttributes(typeof(NoMacroAttribute), true).Length == 0)
                    {
                        CMacroObjet mo = dicMacrosObjets[vo.Id];
                        CResultAErreur resMo = CResultAErreur.True;
                        resMo = mo.FillFromVersion(vo, contexte, dicObjetToMacros);
                        if (!resMo)
                            result.EmpileErreur(resMo.Erreur);
                    }
                }
                result.DataType = macro;
                return result;
            }
            
        }
       
        //--------------------------------
        public int IdSession
        {
            get { return m_contexteDonnee != null?m_contexteDonnee.IdSession:0; }
        }

        //--------------------------------
        public CContexteDonnee ContexteDonnee
        {
            get { return m_contexteDonnee; }
            set
            {
                m_contexteDonnee = value;
            }
        }

        //-------------------------------------------------------------
        public IContexteDonnee IContexteDonnee
        {
            get
            {
                return ContexteDonnee;
            }
        }

        //--------------------------------
        public string GetNewIdForVariable()
        {
            return CUniqueIdentifier.GetNew();
        }

        //--------------------------------
        public void OnChangeVariable(IVariableDynamique variable)
        {
            foreach (CMacroObjet mo in Objets)
            {
                mo.OnChangeVariable(variable);
            }
        }

        //--------------------------------
        public IVariableDynamique[] ListeVariables
        {
            get { return Variables.ToArray(); }
        }

        //--------------------------------
        public bool IsVariableUtilisee(IVariableDynamique variable)
        {
            foreach ( CMacroObjet mac in Objets )
            {
                if ( mac.IsVariableUtilisee ( variable ) )
                    return true;
            }
            return false;
        }

        //--------------------------------
        public CVariableDynamique GetVariable(string strIdVariable)
        {
            return m_listeVariables.FirstOrDefault(v => v.IdVariable == strIdVariable) as CVariableDynamique;
        }

        //--------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();
            foreach ( IVariableDynamique variable in Variables )
            {
                if ( variable is CVariableDynamique )
                    lst.Add ( new CDefinitionProprieteDynamiqueVariableDynamique((CVariableDynamique)variable) );
            }
            return lst.ToArray();

        }



        //------------------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux)
        {
            return GetDefinitionsChamps(new CObjetPourSousProprietes(typeInterroge), null);
        }

        //------------------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux, CDefinitionProprieteDynamique defParente)
        {
            return GetDefinitionsChamps(new CObjetPourSousProprietes(typeInterroge), null);
        }

        //------------------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet)
        {
            return GetDefinitionsChamps(objet, null);
        }

        //------------------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();
            CFournisseurPropDynStd fournisseur = new CFournisseurPropDynStd(true);
            if ( objet.TypeAnalyse == typeof(CMacro) )
            {
                foreach (CVariableDynamique variable in Variables)
                {
                    lst.Add(new CDefinitionProprieteDynamiqueVariableDynamique(variable, fournisseur.HasSubProperties ( variable.TypeDonnee.TypeDotNetNatif )));
                }
            }
            else
                lst.AddRange ( fournisseur.GetDefinitionsChamps ( objet, defParente ));
            return lst.ToArray();
        }

        //------------------------------------------------------------------------------------------
        public CResultAErreur Execute(CContexteExecutionMacro contexteExecution)
        {
            CResultAErreur result = CResultAErreur.True;

            //Initialise les valeurs des variables
            foreach (KeyValuePair<string, CDbKey> kv in m_dicVariableToInitialId)
            {
                IVariableDynamique var = GetVariable(kv.Key);
                if (var != null && kv.Value != null)
                {
                    Type tpObjet = var.TypeDonnee.TypeDotNetNatif;
                    if (typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(tpObjet))
                    {
                        try
                        {
                            CObjetDonneeAIdNumerique obj = Activator.CreateInstance(tpObjet, new object[] { contexteExecution.ContexteDonnee }) as CObjetDonneeAIdNumerique;
                            if (obj != null && obj.ReadIfExists(kv.Value))
                                SetValeurChamp(kv.Key, obj);

                        }
                        catch { }
                    }
                }
            }

            IVariableDynamique variable = VariableCible;
            if (variable == null)
            {
                result.EmpileErreur("#Macro target is not specified");
                return result;
            }
            if ( contexteExecution.Cible != null &&  variable.TypeDonnee.TypeDotNetNatif != contexteExecution.Cible.GetType() )
            {
                result.EmpileErreur("#Macro must be applied on "+DynamicClassAttribute.GetNomConvivial ( variable.TypeDonnee.TypeDotNetNatif ));
                return result;
            }
            SetValeurChamp(variable.IdVariable, contexteExecution.Cible);
            if ( Formulaire != null )
            {
                if ( CFormFormulairePopup.EditeElement ( Formulaire, this, "MACRO") )
                {
                    foreach ( CMacroObjet macObj in Objets )
                    {
                        macObj.Execute(contexteExecution);
                    }
                }
            }
            return result;
        }

    }
}