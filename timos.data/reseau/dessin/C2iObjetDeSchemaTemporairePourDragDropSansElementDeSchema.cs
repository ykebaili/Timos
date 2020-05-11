using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.drawing;

namespace timos.data
{
    /// <summary>
    /// Utilisé dans les drag and drop, lorsque les éléments de schéma ne sont pas encore alloués
    /// </summary>
    public class C2iObjetDeSchemaTemporairePourDragDropSansElementDeSchema : C2iObjetDeSchema
    {
        private CReferenceObjetDonnee m_elementAssocie = null;
        
        //Indique si la taille a été définie à l'initialisation
        private bool m_bSizeIsSet = false;

        public C2iObjetDeSchemaTemporairePourDragDropSansElementDeSchema()
            : base()
        {
        }

        public void InitFrom(IElementDeSchemaReseau element)
        {
            if (element != null)
            {
                m_elementAssocie = new CReferenceObjetDonnee((CObjetDonnee)element);
                C2iSymbole symbole = element.SymboleADessiner;
                if (symbole != null)
                {
                    Size = symbole.Size;
                    m_bSizeIsSet = true;
                }
            }

        }

        public void InitFrom(CReferenceObjetDonnee referenceObjet)
        {
            m_elementAssocie = referenceObjet;
            m_bSizeIsSet = false;
        }

        public void InitFrom(C2iObjetDeSchema objet)
        {
            if (objet.ElementDeSchema != null)
            {
                if (objet.ElementDeSchema.ElementAssocie != null)
                    m_elementAssocie = new CReferenceObjetDonnee((CObjetDonnee)objet.ElementDeSchema.ElementAssocie);
                Size = objet.Size;
                m_bSizeIsSet = true;
            }
        }

        //------------------------------------------------------------------------------------------
        public override I2iObjetGraphique GetCloneAMettreDansParent(I2iObjetGraphique parent, Dictionary<Type, object> dicObjetsPourCloner)
        {
            C2iObjetDeSchema parentAsC2iObjet = parent as C2iObjetDeSchema;
            if (m_elementAssocie != null && parentAsC2iObjet != null && parentAsC2iObjet.SchemaContenant != null)
            {
                IElementDeSchemaReseau eltDeSchema = (IElementDeSchemaReseau)m_elementAssocie.GetObjet(parentAsC2iObjet.SchemaContenant.ContexteDonnee);
                CElementDeSchemaReseau newElement = new CElementDeSchemaReseau(eltDeSchema.ContexteDonnee);
                newElement.CreateNewInCurrentContexte();
                newElement.ElementAssocie = eltDeSchema;
                newElement.SchemaReseau = parentAsC2iObjet.SchemaContenant;
                
                if ( !m_bSizeIsSet )
                {
                    C2iSymbole symbole = eltDeSchema.SymboleADessiner;
                    if ( symbole != null )
                    {
                     Size = symbole.Size;
                     m_bSizeIsSet = true;   
                    }
                }
                newElement.Width = Size.Width;
                newElement.Height = Size.Height;

                C2iObjetDeSchema obj = eltDeSchema.GetObjetDeSchema(newElement);
                return obj;
            }
            return null;
        }

                

        
    }
}
