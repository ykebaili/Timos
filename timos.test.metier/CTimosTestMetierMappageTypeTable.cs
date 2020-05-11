using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using NUnit.Framework;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

using timos.data;
using timos.client;
using timos.acteurs;

namespace timos.test.metier
{
	/*
	 * 
	 * 
	 */
	[TestFixture]
	public class CTimosTestMetierMappageTypeTable
	{
		private CContexteDonnee m_contexteDonnee;
		//private int m_nIdActeur = -1;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="strNom"></param>
		/// <param name="tpTable"></param>
		/// <param name="nPos"></param>
		/// <param name="nPosKey">-1 pour spécifier que la colonne ne fait pas partie de la clé primaire</param>
		/// <param name="ctx"></param>
		/// <returns></returns>
		private CColonneTableParametrable GetColonne(string strNom, CTypeTableParametrable tpTable, TypeDonnee tpColonne, bool bAllowNull, int nPos, int nPosKey)
		{
			CColonneTableParametrable col = new CColonneTableParametrable(m_contexteDonnee);
			col.CreateNewInCurrentContexte();
			col.Libelle = strNom;
			col.AllowNull = bAllowNull;
			col.TypeDonneeChamp = new C2iTypeDonnee(tpColonne);
			col.Position = nPos;
			col.TypeTable = tpTable;
			if (nPosKey != -1)
				col.PrimaryKeyPosition = nPosKey;

			return col;
		}
		private CTypeTableParametrable GetTypeTable(string strNom)
		{
			CTypeTableParametrable tpTable = new CTypeTableParametrable(m_contexteDonnee);
			tpTable.CreateNewInCurrentContexte();
			tpTable.Libelle = strNom;
			return tpTable;
		}


		[SetUp]
		public void Init()
		{
			CResultAErreur result = CResultAErreur.True;
			CTimosTestMetierApp.AssureInit();
			m_contexteDonnee = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false);

			////Création de l'acteur de test
			//CActeur acteur = new CActeur(m_contexteDonnee);
			//if (!acteur.ReadIfExists(new CFiltreData(CActeur.c_champPrenom + "=@1",
			//    "NUNIT ACTEUR")))
			//{
			//    acteur.CreateNew();
			//    acteur.Nom = "NUnit acteur";
			//    acteur.Prenom = "NUNIT ACTEUR";
			//    result = acteur.CommitEdit();
			//    Assert.IsTrue(result.Result);
			//}
			//m_nIdActeur = acteur.Id;
		}

		private List<TypeDonnee> ListeTypes
		{
			get
			{
				List<TypeDonnee> types = new List<TypeDonnee>();
				types.Add(TypeDonnee.tString);
				types.Add(TypeDonnee.tEntier);
				types.Add(TypeDonnee.tDouble);
				types.Add(TypeDonnee.tBool);
				types.Add(TypeDonnee.tDate);
				return types;
			}
		}
		public object GetVal(TypeDonnee type, int nVal)
		{
			switch (type)
			{
				case TypeDonnee.tBool:
					if (nVal == 1)
						return true;
					else
						return false;
				case TypeDonnee.tDate:
					if (nVal == 1)
						return DateTime.Now;
					else
						return DateTime.Now.AddDays(7);
				case TypeDonnee.tDouble:
					if (nVal == 1)
						return 0.1;
					else
						return 0.2;
				case TypeDonnee.tEntier:
					if (nVal == 1)
						return 1;
					else
						return 2;
				case TypeDonnee.tString:
					if (nVal == 1)
						return "Valeur 1";
					else
						return "Valeur 2";
				default:
				case TypeDonnee.tObjetDonneeAIdNumeriqueAuto:
					return null;
			}
		}

