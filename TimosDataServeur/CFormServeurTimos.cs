using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using sc2i.common;
using sc2i.win32.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.expression;

using timos.serveur;
using timos.data;
using timos.acteurs;
using sc2i.data.dynamic;
using sc2i.common.recherche;
using System.Reflection;
using timos.data.projet.gantt;
using sc2i.process;
using sc2i.common.inventaire;
using sc2i.win32.data.dynamic;
using futurocom.snmp.mediation;
using timos.data.snmp.serveur.synchronisation;

namespace TimosDataServeur
{
	public partial class CFormServeurTimos : Form
	{
		private System.Windows.Forms.Timer m_bigben;
		private CTimosServeur m_srv;

		public CFormServeurTimos()
		{
			InitializeComponent();
		}
		private void CFormServeurTimos_Load(object sender, EventArgs e)
		{
			//Detection type connection
			if (CTimosServeurRegistre.TypeConnection == typeof(CSqlDatabaseConnexionSynchronisable))
				m_rbtnSQLServeur.Checked = true;
			else if (CTimosServeurRegistre.TypeConnection == typeof(COracleDatabaseConnexionSynchronisable))
				m_rbtnOracle.Checked = true;
			else
			{
				CFormAlerte.Afficher(I.T("The connection type could not be determined : the register reference is missing|30008"), EFormAlerteType.Erreur);
				Close();
			}

			try
			{
				DateTime lastDate = CTimosDataServeurRegistre.LastDateChamps;
                DateTime dtRel = File.GetLastWriteTime("T:\\Futurocom\\timos\\timos.serveur\\CMAJ_StructureBase.cs");
				if (dtRel > lastDate)
				{
					m_chkMAJ.Checked = true;
					CTimosDataServeurRegistre.LastDateChamps = dtRel.AddSeconds(1);
				}
			}
			catch
			{
			}



			//Initialisation du compteur
			cpt = 3;
			m_bigben = new System.Windows.Forms.Timer();
			m_bigben.Tick += new EventHandler(bigben_Tick);
			m_bigben.Interval = 1000;
			m_bigben.Start();
			m_btnLancementServeur.Text = I.T("Start (3s..)|30009");

			//Preparation de l'interface
			//Text = "Bienvenue dans l'univers magique de Timos Serveur";
			Control.CheckForIllegalCrossThreadCalls = false;
			Size = new Size(m_panProgress.Width, m_panProgress.Height);



		}

		int cpt;
		void bigben_Tick(object sender, EventArgs e)
		{
			cpt--;
			m_btnLancementServeur.Text = I.T("Start (@1s...)|30010",cpt.ToString());
            if (cpt == 0)
            {
                Go();
                m_bigben.Stop();
            }

		}

		private void m_btnLancementServeur_Click(object sender, EventArgs e)
		{
			m_bigben.Stop();
			Go();
		}
		private void Go()
		{
			CResultAErreur result = CResultAErreur.True;
			m_panChoixBase.Visible = false;
			m_panProgress.Visible = true;

			if (m_rbtnOracle.Checked)
			{
				CTimosServeurRegistre.TypeConnection = typeof(COracleDatabaseConnexionSynchronisable);
				//CTimosServeurRegistre.DatabaseConnexionString = @"Data Source=DBTIMOS;Password=MDPPRO;User ID=SMTPRO;Unicode=True;Persist Security Info=True";
				CTimosServeurRegistre.DatabaseConnexionString = CTimosDataServeurRegistre.ConnexionOracle;
				Text = I.T("Oracle Database Connection Initialisation : Please wait...|30011");
			}
			else if (m_rbtnSQLServeur.Checked)
			{
				CTimosServeurRegistre.TypeConnection = typeof(CSqlDatabaseConnexionSynchronisable);
				//CTimosServeurRegistre.DatabaseConnexionString = "Data Source=127.0.0.1\\SQLEXPRESS;Initial Catalog=DB_TIMOS;Integrated Security=True;Pooling=False";
				CTimosServeurRegistre.DatabaseConnexionString = CTimosDataServeurRegistre.ConnexionSql;
                Text = I.T("SQL Server Database Connection Initialisation : Please wait...|30012");
			}
			else
			{
				CFormAlerte.Afficher(I.T("Impossible to initialise the server : unknown connection type |30013"), EFormAlerteType.Erreur);
				return;
			}

            CTimosServeur.ArretServeur += new EventHandler(CTimosServeur_ArretServeur);
			m_srv = CTimosServeur.GetInstance();
			m_srv.MAJDerniereVersionBase = m_chkMAJ.Checked;

			Thread.Sleep(0);
			Thread threadInitialisation = new Thread(new ThreadStart(Initialiser));
			threadInitialisation.Name = I.T("TIMOS Database initialisation|30014");
			threadInitialisation.SetApartmentState(ApartmentState.STA);


			threadInitialisation.Start();
			//threadInitialisation.Join(); 
		}

