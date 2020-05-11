using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.projet.gantt
{
    /// <summary>
    /// Permet de représenter plusieurs projets sur une seule et même ligne
    /// </summary>
    [Serializable]
    public class CElementDeGanttMulti : CElementDeGantt
    {
        private string m_strLibelle = "";
        private string m_strGanttId = "";

        private List<IElementDeGantt> m_listeElementsDeLaLigne = new List<IElementDeGantt>();

        //-------------------------------------------------------------
        public CElementDeGanttMulti(IElementDeGantt elementParent, string strLibelle, string strGanttId)
            :base ( elementParent )
        {
            m_strLibelle = strLibelle;
            m_strGanttId = strGanttId;
        }

        //-------------------------------------------------------------
        public override string Libelle
        {
            get
            {
                return m_strLibelle;
            }
        }

        //-------------------------------------------------------------
        public override void Move(
            TimeSpan spDeplacement, 
            TimeSpan? duree,
            EModeDeplacementProjet mode,
            bool bForceForThisElement)
        {
            return;
        }

        //-------------------------------------------------------------
        public IEnumerable<IElementDeGantt> ElementsDeLaLigne
        {
            get
            {
                return m_listeElementsDeLaLigne.AsReadOnly();
            }
        }

        //-------------------------------------------------------------
        public void AddElementDeLaLigne(IElementDeGantt element)
        {
            m_listeElementsDeLaLigne.Add(element);
        }

        //-------------------------------------------------------------
        public void RemoveElementDeLaLigne(IElementDeGantt element)
        {
            m_listeElementsDeLaLigne.Remove(element);
        }

        //-------------------------------------------------------------
        public override DateTime DateDebut
        {
            get
            {
                return m_listeElementsDeLaLigne.Min(elt => elt.DateDebutPourParent);
            }
            set
            {
            }
        }

        //-------------------------------------------------------------
        public override DateTime DateFin
        {
            get
            {
                return m_listeElementsDeLaLigne.Max(elt => elt.DateFinPourParent);
            }
            set
            {
            }
        }

        //-------------------------------------------------------------
        public override DateTime? DateDebutReelle
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        //-------------------------------------------------------------
        public override DateTime? DateFinReelle
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        //-------------------------------------------------------------
        public override string ElementKey
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                IElementDeGantt elt = this;

                while ( elt != null )
                {
                    bl.Append ( elt.LibelleBarre );
                    bl.Append('/');
                    elt = elt.ElementParent;
                }
                return bl.ToString();
            }
        }

        //--------------------------------------------------------
        /// <summary>
        /// retourne l'identifiant de la barre de gantt associée
        /// </summary>
        public override string GanttBarId
        {
            get
            {
                return "MULTI_" + m_strGanttId;
            }
        }


        //--------------------------------------------------------
        public override bool HasWarnings
        {
            get
            {
                return false;
            }
        }

        

        //------------------------------------------------------------------
        public override IEnumerable<IElementDeGantt> ElementsADessinerSurLaLigne
        {
            get
            {
                return ElementsDeLaLigne;
            }
        }

        public override void AppliqueParametrageDessin(CParametreDessinLigneGantt parametre)
        {
            base.AppliqueParametrageDessin(parametre);
            foreach (IElementDeGantt elt in m_listeElementsDeLaLigne)
                elt.AppliqueParametrageDessin(parametre);
        }
    }
}
