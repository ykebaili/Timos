using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.projet.gantt
{
    [Serializable]
    public class CElementDeGanttGroupe : CElementDeGantt
    {
        private string m_strLibelle = "";
        //-------------------------------------------------------------
        public CElementDeGanttGroupe(IElementDeGantt elementParent, string strLibelle)
            :base ( elementParent )
        {
            m_strLibelle = strLibelle;
        }

        //-------------------------------------------------------------
        public override string Libelle
        {
            get
            {
                return m_strLibelle;
            }
        }

        public override void Move(
            TimeSpan spDeplacement, 
            TimeSpan? duree,
            EModeDeplacementProjet mode,
            bool bForceForThisElement)
        {
            CResultAErreur result = CResultAErreur.True;
            DateDebut = DateDebut.Add(spDeplacement);
            if (duree == null)
                DateFin = DateFin.Add(spDeplacement);
            else
                DateFin = DateDebut.Add(duree.Value);
            foreach (IElementDeGantt eltFils in ElementsFils)
            {
                eltFils.Move(spDeplacement, null, mode, false);
            }
            DatesAreDirty = true;

        }

        private DateTime? m_dateDebut = null;
        private DateTime? m_dateFin = null;

        private void UpdateDates()
        {
            if (m_dateDebut == null || m_dateFin == null || DatesAreDirty)
            {
                m_dateDebut = ElementsFils.Min(elt => elt.DateDebutPourParent);
                m_dateFin = ElementsFils.Max(elt => elt.DateFinPourParent);
                DatesAreDirty = false;
            }
        }

        public override DateTime DateDebut
        {
            get
            {
                UpdateDates();
                return m_dateDebut == null?DateTime.Now:m_dateDebut.Value;
            }
            set
            {
            }
        }

        public override DateTime DateFin
        {
            get
            {
                UpdateDates();
                return m_dateFin == null? DateTime.Now:m_dateFin.Value;
            }
            set
            {
            }
        }

        public override DateTime? DateDebutReelle
        {
            get
            {
                //TODO
                return null;
            }
            set
            {
            }
        }

        public override DateTime? DateFinReelle
        {
            get
            {
                //TODO
                return null;
            }
            set
            {
            }
        }

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
                return "GRP" + LibelleBarre;
            }
        }


        //--------------------------------------------------------
        public override bool HasWarnings
        {
            get
            {
                return false;
                //SC 06 04 2013 : pour homogénéité : si un projet a des fils qui ont des warnings, le projet parent n'a pas de warning
                //alors pourquoi le groupe en aurait-il ? en plus ça ralentit (1s si 500 fils)
                /*foreach (IElementDeGantt elt in ElementsFils)
                    if (elt.HasWarnings)
                        return true;
                return false;*/
            }
        }
    }
}
