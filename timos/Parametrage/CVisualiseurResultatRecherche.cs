using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.win32.common;
using sc2i.win32.common.recherche;
using sc2i.common;
using sc2i.common.recherche;
using sc2i.data.dynamic.recherche;
using sc2i.data;
using sc2i.win32.data;
using timos.general;
using sc2i.win32.data.navigation;
using sc2i.win32.navigation;
using System.Windows.Forms;

namespace timos.Parametrage
{
    [AutoExec("Autoexec")]
    public class CVisualiseurResultatRecherche
    {
        public static void Autoexec()
        {
            CFormResultatRechercheObjet.OnDemandeAffichageNoeud += new CFormResultatRechercheObjet.OnDemandeAffichageNoeudEventHandler(OnDemandeAffichageRecherche);
        }

        public static void OnDemandeAffichageRecherche(CNoeudCheminResultatRechercheObjetAvecParents noeud)
        {
            //Trouve l'objet donnée le plus bas dans les noeuds
            CNoeudCheminResultatRechercheObjetAvecParents noeudLePlusBas = noeud;
            while (noeudLePlusBas.NoeudFils != null)
                noeudLePlusBas = noeudLePlusBas.NoeudFils;
            CNoeudRechercheObjet_ObjetDonnee noeudObjet = noeudLePlusBas.Noeud as CNoeudRechercheObjet_ObjetDonnee;
            while (noeudLePlusBas != null)
            {
                CNoeudRechercheObjet_ObjetDonnee noeudTest = noeudLePlusBas.Noeud as CNoeudRechercheObjet_ObjetDonnee;
                if (noeudTest != null)
                    noeudObjet = noeudTest;
                if ( noeudObjet != null )
                {
                CObjetDonnee objet = noeudObjet.GetObjet(CSc2iWin32DataClient.ContexteCourant);
                if (objet != null)
                {
                    CReferenceTypeForm refType = CFormFinder.GetRefFormToEdit(objet.GetType());
                    if (refType != null)
                    {
                        IFormNavigable form = refType.GetForm(objet as CObjetDonneeAIdNumeriqueAuto) as IFormNavigable;
                        if (form != null)
                        {
                            CTimosApp.Navigateur.AffichePage(form);
                            return;
                        }
                    }
                }
                }
                noeudLePlusBas = noeudLePlusBas.NoeudParent;
            }
            MessageBox.Show(I.T("Cannot display this element|20143"));
        }
    }
}
