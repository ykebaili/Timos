using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.sites.releve.actions
{
    public class CActionDeplacerOuCreer : CActionTraitementReleveEquipement
    {
        private List<CEquipement> m_listeEquipementsDeplaçables = new List<CEquipement>();

        //----------------------------------------------------------------------------------
        public CActionDeplacerOuCreer ( CReleveEquipement releve )
            :base ( releve )
        {  
        }

        //----------------------------------------------------------------------------------
        public CActionDeplacerOuCreer(CReleveEquipement releveEquipement,
            IEnumerable<CEquipement> equipementsDeplaçables)
            :base ( releveEquipement )
        {
            foreach ( CEquipement eqpt in equipementsDeplaçables )
            {
                m_listeEquipementsDeplaçables.Add ( eqpt );
            }
        }

        //----------------------------------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            List<CActionTraitementReleveEquipement> lst = new List<CActionTraitementReleveEquipement>();
            foreach ( CEquipement eqpt in m_listeEquipementsDeplaçables )
            {
                if (ReleveEquipement.Equipement != null)
                {
                    lst.Add(new CActionDoubleAction(ReleveEquipement,
                        new CActionDeplacerEquipement(ReleveEquipement, eqpt, ReleveEquipement.ReleveSite.Site),
                        new CActionDeplacerEquipement(ReleveEquipement, ReleveEquipement.Equipement, null)));
                }
                else
                    lst.Add(new CActionDeplacerEquipement(ReleveEquipement, eqpt, ReleveEquipement.ReleveSite.Site));
            }
            if (ReleveEquipement.Equipement != null)
                lst.Add(new CActionDoubleAction(ReleveEquipement,
                    new CActionCreerEquipement(ReleveEquipement),
                    new CActionDeplacerEquipement(ReleveEquipement, ReleveEquipement.Equipement, null)));
            else
                lst.Add(new CActionCreerEquipement(ReleveEquipement));

            if (m_listeEquipementsDeplaçables.Count() > 0)
            {
                Info = I.T("Serial number has been modified during inventory. @1 device(s) have the corresponding serial number|20211",
                    m_listeEquipementsDeplaçables.Count().ToString());
            }

            return lst.ToArray();
        }

        //----------------------------------------------------------------------------------
        public override string Libelle
        {
            get { return I.T("Choose action|20207"); }
        }

        //---------------------------------------------------------------
        public override bool IsExecutable
        {
            get { return false; }
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
            int nNb = m_listeEquipementsDeplaçables.Count;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (CEquipement eqpt in m_listeEquipementsDeplaçables)
                    {
                        int nId = eqpt.Id;
                        serializer.TraiteInt(ref nId);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    List<CEquipement> lst = new List<CEquipement>();
                    for (int n = 0; n < nNb; n++)
                    {
                        int nId = -1;
                        serializer.TraiteInt(ref nId);
                        CEquipement eqpt = new CEquipement(ReleveEquipement.ContexteDonnee);
                        if (eqpt.ReadIfExists(nId))
                            lst.Add(eqpt);
                    }
                    m_listeEquipementsDeplaçables = lst;
                    break;

            }
            return result;
        }

        //--------------------------------------------------------------------------
        public override CResultAErreur ExecuteAction(
            CTraitementReleveEquipement traitementExecutant,
            CEquipement equipementParent,
            CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            result.EmpileErreur("Action '@1' can not be executed on '@2'|20220",
                Libelle,
                traitementExecutant.ReleveEquipement.DescriptionElement);
            return result;
        }
    }
}
