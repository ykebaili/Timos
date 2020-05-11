using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data.projet.Contraintes;

namespace timos.data.projet.gantt
{
    public class CElementDeGanttMetaProjet : CElementDeGantt, IElementAUniteGanttParDefaut
    {
        private CMetaProjet m_metaProjet = null;

        //-----------------------------------------------
        public CElementDeGanttMetaProjet(IElementDeGantt elementParent, CMetaProjet metaProjet)
            :base ( elementParent )
        {
            m_metaProjet = metaProjet;
            PctAvancement = metaProjet.PctAvancement;
            Poids = 1;
        }

        //-----------------------------------------------
        public override string Libelle
        {
            get
            {
                if (MetaProjetAssocie != null)
                    return MetaProjetAssocie.Libelle;
                return "";
            }
        }

        //-----------------------------------------------
        [DynamicField("Associated meta project")]
        public CMetaProjet MetaProjetAssocie
        {
            get
            {
                return m_metaProjet;
            }
        }

      

        //-----------------------------------------------
        public override DateTime? DateDebutReelle
        {
            get
            {
                return MetaProjetAssocie.DateDebutReelle;
            }
            set
            {
            }
        }

        //-----------------------------------------------
        public override DateTime? DateFinReelle
        {
            get
            {
                return MetaProjetAssocie.DateFinReelle;
            }
            set
            {
            }
        }

        //-----------------------------------------------
        public override void Move(
            TimeSpan spDeplacement, 
            TimeSpan ? duree,
            EModeDeplacementProjet mode,
            bool bForceForThisElement)
        {
            MetaProjetAssocie.Move(spDeplacement, duree, mode, bForceForThisElement);
            DatesAreDirty = true;

        }

        private DateTime? m_dateDebutPlanifiee = null;
        private DateTime? m_dateFinPlanifiee = null;

        private void UpdateDates()
        {
            if (m_dateDebutPlanifiee == null || m_dateFinPlanifiee == null || DatesAreDirty)
            {
                m_dateDebutPlanifiee = ElementsFils.Min(elt => elt.DateDebutPourParent);
                m_dateFinPlanifiee = ElementsFils.Max(elt => elt.DateFinPourParent);

                DatesAreDirty = false;
            }
        }

        public override DateTime DateDebut
        {
            get
            {
                UpdateDates();
                return m_dateDebutPlanifiee == null ? DateTime.Now : m_dateDebutPlanifiee.Value;
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
                return m_dateFinPlanifiee == null ? DateTime.Now : m_dateFinPlanifiee.Value;
            }
            set
            {
            }
        }



        
        //-----------------------------------------------
        public override string ElementKey
        {
            get
            {
                if (m_metaProjet != null && m_metaProjet.IsValide())
                    return "MPRJ_"+m_metaProjet.Id.ToString();
                return "";
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
                if (m_metaProjet != null)
                    return "MPRJ_" + m_metaProjet.Id.ToString();
                return "";
            }
        }


        //-----------------------------------------------
        public override bool HasWarnings
        {
            get
            {
                return false;
                /*foreach (IElementDeGantt elt in ElementsFils)
                    if (elt.HasWarnings)
                        return true;
                return false;*/
            }
        }

        //------------------------------------------------------------------------
        public EGanttTimeUnit UniteParDefaut
        {
            get
            {
                if (MetaProjetAssocie != null && MetaProjetAssocie.TypeMetaProjet != null)
                    return MetaProjetAssocie.TypeMetaProjet.DefaultTimeUnit;
                return EGanttTimeUnit.Semaine;
            }
            set
            {
                if (MetaProjetAssocie != null && MetaProjetAssocie.TypeMetaProjet != null)
                {
                    CTypeMetaProjet type = MetaProjetAssocie.TypeMetaProjet;
                    type.BeginEdit();
                    type.DefaultTimeUnit = value;
                    type.CommitEdit();
                }
            }
        }

        //------------------------------------------------------------------------
        public int PrecisionParDefault
        {
            get
            {
                if (MetaProjetAssocie != null && MetaProjetAssocie.TypeMetaProjet != null)
                    return MetaProjetAssocie.TypeMetaProjet.DefaultTimePrecision;
                return 1;
            }
            set
            {
                if (MetaProjetAssocie != null && MetaProjetAssocie.TypeMetaProjet != null)
                {
                    CTypeMetaProjet type = MetaProjetAssocie.TypeMetaProjet;
                    type.BeginEdit();
                    type.DefaultTimePrecision = value;
                    type.CommitEdit();
                }
            }
        }
    }
}
