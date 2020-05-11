using System;
using System.Data;
using System.Drawing;
using System.IO;

using sc2i.data;
using sc2i.common;


using sc2i.multitiers.client;

#if !PDA_DATA

namespace sc2i.workflow
{
	/// <summary>
    /// Rôle pour <see cref="CEntreeAgenda">entrée d'agenda</see>.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [DynamicClass("Diary role")]
	[Table(CRoleSurEntreeAgenda.c_nomTable, CRoleSurEntreeAgenda.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRoleSurEntreeAgendaServeur")]
	public class CRoleSurEntreeAgenda : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete, IRoleSurEntreeAgenda
	{
		public const string c_nomTable = "DIARY_ROLE";
		public const string c_champId = "DIRO_ID";
		public const string c_champLibelle = "DIRO_LABEL";
		public const string c_champCode = "DIRO_CODE";
		public const string c_champDescriptif = "DIRO_DESCRIPTION";
		public const string c_champImage = "DIRO_IMAGE";

		/// /////////////////////////////////////////////////////////
		public CRoleSurEntreeAgenda( CContexteDonnee ctx)
			:base ( ctx )
		{
			
		}

		/// /////////////////////////////////////////////////////////
		public CRoleSurEntreeAgenda ( DataRow row )
			:base (row)
		{
		}

		/// /////////////////////////////////////////////////////////
		protected  override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////////////////
		public string IdRole
		{
			get
			{
				return "ROLE_IN_DB_" + Id.ToString();
			}
		}

		/// /////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		/// /////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Diary role @1|340", Libelle);
			}
		}

		//------------------------------------------------------
        /// <summary>
        /// Donne ou définit le libellé du rôle
        /// </summary>
		[DynamicField("Label")]
		[TableFieldProperty(c_champLibelle,255)]
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

		//-------------------------------------------------------
        /// <summary>
        /// Donne ou définit le code affecté au rôle
        /// </summary>
		[DynamicField("Code")]
		[TableFieldProperty(c_champCode,64)]
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

		//-----------------------------------------------
        /// <summary>
        /// Donne ou définit la description du rôle
        /// </summary>
		[DynamicField("Description")]
		[TableFieldProperty(c_champDescriptif,1024)]
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

		/// /////////////////////////////////////////////////////////
		[TableFieldProperty(c_champImage,NullAutorise=true)]
		public CDonneeBinaireInRow DataImage
		{
			get
			{
				if ( Row[c_champImage] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champImage);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champImage, donnee);
				}
				object obj = Row[c_champImage];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champImage] = value;
			}
		}

		/// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public Bitmap Image
		{
			get
			{
				CDonneeBinaireInRow data = DataImage;
				if ( data != null && data.Donnees !=  null)
				{
					Stream stream = new MemoryStream( data.Donnees );
					try
					{
						Bitmap image = (Bitmap)Bitmap.FromStream (stream );
						return image;
					}
					catch
					{
					}
				}
				return null;
			}
			set
			{
				if ( value == null )
				{
					CDonneeBinaireInRow data = DataImage;
					data.Donnees = null;
					DataImage = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					try
					{
						value.Save ( stream, System.Drawing.Imaging.ImageFormat.Gif );
						CDonneeBinaireInRow data = DataImage;
						data.Donnees = stream.GetBuffer();
						DataImage = data;
					}
					catch
					{
						CDonneeBinaireInRow data = DataImage;
						data.Donnees = null;
						DataImage = data;
					}
				}
			}
		}
		
	}
}
#endif