using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using futurocom.snmp.entitesnmp;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;

namespace timos.data.snmp
{
    public class CChampEntiteFromQueryToChampCustom : I2iSerializable
    {
        private CChampEntiteFromQuery m_champFromQuery = null;
        private int? m_nIdChampCustom = null;
        

        //----------------------------------------------------
        public CChampEntiteFromQueryToChampCustom()
        {
        }

        //----------------------------------------------------
        [DynamicField("Field")]
        public CChampEntiteFromQuery Champ
        {
            get{
                return m_champFromQuery;
            }
            set{
                m_champFromQuery = value;
            }
        }

        //----------------------------------------------------
        public int? IdChampCustom
        {
            get{
                return m_nIdChampCustom;
            }
            set{
                m_nIdChampCustom = value;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Temporaire : permet de récupérer le champ dans un contexte donné
        /// </summary>
        private CContexteDonnee m_contexteDonneePourChamp = null;
        public CContexteDonnee ContexteDonneePourChamp
        {
            get
            {
                if (m_contexteDonneePourChamp == null)
                    return CContexteDonneeSysteme.GetInstance();
                return m_contexteDonneePourChamp;
            }
            set
            {
                m_contexteDonneePourChamp = value;
            }
        }


        //----------------------------------------------------
        [DynamicField("Custom field")]
        public CChampCustom ChampCustom
        {
            get
            {
                if (IdChampCustom != null)
                {
                    CChampCustom champ = new CChampCustom(ContexteDonneePourChamp);
                    if (champ.ReadIfExists(IdChampCustom.Value))
                        return champ;
                }
                return null;
            }
        }


        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------
        public CResultAErreur Serialize ( C2iSerializer serializer )
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            bool bHasVal = m_nIdChampCustom != null;
            serializer.TraiteBool(ref bHasVal);
            if (bHasVal)
            {
                int nTmp = m_nIdChampCustom == null ? -1 : m_nIdChampCustom.Value;
                serializer.TraiteInt(ref nTmp);
                m_nIdChampCustom = nTmp;
            }
            else
                m_nIdChampCustom = null;
            result = serializer.TraiteObject<CChampEntiteFromQuery>(ref m_champFromQuery);
            return result;
        }

        //----------------------------------------------------
        public static ETypeChampBasique GetTypeChampBasic(TypeDonnee typeChampCustom)
        {
            switch (typeChampCustom)
            {
                case TypeDonnee.tBool:
                    return ETypeChampBasique.Bool;
                case TypeDonnee.tDate:
                    return ETypeChampBasique.Date;

                case TypeDonnee.tDouble:
                    return ETypeChampBasique.Date;

                case TypeDonnee.tEntier:
                    return ETypeChampBasique.Int;

                case TypeDonnee.tObjetDonneeAIdNumeriqueAuto:
                    return ETypeChampBasique.Int;

                case TypeDonnee.tString:
                    return ETypeChampBasique.String;

            }
            return ETypeChampBasique.String;
        }

        //----------------------------------------------------
        public static TypeDonnee GetTypeChampCustom(ETypeChampBasique typeBasique)
        {
            switch (typeBasique)
            {
                case ETypeChampBasique.Bool:
                    return TypeDonnee.tBool;
                case ETypeChampBasique.Date:
                    return TypeDonnee.tDate;
                case ETypeChampBasique.Decimal:
                    return TypeDonnee.tDouble;
                case ETypeChampBasique.Int:
                    return TypeDonnee.tEntier;
                case ETypeChampBasique.String:
                    return TypeDonnee.tString;
            }
            return TypeDonnee.tString;
        }

        //----------------------------------------------------
        public bool AssociationRapide(CContexteDonnee ctxEnEdition, bool bCreationAutomatique)
        {
            if (Champ == null)
                return false;
            if ( IdChampCustom != null )
                return true;
            string strNomChamp = Champ.NomChamp;
            CListeObjetsDonnees lst = new CListeObjetsDonnees(ctxEnEdition, typeof(CChampCustom));
            CFiltreData filtre = new CFiltreData(CChampCustom.c_champNom + " like @1",
                strNomChamp);
            CChampCustom champ = new CChampCustom(ctxEnEdition);
            TypeDonnee typeChampCustom = GetTypeChampCustom (Champ.TypeChamp);
            int nIndex = 0;
            while (champ.ReadIfExists(filtre))
            {
                if (champ.CodeRole == CEntiteSnmp.c_roleChampCustom &&
                    champ.TypeDonneeChamp.TypeDonnee == typeChampCustom)
                {
                    IdChampCustom = champ.Id;
                    return true;
                }
                nIndex++;
                strNomChamp = Champ.NomChamp + "_" + nIndex;
                filtre.Parametres[0] = strNomChamp;
            }
            if (!bCreationAutomatique)
                return false;
            champ = new CChampCustom(ctxEnEdition);
            champ.CreateNewInCurrentContexte();
            champ.Nom = strNomChamp;
            champ.TypeDonneeInt = (int)typeChampCustom;
            champ.CodeRole = CEntiteSnmp.c_roleChampCustom;
            IdChampCustom = champ.Id;
            return true;

        }
    }
}
