using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    public enum ETypeServiceMediation
    {
        GestionSITE = 1,
        GestionIS,
        ServiceTrap,
        ServiceDecouverte,
        ServiceMail,
        ServicePolling,
        EmessEM,
        ServiceXNA,
        ServiceReplication = 10,
        ServiceE10 = 11,
        ServiceQoS = 11
    }

    public enum EEtatLogiciel
    {
        Fonctionnel,
        Arrete
    }

	[Table(CSpvTestem.c_nomTable,CSpvTestem.c_nomTableInDb,new string[]{ CSpvTestem.c_champTESTEM_ID,CSpvTestem.c_champTESTEM_EMNOM})]
	[ObjetServeurURI("CSpvTestemServeur")]
	[DynamicClass(" Test Em")]
    public class CSpvTestem : CObjetDonnee, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TESTEM";
		public const string c_nomTableInDb = "TESTEM";
		public const string c_champTESTEM_ID ="TESTEM_ID";
		public const string c_champTESTEM_CLASSID ="TESTEM_CLASSID";
		public const string c_champTESTEM_NOM ="TESTEM_NOM";
		public const string c_champTESTEM_DATE ="TESTEM_DATE";
		public const string c_champTESTEM_NSEC ="TESTEM_NSEC";
		public const string c_champTESTEM_ETAT ="TESTEM_ETAT";
		public const string c_champTESTEM_EMNOM ="TESTEM_EMNOM";
		public const string c_champTESTEM_PREVIOUSREJECTEDAL ="TESTEM_PREVIOUSREJECTEDAL";
		public const string c_champTESTEM_CURRENTREJECTEDAL ="TESTEM_CURRENTREJECTEDAL";
		public const string c_champTESTEM_TOTALREJECTEDAL ="TESTEM_TOTALREJECTEDAL";

        public const int c_ClassId = 2038;
		
		///////////////////////////////////////////////////////////////
		public CSpvTestem( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTestem( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champTESTEM_CLASSID, true] = c_ClassId;
            SecondesRafraichissement = 0;
            EtatLogiciel = EEtatLogiciel.Fonctionnel;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champTESTEM_ID};
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
		[TableFieldProperty(c_champTESTEM_ID)]
		[DynamicField("Service number")]
		public System.Int32 NumeroService
		{
			get
			{
				return (System.Int32)Row[c_champTESTEM_ID];
			}
			set
			{
				Row[c_champTESTEM_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_CLASSID)]
		[DynamicField("Class ID")]
		public System.Double TESTEM_CLASSID
		{
			get
			{
				return (System.Double)Row[c_champTESTEM_CLASSID];
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_NOM,40)]
		[DynamicField("Service name")]
		public System.String NomService
		{
			get
			{
				return (System.String)Row[c_champTESTEM_NOM];
			}
			set
			{
				Row[c_champTESTEM_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_DATE)]
		[DynamicField("Refresh date")]
		public System.DateTime DateRafraichissement
		{
			get
			{
				return (System.DateTime)Row[c_champTESTEM_DATE];
			}
			set
			{
				Row[c_champTESTEM_DATE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_NSEC)]
		[DynamicField("Refresh date (sec.)")]
		public System.Double SecondesRafraichissement
		{
			get
			{
				return (System.Double)Row[c_champTESTEM_NSEC];
			}
			set
			{
				Row[c_champTESTEM_NSEC,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_ETAT)]
		[DynamicField("Software state")]
        public EEtatLogiciel EtatLogiciel
		{
			get
			{
                return (EEtatLogiciel)Row[c_champTESTEM_ETAT];
			}
			set
			{
				Row[c_champTESTEM_ETAT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_EMNOM,40)]
		[DynamicField("Mediation Equipement Name")]
		public System.String NomEquipementMediation
		{
			get
			{
				return (System.String)Row[c_champTESTEM_EMNOM];
			}
			set
			{
				Row[c_champTESTEM_EMNOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_PREVIOUSREJECTEDAL)]
		[DynamicField("Previous count rejected alarms")]
		public System.Double ComptePrecedentAlarmesRejetees
		{
			get
			{
				return (System.Double)Row[c_champTESTEM_PREVIOUSREJECTEDAL];
			}
			set
			{
				Row[c_champTESTEM_PREVIOUSREJECTEDAL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_CURRENTREJECTEDAL)]
		[DynamicField("Current count rejected alarms")]
		public System.Double CompteurAlarmesRejetees
		{
			get
			{
				return (System.Double)Row[c_champTESTEM_CURRENTREJECTEDAL];
			}
			set
			{
				Row[c_champTESTEM_CURRENTREJECTEDAL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTESTEM_TOTALREJECTEDAL)]
		[DynamicField("Total rejected alarms")]
		public System.Double TotalAlarmesRejetees
		{
			get
			{
				return (System.Double)Row[c_champTESTEM_TOTALREJECTEDAL];
			}
			set
			{
				Row[c_champTESTEM_TOTALREJECTEDAL,true]=value;
			}
		}
	}
}
