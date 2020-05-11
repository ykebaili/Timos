using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using sc2i.data;
using sc2i.common;
using timos.data;
using timos.client;
using timos.acteurs;
using System.Data;
using sc2i.data.dynamic;

namespace timos.test.metier
{
	/*
	 * Le test se base sur 3 version : 
	 * V1 : sur le référentiel
	 * V2 : sur le référentiel
	 * V3 : sur V1
	 * */
	[TestFixture]
	public class CTestDeBaseVersionning	
	{
		private CContexteDonnee m_contexteDonnee;
		private int[] m_nIdsVersions = new int[3];
		private int m_nIdActeur = -1;
		private int m_nIdActeurV1 = -1;

		private string GetLibelleVersion ( int nVersion )
		{
			return "VERSION TEST NUNIT "+(nVersion+1).ToString();
		}

		private class CV
		{
			public readonly string Champ;
			public readonly object Valeur;
			public CV ( string strChamp, object valeur )
			{
				Champ = strChamp;
				Valeur = valeur;
			}
		}

		/// <summary>
		/// Permet de modifier facilement un élément
		/// </summary>
		private class M
		{
			private int? m_nIdVersion;
			private CV[] m_valeurs;

			public M( int? nIdVersion, params CV[] champsEtValeurs )
			{
				m_nIdVersion = nIdVersion;
				m_valeurs = champsEtValeurs;
			}

			public void ModifieActeur ( CActeur acteur )
			{
				acteur.ContexteDonnee.SetVersionDeTravail ( m_nIdVersion, false );
				acteur.BeginEdit();
				Assert.AreEqual(acteur.ContexteDonnee.IdVersionDeTravail, m_nIdVersion);
				foreach ( CV valeur in m_valeurs )
				{
					acteur.Row[valeur.Champ] = valeur.Valeur;
				}
				Assert.IsTrue ( acteur.CommitEdit() );
			}
		}
				

		
		[SetUp]
		public void Init()
		{
			CResultAErreur result = CResultAErreur.True;
			CTimosTestMetierApp.AssureInit();
			m_contexteDonnee = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false);
			using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
			{
				CVersionDonnees version1 = null;
				for (int nVersion = 0; nVersion < m_nIdsVersions.Length; nVersion++)
				{
					CVersionDonnees version = new CVersionDonnees(contexte);
					if (version.ReadIfExists(new CFiltreData(CVersionDonnees.c_champLibelle + "=@1 and " +
						CVersionDonnees.c_champTypeVersion + "=@2",
						GetLibelleVersion(nVersion),
						(int)CTypeVersion.TypeVersion.Previsionnelle)))
					{
						m_nIdsVersions[nVersion] = version.Id;
					}
					else
					{
						version.CreateNew();
						version.Libelle = GetLibelleVersion(nVersion);
						version.CodeTypeVersion = (int)CTypeVersion.TypeVersion.Previsionnelle;
						version.Date = DateTime.Now;
						if (nVersion == 2)
							version.VersionParente = version1;
						result = version.CommitEdit();
						if (!result)
							throw new CExceptionErreur(result.Erreur);
						m_nIdsVersions[nVersion] = version.Id;
					}
					if (nVersion == 0)
						version1 = version;
				}


			}
			//Création de l'acteur de test
			CActeur acteur = new CActeur ( m_contexteDonnee );
			if ( !acteur.ReadIfExists ( new CFiltreData ( CActeur.c_champPrenom+"=@1",
				"NUNIT ACTEUR" ) ))
			{
				acteur.CreateNew();
				acteur.Nom = "NUnit acteur";
					acteur.Prenom = "NUNIT ACTEUR";
				result = acteur.CommitEdit();
				Assert.IsTrue ( result.Result );
			}
			m_nIdActeur = acteur.Id;


			//Remet le jeu de test à 0
			ResetModifs();


		}

		//----------------------------------
		private CActeur ActeurReferentiel
		{
			get
			{
				CActeur acteur = new CActeur ( m_contexteDonnee );
				if ( !acteur.ReadIfExists ( m_nIdActeur ) )
					throw new Exception("Acteur de test inexistant");
				return acteur;
			}
		}

