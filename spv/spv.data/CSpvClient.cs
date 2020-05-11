using System;
using System.Data;

using sc2i.data;
using sc2i.common;
using timos.data;
using sc2i.expression;

namespace spv.data
{
	[Table(CSpvClient.c_nomTable,CSpvClient.c_nomTableInDb,new string[]{ CSpvClient.c_champCLIENT_ID})]
	[ObjetServeurURI("CSpvClientServeur")]
	[DynamicClass("Spv Customer")]
    public class CSpvClient : 
        CMappableAvecTimos<CDonneesActeurClient, CSpvClient>, 
        IObjetSansVersion,
        IMappableAvecObjetTimos<CDonneesActeurClient>
	{
		public const string c_nomTable = "SPV_CLIENT";
		public const string c_nomTableInDb = "CLIENT";
		public const string c_champCLIENT_ID ="CLIENT_ID";
		public const string c_champCLIENT_NOM ="CLIENT_NOM";
		public const string c_champCLIENT_CLASSID ="CLIENT_CLASSID";
		public const string c_champCLIENT_CRITERE ="CLIENT_CRITERE";
		public const string c_champCLIENT_CODE ="CLIENT_CODE";
        public const string c_champSmtClient_Id = "SMTCLIENT_ID";
        const int c_classID = 1027;		// Client

        public const int c_ClientSystemeId = 1;
		
		///////////////////////////////////////////////////////////////
		public CSpvClient( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvClient( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champCLIENT_CLASSID] = c_classID;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champCLIENT_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Customer @1|30015", CLIENT_NOM);
			}
		}
		
			
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCLIENT_NOM,40)]
		[DynamicField("Name")]
		public System.String CLIENT_NOM
		{
			get
			{
				return (System.String)Row[c_champCLIENT_NOM];
			}
			set
			{
				Row[c_champCLIENT_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCLIENT_CLASSID)]
		[DynamicField("Class ID")]
		public System.Int32 CLIENT_CLASSID
		{
			get
			{
				return (System.Int32)Row[c_champCLIENT_CLASSID];
			}
			set
			{
				Row[c_champCLIENT_CLASSID,true]=value;
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCLIENT_CRITERE,40)]
		[DynamicField("Criteria")]
		public System.String CLIENT_CRITERE
		{
			get
			{
				if (Row[c_champCLIENT_CRITERE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champCLIENT_CRITERE];
			}
			set
			{
				Row[c_champCLIENT_CRITERE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCLIENT_CODE,40)]
		[DynamicField("Client Code")]
		public System.String CLIENT_CODE
		{
			get
			{
				if (Row[c_champCLIENT_CODE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champCLIENT_CODE];
			}
			set
			{
				Row[c_champCLIENT_CODE,true]=value;
			}
		}
		
		/*
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvService),"SpvClient")]
        [DynamicChilds("Services", typeof(CSpvService))]
		public CListeObjetsDonnees SpvProgs
		{
			get
			{
				return GetDependancesListe(CSpvService.c_nomTable,c_champCLIENT_ID);
			}
		}*/


        public override string GetChampIdObjetTimos()
        {
            return c_champSmtClient_Id;
        }

        ///////////////////////////////////////////////////////////////
        [Relation(
           CDonneesActeurClient.c_nomTable,
           CDonneesActeurClient.c_champId,
            CSpvClient.c_champSmtClient_Id,
            true,
            true,
            false)]
        [DynamicField("Corresponding SMT client")]
        public override CDonneesActeurClient ObjetTimosAssocie
        {
            get
            {
                return ObjetTimosAssocieProtected;
            }
            set
            {
                ObjetTimosAssocieProtected = value;
            }
        }


        public override void CopyFromObjetTimos(CDonneesActeurClient objetTimos)
        {
            CLIENT_NOM = objetTimos.Acteur.Libelle;
        }

        public static CSpvClient GetClientSysteme(CContexteDonnee contexte)
        {

            CSpvClient client = new CSpvClient(contexte);
            if (client.ReadIfExists(1))
                return client;
            return null;
        }
	}
}
