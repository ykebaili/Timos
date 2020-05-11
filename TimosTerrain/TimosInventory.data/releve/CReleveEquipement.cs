using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data.releve
{
    [MemoryTable(c_nomTable, c_champId)]
    public class CReleveEquipement : CEntiteReleve, IObjetACoordonnees, IElementAChamps
    {
        public const string c_roleChampCustom = "EQUIPMENT_SURVEY";

        public const string c_nomTable = "EQUIPMENT_SURVEY";

        public const string c_champId = "EQSR_ID";
        public const string c_champIdContenant = "EQSR_CONTAINER_ID";
        public const string c_champPresence = "EQSR_PRESENT";
        public const string c_champCommentaire = "EQSR_COMMENT";

        //-------------------------------------------------------
        public CReleveEquipement(CMemoryDb db)
            : base(db)
        {
        }
        //-------------------------------------------------------
        public CReleveEquipement(CReleveDb db)
            : this((CMemoryDb)db)
        {
        }

        //-------------------------------------------------------
        public CReleveEquipement(DataRow row)
            : base(row)
        {
        }

        

        //-------------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            IsPresent = null;
        }

        //-------------------------------------------------------
        [MemoryField(c_champPresence)]
        public bool? IsPresent
        {
            get
            {
                bool? bPresent = Row.Get<bool?>(c_champPresence);
                if (ReleveEquipementParent != null &&
                    ReleveEquipementParent.IsPresent == false)
                    return false;
                return bPresent;
            }
            set
            {
                Row[c_champPresence] = value;
            }
        }

        //-------------------------------------------------------
        [MemoryField(c_champCommentaire)]
        public string Commentaire
        {
            get
            {
                return Row.Get<string>(c_champCommentaire);
            }
            set
            {
                Row[c_champCommentaire] = value;
            }
        }

        //-------------------------------------------------------
        [MemoryField(CEquipement.c_champSerial)]
        public string NumeroSerie
        {
            get
            {
                return Row.Get<string>(CEquipement.c_champSerial);
            }
            set
            {
                Row[CEquipement.c_champSerial] = value;
                if (Equipement != null && Equipement.IdTimos == null)
                    Equipement.NumeroSerie = value;
            }
        }

        //-------------------------------------------------------
        [MemoryField(CEquipement.c_champId)]
        public string IdEquipement
        {
            get
            {
                return Row.Get<string>(CEquipement.c_champId);
            }
            set
            {
                Row[CEquipement.c_champId] = value;
            }
        }

        //-------------------------------------------------------
        public CEquipement Equipement
        {
            get
            {
                CEquipement eqpt = GetEntiteTimos<CEquipement>(IdEquipement);
                if (eqpt == null)
                {
                    eqpt = new CEquipement(ReleveSite.Site.Database);
                    eqpt.CreateNew();
                    eqpt.Site = ReleveSite.Site;
                    eqpt.EquipementParent = ReleveEquipementParent != null ?
                        ReleveEquipementParent.Equipement : null;
                    IdEquipement = eqpt.Id;
                }
                return GetEntiteTimos<CEquipement>(IdEquipement);
            }
            set
            {
                if (value == null)
                    IdEquipement = null;
                else
                    IdEquipement = value.Id;
            }
        }

        //-------------------------------------------------------
        [MemoryParent(c_champIdContenant, true)]
        public CReleveEquipement ReleveEquipementParent
        {
            get
            {
                return GetParent<CReleveEquipement>(c_champIdContenant);
            }
            set
            {
                SetParent<CReleveEquipement>(value, c_champIdContenant);
                if (Equipement != null && Equipement.IdTimos == null)
                {
                    if (value != null)
                        Equipement.EquipementParent = value.Equipement;
                    else
                        Equipement.EquipementParent = null;
                }
            }
        }

        //-------------------------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CReleveEquipement> RelevesContenus
        {
            get
            {
                return GetFils<CReleveEquipement>(c_champIdContenant);
            }
        }
        
        //-------------------------------------------------------
        [MemoryField(CTypeEquipement.c_champId)]
        public string IdTypeEquipement
        {
            get
            {
                return Row.Get<string>(CTypeEquipement.c_champId);
            }
            set
            {
                Row[CTypeEquipement.c_champId] = value;
                if (Equipement != null && Equipement.IdTimos == null)
                {
                    Equipement.Row[CTypeEquipement.c_champId] = value;
                }
            }
        }

        //-------------------------------------------------------
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return GetEntiteTimos<CTypeEquipement>(IdTypeEquipement);
            }
            set
            {
                IdTypeEquipement = value != null ? value.Id : null;
            }
        }

        //-------------------------------------------------------
        [MemoryField(CTypeEquipementConstructeur.c_champId)]
        public string IdTypeEquipementConstructeur
        {
            get
            {
                return Row.Get<string>(CTypeEquipementConstructeur.c_champId);
            }
            set
            {
                Row[CTypeEquipementConstructeur.c_champId] = value;
                if (Equipement != null && Equipement.IdTimos == null)
                {
                    Equipement.Row[CTypeEquipementConstructeur.c_champId] = value;
                }
            }
        }

        //-------------------------------------------------------
        public CTypeEquipementConstructeur TypeEquipementConstructeur
        {
            get
            {
                return GetEntiteTimos<CTypeEquipementConstructeur>(IdTypeEquipementConstructeur);
            }
            set
            {
                IdTypeEquipementConstructeur = value != null ? value.Id : null;
            }
        }

        //-------------------------------------------------------
        [MemoryField(CEquipement.c_champCoordonnee)]
        public string Coordonnee
        {
            get
            {
                return Row.Get<string>(CEquipement.c_champCoordonnee);
            }
            set
            {
                Row[CEquipement.c_champCoordonnee] = value;
                if (Equipement != null && Equipement.IdTimos == null)
                    Equipement.Coordonnee = value;
            }
        }

        //-------------------------------------------------------
        [MemoryParent(true)]
        public CReleveSite ReleveSite
        {
            get{
                return GetParent<CReleveSite>();
            }
            set
            {
                SetParent<CReleveSite>(value);
            }
        }

        //-------------------------------------------------------
        public void FillFromEquipement(CEquipement equipement, CReleveEquipement releveEqptParent)
        {
            if (Database is CReleveDb)
            {
                Equipement = equipement;
                ReleveEquipementParent = releveEqptParent;
                TypeEquipement = equipement.TypeEquipement;
                TypeEquipementConstructeur = equipement.TypeEquipementConstructeur;
                Coordonnee = equipement.Coordonnee;
                NumeroSerie = equipement.NumeroSerie;
                foreach (CRelationEquipementChampCustom rel in equipement.RelationsChampsCustom)
                {
                    CChampCustom champ = rel.ChampCustom.GetChampInMemoryDb(Database);
                    if (champ != null)
                        SetValeurChamp(champ.Id, rel.Valeur);
                }

                foreach (CEquipement eqptFils in equipement.EquipementsContenus)
                {
                    CReleveEquipement relFils = new CReleveEquipement(Database as CReleveDb);
                    relFils.CreateNew();
                    relFils.ReleveSite = ReleveSite;
                    relFils.FillFromEquipement(eqptFils, this);
                }
            }
        }

        //-------------------------------------------------------
        public CResultAErreur VerifieCoordonnee(string strCoord)
        {
            CResultAErreur result = CResultAErreur.True;
            IObjetAFilsACoordonnees parent = ReleveEquipementParent != null ?
                (IObjetAFilsACoordonnees)ReleveEquipementParent.Equipement :
                (IObjetAFilsACoordonnees)ReleveSite.Site;
            if (parent != null)
                return parent.IsCoordonneeValide(strCoord, Equipement);
            return result;
        }

        

        //-------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------
        protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if ( !result) 
                return result;
            result = SerializeChamps(serializer,
                c_champPresence,
                CEquipement.c_champSerial,
                CEquipement.c_champId,
                CTypeEquipement.c_champId,
                CTypeEquipementConstructeur.c_champId,
                CEquipement.c_champCoordonnee,
                c_champCommentaire);

            if (result)
                result = SerializeParent<CReleveSite>(serializer);
            if (result)
                result = SerializeParent<CReleveEquipement>(serializer, c_champIdContenant);
            return result;
        }

        #region IObjetACoordonnees Membres

        //-----------------------------------------------------
        public string DescriptionElement
        {
            get { return Equipement.DescriptionElement; }
        }

        //-----------------------------------------------------
        public string CoordonneeComplete
        {
            get {
                string strC = "";
                if (ReleveEquipementParent != null)
                    strC = ReleveEquipementParent.CoordonneeComplete + ".";
                strC += Coordonnee;
                return strC;
            }
        }

        //-----------------------------------------------------
        public bool IgnorerUnite
        {
            get { return Equipement.IgnorerUnite; }
        }


        //-----------------------------------------------------
        public IObjetAFilsACoordonnees ConteneurFilsACoordonnees
        {
            get
            {
                if (ReleveEquipementParent != null)
                    return ReleveEquipementParent.Equipement;
                return ReleveSite.Site;
            }
        }

        //-----------------------------------------------------
        public CResultAErreur VerifieCoordonnee()
        {
            return VerifieCoordonnee(Coordonnee);
        }

        #endregion

        #region IObjetAOccupation Membres
        //-----------------------------------------------------
        public COccupationCoordonnees OccupationCoordonneeAppliquee
        {
            get { return Equipement.OccupationCoordonneeAppliquee; }
        }

        //-----------------------------------------------------
        public IObjetAOccupation DonnateurOccupationCoordonneeHerite
        {
            get { return Equipement.DonnateurOccupationCoordonneeHerite; }
        }

        //-----------------------------------------------------
        public COccupationCoordonnees OccupationCoordonneesPropre
        {
            get
            {
                return Equipement.OccupationCoordonneesPropre;
            }
            set
            {
            }
        }

        #endregion

        #region IElementAChamps Membres
        //----------------------------------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CRelationReleveEquipementChampCustom> RelationsChampsCustomTypee
        {
            get
            {
                return GetFils<CRelationReleveEquipementChampCustom>();
            }
        }

        //----------------------------------------------------------------
        public CListeEntitesDeMemoryDbBase RelationsChampsCustom
        {
            get
            {
                return RelationsChampsCustomTypee;
            }
        }

        //----------------------------------------------------------------
        public object GetValeurChamp(string strIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdChamp);
        }

        //----------------------------------------------------------------
        public void SetValeurChamp(string strIdChamp, object valeur)
        {
            CUtilElementAChamps.SetValeurChamp(this, strIdChamp, valeur);
        }

        //----------------------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationReleveEquipementChampCustom(Database);
        }

        #endregion
    }
}
