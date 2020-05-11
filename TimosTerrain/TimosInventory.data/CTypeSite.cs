using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data
{
    [MemoryTable(CTypeSite.c_nomTable, CTypeSite.c_champId)]
    public class CTypeSite : CEntiteLieeATimos, IObjetASystemeDeCoordonnee
    {
        public const string c_nomTable = "SITE_TYPE";
        public const string c_champId = "ST_ID";
        public const string c_champLibelle = "ST_LABEL";

        //-----------------------------------------
        public CTypeSite(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CTypeSite(DataRow row)
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
            SerializeChamp(serializer, c_champLibelle);
            //SerializeChilds<CParametrageSystemeCoordonnees>(serializer);
            return result;
        }

        #region IObjetASystemeDeCoordonnee Membres
        //-----------------------------------------
        public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
        {
            get { return ParametrageCoordonneesPropre; }
        }

        //-----------------------------------------
        public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
        {
            get {
                return null;
            }
        }

        //-----------------------------------------
        public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
        {
            get {
                CListeEntitesDeMemoryDb<CParametrageSystemeCoordonnees> lst = GetFils<CParametrageSystemeCoordonnees>();
                if (lst.Count() > 0)
                    return lst.ElementAt(0);
                return null;
            }
        }

        

        #endregion
    }
}
