using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data
{
    [MemoryTable(CTypeEquipement.c_nomTable, CTypeEquipement.c_champId)]
    public class CTypeEquipement : CEntiteLieeATimos,
        IObjetASystemeDeCoordonnee,
		IObjetAOptionsDeControleDeCoordonnees,
		IObjetAOccupation
    {
        public const string c_nomTable = "EQUIPMENT_TYPE";
        public const string c_champId = "EQTTP_ID";
        public const string c_champLibelle = "EQTTP_LABEL";
        public const string c_champNbUnitesOccupation = "EQTTP_UNITS_NB";
        public const string c_champUniteOccupation = "EQTTP_OCCUPATION_UNIT_ID";
        public const string c_champOptionsControleCoordonnees = "EQTTYP_OPT_CTRL_COORD";

        //-----------------------------------------
        public CTypeEquipement(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CTypeEquipement(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------
        public override void MyInitValeursParDefaut()
        {
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

        //-------------------------------------------------------------------
        /// <summary>
        /// Relations aux types fils (dont celui-ci hérite)
        /// </summary>
        [MemoryChild(CRelationTypeEquipement_Heritage.c_champIdTypeParent)]
        public CListeEntitesDeMemoryDb<CRelationTypeEquipement_Heritage> RelationsTypesFils
        {
            get
            {
                return GetFils<CRelationTypeEquipement_Heritage>(CRelationTypeEquipement_Heritage.c_champIdTypeParent);
            }
        }

        //----------------------------------------------------------------------
        [MemoryChild()]
        public CListeEntitesDeMemoryDb<CTypeEquipementConstructeur> RelationsConstructeurs
        {
            get
            {
                return GetFils<CTypeEquipementConstructeur>();
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Relations aux types parents (dont celui-ci hérite)
        /// </summary>
        [MemoryChild(CRelationTypeEquipement_Heritage.c_champIdTypeFils)]
        public CListeEntitesDeMemoryDb<CRelationTypeEquipement_Heritage> RelationsTypesParents
        {
            get
            {
                return GetFils<CRelationTypeEquipement_Heritage>(CRelationTypeEquipement_Heritage.c_champIdTypeFils);
            }
        }

        //----------------------------------------------------------------------
        [MemoryChild()]
        public CListeEntitesDeMemoryDb<CParametrageSystemeCoordonnees> ParametragesSC
        {
            get
            {
                return GetFils<CParametrageSystemeCoordonnees>();
            }
        }


        //----------------------------------------------------------------------
        /// <summary>
        /// Système de coordonnées propre au type d'équipement (lorsqu'il existe)
        /// </summary>
        public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
        {
            get
            {
                CListeEntitesDeMemoryDb<CParametrageSystemeCoordonnees> liste = ParametragesSC;
                if (liste.Count() == 1)
                    return liste.ElementAt(0);
                return null;
            }
        }

        //----------------------------------------------------------------------
        public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
        {
            get
            {
                IObjetASystemeDeCoordonnee donnateur = null;
                //Cherche dans les types parents
                foreach (CRelationTypeEquipement_Heritage heritage in RelationsTypesParents)
                {
                    if (heritage.TypeParent.ParametrageCoordonneesPropre != null)
                    {
                        if (donnateur != null)
                            return null;
                        donnateur = heritage.TypeParent;
                    }
                    else
                    {
                        donnateur = heritage.TypeParent.DonnateurParametrageCoordonneeHerite;
                    }
                }
                return donnateur;
            }
        }


        //----------------------------------------------------------------------
        /// <summary>
        /// Système de coordonnées appliqué au type d'équipement
        /// </summary>
        [DynamicField("Applied coordinate system")]
        public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
        {
            get
            {
                CParametrageSystemeCoordonnees parametrage = ParametrageCoordonneesPropre;
                if (parametrage == null)
                {
                    IObjetASystemeDeCoordonnee donnateur = DonnateurParametrageCoordonneeHerite;
                    if (donnateur != null)
                        return donnateur.ParametrageCoordonneesPropre;
                }
                return parametrage;

            }
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// Nombre d'unités qu'occupe un tel type d'équipement dans son conteneur
        /// </summary>
        [MemoryField(CTypeEquipement.c_champNbUnitesOccupation)]
        public int? NbUnitesOccupees
        {
            get
            {
                return Row.Get<int?>(c_champNbUnitesOccupation);
            }
            set
            {
                Row[c_champNbUnitesOccupation] = value;
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Unité dans laquelle l'occupation du type d'équipement dans son conteneur
        /// est exprimée
        /// </summary>
        [MemoryParent(c_champUniteOccupation, true)]
        public CUniteCoordonnee UniteOccupee
        {
            get
            {
                return GetParent < CUniteCoordonnee>(c_champUniteOccupation);
            }
            set
            {
                SetParent<CUniteCoordonnee>(value, c_champUniteOccupation);
            }
        }

        //--------------------------------------------------------------------
        public COccupationCoordonnees OccupationCoordonneeAppliquee
        {
            get
            {
                COccupationCoordonnees occupation = OccupationCoordonneesPropre;
                if (occupation == null)
                {
                    IObjetAOccupation donnateur = DonnateurOccupationCoordonneeHerite;
                    if (donnateur != null)
                        occupation = donnateur.OccupationCoordonneesPropre;
                }
                return occupation;
            }
        }

        //--------------------------------------------------------------------
        public IObjetAOccupation DonnateurOccupationCoordonneeHerite
        {
            get
            {
                IObjetAOccupation donnateur = null;
                //Cherche dans les types parents
                foreach (CRelationTypeEquipement_Heritage heritage in RelationsTypesParents)
                {
                    if (heritage.TypeParent.OccupationCoordonneesPropre != null)
                    {
                        if (donnateur != null)
                            return null;
                        donnateur = heritage.TypeParent;
                    }
                    else
                    {
                        donnateur = heritage.TypeParent.DonnateurOccupationCoordonneeHerite;
                    }
                }
                return donnateur;
            }
        }

        //--------------------------------------------------------------------
        public COccupationCoordonnees OccupationCoordonneesPropre
        {
            get
            {
                if (NbUnitesOccupees != null)
                {
                    COccupationCoordonnees occupation = new COccupationCoordonnees(
                        (int)NbUnitesOccupees, UniteOccupee);
                    return occupation;
                }
                return new COccupationCoordonnees(1, null);
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

        //-------------------------------------------------------------------------
        [MemoryField(c_champOptionsControleCoordonnees)]
        public int? OptionsControleCoordonneesPropreInt
        {
            get
            {
                return Row.Get<int?>(c_champOptionsControleCoordonnees);
            }
            set
            {
                Row[c_champOptionsControleCoordonnees] = value;
            }
        }

        //-------------------------------------------------------------------------
        public EOptionControleCoordonnees? OptionsControleCoordonneesPropre
        {
            get
            {
                return (EOptionControleCoordonnees?)OptionsControleCoordonneesPropreInt;
            }
            set
            {
                OptionsControleCoordonneesPropreInt = (int?)value;
            }

        }

        //-------------------------------------------------------------------------
        public IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite
        {
            get
            {
                IObjetAOptionsDeControleDeCoordonnees donnateur = null;
                //Cherche dans les types parents
                foreach (CRelationTypeEquipement_Heritage heritage in RelationsTypesParents)
                {
                    if (heritage.TypeParent.OptionsControleCoordonneesPropre != null)
                    {
                        if (donnateur != null)
                            return null;
                        donnateur = heritage.TypeParent;
                    }
                    else
                    {
                        donnateur = heritage.TypeParent.DonnateurOptionsControleCoordonneesHerite;
                    }
                }
                return donnateur;
            }
        }

        //-------------------------------------------------------------------------
        public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
        {
            get
            {
                EOptionControleCoordonnees? option = OptionsControleCoordonneesPropre;
                if (option == null)
                {
                    IObjetAOptionsDeControleDeCoordonnees donnateur = DonnateurOptionsControleCoordonneesHerite;
                    if (donnateur != null)
                        return donnateur.OptionsControleCoordonneesPropre;
                }
                return option;
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
            SerializeChamps(serializer,
                c_champIdTimos, c_champLibelle, 
                c_champNbUnitesOccupation, 
                c_champOptionsControleCoordonnees);
            SerializeParent<CUniteCoordonnee>(serializer, c_champUniteOccupation);
            //SerializeChilds<CRelationTypeEquipement_Heritage>(serializer, CRelationTypeEquipement_Heritage.c_champIdTypeParent);
            //SerializeChilds<CParametrageSystemeCoordonnees>(serializer);
            return result;
        }
    }
}
