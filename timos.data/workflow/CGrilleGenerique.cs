using System;
using System.Collections;
using System.Data;
using System.IO;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;

namespace sc2i.workflow
{
	/// <summary>
	/// Une grille générique est une matrice à deux dimensions dans laquelle
	/// il est possible de récupèrer des valeurs en désignant une ligne et une colonne
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iProcess)]
    [DynamicClass("Generic grid")]
	[ObjetServeurURI("CGrilleGeneriqueServeur")]
	[Table(CGrilleGenerique.c_nomTable, CGrilleGenerique.c_champId,true, IsGrandVolume = true)]
	[FullTableSync]
	//[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_GrillesGeneriques_ID)]
	public class CGrilleGenerique : CObjetDonneeAIdNumeriqueAuto
	{
		#region Déclaration des constantes
		public const string c_nomTable = "GENERIC_GRID";
		public const string c_champId = "GENGRID_ID";
		public const string c_champLibelle = "GENGRID_LABEL";
		public const string c_champCode = "GENGRID_CODE";
		public const string c_champCommentaires = "GENGRID_COMMENT";
		public const string c_champDataGrille = "GENGRID_GRID_DATA";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CGrilleGenerique()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGrilleGenerique( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CGrilleGenerique( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Generic Grid @1|312", Libelle);
			}
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// Libellé de la grille.
		/// </summary>
		[
		TableFieldProperty(c_champLibelle, 255),
		DynamicField("Label")
		]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Code de la grille (unique ou vide). Chaîne de caractères
		/// </summary>
		[
		TableFieldProperty(c_champCode, 255),
		DynamicField("Code")
		]
		public string Code
		{
			get
			{
				return (string)Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Commentaires ou descriptif
		/// </summary>
		[
		TableFieldProperty(c_champCommentaires, 1024),
		DynamicField("Comment")
		]
		public string Commentaires
		{
			get
			{
				return (string)Row[c_champCommentaires];
			}
			set
			{
				Row[c_champCommentaires] = value;
			}
		}


		/// /////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champDataGrille,NullAutorise=true)]
		public CDonneeBinaireInRow DataGrille
		{
			get
			{
				if ( Row[c_champDataGrille] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champDataGrille);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataGrille, donnee);
				}
				return ((CDonneeBinaireInRow)Row[c_champDataGrille]).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champDataGrille] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
        [BlobDecoder]
        public CMatriceDonnee MatriceDonnee
		{
			get
			{
				CMatriceDonnee retour = null;
				if ( DataGrille.Donnees != null )
				{
					MemoryStream stream = new MemoryStream(DataGrille.Donnees);
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
					I2iSerializable objet = null;
					CResultAErreur result = serializer.TraiteObject ( ref objet );
					if ( result )
					{
						retour = (CMatriceDonnee)objet;
					}
                    reader.Close();
                    stream.Close();
				}
				if ( retour == null )
					retour = new CMatriceDonnee();
				return retour;
			}
			set
			{
				if ( value == null )
				{
					CDonneeBinaireInRow data = DataGrille;
					data.Donnees = null;
					DataGrille = data;
				}
				else
				{
					
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter(stream);
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
					I2iSerializable objet = value;
					CResultAErreur result = serializer.TraiteObject ( ref objet );
					if ( result )
					{
						CDonneeBinaireInRow data = DataGrille;
						data.Donnees = stream.GetBuffer();
						DataGrille = data;
					}
                    writer.Close();
                    stream.Close();
				}
			}
		}

		/// <summary>
		/// Indique, lorsque VRAI, que la liste est une liste dynamique
		/// </summary>
		[DynamicField("Is dynamic")]
		public bool IsDynamique
		{
			get
			{
				return DataGrille.Donnees != null;
			}
		}
	}
}
