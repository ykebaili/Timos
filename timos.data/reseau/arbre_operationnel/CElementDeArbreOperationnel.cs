using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.reseau.arbre_operationnel
{
    public abstract class CElementDeArbreOperationnel : IComparable<CElementDeArbreOperationnel>
    {
        /// <summary>
        /// coefficient d'operationnabilité de l'élément.
        /// </summary>
        private double m_fCoeffOperationnel = 1;

        private CElementDeArbreOperationnel m_elementParent = null;

        //-------------------------------------------------------------------------
        public CElementDeArbreOperationnel(CElementDeArbreOperationnel parent)
        {
            m_elementParent = parent;
        }

        //-------------------------------------------------------------------------
        public CElementDeArbreOperationnel ElementParent
        {
            get
            {
                return m_elementParent;
            }
        }

        //-------------------------------------------------------------------------
        public abstract IEnumerable<CElementDeArbreOperationnel> Fils { get; }

        //-------------------------------------------------------------------------
        /// <summary>
        /// Geré automatiquement lors de l'ajout d'un sous élément à un élement
        /// </summary>
        /// <param name="parent"></param>
        public void SetElementParent(CElementDeArbreOperationnel parent)
        {
            m_elementParent = parent;
        }


        //--------------------------------------------
        /// <summary>
        /// Simplifie l'élément, en factorisant ces fils
        /// </summary>
        public abstract void Simplifier();

        /// <summary>
        /// Retourne une clé unique de factorisation. Tous les éléments
        /// qui ont la même clé de factorisation peuvent être factorisés
        /// </summary>
        /// <returns></returns>
        public abstract string GetKeyFactorisation();

        /// <summary>
        /// retourne une clé unique globale. Si deux éléments ont la même FullKey,
        /// ils sont égaux !
        /// </summary>
        /// <returns></returns>
        public abstract string GetFullKey();

        
        protected abstract void MyRecalculeCoefOperationnelFromChilds();

        /// <summary>
        /// Recalcule l'état opérationnel de l'élément en se basant
        /// sur l'état opérationnel de ses fils. L'état opérationnel des fils
        /// doit être à jour.
        /// </summary>
        public void RecalculeCoefOperationnelFromChilds()
        {
            MyRecalculeCoefOperationnelFromChilds();
            if (ElementParent != null)
                ElementParent.RecalculeCoefOperationnelFromChilds();
        }

        public double CoeffOperationnel
        {
            get
            {
                return m_fCoeffOperationnel;
            }
        }

        public void SetCoeffOperationnel(double fCoef)
        {
            m_fCoeffOperationnel = fCoef;
        }


        


        /// <summary>
        /// Compare deux éléments. utilisé en interne pour que deux arbres équivalents
        /// soient toujours présentés dans le même ordre
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CElementDeArbreOperationnel other)
        {
            return GetKeyFactorisation().CompareTo(other.GetKeyFactorisation());
        }
    }

    /// <summary>
    /// Pour les éléments d'arbre a combiner de manière spéciale lorsqu'il y a égalité entre
    /// deux clés. 
    /// Par exemple, lorsque deux sous schéma on la même clé (même sous schéma et même origine/destination),
    /// il ne faut pas simplement supprimer l'une des deux occurences, mais les combiner.
    /// </summary>
    public interface IElementDeArbreOperationnelAEgaliteComplexe
    {
        //Combine deux éléments ayant la même clé
        bool CombineKeyEgal(CElementDeArbreOperationnelOperateur operateur, CElementDeArbreOperationnel autreElement);
    }
}
