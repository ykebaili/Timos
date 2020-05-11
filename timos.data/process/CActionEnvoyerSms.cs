using System;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
using timos.acteurs;
using sc2i.documents;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.workflow;

namespace timos.process
{
	

	
	/// <summary>
	/// Description résumée de CActionEnvoyerSMS.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionEnvoyerSMS : CActionLienSortantSimple
	{
		private C2iExpression m_formuleMessage = null;
        private ArrayList m_listeFormulesDestinataires = new ArrayList();

		/// /////////////////////////////////////////////////////////
		public CActionEnvoyerSMS( CProcess process)
			:base(process)
		{
			Libelle = I.T("Send a SMS|20107");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Send a SMS|20107"),
				I.T( "This action sends a SMS|20108"),
				typeof(CActionEnvoyerSMS),
				CGestionnaireActionsDisponibles.c_categorieInterface );
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return true; }
		}

		/// ////////////////////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable ( Hashtable table )
		{
			AddIdVariablesExpressionToHashtable ( m_formuleMessage, table );
			foreach ( C2iExpression exp in m_listeFormulesDestinataires )
				AddIdVariablesExpressionToHashtable ( exp, table );

		}

		

		//--------------------------------------------------------------------
		public C2iExpression FormuleMessage
		{
			get
			{
				return m_formuleMessage;
			}
			set
			{
				m_formuleMessage = value;
			}
		}

		//--------------------------------------------------------------------
		public ArrayList ListeFormulesDestinataires
		{
			get
			{
				return m_listeFormulesDestinataires;
			}
		}

		/// /////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
            //return 0;
            return 1; // Ajout liste formules destinataires CC (en copie) et BCC (en copie cachée)
		}

		/// /////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize(C2iSerializer serializer)
		{
			CResultAErreur result = CResultAErreur.True;
			int nVersion = GetNumVersion();
			result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base .MySerialize(serializer);
			if ( !result )
				return result;


            I2iSerializable objet = m_formuleMessage;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_formuleMessage = (C2iExpression)objet;

			result = serializer.TraiteArrayListOf2iSerializable ( m_listeFormulesDestinataires );
			if ( !result )
				return result;

            return result;
		}

		/// /////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();
			
			
			
			if ( m_formuleMessage == null )
				result.EmpileErreur(I.T("The message formula is false|393"));
			else if ( !m_formuleMessage.TypeDonnee.Equals ( new CTypeResultatExpression(typeof(string), false ) ) )
				result.EmpileErreur(I.T("The message formula must return a text|394"));

            // Vérifie qu'il y ai au moins un destinataire
            if ( m_listeFormulesDestinataires.Count == 0 )
				result.EmpileErreur(I.T("No recipient|395"));

            // Vérifie les formules d'adresses des destinataires To
			int nDest = 0;
			foreach ( C2iExpression exp in m_listeFormulesDestinataires )
			{
				nDest++;
				if ( exp == null )
					result.EmpileErreur(I.T("The recipient @1 formula is incorrect|396",nDest.ToString()));
				else if ( exp.TypeDonnee.TypeDotNetNatif != typeof(string) )
					result.EmpileErreur(I.T("The recipient @1 formula must return a phone number as text, or a list of phone numbers|20109", nDest.ToString()));
			}
            
			return result;
		}


		
		/// /////////////////////////////////////////////////////////
		protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;

			string strMessage = "";
            ArrayList lstDestinataires = new ArrayList();
			CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression ( contexte.Branche.Process);

			if ( m_formuleMessage == null )
			{
				result.EmpileErreur(I.T( "The message formula is false|393"));
				return result;
			}
			result = m_formuleMessage.Eval ( contexteEval );
			if ( !result )
			{
                result.EmpileErreur(I.T("Error during  sms content evaluation|20110"));
				return result;
			}

			strMessage = result.Data.ToString();

            // Traite les destinataires To
			foreach ( C2iExpression exp in m_listeFormulesDestinataires )
			{
				if ( exp != null )
				{
					result = exp.Eval ( contexteEval );
					if ( !result )
					{
						result.EmpileErreur(I.T("Error while evaluating one of the recipients|402"));
						return result;
					}
                    object res = result.Data;
                    if (res is string)
                        res = ((string)res).Split(new char[] { ';', ',' });

					if ( res is IList )
						foreach ( object obj in ((IList)res ) )
						{
                            lstDestinataires.Add ( obj.ToString() );
						}
					else if ( res.ToString().Trim()!= "" )
					{
                        lstDestinataires.Add ( res.ToString() );
					}
				}
			}

            

            // Genere le SMS
            CMessageSMS message = new CMessageSMS(contexte.ContexteDonnee);
            message.CreateNewInCurrentContexte();
            message.Texte = strMessage;
            foreach (string strDest in lstDestinataires)
                message.AddDestinataire(strDest);

			return result;

		}
		

	}
}
