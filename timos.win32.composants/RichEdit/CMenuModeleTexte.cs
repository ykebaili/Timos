using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;

using System.Windows.Forms;
using System.Data;

using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.multitiers.client;

namespace timos.win32.composants
{
	public partial class CMenuModeleTexte : System.Windows.Forms.ToolStripMenuItem
	{
		private readonly CModeleTexte ModeleTexte = null;
		private readonly string Contexte = "";
		private readonly Object Objet = null;

		public CMenuModeleTexte(CModeleTexte modele, string strContexte, object objet )
			:base ( modele==null?"":modele.Libelle )
		{
			InitializeComponent();
			ModeleTexte = modele;
			Contexte = strContexte;
			Objet  = objet;
		}

		public Type TypeObjet
		{
			get
			{
				return Objet.GetType();
			}
		}

		public CMenuModeleTexte(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public static void AddToMenuParent(ToolStripMenuItem menu, string strContexte, object objet)
		{
			if (objet == null)
				return;

			CModeleTexte modeleSel = CTimosAppRegistre.GetModeleTexteForType(strContexte, objet.GetType());
					
			CListeObjetsDonnees liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CModeleTexte));
			liste.Filtre = new CFiltreData(CModeleTexte.c_champTypeAssocie + "=@1",
				objet.GetType().ToString());
			foreach ( CModeleTexte modele in liste )
			{
				CMenuModeleTexte menuModele = new CMenuModeleTexte ( modele, strContexte, objet );
				if (modeleSel != null && modele.Id == modeleSel.Id)
					menuModele.Checked = true;
				menuModele.MouseUp += new MouseEventHandler(menuModele.menuModele_MouseUp);
				menu.DropDownItems.Add ( menuModele );
			}

            CSessionClient session = CSessionClient.GetSessionForIdSession(CSc2iWin32DataClient.ContexteCourant.IdSession);
            if ( session != null )
            {
                IInfoUtilisateur info = session.GetInfoUtilisateur();
                if ( info != null && info.GetDonneeDroit ( CDroitDeBaseSC2I.c_droitAdministration ) !=null )
                {
			            menu.DropDownItems.Add ( new ToolStripSeparator() );
            			CMenuModeleTexte menuModeleAdd = new CMenuModeleTexte(null, strContexte, objet);
            			menuModeleAdd.Text = I.T( "Add|124");
            			menuModeleAdd.Click += new EventHandler(menuModeleAdd.itemAddMenu_Click);
            			menu.DropDownItems.Add(menuModeleAdd);
                }
            }
			
			if (menu.DropDownItems.Count == 0)
				menu.Visible = false;			
		}

		//-----------------------------------------------------------------
		void menuModele_MouseUp(object sender, MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
				CModeleTexte modele = ModeleTexte;
				if (modele != null)
				{
					modele.BeginEdit();
					if (CFormPopupEditeModeleTexte.EditeModele(modele))
					{
						modele.CommitEdit();
						CTimosAppRegistre.SetModeleTexteForType(ModeleTexte, Contexte, TypeObjet);
					}
					else
						modele.CancelEdit();
				}
			}
			else
				CTimosAppRegistre.SetModeleTexteForType(ModeleTexte, Contexte, TypeObjet);
		}

		//-----------------------------------------------------------------
		private void itemEditMenu_Click ( object sender, EventArgs args )
		{
			CModeleTexte modele = ModeleTexte;
			if (modele != null)
			{
				modele.BeginEdit();
				if (CFormPopupEditeModeleTexte.EditeModele(modele))
				{
					modele.CommitEdit();
					CTimosAppRegistre.SetModeleTexteForType(ModeleTexte, Contexte, TypeObjet);
				}
				else
					modele.CancelEdit();
			}
		}

		//-----------------------------------------------------------------
		private void itemAddMenu_Click(object sender, EventArgs args)
		{
			CModeleTexte modele = new CModeleTexte(CSc2iWin32DataClient.ContexteCourant);
			modele.CreateNew();
			modele.TypeAssocie = TypeObjet;
			if (CFormPopupEditeModeleTexte.EditeModele(modele))
			{
				CResultAErreur result = modele.CommitEdit();
				if (!result)
					CFormAlerte.Afficher(result.Erreur.ToString(), EFormAlerteType.Erreur);
				else
					CTimosAppRegistre.SetModeleTexteForType(ModeleTexte, Contexte, TypeObjet);
			}
			else
			{
				if (ModeleTexte != null)
					ModeleTexte.CancelEdit();
			}
		}
		
	}

	
}
