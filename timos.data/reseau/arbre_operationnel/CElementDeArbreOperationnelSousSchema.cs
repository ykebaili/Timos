using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.reseau.graphe;

namespace timos.data.reseau.arbre_operationnel
{
    public class CElementDeArbreOperationnelSousSchema : CElementDeArbreOperationnel,
        IElementDeArbreOperationnelAEgaliteComplexe
    {
        private int m_nIdSchema;
        private EModeOperationnelSchema m_modeOperationnelSousSchema = EModeOperationnelSchema.AutomaticRedundancy;
        private CNoeudDeGrapheReseau m_noeudDepart = null;
        private CNoeudDeGrapheReseau m_noeudArrivee = null;

        private CElementDeArbreOperationnel m_elementDeArbre = null;

        public CElementDeArbreOperationnelSousSchema(CElementDeArbreOperationnel elementParent)
            : base(elementParent)
        {
        }


        /// <summary>
        /// Id du sous schéma représenté par cet élément
        /// </summary>
        public int IdSchema
        {
            get
            {
                return m_nIdSchema;
            }
            set
            {
                m_nIdSchema = value;
            }
        }

        ///Mode de calcul opérationnel dans le sous schéma
        public EModeOperationnelSchema ModeOperationnel
        {
            get
            {
                return m_modeOperationnelSousSchema;
            }
            set
            {
                m_modeOperationnelSousSchema = value;
            }
        }

        //Indique de où on part dans ce schéma
        public CNoeudDeGrapheReseau NoeudDepart
        {
            get
            {
                return m_noeudDepart;
            }
            set
            {
                m_noeudDepart = value;
            }
        }

        //Indique vers où on va dans ce schéma
        public CNoeudDeGrapheReseau NoeudArrive
        {
            get
            {
                return m_noeudArrivee;
            }
            set
            {
                m_noeudArrivee = value;
            }
        }

        public CElementDeArbreOperationnel ElementDeArbre
        {
            get
            {
                return m_elementDeArbre;
            }
            set
            {
                m_elementDeArbre = value;
                m_elementDeArbre.SetElementParent ( this );
            }
        }

        public override void Simplifier()
        {
            m_elementDeArbre.Simplifier();
            CElementDeArbreOperationnelOperateur op = m_elementDeArbre as CElementDeArbreOperationnelOperateur;
            if (op != null && op.Fils.Count() == 1)
                ElementDeArbre = op.Fils.ElementAt(0);
        }

        public override string ToString()
        {
            string strTexte = ElementDeArbre.ToString();
            string strFils = "";
            foreach (string strTmp in strTexte.Split('\n'))
            {
                strFils += "----" + strTmp + "\n";
            }
            string strNoeuds = "";
            if (NoeudDepart != null)
                strNoeuds = NoeudDepart.IdObjet.ToString();
            strNoeuds += "->";
            if (NoeudArrive != null)
                strNoeuds += NoeudArrive.IdObjet;
            return "SousSchema " + IdSchema + "  "+strNoeuds+"\n" + strFils;
        }

        public override string GetKeyFactorisation()
        {
            string strKey = "(SS" + IdSchema;
            if (m_modeOperationnelSousSchema == EModeOperationnelSchema.AutomaticRedundancy)
                strKey += "_" + NoeudArrive.GetType() + "/" + NoeudArrive.IdSchemaReseau + "/" + NoeudArrive.IdObjet + "-" +
                NoeudDepart.GetType() + "/" + NoeudDepart.IdSchemaReseau + "/" + NoeudDepart.IdObjet + ")";
            else
                strKey += ")";
            return strKey;
        }

        public override string GetFullKey()
        {
            return "(" + GetKeyFactorisation() + "/" + m_elementDeArbre.GetFullKey() + ")";
        }

        public bool  CombineKeyEgal(CElementDeArbreOperationnelOperateur operateur, CElementDeArbreOperationnel autreElement)
        {
            if ( autreElement.GetKeyFactorisation() != GetKeyFactorisation() )
                return false;
            operateur.AddFils(ElementDeArbre);
            operateur.AddFils(((CElementDeArbreOperationnelSousSchema)autreElement).ElementDeArbre);
            ElementDeArbre = operateur;
            operateur.Simplifier();
            return true;
        }

        protected override void  MyRecalculeCoefOperationnelFromChilds()
        {
            if (m_elementDeArbre != null)
                SetCoeffOperationnel(m_elementDeArbre.CoeffOperationnel);
        }

        public override IEnumerable<CElementDeArbreOperationnel> Fils
        {
            get
            {
                if (m_elementDeArbre != null)
                    return new CElementDeArbreOperationnel[]
                    {
                        m_elementDeArbre
                    };
                return new CElementDeArbreOperationnel[0];
            }
        }
    }
}
