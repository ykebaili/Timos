using System;
using System.Collections;
using System.Data;
using System.Linq;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using timos.securite;
using timos.data.reseau.arbre_operationnel;
using timos.data.reseau.graphe;
using timos.data.snmp;
using sc2i.expression;

namespace timos.data
{
	/// <summary>
	/// Représente visuellement une partie de réseau modélisé par TIMOS.
    /// Un schéma réseau peut être indépdendant ou représenter un lien réseau
	/// </summary>
    [DynamicClass("Network diagram")]
	[Table(CSchemaReseau.c_nomTable, CSchemaReseau.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CSchemaReseauServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [AutoExec("Autoexec")]
    [TiagClass("Network diagram","Id", true)]
	public class CSchemaReseau : 
        CElementAChamp, 
        IElementDeSchemaReseau,
        IDefinisseurSymbole,
        IElementASymbolePourDessin,
        IEtapeLienReseau,
        IObjetDonneeAutoReference,
        IElementAEO
        
	{
		public const string c_nomTable = "NETWORK_DIAG";
		public const string c_champId = "NWD_ID";
		public const string c_champLibelle = "NWD_LABEL";
        public const string c_champImageReduite = "NWD_IMAGE";
        public const string c_roleChampCustom = "NETWORK_DIAG";
        public const string c_champUtiliseImageReduite = "NWD_USE_IMG";
        public const string c_champIdSchemaParent = "NWD_PARENT_ID";
        public const string c_champIdLienReseauAuquelJappartient = "NWD_LINK_ID";
        public const string c_champCodesEOS = "NWD_EOS_CODES";
        public const string c_champModeOperationnel = "NWD_OPER_MODE";
        public const string c_champSnmpUpdateDelai = "NWD_SNMP_DELAI";

        public const string c_champCacheSchema = "NWD_SCHEMA_CACHE";
     

		/// /////////////////////////////////////////////
		public CSchemaReseau( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CSchemaReseau(DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }




        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Network Diagram", typeof(CSchemaReseau), typeof(CTypeSchemaReseau));
        }

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Network diagram @1|20026",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            UtiliseImageReduite = true;
            CodeModeOperationnel = (int)EModeOperationnelSchema.AutomaticRedundancy;
            DelaiUpdateSnmpSecondes = 0;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

        //---------------------------------------------------------
        
		
        //---------------------------------------------------------
		/// <summary>
		/// Libellé du schéma
		/// </summary>
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



        //-------------------------------------------------------------------
        public void TiagSetTypeSchemaKeys(object[] lstKeys)
        {
            CTypeSchemaReseau typeSchema = new CTypeSchemaReseau(ContexteDonnee);
            if (typeSchema.ReadIfExists(lstKeys))
                TypeSchemaReseau = typeSchema;
        }
        /// <summary>
        /// Obtient ou définit le Type du schéma réseau.
        /// Le type de schéma réseau définit le comportement des schémas réseau de ce type, par exemple
        /// c'est au niveau du type de schéma qu'on précise quels sont les formulaires personnalisés qui seront
        /// affichés sur les schémas réseau de ce type.
        /// </summary>
        ///
        [Relation(CTypeSchemaReseau.c_nomTable, CTypeSchemaReseau.c_champId, CTypeSchemaReseau.c_champId, false, false)]
        [DynamicField("Network diagram type")]
        [TiagRelation(typeof(CTypeSchemaReseau),"TiagSetTypeSchemaKeys")]
        public CTypeSchemaReseau TypeSchemaReseau
        {
            get
            {
                return (CTypeSchemaReseau)GetParent(CTypeSchemaReseau.c_champId, typeof(CTypeSchemaReseau));
            }
            set
            {
                SetParent(CTypeSchemaReseau.c_champId, value);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Donne la liste des <see cref="CElementDeSchemaReseau">éléments de schéma réseau</see> faisant partie de ce schéma réseau
        /// </summary>
        [RelationFille(typeof(CElementDeSchemaReseau), "SchemaReseau")]
        [DynamicChilds("Network diagram elements", typeof(CElementDeSchemaReseau))]
        public CListeObjetsDonnees ElementsDeSchema
        {
            get
            {
                return GetDependancesListe(CElementDeSchemaReseau.c_nomTable, CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens);
            }
        }

        [TableFieldProperty(CSchemaReseau.c_champCacheSchema, IsInDb=false)]
        public  C2iSchemaReseau SchemaReseauCacheUtilisationInterne
        {
            get
            {
                return null;
                /*C2iSchemaReseau schema = Row[c_champCacheSchema] as C2iSchemaReseau;
                return schema;*/
            }
        }


        /// <summary>
        /// Force la mise à jour du croquis
        /// </summary>
        [DynamicMethod("Update network diagram thumbnail")]
        public void UpdateThumbnail()
        {
            SetSchema(GetSchema(true));
        }


        public C2iSchemaReseau GetSchema(bool bCreationAutorisee)
        {
            C2iSchemaReseau objet = SchemaReseauCacheUtilisationInterne;
            if (objet != null)
            {
                if (objet.Schema != null && objet.Schema.ContexteDonnee == ContexteDonnee)
                    return objet;
            }
                
            objet = new C2iSchemaReseau(this);
            CListeObjetsDonnees listeElements = ElementsDeSchema;
            listeElements.ReadDependances("Site", 
                "EquipementLogique", 
                "LienReseau", 
                "SchemaReseauInclu",
                "SchemaReseauInclu.SiteAppartenance", 
                "SchemaReseauContenu");

            listeElements.Filtre = new CFiltreData(CElementDeSchemaReseau.c_champDataAffichageString + "=@1", "");
            listeElements.ReadBlobs(CElementDeSchemaReseau.c_champDataAffichage);
            listeElements.Filtre = null;
            listeElements.Tri = CElementDeSchemaReseau.c_champZOrder;
            int nMaxX = 0;
            int nMaxY = 0;
            if (bCreationAutorisee)
            {
                foreach (CSchemaReseau fils in SchemaFils)
                {
                    bool bFind = false;
                    IElementDeSchemaReseau elementRecherche = fils;
                    if (fils.SiteApparenance != null)
                        elementRecherche = fils.SiteApparenance;
                    foreach (CElementDeSchemaReseau elt in listeElements)
                    {
                        if (elt.ElementAssocie != null && elt.ElementAssocie.Equals(elementRecherche))
                            bFind = true;

                    }
                    if (!bFind)
                    {
                        CElementDeSchemaReseau newElement = new CElementDeSchemaReseau(ContexteDonnee);
                        newElement.CreateNewInCurrentContexte();
                        newElement.ElementAssocie = elementRecherche;
                        newElement.SchemaReseau = this;
                    }
                }
            }

            foreach (CElementDeSchemaReseau elt in listeElements)
            {
                C2iObjetDeSchema fils = elt.ObjetDeSchema;
                if (fils != null)
                {
                    fils.Parent = objet;
                    objet.AddChild(fils);
                    nMaxX = Math.Max(fils.Position.X + fils.Size.Width, nMaxX);
                    nMaxY = Math.Max(fils.Position.Y + fils.Size.Height, nMaxY);
                    fils.DonneeDessin = elt.DonneeDessin;
                }
                else if (elt.DonneeDessin != null)
                {
                    if (typeof(CDonneeDessinEtiquetteSchema).IsAssignableFrom(elt.DonneeDessin.GetType()))
                    {
                        C2iEtiquetteSchema etiq = new C2iEtiquetteSchema();
                        etiq.ElementDeSchema = elt;
                        etiq.Parent = objet;
                        objet.AddChild(etiq);
                        nMaxX = Math.Max(etiq.Position.X + etiq.Size.Width, nMaxX);
                        nMaxY = Math.Max(etiq.Position.Y + etiq.Size.Height, nMaxY);
                        etiq.DonneeDessin = elt.DonneeDessin;
                    }
                    else if (typeof(C2iObjetDeSchema).IsAssignableFrom(elt.DonneeDessin.GetType()))
                    {
                        C2iObjetDeSchema objetDeSchema = elt.DonneeDessin as C2iObjetDeSchema;
                        objetDeSchema.ElementDeSchema = elt;
                        objetDeSchema.Parent = objet;
                        objet.AddChild(objetDeSchema);
                    }
                }
            }
            if (bCreationAutorisee)
                objet.VerifieUniciteIds();
            else
                objet.ResetNextIdObjetDeSchema();

            objet.Size = new Size(2000, 2000);
            objet.Position = new Point(0, 0);
            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheSchema, objet);
            return objet;
        }
           
        public void SetSchema (C2iSchemaReseau value)
        {
                if (value != null )
                {
                    //Réordonnee les CElementDeSchema
                    int nIndex = 0;
                    foreach ( C2iObjetDeSchema objet in value.Childs )
                    {
                        if (objet.ElementDeSchema != null && objet.ElementDeSchema.IsValide())
                        {
                            objet.ElementDeSchema.ZOrder = nIndex++;
                            objet.ElementDeSchema.DonneeDessin = objet.DonneeDessin;
                        }
                    }
                    //Stocke l'image du schéma
                    Bitmap bmp = value.GetBitmapCopie(2048, true);
                    ImageReduite = bmp;
                    bmp.Dispose();
                } 
            
        }

        [DynamicMethod("Ensure required item is present in the diagram", "Required item")]
        public CElementDeSchemaReseau EnsureItemIsInDiagram(IElementDeSchemaReseau elt)
        {
            if (elt == null)
                return null;
            if ( elt is CLienReseau )
            {
                EnsureItemIsInDiagram(((CLienReseau)elt).Element1);
                EnsureItemIsInDiagram(((CLienReseau)elt).Element2);
            }
            CListeObjetsDonnees lst = ElementsDeSchema;
            CElementDeSchemaReseau eltDeSchema = lst.ToArray<CElementDeSchemaReseau>().FirstOrDefault(e => e.ElementAssocie.Equals(elt));
            if (eltDeSchema != null)
                return eltDeSchema;
            eltDeSchema = new CElementDeSchemaReseau(ContexteDonnee);
            eltDeSchema.CreateNewInCurrentContexte();
            eltDeSchema.SchemaReseau = this;
            eltDeSchema.ElementAssocie = elt;
            eltDeSchema.X = 0;
            eltDeSchema.Y = 0;
            eltDeSchema.Width = 32;
            eltDeSchema.Height = 32;

            return eltDeSchema;
        }





        #region IElementDeSchemaReseau Membres

        public C2iSymbole SymboleADessiner
        {
            get
            {
                if (UtiliseImageReduite)
                {
                    Bitmap bmp = ImageReduite;
                    if (bmp != null)
                    {
                        C2iSymboleImage symbole = new C2iSymboleImage();
                        symbole.Size = bmp.Size;
                        symbole.ImageFile = bmp;
                        symbole.BackColor = Color.Yellow;
                        return symbole;
                    }
                    return null;
                }
                else
                {
                    C2iSymbole symbole = null;
                    if (Symbole != null)
                        symbole = Symbole.Symbole;
                    if (symbole == null)
                        symbole = CSymbole.GetSymboleParDefaut(typeof(CSchemaReseau), ContexteDonnee);
                    if (symbole != null)
                    {
                        symbole = symbole.GetCloneSymbole();
                        symbole.ElementASymbole = this;
                    }
                    return symbole;
                }
            }
        }


        
        #endregion


        public C2iSymbole SymboleDefiniADessiner
        {
            get
            {
                return SymboleADessiner;
            }

        }


        #region IElementDeSchemaReseau Membres


        public C2iObjetDeSchema GetObjetDeSchema(CElementDeSchemaReseau elementDeSchema)
        {
            C2iSchemaReseauDansSchemaReseau obj = new C2iSchemaReseauDansSchemaReseau();
            obj.ElementDeSchema = elementDeSchema;
            return obj;
        }

        #endregion

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champImageReduite, NullAutorise = true)]
        public CDonneeBinaireInRow DataImage
        {
            get
            {
                if (Row[c_champImageReduite] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champImageReduite);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champImageReduite, donnee);
                }
                object obj = Row[c_champImageReduite];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champImageReduite] = value;
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
        /// Obtient, définit la relation avec le <see cref="CLienReseau">lien réseau</see> lorsque le schéma est un schéma de lien réseau
        /// </summary>
        [Relation ( 
            CLienReseau.c_nomTable,
            CLienReseau.c_champId,
            CSchemaReseau.c_champIdLienReseauAuquelJappartient,
            false,
            true,
            true )]
        [DynamicField("Network link")]
        [TiagRelation(typeof(CLienReseau),"TiagSetLienReseauKeys")]
        public CLienReseau LienReseau
        {
            get
            {
                return (CLienReseau)GetParent(c_champIdLienReseauAuquelJappartient, typeof(CLienReseau));
            }
            set
            {
                SetParent(c_champIdLienReseauAuquelJappartient, value);
            }
        }
        
        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public Bitmap ImageReduite
        {
            get
            {
                CDonneeBinaireInRow data = DataImage;
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        Bitmap image = (Bitmap)Bitmap.FromStream(stream);
                        return image;
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataImage;
                    data.Donnees = null;
                    DataImage = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        value.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        CDonneeBinaireInRow data = DataImage;
                        data.Donnees = stream.GetBuffer();
                        DataImage = data;
                    }
                    catch
                    {
                        CDonneeBinaireInRow data = DataImage;
                        data.Donnees = null;
                        DataImage = data;
                    }
                }
            }
        }

        #region IDefinisseurSymbole Membres

        
        /// <summary>
        /// Le symbole graphique de bibliothèque associé au schéma réseau, lorsqu'il existe
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
           CSymboleDeBibliotheque.c_champId,
          CSymboleDeBibliotheque.c_champId,
            false,
            false,
            false)]
        [DynamicField("Library Symbol")]

        public CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)GetParent(CSymboleDeBibliotheque.c_champId, typeof(CSymboleDeBibliotheque));
            }
            set
            {
                if (SymbolePropre != null)
                {

                    SymbolePropre = null;
                }
                SetParent(CSymboleDeBibliotheque.c_champId, value);

            }

        }

        //------------------------------------------------
        /// <summary>
        /// Le symbole graphique propre au schéma réseau, lorsqu'il existe
        /// </summary>
        [RelationFille(typeof(CSymbole), "SchemaReseau")]
        [DynamicField("Proper symbol")]
        public CSymbole SymbolePropre
        {

            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CSchemaReseau.c_champId);
                if (liste.Count > 0)
                    return (CSymbole)liste[0];
                else
                    return null;
            }

            set
            {

                Row[CSymboleDeBibliotheque.c_champId] = null;
                if (value == null)
                {
                    if (SymbolePropre != null)
                        SymbolePropre.Delete(true);
                }
                else
                {
                    value.SchemaReseau = this;
                }
            }
        }

        //------------------------------------------------
        /// <summary>
        /// Le symbole graphique associé au site. celui-ci peut être :
        /// <ul>
        /// <li>Le symbole graphique propre au schéma réseau, ou</li>
        /// <li>Le symbole graphique de bibliothèque associé au schéma réseau, ou</li>
        /// <li>Le symbole graphique associé au type de schéma réseau</li>
        /// </ul>
        /// Ce symbole graphique permet de représenter le schéma réseau à l'intérieur d'autres schémas.
        /// </summary>
        [DynamicField("Symbol")]
        public CSymbole Symbole
        {
            get
            {
                if (SymbolePropre != null)
                    return SymbolePropre;
                if (SymboleDeBibliotheque != null)
                    return SymboleDeBibliotheque.Symbole;
                if (TypeSchemaReseau != null)
                    return TypeSchemaReseau.Symbole;
                return null;
            }

        }


        /// <summary>
        /// Booléen indiquant que le symbole graphique à exploiter pour ce schéma réseau
        /// dans d'autres schémas est la vue réduite du schéma réseau lui-même.
        /// </summary>
        [TableFieldProperty(c_champUtiliseImageReduite)]
        [DynamicField("Uses reduced image")]
        public bool UtiliseImageReduite
        {
            get
            {
                return (bool)Row[c_champUtiliseImageReduite];
            }
            set
            {
                Row[c_champUtiliseImageReduite] = value;
            }
        }


        public Type GetTypePourLequelOnSelectionneUnSymbole()
        {
            return typeof(CSchemaReseau);
        }

        #endregion

       
       public override CFiltreData FiltreStandard
        {
            get
            {
               
                
                CFiltreData filtre = new CFiltreData(c_champIdSchemaParent + " is null and "+
                    c_champIdLienReseauAuquelJappartient+" is null");
                return filtre;               
            }
        }

        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[] { TypeSchemaReseau };
            }
        }





          //----------------------------------------------------
        public override CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeSchemaReseau == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeSchemaReseau_ChampCustom rel in TypeSchemaReseau.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeSchemaReseau_Formulaire rel1 in TypeSchemaReseau.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));

        }

        //----------------------------------------------------
        public override CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        
        public override CRelationElementAChamp_ChampCustom  GetNewRelationToChamp()
        {
 	            return new CRelationSchemaReseau_ChampCustom(ContexteDonnee);
        }


        /// <summary>
        /// Donne la liste des <see cref="CRelationSchemaReseau_ChampCustom">relations du schéma réseau avec les champs personnalisés</see> qui le concernent
        /// </summary>
        [RelationFille(typeof(CRelationSchemaReseau_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationSchemaReseau_ChampCustom))]
	    public override CListeObjetsDonnees  RelationsChampsCustom
        {
		    get
			{
				return GetDependancesListe(CRelationSchemaReseau_ChampCustom.c_nomTable, c_champId);
			}
        }


        #region IEtapeLienReseau Membres

        public IElementALiensReseau[] ElementsALiensContenus
        {
            get 
            {
                List<IElementALiensReseau> eltsALiens = new List<IElementALiensReseau>();
                foreach (CElementDeSchemaReseau elementDeSchema in ElementsDeSchema)
                {
                    IElementALiensReseau eltALien = elementDeSchema.ElementAssocie as IElementALiensReseau;
                    if (eltALien != null)
                        eltsALiens.Add(eltALien);
                }
                return eltsALiens.ToArray();
            }
        }

        public IEtapeLienReseau[] EtapesContenues
        {
            get
            {
                List<IEtapeLienReseau> etapes = new List<IEtapeLienReseau>();
                foreach (CElementDeSchemaReseau elementDeSchema in ElementsDeSchema)
                {
                    IEtapeLienReseau etape = elementDeSchema.ElementAssocie as IEtapeLienReseau;
                    if (etape != null)
                        etapes.Add(etape);
                }
                return etapes.ToArray();
            }
        }

        #endregion
        

        //-------------------------------------------------------------------
        public void TiagSetSchemaParentKeys(object[] lstKeys)
        {
            CSchemaReseau parent = new CSchemaReseau(ContexteDonnee);
            if (parent.ReadIfExists(lstKeys))
                SchemaParent = parent;
        }
        
        
        //--------------------------------------------------------------------
        /// <summary>
        /// Schéma parent de ce schéma.<br/> 
        /// Ceci ne concerne que les schémas qui n'existent que dans un seul autre schéma (schémas de câblage de lien réseau)
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CSchemaReseau.c_champIdSchemaParent,
            false,
            true,
            true)]
        [DynamicField("Parent diagram")]
        [TiagRelation(typeof(CSchemaReseau),"TiagSetSchemaParentKeys")]
        public CSchemaReseau SchemaParent
        {
            get
            {
                return (CSchemaReseau)GetParent(c_champIdSchemaParent, typeof(CSchemaReseau));
            }
            set
            {
                SetParent(c_champIdSchemaParent, value);
            }
        }



     

        //-------------------------------------------------------------------
        /// <summary>
        /// Liste des schémas réseaux conntenus dans ce schéma
        /// </summary>
        [RelationFille(typeof(CSchemaReseau), "SchemaParent")]
        [DynamicChilds("Child diagrams", typeof(CSchemaReseau))]
        public CListeObjetsDonnees SchemaFils
        {
            get
            {
                return GetDependancesListe(c_nomTable, false, c_champIdSchemaParent);
            }
        }



        #region IObjetDonneeAutoReference Membres

        public string ChampParent
        {
            get { return c_champIdSchemaParent; }
        }

        public string ProprieteListeFils
        {
            get { return ("SchemaFils"); }
        }

        #endregion

        //------------------------------------------------------------
        public CSchemaReseau[] GetSousSchemas ()
        {
            List<CSchemaReseau> lstRetour = new List<CSchemaReseau>();
            foreach (CSchemaReseau fils in SchemaFils)
            {
                lstRetour.Add(fils);
                lstRetour.AddRange(fils.GetSousSchemas());
            }
            return lstRetour.ToArray();
            /*
            CListeObjetsDonnees listeelts = ElementsDeSchema;
            listeelts.Filtre = new CFiltreData ( CElementDeSchemaReseau.c_champIdSchemaReseauInclus+" is not null");
            List<CSchemaReseau> lstRetour = new List<CSchemaReseau>();
            foreach ( CElementDeSchemaReseau elt in listeelts )
            {
                CSchemaReseau schema = elt.SchemaReseauInclus;
                if ( schema != null )
                {
                    lstRetour.Add ( schema );
                    lstRetour.AddRange ( schema.GetSousSchemas() );
                }

            }
            return lstRetour.ToArray();*/
        }


        /// <summary>
        /// Indique à quel site appartient le schéma réseau.
        /// Ceci a un sens lorsque le schéma réseau représente par exemple le schéma de
        /// câblage d'un <see cref="CLienReseau">lien réseau</see> dans un site extrémité de ce lien.
        /// </summary>
        public void TiagSetSiteAppartenanceKeys ( object[] keys )
        {
            CSite site = new CSite ( ContexteDonnee );
            if ( site.ReadIfExists ( keys ) )
                SiteApparenance = site;
        }
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            false,
            true,
            true)]
        [DynamicField("Owner site")]
        [TiagRelation(typeof(CSite), "TiagSetSiteAppartenanceKeys")]
        public CSite SiteApparenance
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }
        }

        //------------------------------------------------------------
        public CElementDeSchemaReseau[] GetElementsForType ( Type typeElements )
        {
            List<CElementDeSchemaReseau> lstRetour = new List<CElementDeSchemaReseau>();
            CListeObjetsDonnees listeElements = ElementsDeSchema;
            string strChamp = CElementDeSchemaReseau.GetChampLienElement(typeElements);
            listeElements.Filtre = new CFiltreData(strChamp + " is not null");
            foreach (CElementDeSchemaReseau elt in listeElements)
                lstRetour.Add(elt);
            foreach (CSchemaReseau schema in GetSousSchemas())
            {
                foreach (CElementDeSchemaReseau elt in schema.GetElementsForType(typeElements))
                    lstRetour.Add(elt);
            }
            return lstRetour.ToArray();
        }

        //------------------------------------------------------------
        public CElementDeSchemaReseau[] GetElementsForType<TypeElements>()
        {
            return GetElementsForType ( typeof(TypeElements) );
        }


        //------------------------------------------------------------
        public TypeElements[] GetElementsLies<TypeElements>()
            where TypeElements : class, IElementDeSchemaReseau
        {
            CElementDeSchemaReseau[] listeElements = GetElementsForType<TypeElements>();
            string strChamp = CElementDeSchemaReseau.GetChampLienElement(typeof(TypeElements));
            List<TypeElements> lstRetour = new List<TypeElements>();
            foreach (CElementDeSchemaReseau elt in listeElements)
            {
                TypeElements eltDeSchema = elt.GetParent(strChamp, typeof(TypeElements)) as TypeElements;
                if (eltDeSchema != null)
                    lstRetour.Add(eltDeSchema);
            }
            foreach (CSchemaReseau sousSchema in GetSousSchemas())
                lstRetour.AddRange(sousSchema.GetElementsLies<TypeElements>());
            return lstRetour.ToArray();
        }



        //------------------------------------------------------------
        public CEquipementLogique[] GetEquipementsLiesAuSite(CSite site)
        {
            CListeObjetsDonnees liste = ElementsDeSchema;
            //Pas de filtre avancé pour prendre en compte ce qui n'est pas encore
            //dans la base
            liste.Filtre = new CFiltreData(CEquipementLogique.c_champId + " is not null");
            List<CEquipementLogique> lstEqpts = new List<CEquipementLogique>();
            foreach (CElementDeSchemaReseau element in liste)
            {
                if ( element.EquipementLogique.Row[CSite.c_champId] is int )
                    if ((int)element.EquipementLogique.Row[CSite.c_champId] == site.Id)
                        lstEqpts.Add(element.EquipementLogique);
            }
            foreach ( CSchemaReseau sousSchema in GetSousSchemas() )
            {
                foreach ( CEquipementLogique eqpt in sousSchema.GetEquipementsLiesAuSite ( site ) )
                    lstEqpts.Add ( eqpt );
            }
            return lstEqpts.ToArray();
        }

        //------------------------------------------------------------
        public CLienReseau[] GetLiensDeEquipements(CEquipementLogique[] equipements)
        {
            if (equipements.Length > 0)
            {
                Dictionary<int, bool> dicEqptsCherches = new Dictionary<int, bool>();
                foreach (CEquipementLogique eqptTest in equipements)
                    dicEqptsCherches[eqptTest.Id] = true;
                CListeObjetsDonnees listeLiaisons = ElementsDeSchema;
                listeLiaisons.Filtre = new CFiltreData(CLienReseau.c_champId + " is not null");
                listeLiaisons.ReadDependances("LienReseau", "LienReseau.Equipement1", "LienReseau.Equipement2");
                List<CLienReseau> lstRetour = new List<CLienReseau>();
                foreach (CElementDeSchemaReseau elementLiaison in listeLiaisons)
                {
                    CEquipementLogique eqpt1 = elementLiaison.LienReseau.Equipement1;
                    CEquipementLogique eqpt2 = elementLiaison.LienReseau.Equipement2;
                    if (eqpt1 != null && dicEqptsCherches.ContainsKey(eqpt1.Id) ||
                         eqpt2 != null && dicEqptsCherches.ContainsKey(eqpt2.Id))
                        lstRetour.Add(elementLiaison.LienReseau);
                }
                foreach ( CSchemaReseau schema in GetSousSchemas() )
                {
                    foreach ( CLienReseau lien in schema.GetLiensDeEquipements ( equipements ) )
                        lstRetour.Add ( lien );
                }
                return lstRetour.ToArray();
            }

            return new CLienReseau[0];
        }


        /// <summary>
        /// Code du mode opérationnel pour ce schéma, c'est à dire code définissant
        /// le mode de calcul de l'état opérationnel du schéma (pour la supervision).
        /// </summary>
        [TableFieldProperty(CSchemaReseau.c_champModeOperationnel)]
        [DynamicField("Operational mode code")]
        public int CodeModeOperationnel
        {
            get
            {
                return (int)Row[c_champModeOperationnel];
            }
            set
            {
                Row[c_champModeOperationnel] = value;
            }
        }


        /// <summary>
        /// Délai de mise à jour de la vue de supervision, en ce qui concerne
        /// les <see cref="CEntiteSnmp">entités SNMP</see> qui sont incluses dans le schéma.
        /// Fixe en fait la période d'interrogation des entités SNMP incluses dans le schéma,
        /// pour le rafraîchissement de leurs valeurs.
        /// </summary>
        [TableFieldProperty(c_champSnmpUpdateDelai)]
        [DynamicField("Snmp update delai seconds")]
        public int DelaiUpdateSnmpSecondes
        {
            get
            {
                int nVal = (int)Row[c_champSnmpUpdateDelai];
                if (nVal == 0)
                    nVal = 60 * 3;
                return nVal;
            }
            set
            {
                Row[c_champSnmpUpdateDelai] = value;
            }
        }


        /// <summary>
        /// Obtient ou détermine le <see cref="CModeOperationnelSchema">mode opérationnel du schéma</see> réseau,
        /// c'est à dire le mode de calcul de l'état opérationnel pour ce schéma réseau.
        /// </summary>
        [DynamicField("Operationnal mode")]
        public CModeOperationnelSchema ModeOperationnel
        {
            get
            {
                return new CModeOperationnelSchema((EModeOperationnelSchema)CodeModeOperationnel);
            }
            set
            {
                CodeModeOperationnel = value.CodeInt;
            }
        }


        #region IElementAEO Membres

        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquelles est affecté le schéma réseau<br/>
        /// </summary>
        /// <remarks>
        /// Ces codes sont présentés sous la forme d'une chaîne de caractères<br/>
        /// Chaque code est encadré par deux caractères ~ (exemple : ~01051B~0201~061A0304~)
        /// </remarks>
        [TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
        [DynamicField("Organisational entities codes")]
        public string CodesEntitesOrganisationnelles
        {
            get
            {
                return (string)Row[CUtilElementAEO.c_champEO];
            }
            set
            {
                Row[CUtilElementAEO.c_champEO] = value;
            }
        }

        //-----------------------------------------------------------------
        public CListeObjetsDonnees EntiteOrganisationnellesDirectementLiees
        {
            get
            {
                return CRelationElement_EO.GetEntitesOrganisationnellesDirectementLiees(this);
            }
        }


        public IElementAEO[] DonnateursEO
        {
            get {
                if (SchemaParent != null)
                    return new IElementAEO[] { SchemaParent };
                return new IElementAEO[0];
            }
        }

        public IElementAEO[] HeritiersEO
        {
            get {
                List<IElementAEO> lst = new List<IElementAEO>();
                foreach (CSchemaReseau schema in SchemaFils)
                    lst.Add(schema);
                return lst.ToArray();
            }
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Attribue une nouvelle entité organisationnelle au schéma réseau
        /// </summary>
        /// <param name="nIdEO">Id de l'entité organisationnelle</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        [DynamicMethod(
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }


        /// <summary>
        /// Ote du schéma réseau une entité organisationnelle
        /// </summary>
        /// <param name="nIdEO">Id de l'entité à enlever</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        //-----------------------------------------------------------------
        [DynamicMethod(
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }

        //----------------------------------------------------------------
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

        #endregion

        #region IObjetARestrictionSurEntite Membres

        public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
        {
            CUtilElementAEO.CompleteRestriction(this, restriction);
        }

        #endregion

        /// <summary>
        /// Le data du result contient l'arbre opérationnel
        /// </summary>
        /// <param name="baseGraphes"></param>
        /// <param name="sens"></param>
        /// <returns></returns>
        public CResultAErreur GetArbreOperationnel(CBaseGraphesReseau baseGraphes, ESensAllerRetourLienReseau sens)
        {
            CResultAErreur result = CResultAErreur.True;
            CArbreOperationnel arbre = new CArbreOperationnel();
            result = arbre.CalculeArbre(this, sens, baseGraphes);
            if (result)
                result.Data = arbre;
            return result;
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Fonction de recherche d'un <see cref="CElementDeSchemaReseau">élément de schéma réseau</see> dans le schéma réseau et
        /// tous les schémas inclus et ce de manière récursive.
        /// </summary>
        /// <param name="elt">Elément de schéma réseau recherché</param>
        /// <returns>L'élément de schéma réseau ou Null si non trouvé</returns>
        [DynamicMethod("Search for a specific element in the network diagram and its sub diagramss and return the representation element",
            "Element to search")]
        public CElementDeSchemaReseau FindElement(IElementDeSchemaReseau elt)
        {
            List<CSchemaReseau> lstSchemasAExplorer = new List<CSchemaReseau>();
            lstSchemasAExplorer.Add ( this );
            CElementDeSchemaReseau eltTrouve = null;
            while (lstSchemasAExplorer.Count > 0 )
            {
                List<CSchemaReseau> lstSuite = new List<CSchemaReseau>();
                foreach ( CSchemaReseau schema in lstSchemasAExplorer )
                {
                    eltTrouve = schema.FindInChilds ( elt, lstSuite );
                    if ( eltTrouve != null )
                        return eltTrouve;
                }
                lstSchemasAExplorer = lstSuite;
            }
            return null;
        }


        //-------------------------------------------------------------------------------------
        private CElementDeSchemaReseau FindInChilds(IElementDeSchemaReseau elt, List<CSchemaReseau> lstSchemasAExplorerEnsuite)
        {
            foreach (CElementDeSchemaReseau eltDuSchema in GetElementsForType(elt.GetType()))
            {
                if (elt.Equals(eltDuSchema.ElementAssocie))
                    return eltDuSchema;
            }
            foreach (CSchemaReseau schema in GetElementsLies<CSchemaReseau>())
                lstSchemasAExplorerEnsuite.Add(schema);
            return null;
        }


        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne un tableau des schémas réseau à traverser pour atteindre le schéma réseau recherché,
        /// ce en parcourant de manière récursive les schémas réseau fils de ce schéma réseau.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        [DynamicMethod("Returns list of paths to reach asked network diagram", "Network diagram to reach")]
        public CSchemaReseau[] GetPaths(CSchemaReseau schema)
        {
            if (schema == null)
                return null;
            Stack<CSchemaReseau> lstEtapes = new Stack<CSchemaReseau>();
            if (GetEtapes(schema, lstEtapes))
            {
                List<CSchemaReseau> lst = new List<CSchemaReseau>(lstEtapes.ToArray());
                lst.Reverse();
                return lst.ToArray();
            }
            return null;
        }

        //-------------------------------------------------------------------------------------
        private void FillListeElementsUtilisesRecursif<T>(HashSet<T> lstToFill)
            where T : class, IElementDeSchemaReseau
        {
            foreach (T elt in GetElementsLies<T>())
                lstToFill.Add(elt);
            foreach (CSchemaReseau schema in GetElementsLies<CSchemaReseau>())
                schema.FillListeElementsUtilisesRecursif<T>(lstToFill);
            foreach (CLienReseau lien in GetElementsLies<CLienReseau>())
            {
                if (lien.SchemaReseau != null)
                    lien.SchemaReseau.FillListeElementsUtilisesRecursif<T>(lstToFill);
            }
        }

        //-------------------------------------------------------------------------------------
        private List<T> GetTousElementsType<T>()
            where T : CObjetDonnee, IElementDeSchemaReseau
        {
            StringBuilder bl = new StringBuilder();
            HashSet<T> lstToFill = new HashSet<T>();
            FillListeElementsUtilisesRecursif<T>(lstToFill);
            List<T> lst = new List<T>();
            foreach (T elt in lstToFill)
            {
                lst.Add(elt);
            }
            return lst;
        }


        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne un tableau de tous les <see cref="CSite">sites</see> exploités dans ce schéma réseau et schémas
        /// réseau inclus et ce de manière récursive
        /// </summary>
        [DynamicField("All sites")]
        public CSite[] TousLesSitesUtilises
        {
            get
            {
                return GetTousElementsType<CSite>().ToArray() ;
            }
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne un tableau de tous les <see cref="CLienReseau">liens réseau</see> exploités dans ce schéma réseau et schémas
        /// réseau inclus et ce de manière récursive
        /// </summary>
        [DynamicField("All links")]
        public CLienReseau[] TousLesLiensUtilises
        {
            get
            {
                return GetTousElementsType<CLienReseau>().ToArray();
            }
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne un tableau de tous les schéma réseau exploités dans ce schéma réseau et schémas
        /// réseau inclus et ce de manière récursive
        /// </summary>
        [DynamicField("All network diagram")]
        public CSchemaReseau[] TousLesSchemasUtilises
        {
            get
            {
                return GetTousElementsType<CSchemaReseau>().ToArray() ;
            }
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne un tableau de tous les <see cref="CEquipementLogique">équipements logiques</see> exploités dans ce schéma réseau et schémas
        /// réseau inclus et ce de manière récursive
        /// </summary>
        [DynamicField("All logical equipments")]
        public CEquipementLogique[] TousLesEquipementsLogiques
        {
            get
            {
                return GetTousElementsType<CEquipementLogique>().ToArray();
            }
        }

        //-------------------------------------------------------------------------------------
        private bool GetEtapes(CSchemaReseau schema, Stack<CSchemaReseau> pile)
        {
            if (schema.Equals(this))
                return true;
            foreach (CSchemaReseau schemaFils in SchemaFils)
            {
                pile.Push(schemaFils);
                if (schemaFils.GetEtapes(schema, pile))
                    return true;
                pile.Pop();
            }
            foreach (CSchemaReseau schemaFils in GetElementsLies<CSchemaReseau>())
            {
                pile.Push(schemaFils);
                if (schemaFils.GetEtapes(schema, pile))
                    return true;
                pile.Pop();
            }
            return false;
        }

        //-------------------------------------------------------------------------------------
        public CListeCouplesEntiteChamp GetListeValeursSnmpAffichees()
        {
            CListeCouplesEntiteChamp liste = new CListeCouplesEntiteChamp();
            foreach (CElementDeSchemaReseau elt in GetElementsForType<CEntiteSnmp>())
            {
                CEntiteSnmp entite = elt.EntiteSnmp;
                if (entite == null || entite.SymboleADessiner == null)
                    continue;
                IEnumerable<CDefinitionProprieteDynamique> lstProps = entite.SymboleADessiner.GetChampsUtilises();
                foreach (CDefinitionProprieteDynamique def in lstProps)
                {
                    CDefinitionProprieteDynamiqueChampCustom defChamp = def as CDefinitionProprieteDynamiqueChampCustom;
                    if (defChamp != null)
                    {
                        CChampCustom champ = new CChampCustom(ContexteDonnee);
                        if (champ.ReadIfExists(defChamp.DbKeyChamp))
                        {
                            if (champ.CodeRole == CEntiteSnmp.c_roleChampCustom)
                                liste.AddChamp(entite, champ);
                        }
                    }
                }
            }
            return liste;
        }
                



            
    }
}
