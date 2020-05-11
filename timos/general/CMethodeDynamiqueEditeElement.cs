using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.data;
using sc2i.formulaire;
using sc2i.win32.data.navigation;
using sc2i.formulaire.win32.controles2iWnd;
using timos;
using sc2i.win32.data;

namespace timos
{
	/// <summary>
	/// Ajoute la méthode "EditElement" à C2iWnd Cette méthode ne 
    /// sert pas réellement, elle permet d'appeller celle sur CEncaspuleurControleWndForFormules
	/// </summary>
	[AutoExec("Autoexec")]
	public class CMethodeDynamiqueEditeElementForC2iWnd : CMethodeSupplementaire
	{
        protected CMethodeDynamiqueEditeElementForC2iWnd()
			: base(typeof(C2iWnd))
		{
		}

		public static void Autoexec()
		{
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeDynamiqueEditeElementForC2iWnd());
		}

		public override string Name
		{
			get
			{
				return "EditEntity";
			}
		}

		public override string Description
		{
			get
			{
				return I.T("Edit an entity in main window (only for forms in Timos)|20472");
			}
		}

		public override Type ReturnType
		{
			get
			{
				return typeof(bool);
			}
		}

		public override bool ReturnArrayOfReturnType
		{
			get
			{
				return false;
			}
		}


		public override CInfoParametreMethodeDynamique[] InfosParametres
		{
			get
			{
				return new CInfoParametreMethodeDynamique[]
					{
                        new CInfoParametreMethodeDynamique ( "Edited element","Element to display", typeof(CObjetDonneeAIdNumeriqueAuto)),
                        new CInfoParametreMethodeDynamique ( "Form code","code for the form to use", typeof(string))
					};
			}
		}

		public override object Invoke(object objetAppelle, params object[] parametres)
		{
            return false;
        }
    }
          
    /// <summary>
	/// Ajoute la méthode "EditElement" à CEncaspuleurControleWndForFormules cette méthode
    /// est appellé en trichant sur la méthode sur C2iWnd
	/// </summary>
	[AutoExec("Autoexec")]
	public class CMethodeDynamiqueEditeElementForCEncapsuleur : CMethodeSupplementaire
	{
        protected CMethodeDynamiqueEditeElementForCEncapsuleur()
			: base(typeof(CEncaspuleurControleWndForFormules))
		{
		}

		public static void Autoexec()
		{
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeDynamiqueEditeElementForCEncapsuleur());
		}

		public override string Name
		{
			get
			{
				return "EditEntity";
			}
		}

		public override string Description
		{
			get
			{
				return I.T("Edit an entity in main window (only for forms in Timos)|20472");
			}
		}

		public override Type ReturnType
		{
			get
			{
				return typeof(bool);
			}
		}

		public override bool ReturnArrayOfReturnType
		{
			get
			{
				return false;
			}
		}


		public override CInfoParametreMethodeDynamique[] InfosParametres
		{
			get
			{
				return new CInfoParametreMethodeDynamique[]
					{
                        new CInfoParametreMethodeDynamique ( "Edited element","Element to display", typeof(CObjetDonneeAIdNumeriqueAuto)),
                        new CInfoParametreMethodeDynamique ( "Form code","code for the form to use", typeof(string))
					};
			}
		}

		public override object Invoke(object objetAppelle, params object[] parametres)
		{
            if (parametres.Length < 1)
                return false;
            CObjetDonneeAIdNumeriqueAuto objet = parametres[0] as CObjetDonneeAIdNumeriqueAuto;
            if (objet == null)
                return false;
            objet = objet.GetObjetInContexte(CSc2iWin32DataClient.ContexteCourant) as CObjetDonneeAIdNumeriqueAuto;
            if (objet == null)
                return false;
            CReferenceTypeForm refForm = null;
            string strCode = null;
            if ( parametres.Length > 1 )
                strCode = parametres[1] as string;
            if (strCode == null || strCode.Length == 0)
                refForm = CFormFinder.GetRefFormToEdit(objet.GetType());
            else
                refForm = CFormFinder.GetRefFormToEdit(objet.GetType(), strCode);

            if (refForm != null)
            {
                CFormEditionStandard frm = refForm.GetForm(objet) as CFormEditionStandard;
                if (frm != null)
                {
                    CTimosApp.Navigateur.AffichePage(frm);
                    return true;
                }
            }
            return false;
		}
	}
}
