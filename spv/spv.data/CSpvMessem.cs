using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvMessem.c_nomTable,CSpvMessem.c_nomTableInDb,new string[]{ CSpvMessem.c_champMESSEM_ID})]
	[ObjetServeurURI("CSpvMessemServeur")]
	[DynamicClass("Spv Message for EM")]
    [InsertEnFin]
	public class	CSpvMessem : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_MESSEM";
		public const string c_nomTableInDb = "MESSEM";
		public const string c_champMESSEM_ID ="MESSEM_ID";
		public const string c_champMESSEM_DATE ="MESSEM_DATE";
		public const string c_champMESSEM_MESS ="MESSEM_MESS";

		// Code objet pour les messages d'alarme
		public const string c_SITE = "S";
		public const string c_EQUIP = "E";
		public const string c_LIAISON = "L";
		///////////////////////////////////////////////////////////////
		public CSpvMessem( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvMessem( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
			DateMessage = CDivers.GetSysdateNotNull();//DateTime.Now.Date;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champMESSEM_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("EM message @1|30031", Id.ToString());
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMESSEM_DATE)]
		[DynamicField("Date")]
		public System.DateTime DateMessage
		{
			get
			{
				return (System.DateTime)Row[c_champMESSEM_DATE];
			}
			set
			{
				Row[c_champMESSEM_DATE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMESSEM_MESS,256)]
		[DynamicField("Message")]
		public System.String Message
		{
			get
			{
				return (System.String)Row[c_champMESSEM_MESS];
			}
			set
			{
				Row[c_champMESSEM_MESS,true]=value;
			}
		}

        /// <summary>
        /// Construction du message suite à modification d'un type d'équipement
        /// </summary>
        /// <param name="typeqID"></param>
        /// <param name="typeqToSurv"></param>
         public void FormatMessModTypeq (Int32 typeqID, bool typeqToSurv)
        {
            Message = string.Format("#9#7#7#M#{0}#{1}#", typeqID, (typeqToSurv == true) ? 1 : 0);
        }

        /// <summary>
        /// Construction du message suite à suppression d'un type d'équipement
        /// </summary>
        /// <param name="typeqID"></param>
        public void FormatMessDelTypeq(Int32 typeqID)
        {
            Message = string.Format("#9#6#7#S#{0}#", typeqID);
        }


        /// <summary>
        /// Construction du message à la création d'un site
        /// </summary>
        /// <param name="siteId">ID du site</param>
        public void FormatMessCreSite(int siteId)
        {
            Message = string.Format("#9#6#6#C#{0}#", siteId);
        }

        /// <summary>
        /// Construction du message à la modification d'un site (sous conditions)
        /// </summary>
        /// <param name="siteId">ID du site</param>
        public void FormatMessModSite(int siteId)
        {
            Message = string.Format("#9#6#6#M#{0}#", siteId);
        }

        public void FormatMessDelSite(int siteId)
        {
            Message = string.Format("#9#6#6#S#{0}#", siteId);
        }


		/// <summary>
		/// Construction du message suite à la création d'un équipement
		/// </summary>
		/// <param name="equipId">ID de l'équipement</param>
		/// <param name="equipToSurv">Indicateur d'équipement à surveiller ou non</param>
		public void FormatMessCreEquip(int equipId)
		{
			Message = string.Format("#9#6#1#C#{0}#", equipId);
		}

        /// <summary>
        /// Construction du message suite modificqation d'un équipement
        /// </summary>
        /// <param name="equipId"></param>
        /// <param name="equipToSurv"></param>
        public void FormatMessModEquip(Int32 equipId, bool equipToSurv)
        {
            Message = string.Format("#9#6#1#{0}#{1}#", (equipToSurv == true) ? "C" : "S", equipId);
        }

        /// <summary>
        /// Construction du message suite à suppression de l'équipement
        /// </summary>
        /// <param name="equipId">ID de l'équipempent</param>
        /// <param name="addrIP">Son adresse IP</param>
        /// <param name="emName">Nom de l'équipement de médiation qui en a la surveillance</param>
        /// <param name="bSurv">Indicateur de surveillance</param>
        /// retourne true si le message est à créer, false sinon
        public void FormatMessDelEquip(Int32 equipId, string addrIP, string emName, bool bSurv)
        {
            Message = string.Format("#9#9#1#S#{0}#{1}#{2}#{3}#", equipId, (bSurv == true) ? 1 : 0, addrIP, emName);
        }

		public bool FormatMessAccesAlarme (CSpvLienAccesAlarme spvLienAccesAlarme, DataRowState rowState)
		{
			Int32 nIdTypeCARTE_GTR = 0, nIdTypeIP2PORT = 0, nIdTypeGSITE = 0;
			string strCategorieObjet = "";
			Int32 nIdObjet = 0;
			bool bEquipToSurv = false;
			string strCodeSaisie;
			string strAddrIP;

            if (rowState == DataRowState.Added)
                strCodeSaisie = "C";
            else if (rowState == DataRowState.Modified)
                strCodeSaisie = "M";
            else if (rowState == DataRowState.Deleted)
                strCodeSaisie = "S";
            else
                throw new Exception(I.T("DataRowState not provided for this function|50010"));
			

			CSpvTypeq spvTypeq = new CSpvTypeq (ContexteDonnee);

			if (spvTypeq.ReadIfExists(new CFiltreData (CSpvTypeq.c_champTYPEQ_NOM + "=@1", CSpvTypeq.c_CARTE_GTR)))
				nIdTypeCARTE_GTR = spvTypeq.Id;

			if (spvTypeq.ReadIfExists(new CFiltreData (CSpvTypeq.c_champTYPEQ_NOM + "=@1", CSpvTypeq.c_GSITE)))
				nIdTypeGSITE = spvTypeq.Id;

			if (spvTypeq.ReadIfExists(new CFiltreData (CSpvTypeq.c_champTYPEQ_NOM + "=@1", CSpvTypeq.c_IP2PORT)))
				nIdTypeIP2PORT = spvTypeq.Id;

            CSpvAccesAlarme accesOne, accesTwo;
            accesOne = spvLienAccesAlarme.AccesAlarmeOne;
            accesTwo = spvLienAccesAlarme.AccesAlarmeTwo;
            CSpvEquip spvEqt = spvLienAccesAlarme.SpvEquip;
            CSpvSite spvSite = spvLienAccesAlarme.SpvSite;
            CSpvLiai spvLiai = spvLienAccesAlarme.SpvLiai;
            if (rowState == DataRowState.Deleted)
            {
                if (accesOne.Row.RowState == DataRowState.Deleted)
                    accesOne.VersionToReturn = DataRowVersion.Original;

                if (accesTwo.Row.RowState == DataRowState.Deleted)
                    accesTwo.VersionToReturn = DataRowVersion.Original;

                if (spvEqt != null && spvEqt.Row.RowState == DataRowState.Deleted)
                    spvEqt.VersionToReturn = DataRowVersion.Original;

                if (spvSite != null && spvSite.Row.RowState == DataRowState.Deleted)
                    spvSite.VersionToReturn = DataRowVersion.Original;

                if (spvLiai != null && spvLiai.Row.RowState == DataRowState.Deleted)
                    spvLiai.VersionToReturn = DataRowVersion.Original;
            }

			if (accesOne == spvLienAccesAlarme.SpvAccesAlarmeSysteme0())
			{
				// Dans ce cas, seul le cas GSITE nous intéresse
				CSpvEquip spvEquip = new CSpvEquip(ContexteDonnee);
				if (spvEquip.ReadIfExists(new CFiltreData(CSpvEquip.c_champEQUIP_ID + "=@1", spvLienAccesAlarme.BindingId)))
				{
					if (spvEquip.TypeEquipement.Id != nIdTypeGSITE)
						return false;
					else
						bEquipToSurv = spvEquip.ASuperviser;
				}
			}
			else
			{
				if (spvSite != null)
				{
					strCategorieObjet = c_SITE;
					nIdObjet = spvSite.Id;
					bEquipToSurv = true;
				}
				else if (spvLiai != null)
				{
					strCategorieObjet = c_LIAISON;
					nIdObjet = spvLiai.Id;
					bEquipToSurv = true;
				}
                else if (spvEqt != null)
				{
					strCategorieObjet = c_EQUIP;
					nIdObjet = spvEqt.Id;
                    bEquipToSurv = spvEqt.ASuperviser;
                    strAddrIP = spvEqt.AdresseIP;
				}
				else
					throw new Exception(I.T("Father object not filled|50009"));
			}

			if (!bEquipToSurv)
				return false;

			string strMess = "";

            if (accesOne == spvLienAccesAlarme.SpvAccesAlarmeSysteme0())
			{
				// Concerne un accès alarme GSITE

				if (rowState == DataRowState.Deleted)
				{
					strMess = string.Format("#9#7#5#S#{0}#{1}#",
						spvLienAccesAlarme.BindingId,
                        spvEqt.CommentairePourSituer);
				}
				else
				{
					strMess = string.Format("#9#11#5#{0}#{1}#{2}#{3}#{4}#{5}#{6}#",
						strCodeSaisie, spvLienAccesAlarme.BindingId,
                        spvEqt.CommentairePourSituer,
						spvLienAccesAlarme.DureeMin, spvLienAccesAlarme.FreqNb,
						spvLienAccesAlarme.FreqPeriod, System.Convert.ToInt32(spvLienAccesAlarme.Surveiller));
				}
			}
            else if (accesTwo == spvLienAccesAlarme.SpvAccesAlarmeSysteme0())
			{
				// Concerne un accès alarme TRAP
				if (rowState == DataRowState.Deleted)
					strMess = string.Format("#9#8#5#S#{0}#{1}#{2}#",
                        spvEqt.AdresseIP,
                        spvEqt.Id, accesOne.TrapIdent);
				else
					strMess = string.Format("#9#12#4#{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#",
                        strCodeSaisie, spvEqt.AdresseIP,
                        spvEqt.Id,
						accesOne.TrapIdent,
						spvLienAccesAlarme.DureeMin, spvLienAccesAlarme.FreqNb,
                        spvLienAccesAlarme.FreqPeriod, System.Convert.ToInt32(spvLienAccesAlarme.Surveiller));
			}
			else if (accesTwo != null &&
				accesTwo != spvLienAccesAlarme.SpvAccesAlarmeSysteme0())
			{
				// Concerne un accès alarme de type boucle

				// La donnée "A surveiller" a-t-elle changée
                bool bSurveillanceChangee =
                    (rowState == DataRowState.Added && spvLienAccesAlarme.Surveiller) ||
                (rowState == DataRowState.Modified &&
                (bool)spvLienAccesAlarme.Row[CSpvLienAccesAlarme.c_champALARMGEREE_TOSURV,
                    DataRowVersion.Original] != spvLienAccesAlarme.Surveiller);

				if (accesTwo.SpvEquip.TypeEquipement.Id == nIdTypeCARTE_GTR)
				{
					// Le nom de l'équipement de collecte est de la forme
					// IS xx/GTR yy
					string strNomEquipCollecte =
                        accesTwo.SpvEquip.CommentairePourSituer;

					if (rowState == DataRowState.Deleted)
						strMess = string.Format("#9#9#2#S#{0}#{1}#{2}#{3}#",
							strCategorieObjet, nIdObjet,
							strNomEquipCollecte.Substring(3, 2),
							((Convert.ToInt32(strNomEquipCollecte.Substring(10, 2)) -1) * 48) +
							Convert.ToInt32(accesTwo.NomAcces));
					else if (bSurveillanceChangee)
						strMess = string.Format("#9#10#2#{0}#{1}#{2}#{3}#{4}#{5}#",
							strCodeSaisie, strCategorieObjet, nIdObjet,
							strNomEquipCollecte.Substring(3, 2),
							((Convert.ToInt32(strNomEquipCollecte.Substring(10, 2)) -1) * 48) +
							Convert.ToInt32(accesTwo.NomAcces),
                            System.Convert.ToInt32(spvLienAccesAlarme.Surveiller));
				}
				else
				{
					// IP2PORT ou IP2CHOICE ou autre EDC boucle de type IP (ex: NEC)
					if (rowState == DataRowState.Deleted)
						strMess = string.Format("#9#10#3#S#{0}#{1}#{2}#{3}#{4}#",
							strCategorieObjet, nIdObjet,
							accesTwo.SpvEquip.AdresseIP,
							accesTwo.SpvEquip.Id,
                            accesTwo.NomAcces);
					else
						strMess = string.Format("#9#14#3#{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}#",
							strCodeSaisie, strCategorieObjet, nIdObjet,
							accesTwo.SpvEquip.AdresseIP,
							accesTwo.SpvEquip.Id,
							accesTwo.NomAcces,
							spvLienAccesAlarme.DureeMin, spvLienAccesAlarme.FreqNb,
                            spvLienAccesAlarme.FreqPeriod, System.Convert.ToInt32(spvLienAccesAlarme.Surveiller));

							
				}
				
						
			}

			Message = strMess;
            return true;
		}
	}
}
