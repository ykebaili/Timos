using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;
using System.Data;
using timos.data.reseau.arbre_operationnel;
using timos.data.reseau.graphe;
using timos.data;

namespace spv.data
{
    public class CSpvElementDeGrapheElementDeSchema : CSpvElementDeGraphe
    {
        //---------------------------------------------------------------------
        public CSpvElementDeGrapheElementDeSchema ( CContexteDonnee contexte )
            :base ( contexte )
        {
        }

        //---------------------------------------------------------------------
        public CSpvElementDeGrapheElementDeSchema(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------------------------------------
        protected override void MyInitValeurDefaut()
        {
            SetType(ETypeElementDeGrapheSpv.Entite);
        }

        //---------------------------------------------------------------------
        public override CFiltreData FiltreStandard
        {
            get
            {
                return new CFiltreData ( c_champType+"=@1", 
                    (int)ETypeElementDeGrapheSpv.Entite);
            }
        }

        ///////////////////////////////////////////////////////////////
        public CSpvSite SpvSite
        {
            get
            {
                return _sys_SpvSite;
            }
            set
            {
                _sys_SpvSite = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        public CSpvEquip SpvEquip
        {
            get
            {
                return _sys_SpvEquip;
            }
            set
            {
                _sys_SpvEquip = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        public CSpvLiai SpvLiai
        {
            get
            {
                return _sys_SpvLiai;
            }
            set
            {
                _sys_SpvLiai = value ;
            }
        }

        ///////////////////////////////////////////////////////////////
        public IElementACoeffOperationnel ElementAssocie
        {
            get
            {
                if (_sys_SpvSite != null)
                    return _sys_SpvSite;
                if (_sys_SpvLiai != null)
                    return _sys_SpvLiai;
                if (_sys_SpvEquip != null)
                    return _sys_SpvEquip;
                return null;
            }
            set
            {
                SpvSite = value as CSpvSite;
                SpvLiai = value as CSpvLiai;
                SpvEquip = value as CSpvEquip;
            }
        }

        ///////////////////////////////////////////////////////////////
        protected override CResultAErreur MyFillFromElementDeGraphe(CElementDeArbreOperationnel element)
        {
            CResultAErreur result = CResultAErreur.True;
            CElementDeArbreOperationnelEntite eltComposant = element as CElementDeArbreOperationnelEntite;
            if (eltComposant == null)
            {
                result.EmpileErreur(I.T("Bad element type|20030"));
                return result;
            }
            CComposantDeGrapheReseau composant = eltComposant.Composant;

            IElementDeSchemaReseau eltAssocie = composant.GetElementAssocie(ContexteDonnee);
            ElementAssocie = null;
            if (eltAssocie is CSite)
                ElementAssocie = CSpvSite.GetObjetSpvFromObjetTimosAvecCreation(eltAssocie as CSite);
            else if (eltAssocie is CEquipementLogique)
                ElementAssocie = CSpvEquip.GetObjetSpvFromObjetTimosAvecCreation(eltAssocie as CEquipementLogique);
            else if (eltAssocie is CLienReseau)
                ElementAssocie = CSpvLiai.GetObjetSpvFromObjetTimosAvecCreation(eltAssocie as CLienReseau);
            if (ElementAssocie == null)
            {
                result.EmpileErreur(I.T("Can not associate element to Graph component|20031"));
                return result;
            }
            return result;
        }

        public override string GetStringDebugDescription()
        {
            IElementACoeffOperationnel elt = ElementAssocie;

            string strDescElement = "null";
            if ( elt != null )
            {
                strDescElement = DynamicClassAttribute.GetNomConvivial(elt.GetType() );
                strDescElement += elt.Id;
            }

            return "Elt " + strDescElement;
        }
    }
}
