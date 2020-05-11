using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.IO;
using System.Collections.Generic;
using timos.data.snmp;

namespace timos.data
{
	/// <summary>
    /// A chaque élément placé sur un schéma réseau, correspond une entité CElementDeSchemaReseau.
    /// Un CElementDeSchemaReseau peut pointer sur un <see cref="CSite">site</see>, un <see cref="CEquipement">équipement</see>, un <see cref="CLienReseau">lien réseau</see>, 
    /// un <see cref="CSchemaReseau">schéma réseau</see>, il contient la position de l'élément
	/// </summary>
    [DynamicClass("Network diagram element")]
	[Table(CElementDeSchemaReseau.c_nomTable, CElementDeSchemaReseau.c_champId, true )]
	[FullTableSync]
    [ObjetServeurURI("CElementDeSchemaReseauServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [TiagClass("Network diagram element","Id", true)]
	public class CElementDeSchemaReseau : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "NETWORK_DIAG_ELT";
		public const string c_champId = "NWDEL_ID";
        public const string c_champDataAffichage = "NWDEL_DISPLAY_DATA";
        public const string c_champX = "NWDEL_X";
        public const string c_champY = "NWDEL_Y";
        public const string c_champWidth = "NWDEL_WIDTH";
        public const string c_champHeight = "NWDEL_HEIGHT";
        public const string c_champZOrder = "NWDEL_ZORDER";
        public const string c_champIdSchemaReseauAuquelJappartiens = "NWDEL_NETDIAG_ID";
        public const string c_champIdSchemaReseauContenu = "NWDEL_NETDIAG_USE_ID";
        public const string c_champIdSchemaReseauInclus = "NWDEL_NETDIAG_INC_ID";
        public const string c_champDataAffichageString = "NWDEL_DISP_DAT_STR";

        public const string c_champCacheIdDessin = "NWDEL_DATA_DRAWING";

		/// /////////////////////////////////////////////
		public CElementDeSchemaReseau( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CElementDeSchemaReseau(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Network diagram element @1|20027",Id.ToString());
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


        //-------------------------------------------------------------------
        //-------------------------------------------------------------------
        public void TiagSetSchemaContenantKeys(object[] lstKeys)
        {
            CSchemaReseau schema = new CSchemaReseau(ContexteDonnee);
            if (schema.ReadIfExists(lstKeys))
                SchemaReseau = schema;
        }/// <summary>
        /// <see cref="CSchemaReseau">Schéma de réseau</see> auquel appartient cet élément de schéma
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens,
            true,
            true,
            true)]
        [DynamicField("Network diagram")]
        [TiagRelation(typeof(CSchemaReseau), "TiagSetSchemaContenantKeys")]
        public CSchemaReseau SchemaReseau
        {
            get
            {
                return (CSchemaReseau)GetParent(CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens, typeof(CSchemaReseau));
            }
            set
            {
                SetParent(CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens, value);
            }
        }

        //---------------------------------------------------------
        /// <summary>
        /// Position en X de l'élément de schéma dans son <see cref="CSchemaReseau">schéma réseau</see>
        /// </summary>
        [TableFieldProperty(CElementDeSchemaReseau.c_champX)]
        [DynamicField("X")]
        [TiagField("X")]
        public int X
        {
            get
            {
                return (int)Row[c_champX];
            }
            set
            {
                Row[c_champX] = value;
            }
        }

        //-------------------------------------------------------
        /// <summary>
        /// Position en Y de l'élément de schéma dans son <see cref="CSchemaReseau">schéma réseau</see>
        /// </summary>
        [TableFieldProperty(CElementDeSchemaReseau.c_champY)]
        [DynamicField("Y")]
        [TiagField("Y")]
        public int Y
        {
            get
            {
                return (int)Row[c_champY];
            }
            set
            {
                Row[c_champY] = value;
            }
        }

        //----------------------------------------------------------
        /// <summary>
        /// Largeur de l'élément de schéma dans son <see cref="CSchemaReseau">schéma réseau</see>
        /// </summary>
        [TableFieldProperty(CElementDeSchemaReseau.c_champWidth)]
        [DynamicField("Width")]
        [TiagField("Width")]
        public int Width
        {
            get
            {
                return (int)Row[c_champWidth];
            }
            set
            {
                Row[c_champWidth] = value;
            }
        }

        //--------------------------------------------------------
        /// <summary>
        /// Hauteur de l'élément de schéma dans son <see cref="CSchemaReseau">schéma réseau</see>
        /// </summary>
        [TableFieldProperty(CElementDeSchemaReseau.c_champHeight)]
        [DynamicField("Height")]
        [TiagField("Height")]
        public int Height
        {
            get
            {
                return (int)Row[c_champHeight];
            }
            set
            {
                Row[c_champHeight] = value;
            }
        }

        //----------------------------------------------------------
        /// <summary>
        /// N° d'ordre de l'élément de schéma dans son <see cref="CSchemaReseau">schéma réseau</see>
        /// </summary>
        [TableFieldProperty(CElementDeSchemaReseau.c_champZOrder)]
        [DynamicField("ZOrder")]
        [TiagField("ZOrder")]
        public int ZOrder
        {
            get
            {
                return (int)Row[c_champZOrder];
            }
            set
            {
                Row[c_champZOrder] = value;
            }
        }

        //-------------------------------------------------------------------
        public void TiagSetSiteRepresenteKeys(object[] lstKeys)
        {
            CSite site = new CSite(ContexteDonnee);
            if (site.ReadIfExists(lstKeys))
                Site = site;
        }


        /// <summary>
        /// <see cref="CSite">Site</see> correspondant lorsque l'élément de schéma représente un site
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            false,
            false,
            true)]
        [DynamicField("Represented site")]
        [TiagRelation(typeof(CSite), "TiagSetSiteRepresenteKeys")]
        public CSite Site
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                if (value != null)
                    ElementAssocie = value;
            }
        }


        //-------------------------------------------------------------------

        public void TiagSetEquipementRepresenteKeys(object[] lstKeys)
        {
            CEquipementLogique eqpt = new CEquipementLogique(ContexteDonnee);
            if (eqpt.ReadIfExists(lstKeys))
                EquipementLogique = eqpt;
        }
        /// <summary>
        /// <see cref="CEquipementLogique">Equipement logique</see> correspondant lorsque l'élément de schéma représente un équipement logique
        /// </summary>
        [Relation(
            CEquipementLogique.c_nomTable,
            CEquipementLogique.c_champId,
            CEquipementLogique.c_champId,
            false,
            false,
            true)]
        [DynamicField("Represented Equipment")]
        [TiagRelation(typeof(CEquipementLogique), "TiagSetEquipementRepresenteKeys")]
        public CEquipementLogique EquipementLogique
        {
            get
            {
                return (CEquipementLogique)GetParent(CEquipementLogique.c_champId, typeof(CEquipementLogique));
            }
            set
            {
                if (value != null)
                    ElementAssocie = value;
                
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CEntiteSnmp">Entité SNMP</see> correspondante lorsque l'élément de schéma représente une entité SNMP
        /// </summary>
        [Relation(
            CEntiteSnmp.c_nomTable,
            CEntiteSnmp.c_champId,
            CEntiteSnmp.c_champId,
            false,
            false,
            true)]
        [DynamicField("Snmp entity")]
        public CEntiteSnmp EntiteSnmp
        {
            get
            {
                return (CEntiteSnmp)GetParent(CEntiteSnmp.c_champId, typeof(CEntiteSnmp));
            }
            set
            {
                if (value != null)
                    ElementAssocie = value;
            }
        }

	



        //-------------------------------------------------------------------
        public void TiagSetLienReseauKeys(object[] lstKeys)
        {
            CLienReseau lien = new CLienReseau(ContexteDonnee);
            if (lien.ReadIfExists(lstKeys))
                LienReseau = lien;
        }
        /// <summary>
        /// <see cref="CLienReseau">Lien réseau</see> correspondant lorsque l'élément de schéma représente un lien réseau
        /// </summary>
        [Relation(
            CLienReseau.c_nomTable,
            CLienReseau.c_champId,
            CLienReseau.c_champId,
            false,
            true,
            true)]
        [DynamicField("Represented Network link")]
        [TiagRelation(typeof(CLienReseau), "TiagSetLienReseauKeys")]
        public CLienReseau LienReseau
        {
            get
            {
                return (CLienReseau)GetParent(CLienReseau.c_champId, typeof(CLienReseau));
            }
            set
            {
                if (value != null)
                    ElementAssocie = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        ///STocke les données d'affichage si l'objet DOnneeDessinindique qu'il doit se sauvegarder sous forme de string
        [TableFieldProperty(CElementDeSchemaReseau.c_champDataAffichageString, 2000)]
        public string DataAffichageString
        {
            get
            {
                return (string)Row[c_champDataAffichageString];
            }
            set
            {
                Row[c_champDataAffichageString] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        /// Stocke les données d'affichage si l'objet donneeDessin indique qu'il doit se sauvegarde dans un blob
        [TableFieldProperty(CElementDeSchemaReseau.c_champDataAffichage, NullAutorise = true)]
        public CDonneeBinaireInRow DataAffichage
        {
            get
            {
                if (Row[c_champDataAffichage] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataAffichage);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataAffichage, donnee);
                }
                object obj = Row[c_champDataAffichage];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataAffichage] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheIdDessin, IsInDb = false)]
        [BlobDecoder]
        public IDonneeDessinElementDeSchemaReseau DonneeDessin
        {
            get
            {
                if (Row[c_champCacheIdDessin] != DBNull.Value)
                {
                    IDonneeDessinElementDeSchemaReseau donnee = (IDonneeDessinElementDeSchemaReseau)Row[c_champCacheIdDessin];
                    if (donnee.IdContexteDonnee == ContexteDonnee.IdContexteDonnee)
                        return donnee;
                }
                if (DataAffichageString.Length > 0)
                {
                    if (DataAffichageString != "0")//O indique null
                    {
                        CStringSerializer serializer = new CStringSerializer(DataAffichageString, ModeSerialisation.Lecture);
                        IDonneeDessinElementDeSchemaReseau dataComplementaire = null;
                        CResultAErreur result = serializer.TraiteObject<IDonneeDessinElementDeSchemaReseau>(ref dataComplementaire, ContexteDonnee.IdContexteDonnee);
                        if (result)
                        {
                            CDonneeDessinElementDeSchemaReseau donneeDessin = dataComplementaire as CDonneeDessinElementDeSchemaReseau;
                            if ( donneeDessin != null )
                                dataComplementaire = ConvertDonneeDessin(donneeDessin);
                            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheIdDessin, dataComplementaire);
                            return dataComplementaire;
                        }
                    }
                }
                else
                {
                    CDonneeBinaireInRow data = DataAffichage;
                    if (data != null && data.Donnees != null)
                    {
                        Stream stream = new MemoryStream(data.Donnees);
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                        IDonneeDessinElementDeSchemaReseau dataComplementaire = null;
                        CResultAErreur result = serializer.TraiteObject<IDonneeDessinElementDeSchemaReseau>(ref dataComplementaire, ContexteDonnee.IdContexteDonnee);
                        reader.Close();
                        stream.Close();
                        if (result)
                        {
                            CDonneeDessinElementDeSchemaReseau donneeDessin = dataComplementaire as CDonneeDessinElementDeSchemaReseau;
                            if (donneeDessin != null)
                                dataComplementaire = ConvertDonneeDessin(donneeDessin);
                            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheIdDessin, dataComplementaire);
                            return dataComplementaire;
                        }
                 
                    }
                }
                if (ObjetDeSchema != null)
                {
                    IDonneeDessinElementDeSchemaReseau donneeDessin = ObjetDeSchema.DonneeDessin;
                    return donneeDessin;
                }
                return null;
            }
            set
            {
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheIdDessin, DBNull.Value);
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataAffichage;
                    data.Donnees = null;
                    DataAffichage = data;
                    DataAffichageString = "0";//0 indique null

                }
                else
                {
                    if (value.ShouldSaveInBlob)
                    {
                        MemoryStream stream = new MemoryStream();
                        BinaryWriter writer = new BinaryWriter(stream);
                        CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                        serializer.TraiteObject<IDonneeDessinElementDeSchemaReseau>(ref value, ContexteDonnee.IdContexteDonnee);
                        CDonneeBinaireInRow data = DataAffichage;
                        data.Donnees = stream.GetBuffer();
                        writer.Close();
                        stream.Close();
                        DataAffichageString = "";
                    }
                    else
                    {
                        CStringSerializer serializer = new CStringSerializer(ModeSerialisation.Ecriture);
                        serializer.TraiteObject<IDonneeDessinElementDeSchemaReseau>(ref value, ContexteDonnee.IdContexteDonnee);
                        DataAffichageString = serializer.String;
                        CDonneeBinaireInRow data = Row[c_champDataAffichage] as CDonneeBinaireInRow;
                        if (data != null && data.Donnees != null)
                            data.Donnees = null;
                    }
                }
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Convertit la donnée de dessin dans le type attendu par l'objet de schema
        /// </summary>
        /// <param name="donneeDessin"></param>
        /// <returns></returns>
        private CDonneeDessinElementDeSchemaReseau ConvertDonneeDessin(CDonneeDessinElementDeSchemaReseau donneeDessin)
        {
            if (ObjetDeSchema == null)
                return donneeDessin;
            CDonneeDessinElementDeSchemaReseau donneeBonType = ObjetDeSchema.DonneeDessin as CDonneeDessinElementDeSchemaReseau;
            if (donneeBonType != null)
            {
                if (donneeBonType.GetType() != donneeDessin.GetType())
                {
                    donneeBonType.CopyFrom(donneeDessin);
                    return donneeBonType;
                }
            }
            return donneeDessin;
        }


        //-------------------------------------------------------------------
        public void TiagSetRepresentedDiagramKeys(object[] lstKeys)
        {
            CSchemaReseau schema = new CSchemaReseau(ContexteDonnee);
            if (schema.ReadIfExists(lstKeys))
                SchemaReseauContenu = schema;
        }
        /// <summary>
        /// <see cref="CSchemaReseau">Schéma réseau</see> correspondant lorsque l'élément de schéma représente un schéma réseau
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CElementDeSchemaReseau.c_champIdSchemaReseauContenu,
            false,
            false,
            true)]
        [DynamicField("Represented external Network diagram")]
        [TiagRelation(typeof(CSchemaReseau),"TiagSetRepresentedDiagramKeys")]
        public CSchemaReseau SchemaReseauContenu
        {
            get
            {
                return (CSchemaReseau)GetParent(CElementDeSchemaReseau.c_champIdSchemaReseauContenu, typeof(CSchemaReseau));
            }
            set
            {
                if (value != null)
                    ElementAssocie = value;
            }
        }






        //-------------------------------------------------------------------
        public void TiagSetIncludedDiagramKeys(object[] lstKeys)
        {
            CSchemaReseau schema = new CSchemaReseau(ContexteDonnee);
            if (schema.ReadIfExists(lstKeys))
                SchemaReseauInclus = schema;
        }



        /// <summary>
        /// <see cref="CSchemaReseau">Schéma réseau</see> correspondant lorsque l'élément de schéma représente un schéma réseau appartenant exclusivement<br/>
        /// au schéma courant (cas d'un schéma de câblage dans un site pour un schéma de lien)
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CElementDeSchemaReseau.c_champIdSchemaReseauInclus,
            false,
            true,
            true)]
        [DynamicField("Represented internal Network diagram")]
        [TiagRelation(typeof(CSchemaReseau), "TiagSetIncludedDiagramKeys")]
        public CSchemaReseau SchemaReseauInclus
        {
            get
            {
                return (CSchemaReseau)GetParent(CElementDeSchemaReseau.c_champIdSchemaReseauInclus, typeof(CSchemaReseau));
            }
            set
            {
                if (value != null)
                    ElementAssocie = value;
            }
        }


        /// <summary>
        /// Objet associé à l'élément de schéma réseau :
        /// <see cref="CSite">Site</see> ou <see cref="CEquipementLogique">Equipement logique</see> ou <see cref="CLienReseau">Lien réseau</see> ou <see cref="CEntiteSnmp">Entité SNMP</see> ou <see cref="CSchemaReseau">Schéma réseau</see>
        /// </summary>
        [DynamicField("Associated element")]
        public IElementDeSchemaReseau ElementAssocie
        {
            get
            {
                if (Site != null)
                    return Site;
                if (EquipementLogique != null)
                    return EquipementLogique;
                if (LienReseau != null)
                    return LienReseau;
                if (EntiteSnmp != null)
                    return EntiteSnmp;
                if (SchemaReseauContenu != null)
                    return SchemaReseauContenu;
                if(SchemaReseauInclus !=null)
                    return SchemaReseauInclus;
                return null;
            }
            set
            {
                SetParent(CSite.c_champId, value as CSite);
                SetParent(CEquipementLogique.c_champId, value as CEquipementLogique);
                SetParent(CLienReseau.c_champId, value as CLienReseau);
                SetParent(CEntiteSnmp.c_champId, value as CEntiteSnmp);
                if(value ==null)
                {
                    if(SchemaReseauContenu!=null)
                    {
                          SetParent(CElementDeSchemaReseau.c_champIdSchemaReseauContenu, value as CSchemaReseau);
                 
                    }
                    else if(SchemaReseauInclus !=null)
                    {
                        SetParent(CElementDeSchemaReseau.c_champIdSchemaReseauContenu, value as CSchemaReseau);

                    }

                }
                else if(value.GetType().IsAssignableFrom(typeof(CSchemaReseau)))
                {
                    if(((CSchemaReseau)value).SchemaParent == null)
                     SetParent(CElementDeSchemaReseau.c_champIdSchemaReseauContenu, value as CSchemaReseau);
                    else
                     SetParent(CElementDeSchemaReseau.c_champIdSchemaReseauInclus, value as CSchemaReseau);
                   
            }   }
        }

        public C2iSymbole SymboleADessiner
        {
            get
            {
                IElementDeSchemaReseau element = ElementAssocie;
                if (element != null)
                    return element.SymboleADessiner;
                return null;
            }
        }


        /// <summary>
        /// Retourne l'objet de schéma à afficher dans un schéma réseau
        /// </summary>
        public C2iObjetDeSchema ObjetDeSchema
        {
            get
            {
                IElementDeSchemaReseau element = ElementAssocie;
                C2iObjetDeSchema objetDeSchema = null;
                if (element != null)
                {
                    objetDeSchema = element.GetObjetDeSchema(this);
                    if (objetDeSchema != null && (Width ==0 || Height == 0 ))
                    {
                        C2iSymbole symbole = element.SymboleADessiner;
                        if (symbole != null)
                            objetDeSchema.Size = symbole.Size;
                        else
                            objetDeSchema.Size = new System.Drawing.Size(30, 30);
                    }
                }
                return objetDeSchema;
            }
        }



        public CResultAErreur DeleteObjetLie(bool bDansContexteCourant)
        {
            
            CResultAErreur result = CResultAErreur.True;
            if (SchemaReseauInclus != null)
            {
                CSchemaReseau schema = SchemaReseauInclus;
                ElementAssocie = null;
                SchemaReseauInclus = null;
                result = schema.Delete(bDansContexteCourant);

            }
            else if (LienReseau != null)
            {
               
                CLienReseau lien = LienReseau;
                ElementAssocie = null;
                LienReseau = null;
           //     result = lien.Delete(bDansContexteCourant);
                /*if (result)
                {
                    ElementAssocie = null;
                    LienReseau = null;
                }*/
            }
            return result;
        }

        /// <summary>
        /// Retourne le champ faisant le lien avec des éléments de schéma
        /// d'un certain type
        /// </summary>
        /// <param name="typeElements"></param>
        /// <returns></returns>
        internal static string GetChampLienElement(Type typeElements)
        {
            if (typeElements == typeof(CSite))
                return CSite.c_champId;
            else if (typeElements == typeof(CEquipementLogique))
                return CEquipementLogique.c_champId;
            else if (typeElements == typeof(CSchemaReseau))
                return c_champIdSchemaReseauContenu;
            else if (typeElements == typeof(CEntiteSnmp))
                return CEntiteSnmp.c_champId;
            else if (typeElements == typeof(CLienReseau))
                return CLienReseau.c_champId;
            throw new Exception("Can not find link from schema to " + typeElements.ToString());
        }


        [TiagField("Forward_Backward")]
        public int TiagForwardBackwardCode
        {
            get
            {
                CDonneeDessinLienDeSchemaReseau data = DonneeDessin as CDonneeDessinLienDeSchemaReseau;
                if (data == null)
                    return (int)ESensAllerRetourLienReseau.Forward;
                else
                    return (int)data.Forward_Backward;
            }
            set
            {
                if (LienReseau != null)
                {
                    CDonneeDessinLienDeSchemaReseau data = DonneeDessin as CDonneeDessinLienDeSchemaReseau;
                    if (data == null)
                        data = new CDonneeDessinLienDeSchemaReseau(ContexteDonnee.IdContexteDonnee);
                    data.Forward_Backward = (ESensAllerRetourLienReseau)value;
                    DonneeDessin = data;
                }
            }
        }

        /// <summary>
        /// Retourne true si l'élément associé contient un sous schéma pour ce schéma
        /// </summary>
        public bool IsCableALinterieur
        {
            get
            {
                if ( ElementAssocie != null && SchemaReseau!= null  && ElementAssocie is CSite )
                {
                    foreach ( CSchemaReseau sousSchema in SchemaReseau.SchemaFils )
                    {
                        if (ElementAssocie.Equals ( sousSchema.SiteApparenance ) )
                            return true;
                    }
                }
                return false;
            }
        }

        //////GESTION DES CHEMINS POUR LES LIENS RESEAU

        //---------------------------------------------
        [RelationFille(typeof(CCheminLienReseau), "ElementDeSchemaConcerne")]
        public CListeObjetsDonnees CheminsAssocies
        {
            get
            {
                return GetDependancesListe(CCheminLienReseau.c_nomTable, c_champId);
            }
        }

        /// <summary>
        /// Définit le tableau des <see cref="CSchemaReseau">schémas réseau</see> empruntés successivement par la première extrémité
        /// du <see cref="CLienReseau">lien réseau</see>
        /// </summary>
        /// <param name="schemas">Le tableau de schémas réseau</param>
        [DynamicMethod("Indicate wich successive network diagram is used by the first link extremity",
            "Network diagram array")]
        public void SetPathsForNetworkLinkExt1(CSchemaReseau[] schemas)
        {
            CListeObjetsDonnees lst = TousCheminsExtremite1;
            CObjetDonneeAIdNumerique.Delete(lst, true);
            CreateChemin(schemas, EExtremiteLienReseau.Un);
        }


        /// <summary>
        /// Définit le tableau des <see cref="CSchemaReseau">schémas réseau</see> empruntés successivement par la deuxième extrémité
        /// du <see cref="CLienReseau">lien réseau</see>
        /// </summary>
        /// <param name="schemas">Le tableau de schémas réseau</param>
        [DynamicMethod("Indicate wich successive network diagram is used by the second link extremity",
            "Network diagram array")]
        public void SetPathsForNetworkLinkExt2(CSchemaReseau[] schemas)
        {
            CListeObjetsDonnees lst = TousCheminsExtremite1;
            CObjetDonneeAIdNumerique.Delete(lst, true);
            CreateChemin(schemas, EExtremiteLienReseau.Deux);
        }

        private CCheminLienReseau CreateChemin(CSchemaReseau[] schemas, EExtremiteLienReseau extremite)
        {
            if (schemas.Length == 0)
                return null;
            CCheminLienReseau chemin = new CCheminLienReseau(ContexteDonnee);
            chemin.CreateNewInCurrentContexte ( );
            chemin.ElementDeSchemaConcerne = this;
            chemin.SchemaReseauUtilise = schemas[0];
            chemin.NumeroExtremiteConcernee = (int)extremite;
            List<CSchemaReseau> copie = new List<CSchemaReseau>(schemas);
            copie.RemoveAt(0);
            CCheminLienReseau cheminFils = CreateChemin(copie.ToArray(), extremite);
            if (cheminFils != null)
                cheminFils.CheminParent = chemin;
            return chemin;
            
        }


        //---------------------------------------------
        /// <summary>
        /// Renvoie la liste de tous les <see cref="CCheminLienReseau">chemins réseau</see> empruntés pour atteindre l'extrémité 1 du <see cref="CLienReseau">lien réseau</see>
        /// </summary>
        [DynamicChilds("All Paths for ext 1", typeof(CCheminLienReseau))]
        public CListeObjetsDonnees TousCheminsExtremite1
        {
            get
            {
                CListeObjetsDonnees lst = CheminsAssocies;
                lst.FiltrePrincipal = CFiltreData.GetAndFiltre(lst.FiltrePrincipal,
                    new CFiltreData (CCheminLienReseau.c_champExtremiteConcernee + "=@1", (int)EExtremiteLienReseau.Un));
                return lst;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// <see cref="CCheminLienReseau">Chemin réseau</see> racine pour atteindre l'extremité 1 du <see cref="CLienReseau">lien réseau</see>
        /// </summary>
        [DynamicField("Path 1")]
        public CCheminLienReseau RacineChemin1
        {
            get
            {
                CListeObjetsDonnees liste = TousCheminsExtremite1;
                liste.Filtre = new CFiltreData(CCheminLienReseau.c_champIdCheminParent + " is null");
                if (liste.Count == 1)
                    return liste[0] as CCheminLienReseau;
                return null;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Renvoie la liste de tous les <see cref="CCheminLienReseau">chemins réseau</see> empruntés pour atteindre l'extrémité 2 du <see cref="CLienReseau">lien réseau</see>
        /// </summary>
        [DynamicChilds("All Paths for ext 2", typeof(CCheminLienReseau))]
        public CListeObjetsDonnees TousCheminsExtremite2
        {
            get
            {
                CListeObjetsDonnees lst = CheminsAssocies;
                lst.FiltrePrincipal = CFiltreData.GetAndFiltre(lst.FiltrePrincipal,
                    new CFiltreData(CCheminLienReseau.c_champExtremiteConcernee + "=@1", (int)EExtremiteLienReseau.Deux));
                return lst;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// <see cref="CCheminLienReseau">Chemin réseau</see> racine pour atteindre l'extremité 2 du <see cref="CLienReseau">lien réseau</see>
        /// </summary>
        [DynamicField("Path 2")]
        public CCheminLienReseau RacineChemin2
        {
            get
            {
                CListeObjetsDonnees liste = TousCheminsExtremite2;
                liste.Filtre = new CFiltreData(CCheminLienReseau.c_champIdCheminParent + " is null");
                if (liste.Count == 1)
                    return liste[0] as CCheminLienReseau;
                return null;
            }
        }

        //Si l'extremité 1 n'est pas dans le schéma principal,
        //Retourne le schéma contenant l'extremité 1
        //Sinon, retourne  null;
        public CSchemaReseau SchemaContenantExtremite1
        {
            get
            {
                CCheminLienReseau chemin = RacineChemin1;
                if (chemin == null)
                    return null;
                while (chemin.CheminsFils.Count != 0)
                    chemin = chemin.CheminsFils[0] as CCheminLienReseau;
                return chemin.SchemaReseauUtilise;
            }
        }

        //Si l'extremité 2 n'est pas dans le schéma principale,
        //Retour le schéma contenant l'extremité 2
        //sinon, retourne null;
        public CSchemaReseau SchemaContenantExtremite2
        {
            get
            {
                CCheminLienReseau chemin = RacineChemin2;
                if (chemin == null)
                    return null;
                while (chemin.CheminsFils.Count != 0)
                    chemin = chemin.CheminsFils[0] as CCheminLienReseau;
                return chemin.SchemaReseauUtilise;
            }
        }

        /// <summary>
        /// Retourne le chemin correspondant à l'extremité demandée
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public CCheminLienReseau GetCheminToElement(IElementALiensReseau elt)
        {
            CLienReseau lien = LienReseau;
            if (lien == null)
                return null;
            if (elt == null)
                return null;
            if (elt.Equals(lien.Element1))
                return RacineChemin1;
            if (elt.Equals(lien.Element2))
                return RacineChemin2;
            return null;
        }

    }
}
