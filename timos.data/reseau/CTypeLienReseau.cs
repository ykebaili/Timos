using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;
using sc2i.doccode;
using System.IO;

namespace timos.data
{
    /// <summary>
    /// Type de lien réseau.
    /// Définit le comportement pour tous les <see cref="CLienReseau">liens réseau</see> de ce type,
    /// par exemple, c'est au niveau du type de lien réseau que se fait
    /// l'association avec les formulaires personnalisés à afficher au niveau des liens réseau de ce type.
    /// </summary>
    [DynamicClass("Network link type")]
    [Table(CTypeLienReseau.c_nomTable, CTypeLienReseau.c_champId, true)]
    [ObjetServeurURI("CTypeLienReseauServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_Liaisons_ID)]
	[Unique (false, "The label of this link type is already used", CTypeLienReseau.c_champLibelle)]
    [TiagClass("Network link type","Id", true)]
    public class CTypeLienReseau : CObjetDonneeAIdNumeriqueAuto,IDefinisseurChampCustomRelationObjetDonnee,
        IObjetALectureTableComplete
    {
        public const string c_nomTable = "NETWORK_LINK_TYPE";
        public const string c_champId = "NETWORKLINKTYPE_ID";
        public const string c_champLibelle = "NETWORKLINKTYPE_LABEL";
        public const string c_champTypeElement1 = "NTWLNKTYP_TYPELT1";
        public const string c_champTypeElement2 = "NTWLNKTYP_TYPELT2";
        public const string c_champFiltreElement1 = "NTWLNKTYP_FILTER1";
        public const string c_champFiltreElement2 = "NTWLNKTYP_FILTER2";

        /// /////////////////////////////////////////////
		public CTypeLienReseau( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeLienReseau(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
        // Decription du Type de lien réseau
		public override string DescriptionElement
		{
			get { return I.T( "Network Link Type: @1|30087", Libelle); }
		}


        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        /////////////////////////////////////////////
        /// <summary>
        /// Indique libellé pour ce Type de lien réseau. Ce champ texte de 255 caractères est obligatoire et unique.
        /// </summary>
        [DescriptionField]
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [TiagField("Label")]
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



        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        /// <summary>
        /// Donne la liste des <see cref="CRelationTypeLienReseau_ChampCustom">relations du type de lien réseau avec les champs personnalisés</see> qui le concernent
        /// </summary>
        [RelationFille(typeof(CRelationTypeLienReseau_ChampCustom), "Definisseur")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeLienReseau_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeLienReseau_ChampCustom.c_nomTable, c_champId); }
        }


        /// <summary>
        /// Donne la liste des <see cref="CRelationTypeLienReseau_Formulaire">relations du type de lien réseau avec les formulaires personnalisés</see> qui le concernent
        /// </summary>
        [RelationFille(typeof(CRelationTypeLienReseau_Formulaire), "Definisseur")]
        [DynamicChilds("Form relations", typeof(CRelationTypeLienReseau_Formulaire))]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeLienReseau_Formulaire.c_nomTable, c_champId); }
        }


        #endregion





        
	

