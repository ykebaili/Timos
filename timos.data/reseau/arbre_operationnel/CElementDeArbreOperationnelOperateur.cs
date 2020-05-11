using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.reseau.arbre_operationnel
{
    /// <summary>
    /// Classe racine pour les opérateurs dans un arbre opérationnel de schema
    /// </summary>
    public abstract class CElementDeArbreOperationnelOperateur : CElementDeArbreOperationnel
    {
        private List<CElementDeArbreOperationnel> m_listeFils = new List<CElementDeArbreOperationnel>();

        //------------------------------------------------------
        public CElementDeArbreOperationnelOperateur( CElementDeArbreOperationnel elementParent)
            : base(elementParent)
        {
        }

        //------------------------------------------------------
        public override IEnumerable<CElementDeArbreOperationnel> Fils
        {
            get
            {
                return m_listeFils.AsReadOnly();
            }
        }

        //------------------------------------------------------
        public void AddFils(CElementDeArbreOperationnel element)
        {
            m_listeFils.Add(element);
            element.SetElementParent(this);
        }

        //------------------------------------------------------
        public void RemoveFils(CElementDeArbreOperationnel element)
        {
            m_listeFils.Remove(element);
        }

        //------------------------------------------------------
        public int GetNbFils()
        {
            return m_listeFils.Count();
        }

        //------------------------------------------------------
        public abstract string GetStringOperateur();

        public override string ToString()
        {
            string strResult = GetStringOperateur();
            strResult = strResult + "\n";
            foreach (CElementDeArbreOperationnel elt in Fils)
            {
                string strFils = elt.ToString();
                string strFilsTab = "";
                foreach (string strLigne in strFils.Split('\n'))
                    strFilsTab += "----" + strLigne + "\n";
                strResult += strFilsTab;
            }
            return strResult;
        }

        //------------------------------------------------------
        public override string GetKeyFactorisation()
        {
            StringBuilder bl = new StringBuilder();
            bl.Append(GetStringOperateur());
            bl.Append('(');
            foreach (CElementDeArbreOperationnel elt in Fils)
            {
                bl.Append(elt.GetKeyFactorisation());
                bl.Append(',');
            }
            if (bl.Length > 0)
                bl.Remove(bl.Length - 1,1);
            bl.Append(')');
            return bl.ToString();
        }

        //------------------------------------------------------
        public override string GetFullKey()
        {
            StringBuilder bl = new StringBuilder();
            bl.Append(GetStringOperateur());
            bl.Append('(');
            foreach (CElementDeArbreOperationnel elt in Fils)
            {
                bl.Append(elt.GetFullKey());
                bl.Append(',');
            }
            if (bl.Length > 0)
                bl.Remove(bl.Length - 1, 1);
            bl.Append(')');
            return bl.ToString();
        }


        public override void Simplifier()
        {
            //Simplifie les fils
            foreach ( CElementDeArbreOperationnel elt in Fils )
                elt.Simplifier();

            m_listeFils.Sort();
            //Si c'est un OU et qu'il contient un 1, le ou ne sert à rien
            //1+a+b+c = 1
            if ( GetType() == typeof(CElementDeArbreOperationnelOperateurOu) )
            {

                if (m_listeFils.ToArray().FirstOrDefault(f => f is CElementDeArbreOperationnelTrue) != null)
                {
                    m_listeFils.Clear();
                    return;
                }
            }


            bool bChange = true;
            while (bChange)
            {
                bChange = false;
                /*Fait remonter les fils du même type sur ses propres paramètres
                suivant la règle a+(b+c) = a+b+c et a.(b.c) = a.b.c
                 * */
                foreach (CElementDeArbreOperationnelOperateur element in from f in m_listeFils.ToArray()
                                                    where
                                                    f.GetType() == GetType()
                                                    select f as CElementDeArbreOperationnelOperateur)
                {
                    foreach (CElementDeArbreOperationnel fils in element.Fils)
                        AddFils ( fils );
                    RemoveFils(element);
                    bChange = true;
                }

                /*Supprime les doublons
                 * suivant la règle a+a = a et a.a = a ou les combine, s'il s'agit de trucs
                 * plus compliqués (comme des sous schémas)
                 * */
                Dictionary<string, CElementDeArbreOperationnel> dicElements = new Dictionary<string, CElementDeArbreOperationnel>();
                foreach (CElementDeArbreOperationnel element in m_listeFils.ToArray())
                {
                    if (dicElements.Keys.Contains(element.GetKeyFactorisation()))
                    {
                        IElementDeArbreOperationnelAEgaliteComplexe elementComplexe = element as IElementDeArbreOperationnelAEgaliteComplexe;
                        if (elementComplexe != null)
                        {
                            IElementDeArbreOperationnelAEgaliteComplexe autreElement = dicElements[element.GetKeyFactorisation()] as IElementDeArbreOperationnelAEgaliteComplexe;
                            CElementDeArbreOperationnelOperateur op;
                            if (GetType() == typeof(CElementDeArbreOperationnelOperateurEt))
                                op = new CElementDeArbreOperationnelOperateurOu(null);
                            else
                                op = new CElementDeArbreOperationnelOperateurEt(null);
                            if (autreElement.CombineKeyEgal(op, element))
                            {
                                RemoveFils(element);
                            }
                            bChange = true;
                        }
                        else
                        {
                            CElementDeArbreOperationnel autreElement = dicElements[element.GetKeyFactorisation()];
                            if (autreElement.GetFullKey() == element.GetFullKey())
                            {
                                RemoveFils(element);
                                bChange = true;
                            }
                        }
                    }
                    else
                        dicElements[element.GetKeyFactorisation()] = element;
                }

                //Supprime les opérateurs avec un zéro ou seul paramètere 
                foreach (CElementDeArbreOperationnelOperateur element in from f in m_listeFils.ToArray()
                                                      where
                                                         typeof(CElementDeArbreOperationnelOperateur).IsAssignableFrom(f.GetType()) &&
                                                      ((CElementDeArbreOperationnelOperateur)f).Fils.Count() <= 1
                                                            select f as CElementDeArbreOperationnelOperateur)
                {
                    if (element.Fils.Count() == 1)
                        AddFils(element.Fils.ElementAt(0));
                    m_listeFils.Remove(element);
                    bChange = true;
                }

                if (GetType() == typeof(CElementDeArbreOperationnelOperateurEt))
                {
                    foreach (CElementDeArbreOperationnelTrue opTrue in from f in Fils
                                                             where f is CElementDeArbreOperationnelTrue
                                                             select f as CElementDeArbreOperationnelTrue)
                    {
                        RemoveFils(opTrue);
                        bChange = true;
                    }
                }
            }
            //if ( TypeOperateur == ETypeOperateur.OU )
            Factoriser();
            m_listeFils.Sort();
        }

        public void Factoriser()
        {
            /*if ( TypeOperateur != ETypeOperateur.OU )
                return;*/
            Dictionary<string, int> compteur = new Dictionary<string, int>();
            Dictionary<string, List<CElementDeArbreOperationnel>> dicConcernesParElement = new Dictionary<string, List<CElementDeArbreOperationnel>>();
            int nNbOccurMax = 0;
            foreach (CElementDeArbreOperationnelOperateur element in from f in m_listeFils.ToArray()
                                                  where
                                                  typeof(CElementDeArbreOperationnelOperateur).IsAssignableFrom(f.GetType())
                                                  select f as CElementDeArbreOperationnelOperateur)
            {
                foreach (CElementDeArbreOperationnel fils in element.Fils)
                {
                    int nVal = 0;
                    string strKey = fils.GetKeyFactorisation();
                    compteur.TryGetValue(strKey, out nVal);

                    nVal++;
                    if (nVal > nNbOccurMax)
                        nNbOccurMax = nVal;
                    compteur[fils.GetKeyFactorisation()] = nVal;
                    List<CElementDeArbreOperationnel> lst = null;
                    if (!dicConcernesParElement.TryGetValue(strKey, out lst))
                    {
                        lst = new List<CElementDeArbreOperationnel>();
                        dicConcernesParElement[strKey] = lst;
                    }
                    lst.Add(element);
                }
            }
            foreach (CElementDeArbreOperationnelEntite element in from f in m_listeFils.ToArray()
                                                         where
                                                         f.GetType() == typeof(CElementDeArbreOperationnelEntite)
                                                         select f as CElementDeArbreOperationnelEntite)
            {
                int nVal = 0;
                string strKey = element.GetKeyFactorisation();
                compteur.TryGetValue(strKey, out nVal);
                nVal++;
                if (nVal > nNbOccurMax)
                    nNbOccurMax = nVal;
                compteur[strKey] = nVal;
                List<CElementDeArbreOperationnel> lst = null;
                if (!dicConcernesParElement.TryGetValue(strKey, out lst))
                {
                    lst = new List<CElementDeArbreOperationnel>();
                    dicConcernesParElement[strKey] = lst;
                }
                lst.Add(element);
            }

            if (nNbOccurMax > 1)
            {
                //Il est possible de factoriser
                foreach (KeyValuePair<string, int> kv in compteur)
                {
                    if (kv.Value == nNbOccurMax)
                    {
                        //On a trouvé celui qu'on voulait factoriser
                        List<CElementDeArbreOperationnel> lstConcernes = null;
                        dicConcernesParElement.TryGetValue(kv.Key, out lstConcernes);
                        if (lstConcernes != null || lstConcernes.Count <= 1)
                        {
                            CElementDeArbreOperationnelOperateur opGlobal;
                            if (GetType() == typeof(CElementDeArbreOperationnelOperateurOu))
                                opGlobal = new CElementDeArbreOperationnelOperateurEt(null);
                            else
                                opGlobal = new CElementDeArbreOperationnelOperateurOu(null);
                            
                            CElementDeArbreOperationnelOperateur opFactorise;
                            if (GetType() == typeof(CElementDeArbreOperationnelOperateurOu))
                                opFactorise = new CElementDeArbreOperationnelOperateurOu(null);
                            else
                                opFactorise = new CElementDeArbreOperationnelOperateurEt(null);
                            bool bHasEltToutSeul = false;
                            foreach (CElementDeArbreOperationnel elt in lstConcernes)
                            {
                                if (elt.GetKeyFactorisation() == kv.Key)
                                {
                                    opGlobal.AddFils(elt);
                                    m_listeFils.Remove(elt);
                                    bHasEltToutSeul = true;
                                    //Si c'est un ou, on a "a+(a.b) = a.(1+b)"
                                    //Si c'est un et, on a "a.(a+b) = a"
                                    if ( GetType() == typeof(CElementDeArbreOperationnelOperateurOu) )
                                        opFactorise.AddFils(new CElementDeArbreOperationnelOperateurOu(opFactorise));
                                }
                                else if (elt is CElementDeArbreOperationnelOperateur)
                                {
                                    CElementDeArbreOperationnelOperateur operateur = elt as CElementDeArbreOperationnelOperateur;
                                    foreach (CElementDeArbreOperationnel fils in operateur.Fils.ToArray())
                                    {
                                        if (fils.GetKeyFactorisation() == kv.Key)
                                        {
                                            opGlobal.AddFils(fils);
                                            operateur.RemoveFils(fils);
                                        }
                                    }
                                    RemoveFils(elt);
                                    opFactorise.AddFils(elt);
                                }
                            }
                            if (GetType() == typeof(CElementDeArbreOperationnelOperateurOu) ||
                                !bHasEltToutSeul)
                            {
                                //Si et et que on a a.(a+b), ça fait a, donc l'op global n'a que le premier élément
                                opGlobal.AddFils(opFactorise);
                            }
                            AddFils(opGlobal);
                            Simplifier();
                            return;
                        }
                    }
                }
            }
        }

        

    }

    /// <summary>
    /// Opérateur OU dans un arbre opérationnel de schéma. Le Ou est OK si un de ses fils
    /// direct est ok
    /// </summary>
    public class CElementDeArbreOperationnelOperateurOu : CElementDeArbreOperationnelOperateur
    {
        //------------------------------------------------------
        public CElementDeArbreOperationnelOperateurOu(CElementDeArbreOperationnel elementParent)
            :base ( elementParent )
        {
        }
        //------------------------------------------------------
        public override string GetStringOperateur()
        {
            return "OU";
        }

        /// <summary>
        /// recalcule le coef opérationnel de l'opérateur ou( moyenne des coef
        /// opérationnels des fils
        /// </summary>
        protected override void MyRecalculeCoefOperationnelFromChilds()
        {
            double fTotal = 0;
            foreach (CElementDeArbreOperationnel elt in Fils)
            {
                fTotal += elt.CoeffOperationnel;
            }
            if (Fils.Count() == 0)
                SetCoeffOperationnel(1);
            else
                SetCoeffOperationnel(fTotal / Fils.Count());
        }

    }


    /// <summary>
    /// Opérateur ET dans un arbre opérationnel de schéma. Le Et est ok si tous ses fils directs
    /// sont OK
    /// </summary>
    public class CElementDeArbreOperationnelOperateurEt : CElementDeArbreOperationnelOperateur
    {
        public CElementDeArbreOperationnelOperateurEt(CElementDeArbreOperationnel elementParent)
            : base(elementParent)
        {
        }

        //------------------------------------------------------
        public override string GetStringOperateur()
        {
            return "ET";
        }

        /// <summary>
        /// recalcule le coef opérationnel de l'opérateur( min des coef
        /// opérationnels des fils
        /// </summary>
        protected override void MyRecalculeCoefOperationnelFromChilds()
        {
            double fMin = 1.0;
            foreach (CElementDeArbreOperationnel elt in Fils)
            {
                fMin = Math.Min( fMin, elt.CoeffOperationnel);
            }
            SetCoeffOperationnel(fMin);
        }

        
    }

    
}
