using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;


namespace timos.data.version
{
    /// <summary>
    /// Type d'audit pour <see cref="CAuditVersion">audit de version.</see><br/>
    /// Le type d'audit permet de d�finir la nature des entit�s qui feront l'objet de l'audit.<br/>
    /// Il permet �galement de d�finir, au moyen de formules, la cl� de l'audit qui sera utilis�e<br/>
    /// pour le mappage par formule; la cl� de l'audit est utilis�e pour d�terminer quelle entit�<br/>
    /// sera consid�r�e comme �tant le m�me objet dans les deux versions.Deux entit�s dont la cl�<br/>
    /// retourne le m�me r�sultat dans chacune des versions seront consid�r�es au niveau de l'audit<br/>
    /// comme repr�sentant le m�me objet. Ainsi, par exemple, si dans l'une des versions un site<br/>
    /// a �t� supprim� et remplac� par un autre site ayant le m�me code et que la cl� est le code<br/>
    /// du site, les deux sites seront consid�r�s comme �tant le m�me site.
    /// <br/>
    /// <br/>
    /// Si aucune cl� n'est sp�cifi�e par l'utilisateur, c'est la cl� primaire de l'objet en base<br/>
    /// de donn�es qui est utilis�e comme cl� pour l'audit.
    /// </summary>
	[DynamicClass("Audit Type for version")]
	[ObjetServeurURI("CTypeAuditVersionServeur")]
	[Table(CTypeAuditVersion.c_nomTable, CTypeAuditVersion.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeReferentiel_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeAudit_ID)]
    public class CTypeAuditVersion : CObjetDonneeAIdNumeriqueAuto
	{
		#region D�claration des constantes
		public const string c_nomTable = "VERSIONAUDITTYPE";
		public const string c_champId = "VAUDITTYP_ID";
		public const string c_champLibelle = "VAUDITTYP_LABEL";
		public const string c_champMapID = "VAUDITTYP_MAPBYID";
		public const string c_champDescription = "VAUDITTYP_DESC";
		public const string c_champParametrageBlob = "VAUDITTYP_PARAM";
		#endregion

		//-------------------------------------------------------------------
		public CTypeAuditVersion(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CTypeAuditVersion(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Libelle;
		}


        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
			get { return I.T( "Audit Type @1 for version|550",Libelle); }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

		/// <summary>
		/// Indicateur comme quoi le mappage entre versions d'une m�me entit� est fait par l'ID<br/>
        /// (si VRAI)
		/// </summary>
		[DynamicField("Mappage by ID")]
		[TableFieldProperty(c_champMapID)]
		public bool MappageParChampsID
		{
			get
			{
				return (bool)Row[c_champMapID];
			}
			set
			{
				Row[c_champMapID] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Libell� du type d'audit
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
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

		//----------------------------------------------
        /// <summary>
        /// Description du type d'audit
        /// </summary>
		[TableFieldProperty(c_champDescription, 2000)]
		[DynamicField("Description")]
		public string Description
		{
			get
			{
				return (string)Row[c_champDescription];
			}
			set
			{
				Row[c_champDescription] = value;
			}
		}


		[TableFieldProperty(c_champParametrageBlob, NullAutorise = true)]
		public CDonneeBinaireInRow ParametrageBlob
		{
			get
			{
				if (Row[c_champParametrageBlob] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champParametrageBlob);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champParametrageBlob, donnee);
				}
				object obj = Row[c_champParametrageBlob];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow ( Row.Row );
			}
			set
			{
				if (value != null)
					Row[c_champParametrageBlob] = value;
				else
					Row[c_champParametrageBlob] = DBNull.Value;
			}
		}

        /// <summary>
        /// Donne ou d�finit l'objet de param�trage du type d'audit
        /// </summary>
		[DynamicField("Parametrage")]
        [BlobDecoder]
		public CAuditVersionParametrage ParametrageObject
		{
			get
			{
				CDonneeBinaireInRow data = ParametrageBlob;
				if (data != null && data.Donnees != null)
				{
					try
					{
						MemoryStream stream = new MemoryStream(data.Donnees);
						BinaryReader reader = new BinaryReader(stream);
						CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
						CAuditVersionParametrage parametre = new CAuditVersionParametrage();
						CResultAErreur result = parametre.Serialize(serializer);
                        reader.Close();
                        stream.Close();
						if (result)
						{
							return parametre;
						}
					}
					catch
					{
					}
				}
				CAuditVersionParametrage para = new CAuditVersionParametrage();
				return para;
			}
			set
			{
				if (value == null)
				{
					CDonneeBinaireInRow data = ParametrageBlob;
					data.Donnees = null;
					ParametrageBlob = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					try
					{
						BinaryWriter writer = new BinaryWriter(stream);
						CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
						CResultAErreur result = value.Serialize(serializer);
						if (result)
						{
							CDonneeBinaireInRow data = ParametrageBlob;
							data.Donnees = stream.GetBuffer(); ;
							ParametrageBlob = data;
						}
                        writer.Close();
					}
					catch
					{
						CDonneeBinaireInRow data = ParametrageBlob;
						data.Donnees = null;
						ParametrageBlob = data;
					}
                    stream.Close();
				}
			}
		}
	}
}
