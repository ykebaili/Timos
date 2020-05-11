using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using System.Data;
using System.Reflection;

namespace timos.data.projet.besoin
{
    public static class CUtilElementACout
    {
        public const string c_champImputationsVersUtilisateurs = "COST_IMPUTATIONS";
        public const string c_champImputationsParLesSources = "COST_SOURCE_IMPUTATIONS";

        public const string c_champCoutsParentsARecalculer = "PRT_COST_TO_RECALCULATE";


        //Les outils de stockage de cout imputé ne doivent pas être utilisée en dehors,
        //car ces valeurs risquent d'être mals exploitées.  La Somme des valeurs imputées de source 
        //Peut ne pas être égale au cout correspondant, ça peut arriver lors d'un changement 
        //de destination de cout par exemple.
        //------------------------------------------------------------------------------------------------------------------------------
        private static CValeursImputées GetValeursImputéesSurUtilisateurs(IElementACout elementSource)
        {
            if ( elementSource == null )
                return new CValeursImputées();
            string strTmp = "";
            if (elementSource.Row.RowState == DataRowState.Deleted || elementSource.Row.RowState == DataRowState.Detached)
                strTmp = (string)elementSource.Row[c_champImputationsVersUtilisateurs, DataRowVersion.Original];
            else
                strTmp = (string)elementSource.Row[c_champImputationsVersUtilisateurs];
            return new CValeursImputées(strTmp);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void SetValeursImputéesSurUtilisateurs(IElementACout source, CValeursImputées valeurs)
        {
            if ( source == null || source.Row.RowState == DataRowState.Deleted || source.Row.RowState == DataRowState.Detached )
                return;
            source.Row[c_champImputationsVersUtilisateurs] = valeurs.GetStringSerialization();
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static double GetValeurImputéeSurUtilisateur(IElementACout source, IElementACout utilisateur, bool bCoutReel)
        {
            CValeursImputées valeur = GetValeursImputéesSurUtilisateurs(source);
            return valeur.GetImputation(utilisateur, bCoutReel);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void SetValeurImputéeSurUtilisateur(IElementACout source, IElementACout utilisateur, double fImputation, bool bCoutReel)
        {
            if (source.Row.RowState == DataRowState.Deleted || source.Row.RowState == DataRowState.Deleted)
                return;
            CValeursImputées valeurs = GetValeursImputéesSurUtilisateurs(source);
            valeurs.SetImputation(utilisateur, fImputation, bCoutReel);
            SetValeursImputéesSurUtilisateurs(source, valeurs);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static CValeursImputées GetValeursImputéesDeSources(IElementACout utilisateur)
        {
            if (utilisateur == null)
                return new CValeursImputées();
            string strTmp = "";
            if (utilisateur.Row.RowState == DataRowState.Deleted || utilisateur.Row.RowState == DataRowState.Detached)
                strTmp = (string)utilisateur.Row[c_champImputationsParLesSources, DataRowVersion.Original];
            else
                strTmp = (string)utilisateur.Row[c_champImputationsParLesSources];
            return new CValeursImputées(strTmp);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void SetValeursImputéesDeSources(IElementACout utilisateur, CValeursImputées valeurs)
        {
            if (utilisateur == null || utilisateur.Row.RowState == DataRowState.Deleted || utilisateur.Row.RowState == DataRowState.Detached)
                return;
            utilisateur.Row[c_champImputationsParLesSources] = valeurs.GetStringSerialization();
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static double GetValeurImputéeDeSource(IElementACout utilisateur, IElementACout source, bool bCoutReel)
        {
            CValeursImputées valeur = GetValeursImputéesDeSources(utilisateur);
            return valeur.GetImputation(source, bCoutReel);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void SetValeurImputéeDeSource(IElementACout utilisateur, IElementACout source, double fImputation, bool bCoutReel)
        {
            if (source.Row.RowState == DataRowState.Deleted || source.Row.RowState == DataRowState.Deleted)
                return;
            CValeursImputées valeurs = GetValeursImputéesDeSources(utilisateur);
            valeurs.SetImputation(source, fImputation, bCoutReel);
            SetValeursImputéesDeSources(utilisateur, valeurs);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static IElementACout[] GetElementsACoutFinaux(IElementACout element, bool bCoutReel)
        {
            HashSet<IElementACout> setElements = new HashSet<IElementACout>();
            Dictionary<IElementACout, IElementACout[]> sources = new Dictionary<IElementACout, IElementACout[]>();
            FillDicSources(bCoutReel, element, true, sources);
            foreach (IElementACout[] sourcesDeElt in sources.Values)
            {
                foreach (IElementACout source in sourcesDeElt)
                {
                    IElementACout[] tmp = new IElementACout[0];;
                    sources.TryGetValue(source, out tmp);
                    if (tmp.Length == 0)
                        setElements.Add(source);
                }
            }
            return setElements.ToArray();
        }

        //------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Recalcule un cout
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="elementARecalculer"></param>
        /// <param name="bCoutReel"></param>
        /// <param name="bRecursif"></param>
        /// <returns></returns>
        public static CResultAErreur RecalculeCoutDescendant(IElementACout elementARecalculer, bool bCoutReel, bool bRecursif, IIndicateurProgression indicateur)
        {
            List<IElementACout> lstElements = new List<IElementACout>();
            lstElements.Add(elementARecalculer);
            return RecalculeCoutsDescendants(lstElements, bCoutReel, bRecursif, indicateur);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static CResultAErreur RecalculeCoutsDescendants ( IEnumerable<IElementACout> elements, bool bCoutReel, bool bRecursif, IIndicateurProgression indicateurDeProgression )
        {
            CConteneurIndicateurProgression indicateur = CConteneurIndicateurProgression.GetConteneur(indicateurDeProgression);
            indicateur.CanCancel = true;
            CResultAErreur result = CResultAErreur.True;
            Dictionary<IElementACout, IElementACout[]> elementsToSources = new Dictionary<IElementACout, IElementACout[]>();
            Dictionary<IElementACout, CImputationsCouts> dicImputations = new Dictionary<IElementACout, CImputationsCouts>();

            foreach ( IElementACout elt in elements )
                FillDicSources(bCoutReel, elt, bRecursif, elementsToSources);

            HashSet<IElementACout> setRecalcules = new HashSet<IElementACout>();

            List<IElementACout> elementsACalculer = new List<IElementACout>();
            if (bRecursif)
                foreach (IElementACout elt in elementsToSources.Keys)
                    elementsACalculer.Add(elt);
            else
                elementsACalculer.AddRange(elements);


            indicateur.SetBornesSegment(0, elementsACalculer.Count());
            int nNbFaits = 0;
            try
            {
                while (elementsACalculer.Count > 0)
                {
                    if (indicateur.CancelRequest)
                    {
                        result.EmpileErreur(I.T("Operation cancelled|20184"));
                        return result;
                    }
                    List<IElementACout> prochaineGeneration = new List<IElementACout>();
                    foreach (IElementACout elt in elementsACalculer)
                    {
                        //Vérifie qu'il est possible de calculer cet élément
                        IElementACout[] sources = elementsToSources[elt];
                        bool bCanCalcul = !elt.IsCoutFromSources(bCoutReel);
                        if (!bCanCalcul)
                        {
                            bCanCalcul = true;
                            foreach (IElementACout source in sources)
                            {
                                if (!setRecalcules.Contains(source) && elementsToSources.ContainsKey(source))
                                {
                                    bCanCalcul = false;
                                    break;
                                }
                            }
                        }
                        if (bCanCalcul)
                        {
                            nNbFaits++;
                            indicateur.SetValue(nNbFaits);
                            indicateur.SetInfo(elt.Libelle);
                            setRecalcules.Add(elt);
                            double fCout = 0;
                            if (elt.ShouldAjouterCoutPropreAuCoutDesSource(bCoutReel) && elt.IsCoutFromSources(bCoutReel))
                            {
                                AffecteValeurCalcSansSourcesToElement(elt, bCoutReel);
                                fCout = bCoutReel ? elt.CoutReel : elt.CoutPrevisionnel;
                            }

                            CValeursImputées valeursDeSources = GetValeursImputéesDeSources(elt);
                            valeursDeSources.Reset(bCoutReel);

                            if (elt.IsCoutFromSources(bCoutReel))
                            {
                                foreach (IElementACout source in sources)
                                {
                                    CImputationsCouts imputations = null;
                                    if (!dicImputations.TryGetValue(source, out imputations))
                                    {
                                        imputations = source.GetImputationsAFaireSurUtilisateursDeCout();
                                        dicImputations[source] = imputations;
                                    }
                                    if (imputations != null)
                                    {
                                        double fImput = imputations.GetCoutImputéeA(elt, bCoutReel);
                                        fCout += fImput;
                                        SetValeurImputéeSurUtilisateur(source, elt, fImput, bCoutReel);
                                        valeursDeSources.SetImputation(source, fImput, bCoutReel);
                                    }
                                }
                                elt.SetCoutSansCalculDesParents(fCout, bCoutReel);
                                OnChangeCoutSansCalculCoutDescendant(elt, bCoutReel, false);
                                SetValeursImputéesDeSources(elt, valeursDeSources);
                            }
                            else
                            {
                                AffecteValeurCalcSansSourcesToElement(elt, bCoutReel);
                            }

                        }
                        else
                            prochaineGeneration.Add(elt);
                    }
                    if (prochaineGeneration.Count == elementsACalculer.Count)//On n'a rien fait, c'est la cata
                    {
                        result.EmpileErreur(I.T("Can not calculate cost. Cyclic redundancy error|20182"));
                        return result;
                    }
                    elementsACalculer = prochaineGeneration;
                    if (!bRecursif)
                        break;
                }
            }
            finally
            {
            }
            return result;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static double CalcImputationAFaireSur(IElementACout source, IElementACout utilisateur, bool bCoutReel)
        {
            if (source == null || source.Row.RowState == DataRowState.Detached || source.Row.RowState == DataRowState.Deleted ||
                utilisateur== null || utilisateur.Row.RowState == DataRowState.Deleted || utilisateur.Row.RowState == DataRowState.Detached)
                return 0;
            CImputationsCouts imputations = source.GetImputationsAFaireSurUtilisateursDeCout();
            return imputations.GetCoutImputéeA(utilisateur, bCoutReel);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void FillDicSources(
            bool bCoutReel, 
            IElementACout elementACout, 
            bool bRecursif,
            Dictionary<IElementACout, IElementACout[]> elementsToSource)
        {
            if (elementsToSource.ContainsKey(elementACout))
                return;
            IElementACout[] sources = elementACout.GetSourcesDeCout(bCoutReel);
            elementsToSource[elementACout] = sources;
            if (bRecursif)
            {
                foreach (IElementACout source in sources)
                {
                    FillDicSources(bCoutReel, source, true, elementsToSource);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void UpdateValeurAAjouterAuxSourceDeElement(IElementACout element, bool bCoutReel)
        {
            if (!element.ShouldAjouterCoutPropreAuCoutDesSource(bCoutReel))
                return;
            double fOld = GetValeurImputéeDeSource(element, element, bCoutReel);
            double fNew = element.CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bCoutReel);
            if (fOld != fNew)
            {
                double fCout = bCoutReel ? element.CoutReel : element.CoutPrevisionnel;
                fCout -= fOld;
                fCout += fNew;
                SetValeurImputéeDeSource(element, element, fNew, bCoutReel);
                element.SetCoutSansCalculDesParents(fCout, bCoutReel);
            }
        }



        //------------------------------------------------------------------------------------------------------------------------------
        private static void AffecteValeurCalcSansSourcesToElement(IElementACout element, bool bCoutReel)
        {
            if (element == null)
                return;
            double fCout = element.CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bCoutReel);
            element.SetCoutSansCalculDesParents(fCout, bCoutReel);
            CValeursImputées valeurs = GetValeursImputéesDeSources(element);
            valeurs.Reset(bCoutReel);
            valeurs.SetImputation(element, fCout, bCoutReel);
            SetValeurImputéeSurUtilisateur(element, element, fCout, bCoutReel);
        }


        //------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Note toutes les sources d'un élément, sources appartenant aux types spécifiés,
        /// qu'elle doivent noter leur cout comme modifié
        /// </summary>
        /// <param name="elt"></param>
        /// <param name="typesDesElementsAInvalider"></param>
        public static void InvalideLeCoutDesSources(IElementACout elt, bool bCoutReel, params Type[] typesDesElementsAInvalider)
        {
            HashSet<IElementACout> setFaits = new HashSet<IElementACout>();
            HashSet<Type> typesAInvalider = new HashSet<Type>();
            foreach ( Type tp in typesDesElementsAInvalider )
                typesAInvalider.Add ( tp );
            InvalideLeCoutDesSources(elt, bCoutReel, typesAInvalider, setFaits);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void InvalideLeCoutDesSources(IElementACout elt, bool bCoutReel, HashSet<Type> typesAInvalider, HashSet<IElementACout> elementsFaits)
        {
            if ( elt == null || elt.Row.RowState == DataRowState.Deleted || elt.Row.RowState == DataRowState.Detached )
                return;
            if ( elementsFaits.Contains(elt ) )
                return;
            elementsFaits.Add ( elt );
            foreach ( IElementACout source in elt.GetSourcesDeCout(bCoutReel) )
            {
                InvalideLeCoutDesSources ( source, bCoutReel, typesAInvalider, elementsFaits );
            }
            if ( typesAInvalider.Contains ( elt.GetType() ))
                OnChangeCout ( elt, bCoutReel, false );
        }


        


        //------------------------------------------------------------------------------------------------------------------------------
        public static void OnChangeCout ( IElementACout source, bool bCoutReel, bool bImmediatement )
        {
            List<IElementACout> lstSources = new List<IElementACout>();
            lstSources.Add(source);
            OnChangeCout(lstSources, bCoutReel, bImmediatement);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static void OnChangeCout ( IEnumerable<IElementACout> lstSources, bool bCoutReel, bool bImmediatement )
        {
            foreach (IElementACout source in lstSources)
            {
                if (source.Row.RowState != DataRowState.Deleted && source.Row.RowState != DataRowState.Detached)
                    RecalculeCoutDescendant(source, bCoutReel, false, null);
            }
            OnChangeCoutSansCalculCoutDescendant(lstSources, bCoutReel, bImmediatement);
            
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void OnChangeCoutSansCalculCoutDescendant(IElementACout source, bool bCoutReel, bool bImmediatement)
        {
            List<IElementACout> lstSources = new List<IElementACout>();
            lstSources.Add(source);
            OnChangeCoutSansCalculCoutDescendant(lstSources, bCoutReel, bImmediatement);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void OnChangeCoutSansCalculCoutDescendant(IEnumerable<IElementACout> sources, bool bCoutReel, bool bImmediatement)
        {
            HashSet<DataRow> setDejaRecalcules = new HashSet<DataRow>();
            foreach (IElementACout source in sources)
            {
                if (source != null && !bImmediatement)
                    source.TypesCoutsParentsARecalculer |= bCoutReel ? ETypeCout.réel : ETypeCout.Prévisionnel;
                if (source != null && bImmediatement)
                    RecalcCoutMontant(source, bCoutReel, setDejaRecalcules);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void RecalcCoutMontant ( IElementACout source, bool bCoutReel, HashSet<DataRow> setDejaRecalcules )
        {
            if (source == null)
                return;
            if (setDejaRecalcules.Contains(source.Row.Row))
                return;
            setDejaRecalcules.Add ( source.Row.Row );

            
            if (source.Row.RowState == DataRowState.Deleted || source.Row.RowState == DataRowState.Detached)
            {
                source.VersionToReturn = DataRowVersion.Original;
            }
            CImputationsCouts imputations = source.GetImputationsAFaireSurUtilisateursDeCout();
            HashSet<IElementACout> elementsModifies = new HashSet<IElementACout>();
            CValeursImputées newValeurs = GetValeursImputéesSurUtilisateurs(source);
            newValeurs.Reset(bCoutReel);
            CValeursImputées oldValeurs = GetValeursImputéesSurUtilisateurs(source);
            HashSet<string> newElementsImputes = new HashSet<string>();
            
            if (source.Row.RowState != DataRowState.Deleted && source.Row.RowState != DataRowState.Deleted)
            {
                if (!source.IsCoutFromSources(bCoutReel))
                {
                    double fCout = source.CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bCoutReel);
                    source.SetCoutSansCalculDesParents(fCout, bCoutReel);
                    SetValeurImputéeDeSource(source, source, bCoutReel ? source.CoutReel : source.CoutPrevisionnel, bCoutReel);
                    newValeurs.SetImputation(source, bCoutReel ? source.CoutReel : source.CoutPrevisionnel, bCoutReel);
                    newElementsImputes.Add(source.IdUniversel);
                }
            }

                   
            foreach (CImputationCout imputation in imputations.Imputations)
            {
                newElementsImputes.Add (imputation.UtilisateurDeCout.IdUniversel);
                IElementACout utilisateur = imputation.UtilisateurDeCout;
                if (utilisateur.Row.RowState == DataRowState.Deleted || utilisateur.Row.RowState == DataRowState.Deleted)
                {
                    newValeurs.SetImputation(utilisateur, 0, bCoutReel);
                }
                else
                {
                    double fOld = oldValeurs.GetImputation(utilisateur, bCoutReel);
                    double fNew = 0;

                    

                    if ( source.Row.RowState != DataRowState.Deleted && source.Row.RowState != DataRowState.Detached )
                        fNew = source.CalcImputationAFaireSur(utilisateur, bCoutReel);
                    if (Math.Abs(fOld - fNew) > 0.01)
                    {
                        elementsModifies.Add(utilisateur);
                        setDejaRecalcules.Remove(utilisateur.Row.Row);
                        double fVal = bCoutReel ? utilisateur.CoutReel : utilisateur.CoutPrevisionnel;
                        fVal -= fOld;
                        fVal += fNew;
                        utilisateur.SetCoutSansCalculDesParents(fVal, bCoutReel);
                        SetValeurImputéeDeSource(utilisateur, source, fNew, bCoutReel);
                    }
                    newValeurs.SetImputation(utilisateur, fNew, bCoutReel);
                }
                CUtilElementACout.SetValeursImputéesSurUtilisateurs(source, newValeurs);
            }
            
            //Enlève les valeurs qui ont été imputées sur des éléments qui ne sont plus imputés
            foreach (IElementACout utilisateur in oldValeurs.GetObjetsImputés(source.ContexteDonnee))
            {
                if (!newElementsImputes.Contains(utilisateur.IdUniversel))
                {
                    //On avait imputé ce type, mais il ne faut plus
                    //Vérifie que le coût de cet utilisateur intègre bien mon cout
                    CValeursImputées valeurs = GetValeursImputéesDeSources(utilisateur);
                    if (valeurs.ContainsElement(source,bCoutReel))
                    {
                        double fImput = oldValeurs.GetImputation ( utilisateur, bCoutReel );
                        if (fImput > 0.001)
                        {
                            elementsModifies.Add(utilisateur);
                            setDejaRecalcules.Remove(utilisateur.Row.Row);
                            double fVal = bCoutReel ? utilisateur.CoutReel : utilisateur.CoutPrevisionnel;
                            fVal -= fImput;
                            utilisateur.SetCoutSansCalculDesParents(fVal, bCoutReel);
                            SetValeurImputéeDeSource(utilisateur, source, 0, bCoutReel);
                        }
                    }
                }
            }


            if ( source.Row.RowState != DataRowState.Deleted && source.Row.RowState != DataRowState.Detached )
                source.TypesCoutsParentsARecalculer &= bCoutReel ? ~ETypeCout.réel : ~ETypeCout.Prévisionnel;

            foreach (IElementACout eltModif in elementsModifies)
            {
                RecalcCoutMontant(eltModif, bCoutReel, setDejaRecalcules);
            }
        }


        private static List<Type> m_listeTypesElementsACouts = null;
        //------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Se base sur le champ PRT_COST_TO_RECALCULATE pour savoir ce qu'il faut recalculer
        /// </summary>
        /// <param name="contexte"></param>
        /// <returns></returns>
        public static CResultAErreur RecalculeCoutsARecalculer(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_listeTypesElementsACouts == null)
            {
                m_listeTypesElementsACouts = new List<Type>();
                foreach (Assembly ass in CGestionnaireAssemblies.GetAssemblies())
                {
                    foreach (Type tp in ass.GetTypes())
                    {
                        if (typeof(IElementACout).IsAssignableFrom(tp))
                            m_listeTypesElementsACouts.Add(tp);
                    }
                }
            }
            List<IElementACout> lstARecalculerReel = new List<IElementACout>();
            List<IElementACout> lstARecalculerPrevisionnel = new List<IElementACout>();
            foreach (Type tp in m_listeTypesElementsACouts)
            {
                string strNomTable = CContexteDonnee.GetNomTableForType(tp);
                DataTable table = contexte.Tables[strNomTable];
                if (table != null)
                {
                    DataRow[] rows = table.Select(c_champCoutsParentsARecalculer + "<>0");
                    foreach (DataRow row in rows)
                    {
                        IElementACout elt = Activator.CreateInstance(tp, new object[] { row }) as IElementACout;
                        if ( (elt.TypesCoutsParentsARecalculer & ETypeCout.réel) == ETypeCout.réel )
                            lstARecalculerReel.Add(elt);
                        if ((elt.TypesCoutsParentsARecalculer & ETypeCout.Prévisionnel) == ETypeCout.Prévisionnel)
                            lstARecalculerPrevisionnel.Add(elt);
                    }
                    //Récupère également les lignes supprimées
                    rows = table.Select("", "", DataViewRowState.Deleted);
                    foreach (DataRow row in rows)
                    {
                        IElementACout elt = Activator.CreateInstance(tp, new object[] { row }) as IElementACout;
                        lstARecalculerPrevisionnel.Add(elt);
                        lstARecalculerReel.Add(elt);
                    }
                }
            }
            DataTable tableRels = contexte.Tables[CRelationBesoin_Satisfaction.c_nomTable];
            if (tableRels != null)
            {
                DataRow[] rowsRels = tableRels.Select("", "", DataViewRowState.Added | DataViewRowState.Deleted);
                foreach (DataRow row in rowsRels)
                {
                    CRelationBesoin_Satisfaction rel = new CRelationBesoin_Satisfaction(row);
                    if (row.RowState == DataRowState.Deleted)
                        rel.VersionToReturn = DataRowVersion.Original;
                    IElementACout elt = rel.Satisfaction;
                    lstARecalculerPrevisionnel.Add(elt);
                    lstARecalculerReel.Add(elt);
                }
            }

                

            HashSet<DataRow> setCalcules = new HashSet<DataRow>();
            foreach (IElementACout elt in lstARecalculerPrevisionnel)
                RecalcCoutMontant(elt, false, setCalcules);

            setCalcules = new HashSet<DataRow>();
            foreach (IElementACout elt in lstARecalculerReel)
                RecalcCoutMontant(elt, true, setCalcules);
                

            return result;            
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static bool IsSourceDe(IElementACout elementSource, IElementACout utilisateur)
        {
            HashSet<IElementACout> setUtilisateurs = new HashSet<IElementACout>();
            FillSetUtilisateurs(elementSource, setUtilisateurs, utilisateur);
            if (setUtilisateurs.Contains(utilisateur))
                return true;
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static void FillSetUtilisateurs(IElementACout elementACout, HashSet<IElementACout> set, params IElementACout[] stopOn)
        {
            if (set.Contains(elementACout))
                return;
            set.Add(elementACout);
            if (stopOn.Length > 0 && stopOn.Contains(elementACout))
                return;
            CImputationsCouts imputations = elementACout.GetImputationsAFaireSurUtilisateursDeCout();
            foreach (CImputationCout imput in imputations.Imputations)
            {
                IElementACout elt = imput.UtilisateurDeCout;
                if (elt != null && elt.Row.RowState != DataRowState.Deleted && elt.Row.RowState != DataRowState.Detached)
                    FillSetUtilisateurs(elt, set, stopOn);
            }
        }

    
    }
}
