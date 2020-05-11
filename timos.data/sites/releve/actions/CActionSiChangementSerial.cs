using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;

namespace timos.data.sites.releve.actions
{
    public class CActionSiChangementSerial : CActionTraitementReleveEquipement
    {
        //-----------------------------------------------------------
        public CActionSiChangementSerial(CReleveEquipement releve)
            :base(releve)
        {
        }

        //-----------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            List<CActionTraitementReleveEquipement> lstActions = new List<CActionTraitementReleveEquipement>();
            lstActions.Add(new CActionModifierEquipement(ReleveEquipement));
            //S'il existe un équipement avec le même numéro de série
            CListeObjetDonneeGenerique<CEquipement> lst = this.ListeAvecMemeSerial;
            lstActions.Add ( new CActionDeplacerOuCreer ( ReleveEquipement, lst.ToArray() ));
            if (lst.Count() > 0)
            {
                Info = I.T("Serial number has been modified during inventory. @1 device(s) have the corresponding serial number|20211",
                        lst.Count().ToString());
            }
            else
                Info = I.T("Serial number has been modified during inventory|20212");
            return lstActions.ToArray();
        }

        //---------------------------------------------------
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