		/// <summary>
		/// Test l'importation de donnée à partir de colonnes non nullable :
		/// 
		/// Colonne 1 :
		/// Primary Key : Oui
		/// Nullable : Non
		/// 
		/// Colonne 2 :
		/// Primary Key : Oui
		/// Nullable : Non
		/// 
		/// Vers une colonne nullable :
		/// 
		/// Colonne3 :
		/// Primary Key : Oui
		/// Nullable : Oui
		/// 
		/// Dans tout les types
		/// 
		/// [ 10 Tests d'importation ]
		/// </summary>
		[Test]
		public void TestColonneNonNullVersNull()
		{
			Console.WriteLine("TEST : ");
			foreach (TypeDonnee tpDonnee in ListeTypes)
			{
				for (int nPk = 0; nPk < 2; nPk++)
				{
					int nPrimaryKeyPos = -1;
					if (nPk == 1)
						nPrimaryKeyPos = 0;

					string strTp = new C2iTypeDonnee(tpDonnee).Libelle;
					Console.WriteLine("");
					Console.WriteLine("----- TYPE " + strTp + " -----");
					Console.WriteLine("");

					CTypeTableParametrable tpSource = GetTypeTable("TpSource");
					CColonneTableParametrable colSource = GetColonne("ColSrc", tpSource, tpDonnee, true, 0, nPrimaryKeyPos);
					Console.WriteLine("-- Colonne Source --");
					Console.WriteLine("Clé : " + (nPrimaryKeyPos == -1 ? "Non" : "Oui"));
					Console.WriteLine("Nullable : Non");
					Console.WriteLine("Type : " + strTp);


					CTypeTableParametrable tpCible = GetTypeTable("TpCible");
					CColonneTableParametrable colCible = GetColonne("ColCible", tpCible, tpDonnee, false, 0, nPrimaryKeyPos);

					DataTable dtSource = tpSource.GetNewDataTable("TableTest");

					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneA = colSource;
					map.ColonneB = colCible;

					List<CMappageColonneTableParametrableColonneTableParametrable> maps = new List<CMappageColonneTableParametrableColonneTableParametrable>();
					maps.Add(map);

					Console.WriteLine("");
					Console.WriteLine("-- Colonne Cible --");
					Console.WriteLine("Clé : Non");
					Console.WriteLine("Nullable : Non");
					Console.WriteLine("Type : " + strTp);

					DataRow rowA = dtSource.NewRow();
					object val = GetVal(tpDonnee, 1);
					rowA["ColSrc"] = val;
					dtSource.Rows.Add(rowA);

					Console.WriteLine("");
					Console.WriteLine("Valeur importée : " + val.ToString());
					Console.WriteLine("");

					DataTable dtFinale = tpCible.GetNewDataTable("TableFinale");
					CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(maps, dtSource, dtFinale);
					Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
					Console.WriteLine("");

					Console.WriteLine("RESULTAT TEST :");
					Assert.AreEqual(dtFinale.Rows.Count, dtSource.Rows.Count);
					Console.WriteLine(" - Nombre de lignes importées egales OK");
					if (dtFinale.Rows.Count == 1)
					{
						Assert.AreEqual(dtFinale.Rows[0]["ColCible"], dtSource.Rows[0]["ColSrc"]);
						Console.WriteLine(" - Valeur importées exactes OK");
					}
					dtSource.Rows.Clear();
				}
			}
		}

