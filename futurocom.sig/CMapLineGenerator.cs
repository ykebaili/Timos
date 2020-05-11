using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.common.sig;
using sc2i.data;
using System.Data;
using sc2i.formulaire;
using System.Drawing;

namespace futurocom.sig
{
    public class CMapLineGenerator : IMapItemGenertorFromEntities, 
        IElementAVariableInstance
    {
        private string m_strLibelle = "";
        private CFiltreDynamique m_filtreDynamique;
        private CMapDatabaseGenerator m_generateur = null;
        private C2iExpression m_formuleLatitude1 = null;
        private C2iExpression m_formuleLongitude1 = null;
        private C2iExpression m_formuleLatitude2 = null;
        private C2iExpression m_formuleLongitude2 = null;
        private CActionSur2iLink m_actionSurClick = null;

        private List<CMapLineDessin> m_listeAlternativesDessin = new List<CMapLineDessin>();

        private object m_currentGeneratedItem = null;

        //-------------------------------------------------------------
        public CMapLineGenerator()
        {
            Libelle = GeneratorName;
            CMapLineDessin config = new CMapLineDessin(this);
            config.LineColor = Color.Blue;
            config.LineWidth = 2;
            config.FormuleCondition = new C2iExpressionVrai();
            m_listeAlternativesDessin.Add(config);
        }

        //-------------------------------------------------------------
        public CMapLineGenerator(CMapDatabaseGenerator generateur)
        {
            m_generateur = generateur;
        }

        //-------------------------------------------------------------
        public string GeneratorName
        {
            get
            {
                return I.T("lines from entities|20025");
            }
        }


        
        //--------------------------------------------------------------------------
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

        

        //-------------------------------------------------------------
        [DynamicField("Map generator")]
        public CMapDatabaseGenerator Generator
        {
            get
            {
                return m_generateur;
            }
            set
            {
                m_generateur = value;
            }
        }

        //-------------------------------------------------------------
        public object CurrentGeneratedItem
        {
            get
            {
                return m_currentGeneratedItem;
            }
        }

        //-------------------------------------------------------------
        public CFiltreDynamique Filtre
        {
            get
            {
                if (m_filtreDynamique == null)
                    m_filtreDynamique = new CFiltreDynamique();
                m_filtreDynamique.ContexteDonnee = Generator.ContexteDonnee;
                m_filtreDynamique.ElementAVariablesExterne = m_generateur;
                return m_filtreDynamique;
            }
            set
            {
                m_filtreDynamique = value;
            }
        }

        //-------------------------------------------------------------
        public CActionSur2iLink ActionSurClick
        {
            get
            {
                return m_actionSurClick;
            }
            set
            {
                m_actionSurClick = value;
            }
        }

        //-------------------------------------------------------------
        public Type TypeElementsDessines
        {
            get
            {
                if (m_filtreDynamique != null)
                    return m_filtreDynamique.TypeElements;
                return null;
            }
        }



        //-------------------------------------------------------------
        public C2iExpression FormuleLatitude1
        {
            get
            {
                return m_formuleLatitude1;
            }
            set
            {
                m_formuleLatitude1 = value;
            }
        }

        //-------------------------------------------------------------
        public C2iExpression FormuleLongitude1
        {
            get
            {
                return m_formuleLongitude1;
            }
            set
            {
                m_formuleLongitude1 = value;
            }
        }

        //-------------------------------------------------------------
        public C2iExpression FormuleLatitude2
        {
            get
            {
                return m_formuleLatitude2;
            }
            set
            {
                m_formuleLatitude2 = value;
            }
        }

        //-------------------------------------------------------------
        public C2iExpression FormuleLongitude2
        {
            get
            {
                return m_formuleLongitude2;
            }
            set
            {
                m_formuleLongitude2 = value;
            }
        }

        //-------------------------------------------------------------
        public IEnumerable<CMapLineDessin> LinesDessin
        {
            get
            {
                return m_listeAlternativesDessin.ToArray();
            }
            set
            {
                m_listeAlternativesDessin.Clear();
                int nIndex = 0;
                if (value != null)
                {
                    foreach (CMapLineDessin item in value)
                    {
                        item.Index = nIndex++;
                        m_listeAlternativesDessin.Add(item);
                    }
                }
            }
        }


        //-------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strLibelle);

            if ( result )
                result = serializer.TraiteObject<CFiltreDynamique>(ref m_filtreDynamique);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLatitude1);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLongitude1);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLatitude2);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLongitude2);
            if (result)
                result = serializer.TraiteListe<CMapLineDessin>(m_listeAlternativesDessin, new object[] { this });
            if (result)
                result = serializer.TraiteObject<CActionSur2iLink>(ref m_actionSurClick);
            if (!result)
                return result;
            return result;
        }

        //-------------------------------------------------------------
        private int? GetIdChampOptimFromFormule(C2iExpression formule)
        {
            C2iExpressionChamp exp = formule as C2iExpressionChamp;
            if (exp != null)
            {
                //TESTDBKEYOK
                CDefinitionProprieteDynamiqueChampCustom prop = exp.DefinitionPropriete as CDefinitionProprieteDynamiqueChampCustom;
                if (prop != null)
                    return CChampCustom.GetIdFromDbKey(prop.DbKeyChamp);
            }
            return null;

        }
                

        //-------------------------------------------------------------
        public CResultAErreur GenereItems(CMapDatabase database, CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            //Calcule les éléments à générer
            if (Filtre == null || Filtre.TypeElements == null)
                return result;
            if ( FormuleLatitude1 == null || FormuleLongitude1 == null || FormuleLatitude2 == null || FormuleLatitude2 == null)
                return result;
            result = Filtre.GetFiltreData();
            if (!result)
                return result;
            CFiltreData filtre = result.Data as CFiltreData;
            CListeObjetsDonnees lstObjets = new CListeObjetsDonnees(ctxDonnee, Filtre.TypeElements);
            lstObjets.Filtre = filtre;
            lstObjets.ModeSansTri = true;

            CMapLayer layer = null;
            if (lstObjets.Count > 0)
                layer = database.GetLayer(Generator.LayerId, true);
            else
                return result;

            Dictionary<int, double> dicValeursLatitude = new Dictionary<int, double>();
            Dictionary<int, double> dicValeursLongitude = new Dictionary<int, double>();

            foreach (object obj in lstObjets)
            {
                DateTime dt = DateTime.Now;
                m_currentGeneratedItem = obj;
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(obj);
                double? fLat1 = null; 
                double? fLong1 = null;
                double? fLat2 = null;
                double? fLong2 = null;
                result = FormuleLatitude1.Eval(ctxEval);
                if (result)
                {
                    try
                    {
                        fLat1 = Convert.ToDouble(result.Data);
                    }
                    catch { }
                }
                if (fLat1 != null)
                {
                    result = FormuleLongitude1.Eval(ctxEval);
                    if (result)
                    {
                        try
                        {
                            fLong1 = Convert.ToDouble(result.Data);
                        }
                        catch { }
                    }
                }
                if(  fLat1 != null && fLong1 != null )
                {
                    result = FormuleLatitude2.Eval(ctxEval);
                    if ( result )
                    {
                        try
                        {
                            fLat2 = Convert.ToDouble(result.Data);
                        }
                        catch { }
                    }
                }
                if ( fLat1 != null && fLong1 != null && fLat2 != null)
                {
                    result = FormuleLongitude2.Eval(ctxEval);
                    if (result)
                    {
                        try
                        {
                            fLong2 = Convert.ToDouble(result.Data);
                        }
                        catch { }
                    }
                }
                
                TimeSpan sp = DateTime.Now - dt;
                if (obj is CObjetDonnee)
                {
                    //Console.WriteLine("Coord "+((CObjetDonnee)obj).DescriptionElement + " : " + sp.TotalMilliseconds);
                }
                if (fLat1 != null && fLat2 != null && fLong1 != null && fLong2 != null)
                {
                    foreach (CMapLineDessin mapLineDessin in LinesDessin)
                    {
                        if (mapLineDessin.GenereItem(
                            obj, 
                            fLat1.Value, 
                            fLong1.Value,
                            fLat2.Value, 
                            fLong2.Value,
                            layer))
                            break;
                    }
                }
                sp = DateTime.Now - dt;
                if (obj is CObjetDonnee)
                {
                    //Console.WriteLine(((CObjetDonnee)obj).DescriptionElement + " : " + sp.TotalMilliseconds);
                }
            }

            return result;
        }

        //--------------------------------------------------------------
        public void OnMapItemClick(IMapItem itemClicked)
        {
            if (ActionSurClick != null && Generator != null)
                Generator.ExecuteAction(ActionSurClick, itemClicked);
        }

        //--------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            if (TypeElementsDessines != null)
            {
                return new CDefinitionProprieteDynamique[]
                {
                    new CDefinitionCurrentItemMapPoint(this)
                };
            }
            return new CDefinitionProprieteDynamique[0];
        }

        
    }
}