        void CTimosServeur_ArretServeur(object sender, EventArgs e)
        {
            Close();
        }
		private void Initialiser()
		{ 
			int nSavHauteur = Height;
			CResultAErreur resultInitialisation = m_srv.InitServeur("timos.remoting.config", m_ctrlProgressBarHome);
			if (!resultInitialisation)
			{
				//Clipboard.SetData(DataFormats.Text, resultInitialisation.Erreur.ToString());
				resultInitialisation.EmpileErreur(I.T("Initialisation error|30015"));
				CFormAlerte.Afficher(resultInitialisation.Erreur.ToString(), EFormAlerteType.Erreur);
				Close();
			}

            //CChercheurDeTypesQuiUtilisentUnType chercheur = new CChercheurDeTypesQuiUtilisentUnType(typeof(C2iExpressionChamp));
            //bool bTest = chercheur.IsDansLaListe(typeof(CParametrageGantt));

            //bTest = chercheur.IsDansLaListe(typeof(CProcessInDb));

            //bTest = chercheur.IsDansLaListe(typeof(CCivilite));

            //CFournisseurInventaireObjetGenerique<C2iExpression> fournisseur = new CFournisseurInventaireObjetGenerique<C2iExpression>();
            //CInventaire inventaire = new CInventaire();
            //fournisseur.FillInventaireNonRecursif(timos.data.projet.gantt.CParametreDessinLigneGantt.ParametreParDefaut.ParametreBarre, inventaire);

            //List<object> listeInventoriee = new List<object>(inventaire.GetObjects());
            //List<object> listeAInventorier = new List<object>(inventaire.GetObjectsAInventorier());

         
			m_panProgress.Visible = false;
			m_panEnd.Visible = true;
			WindowState = FormWindowState.Minimized;
			Height = nSavHauteur;
			

		}



