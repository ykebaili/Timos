using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data
{
    [MemoryTable(CEquipement.c_nomTable, CEquipement.c_champId)]
    public class CEquipement : CEntiteLieeATimos,
        IObjetAFilsACoordonnees,
        IObjetACoordonnees,
        IElementAChamps
    {

        public const string c_roleChampCustom = "EQUIPMENT";

        public const string c_nomTable = "EQUIPMENT";
        public const string c_champId = "EQT_ID";
        public const string c_champSerial = "EQT_SERIAL";
        public const string c_champCoordonnee = "EQT_COORD";
        public const string c_champIdEquipementContenant = "EQT_PARENT_ID";
        public const string c_champOptionsControleCoord = "EQT_OPTION_COORD";
        public const string c_champNbUnitesOccupation = "EQPT_UNITS_NB";
        public const string c_champUniteOccupation = "EQPT_OCCUPATION_UNIT_ID";
        

        //-----------------------------------------
        public CEquipement(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CEquipement(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------
        public string DescriptionElement
        {
            get
            {
                return I.T("Equipment @1 @2 (@3)|20001",
                    TypeEquipement != null ? TypeEquipement.Libelle : "",
                    NumeroSerie,
                    CoordonneeComplete);
            }
        }

        //-----------------------------------------
        public override void MyInitValeursParDefaut()
        {
        }

        //-----------------------------------------
        [MemoryField(c_champSerial)]
        public string NumeroSerie
        {
            get
            {
                return Row.Get<string>(c_champSerial);
            }
            set
            {
                Row[c_champSerial] = value;
            }
        }

        //-----------------------------------------
        [MemoryField(c_champCoordonnee)]
        public string Coordonnee
        {
            get
            {
                return Row.Get<string>(c_champCoordonnee);
            }
            set
            {
                Row[c_champCoordonnee] = value;
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
            set
            {
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

        //------------------------------------------------------------------
        public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
        {
            get
            {
                EOptionControleCoordonnees? option = OptionsControleCoordonneesPropre;
                if (option == null )
                {
                    IObjetAOptionsDeControleDeCoordonnees donnateur = TypeEquipement;
                    if (donnateur != null)
                        option = donnateur.OptionsControleCoordonneesPropre;
                }
                return option;
            }
        }

        //------------------------------------------------------------------
        public CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet)
        {
            return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneeFils(this, objet, strCoordonnee);
        }

        //------------------------------------------------------------------
        public CResultAErreur VerifieCoordonneesFils()
        {
            return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneesFils(this);
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Nombre <see cref="CUniteCoordonnee">d'unités</see> qu'occupe l'équipement dans son contenant
        /// </summary>
        [MemoryField(CEquipement.c_champNbUnitesOccupation)]
        public int? NbUnitesOccupees
        {
            get
            {
                int? nb = Row.Get<int?>(c_champNbUnitesOccupation);
                if ( nb == null && TypeEquipement != null )
                    nb = TypeEquipement.NbUnitesOccupees;
                return nb;
            }
            set
            {
                Row[c_champNbUnitesOccupation] = value;
            }
        }

        //------------------------------------------------------------------
        public List<IObjetACoordonnees> FilsACoordonnees
        {
            get
            {
                List<IObjetACoordonnees> fils = new List<IObjetACoordonnees>();
                foreach (CEquipement eqpt in EquipementsContenus)
                    fils.Add(eqpt);
                return fils;
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CUniteCoordonnee">Unité</see> employée pour donner l'encombrement de l'équipement
        /// </summary>
        [MemoryParent(c_champUniteOccupation, true)]
        public CUniteCoordonnee UniteOccupee
        {
            get
            {
                CUniteCoordonnee u = GetParent<CUniteCoordonnee>(c_champUniteOccupation);
                if (u == null && TypeEquipement != null)
                    u = TypeEquipement.UniteOccupee;
                return u;
            }
            set
            {
                SetParent<CUniteCoordonnee>(value, c_champUniteOccupation);
            }
        }

        //--------------------------------------------------------------
        public COccupationCoordonnees OccupationCoordonneeAppliquee
        {
            get
            {
                COccupationCoordonnees occupation = OccupationCoordonneesPropre;
                if (occupation == null )
                {
                    IObjetAOccupation donnateur = DonnateurOccupationCoordonneeHerite;
                    if (donnateur != null)
                        occupation = donnateur.OccupationCoordonneesPropre;
                }
                return occupation;
            }
        }

        //--------------------------------------------------------------
        public IObjetAOccupation DonnateurOccupationCoordonneeHerite
        {
            get
            {
                return TypeEquipement;
            }
        }

        //--------------------------------------------------------------
        public COccupationCoordonnees OccupationCoordonneesPropre
        {
            get
            {
                if (NbUnitesOccupees != null)
                    return new COccupationCoordonnees((int)NbUnitesOccupees, UniteOccupee);
                return null;
            }
            set
            {
                if (value == null)
                {
                    NbUnitesOccupees = null;
                    UniteOccupee = null;
                }
                else
                {
                    NbUnitesOccupees = value.NbUnitesOccupees;
                    UniteOccupee = value.Unite;
                }
            }
        }

        //--------------------------------------------------------------
        /// <summary>
        /// On ignore l'unité si elle est nulle !
        /// tiens pourquoi ? parce que c'est une idée comme ça.
        /// </summary>
        public bool IgnorerUnite
        {
            get
            {
                return UniteOccupee == null;
            }
        }

        //-----------------------------------------
        [MemoryParent(false)]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return GetParent<CTypeEquipement>();
            }
            set
            {
                SetParent<CTypeEquipement>(value);
            }
        }

        //-----------------------------------------
        [MemoryParent(false)]
        public CTypeEquipementConstructeur TypeEquipementConstructeur
        {
            get
            {
                return GetParent<CTypeEquipementConstructeur>();
            }
            set
            {
                SetParent<CTypeEquipementConstructeur>(value);
            }
        }


        //-----------------------------------------
        [MemoryParent(c_champIdEquipementContenant, true)]
        public CEquipement EquipementParent
        {
            get
            {
                return GetParent<CEquipement>(c_champIdEquipementContenant);
            }
            set
            {
                SetParent<CEquipement>(value, c_champIdEquipementContenant);
            }
        }

        //-----------------------------------------
        [MemoryChild(c_champIdEquipementContenant)]
        public CListeEntitesDeMemoryDb<CEquipement> EquipementsContenus
        {
            get
            {
                return GetFils<CEquipement>(c_champIdEquipementContenant);
            }
        }

        //-----------------------------------------
        [MemoryParent(true)]
        public CSite Site
        {
            get
            {
                return GetParent<CSite>();
            }
            set
            {
                SetParent<CSite>(value);
            }
        }

        //----------------------------------------------------------------------
        public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
        {
            get
            {
                if (TypeEquipement != null && TypeEquipement.ParametrageCoordonneesPropre != null)
                    return TypeEquipement;
                if (TypeEquipement != null && TypeEquipement.ParametrageCoordonneesPropre == null)
                    return TypeEquipement.DonnateurParametrageCoordonneeHerite;
                return null;
            }
        }

        //-------------------------------------------------------------------
        public IObjetAFilsACoordonnees ConteneurFilsACoordonnees
        {
            get
            {
                if (EquipementParent != null)
                    return EquipementParent;
                return Site;
            }
        }

        //------------------------------------------------------------------
        /// <summary>
        /// Donne le <see cref="CParametrageSystemeCoordonnees">système de coordonnées</see> appliqué à l'équipement
        /// </summary>
        [DynamicField("Applied coordinate system")]
        public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
        {
            get
            {
                CParametrageSystemeCoordonnees parametrage = ParametrageCoordonneesPropre;
                if (parametrage == null )
                {
                    IObjetASystemeDeCoordonnee donnateur = DonnateurParametrageCoordonneeHerite;
                    if (donnateur != null)
                        parametrage = donnateur.ParametrageCoordonneesPropre;
                }
                return parametrage;
            }
        }


        //------------------------------------------------------------------
        /// <summary>
        /// Donne le <see cref="CParametrageSystemeCoordonnees">système de coordonnées</see> qui est propre à l'équipement
        /// </summary>
        [DynamicField("Own coordinate system")]
        public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
        {
            get
            {
                CListeEntitesDeMemoryDb<CParametrageSystemeCoordonnees> liste = GetFils<CParametrageSystemeCoordonnees>();
                if (liste.Count() == 1)
                    return (CParametrageSystemeCoordonnees)liste.ElementAt(0);
                return null;
            }
        }

        //-------------------------------------------------------------------
        public CResultAErreur VerifieCoordonnee()
        {
            CResultAErreur result = CResultAErreur.True;
            IObjetAFilsACoordonnees parent = ConteneurFilsACoordonnees;
            if (parent != null)
                return parent.IsCoordonneeValide(Coordonnee, this);
            return result;
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
            result = SerializeChamps(serializer, c_champSerial, c_champCoordonnee,
                c_champOptionsControleCoord, c_champNbUnitesOccupation);
            /*if (result)
                result = SerializeChilds<CParametrageSystemeCoordonnees>(serializer);*/
            if (result)
                result = SerializeParent<CUniteCoordonnee>(serializer, c_champUniteOccupation);
            if ( result )
                result = SerializeParent<CTypeEquipement>(serializer);
            if (result)
                result = SerializeParent<CTypeEquipementConstructeur>(serializer);
            if (result)
                result = SerializeParent<CSite>(serializer);
            if (result)
                result = SerializeParent<CEquipement>(serializer, c_champIdEquipementContenant);

            //Les équipements contenus sont déjà sérializés
            
            return result;
        }

        //-----------------------------------------
        public string CoordonneeComplete
        {
            get
            {
                string strCoord = "";
                if (EquipementParent != null)
                    strCoord = EquipementParent.CoordonneeComplete + ".";
                strCoord += Coordonnee;
                return strCoord;
            }
        }

        //-----------------------------------------
        #region IElementAChamps Membres
        //-----------------------------------------
        [MemoryChild()]
        public CListeEntitesDeMemoryDb<CRelationEquipementChampCustom> RelationsChampsTypee
        {
            get
            {
                return GetFils<CRelationEquipementChampCustom>();
            }
        }

        //-----------------------------------------
        public CListeEntitesDeMemoryDbBase RelationsChampsCustom
        {
            get
            {
                return RelationsChampsTypee;
            }
        }

        //-----------------------------------------
        public object GetValeurChamp(string strIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdChamp);
        }
        
        //-----------------------------------------
        public void SetValeurChamp(string strIdChamp, object valeur)
        {
            CUtilElementAChamps.SetValeurChamp(this, strIdChamp, valeur);
        }

        //----------------------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationEquipementChampCustom(Database);
        }

        #endregion
    }
}
