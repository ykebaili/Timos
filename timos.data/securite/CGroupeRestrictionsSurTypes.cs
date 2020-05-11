using System;
using System.Collections;
using System.IO;


using sc2i.data;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.multitiers.client;
using timos.acteurs;
using timos.data;

namespace timos.securite
{
	/// <summary>
	/// Un groupe de restrictions permet de restreindre l'accès aux objets de l'application.
    /// La restriction peut porter sur :
    /// <ul>
    /// <li>Une catégorie d'objet</li>
    /// <li>Un élément d'une catégorie d'objet</li>
    /// <li>Un formulaire d'une catégorie d'objet</li>
    /// </ul>
    /// Les restrictions possibles sont :
    /// <ul>
    /// <li>Ecriture interdite (Lecture seule)</li>
    /// <li>Masqué (Invisible)</li>
    /// <li>Création interdite</li>
    /// <li>Suppression interdite</li>
    /// </ul>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iProcess)]
    [DynamicClass("Restriction group")]
	[ObjetServeurURI("CGroupeRestrictionSurTypeServeur")]
	[FullTableSync]
	[Table(CGroupeRestrictionSurType.c_nomTable, CGroupeRestrictionSurType.c_champId,true)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_Restrictions_ID)]
    public class CGroupeRestrictionSurType : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		#region Déclaration des constantes
		public const string c_nomTable = "RESTRICTION_GROUP";
		public const string c_champId = "RESTGRP_ID";
		public const string c_champLibelle = "RESTGRP_LABEL";
		public const string c_champDescriptif = "RESTGRP_DESCRIPTION";
		public const string c_champData = "RESTGRP_DATA";

		public const string c_champPrioriteSeuilAnnulation = "RESTGRP_CANCEL_THRESHOLD";

		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CGroupeRestrictionSurType()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGroupeRestrictionSurType( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CGroupeRestrictionSurType( System.Data.DataRow row )
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
			return new string[]{c_champId};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Restriction group @1|294",Libelle);
				}
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Libellé du groupe de restriction
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


        

        //-----------------------------------------------------------
        /// <summary>
        /// Priorité du groupe de restriction. Lorsque plusieurs groupes de restriction<br/>
        /// sont combinés, cela peut permettre d'annuler l'effet des groupes de restriction de<br/>
        /// priorité inférieure.
        /// </summary>
		[TableFieldProperty(c_champPrioriteSeuilAnnulation, NullAutorise = true)]
        [DynamicField("Priority")]
        public int ? SeuilAnnulationPriorites
        {
            get
            {
				return (int?)Row[c_champPrioriteSeuilAnnulation, true];
            }
            set
            {
                Row[c_champPrioriteSeuilAnnulation, true] = value;
            }
        }




		//-------------------------------------------------------------------
        /// <summary>
        /// Descriptif
        /// </summary>
		[
		TableFieldProperty(c_champDescriptif, 1024),
		DynamicField("Descriptif")
		]
		public string Descriptif
		{
			get
			{
				return (string)Row[c_champDescriptif];
			}
			set
			{
				Row[c_champDescriptif] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champData,NullAutorise=true)]
		public CDonneeBinaireInRow Data
		{
			get
			{
				if ( Row[c_champData] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champData);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champData, donnee);
				}
				return ((CDonneeBinaireInRow)Row[c_champData]).GetSafeForRow ( Row.Row );
			}
			set
			{
				Row[c_champData] = value;
			}
		}


		/// /////////////////////////////////////////////////////////////
        [BlobDecoder]
        public CListeRestrictionsUtilisateurSurType ListeRestrictions
		{
			get
			{
				CListeRestrictionsUtilisateurSurType liste = new CListeRestrictionsUtilisateurSurType();
				if (SeuilAnnulationPriorites != null)
					liste.SeuilAnnulationPriorites = SeuilAnnulationPriorites;
				if ( Data.Donnees != null )
				{
					MemoryStream stream = new MemoryStream(Data.Donnees);
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
					CResultAErreur result = liste.Serialize(serializer);
					if ( !result )
					{
						liste = new CListeRestrictionsUtilisateurSurType();
					}
                    reader.Close();
                    stream.Close();

				}
				return liste;
			}
			set
			{
				if ( value == null )
				{
					CDonneeBinaireInRow data = Data;
					data.Donnees = null;
					Data = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter(stream);
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
					CResultAErreur result = value.Serialize ( serializer );
					if ( result )
					{
						CDonneeBinaireInRow data = Data;
						data.Donnees = stream.GetBuffer();
						Data = data;
					}
                    writer.Close();
                    stream.Close();
				}
			}
		}
	}
}
