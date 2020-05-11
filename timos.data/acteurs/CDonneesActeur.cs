using System;
using sc2i.data;
using sc2i.common;
using tiag.client;

namespace timos.acteurs
{
	/// <summary>
	/// Donn�es acteur
	/// </summary>
	[RechercheRapide("Acteur.Nom")]
	public abstract class CDonneesActeur : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		public const string c_champIsDonneeValide = "DATA_IS_VALID";

#if PDA
		//-------------------------------------------------------------------
		public CDonneesActeur()
			:base()
		{
		}
#endif
		public CDonneesActeur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CDonneesActeur( System.Data.DataRow row )
			:base(row)
		{
		}

		protected override void MyInitValeurDefaut()
		{
			Row[c_champIsDonneeValide] = false;
		}

        /// <summary>
		/// Utilis� par TIAG pour affecter l'acteur parent par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetMemberKeys(object[] lstCles)
		{
			CActeur acteur = new CActeur(ContexteDonnee);
			if (acteur.ReadIfExists(lstCles))
				Acteur = acteur;
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// Acteur li� aux donn�es
		/// </summary>
		[Relation(CActeur.c_nomTable,CActeur.c_champId,CActeur.c_champId,true,true)]
		[DynamicField("Member")]
		[TiagRelation(typeof(CActeur), "TiagSetMemberKeys")]
		public virtual CActeur Acteur
		{
			get
			{
				CActeur acteur = new CActeur(ContexteDonnee);
				acteur.Id = (int) Row[CActeur.c_champId];
				return acteur;
			}
			set
			{
				AssureExiste(value);
				Row[CActeur.c_champId] = value.Id;
			}
		}

		/// ////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{GetChampId()};
		}


		/// ////////////////////////////////////////////////////////////////////
		public override CFiltreData FiltreStandard
		{
			get
			{
				///Il y a avait un filtre avanc�
				/*
				CFiltreData filtre = new CFiltreDataAvance(
					GetNomTable(),
					c_champIsDonneeValide+"=@1", true);
				return filtre;*/
				return new CFiltreData ( c_champIsDonneeValide+"=@1", true );
			}
		}

		 ////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Bool�en indiquant si les donn�es sont valides ou non
		/// </summary>
		[TableFieldProperty(c_champIsDonneeValide)]
		[DynamicField("Is valid data")]
		public bool IsDonneeActeurValide
		{
			get
			{
				return (bool)Row[c_champIsDonneeValide];
			}
			set
			{
				Row[c_champIsDonneeValide] = value;
			}
		}


	}
}
