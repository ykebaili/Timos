using System;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvEvenementReseauConcernes.c_nomTable,CSpvEvenementReseauConcernes.c_nomTableInDb,new string[]{ CSpvEvenementReseauConcernes.c_champALARM3_ID})]
    [ObjetServeurURI("CSpvEvenementReseauConcernesServeur")]
	[DynamicClass("Event concerned elements")]
	public class	CSpvEvenementReseauConcernes : CObjetDonneeAIdNumerique, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARM3";
		public const string c_nomTableInDb = "ALARM3";
		public const string c_champALARM3_ID ="ALARM3_ID";
		public const string c_champALARM3_CLICONC ="ALARM3_CLICONC";
		public const string c_champALARM3_PRCONC ="ALARM3_PRCONC";
		public const string c_champALARM3_PRETAT ="ALARM3_PRETAT";
		public const string c_champALARM3_SITENOM ="ALARM3_SITENOM";
		public const string c_champALARM3_TYPEQ ="ALARM3_TYPEQ";
		public const string c_champALARM3_EQTG ="ALARM3_EQTG";
		public const string c_champALARM3_FELTG ="ALARM3_FELTG";
		public const string c_champALARM3_FALG ="ALARM3_FALG";
        public const string c_champALARM3_ELTSITEID = "ALARM3_ELTSITEID";
        public const string c_champALARM3_ELTTYPEID = "ALARM3_ELTTYPEID";
        public const string c_champALARM3_ELTID = "ALARM3_ELTID";
        public const string c_champALARM3_ELTCLASSE = "ALARM3_ELTCLASSE";
		
		///////////////////////////////////////////////////////////////
		public CSpvEvenementReseauConcernes( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvEvenementReseauConcernes( DataRow row )
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
			return new string[] {c_champALARM3_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return "l'élement de type "+GetType().ToString();
			}
		}
		
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Noms des clients concernés séparés par des ;
		/// </summary>
        public System.Int32[] ClientsConcernes
        {
            get
            {
                List<System.Int32> clientsId = new List<System.Int32>();
                if (Row[c_champALARM3_CLICONC] != DBNull.Value)
                {
                    String[] strClientsId = ((System.String)Row[c_champALARM3_CLICONC]).Split(';');
                    foreach (string strClientId in strClientsId)
                        if (strClientId.Length > 0)
                            clientsId.Add(Convert.ToInt32(strClientId));

                }
                return clientsId.ToArray();
            }
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARM3_PRCONC,1000)]
        [DynamicField("Concerned services")]
		public System.Int32[] ServicesConcernes
		{
			get
			{
                List<System.Int32> servicesId = new List<System.Int32>();
				if (Row[c_champALARM3_PRCONC] != DBNull.Value)
                {
                    String[] strServices = ((System.String)Row[c_champALARM3_PRCONC]).Split(';');
                    foreach (string strService in strServices)
                    {
                        if (strService.Length > 0)
                            servicesId.Add(Convert.ToInt32(strService));
                    }
                }
                return servicesId.ToArray();
			}	
		}

		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARM3_PRETAT,100)]
        [DynamicField("Services Operational state")]
        public double[] EtatOperationnelServices
		{
			get
			{
                List<double> servicesEtat = new List<double>();
                if (Row[c_champALARM3_PRETAT] != DBNull.Value)
                {
                    String[] strServicesEtat = 
                        ((System.String)Row[c_champALARM3_PRETAT]).Split(new char[] { ';' },
                          StringSplitOptions.RemoveEmptyEntries);
                    foreach (string strServiceEtat in strServicesEtat)
                        if (strServiceEtat.Length > 0)
                            servicesEtat.Add(Convert.ToDouble(strServiceEtat));
                }

                return servicesEtat.ToArray();
			}
		}


        [TableFieldProperty(c_champALARM3_ELTSITEID, NullAutorise=true)]
        [DynamicField("Network element site id")]
        public System.Int32? ElementGereIdSite
        {
            get
            {
                if (Row[c_champALARM3_ELTSITEID] == DBNull.Value)
                    return null;
                return (System.Int32)Row[c_champALARM3_ELTSITEID];
            }
        }


        [DynamicField("Network element site name")]
        public string ElementGereNomSite
        {
            get
            {
                if (ElementGereIdSite != null)
                {
                    CSpvSite spvSite = new CSpvSite(this.ContexteDonnee);
                    if (spvSite.ReadIfExists((int)ElementGereIdSite))
                        return spvSite.SiteNom;
                }
                return null;
            }
        }


        [TableFieldProperty(c_champALARM3_ELTTYPEID, NullAutorise = true)]
        [DynamicField("Network element type id")]
        public System.Int32? ElementGereIdType
        {
            get
            {
                if (Row[c_champALARM3_ELTTYPEID] == DBNull.Value)
                    return null;
                return (System.Int32)Row[c_champALARM3_ELTTYPEID];
            }
        }

        [DynamicField("Network element type name")]
        public string ElementGereNomType
        {
            get
            {
                if (ElementGereIdType != null)
                {
                    if (ElementGereClasse == EClasseObjetEnAlarme.Equipement)
                    {
                        CSpvTypeq spvTypeq = new CSpvTypeq(this.ContexteDonnee);
                        if (spvTypeq.ReadIfExists((int)ElementGereIdType))
                            return spvTypeq.Libelle;
                    }
                    else if (ElementGereClasse == EClasseObjetEnAlarme.Site)
                    {
                        CSpvTypsite spvTypsite = new CSpvTypsite(this.ContexteDonnee);
                        if (spvTypsite.ReadIfExists((int)ElementGereIdType))
                            return spvTypsite.TypeSiteNom;
                    }
                    else if (ElementGereClasse == EClasseObjetEnAlarme.Liaison)
                    {
                        CSpvTypliai spvTypliai = new CSpvTypliai(this.ContexteDonnee);
                        if (spvTypliai.ReadIfExists((int)ElementGereIdType))
                            return spvTypliai.Libelle;
                    }
                }
                return null;
            }
        }


        [TableFieldProperty(c_champALARM3_ELTID, NullAutorise = true)]
        [DynamicField("Network element id")]
        public System.Int32 ElementGereId
        {
            get
            {
                return (System.Int32)Row[c_champALARM3_ELTID];
            }
        }


        [DynamicField("Network element name")]
        public string ElementGereNom
        {
            get
            {
                if (ElementGereClasse == EClasseObjetEnAlarme.Equipement)
                {
                    CSpvEquip spvEquip = new CSpvEquip(this.ContexteDonnee);
                    if (spvEquip.ReadIfExists(ElementGereId))
                        return spvEquip.CommentairePourSituer;
                }
                else if (ElementGereClasse == EClasseObjetEnAlarme.Liaison)
                {
                    CSpvLiai spvLiai = new CSpvLiai(this.ContexteDonnee);
                    if (spvLiai.ReadIfExists(ElementGereId))
                        return spvLiai.NomComplet;
                }
                else if (ElementGereClasse == EClasseObjetEnAlarme.Site)
                {
                    CSpvSite spvSite = new CSpvSite(this.ContexteDonnee);
                    if (spvSite.ReadIfExists(ElementGereId))
                        return spvSite.SiteNom;
                }
                return null;
            }
        }


        [TableFieldProperty(c_champALARM3_ELTCLASSE, Longueur = 40, NullAutorise = true)]
        [DynamicField("Network table element")]
        public EClasseObjetEnAlarme ElementGereClasse
        {
            get
            {
                return (EClasseObjetEnAlarme)Row[c_champALARM3_ELTCLASSE];
            }
            set
            {
                Row[c_champALARM3_ELTCLASSE] = value;
            }
        }

        

		///////////////////////////////////////////////////////////////
        /*
		[TableFieldProperty(c_champALARM3_FELTG,2000)]
		public System.String ElementGereeFiche
		{
			get
			{
				if (Row[c_champALARM3_FELTG] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM3_FELTG];
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARM3_FALG,2000)]
		public System.String AlarmGereeFiche
		{
			get
			{
				if (Row[c_champALARM3_FALG] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM3_FALG];
			}	
		}
        */

        [Relation(CSpvEvenementReseau.c_nomTable, new string[] { CSpvEvenementReseau.c_champALARM_ID }, new string[] { CSpvEvenementReseauConcernes.c_champALARM3_ID }, false, true)]
        [DynamicField("Alarm event")]
        public CSpvEvenementReseau SpvAlarmeEvenement
        {
            get
            {
                return (CSpvEvenementReseau)GetParent(new string[] { c_champALARM3_ID }, typeof(CSpvEvenementReseau));
            }
            set
            {
                SetParent(new string[] { c_champALARM3_ID }, value);
            }
        }
	}
}