		/// <summary>
		/// Test l'importation de donnée à partir d'une colonne nullable vers :
		/// 
		/// Colonne1 :
		/// Primary Key : Oui
		/// Nullable : Non
		/// 
		/// Colonne 2 :
		/// Primary Key : Oui
		/// Nullable : Non
		/// 
		/// Dans tout les types
		/// 
		/// Chaque importation est testée avec une valeur du bon type et une valeur Null
		/// 
		/// [ 20 Tests d'importation ]
		/// </summary>
		[Test]
		public void TestColonneNullVersNonNull()
		{
			Console.WriteLine("TEST : ");
			foreach (TypeDonnee tpDonnee in ListeTypes)
			{
				string strTp = new C2iTypeDonnee(tpDonnee).Libelle;
				Console.WriteLine("");
				Console.WriteLine("----- TYPE " + strTp + " -----");
				Console.WriteLine("");

				CTypeTableParametrable tpSource = GetTypeTable("TpSource");
				CColonneTableParametrable colSource = GetColonne("ColSrc", tpSource, tpDonnee, true, 0, -1);
				Console.WriteLine("-- Colonne Source --");
				Console.WriteLine("Clé : Non");
				Console.WriteLine("Nullable : Oui");
				Console.WriteLine("Type : " + strTp);


				for (int nPk = 0; nPk < 2; nPk++)
				{
					int nPrimaryKeyPos = -1;
					if (nPk == 1)
						nPrimaryKeyPos = 0;

					CTypeTableParametrable tpCible = GetTypeTable("TpCible");
					CColonneTableParametrable colCible = GetColonne("ColCible", tpCible, tpDonnee, false, 0, nPrimaryKeyPos);

					DataTable dtSource = tpSource.GetNewDataTable("TableTest");

					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneA = colSource;
					map.ColonneB = colCible;

					List<CMappageColonneTableParametrableColonneTableParametrable> maps = new List<CMappageColonneTableParametrableColonneTableParametrable>();
					maps.Add(map);

					Console.WriteLine("");
					Console.WriteLine("-- Colonne Cible --");
					Console.WriteLine("Clé : " + (nPrimaryKeyPos == -1 ? "Non" : "Oui"));
					Console.WriteLine("Nullable : Non");
					Console.WriteLine("Type : " + strTp);

					for (int nNull = 0; nNull < 2; nNull++)
					{
						DataRow rowA = dtSource.NewRow();
						object val = DBNull.Value;
						if (nNull == 1)
							val = GetVal(tpDonnee, 1);
						rowA["ColSrc"] = val;
						dtSource.Rows.Add(rowA);

						Console.WriteLine("");
						Console.WriteLine("Valeur importée : " + (val == DBNull.Value ? "NULL" : val.ToString()));
						Console.WriteLine("");

						DataTable dtFinale = tpCible.GetNewDataTable("TableFinale");
						CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(maps, dtSource, dtFinale);
						Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
						Console.WriteLine("");

						if (nNull == 0)
						{
							Console.WriteLine("RESULTAT TEST :");
							Assert.AreEqual(0, dtFinale.Rows.Count);
							Console.WriteLine(" - Erreur d'importation OK");
						}
						else
						{
							Console.WriteLine("RESULTAT TEST :");
							Assert.AreEqual(dtFinale.Rows.Count, dtSource.Rows.Count);
							Console.WriteLine(" - Nombre de lignes importées egales OK");
							if (dtFinale.Rows.Count == 1)
							{
								Assert.AreEqual(dtFinale.Rows[0]["ColCible"], dtSource.Rows[0]["ColSrc"]);
								Console.WriteLine(" - Valeur importées exactes OK");
							}
						}
						dtSource.Rows.Clear();
					}
				}
			}
		}

		/// <summary>
		/// Test l'affectation d'une valeur constante vers :
		/// 
		/// Colonne1 :
		/// Primary Key : Non
		/// Nullable : Oui
		/// 
		/// Colonne2 :
		/// Primary Key : Non
		/// Nullable : Non
		/// 
		/// Colonne3 :
		/// Primary Key : Oui
		/// Nullable : Non
		/// 
		/// Dans tout les types
		/// 
		/// Chaque importation est testée avec une valeur du bon type et une valeur Null
		/// 
		/// [ 30 Tests d'importation ]
		/// </summary>
		[Test]
		public void TestValeurConstante()
		{
			Console.WriteLine("TEST : ");
			foreach (TypeDonnee tpDonnee in ListeTypes)
			{
				string strTp = new C2iTypeDonnee(tpDonnee).Libelle;
				Console.WriteLine("");
				Console.WriteLine("----- TYPE " + strTp + " -----");
				Console.WriteLine("");

				for (int nPk = 0; nPk < 2; nPk++)
				{
					int nPrimaryKeyPos = -1;
					if (nPk == 1)
						nPrimaryKeyPos = 0;
					bool bPrimaryKey = nPrimaryKeyPos == 0;
					for (int nColNullable = 0; nColNullable < 2; nColNullable++)
					{
						bool bNullable = nColNullable == 0;

						//Le test clé primaire & nullable n'a pas lieu d'existé car
						//il serait une redondance du test clé primaire & non nullable
						//étant donné que la propriété nullable n'a pas d'incidance
						//lorsque la colonne est primary key (toujours non nullable)
						if (bPrimaryKey && bNullable)
							continue;

						//Creation d'une table qui ne servira à rien sinon à donner le nombre de lignes
						CTypeTableParametrable tpSrc = GetTypeTable("TpSource");
						CColonneTableParametrable colSrc = GetColonne("ColSource", tpSrc, tpDonnee, bNullable, 0, nPrimaryKeyPos);
						DataTable dtSource = tpSrc.GetNewDataTable("TableSource");
						DataRow dr = dtSource.NewRow();
						dr["ColSource"] = GetVal(tpDonnee, 1);
						dtSource.Rows.Add(dr);


						CTypeTableParametrable tpCible = GetTypeTable("TpCible");
						CColonneTableParametrable colCible = GetColonne("ColCible", tpCible, tpDonnee, bNullable, 0, nPrimaryKeyPos);
						Console.WriteLine("-- Colonne Cible --");
						Console.WriteLine("Clé : " + (bPrimaryKey ? "Oui" : "Non"));
						Console.WriteLine("Nullable : " + (bNullable ? "Oui" : "Non"));
						Console.WriteLine("Type : " + strTp);


						CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
						map.ColonneB = colCible;

						List<CMappageColonneTableParametrableColonneTableParametrable> maps = new List<CMappageColonneTableParametrableColonneTableParametrable>();
						maps.Add(map);

						for (int nNull = 0; nNull < 2; nNull++)
						{
							object val = DBNull.Value;
							if (nNull == 1)
								val = GetVal(tpDonnee, 1);

							Console.WriteLine("");
							Console.WriteLine("Valeur constante : " + (val == DBNull.Value ? "NULL" : val.ToString()));
							Console.WriteLine("");

							map.DefaultValueAtoB = val;

							DataTable dtFinale = tpCible.GetNewDataTable("TableFinale");
							CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(maps, dtSource, dtFinale);
							Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
							Console.WriteLine("");

							if (nNull == 0 && (!bNullable || bPrimaryKey))
							{
								Console.WriteLine("RESULTAT TEST :");
								Assert.AreEqual(0, dtFinale.Rows.Count);
								Console.WriteLine(" - Erreur d'importation OK");
							}
							else
							{
								Console.WriteLine("RESULTAT TEST :");
								Assert.AreEqual(dtFinale.Rows.Count, dtSource.Rows.Count);
								Console.WriteLine(" - Nombre de lignes importées egales OK");
								if (dtFinale.Rows.Count == 1)
								{
									Assert.AreEqual(dtFinale.Rows[0]["ColCible"], val);
									Console.WriteLine(" - Valeur importées exactes OK");
								}
							}
							dtFinale.Rows.Clear();
						}
					}
				}
			}
		}

