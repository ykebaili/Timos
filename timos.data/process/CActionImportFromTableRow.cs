using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Collections.Generic;

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
using timos.data;
using System.IO;
using sc2i.data.Excel;
using sc2i.process.workflow;
using timos.data.process.workflow;


namespace sc2i.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionImportFromTableRow : CActionLienSortantSimple
	{
        public class CMappageColonne : I2iSerializable
        {
            private int m_nIdColonne = -1;
            private CDefinitionProprieteDynamique m_proprieteCible = null;
            private C2iExpression m_formuleCondition = null;

            public CMappageColonne ( )
            {}

            public int IdColonne
            {
                get{return m_nIdColonne;
                }
                set{m_nIdColonne = value;
                }
            }

            public C2iExpression FormuleCondition
            {
                get{return m_formuleCondition;
                }
                set{m_formuleCondition = value;
                }
            }

            public CDefinitionProprieteDynamique ProprieteCible
            {
                get
                {
                    return m_proprieteCible;
                }
                set{m_proprieteCible = value;
                }
            }

            private int GetNumVersion()
            {return 0;
            }

            public CResultAErreur Serialize ( C2iSerializer serializer )
            {
                int nVersion = GetNumVersion();
                CResultAErreur result=  serializer.TraiteVersion ( ref nVersion );
                if ( !result )
                    return result;
                serializer.TraiteInt ( ref m_nIdColonne );
                result = serializer.TraiteObject<C2iExpression> ( ref m_formuleCondition );
                if ( result )
                    result = serializer.TraiteObject<CDefinitionProprieteDynamique>( ref m_proprieteCible );
                return result;
            }
        }

        private C2iExpression m_formuleElementCible = null;
        private int m_nIdTypeTableParametrable = -1;
        private List<CMappageColonne> m_listeMappages = new List<CMappageColonne>();
        private C2iExpression m_formuleRow = null;
        private bool m_bIgnorerLesValeursVides = true;

		/// /////////////////////////////////////////
		public CActionImportFromTableRow( CProcess process )
			:base(process)
		{
			Libelle = I.T("Import table row|20232");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Import a table row|20232"),
				I.T( "Import a custom table row into an object|20233"),
				typeof(CActionImportFromTableRow),
				CGestionnaireActionsDisponibles.c_categorieDonnees );
		}


		

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return true; }
        }


        /// ////////////////////////////////////////////////////////
        public C2iExpression FormuleRow
        {
            get
            {
                return m_formuleRow;
            }
            set
            {
                m_formuleRow = value;
            }
        }


        
        /// ////////////////////////////////////////////////////////
		public C2iExpression FormuleElementCible
		{ 
			get
			{
                return m_formuleElementCible;
			}
			set
			{
                m_formuleElementCible = value;
			}
		}

        /// ////////////////////////////////////////////////////////
        public int IdTypeTable
        {
            get
            {
                return m_nIdTypeTableParametrable;
            }
            set
            {
                m_nIdTypeTableParametrable = value;
            }
        }

        /// ////////////////////////////////////////////////////////
        public bool IgnorerValeursVide
        {
            get
            {
                return m_bIgnorerLesValeursVides;
            }
            set
            {
                m_bIgnorerLesValeursVides = value;
            }
        }

        /// /////////////////////////////////////////
        public IEnumerable<CMappageColonne> Mappages
        {
            get
            {
                return m_listeMappages.AsReadOnly();
            }
            set
            {
                if (value != null)
                {
                    m_listeMappages.Clear();
                    foreach (CMappageColonne map in value)
                        m_listeMappages.Add(map);
                }
                else
                    m_listeMappages.Clear();
            }
        }

        /// /////////////////////////////////////////
        private int GetNumVersion()
        {
            return 0;
        }
		
		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base.MySerialize( serializer );

            serializer.TraiteInt(ref m_nIdTypeTableParametrable);
            serializer.TraiteBool(ref m_bIgnorerLesValeursVides);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleElementCible);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleRow);
            if (result)
                result = serializer.TraiteListe<CMappageColonne>(m_listeMappages);
			return result;
		}

		
		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();
            if (m_formuleElementCible == null)
            {
                result.EmpileErreur("Target element formula should not be empty|20234");
            }
            if (m_nIdTypeTableParametrable == -1)
                result.EmpileErreur("Select a custom table type|20235");
            if (m_formuleRow == null || m_formuleRow.TypeDonnee.TypeDotNetNatif != typeof(CLigneTableParametrable))
                result.EmpileErreur(I.T("Table row formula is invalid|20237"));
			return result;
		}

		/// ////////////////////////////////////////////////////////
        protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(Process);

            object elementCible = null;
            if (FormuleElementCible != null)
            {
                result = FormuleElementCible.Eval(ctxEval);
                if (result)
                    elementCible = result.Data;
            }
            if (elementCible == null)
            {
                result.EmpileErreur(I.T("Error in target element formula|20236"));
                return result;
            }
            else if (elementCible is CObjetDonnee)
            {
                elementCible = ((CObjetDonnee)elementCible).GetObjetInContexte(contexte.ContexteDonnee);
            }

            CLigneTableParametrable ligne = null;
            if (FormuleRow != null) 
            {
                result = FormuleRow.Eval(ctxEval);
                if (result)
                    ligne = result.Data as CLigneTableParametrable;
            }
            if (ligne == null)
            {
                result.EmpileErreur(I.T("Error in table row formula|20238"));
                return result;
            }

            //Identifie les colonnes à importer
            Dictionary<string, CDefinitionProprieteDynamique> dicMap = new Dictionary<string, CDefinitionProprieteDynamique>();
            foreach (CMappageColonne mappage in Mappages)
            {
                if (mappage.ProprieteCible != null)
                {
                    bool bPrendre = true;
                    CColonneTableParametrable col = new CColonneTableParametrable(contexte.ContexteDonnee);
                    if (col.ReadIfExists(mappage.IdColonne))
                    {
                        if (mappage.FormuleCondition != null)
                        {
                            result = mappage.FormuleCondition.Eval(ctxEval);
                            if (!result || result.Data == null)
                                bPrendre = false;
                            else
                            {
                                bool? bTmp = CUtilBool.BoolFromString(result.Data.ToString());
                                if (bTmp != null)
                                    bPrendre = bTmp.Value;
                                else
                                    bPrendre = false;
                            }
                        }
                        if (bPrendre)
                        {
                            object val = ligne.GetValue(col.Libelle);
                            if (val != null || !m_bIgnorerLesValeursVides)
                                try
                                {
                                    CInterpreteurProprieteDynamique.SetValue(elementCible, mappage.ProprieteCible, ligne.GetValue(col.Libelle));
                                }
                                catch
                                {
                                }
                        }
                    }
                }
            }
            return result;
        }

		//-----------------------------------------------
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
            AddIdVariablesExpressionToHashtable(FormuleElementCible, table);
            foreach (CMappageColonne mappage in m_listeMappages)
                AddIdVariablesExpressionToHashtable(mappage.FormuleCondition, table);
		}
	}
}