		//----------------------------------
		private void ResetModifs()
		{
			using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
			{
				for (int nVersion = 0; nVersion < m_nIdsVersions.Length; nVersion++)
				{
					CVersionDonnees version = new CVersionDonnees(contexte);
					version.ReadIfExists(m_nIdsVersions[nVersion]);
					foreach (CVersionDonneesObjet dataObjet in version.VersionsObjets)
						Assert.IsTrue(dataObjet.AnnuleModificationsPrevisionnelles().Result);
				}
			}
		}

		//----------------------------------
		private string[] GetValeursActeurParVersion(string strChamp)
		{
			return GetValeursActeurParVersion ( ActeurReferentiel, strChamp );
		}

		//----------------------------------
		private string[] GetValeursActeurParVersion(CActeur acteur, string strChamp)
		{
			int nId = acteur.Id;
			List<string> strLibs = new List<string>();
			int? nOldVersion = m_contexteDonnee.IdVersionDeTravail;
			m_contexteDonnee.SetVersionDeTravail(null, false);
			DataRow row = acteur.Row.Row;
			acteur.Nom = "Test";
			row.Table.RowChanging += new DataRowChangeEventHandler(Table_RowChanging);
			row[CActeur.c_champNom] = "TEST 2";
			row[CContexteDonnee.c_colIsToRead] = true;
			
			m_contexteDonnee.SetIsToRead(row, true);
			if (! acteur.IsValide() )
				strLibs.Add(null);
			else
				strLibs.Add((string)acteur.Row[strChamp]);
			for (int nVersion = 0; nVersion < m_nIdsVersions.Length; nVersion++)
			{
				m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[nVersion], false);
				if (acteur.IsValide())
					strLibs.Add((string)acteur.Row[strChamp]);
				else
					strLibs.Add(null);
			}
			m_contexteDonnee.SetVersionDeTravail(nOldVersion, false);
			return strLibs.ToArray();
		}

		void Table_RowChanging(object sender, DataRowChangeEventArgs e)
		{
		}

		


		//----------------------------------
		private void SetSituation ( params M[] modifications )
		{
			SetSituation ( ActeurReferentiel, modifications );
		}

		//----------------------------------
		private void SetSituation ( CActeur acteur, params M[] modifications )
		{
			foreach ( M modif in modifications )
				modif.ModifieActeur ( acteur );
		}

		//----------------------------------
		/// <summary>
		/// Situation de base : aucune modif dans les version
		/// Action : Modification du référentiel
		/// Résultat attendu : Toutes les versions doivent retourner la même donnée
		/// </summary>
		[Test]
		public void ModifActeurReferentielSansModifDeVersion()
		{
			ResetModifs();
			CActeur acteur = ActeurReferentiel;
			string strNom = "Nom test "+DateTime.Now.ToString("G");

			new M(null, new CV(CActeur.c_champNom, strNom)).ModifieActeur ( acteur );
			
			string[] strLibs = GetValeursActeurParVersion ( CActeur.c_champNom );
			
			//Ref = "Nom dans référentiel ?
			Assert.AreEqual ( strLibs[0], strNom);
			
			//V1 = ref ?
			Assert.AreEqual ( strLibs[0], strLibs[1] );

			//V2 = ref ?
			Assert.AreEqual ( strLibs[0], strLibs[2] );

			//V3 = ref ?
			Assert.AreEqual ( strLibs[0], strLibs[3] );
		}

		//----------------------------------
		/// <summary>
		/// /// <summary>
		/// Situation de base : aucune modif dans les version
		/// Action : Modification du nom en V1
		/// Résultat attendu : 
		///		Ref et V2 doivent retourner la même valeur (celle du référentiel)
		///		V1 et V3 doivent retourner la valeur de V1
		/// </summary>
		/// </summary>
		[Test]
		public void ModifNomDansV1()
		{
			ResetModifs();
			CActeur acteur = ActeurReferentiel;
			DataRow row = acteur.Row.Row;

			string strNomRef = "Nom ref";
			string strNomV1 = "Acteur V1";

			SetSituation ( 
				new M ( null, new CV(CActeur.c_champNom, strNomRef) ),
				new M ( m_nIdsVersions[0], new CV ( CActeur.c_champNom, strNomV1 ))
				);

			string[] strLibs = GetValeursActeurParVersion(acteur, CActeur.c_champNom);

			//Ref = valeur d'origine
			Assert.AreEqual(strLibs[0], strNomRef);

			//V1 = valeur "Acteur V1"
			Assert.AreEqual(strLibs[1], strNomV1);

			//V2 = valeur du référentiel
			Assert.AreEqual(strLibs[2], strNomRef);

			//V3 = valeur de V1
			Assert.AreEqual(strLibs[3], strNomV1);
		}

		/// <summary>
		/// Modifie le nom dans V1
		/// Modifie l'adresse dans ref
		/// Le nom de V1 doit être conservé, mais l'adresse de V1 doit être
		/// celle du référentiel
		/// </summary>
		[Test]
		public void ModifNomDansV1EtAdresseDansReferentiel()
		{
			ResetModifs();

			string strNomRef = "Nom ref";
			string strNomV1 = "Nom V1";
			string strAdresseRef = "ADR REF";
			SetSituation(
				new M(null, new CV(CActeur.c_champNom, strNomRef ), new CV(CActeur.c_champAdresse,"") ),
				new M(m_nIdsVersions[0], new CV(CActeur.c_champNom, strNomV1)),
				new M(null, new CV(CActeur.c_champAdresse, strAdresseRef)));

			string[] strNoms = GetValeursActeurParVersion(CActeur.c_champNom);
			string[] strAdresses = GetValeursActeurParVersion(CActeur.c_champAdresse);

			//Le nom ne doit pas bouger en ref et V2, il doit être strNomV1 pour V1
			Assert.AreEqual(strNoms[0], strNomRef);
			Assert.AreEqual(strNoms[2], strNomRef);
			Assert.AreEqual(strNoms[1], strNomV1);
			Assert.AreEqual(strNoms[3], strNomV1);

			//Les adresse doivent toutes être les mêmes
			Assert.AreEqual(strAdresses[0], strAdresseRef);
			Assert.AreEqual(strAdresses[1], strAdresseRef);
			Assert.AreEqual(strAdresses[2], strAdresseRef);
			Assert.AreEqual(strAdresses[3], strAdresseRef);

			//Modifie maintenant l'adresse dans V3 et la remodifie dans referentiel
			string strAdrV3 = "ADR V3";
			string strAdrRefNew = "ADR REF (2)";
			SetSituation(
				new M(m_nIdsVersions[2], new CV(CActeur.c_champAdresse, strAdrV3)),
				new M(null, new CV(CActeur.c_champAdresse, strAdrRefNew)));
			strNoms = GetValeursActeurParVersion(CActeur.c_champNom);
			strAdresses = GetValeursActeurParVersion(CActeur.c_champAdresse);
			//Le nom ne doit pas bouger en ref et V2, il doit être strNomV1 pour V1
			Assert.AreEqual(strNoms[0], strNomRef);
			Assert.AreEqual(strNoms[2], strNomRef);
			Assert.AreEqual(strNoms[1], strNomV1);
			Assert.AreEqual(strNoms[3], strNomV1);

			//Les adresse doivent toutes être les mêmes
			Assert.AreEqual(strAdresses[0], strAdrRefNew);
			Assert.AreEqual(strAdresses[1], strAdrRefNew);
			Assert.AreEqual(strAdresses[2], strAdrRefNew);
			Assert.AreEqual(strAdresses[3], strAdrV3);

		}

		/// <summary>
		/// Modifie le nom dans V1
		/// Modifie le nom dans V2
		/// ref : contient le nom std
		/// V1 : contient le nom V1
		/// V2 : contient le nom V2
		/// v3 : contient le nom V1
		/// </summary>
		[Test]
		public void ModifNomDansV1EtDansV2()
		{
			ResetModifs();

			string strNomRef = "Nom ref";
			string strNomV1 = "Nom V1";
			string strNomV2 = "Nom V2";
			SetSituation(
				new M(null, new CV(CActeur.c_champNom, strNomRef)),
				new M(m_nIdsVersions[0], new CV(CActeur.c_champNom, strNomV1)),
				new M(m_nIdsVersions[1], new CV(CActeur.c_champNom, strNomV2)));

			string[] strNoms = GetValeursActeurParVersion(CActeur.c_champNom);

			//Le nom ne doit pas bouger en ref et V2, il doit être strNomV1 pour V1
			Assert.AreEqual(strNoms[0], strNomRef);
			Assert.AreEqual(strNoms[1], strNomV1);
			Assert.AreEqual(strNoms[2], strNomV2);
			Assert.AreEqual(strNoms[3], strNomV1);

		}

		/// <summary>
		/// Modifie le nom dans V1
		/// Modifie le nom dans V2
		/// Modifie le nom dans V3
		/// Modifie l'adresse dans V3
		/// ref : contient le nom std et l'adresse ref
		/// V1 : contient le nom V1 et l'adresse ref
		/// V2 : contient le nom V2 et l'adresse ref
		/// v3 : contient le nom V3 et l'adresse V3
		/// 
		/// </summary>
		[Test]
		public void ModifNomDansV1etV2etV3EtAdresseV3()
		{
			ResetModifs();

			string strNomRef = "Nom ref";
			string strNomV1 = "Nom V1";
			string strNomV2 = "Nom V2";
			string strNomV3 = "Nom V3";
			string strAdresseRef1 = "Adresse ref 1";
			string strAdresseRef2 = "Adresse ref 2";
			string strAdresseV3 = "Adresse V3";
			SetSituation(
				new M(null, new CV(CActeur.c_champNom, strNomRef), new CV(CActeur.c_champAdresse, strAdresseRef1)),
				new M(m_nIdsVersions[0], new CV(CActeur.c_champNom, strNomV1)),
				new M(m_nIdsVersions[1], new CV(CActeur.c_champNom, strNomV2)),
				new M(m_nIdsVersions[2], new CV(CActeur.c_champNom, strNomV3), new CV(CActeur.c_champAdresse, strAdresseV3)),
				new M(null, new CV ( CActeur.c_champAdresse, strAdresseRef2) ));

			string[] strNoms = GetValeursActeurParVersion(CActeur.c_champNom);
			string[] strAdresses = GetValeursActeurParVersion ( CActeur.c_champAdresse );

			Assert.AreEqual(strNoms[0], strNomRef);
			Assert.AreEqual(strNoms[1], strNomV1);
			Assert.AreEqual(strNoms[2], strNomV2);
			Assert.AreEqual(strNoms[3], strNomV3);

			Assert.AreEqual (strAdresses[0], strAdresseRef2);
			Assert.AreEqual (strAdresses[1], strAdresseRef2);
			Assert.AreEqual (strAdresses[2], strAdresseRef2);
			Assert.AreEqual (strAdresses[3], strAdresseV3);

		}

		private CActeur AssureActeurV1()
		{
			string strPrenomActeur = "PRENOM acteur V1";
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false );
			CActeur acteur = new CActeur ( m_contexteDonnee );
			if ( !acteur.ReadIfExists ( new CFiltreData ( CActeur.c_champPrenom+"=@1",
				strPrenomActeur ) ))
			{
				acteur.CreateNew();
				acteur.Prenom = strPrenomActeur;
				acteur.Nom = "ACTEUR V1";
				Assert.IsTrue ( acteur.CommitEdit().Result );
			}
			m_nIdActeurV1 = acteur.Id;
			return acteur;
		}


		/// <summary>
		/// Crée un acteur dans la V1
		/// On doit retrouver cet acteur en V1 et V3 mais pas en V2 ni référentiel
		/// </summary>
		[Test]
		public void CreateActeurV1()
		{
			ResetModifs();


			CActeur acteur = AssureActeurV1();
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0],false);
			Assert.IsTrue(acteur.IsValide());

			m_contexteDonnee.SetVersionDeTravail(null, false);
			Assert.IsFalse(acteur.IsValide());

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			Assert.IsFalse(acteur.IsValide());

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			Assert.IsTrue(acteur.IsValide());
		}

		

		/// <summary>
		/// Modification de l'acteur créé dans V1.
		/// Les modifs doivent se répercuter dans V3
		/// </summary>
		[Test]
		public void ModifActeurDeV1DansV1()
		{
			ResetModifs();
			CActeur acteur = AssureActeurV1();
			

			string strNom1 = "NOM 1"+DateTime.Now.ToString("g");
			SetSituation(acteur,
				new M(m_nIdsVersions[0], new CV(CActeur.c_champNom, strNom1)));

			
			string[] strLibs = GetValeursActeurParVersion(acteur, CActeur.c_champNom);
			Assert.AreEqual(null, strLibs[0]);
			Assert.AreEqual(null, strLibs[2]);
			Assert.AreEqual(strNom1, strLibs[1]);
			Assert.AreEqual(strNom1, strLibs[3]);

			string strNom2 = "NOM V1 2";
			SetSituation(acteur,
				new M(m_nIdsVersions[0], new CV(CActeur.c_champNom, strNom2)));

			strLibs = GetValeursActeurParVersion(acteur, CActeur.c_champNom);
			Assert.AreEqual(null, strLibs[0]);
			Assert.AreEqual(null, strLibs[2]);
			Assert.AreEqual(strNom2, strLibs[1]);
			Assert.AreEqual(strNom2, strLibs[3]);
		}

		[Test]
		public void SupprimeActeurDansV1()
		{
			ResetModifs();
			CActeur acteur = ActeurReferentiel;
			int nIdActeur = acteur.Id;
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);

			CListeObjetsDonnees listeActeurs = new CListeObjetsDonnees ( m_contexteDonnee, typeof(CActeur));
			listeActeurs.Filtre = new CFiltreData ( CActeur.c_champId+"=@1", nIdActeur );
			Assert.IsTrue(acteur.Delete());

			m_contexteDonnee.SetVersionDeTravail(null, false);
			Assert.IsTrue(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 1, listeActeurs.Count );

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			Assert.IsFalse(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 0, listeActeurs.Count );

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			Assert.IsTrue(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 1, listeActeurs.Count );

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			Assert.IsFalse(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 0, listeActeurs.Count );
		}

		[Test]
		public void ModifDansV1PuisSuppression()
		{
			ResetModifs();
			CActeur	acteur = ActeurReferentiel;
			int nIdActeur = acteur.Id;

			//Crée l'objet dans V1
			SetSituation(new M(m_nIdsVersions[0], new CV(CActeur.c_champNom, "TOTO")),
			new M(m_nIdsVersions[2], new CV(CActeur.c_champNom, "TOTO 2")));

			CListeObjetsDonnees listeActeurs = new CListeObjetsDonnees ( m_contexteDonnee, typeof(CActeur));
			listeActeurs.Filtre = new CFiltreData ( CActeur.c_champId+"=@1", nIdActeur );
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			Assert.IsFalse(acteur.CanDelete());//On ne peut pas car il est utilisé par V3
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			Assert.IsTrue(acteur.Delete());
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			acteur = ActeurReferentiel;
			Assert.IsTrue(acteur.Delete());

			m_contexteDonnee.SetVersionDeTravail(null, false);
			acteur = ActeurReferentiel;
			Assert.IsTrue(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 1, listeActeurs.Count );

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			Assert.IsFalse(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 0, listeActeurs.Count );

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			Assert.IsTrue(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 1, listeActeurs.Count );

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			Assert.IsFalse(acteur.IsValide());
			listeActeurs.Refresh();
			Assert.AreEqual ( 0, listeActeurs.Count );

		}

		[Test]
		public void CreateActeurDansV1EtsuppressionDansV3()
		{
			ResetModifs();
			CActeur acteur = AssureActeurV1();

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			Assert.IsTrue(acteur.IsValide());
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			Assert.IsTrue(acteur.IsValide());
			m_contexteDonnee.SetVersionDeTravail(null, false);
			Assert.IsFalse(acteur.IsValide());
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			Assert.IsFalse(acteur.IsValide());

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			Assert.IsTrue(acteur.Delete().Result);

			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			Assert.IsTrue(acteur.IsValide());
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			Assert.IsFalse(acteur.IsValide());
			m_contexteDonnee.SetVersionDeTravail(null, false);
			Assert.IsFalse(acteur.IsValide());
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			Assert.IsFalse(acteur.IsValide());
		}

		[Test]
		public void TentativeDeSupprimerUnElementUtiliseDansUneVersion()
		{
			ResetModifs();
			CActeur acteur = ActeurReferentiel;

			string strNom = "SUPP "+DateTime.Now.ToString() ;
			SetSituation ( new M ( m_nIdsVersions[0], new CV(CActeur.c_champNom,strNom)));

			m_contexteDonnee.SetVersionDeTravail(null, false);
			Assert.IsFalse ( acteur.CanDelete() );
		}

		private void VerifTable(DataTable table, string[] strNomColonnes, string[][] valeurs)
		{
			for ( int nRow = 0; nRow < valeurs.Length; nRow++ )
			{
				DataRow row = table.Rows[nRow];
				for (int nCol = 0; nCol < valeurs[nRow].Length; nCol++)
					Assert.IsTrue ( row[strNomColonnes[nCol]].Equals(valeurs[nRow][nCol]));
			}
		}

		[Test]
		public void TestVersionsDeTables()
		{
			System.Console.WriteLine("-----------------------------------Test versions de tables----------------------");
			System.Console.WriteLine("Initialisation");
			ResetModifs();

			string strNomTableTest = "TEST_NUNIT";
			string[] strNomsCols = new string[] { "Cle", "Val1", "Val2" };
			//Supprime les tables de test
			m_contexteDonnee.SetVersionDeTravail(-1, false);//Toutes versions
			CListeObjetsDonnees listeTables = new CListeObjetsDonnees(m_contexteDonnee, typeof(CTableParametrable));
			listeTables.Filtre = new CFiltreData(CTableParametrable.c_champLibelle + "=@1",
				strNomTableTest);
			Assert.IsTrue(CObjetDonneeAIdNumerique.Delete(listeTables));

			//Création du type de table
			m_contexteDonnee.SetVersionDeTravail(null, false);
			CTypeTableParametrable typeTable = new CTypeTableParametrable(m_contexteDonnee);
			if (typeTable.ReadIfExists(new CFiltreData(CTypeTableParametrable.c_champLibelle + "=@1",
				strNomTableTest)))
			{
				Assert.IsTrue(CObjetDonneeAIdNumerique.Delete(typeTable.Colonnes));
				typeTable.BeginEdit();
			}
			else
				typeTable.CreateNew();
			typeTable.Libelle = strNomTableTest;
			CColonneTableParametrable col1 = new CColonneTableParametrable(typeTable.ContexteDonnee);
			col1.CreateNewInCurrentContexte();
			col1.Libelle = strNomsCols[0];
			col1.TypeDonneeChamp = new C2iTypeDonnee(TypeDonnee.tString);
			col1.AllowNull = false;
			col1.TypeTable = typeTable;
			col1.PrimaryKeyPosition = 0;
			col1.Position = 0;

			CColonneTableParametrable col2 = new CColonneTableParametrable(typeTable.ContexteDonnee);
			col2.CreateNewInCurrentContexte();
			col2.Libelle = strNomsCols[1];
			col2.TypeDonneeChamp = new C2iTypeDonnee(TypeDonnee.tString);
			col2.TypeTable = typeTable;
			col2.Position = 1;

			CColonneTableParametrable col3 = new CColonneTableParametrable(typeTable.ContexteDonnee);
			col3.CreateNewInCurrentContexte();
			col3.Libelle = strNomsCols[2];
			col3.TypeDonneeChamp = new C2iTypeDonnee(TypeDonnee.tString);
			col3.TypeTable = typeTable;
			col3.Position = 2;

			Assert.IsTrue(typeTable.CommitEdit());

			//Création d'une table dans le référentiel
			CTableParametrable tableP = new CTableParametrable(m_contexteDonnee);
			tableP.CreateNew();
			tableP.Libelle = strNomTableTest;
			tableP.TypeTable = typeTable;
			DataTable table = tableP.DataTableObject;

			/*Table dans le referentiel
			 * KEY	|	Val1	|	Val2	
			 * A1	|	A2		|	A3	
			 * B1	|	B2		|	B3
			 * C1	|	C2		|	C3
			 * D1	|	D2		|	D3
			 * */
			DataRow row = null;
			for ( int nRow = 0; nRow < 4; nRow++ )
			{
				row = table.NewRow();
				string strCleLigne = (new string[]{"A","B","C","D"})[nRow];
				for ( int nCol = 1; nCol < table.Columns.Count; nCol++ )
					if ( table.Columns[nCol].ColumnName != CTableParametrable.c_strColTimeStamp )
						row[nCol] = strCleLigne+(nCol).ToString();
				table.Rows.Add ( row );
			}
			tableP.DataTableObject = table;
			Assert.IsTrue(tableP.CommitEdit());

			//---------------------------------------------------------
			///Modification de la table en V1
			System.Console.Write("Modif dans V1");
			string strA2V1 = "A2 en V1";
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			table = tableP.DataTableObject;
			row = table.Rows[0];
			row[strNomsCols[1]] = strA2V1;
			tableP.BeginEdit();
			tableP.DataTableObject = table;
			Assert.IsTrue ( tableP.CommitEdit());

			//La table n'a pas bougé en version référentiel
			m_contexteDonnee.SetVersionDeTravail(null, false);
			table = tableP.DataTableObject;
			VerifTable ( table, strNomsCols, new string[][]{
			new string[]{"A1","A2","A3"},
			new string[]{"B1","B2","B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table n'a pas bougé en V2
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			table = tableP.DataTableObject;
			VerifTable ( table, strNomsCols, new string[][]{
			new string[]{"A1","A2","A3"},
			new string[]{"B1","B2","B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table a bougé en V1
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V1,"A3"},
			new string[]{"B1","B2","B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table a bougé en V3
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V1,"A3"},
			new string[]{"B1","B2","B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//---------------------------------------------------------
			//Modification de la table dans le référentiel :
			//Modif ligne 1 et ligne 2.
			System.Console.Write("Modif dans Ref");
			m_contexteDonnee.SetVersionDeTravail(null, false);
			table = tableP.DataTableObject;
			 row = table.Rows[0];
			string strA3REF = "A3 ref";
			row[strNomsCols[2]] = strA3REF;
			row = table.Rows[1];
			string strB2REF = "B2 ref";
			row[strNomsCols[1]] = strB2REF;
			tableP.BeginEdit();
			tableP.DataTableObject = table;
			Assert.IsTrue(tableP.CommitEdit());

			//La table n'a pas bougé en version référentiel
			m_contexteDonnee.SetVersionDeTravail(null, false);
			table = tableP.DataTableObject;
			VerifTable ( table, strNomsCols, new string[][]{
			new string[]{"A1","A2",strA3REF},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table n'a pas bougé en V2
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			table = tableP.DataTableObject;
			VerifTable ( table, strNomsCols, new string[][]{
			new string[]{"A1","A2",strA3REF},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//la ligne A de V1 ne doit pas être modifiée,
			//Par contre la ligne 2 oui
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V1,"A3"},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//V3 = V1
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V1,"A3"},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//---------------------------------------------------------
			System.Console.Write("Modif dans V3");
			//Modification de la ligne en V3
			string strA2V3 = "A2 en V3";
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			table = tableP.DataTableObject;
			row = table.Rows[0];
			row[strNomsCols[1]] = strA2V3;
			tableP.BeginEdit();
			tableP.DataTableObject = table;
			Assert.IsTrue(tableP.CommitEdit());

			//La table n'a pas bougé en version référentiel
			m_contexteDonnee.SetVersionDeTravail(null, false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1","A2",strA3REF},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table n'a pas bougé en V2
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1","A2",strA3REF},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table a bougé en V1
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V1,"A3"},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table a bougé en V3
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V3,"A3"},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//-----------------------------------------------
			//Suppression de la ligne C en V1
			System.Console.Write("Delete dans V1");
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			table = tableP.DataTableObject;
			table.Rows[2].Delete();
			tableP.BeginEdit();
			tableP.DataTableObject = table;
			Assert.IsTrue(tableP.CommitEdit());

			//La table n'a pas bougé en version référentiel
			m_contexteDonnee.SetVersionDeTravail(null, false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1","A2",strA3REF},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table n'a pas bougé en V2
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[1], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1","A2",strA3REF},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"C1","C2","C3"},
			new string[]{"D1","D2","D3"}});

			//La table a bougé en V1 (plus de ligne C)
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[0], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V1,"A3"},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"D1","D2","D3"}});

			//La table a bougé en V3 (plus de ligne C)
			m_contexteDonnee.SetVersionDeTravail(m_nIdsVersions[2], false);
			table = tableP.DataTableObject;
			VerifTable(table, strNomsCols, new string[][]{
			new string[]{"A1",strA2V3,"A3"},
			new string[]{"B1",strB2REF,"B3"},
			new string[]{"D1","D2","D3"}});

		}
	}
}
