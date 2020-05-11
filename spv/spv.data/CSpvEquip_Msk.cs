using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvEquip_Msk.c_nomTable,CSpvEquip_Msk.c_nomTableInDb,new string[]{ CSpvEquip_Msk.c_champEQUIP_MSK_ID})]
	[ObjetServeurURI("CSpvEquip_MskServeur")]
	[DynamicClass("Masked Equipment / Masking equipment relationship")]
	public class	CSpvEquip_Msk : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_EQUIP_MSK";
		public const string c_nomTableInDb = "EQUIP_MSK";
		public const string c_champEQUIP_MSK_ID ="EQUIP_MSK_ID";
		public const string c_champEQUIP_MASQUE_ID ="EQUIP_ID";
		public const string c_champEQUIP_MASQUANT_ID ="EQUIP_BINDINGID";
		
		///////////////////////////////////////////////////////////////
		public CSpvEquip_Msk( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvEquip_Msk( DataRow row )
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
			return new string[] {c_champEQUIP_MSK_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Masked Equipment / Masking equipment relationship |30017");
			}
		}

        //--------------------------------------------------------
        [Relation(
            CSpvEquip.c_nomTable,
            CSpvEquip.c_champEQUIP_ID,
            CSpvEquip_Msk.c_champEQUIP_MASQUE_ID,
            true,
            true,
            false)]

        [DynamicField("Masked equipment")]
        public CSpvEquip EquipementMasque
        {
            get
            {
                return (CSpvEquip)GetParent(c_champEQUIP_MASQUE_ID, typeof(CSpvEquip));
            }
            set
            {
                SetParent(c_champEQUIP_MASQUE_ID, value);
            }
        }

        //-----------------------------------------------------------------
        [Relation(
            CSpvEquip.c_nomTable,
            CSpvEquip.c_champEQUIP_ID,
            CSpvEquip_Msk.c_champEQUIP_MASQUANT_ID,
            true,
            true,
            false)]
        [DynamicField("Masking equipment")]
        public CSpvEquip EquipementMasquant
        {
            get
            {
                return (CSpvEquip)GetParent(c_champEQUIP_MASQUANT_ID, typeof(CSpvEquip));
            }
            set
            {
                SetParent(c_champEQUIP_MASQUANT_ID, value);
            }
        }

        //--------------------------------------------------------------------------------
        [RelationFille(typeof(CSpvEquip_Msk_Source), "Equip_Msk")]
        public CListeObjetsDonnees Sources
        {
            get
            {
                return GetDependancesListe(CSpvEquip_Msk_Source.c_nomTable,
                    c_champEQUIP_MSK_ID);
            }
        }

        //-----------------------------------------
        public CResultAErreur PropageMasquage()
        {
            CResultAErreur result = CResultAErreur.True;
            
            //STEF 20/10/2010, le masquage est à revoir, il crée des boucles infinies.
            //c'est notamment à cause des boucles, qui ne peuvent pas être gerées par le masquage.
            //Il faut travailler sur un masquage au niveau service !
            return result;


            CSpvEquip masquant = EquipementMasquant;
            CSpvEquip masqué = EquipementMasque;

            //Recherche tout ce que masque le masqué
            CListeObjetsDonnees listeMasqués = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvEquip_Msk));
            listeMasqués.Filtre = new CFiltreData(c_champEQUIP_MASQUANT_ID + "=@1",
                masqué.Id);
            foreach (CSpvEquip_Msk mskExistant in listeMasqués)
            {
                //Trouve le masquage entre le masquant et le masqué du masqué
                CSpvEquip_Msk msk = new CSpvEquip_Msk(ContexteDonnee);
                if (!msk.ReadIfExists(new CFiltreData (
                    c_champEQUIP_MASQUANT_ID + "=@1 and " +
                    CSpvEquip_Msk.c_champEQUIP_MASQUE_ID + "=@2",
                    masquant.Id,
                    mskExistant.EquipementMasque.Id)))
                {
                    //Stef 11/10/2010 : Evite le masquage de boucle : si le masquant est masqué par le
                    //masqué, on ne crée pas
                    CSpvEquip_Msk mskTmp = new CSpvEquip_Msk(ContexteDonnee);
                    if (!mskTmp.ReadIfExists(new CFiltreData(
                        c_champEQUIP_MASQUANT_ID + "=@1 and " +
                        CSpvEquip_Msk.c_champEQUIP_MASQUE_ID + "=@2",
                        mskExistant.EquipementMasquant.Id, 
                        masquant.Id)))
                    {
                        msk.CreateNewInCurrentContexte();
                        msk.EquipementMasquant = masquant;
                        msk.EquipementMasque = mskExistant.EquipementMasque;
                        msk.PropageMasquage();
                    }
                    else
                        msk = null;
                }
                if (msk != null)
                {
                    //S'assure que je suis bien source du masquage
                    CListeObjetsDonnees sources = msk.Sources;
                    sources.Filtre = new CFiltreData(
                        CSpvEquip_Msk_Source.c_champMasquageParent1 + "=@1 and " +
                        CSpvEquip_Msk_Source.c_champMasquageParent2 + "=@2",
                        Id,
                        mskExistant.Id);
                    if (sources.Count == 0)
                    {
                        CSpvEquip_Msk_Source source = new CSpvEquip_Msk_Source(ContexteDonnee);
                        source.CreateNewInCurrentContexte();
                        source.Equip_Msk = msk;
                        source.Equip_MskSource1 = this;
                        source.Equip_MskSource2 = mskExistant;
                    }
                }
            }

            //Recherche tout ce qui masque le masquant
            CListeObjetsDonnees listeMasquants = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvEquip_Msk));
            listeMasquants.Filtre = new CFiltreData(
                c_champEQUIP_MASQUE_ID + "=@1",
                masquant.Id);
            foreach (CSpvEquip_Msk mskExistant in listeMasquants)
            {
                //Trouve le masquage entre le masquant du masquant et le masqué
                CSpvEquip_Msk msk = new CSpvEquip_Msk(ContexteDonnee);
                if (!msk.ReadIfExists(new CFiltreData(
                    c_champEQUIP_MASQUANT_ID + "=@1 and " +
                    c_champEQUIP_MASQUE_ID + "=@2",
                    mskExistant.EquipementMasquant.Id,
                    masqué.Id)))
                {
                    //Stef 11/10/2010 : Evite le masquage de boucle : si le masquant est masqué par le
                    //masqué, on ne crée pas
                    
                    CSpvEquip_Msk mskTmp = new CSpvEquip_Msk(ContexteDonnee);
                    if (!mskTmp.ReadIfExists(new CFiltreData(
                        c_champEQUIP_MASQUANT_ID + "=@1 and " +
                        CSpvEquip_Msk.c_champEQUIP_MASQUE_ID + "=@2",
                        masquant.Id,
                        mskExistant.EquipementMasquant.Id)))
                    {
                        //Crée le masquage
                        msk.CreateNewInCurrentContexte();
                        msk.EquipementMasquant = mskExistant.EquipementMasquant;
                        msk.EquipementMasque = masqué;
                        msk.PropageMasquage();
                    }
                    else
                        msk = null;
                }
                if (msk != null)
                {
                    //S'assure que je suis bien source du masquage
                    CListeObjetsDonnees sources = msk.Sources;
                    sources.Filtre = new CFiltreData(
                        CSpvEquip_Msk_Source.c_champMasquageParent1 + "=@1 and " +
                        CSpvEquip_Msk_Source.c_champMasquageParent2 + "=@2",
                        mskExistant.Id,
                        Id);
                    if (sources.Count == 0)
                    {
                        //Crée la source
                        CSpvEquip_Msk_Source source = new CSpvEquip_Msk_Source(ContexteDonnee);
                        source.CreateNewInCurrentContexte();
                        source.Equip_Msk = msk;
                        source.Equip_MskSource1 = mskExistant;
                        source.Equip_MskSource2 = this;
                    }
                }
            }
            return result;
        }
	}
}