		/// <summary>
		/// Test l'affectation d'une valeur par défaut vers :
		/// 
		/// Colonne1 :
		/// Primary Key : Non
		/// Nullable : Oui
		/// 
		/// Colonne2 :
		/// Primary Key : Non
		/// Nullable : Non
		/// 
		/// Colonne3 :
		/// Primary Key : Oui
		/// Nullable : Non
		/// 
		/// Dans tout les types
		/// 
		/// Chaque importation est testée avec une valeur du bon type et une valeur Null
		/// 
		/// [ 30 Tests d'importation ]
		/// </summary>
		[Test]
		public void TestValeurParDefaut()
		{
			Console.WriteLine("TEST : ");
			foreach (TypeDonnee tpDonnee in ListeTypes)
			{
				string strTp = new C2iTypeDonnee(tpDonnee).Libelle;
				Console.WriteLine("");
				Console.WriteLine("----- TYPE " + strTp + " -----");
				Console.WriteLine("");

				for (int nPk = 0; nPk < 2; nPk++)
				{
					int nPrimaryKeyPos = -1;
					if (nPk == 1)
						nPrimaryKeyPos = 0;
					bool bPrimaryKey = nPrimaryKeyPos == 0;
					for (int nColNullable = 0; nColNullable < 2; nColNullable++)
					{
						bool bNullable = nColNullable == 0;

						//Le test clé primaire & nullable n'a pas lieu d'existé car
						//il serait une redondance du test clé primaire & non nullable
						//étant donné que la propriété nullable n'a pas d'incidance
						//lorsque la colonne est primary key (toujours non nullable)
						if (bPrimaryKey && bNullable)
							continue;

						//Creation d'une table qui ne servira à rien sinon à donner le nombre de lignes
						CTypeTableParametrable tpSrc = GetTypeTable("TpSource");
						CColonneTableParametrable colSrc = GetColonne("ColSource", tpSrc, tpDonnee, true, 0, -1);
						DataTable dtSource = tpSrc.GetNewDataTable("TableSource");
						DataRow dr = dtSource.NewRow();
						dr["ColSource"] = DBNull.Value;
						dtSource.Rows.Add(dr);


						CTypeTableParametrable tpCible = GetTypeTable("TpCible");
						CColonneTableParametrable colCible = GetColonne("ColCible", tpCible, tpDonnee, bNullable, 0, nPrimaryKeyPos);
						Console.WriteLine("-- Colonne Cible --");
						Console.WriteLine("Clé : " + (bPrimaryKey ? "Oui" : "Non"));
						Console.WriteLine("Nullable : " + (bNullable ? "Oui" : "Non"));
						Console.WriteLine("Type : " + strTp);


						CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
						map.ColonneA = colSrc;
						map.ColonneB = colCible;

						List<CMappageColonneTableParametrableColonneTableParametrable> maps = new List<CMappageColonneTableParametrableColonneTableParametrable>();
						maps.Add(map);

						for (int nNull = 0; nNull < 2; nNull++)
						{
							object val = DBNull.Value;
							if (nNull == 1)
								val = GetVal(tpDonnee, 1);

							Console.WriteLine("");
							Console.WriteLine("Valeur par défaut : " + (val == DBNull.Value ? "NULL" : val.ToString()));
							Console.WriteLine("");

							map.DefaultValueAtoB = val;

							DataTable dtFinale = tpCible.GetNewDataTable("TableFinale");
							CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(maps, dtSource, dtFinale);
							Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
							Console.WriteLine("");

							if (nNull == 0 && (!bNullable || bPrimaryKey))
							{
								Console.WriteLine("RESULTAT TEST :");
								Assert.AreEqual(0, dtFinale.Rows.Count);
								Console.WriteLine(" - Erreur d'importation OK");
							}
							else
							{
								Console.WriteLine("RESULTAT TEST :");
								Assert.AreEqual(dtFinale.Rows.Count, dtSource.Rows.Count);
								Console.WriteLine(" - Nombre de lignes importées egales OK");
								if (dtFinale.Rows.Count == 1)
								{
									if (map.NeedDefaultValueAtoB)
										Assert.AreEqual(dtFinale.Rows[0]["ColCible"], val);
									else
										Assert.AreEqual(dtFinale.Rows[0]["ColCible"], DBNull.Value);

									Console.WriteLine(" - Valeur importées exactes OK");
								}
							}
							dtFinale.Rows.Clear();
						}
					}
				}
			}
		}

