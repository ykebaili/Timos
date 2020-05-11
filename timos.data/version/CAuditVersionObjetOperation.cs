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
    /// Décrit une opération effectuée sur une entité et répertoriée dans un audit de version
    /// </summary>
    [NoRelationTypeId()]
	[DynamicClass("Audit Version Object Operation")]
	[ObjetServeurURI("CAuditVersionObjetOperationServeur")]
	[Table(CAuditVersionObjetOperation.c_nomTable, CAuditVersionObjetOperation.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeReferentiel_ID)]
    public class CAuditVersionObjetOperation : CObjetDonneeAIdNumeriqueAuto, 
		IElementAChampPourVersion,
		IObjetSansVersion
	{


		#region Déclaration des constantes
		public const string c_nomTable = "AUDITVERSIONOBJECTOP";
		public const string c_champId = "AUDTVOO_ID";

		public const string c_champChamp = "AUDTVOO_CHAMP";
		public const string c_champTypeChamp = "AUDTVOO_TYPECHAMP";
		public const string c_champNomConvivialChamp = "AUDTVOO_FIELDFRIENDLYNAME";
		public const string c_champOperation = "AUDTVOO_TPOP";
		public const string c_champTypeValChamp = "AUDTVOO_TYPEVALCHAMP";
		public const string c_champTypeIDiffBlob = "AUDTVOO_TYPEIDIFFBLOB";
		public const string c_champCodeOperation = "AUDTVOO_OPCODE";
		public const string c_champEditTime = "AUDTVOO_EDIT_TIME";


		
		public const string c_champValVersionSourceString = "AUDTVOO_VALVSRCSTRING";
		public const string c_champValVersionSourceBlob= "AUDTVOO_VALVSRCBLOB";

		public const string c_champValVersionCibleString = "AUDTVOO_VALVTARGETSTRING";
		public const string c_champValVersionCibleBlob = "AUDTVOO_VALVTARGETBLOB";

		public const string c_champNumOrdre = "AUDTVOO_ORDRE";

		#endregion

		//-------------------------------------------------------------------
		public CAuditVersionObjetOperation(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CAuditVersionObjetOperation(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Id.ToString();
		}


        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
			get { return I.T( "Audit Version Object Data|564"); }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champNumOrdre };
        }

        /// <summary>
        /// Objet de version d'audit concerné
        /// </summary>
		[Relation(
		CAuditVersionObjet.c_nomTable,
		CAuditVersionObjet.c_champId,
		CAuditVersionObjet.c_champId,
		true,
		true,
		true)]
		[DynamicField("Object version")]
		public CAuditVersionObjet VersionObjet
		{
			get
			{
				return (CAuditVersionObjet)GetParent(CAuditVersionObjet.c_champId, typeof(CAuditVersionObjet));
			}
			set
			{
				SetParent(CAuditVersionObjet.c_champId, value);
			}
		}

		public IChampPourVersion Champ
		{
			get
			{

				IJournaliseurDonneesChamp journaliseur = CGestionnaireAChampPourVersion.GetJournaliseur(TypeChamp);
				if(journaliseur != null)
					return journaliseur.GetChamp(this);
				return null;
			}
			set
			{
				if (value == null)
				{
					FieldKey = "";
					TypeChamp = "";
					NomChampConvivial = "";
				}
				else
				{
					FieldKey = value.FieldKey;
					TypeChamp = value.TypeChampString;
					NomChampConvivial = value.NomConvivial;
				}
			}
		}

		//---------------------------------------------
        /// <summary>
        /// Type de la donnée associée (sous la forme string)
        /// </summary>
		[TableFieldProperty(CAuditVersionObjetOperation.c_champTypeValChamp, 1024)]
		[DynamicField("Value type")]
		public string TypeValeurString
		{
			get
			{
				return (string)Row[c_champTypeValChamp];
			}
			set
			{
				Row[c_champTypeValChamp] = value;
			}
		}

		//---------------------------------------------
		[TableFieldProperty(CAuditVersionObjetOperation.c_champTypeIDiffBlob, 1024)]
		public string IDifferencesBlobType
		{
			get
			{
				return (string)Row[c_champTypeIDiffBlob];
			}
			set
			{
				Row[c_champTypeIDiffBlob] = value;
			}
		}

		//---------------------------------------------
		[TableFieldProperty(CAuditVersionObjetOperation.c_champCodeOperation, NullAutorise = true)]
		public int? CodeOperation
		{
			get
			{
				return (int?)Row[c_champCodeOperation, true];
			}
			set
			{
				Row[c_champCodeOperation, true] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Date et heure à laquelle a eu lieu l'opération
		/// </summary>
		[TableFieldProperty(c_champEditTime, true)]
		[DynamicField("Edit time")]
		public DateTime? TimeStampModification
		{
			get
			{
				return (DateTime?)Row[c_champEditTime, true];
			}
			set
			{
				Row[c_champEditTime, true] = value;
			}
		}



		//---------------------------------------------
        /// <summary>
        /// Code de l'opération effectuée sur l'objet :<br/>
        /// <ul>
        /// <li> 0 : ajout</li>
        /// <li>10 : suppression</li>
        /// <li>20 : modification</li>
        /// <li>30 : aucune</li>
        /// </ul>
        /// </summary>
		[TableFieldProperty(CAuditVersionObjetOperation.c_champOperation)]
		[DynamicField("Operation type code")]
		public int CodeTypeOperation
		{
			get
			{
				return (int)Row[c_champOperation];
			}
			set
			{
				Row[c_champOperation] = value;
			}
		}

		//---------------------------------------------
        /// <summary>
        /// Type de l'opération effectuée sur l'objet (cf. 'Operation type code')
        /// </summary>
		[DynamicField("Operation type")]
		public CTypeOperationSurObjet TypeOperation
		{
			get
			{
				return new CTypeOperationSurObjet((CTypeOperationSurObjet.TypeOperation)CodeTypeOperation);
			}
			set
			{
				if (value != null)
					CodeTypeOperation = value.CodeInt;
			}
		}



		//CHAMP VERSION SOURCE
		public object ValeurSource
		{ 
			get
			{
				return CUtilStockageValeurChamp.GetValeur(Row, c_champValVersionSourceString, c_champValVersionSourceBlob, c_champTypeValChamp, ContexteDonnee);
			}
			set
			{
				CUtilStockageValeurChamp.StockValeur(Row, ContexteDonnee.IdSession, c_champTypeValChamp, c_champValVersionSourceBlob, c_champValVersionSourceString, value);
			}
		}

        /// <summary>
        /// Valeur du champ sur la source (sous forme string)
        /// </summary>
		[TableFieldProperty(c_champValVersionSourceString, 4000, NullAutorise = true)]
		[DynamicField("Source value string")]
		public string ValChampSourceString
		{
			get
			{
				if (Row[c_champValVersionSourceString] == DBNull.Value)
					return null;
				return (string)Row[c_champValVersionSourceString];
			}
			set
			{
				Row[c_champValVersionSourceString, true] = value;
			}
		}
		[TableFieldProperty(c_champValVersionSourceBlob, NullAutorise = true)]
		public CDonneeBinaireInRow ValChampSourceBlob
		{
			get
			{
				if (Row[c_champValVersionSourceBlob] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champValVersionSourceBlob);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champValVersionSourceBlob, donnee);
				}
				object obj = Row[c_champValVersionSourceBlob];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champValVersionSourceBlob] = value;
			}
		}

		//CHAMP VERSION CIBLE
		public object ValeurCible
		{
			get
			{
				return CUtilStockageValeurChamp.GetValeur(Row, c_champValVersionCibleString, c_champValVersionCibleBlob, c_champTypeValChamp, ContexteDonnee);
			}
			set
			{
				CUtilStockageValeurChamp.StockValeur(Row, ContexteDonnee.IdSession, c_champTypeValChamp, c_champValVersionCibleBlob, c_champValVersionCibleString, value);
			}
		}


        /// <summary>
        /// Valeur du champ sur la cible (sous forme string)
        /// </summary>
		[TableFieldProperty(c_champValVersionCibleString, 4000, NullAutorise= true)]
		[DynamicField("Target value string")]
		public string ValChampCibleString
		{
			get
			{
				if (Row[c_champValVersionCibleString] == DBNull.Value)
					return null;
				return (string)Row[c_champValVersionCibleString];
			}
			set
			{
				Row[c_champValVersionCibleString, true] = value;
			}
		}
		[TableFieldProperty(c_champValVersionCibleBlob, NullAutorise = true)]
		public CDonneeBinaireInRow ValChampCibleBlob
		{
			get
			{
				if (Row[c_champValVersionCibleBlob] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champValVersionCibleBlob);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champValVersionCibleBlob, donnee);
				}
				object obj = Row[c_champValVersionCibleBlob];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(  Row.Row );
			}
			set
			{
				Row[c_champValVersionCibleBlob] = value;
			}
		}


		/// <summary>
		/// Numéro d'ordre de l'opération dans la liste des opérations de l'audit
		/// </summary>
		[TableFieldProperty(c_champNumOrdre)]
		[DynamicField("Sort order")]
		public int NumeroOrdre
		{
			get
			{
				return (int)Row[c_champNumOrdre];
			}
			set
			{
				Row[c_champNumOrdre] = value;
			}
		}

		#region IElementAChampPourVersion
        /// <summary>
        /// Champ concerné par l'opération. Renvoie le nom du champ<br/>
        /// ou son Id, suivant qu'il s'agit d'un champ natif TIMOS ou <br/>
        /// d'un champ personnalisé.
        /// </summary>
		[TableFieldProperty(c_champChamp, 255)]
		[DynamicField("Field")]
		public string FieldKey
		{
			get
			{
				return (string)Row[c_champChamp];
			}
			set
			{
				Row[c_champChamp] = value;
			}
		}

        /// <summary>
        /// Type du champ (sous forme string) :
        /// <ul>
        /// <li>DB_FIELD, pour un champ natif TIMOS</li>
        /// <li>CUST_FIELD, pour un champ personnalisé</li>
        /// </ul>
        /// </summary>
		[TableFieldProperty(c_champTypeChamp, 255)]
		[DynamicField("Field type")]
		public string TypeChamp
		{
			get
			{
				return (string)Row[c_champTypeChamp];
			}
			set
			{
				Row[c_champTypeChamp] = value;
			}
		}
		public Type TypeEntite
		{
			get
			{
				if (VersionObjet != null)
					return VersionObjet.TypeElement;
				return null;
			}
		}

		#endregion

        /// <summary>
        /// Nom convivial du champ
        /// </summary>
		[TableFieldProperty(c_champNomConvivialChamp, 255)]
		[DynamicField("Friendly Field Name")]
		public string NomChampConvivial
		{
			get
			{
				string str =(string)Row[c_champNomConvivialChamp];
				return str != null && str != "" ? str : FieldKey;
			}
			set
			{
				Row[c_champNomConvivialChamp] = value;
			}
		}
	}
}
