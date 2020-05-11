using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using sc2i.data.dynamic;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace timos.data.composantphysique
{
	/// <summary>
	/// Permet de définir une composante d'une représentation physique
	/// </summary>
    [DynamicClass("Physical component")]
	[Table(CComposantPhysiqueInDb.c_nomTable, CComposantPhysiqueInDb.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CComposantPhysiqueInDbServeur")]
	public class CComposantPhysiqueInDb : CObjetDonneeAIdNumeriqueAuto,
        IDefinisseurChampCustom
	{
		public const string c_nomTable = "PHYSICAL_COMPONENT";
		public const string c_champId = "PHCO_ID";
        public const string c_champLibelle = "PHCO_LABEL";
        public const string c_champFacePrincipale = "PHCO_MAIN_FACE";
        public const string c_champDataComposant = "PHCO_COMP_DATA";

		/// /////////////////////////////////////////////
		public CComposantPhysiqueInDb( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CComposantPhysiqueInDb(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Physical  component @1|20068",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            CodeFacePrincipale = (int)EFaceVueDynamique.Front;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

        
        //--------------------------------------------------
        /// <summary>
        /// Code de la face principale représentée :
        /// <ul>
        /// <li>0 : avant</li>
        /// <li>1 : gauche</li>
        /// <li>2 : haut</li>
        /// <li>3 : arrière</li>
        /// <li>4 : droite</li>
        /// <li>5 : bas</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champFacePrincipale)]
        [DynamicField("Main face code")]
        public int CodeFacePrincipale
        {
            get
            {
                return (int)Row[c_champFacePrincipale];
            }
            set
            {
                Row[c_champFacePrincipale] = value;
            }
        }

        //-------------------------------------------------
        /// <summary>
        /// Face principale représentée (cf. Main face code)
        /// </summary>
        [DynamicField("Main face")]
        public CFaceVueDynamique FacePrincipale
        {
            get
            {
                return new CFaceVueDynamique((EFaceVueDynamique)CodeFacePrincipale);
            }
            set
            {
                if (value != null)
                    CodeFacePrincipale = value.CodeInt;
            }
        }

        //-----------------------------------
        /// <summary>
        /// Libellé du composant physique
        /// </summary>
        [TableFieldProperty(CComposantPhysiqueInDb.c_champLibelle, 255)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-----------------------------------
        [TableFieldProperty(c_champDataComposant, NullAutorise = true)]
        public CDonneeBinaireInRow DataComposant
        {
            get
            {
                if (Row[c_champDataComposant] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataComposant);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataComposant, donnee);
                }
                return ((CDonneeBinaireInRow)Row[c_champDataComposant]).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataComposant] = value;
            }
        }

        //-----------------------------------
        [BlobDecoder]
        public C2iComposant3D Composant
        {
            get{
                C2iComposant3D composant = new C2iComposant3DConteneurDock();

                if (DataComposant.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(DataComposant.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    serializer.AttacheObjet(typeof(CContexteDonnee), ContexteDonnee);
                    CResultAErreur result = composant.Serialize(serializer);
                    serializer.DetacheObjet(typeof(CContexteDonnee), ContexteDonnee);
                    if (!result)
                    {
                        composant = new C2iComposant3DConteneurDock();
                        composant.Size = new C3DSize ( 50000, 50000, 50000 );
                    }

                }
                return composant;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataComposant;
                    data.Donnees = null;
                    DataComposant = data;

                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = value.Serialize(serializer);
                    if (result)
                    {
                        CDonneeBinaireInRow data = DataComposant;
                        data.Donnees = stream.GetBuffer();
                        DataComposant = data;
                    }
                }
            }
        }


        //-----------------------------------
        /// <summary>
        /// Formulaire associé
        /// </summary>
        [Relation(
            CFormulaire.c_nomTable,
            CFormulaire.c_champId,
            CFormulaire.c_champId,
            false,
            false)]
        [DynamicField("Associated Form")]
        public CFormulaire FormulaireAssocie
        {
            get
            {
                return (CFormulaire)GetParent(CFormulaire.c_champId, typeof(CFormulaire));
            }
            set
            {
                SetParent(CFormulaire.c_champId, value);
            }
        }

        #region CRelationComposantPhysiqueFormulaire

        public class CRelationComposantPhysiqueFormulaire :
            IRelationDefinisseurChamp_Formulaire
        {
            private CComposantPhysiqueInDb m_composant = null;
            private CFormulaire m_formulaire = null;
            public CRelationComposantPhysiqueFormulaire ( 
                CComposantPhysiqueInDb composant,
                CFormulaire formulaire )
            {
                m_composant = composant;
                m_formulaire = formulaire;
            }

            public IDefinisseurChampCustom Definisseur
            {
                get
                {
                    return m_composant;
                }
                set
                {
                    m_composant = value as CComposantPhysiqueInDb;
                }
            }

            public CFormulaire Formulaire
            {
                get
                {
                    return m_formulaire;
                }
                set
                {
                    m_formulaire = value;
                }
            }
        }
        #endregion

        #region IDefinisseurChampCustom Membres


        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
        }

        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                if (FormulaireAssocie == null)
                    return new IRelationDefinisseurChamp_Formulaire[0];

                return new IRelationDefinisseurChamp_Formulaire[]
                        {
                        new CRelationComposantPhysiqueFormulaire ( this, FormulaireAssocie )
                        };
            }
        }

        //--------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get { return CRoleChampCustom.GetRole (CTypeEquipement.c_roleChampCustom); }
        }

        //--------------------------------------------------------
        public CChampCustom[] TousLesChampsAssocies
        {
            get 
            { 
                if ( FormulaireAssocie == null )
                    return new CChampCustom[0];
                List<CChampCustom> lst = new List<CChampCustom>();
                foreach (CRelationFormulaireChampCustom rel in FormulaireAssocie.RelationsChamps)
                    lst.Add(rel.Champ);
                return lst.ToArray();
            }
        }

        #endregion
    }
}