		//ERREURS
		/// <summary>
		/// Test l'importation de donnée avec clé en double :
		/// 
		/// Colonne Source :
		/// Primary Key : Non
		/// Nullable : Non
		/// 
		/// Colonne Destination :
		/// Primary Key : Oui
		/// Nullable : Non
		/// 
		/// Dans tout les types
		/// 
		/// [ 5 Tests d'importation ]
		/// </summary>
		[Test]
		public void TestCleDoublee()
		{
			Console.WriteLine("TEST : ");
			foreach (TypeDonnee tpDonnee in ListeTypes)
			{
				string strTp = new C2iTypeDonnee(tpDonnee).Libelle;
				Console.WriteLine("");
				Console.WriteLine("----- TYPE " + strTp + " -----");
				Console.WriteLine("");

				//Creation d'une table qui ne servira à rien sinon à donner le nombre de lignes
				CTypeTableParametrable tpSrc = GetTypeTable("TpSource");
				CColonneTableParametrable colSrc = GetColonne("ColSource", tpSrc, tpDonnee, false, 0, -1);
				DataTable dtSource = tpSrc.GetNewDataTable("TableSource");
				DataRow dr1 = dtSource.NewRow();
				dr1["ColSource"] = GetVal(tpDonnee, 1);
				dtSource.Rows.Add(dr1);
				DataRow dr2 = dtSource.NewRow();
				dr2["ColSource"] = GetVal(tpDonnee, 1);
				dtSource.Rows.Add(dr2);


				CTypeTableParametrable tpCible = GetTypeTable("TpCible");
				CColonneTableParametrable colCible = GetColonne("ColCible", tpCible, tpDonnee, false, 0, 0);

				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneA = colSrc;
				map.ColonneB = colCible;

				List<CMappageColonneTableParametrableColonneTableParametrable> maps = new List<CMappageColonneTableParametrableColonneTableParametrable>();
				maps.Add(map);

				DataTable dtFinale = tpCible.GetNewDataTable("TableFinale");
				CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(maps, dtSource, dtFinale);
				Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
				Console.WriteLine("");
				Assert.AreEqual((bool)result, false);
				Console.WriteLine(" - Erreur d'importation OK");
				foreach (IErreur err in result.Erreur.Erreurs)
					Console.WriteLine(err.Message);
				Console.WriteLine("RESULTAT TEST :");
				Assert.AreEqual(1, dtFinale.Rows.Count);
				Console.WriteLine(" - Une seule ligne importée OK");
			}
		}
		/// <summary>
		/// Test l'importation de donnée de types différents
		/// Dans tout les types
		/// 
		/// [ 20 Tests d'importation ]
		/// </summary>
		[Test]
		public void TestErreurType()
		{
			foreach (TypeDonnee tpDonnee in ListeTypes)
			{
				foreach (TypeDonnee tpDonneeCible in ListeTypes)
				{
					if (tpDonnee == tpDonneeCible)
						continue;

					string strTp = new C2iTypeDonnee(tpDonnee).Libelle;
					string strTpCible = new C2iTypeDonnee(tpDonneeCible).Libelle;

					Console.WriteLine("");
					Console.WriteLine("----- TYPE " + strTp + " > " + strTpCible + " -----");
					Console.WriteLine("");

					//Creation d'une table qui ne servira à rien sinon à donner le nombre de lignes
					CTypeTableParametrable tpSrc = GetTypeTable("TpSource");
					CColonneTableParametrable colSrc = GetColonne("ColSource", tpSrc, tpDonnee, false, 0, -1);
					DataTable dtSource = tpSrc.GetNewDataTable("TableSource");
					DataRow dr1 = dtSource.NewRow();
					object val = GetVal(tpDonnee, 1);
					dr1["ColSource"] = val;
					dtSource.Rows.Add(dr1);

					CTypeTableParametrable tpCible = GetTypeTable("TpCible");
					CColonneTableParametrable colCible = GetColonne("ColCible", tpCible, tpDonneeCible, true, 0, -1);

					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneA = colSrc;
					map.ColonneB = colCible;

					Console.WriteLine("Valeur testée : " + val.ToString());
					Console.WriteLine("");

					List<CMappageColonneTableParametrableColonneTableParametrable> maps = new List<CMappageColonneTableParametrableColonneTableParametrable>();
					maps.Add(map);

					DataTable dtFinale = tpCible.GetNewDataTable("TableFinale");
					CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(maps, dtSource, dtFinale);
					Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
					Console.WriteLine("");
					//if (
					//    tpDonneeCible == TypeDonnee.tString
					//    || (tpDonnee == TypeDonnee.tEntier && (tpDonneeCible == TypeDonnee.tDouble
					//                                        || tpDonneeCible == TypeDonnee.tBool))

					//    || (tpDonnee == TypeDonnee.tDouble && (tpDonneeCible == TypeDonnee.tEntier
					//                                        || tpDonneeCible == TypeDonnee.tBool))

					//    || (tpDonnee == TypeDonnee.tBool && (tpDonneeCible == TypeDonnee.tEntier 
					//                                        || tpDonneeCible == TypeDonnee.tDouble))
					//    )
					//{
					//    Assert.AreEqual((bool)result, true);
					//    Assert.AreEqual(dtFinale.Rows.Count, dtSource.Rows.Count);
					//    Console.WriteLine(" - Importation réussie OK");
					//}
					//else
					//{
					Assert.AreEqual((bool)result, false);
					Console.WriteLine(" - Erreur d'importation OK");
					foreach (IErreur err in result.Erreur.Erreurs)
						Console.WriteLine(err.Message);
					//}
				}
			}
		}

