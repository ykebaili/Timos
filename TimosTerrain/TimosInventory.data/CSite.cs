using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data
{
    [MemoryTable(CSite.c_nomTable, CSite.c_champId)]
    public class CSite : CEntiteLieeATimos,
        IObjetAFilsACoordonnees
    {
        public const string c_nomTable = "SITES";
        public const string c_champId = "SIT_ID";
        public const string c_champLibelle = "SIT_LABEL";
        public const string c_champIdSiteParent = "SIT_PARENT_ID";
        public const string c_champOptionsControleCoord = "SIT_OPTION_COORD";

        //-----------------------------------------
        public CSite(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CSite(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------
        public override void MyInitValeursParDefaut()
        {
        }

        //-----------------------------------------
        public string DescriptionElement
        {
            get
            {
                return I.T("Site @1|20000", Libelle);
            }
        }

        //-----------------------------------------
        [MemoryField(c_champLibelle)]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-----------------------------------------
        public string LibelleComplet
        {
            get
            {
                string strLib = "";
                if (SiteParent != null)
                    strLib += SiteParent.LibelleComplet + "/";
                strLib += Libelle;
                return strLib;
            }
        }

        //-----------------------------------------
        [MemoryParent(false)]
        public CTypeSite TypeSite
        {
            get
            {
                return GetParent<CTypeSite>();
            }
            set
            {
                SetParent<CTypeSite>(value);
            }
        }

        //-----------------------------------------
        [MemoryParent(c_champIdSiteParent, true)]
        public CSite SiteParent
        {
            get
            {
                return GetParent<CSite>(c_champIdSiteParent);
            }
            set
            {
                SetParent<CSite>(value, c_champIdSiteParent);
            }
        }

        //-----------------------------------------
        [MemoryChild()]
        public CListeEntitesDeMemoryDb<CEquipement> Equipements
        {
            get
            {
                return GetFils<CEquipement>();
            }
        }

        //-----------------------------------------
        [MemoryField(c_champOptionsControleCoord)]
        public int? CodeOptionsControleCoordonnees
        {
            get
            {
                return Row.Get<int?>(c_champOptionsControleCoord);
            }
            set{
                Row[c_champOptionsControleCoord] = value;
            }
        }

        //-----------------------------------------
        public EOptionControleCoordonnees? OptionsControleCoordonneesPropre
        {
            get
            {
                return (EOptionControleCoordonnees?)CodeOptionsControleCoordonnees;
            }
            set
            {
                CodeOptionsControleCoordonnees = (int)value;
            }
        }

        //---------------------------------------------------------------------
        public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
        {
            get
            {
                return OptionsControleCoordonneesPropre;
            }
        }

        //---------------------------------------------------------------------
        public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
        {
            get
            {
                CParametrageSystemeCoordonnees parametrage = ParametrageCoordonneesPropre;
                if (parametrage == null)
                {
                    IObjetASystemeDeCoordonnee donnateur = DonnateurParametrageCoordonneeHerite;
                    if (donnateur != null)
                        parametrage = donnateur.ParametrageCoordonneesPropre;
                }
                return parametrage;
            }
        }

        //---------------------------------------------------------------------
        public List<IObjetACoordonnees> FilsACoordonnees
        {
            get
            {
                List<IObjetACoordonnees> lst = new List<IObjetACoordonnees>();
                CListeEntitesDeMemoryDb<CEquipement> equipements = Equipements;
                equipements.Filtre = new CFiltreMemoryDb(CEquipement.c_champIdEquipementContenant + " is null");
                foreach (CEquipement equipement in equipements)
                    lst.Add(equipement);
                return lst;
            }
        }


        //---------------------------------------------------------------------
        public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
        {
            get
            {
                return TypeSite;
            }
        }

        //-----------------------------------------
        public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
        {
            get
            {
                CListeEntitesDeMemoryDb<CParametrageSystemeCoordonnees> lst = GetFils<CParametrageSystemeCoordonnees>();
                if (lst.Count() == 1)
                    return lst.ElementAt(0);
                return null;
            }
        }

        //-----------------------------------------
        public CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet)
        {
            return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneeFils(this, objet, strCoordonnee);
        }

        //---------------------------------------------------------------------
        public CResultAErreur VerifieCoordonneesFils()
        {
            return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneesFils(this);
        }

        //-----------------------------------------
        [MemoryChild(c_champIdSiteParent)]
        public CListeEntitesDeMemoryDb<CSite> SitesFils
        {
            get
            {
                return GetFils<CSite>(c_champIdSiteParent);
            }
        }


        //-----------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champIdTimos,
                c_champLibelle, 
                c_champOptionsControleCoord);
            if ( result )
                result = SerializeParent<CTypeSite>(serializer);
            if (result)
                result = SerializeParent<CSite>(serializer, c_champIdSiteParent);
            /*if ( result )
                result = SerializeChilds<CSite>(serializer, c_champIdSiteParent);*/
            return result;
        }
    }
}
