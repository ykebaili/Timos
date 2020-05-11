using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    [Table(CSpvFamilleMibmodule.c_nomTable, CSpvFamilleMibmodule.c_nomTableInDb, new string[] { CSpvFamilleMibmodule.c_champFAMILLE_ID })]
    [ObjetServeurURI("CSpvFamilleMibmoduleServeur")]
    [DynamicClass("MIB module family")]
    public class CSpvFamilleMibmodule : CSpvFamille
    {
        public const int c_classID = 14;		// Famille de Modules MIB
        public const int c_niveauHaut = 1;      // Niveau d'une famille sans parent

        ///////////////////////////////////////////////////////////////
        public CSpvFamilleMibmodule(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        ///////////////////////////////////////////////////////////////
        public CSpvFamilleMibmodule(DataRow row)
            : base(row)
        {
        }

        ///////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            //TODO : Insérer ici le code d'initalisation
            Row[c_champFAMILLE_CLASSID] = c_classID;
            Row[c_champNiveau] = c_niveauHaut;
        }

        public override string DescriptionElement
        {
            get
            {
                return I.T("MIB module family @1|30023", Libelle);

            }   
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvMibmodule), "FamilleMere")]
        [DynamicField("MIB modules")]
        public CListeObjetsDonnees ModulesMIB
        {
            get
            {
                return GetDependancesListe(CSpvMibmodule.c_nomTable, c_champFAMILLE_ID);
            }
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvFamilleMibmodule), "FamilleParente")]
        [DynamicField("Child families")]
        public CListeObjetsDonnees FamillesFilles
        {
            get
            {
                return GetDependancesListe(CSpvFamille.c_nomTable, c_champFAMILLE_BINDINGID);
            }
        }


        ///////////////////////////////////////////////////////////////
        [Relation(CSpvFamilleMibmodule.c_nomTable, new string[] { CSpvFamilleMibmodule.c_champFAMILLE_ID }, new string[] { CSpvFamilleMibmodule.c_champFAMILLE_BINDINGID }, false, false)]
        [DynamicField("Father family")]
        public CSpvFamilleMibmodule FamilleParente
        {
            get
            {
                return (CSpvFamilleMibmodule)GetParent(new string[] { c_champFAMILLE_BINDINGID }, typeof(CSpvFamilleMibmodule));
            }
            set
            {
                //SetParent(new string[] { c_champFAMILLE_BINDINGID }, value);
                if (value != null)
                    ObjetParent = value;
            }
        }
    }
}