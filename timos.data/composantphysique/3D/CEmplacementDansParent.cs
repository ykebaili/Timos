using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using sc2i.common;

namespace timos.data.composantphysique
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public abstract class CEmplacementDansParent : I2iSerializable
    {


        private C2iComposant3D m_composantAssocie = null;

        public CEmplacementDansParent()
        {
        }

        public CEmplacementDansParent(C2iComposant3D composant)
        {
            m_composantAssocie = composant;
        }


        [Browsable(false)]
        public C2iComposant3D ComposantAssocie
        {
            get
            {
                return m_composantAssocie;
            }
            set
            {
                m_composantAssocie = value;
            }
        }

        public virtual void OnChangeValeur()
        {
            if (ComposantAssocie != null && ComposantAssocie.Parent != null)
                ComposantAssocie.Parent.RepositionneChilds();
        }

        public abstract CResultAErreur Serialize ( C2iSerializer serializer );

    }
}
