using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using System.Reflection;
using tiag.client;

namespace sc2i.data.dynamic.Macro
{
    public class CMacroObjetValeur : I2iSerializable
    {
        private CMacroObjet m_macroObjet = null;
        private C2iExpression m_formuleValeur = null;
        private CDefinitionProprieteDynamique m_champ = null;
        
        //Contient le GUID d'un objet modifié par la même macro. Si non vide->pas de formule de valeur
        private string m_strGUIDReference = "";

        public CMacroObjetValeur()
        {
        }

        public CMacroObjetValeur(CMacroObjet macroObjet)
        {
            m_macroObjet = macroObjet;
        }

        //----------------------------------------------------
        public CMacroObjet MacroObjet
        {
            get
            {
                return m_macroObjet;
            }
        }

        //----------------------------------------------------
        public C2iExpression FormuleValeur
        {
            get
            {
                return m_formuleValeur;
            }
            set
            {
                m_formuleValeur = value;
            }
        }

        //----------------------------------------------------
        public string IdReference
        {
            get
            {
                return m_strGUIDReference;
            }
            set
            {
                m_strGUIDReference = value;
            }
        }

        //----------------------------------------------------
        public CDefinitionProprieteDynamique Champ
        {
            get
            {
                return m_champ;
            }
            set
            {
                m_champ = value;
            }
        }

        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strGUIDReference);
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleValeur);
            if (result)
                result = serializer.TraiteObject<CDefinitionProprieteDynamique>(ref m_champ);
            return result;
        }

        internal void OnChangeVariable(IVariableDynamique variable)
        {
            CDefinitionProprieteDynamique defProp = new CDefinitionProprieteDynamiqueVariableDynamique(variable as CVariableDynamique);
            if (FormuleValeur != null)
            {
                foreach (C2iExpressionChamp expChamp in FormuleValeur.ExtractExpressionsType(typeof(C2iExpressionChamp)))
                {
                    CDefinitionProprieteDynamiqueVariableDynamique defVar = expChamp.DefinitionPropriete as CDefinitionProprieteDynamiqueVariableDynamique;
                    if (defVar != null && defVar.IdChamp == variable.IdVariable)
                        expChamp.DefinitionPropriete = defProp;
                }
            }
        }

        internal CResultAErreur Execute(CObjetDonneeAIdNumerique cible)
        {
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(MacroObjet.Macro);
            CResultAErreur result = FormuleValeur.Eval(ctx);
            if (result)
            {
                try
                {
                    if (!m_champ.IsReadOnly)
                    {
                        CInterpreteurProprieteDynamique.SetValue(cible, m_champ, result.Data);
                    }
                    else//Peut être un champ forçable pour les macros
                    {
                        CDefinitionProprieteDynamiqueDotNet defDotNet = m_champ as CDefinitionProprieteDynamiqueDotNet;
                        if (defDotNet != null)
                        {
                            PropertyInfo info = info = cible.GetType().GetProperty ( defDotNet.NomProprieteSansCleTypeChamp);
                            if ( info != null  )
                            {
                                object[] attrs = info.GetCustomAttributes ( typeof(TiagRelationAttribute), true);
                                if ( attrs != null && attrs.Length > 0 )
                                {
                                    TiagRelationAttribute att = (TiagRelationAttribute)attrs[0] ;
                                        MethodInfo meth = cible.GetType().GetMethod ( att.NomMethodeSetClesParentes );
                                    if ( meth != null )
                                    {
                                        object[] lstCles = null;
                                        CObjetDonnee obj = result.Data as CObjetDonnee;
                                        if ( obj == null )
                                            lstCles = new object[1];
                                        else
                                            lstCles = obj.GetValeursCles();
                                        meth.Invoke ( cible, new object[]{lstCles} );
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    result.EmpileErreur(new CErreurException(e));
                    result.EmpileErreur("#Error while affecting property " + m_champ.Nom);
                }
            }
            return result;
        }
    }
}