		private void m_btnLog_Click(object sender, EventArgs e)
		{

		}
		private void m_btnCopierBase_Click(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.ToString(), EFormAlerteType.Erreur);
			}
			/*string strBase = "";
			string strUser = "";
			string strPassword = "";

			if (CFormSelectBDD.SelectBDD(ref strBase, ref strUser, ref strPassword))
			{
				CSessionClient session = CSessionClient.CreateInstance ();
				CResultAErreur result = session.OpenSession ( new CAuthentificationSessionSousSession ( 0 ), "Duplication de base", TypeApplicationCliente.Service );
				if ( !result )
				{
					MessageBox.Show ( result.Erreur.ToString() );
					return;
				}
				IDatabaseConnexion connexionSource = CSc2iDataServer.GetInstance().GetDatabaseConnexion ( session.IdSession, typeof(timos.data.serveur.CContrainteServeur) );
				string strIdTmp = "DUPLICATION";
				CSc2iDataServer.AddDefinitionConnexion ( new CDefinitionConnexionDataSource ( 
					strIdTmp, 
					typeof(COracleDatabaseConnexion),
					"Data Source=" + strBase + ";Password=" + strPassword+ ";User ID=" + strUser+ ";Unicode=True;Persist Security Info=True"));
				IDatabaseConnexion connexionDest = CSc2iDataServer.GetInstance().GetDatabaseConnexion ( session.IdSession, strIdTmp );
				m_panProgress.Visible = true;
				m_panEnd.Visible = false;
				//m_ctrlProgressBar.Maximum = CContexteDonnee.GetAllTypes().Length;
				//m_ctrlProgressBar.Minimum = 0;
				List<string> listeTables = new List<string>();
				foreach (Type tp in CContexteDonnee.GetAllTypes())
					listeTables.Add(CContexteDonnee.GetNomTableForType(tp));
				try
				{
					//désactive toutes les contraintes de la base dest
					//m_lblEnCour.Text = "Désactivation des contraintes";
					Refresh();
					connexionDest.DesactiverContraintes ( true );
					//m_lblEnCour.Text = "Désactivation des ids auto";
					Refresh();
					//Désactive les ids auto
					foreach ( string strTable in listeTables )
						connexionDest.DesactiverIdAuto ( strTable, true );
					connexionDest.BeginTrans();
					//m_ctrlProgressBar.Value = 0;
					foreach (Type tp in CContexteDonnee.GetAllTypes())
					{
						//m_ctrlProgressBar.PerformStep();
						string strTable = CContexteDonnee.GetNomTableForType ( tp );
						using ( CContexteDonnee contexte = new CContexteDonnee ( session.IdSession, true, false ) )
						{
							//m_lblEnCour.Text = "Copie de " + strTable;
							Refresh();
							contexte.EnableTraitementsAvantSauvegarde = false;
							if ( CSc2iDataServer.GetInstance().GetDatabaseConnexion ( session.IdSession, contexte.GetTableLoader ( strTable ).GetType()) == connexionSource )
							{
								//Supprime toutes les données dest
								result = connexionDest.RunStatement ( "delete from "+strTable );
								if (!result)
									break;
								if (result)
								{
									CListeObjetsDonnees liste = new CListeObjetsDonnees(contexte, tp);
									liste.AssureLectureFaite();
									DataTable table = contexte.Tables[strTable];
									if (table.PrimaryKey.Length > 0)
									{
										//S'assure que les blobs sont lus
										foreach (DataColumn col in table.Columns)
										{
											if (col.DataType == typeof(CDonneeBinaireInRow))
											{
												foreach (DataRow row in table.Rows)
												{
													CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(session.IdSession, row, col.ColumnName);
													byte[] data = donnee.Donnees;
												}
											}
										}
										foreach (DataRow row in table.Rows)
											row.SetAdded();
										//Change la connexion active
										try
										{
											CSc2iDataServer.SetIdConnexionForClasse(contexte.GetTableLoader ( strTable ).GetType(), strIdTmp);
											result = contexte.SaveAll(true);
										}
										catch (Exception ex)
										{
											result.EmpileErreur("Erreur table " + strTable);
											result.EmpileErreur(new CErreurException(ex));
										}
										finally
										{
											CSc2iDataServer.SetIdConnexionForClasse(contexte.GetTableLoader(strTable).GetType(), CSc2iDataServer.IdConnexionParDefaut);
											if (!result)
												throw new Exception(result.Erreur.ToString());
										}
									}
								}
							}
						}
					}
				}
				catch ( Exception ex )
				{
					result.EmpileErreur ( new CErreurException ( ex ) );
				}
				finally
				{
					if (!result)
					{
						connexionDest.RollbackTrans();
					}
					else
					{
						result = connexionDest.CommitTrans();
						if (result)
						{
							//Suppression de toutes les sequences
							result = connexionDest.RunStatement("Delete * from SYS.USER_SEQUENCES");
							if (result)
							{
								//Recrée toutes les séquences
								DataSet dsSequences = new DataSet();
								IDataAdapter adapter = connexionSource.GetSimpleReadAdapter("select * from SYS.USER_SEQUENCES");
								adapter.Fill(dsSequences);
								foreach (DataRow row in dsSequences.Tables[0].Rows)
								{
									string strSequence = (string)row["SEQUENCE_NAME"];
									result = connexionSource.ExecuteScalar("select " + strSequence + ".NEXTVAL from DUAL");
									if (result)
									{
										string strRequete = "Create SEQUENCE " + strSequence + " " +
											"INCREMENT BY 1 START WITH " + result.Data.ToString();
										result = connexionDest.RunStatement(strRequete);
									}
									if (!result)
										break;
								}
							}
						}
					}
					//m_lblEnCour.Text = "Réactivation des contraintes";
					Refresh();
					connexionDest.DesactiverContraintes ( false );
					//m_lblEnCour.Text= "Réactivation des ids auto";
					Refresh();
					//Réactive les contraintes
					foreach ( string strTable in listeTables )
						connexionDest.DesactiverIdAuto ( strTable, false );
				}
				m_panEnd.Visible = true;
				m_panProgress.Visible = false;
				if ( !result )
					MessageBox.Show ( result.Erreur.ToString() );
				else
					MessageBox.Show ( "Copie terminée" );
			}*/
		}


		private void ctrl_progressBarHome_SizeChanged(object sender, EventArgs e)
		{
			if (m_ctrlProgressBarHome.Size.Height != 0 && m_ctrlProgressBarHome.ProgressionEnCour)
				Height = m_ctrlProgressBarHome.Size.Height + 15;
		}

		

		private void Rien(CActeur acteur)
		{
			CFormAlerte.Afficher(acteur.Nom);
		}

		private void DisplayActeur(CActeur acteur, params int[] nIdsVersions)
		{
			int? nOldVersion = acteur.ContexteDonnee.IdVersionDeTravail;
			List<string> lstLabels = new List<string>();
			acteur.ContexteDonnee.SetVersionDeTravail(null, false);
			lstLabels.Add(acteur.Nom+" / "+acteur.Adresse);
			foreach (int nVersion in nIdsVersions)
			{
				acteur.ContexteDonnee.SetVersionDeTravail(nVersion, false);
				lstLabels.Add(acteur.Nom + " / " + acteur.Adresse);
			}
			StringBuilder bl = new StringBuilder();
			int nVer = 0;
			foreach (string strLib in lstLabels)
			{
				if (nVer == 0)
					bl.Append("Ref : ");
				else
				{
					bl.Append(nVer.ToString());
					bl.Append(" : ");
				}
				bl.Append(strLib);
				bl.Append("\r\n");
				nVer++;
			}
			CFormAlerte.Afficher(bl.ToString());
			acteur.ContexteDonnee.SetVersionDeTravail(nOldVersion, false);
		}
			


		private void DisplayListe(string strLib, CListeObjetsDonnees liste)
		{
			StringBuilder bl = new StringBuilder();
			bl.Append(strLib + "\r\n\r\n");
			foreach (CObjetDonnee objet in liste)
			{
				bl.Append(objet.DescriptionElement);
				bl.Append("\r\n");
			}
			CFormAlerte.Afficher(bl.ToString());
		}

        private void m_lnkServiceMediation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormVisualisationDataSet.AfficheDonnees(CServiceMediation.GetDefaultInstance().Configuration.DataBase);
        }

        private void m_btnProxySync_Click(object sender, EventArgs e)
        {
            CSynchroniseurBaseProxy synchroniseur = new CSynchroniseurBaseProxy();
            synchroniseur.GetUpdatesForProxy(2, -1);
        }
	}
}