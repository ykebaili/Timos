using System;
using System.Drawing;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;

using sc2i.workflow;
using sc2i.documents;
using sc2i.multitiers.client;
using timos.acteurs;
using timos.securite;

namespace sc2i.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionAppliquerEosPlanifiees : CActionLienSortantSimple
	{
		/// /////////////////////////////////////////
		public CActionAppliquerEosPlanifiees( CProcess process )
			:base(process)
		{
			Libelle = I.T("Apply planified O.E.|467");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Apply planified O.E.|467"),
				I.T( "Apply all planified O.Es to members depending on the current date|468"),
				typeof(CActionAppliquerEosPlanifiees),
				CGestionnaireActionsDisponibles.c_categorieMetier );
		}


		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}


		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base.MySerialize( serializer );
			if ( !result )
				return result;

			return result;
		}

		
		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();

			return result;
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			
			try
			{
				CListeObjetsDonnees liste = new CListeObjetsDonnees(contexte.ContexteDonnee, typeof(CActeur));
				CFiltreData filtre = new CFiltreDataAvance(
					CActeur.c_nomTable,
					"Has("+CEOplanifiee_Acteur.c_nomTable+"."+CEOplanifiee_Acteur.c_champId+")");
				liste.Filtre = filtre;
				foreach ( CActeur acteur in liste )
				{
					//Il suffit de modifier l'acteur pour qu'on recalcule ces eos
					CUtilElementAEO.UpdateEOSInCurrentContext(acteur);
				}
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}

			return result;
		}

		//-----------------------------------------------
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
			
		}
	}
}
