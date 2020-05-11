using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using sc2i.workflow;

namespace timos.data.sites.releve.actions
{
    //--------------------------------------------------------------------------
    public class CActionDeplacerEquipement : CActionTraitementReleveEquipement
    {
        private CEquipement m_equipement = null;
        private IEmplacementEquipement m_emplacement = null;
        

        //--------------------------------------------------------------------------
        public CActionDeplacerEquipement(CReleveEquipement releveEquipement)
            : base(releveEquipement)
        {
        }

        //--------------------------------------------------------------------------
        public CActionDeplacerEquipement(CReleveEquipement releveEquipement, 
            CEquipement equipement,
            IEmplacementEquipement emplacement)
            : base(releveEquipement)
        {
            m_equipement = equipement;
            m_emplacement = emplacement;
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Equipement à déplacer ne doit pas être null
        /// </summary>
        public CEquipement Equipement
        {
            get
            {
                return m_equipement;
            }
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// si null, c'est sur l'emplacement par défaut des équipements trouvés que ça se passe !
        /// </summary>
        public IEmplacementEquipement Emplacement
        {
            get
            {
                return m_emplacement;
            }
            set
            {
                m_emplacement = value;
            }
        }

        //---------------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            return new CActionTraitementReleveEquipement[0];
        }

        //---------------------------------------------------------------
        public override string Libelle
        {
            get
            {
                return I.T("Move @1 from @2 to @3|20206",
                    m_equipement.Libelle,
                    m_equipement.Emplacement.Libelle,
                    m_emplacement != null?m_emplacement.Libelle:CEmplacementEquipementsTrouves.Libelle);
            }
        }

        //---------------------------------------------------------------
        public override bool IsExecutable
        {
            get { return true; }
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }


        //---------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            int? nIdEquipement = m_equipement != null?(int?)m_equipement.Id:null;
            int? nIdEmplacement = m_emplacement != null ? (int?)m_emplacement.Id : null;
            serializer.TraiteIntNullable(ref nIdEquipement);
            serializer.TraiteIntNullable(ref nIdEmplacement);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (nIdEmplacement != null)
                    {
                        Type tp = m_emplacement.GetType();
                        serializer.TraiteType(ref tp);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    CContexteDonnee ctx = ReleveEquipement.ContexteDonnee;
                    if (nIdEquipement != null)
                    {
                        m_equipement = new CEquipement(ctx);
                        if (!m_equipement.ReadIfExists(nIdEquipement.Value))
                            m_equipement = null;
                    }
                    if (nIdEmplacement != null)
                    {
                        Type tp = null;
                        serializer.TraiteType(ref tp);
                        m_emplacement = Activator.CreateInstance(tp, new object[] { ReleveEquipement.ContexteDonnee }) as IEmplacementEquipement;
                        if (m_emplacement != null)
                        {
                            if (!m_emplacement.ReadIfExists(nIdEmplacement.Value))
                                m_emplacement = null;
                        }
                    }
                    break;
            }
            return result;
        }

        //----------------------------------------------------------------------------------
        public override CResultAErreur ExecuteAction(
            CTraitementReleveEquipement traitementExecutant,
            CEquipement equipementParent,
            CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            CEquipement eqpt = (CEquipement)m_equipement.GetObjetInContexte(ctxDonnee);
            IEmplacementEquipement emplacement = m_emplacement;
            if (emplacement == null)
                emplacement = CEmplacementEquipementsTrouves.StockPerduTrouve;
            if (emplacement == null)
            {
                result.EmpileErreur(I.T("'lost & found' stock is not defined. Contact Timos Administrator|20216"));
                return result;
            }
            string strSiteLabel = "";
            string strDate = "";
            try
            {
                strSiteLabel = ReleveEquipement.ReleveSite.Site.Libelle;
                strDate = ReleveEquipement.ReleveSite.DateReleve.ToShortDateString();
            }
            catch { }
            result = eqpt.DeplaceEquipementOptionPassage(
                I.T("Inventory on @1 (@2)|20245",
                strSiteLabel, strDate),
                emplacement,
                equipementParent != null && equipementParent.Emplacement.Equals(emplacement) ? equipementParent : null,
                traitementExecutant.ReleveEquipement.Coordonnee,
                null,
                CUtilSession.GetUserForSession(ctxDonnee),
                DateTime.Now,"", false, true);
            if (result && emplacement.Equals(ReleveEquipement.ReleveSite.Site )  )
                result = CActionModifierEquipement.MajEquipement(eqpt, traitementExecutant.ReleveEquipement);
            return result;
        }            
    }
}
