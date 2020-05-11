using System;
using System.Collections.Generic;
using System.Text;
using sc2i.win32.common;
using sc2i.formulaire.win32;
using sc2i.formulaire.win32.controles2iWnd;
using sc2i.win32.data.dynamic.controlesFor2iWnd;
using timos.data;
using sc2i.formulaire;
using System.Windows.Forms;
using sc2i.expression;
using sc2i.common;
using timos;
using timos.data.C2iWndComposants;
using timos.Reseau;
using sc2i.common.Restrictions;

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForC2iWndSchemaReseau : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
        private CControleEditionSchemaReseauSimple m_controleSchemaReseau = new CControleEditionSchemaReseauSimple();
        

		//---------------------------------------------------------------
		public static void Autoexec()
		{
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndSchemaReseau), typeof(CWndForC2iWndSchemaReseau));
		}

		//---------------------------------------------------------------
		protected override void MyCreateControle(
			CCreateur2iFormulaireV2 createur,
			C2iWnd wnd, 
			Control parent, 
			IFournisseurProprietesDynamiques fournisseurProprietes)
		{

            if (WndSchemaReseau == null)
				return;
			CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndSchemaReseau, m_controleSchemaReseau);
			parent.Controls.Add(m_controleSchemaReseau);


        }

		//-------------------------------------
		private C2iWndSchemaReseau WndSchemaReseau
		{
			get
			{
				return WndAssociee as C2iWndSchemaReseau;

			}
		}

		//---------------------------------------------------------------
		public override Control Control
		{
			get
			{
				return m_controleSchemaReseau;
			}
		}

		//---------------------------------------------------------------
		protected override void OnChangeElementEdite(object element)
		{
			UpdateValeursCalculees();
		}


		//---------------------------------------------------------------
		protected override CResultAErreur MyMajChamps(bool bControlerLesValeursAvantValidation)
		{
			return CResultAErreur.True;
		}

		//-----------------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
            CContexteEvaluationExpression ctx = CUtilControlesWnd.GetContexteEval(this,EditedElement);
            if(WndSchemaReseau.ElementFormula != null)
            {
                CResultAErreur resultExpression = WndSchemaReseau.ElementFormula.Eval(ctx);
                if( resultExpression)
                {
                    // Schema de réseau
                    CSchemaReseau schema = resultExpression.Data as CSchemaReseau;
                    if (schema != null)
                    {
                        // Init ici
                        m_controleSchemaReseau.Init(schema.GetSchema(false), schema);
                        m_controleSchemaReseau.LockEdition = true;
                        m_controleSchemaReseau.ModeEdition = EModeEditeurSchema.Selection;
                    }
                }
            }

            if (WndSchemaReseau.DynamicNetworkViewFormula != null)
            {
                CResultAErreur resultExpression = WndSchemaReseau.DynamicNetworkViewFormula.Eval(ctx);
                if (resultExpression)
                {
                    // Parametre de vue dynamique
                    CParametreVueSchemaDynamique parametre = resultExpression.Data as CParametreVueSchemaDynamique;
                    if (parametre != null)
                    {
                        m_controleSchemaReseau.ParametreDynamique = parametre.ParametreRepresentation;
                    }
                }
            }

		}


		//---------------------------------------------
        protected override void MyAppliqueRestriction(
            CRestrictionUtilisateurSurType restrictionSurObjetEdite,
            CListeRestrictionsUtilisateurSurType restrictions,
            IGestionnaireReadOnlySysteme gestionnaireReadOnly)
		{

        }
	}
}