        #region IDefinisseurChampCustom Membres

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        /// /////////////////////////////////////////////
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CLienReseau.c_roleChampCustom);
            }
        }

        /// /////////////////////////////////////////////
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                Hashtable tableChamps = new Hashtable();
                FillHashtableChamps(tableChamps);
                CChampCustom[] liste = new CChampCustom[tableChamps.Count];
                int nChamp = 0;
                foreach (CChampCustom champ in tableChamps.Values)
                    liste[nChamp++] = champ;
                return liste;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis)
                tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
            {
                foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                    tableChamps[relFor.Champ.Id] = relFor.Champ;
            }
        }

        #endregion



        /// <summary>
        /// Donne la liste des types de liens réseau pouvant être support de ce type de lien réseau.
        /// Un lien réseau support est en général un lien de plus haut niveau dans la hiérarchie des liens
        /// (exemple : hiérarchie de télécommunication SDH ou PDH)
        /// </summary>
        [RelationFille(typeof(CTypeLienReseauSupport), "TypeSupportant")]
        [DynamicChilds("Supported Types", typeof(CTypeLienReseauSupport))]
        public CListeObjetsDonnees TypesPouvantEtreSupportesParCeType
        {
            get
            {
                return GetDependancesListe(CTypeLienReseauSupport.c_nomTable, CTypeLienReseauSupport.c_champIdTypeSupportant);
                   
            }
        }

        /// <summary>
        /// Donne la liste des types de liens réseau pouvant être supportés par ce type de lien réseau.
        /// Un lien réseau supporté est en général un lien de plus bas niveau dans la hiérarchie des liens
        /// (exemple : hiérarchie de télécommunication SDH ou PDH)
        /// </summary>
        [RelationFille(typeof(CTypeLienReseauSupport), "TypeSupporté")]
        [DynamicChilds("Supporting types", typeof(CTypeLienReseauSupport))]
        public CListeObjetsDonnees TypesPouvantSupporterCeType
        {
            get
            {
                return GetDependancesListe(CTypeLienReseauSupport.c_nomTable, CTypeLienReseauSupport.c_champIdTypeSupporté);
            }
        }



        /// <summary>
        /// Type de l'élément extrémité 1, pour les liens de ce type.
        /// Peut être :
        /// <ul>
        /// <li>Un site</li>
        /// <li>Un Equipement logique</li>
        /// <li>Un objet d'extrémité associé à un site ou à un équipement logique</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champTypeElement1, 255)]
        [DynamicField("Element 1 Type")]
        [TiagField("Element 1 system type")]
        public string TypeElement1String
        {
            get
            {
                return (string)Row[c_champTypeElement1];
            }

            set
            {
                Row[c_champTypeElement1] = value;
            }
        }




        public Type TypeElement1
        {
            get
            {
                return CActivatorSurChaine.GetType(TypeElement1String);
            }

            set
            {
                TypeElement1String = value.ToString();
            }

        }


        /// <summary>
        /// Type de l'élément extrémité 2, pour les liens de ce type.
        /// Peut être :
        /// <ul>
        /// <li>Un site</li>
        /// <li>Un Equipement logique</li>
        /// <li>Un objet d'extrémité associé à un site ou à un équipement logique</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champTypeElement2, 255)]
        [DynamicField("Element 2 Type")]
        [TiagField("Element 2 system type")]
        public string TypeElement2String
        {
            get
            {
                return (string)Row[c_champTypeElement2];
            }

            set
            {
                Row[c_champTypeElement2] = value;
            }
        }




        public Type TypeElement2
        {
            get
            {
                return CActivatorSurChaine.GetType(TypeElement2String);
            }

            set
            {
                TypeElement2String = value.ToString();
            }

        }


        /// <summary>
        /// Donne la liste de tous les <see cref="CLienReseau">liens réseau</see> de ce type
        /// </summary>
        [RelationFille(typeof(CLienReseau), "TypeLienReseau")]
        [DynamicChilds("Network links", typeof(CLienReseau))]
        public CListeObjetsDonnees LiensReseau
        {
            get
            {
                return GetDependancesListe(CLienReseau.c_nomTable, c_champId);
            }
        }


        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(CTypeLienReseau.c_champFiltreElement1, NullAutorise = true)]
        public CDonneeBinaireInRow DataFiltre1
        {
            get
            {
                if (Row[c_champFiltreElement1] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFiltreElement1);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltreElement1, donnee);
                }
                object obj = Row[c_champFiltreElement1];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFiltreElement1] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CFiltreDynamique Filtre1
        {
            get
            {
                CDonneeBinaireInRow data = DataFiltre1;
                CFiltreDynamique filtre = null;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    serializer.AttacheObjet(typeof(CContexteDonnee), ContexteDonnee);
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref filtre, new object[] { });
                    if (!result)
                        filtre = null;
                }
                return filtre;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataFiltre1;
                    data.Donnees = null;
                    DataFiltre1 = null;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref value, new object[] { });
                    if (result)
                    {
                        CDonneeBinaireInRow data = DataFiltre1;
                        data.Donnees = stream.GetBuffer();
                        DataFiltre1 = data;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(CTypeLienReseau.c_champFiltreElement2, NullAutorise = true)]
        public CDonneeBinaireInRow DataFiltre2
        {
            get
            {
                if (Row[c_champFiltreElement2] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFiltreElement2);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltreElement2, donnee);
                }
                object obj = Row[c_champFiltreElement2];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFiltreElement2] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CFiltreDynamique Filtre2
        {
            get
            {
                CDonneeBinaireInRow data = DataFiltre2;
                CFiltreDynamique filtre = null;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    serializer.AttacheObjet(typeof(CContexteDonnee), ContexteDonnee);
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref filtre, new object[] { });
                    if (!result)
                        filtre = null;
                }
                return filtre;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataFiltre2;
                    data.Donnees = null;
                    DataFiltre2 = null;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref value, new object[] { });
                    if (result)
                    {
                        CDonneeBinaireInRow data = DataFiltre2;
                        data.Donnees = stream.GetBuffer();
                        DataFiltre2 = data;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }


    }
}