		private void CreateColsStructureA(CTypeTableParametrable tpTable)
		{
			int nPos = 0;
			for(int n = 0; n < 3; n++)
				foreach (TypeDonnee tpDonnee in ListeTypes)
				{
					string strType = new C2iTypeDonnee(tpDonnee).Libelle;
					int nKey = nPos < 5 ? nPos : -1;
					bool bNullable = nPos > 4 && nPos < 10;
					string strNomCol = "Col" + nPos.ToString() + " type "+ strType;
					GetColonne(strNomCol, tpTable, tpDonnee, bNullable, nPos, nKey);
					nPos++;
				}
		}
		private DataTable GetDataTableWithOneLine(CTypeTableParametrable tpTable)
		{
			DataTable dt = tpTable.GetNewDataTable("table");
			DataRow dr = dt.NewRow();
			foreach(CColonneTableParametrable col in tpTable.Colonnes)
			{
				dr[col.Libelle] = GetVal(col.TypeDonneeChamp.TypeDonnee,0);
			}
			dt.Rows.Add(dr);
			return dt;
		}

		/// <summary>
		/// Test l'importation de donnée de types différents
		/// Dans tout les types
		/// 
		/// [ 20 Tests d'importation ]
		/// </summary>
		[Test]
		public void TestErreurMappageCle()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREUR MAPPAGE CLE -----");
			Console.WriteLine("");
			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);
		
			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);
			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");

			//TEST CLE NON MAPPEE
			Console.WriteLine("----- TEST CLE NON MAPPEE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach(CColonneTableParametrable col in tpTableCible.Colonnes)
				if(!col.AllowNull && !col.IsPrimaryKey)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;
					foreach(CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if(colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}

			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages,dtSource,dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);

			//TEST CLE MAPPEE PARTIELLEMENT
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST CLE PARTIELLEMENT MAPPEE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				if ((col.IsPrimaryKey || !col.AllowNull) && col.PrimaryKeyPosition != 0)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;
					foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);


			//TEST CLE MAPPEE
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST CLE MAPPEE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;
				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}
				mappages.Add(map);
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");

		}
		[Test]
		public void TestErreurColonneNonNullNonMappee()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREURS MAPPAGE COLONNES NON NULLES -----");
			Console.WriteLine("");
			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);

			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);
			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");

			//TEST CLE NON MAPPEE
			Console.WriteLine("----- TEST COLONNES NON NULLES NON MAPPEES -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				if (col.IsPrimaryKey)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;
					foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}

			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);

			//TEST CLE MAPPEE PARTIELLEMENT
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST COLONNES NON NULLES PARTIELLEMENT MAPPEES -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			bool bColonneNonNullMappee = false;
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				if (col.IsPrimaryKey || (!col.AllowNull && !bColonneNonNullMappee))
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;
					foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}
				if(!bColonneNonNullMappee && !col.IsPrimaryKey && !col.AllowNull)
					bColonneNonNullMappee = true;
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);


			//TEST CLE MAPPEE
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST COLONNES NON NULLES MAPPEES -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;
				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}
				mappages.Add(map);
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");
		}
		[Test]
		public void TestErreurColonneDestinationMappeePlusieursFois()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREURS COLONNE DESTINATION MAPPEE N FOIS -----");
			Console.WriteLine("");
			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);

			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);
			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");
			
			Console.WriteLine("----- TEST COLONNES MAPPEES PLUSIEURS FOIS -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				if (col.IsPrimaryKey || !col.AllowNull)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					CMappageColonneTableParametrableColonneTableParametrable map2 = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;
					map2.ColonneB = col;

					foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							map2.ColonneA = col;
							break;
						}
					mappages.Add(map);
					mappages.Add(map2);
				}

			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);

			
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST COLONNE MAPPEE UNE SEULE FOIS -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;

				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}
				mappages.Add(map);
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");

		}
		[Test]
		public void TestErreurPlusieursTypeSource()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREURS PLUSIEURS TYPES SOURCE DEFINIS -----");
			Console.WriteLine("");

			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableSource2 = GetTypeTable("TpSource2");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");


			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableSource2);
			CreateColsStructureA(tpTableCible);

			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);
			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");


			Console.WriteLine("----- TEST PLUSIEURS TYPES SOURCE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				if (col.IsPrimaryKey || !col.AllowNull)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;

					foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}
				else
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;

					foreach (CColonneTableParametrable colSrc in tpTableSource2.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}

			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);


			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST UN TYPE SOURCE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;

				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}
				mappages.Add(map);
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");
		}
		[Test]
		public void TestErreurPlusieursTypeCible()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREURS PLUSIEURS TYPES CIBLE DEFINIS -----");
			Console.WriteLine("");

			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");
			CTypeTableParametrable tpTableCible2 = GetTypeTable("TpCible2");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);
			CreateColsStructureA(tpTableCible2);

			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");
			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);


			Console.WriteLine("----- TEST PLUSIEURS TYPES CIBLE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				if (col.IsPrimaryKey || !col.AllowNull)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;

					foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}
			foreach (CColonneTableParametrable col in tpTableCible2.Colonnes)
				if(col.AllowNull)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = col;

					foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
						if (colSrc.Position == col.Position)
						{
							map.ColonneA = colSrc;
							break;
						}
					mappages.Add(map);
				}

			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);


			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST UN TYPE CIBLE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;

				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}
				mappages.Add(map);
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");
		}

		[Test]
		public void TestErreurAucunMappage()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREURS AUCUN MAPPAGE -----");
			Console.WriteLine("");

			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);

			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);
			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");

			Console.WriteLine("----- TEST MAPPAGES NULL -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(null, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);

			Console.WriteLine("----- TEST AUCUN MAPPAGES -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);


			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST AVEC MAPPAGES -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;

				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}
				mappages.Add(map);
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");
		}
		[Test]
		public void TestErreurTableSource()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREURS TABLE SOURCE -----");
			Console.WriteLine("");

			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);

			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");
			DataTable dtSource = tpTableSource.GetNewDataTable("TbSource");

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;

				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}

				mappages.Add(map);
			}

			Console.WriteLine("----- TEST TABLE SOURCE NULLE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, null, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);


			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST TABLE SOURCE AUCUNE LIGNE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 0);
			Console.WriteLine(" - 0 lignes importées OK");



			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST TABLE SOURCE NE CORRESONDANT PAS AU TYPE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			dtSource = GetDataTableWithOneLine(tpTableSource);
			bool bRemove = true;
			foreach(CColonneTableParametrable col in tpTableSource.Colonnes)
			{
				if (bRemove)
				{
					if (col.IsPrimaryKey)
						continue;
					dtSource.Columns.Remove(col.Libelle);
				}
				bRemove = !bRemove;
			}

			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 0);

			dtSource = GetDataTableWithOneLine(tpTableSource);



			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST AVEC TABLE SOURCE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");
			
		}
		[Test]
		public void TestErreurTableCible()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST ERREURS TABLE SOURCE -----");
			Console.WriteLine("");

			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);

			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");
			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);

			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;

				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						map.ColonneA = colSrc;
						break;
					}

				mappages.Add(map);
			}
			Console.WriteLine("----- TEST TABLE CIBLE NULLE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, null);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);


			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST TABLE CIBLE NE CORRESONDANT PAS AU TYPE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			bool bRemove = true;
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				if (bRemove)
				{
					if (col.IsPrimaryKey)
						continue;
					dtCible.Columns.Remove(col.Libelle);
				}
				bRemove = !bRemove;
			}


			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur importation OK");

			dtCible = tpTableCible.GetNewDataTable("TbCible");

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST AVEC TABLE CIBLE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");
		}

		[Test]
		public void TestErreurColonneCibleManquante()
		{
			Console.WriteLine("");
			Console.WriteLine("----- TEST COLONNE CIBLE MANQUANTE -----");
			Console.WriteLine("");

			CTypeTableParametrable tpTableSource = GetTypeTable("TpSource");
			CTypeTableParametrable tpTableCible = GetTypeTable("TpCible");

			CreateColsStructureA(tpTableSource);
			CreateColsStructureA(tpTableCible);

			DataTable dtCible = tpTableCible.GetNewDataTable("TbCible");
			DataTable dtSource = GetDataTableWithOneLine(tpTableSource);

			CMappageColonneTableParametrableColonneTableParametrable mapTmp = null;
			CColonneTableParametrable colTmp = null;
			List<CMappageColonneTableParametrableColonneTableParametrable> mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
			{
				CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
				map.ColonneB = col;

				foreach (CColonneTableParametrable colSrc in tpTableSource.Colonnes)
					if (colSrc.Position == col.Position)
					{
						if (col.Position == 6)
						{
							colTmp = col;
							mapTmp = map;
							map.ColonneB = null;
						}
						map.ColonneA = colSrc;
						break;
					}

				mappages.Add(map);
			}
			Console.WriteLine("----- TEST COLONNE CIBLE MANQUANTE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");
			CResultAErreur result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, null);
			Assert.AreEqual((bool)result, false);
			Console.WriteLine(" - Erreur d'importation OK");
			foreach (IErreur err in result.Erreur.Erreurs)
				Console.WriteLine(err.Message);

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("----- TEST AVEC COLONNE PRESENTE -----");
			Console.WriteLine("[[ TEST D'IMPORTATION... ]]");
			Console.WriteLine("");

			mapTmp.ColonneB = colTmp;
			result = CMappeurTypeTableParametrableTypeTableParametrable.Mapper(mappages, dtSource, dtCible);
			Assert.AreEqual((bool)result, true);
			Console.WriteLine(" - Importation OK");
			Assert.AreEqual(dtCible.Rows.Count, 1);
			Console.WriteLine(" - Nombre ligne importées OK");
			foreach (CColonneTableParametrable col in tpTableCible.Colonnes)
				Assert.AreEqual(dtCible.Rows[0][col.Libelle], dtSource.Rows[0][col.Libelle]);
			Console.WriteLine(" - Valeurs importées OK");
		}
	}
}
