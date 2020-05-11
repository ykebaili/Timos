using System;
using System.Drawing;
using System.Collections;

using sc2i.drawing;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;
using sc2i.multitiers.client;
using sc2i.process;


namespace timos.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionFormulaire : CAction
	{
		public static string c_idServiceClientFormulaire = "ACTION_FORMULAIRE";

		C2iWndFenetre m_formulaire = null;

		bool m_bCanCancel = true;

		private string m_strDescriptif = "";


		/// /////////////////////////////////////////
		public CActionFormulaire( CProcess process )
			:base(process)
		{
			Libelle = I.T("Form|410");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T("Create user Form|411"),
				I.T("Displays a form to the user|412"),
				typeof(CActionFormulaire),
				CGestionnaireActionsDisponibles.c_categorieInterface );
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return true; }
		}

		/// /////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
		}

		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			return 1;
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

			I2iSerializable objet = m_formulaire;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_formulaire = (C2iWndFenetre)objet;

			if(  nVersion > 0 )
			{
				serializer.TraiteBool ( ref m_bCanCancel );
				serializer.TraiteString ( ref m_strDescriptif );
			}
		
			return result;
		}

		/// ////////////////////////////////////////////////////////
		public C2iWndFenetre Formulaire
		{
			get
			{
				if (m_formulaire == null )
				{
					m_formulaire = new C2iWndFenetre();
					m_formulaire.Size = new System.Drawing.Size ( 350, 200 );
				}
				return m_formulaire;
			}
			set
			{
				m_formulaire = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public bool CanCancel
		{
			get
			{
				return m_bCanCancel;
			}
			set
			{
				m_bCanCancel =  value;
			}
		}

		/// /////////////////////////////////////////
		public string Descriptif
		{
			get
			{
				return m_strDescriptif;
			}
			set
			{
				m_strDescriptif = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public byte[] GetDataSerialisationFormulairePourClient()
		{
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream);
            CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
			I2iSerializable ser = m_formulaire;
			serializer.TraiteObject ( ref ser );
            byte[] buffer = stream.GetBuffer();
            writer.Close();
            stream.Close();
            return buffer;
		}

	

		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = CResultAErreur.True;
			return result;
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur ExecuteAction(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			//Si la session qui execute est une session de l'utilisateur associé à la branche,
			//Tente d'afficher le formulaire sur cette session,
			//Sinon, enregistre une Intervention sur l'utilisateur
			CSessionClient sessionClient = CSessionClient.GetSessionForIdSession ( contexte.IdSession );
			if ( sessionClient != null )
			{
                //TESTDBKEYOK
				if ( sessionClient.GetInfoUtilisateur().KeyUtilisateur == contexte.Branche.KeyUtilisateur )
				{
					using (C2iSponsor sponsor = new C2iSponsor())
					{
                        sponsor.Label = "Execute Action serveur";
						CServiceSurClient service = sessionClient.GetServiceSurClient(c_idServiceClientFormulaire);
						if (service != null)
						{
							sponsor.Register(service);
							result = service.RunService(this);
							if (!result)
								return result;
							E2iDialogResult dResult = (E2iDialogResult)result.Data;
							foreach (CLienAction lien in GetLiensSortantHorsErreur())
							{
								if (lien is CLienFromDialog &&
									((CLienFromDialog)lien).ResultAssocie == dResult)
								{
									result.Data = lien;
									return result;
								}
							}
							result.Data = null;
							return result;
						}
                        else
                        {
                            //Utilisateur pas accessible
                            foreach (CLienAction lien in GetLiensSortantHorsErreur())
                            {
                                if (lien is CLienUtilisateurAbsent)
                                {
                                    result.Data = lien;
                                    return result;
                                }
                            }
                        }
					}
				}
			}
			//Utilisateur pas accessible
			foreach ( CLienAction lien in GetLiensSortantHorsErreur() )
			{
				if ( lien is CLienUtilisateurAbsent )
				{
					result.Data = lien;
					return result;
				}
			}
			return result;
		}

		/// ///////////////////////////////////////////////
		protected override void MyDraw(CContextDessinObjetGraphique ctx)
		{
			base.MyDraw(ctx);
		}

		/// /////////////////////////////////////////////////////////
		protected override CLienAction[] GetMyLiensSortantsPossibles()
		{
			CLienAction[] listeLiens = GetLiensSortantHorsErreur();
			bool bHasOk = false;
			bool bHasCancel = false;
			bool bHasLienUtilisateurAbsent = false;
			foreach ( CLienAction lien in listeLiens )
			{
				if ( lien is CLienFromDialog )
				{
					CLienFromDialog lienDialog = (CLienFromDialog)lien;
					bHasOk |= lienDialog.ResultAssocie == E2iDialogResult.OK;
					bHasCancel |= lienDialog.ResultAssocie == E2iDialogResult.Cancel;
				}
				if ( lien is CLienUtilisateurAbsent )
					bHasLienUtilisateurAbsent = true;
			}

			ArrayList lst = new ArrayList();
			if ( !bHasOk )
				lst.Add ( new CLienFromDialog ( Process, E2iDialogResult.OK ));
			if ( !bHasCancel && m_bCanCancel )
				lst.Add ( new CLienFromDialog ( Process, E2iDialogResult.Cancel ));
			if ( !bHasLienUtilisateurAbsent )
				lst.Add ( new CLienUtilisateurAbsent ( Process ) );

			return ( CLienAction[] )lst.ToArray(typeof(CLienAction));
		}




	}
}
