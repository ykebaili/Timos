using System;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvEvenementReseauEtatServices.c_nomTable,CSpvEvenementReseauEtatServices.c_nomTableInDb,new string[]{ CSpvEvenementReseauEtatServices.c_champALARM2_ID})]
    [ObjetServeurURI("CSpvEvenementReseauEtatServicesServeur")]
	[DynamicClass("Event Services states")]
	public class	CSpvEvenementReseauEtatServices : CObjetDonneeAIdNumerique, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARM2";
		public const string c_nomTableInDb = "ALARM2";
		public const string c_champALARM2_ID ="ALARM2_ID";
		public const string c_champALARM2_TSPROPER ="ALARM2_TSPROPER";
		
		///////////////////////////////////////////////////////////////
		public CSpvEvenementReseauEtatServices( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvEvenementReseauEtatServices( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champALARM2_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return ("Services states");
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Liste des etats opérationnels
        /// Chaque état est séparé par des ;
        /// un enregistrement est composé de l'ID du service,
        /// Ancien état op, Nouvel etat op, etat de masquage
		/// </summary>
        [TableFieldProperty(c_champALARM2_TSPROPER,900)]
		public System.String TsProgsOper
		{
			get
			{
				if (Row[c_champALARM2_TSPROPER] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM2_TSPROPER];
			}
		}

        public List<CInfoEtatService> EtatsServices
        {
            get
            {
                return DecodeEtatsServices();
            }
        }

        private List<CInfoEtatService> DecodeEtatsServices()
        {
            List<CInfoEtatService> listeEtat = new List<CInfoEtatService>();
            if (Row[c_champALARM2_TSPROPER] != DBNull.Value)
            {
                string [] strEtatsServices = ((string)Row[c_champALARM2_TSPROPER]).Split(';');
                
                int nId;
                EEtatOperationnelService etatAvant;
                EEtatOperationnelService etatApres;
                EEtatMasquageService etatMasquage;

                foreach (string strEtatsUnServiceChaine in strEtatsServices)
                {
                    nId = -1;
                    etatAvant = EEtatOperationnelService.OK;
                    etatApres = EEtatOperationnelService.OK;
                    etatMasquage = EEtatMasquageService.NomMasque;

                    string [] strEtatsUnService = strEtatsUnServiceChaine.Split(',');
                    int nLen = strEtatsUnService.Length;
                    if (nLen >= 1)
                        nId = Convert.ToInt32(strEtatsUnService[0]);
                    if (nLen >= 2)
                        etatAvant = (EEtatOperationnelService) Convert.ToInt32(strEtatsUnService[1]);
                    if (nLen >= 3)
                        etatApres = (EEtatOperationnelService) Convert.ToInt32(strEtatsUnService[2]);
                    if (nLen >= 4)
                        etatMasquage = (EEtatMasquageService) Convert.ToInt32(strEtatsUnService[3]);
                
                    if (nId > 0)
                        listeEtat.Add(new CInfoEtatService(nId, etatAvant, etatApres, etatMasquage));
                }
            }
            return listeEtat;
        }


        [Relation(CSpvEvenementReseau.c_nomTable, new string[] { CSpvEvenementReseau.c_champALARM_ID }, new string[] { CSpvEvenementReseauEtatServices.c_champALARM2_ID }, false, true)]
        [DynamicField("Alarm event")]
        public CSpvEvenementReseau SpvAlarmeEvenement
        {
            get
            {
                return (CSpvEvenementReseau)GetParent(new string[] { c_champALARM2_ID }, typeof(CSpvEvenementReseau));
            }
            set
            {
                SetParent(new string[] { c_champALARM2_ID }, value);
            }
        }
	}
}
