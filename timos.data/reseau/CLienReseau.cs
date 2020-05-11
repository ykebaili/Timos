using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Linq;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;
using sc2i.doccode;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using timos.data.supervision;
using timos.data.snmp;


namespace timos.data
{


    /// <summary>
    /// Un lien réseau représente une liaison entre deux entités; chaque entité d'extrémité peut être un <see cref="CStock">site</see> ou un <see cref="CEquipementLogique">équipement logique</see>
    /// Pour un tel lien, il est également possible de se référer à un objet d'extrémité plus précis comme le <see cref="CPort">port</see> d'un équipement logique ou ce qu'on appelle l'<see cref="CExtremiteLienSurSite">extrémité</see> d'un site
    /// qui est en fait un sous-ensemble du site.
    /// </summary>
    [DynamicClass("Network link")]
    [Table(CLienReseau.c_nomTable, CLienReseau.c_champId, true)]
    [ObjetServeurURI("CLienReseauServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [AutoExec("Autoexec")]
    [LicenceCount(CConfigTypesTimos.c_appType_ElementDeReferentiel)]
    [TiagClass("Network link","Id", true)]
    public class CLienReseau : CElementAChamp,
                               IElementDeSchemaReseau,
                               IElementSupervise
    {
        public const string c_nomTable = "NETWORK_LINK";
        public const string c_champId = "NETWORK_LINK_ID";
        public const string c_champLibelle = "NETWORK_LINK_LABEL";
        public const string c_roleChampCustom = "NETWORK_LINK";
        public const string c_champSite1 = "NTWLNK_SITE1";
        public const string c_champSite2 = "NTWLNK_SITE2";
        public const string c_champEquipement1 = "NTWLNK_EQUIP1";
        public const string c_champEquipement2 = "NTWLNK_EQUIP2";
        public const string c_champPort1 = "NTWLNK_PORT1";
        public const string c_champPort2 = "NTWLNK_PORT2";
        public const string c_champDirection = "NTWLNK_DIRECTION";
        public const string c_champExtremiteSite1 = "NTWLNK_EXT1";
        public const string c_champExtremiteSite2 = "NTWLNK_EXT2";



        /// /////////////////////////////////////////////
        public CLienReseau(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CLienReseau(DataRow row)
            : base(row)
        {
        }


        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Network Link", typeof(CLienReseau), typeof(CTypeLienReseau));
        }

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole ( c_roleChampCustom); }
        }


        /// <summary>
        /// Le nom donné au lien réseau
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [TiagField("Label")]
        public string Libelle
        {
            get
            {
                if ((string)Row[c_champLibelle] == "")
                {
                    string libelleParDefaut = "";
                    if (this.Element1 != null && this.Element2 != null)
                    {
                        libelleParDefaut += Element1.Libelle;

                        if (this.Direction == EDirectionLienReseau.UnVersDeux)
                            libelleParDefaut += " -> ";
                        else if (this.Direction == EDirectionLienReseau.DeuxVersUn)
                            libelleParDefaut += " <- ";
                        else if (this.Direction == EDirectionLienReseau.Bidirectionnel)
                            libelleParDefaut += " <-> ";

                        libelleParDefaut += Element2.Libelle;
                    }

                    return libelleParDefaut;

                }
                else

                    return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }


        public void TiagSetLinkTypeKeys(object[] lstKeys)
        {
            CTypeLienReseau typeLien = new CTypeLienReseau(ContexteDonnee);
            if (typeLien.ReadIfExists(lstKeys))
                TypeLienReseau = typeLien;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le <see cref="CStock">Type du lien réseau</see>. Ce champ est obligatoire.
        /// Le type de lien réseau définit le comportement du lien, par exemple c'est à son niveau
        /// que se fait l'association avec des formulaires personnalisés à afficher au niveau du lien réseau.
        /// </summary>
        [Relation(CTypeLienReseau.c_nomTable, CTypeLienReseau.c_champId, CTypeLienReseau.c_champId, true, false)]
        [DynamicField("Link type")]
        [TiagRelation(typeof(CTypeLienReseau), "TiagSetLinkTypeKeys")]
        public CTypeLienReseau TypeLienReseau
        {
            get
            {
                return (CTypeLienReseau)GetParent(CTypeLienReseau.c_champId, typeof(CTypeLienReseau));
            }
            set
            {
                SetParent(CTypeLienReseau.c_champId, value);
            }
        }


        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[] { TypeLienReseau };
            }
        }

        //----------------------------------------------------
        public new CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeLienReseau == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeLienReseau_ChampCustom rel in TypeLienReseau.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeLienReseau_Formulaire rel1 in TypeLienReseau.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));

        }

        //----------------------------------------------------
        public new CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }


        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationLienReseau_ChampCustom(ContexteDonnee);
        }


        /// <summary>
        ///Liste des <see cref="CRelationLienReseau_ChampCustom">relations vers les Champs personnalisés</see>
        /// </summary>
        [DynamicChilds("Custom fields relations", typeof(CRelationLienReseau_ChampCustom))]
        [RelationFille(typeof(CRelationLienReseau_ChampCustom), "ElementAChamps")]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationLienReseau_ChampCustom.c_nomTable, c_champId);
            }
        }

        public override string DescriptionElement
        {
            get
            {

                return I.T("Network link @1|30088", Libelle);
            }
        }




        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }


        protected override void MyInitValeurDefaut()
        {


        }

        /// <summary>
        /// Obtient ou fixe l'élément d'extrémité 1 (peut être un <see cref="CSite">site</see> ou un <see cref="CEquipementLogique">équipement logique</see>)
        /// </summary>
        [DynamicField("Element 1")]
        public IElementALiensReseau Element1
        {
            get
            {
                if (Site1 != null)
                    return Site1;
                else
                    return Equipement1;
            }
            set
            {
                if (value is CSite)
                {
                    Site1 = (CSite)value;
                    Equipement1 = null;
                }
                else if (value is CEquipementLogique)
                {
                    Site1 = null;
                    Equipement1 = (CEquipementLogique)value;
                }
                else
                {
                    Site1 = null;
                    Equipement1 = null;
                }
            }

        }


        /// <summary>
        /// Obtient ou fixe l'élément d'extrémité 2 (peut être un <see cref="CSite">site</see> ou un <see cref="CEquipementLogique">équipement logique</see>)
        /// </summary>
        [DynamicField("Element 2")]
        public IElementALiensReseau Element2
        {
            get
            {
                if (Site2 != null)
                    return Site2;
                else
                    return Equipement2;
            }
            set
            {
                if (value is CSite)
                {
                    Site2 = (CSite)value;
                    Equipement2 = null;
                }
                else if (value is CEquipementLogique)
                {
                    Site2 = null;
                    Equipement2 = (CEquipementLogique)value;
                }
                else
                {
                    Site2 = null;
                    Equipement2 = null;
                }
            }

        }

        public void TiagSetSite1Keys(object[] lstKeys)
        {
            CSite site = new CSite(ContexteDonnee);
            if (site.ReadIfExists(lstKeys))
                Site1 = site;
        }


        /// <summary>
        /// Obtient ou fixe le <see cref="CSite">site</see> d'extrémité 1, lorsqu'il s'agit d'un site
        /// </summary>
        [Relation(
        CSite.c_nomTable,
       CSite.c_champId,
       c_champSite1,
        false,
        false,
        false)]
        [DynamicField("Site 1")]
        [TiagRelation(typeof(CSite), "TiagSetSite1Keys")]
        public CSite Site1
        {
            get
            {
                return (CSite)GetParent(c_champSite1, typeof(CSite));
            }
            set
            {
                SetParent(c_champSite1, value);
            }
        }

        public void TiagSetSite2Keys(object[] lstKeys)
        {
            CSite site = new CSite(ContexteDonnee);
            if (site.ReadIfExists(lstKeys))
                Site2 = site;
        }


        /// <summary>
        /// Obtient ou fixe le <see cref="CSite">site</see> d'extrémité 2, lorsqu'il s'agit d'un site
        /// </summary>
        [Relation(
         CSite.c_nomTable,
        CSite.c_champId,
        c_champSite2,
         false,
         false,
         false)]
        [DynamicField("Site 2")]
        [TiagRelation(typeof(CSite), "TiagSetSite2Keys")]
        public CSite Site2
        {
            get
            {
                return (CSite)GetParent(c_champSite2, typeof(CSite));
            }
            set
            {
                SetParent(c_champSite2, value);
            }
        }

        public void TiagSetEquipement1Keys(object[] lstKeys)
        {
            CEquipementLogique eqpt = new CEquipementLogique(ContexteDonnee);
            if (eqpt.ReadIfExists(lstKeys))
                Equipement1 = eqpt;
        }


        /// <summary>
        /// Obtient ou fixe l'<see cref="CEquipementLogique">Equipement logique</see> d'extrémité 1, lorsqu'il s'agit d'un équipement logique
        /// </summary>
        [Relation(
         CEquipementLogique.c_nomTable,
        CEquipementLogique.c_champId,
        c_champEquipement1,
         false,
         false,
         false)]
        [DynamicField("Logical Equipement 1")]
        [TiagRelation(typeof(CEquipementLogique), "TiagSetEquipement1Keys")]
        public CEquipementLogique Equipement1
        {
            get
            {
                return (CEquipementLogique)GetParent(c_champEquipement1, typeof(CEquipementLogique));
            }
            set
            {
                SetParent(c_champEquipement1, value);
            }
        }

        public void TiagSetEquipement2Keys(object[] lstKeys)
        {
            CEquipementLogique eqpt = new CEquipementLogique(ContexteDonnee);
            if (eqpt.ReadIfExists(lstKeys))
                Equipement2 = eqpt;
        }


        /// <summary>
        /// Obtient ou fixe l'<see cref="CEquipementLogique">Equipement logique</see> d'extrémité 2, lorsqu'il s'agit d'un équipement logique
        /// </summary>
        [Relation(
        CEquipementLogique.c_nomTable,
       CEquipementLogique.c_champId,
       c_champEquipement2,
        false,
        false,
        false)]
        [DynamicField("Logical Equipment 2")]
        [TiagRelation(typeof(CEquipementLogique), "TiagSetEquipement2Keys")]
        public CEquipementLogique Equipement2
        {
            get
            {
                return (CEquipementLogique)GetParent(c_champEquipement2, typeof(CEquipementLogique));
            }
            set
            {
                SetParent(c_champEquipement2, value);
            }
        }


        /// <summary>
        /// Objet complémentaire associé à l'élément d'extrémité 1, lorsqu'il existe.
        /// Cet objet peut être un <see cref="CPort">port</see> ou une <see cref="CExtremiteLienSurSite">extrémité de site</see> suivant que l'élément 1 est un site ou un équipement logique.
        /// </summary>
        [DynamicField("Complement 1")]
        public IComplementElementALiensReseau Complement1
        {
            get
            {
                if (Port1 != null)
                    return Port1;
                else if (ExtremiteSurSite1 != null)
                    return ExtremiteSurSite1;
                else
                    return null;
            }
            set
            {
                Port1 = value as CPort;
                ExtremiteSurSite1 = value as CExtremiteLienSurSite;
            }

        }


        /// <summary>
        /// Objet complémentaire associé à l'élément d'extrémité 2, lorsqu'il existe.
        /// Cet objet peut être un <see cref="CPort">port</see> ou une <see cref="CExtremiteLienSurSite">extrémité de site</see> suivant que l'élément 2 est un site ou un équipement logique.
        /// </summary>
        [DynamicField("Complement 2")]
        public IComplementElementALiensReseau Complement2
        {
            get
            {
                if (Port2 != null)
                    return Port2;
                else if (ExtremiteSurSite2 != null)
                    return ExtremiteSurSite2;
                else
                    return null;
            }
            set
            {
                Port2 = value as CPort;
                ExtremiteSurSite2 = value as CExtremiteLienSurSite;
            }

        }

        public void TiagSetPort1Keys(object[] lstKeys)
        {
            CPort port = new CPort(ContexteDonnee);
            if (port.ReadIfExists(lstKeys))
                Port1 = port;
        }


        /// <summary>
        /// Port associé à l'élément 1 d'extrémité de la liaison (lorsqu'il existe).
        /// Peut exister lorsque l'élément 1 d'extrémité de la liaison est un <see cref="CEquipementLogique">équipement logique</see>.
        /// </summary>
        [Relation(
        CPort.c_nomTable,
       CPort.c_champId,
       c_champPort1,
        false,
        false,
        false)]
        [DynamicField("Port 1")]
        [TiagRelation(typeof(CPort), "TiagSetPort1Keys")]
        public CPort Port1
        {
            get
            {
                return (CPort)GetParent(c_champPort1, typeof(CPort));
            }
            set
            {
                SetParent(c_champPort1, value);
            }
        }

        public void TiagSetPort2Keys(object[] lstKeys)
        {
            CPort port = new CPort(ContexteDonnee);
            if (port.ReadIfExists(lstKeys))
                Port2 = port;
        }


        /// <summary>
        /// Port associé à l'élément 2 d'extrémité de la liaison (lorsqu'il existe).
        /// Peut exister lorsque l'élément 2 d'extrémité de la liaison est un <see cref="CEquipementLogique">équipement logique</see>.
        /// </summary>
        [Relation(
      CPort.c_nomTable,
     CPort.c_champId,
     c_champPort2,
      false,
      false,
      false)]
        [DynamicField("Port 2")]
        [TiagRelation(typeof(CPort), "TiagSetPort2Keys")]
        public CPort Port2
        {
            get
            {
                return (CPort)GetParent(c_champPort2, typeof(CPort));
            }
            set
            {
                SetParent(c_champPort2, value);
            }
        }



        //-------------------------------------------------------------------
        public void TiagSetExt1Keys(object[] lstKeys)
        {
            CExtremiteLienSurSite ext = new CExtremiteLienSurSite(ContexteDonnee);
            if (ext.ReadIfExists(lstKeys))
                ExtremiteSurSite1 = ext;
        }


        /// <summary>
        /// Extrémité de site associée à l'élément 1 d'extrémité de la liaison (lorsqu'il existe).
        /// Peut exister lorsque l'élément 1 d'extrémité de la liaison est un <see cref="CSite">Site</see>.
        /// Dans ce cas, l'extrémité de site désigne un sous-ensemble dans ce site.
        /// </summary>
        [Relation(
            CExtremiteLienSurSite.c_nomTable,
            CExtremiteLienSurSite.c_champId,
            CLienReseau.c_champExtremiteSite1,
            false,
            false,
            false)]
        [DynamicField("Link End 1")]
        [TiagRelation(typeof(CExtremiteLienSurSite), "TiagSetExt1Keys")]
        public CExtremiteLienSurSite ExtremiteSurSite1
        {
            get
            {
                return (CExtremiteLienSurSite)GetParent(CLienReseau.c_champExtremiteSite1, typeof(CExtremiteLienSurSite));
            }
            set
            {
                SetParent(CLienReseau.c_champExtremiteSite1, value);
            }
        }


        //-------------------------------------------------------------------
        public void TiagSetExt2Keys(object[] lstKeys)
        {
            CExtremiteLienSurSite ext = new CExtremiteLienSurSite(ContexteDonnee);
            if (ext.ReadIfExists(lstKeys))
                ExtremiteSurSite2 = ext;
        }


        /// <summary>
        /// Extrémité de site associée à l'élément 2 d'extrémité de la liaison (lorsqu'il existe).
        /// Peut exister lorsque l'élément 2 d'extrémité de la liaison est un <see cref="CSite">Site</see>.
        /// Dans ce cas, l'extrémité de site désigne un sous-ensemble dans ce site.
        /// </summary>
        [Relation(
            CExtremiteLienSurSite.c_nomTable,
            CExtremiteLienSurSite.c_champId,
            CLienReseau.c_champExtremiteSite2,
            false,
            false,
            false)]
        [DynamicField("Link end 2")]
        [TiagRelation(typeof(CExtremiteLienSurSite), "TiagSetExt2Keys")]
        public CExtremiteLienSurSite ExtremiteSurSite2
        {
            get
            {
                return (CExtremiteLienSurSite)GetParent(CLienReseau.c_champExtremiteSite2, typeof(CExtremiteLienSurSite));
            }
            set
            {
                SetParent(CLienReseau.c_champExtremiteSite2, value);
            }
        }


        /// <summary>
        /// Donne la liste des <see cref="CSchemaReseau">schémas réseau</see> dans lesquels figure le lien réseau
        /// </summary>
        [RelationFille(typeof(CSchemaReseau), "LienReseau")]
        [DynamicChilds("Internal network diagrams", typeof(CSchemaReseau), Rubrique = "Internal")]
        public CListeObjetsDonnees Schemas
        {
            get
            {
                return GetDependancesListe(CSchemaReseau.c_nomTable, false, CSchemaReseau.c_champIdLienReseauAuquelJappartient);
            }
        }


        /// <summary>
        /// Retourne le premier des <see cref="CSchemaReseau">schémas réseau</see> dans lesquels figure le lien réseau.
        /// Il s'agit en fait du schéma du lien lui-même.
        /// </summary>
        [DynamicField("Newtwork diagram")]
        public CSchemaReseau SchemaReseau
        {
            get
            {
                CListeObjetsDonnees lst = Schemas;
                if (lst.Count > 0)
                    return lst[0] as CSchemaReseau;
                return null;
            }
        }


        /// <summary>
        /// Retourne le <see cref="CSchemaReseau">schéma</see> du lien réseau.
        /// S'il n'existe pas encore, il est créé.
        /// Cette fonction ne doit pas être exploitée en dehors d'un process.
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Create network diagram if it's not yet created. Don't use outside a process")]
        public void EnsureNetworkDiagram()
        {
            GetSchemaReseauCreateIfNull();
        }

        public CSchemaReseau GetSchemaReseauCreateIfNull()
        {
            CSchemaReseau schema = SchemaReseau;
            if (schema != null)
            {
                if (schema.Libelle == "")
                    schema.Libelle = Libelle;
                return schema;
            }
            schema = new CSchemaReseau(ContexteDonnee);
            schema.CreateNewInCurrentContexte();
            schema.LienReseau = this;
            schema.Libelle = Libelle;
            if (schema.GetSchema(true) == null)
            {
                schema.SetSchema(new C2iSchemaReseau(schema));
            }


            return schema;
        }



        //---------------------------------------------
        /// <summary>
        /// Donne la liste des <see cref="CElementDeSchemaReseau">éléments de schéma réseau</see> correspondant à ce lien réseau
        /// </summary>
        [RelationFille(typeof(CElementDeSchemaReseau), "LienReseau")]
        [DynamicChilds("Associated network elements", typeof(CElementDeSchemaReseau))]
        public CListeObjetsDonnees ElementsDeSchema
        {
            get
            {
                return GetDependancesListe(CElementDeSchemaReseau.c_nomTable, c_champId);
            }
        }

        public C2iSchemaReseau GetSchemaReseauADessiner(bool bCreationAutorisee)
        {


            C2iSchemaReseau schemaADessiner;

            if (SchemaReseau != null)
            {
                if (SchemaReseau.GetSchema(bCreationAutorisee) != null)
                {
                    schemaADessiner = SchemaReseau.GetSchema(bCreationAutorisee);

                }
                else
                {
                    schemaADessiner = new C2iSchemaReseau(SchemaReseau);

                }
            }
            else if (bCreationAutorisee)
            {

                CSchemaReseau schema = GetSchemaReseauCreateIfNull();
                schema.CreateNewInCurrentContexte();
                schema.LienReseau = this;
                schema.Libelle = this.Libelle;
                
                schemaADessiner = schema.GetSchema(bCreationAutorisee);
            }
            else
            {

                return null;

            }

            bool bFindObjet1 = false;
            bool bFindObjet2 = false;

            foreach (C2iObjetDeSchema objet in schemaADessiner.Childs)
            {
                if (objet.ElementDeSchema != null && objet.ElementDeSchema.ElementAssocie != null)
                {
                    if (objet.ElementDeSchema.ElementAssocie.Equals(Element1))
                    {
                        bFindObjet1 = true;

                    }

                    if (objet.ElementDeSchema.ElementAssocie.Equals(Element2))
                    {
                        bFindObjet2 = true;
                    }
                }
            }

            if (!bFindObjet1 && Element1 != null)
            {
                CElementDeSchemaReseau elt1 = new CElementDeSchemaReseau(ContexteDonnee);
                elt1.CreateNewInCurrentContexte();
                elt1.SchemaReseau = SchemaReseau;
                elt1.ElementAssocie = Element1;
                C2iObjetDeSchema objet1 = elt1.ObjetDeSchema;
                schemaADessiner.AddChild(objet1);
                objet1.Parent = schemaADessiner;
                objet1.Position = new Point(10, 10);
                elt1.X = objet1.Position.X;
                elt1.Y = objet1.Position.Y;
            }

            if (!bFindObjet2 && Element2 != null)
            {
                CElementDeSchemaReseau elt2 = new CElementDeSchemaReseau(ContexteDonnee);
                elt2.CreateNewInCurrentContexte();
                elt2.SchemaReseau = SchemaReseau;
                elt2.ElementAssocie = Element2;
                C2iObjetDeSchema objet2 = elt2.ObjetDeSchema;
                schemaADessiner.AddChild(objet2);
                objet2.Parent = schemaADessiner;
                objet2.Position = new Point(10, 400);
                elt2.X = objet2.Position.X;
                elt2.Y = objet2.Position.Y;
            }

            C2iLienDeSchemaReseauNoDelete lienGraphiqueEdite = new C2iLienDeSchemaReseauNoDelete();

            lienGraphiqueEdite.LienReseau = this;
            schemaADessiner.AddChild(lienGraphiqueEdite);
            lienGraphiqueEdite.Parent = schemaADessiner;
            schemaADessiner.FrontToBack(lienGraphiqueEdite);




            return schemaADessiner;


        }





        ////////////////////////////////////////////////
        /// <summary>
        /// Code donnant la direction du lien :
        /// <ul>
        /// <li>0 : de l'élément 1 vers l'élément 2</li>
        /// <li>1 : de l'élément 2 vers l'élément 1</li>
        /// <li>2 : bidirectionnel</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(CLienReseau.c_champDirection)]
        [DynamicField("Link direction code")]
        [TiagField("DirectionCode")]
        public int DirectionInt
        {
            get
            {
                return (int)Row[c_champDirection];
            }
            set
            {
                Row[c_champDirection] = value;
            }
        }

        ////////////////////////////////////////////////
        /// <summary>
        /// Objet donnant la <see cref="CDirectionLienReseau">direction</see> du lien
        /// </summary>
        [DynamicField("Link direction")]
        public CDirectionLienReseau Direction
        {
            get
            {
                return new CDirectionLienReseau((EDirectionLienReseau)DirectionInt);
            }
            set
            {
                if (value != null)
                    DirectionInt = value.CodeInt;

            }
        }


        /// <summary>
        /// Donne la liste des liens supportés par ce lien (liens dont le schéma contient ce lien) 
        /// </summary>
        [DynamicChilds(("Supported links"), typeof(CLienReseau))]
        public CListeObjetsDonnees LiensSupportes
        {
            get
            {
                if (ContexteDonnee.HasChanges())
                //Le contexte contient des modifs, on va donc chercher les données dans ce contexte !
                {
                    CListeObjetsDonnees lstElements = new CListeObjetsDonnees(ContexteDonnee, typeof(CElementDeSchemaReseau));
                    lstElements.Filtre = new CFiltreData(CLienReseau.c_champId + "=@1", Id);
                    StringBuilder blIds = new StringBuilder();
                    foreach (CElementDeSchemaReseau elt in lstElements)
                    {
                        if (elt.SchemaReseau != null && elt.SchemaReseau.LienReseau != null)
                        //C'est un supporté
                        {
                            blIds.Append(elt.SchemaReseau.LienReseau.Id);
                            blIds.Append(',');
                        }
                    }
                    CListeObjetsDonnees lstRetour = new CListeObjetsDonnees(ContexteDonnee, typeof(CLienReseau));
                    if (blIds.Length > 0)
                    {
                        blIds.Remove(blIds.Length - 1, 1);
                        lstRetour.FiltrePrincipal = new CFiltreData(CLienReseau.c_champId + " in (" + blIds.ToString() + ")");
                    }
                    else
                        lstRetour.FiltrePrincipal = new CFiltreDataImpossible();
                    return lstRetour;
                }
                else
                {
                    //Pas de modif dans le contexte, donc va chercher dans la base
                    CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CLienReseau));
                    liste.FiltrePrincipal = new CFiltreDataAvance(CLienReseau.c_nomTable, CSchemaReseau.c_nomTable + "." +
                        CElementDeSchemaReseau.c_nomTable + "." + CLienReseau.c_nomTable + "." + CLienReseau.c_champId + "=@1", Id);
                    return liste;
                }
            }
        }


        /// <summary>
        /// Donne la liste de tous les liens supportés par ce lien, quelque soit le niveau dans la hiérarchie.
        /// C'est à dire donne la liste des liens immédiatement supportés par ce lien (liens dont le schéma contient ce lien),
        /// puis pour chaque supporté direct, donne la liste des liens immmédiatement supportés par ce lien supporté direct
        /// et ainsi de suite jusqu'au plus profond de la hiérachie des liens supportés.
        /// </summary>
        [DynamicField("All supported links")]
        public CLienReseau[] TousLesLiensSupportes
        {
            get
            {
                Dictionary<CLienReseau, bool> supportes = new Dictionary<CLienReseau, Boolean>();
                FillDicSupportes(supportes);
                List<CLienReseau> lstRetour = new List<CLienReseau>();
                foreach (CLienReseau lien in supportes.Keys)
                    lstRetour.Add(lien);
                return lstRetour.ToArray();
            }
        }

        private void FillDicSupportes(Dictionary<CLienReseau, bool> dic)
        {
            foreach (CLienReseau lienSupporte in LiensSupportes)
            {
                dic[lienSupporte] = true;
                lienSupporte.FillDicSupportes(dic);
            }
        }


        /// <summary>
        /// Liens supports de ce lien (liens inclus dans le schéma de ce lien)
        /// </summary>
        [DynamicChilds(("Supporting links"), typeof(CLienReseau))]
        public CListeObjetsDonnees LiensSupportants
        {
            get
            {
                //PAs de filtre avancé, car pb des élements par encore créés
                StringBuilder bl = new StringBuilder();
                CFiltreData filtre = new CFiltreDataImpossible();
                if (SchemaReseau != null)
                {
                    foreach (CLienReseau lien in SchemaReseau.GetElementsLies<CLienReseau>())
                    {
                        bl.Append(lien.Id);
                        bl.Append(',');
                    }
                    if (bl.Length > 0)
                    {
                        bl.Remove(bl.Length - 1, 1);
                        filtre = new CFiltreData(CLienReseau.c_champId + " in (" + bl.ToString() + ")");
                    }
                }
                return new CListeObjetsDonnees(ContexteDonnee, typeof(CLienReseau), filtre);
            }
        }

        /// <summary>
        /// Retourne une liste de liens partant de l'élément demandé
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [DynamicMethod("Returns a list of supporting links (chain) from requested element", "Start element")]
        public IEnumerable<CLienReseau> GetSupportingSortedFrom(IElementDeSchemaReseau element)
        {
            CListeObjetsDonnees lstSupports = LiensSupportants;
            HashSet<int> setFaits = new HashSet<int>();
            List<CLienReseau> lstLiens = new List<CLienReseau>();
            FillLiensSupportFrom(element, lstLiens, setFaits, lstSupports.ToList<CLienReseau>());
            return lstLiens.AsReadOnly();

        }

        /// <summary>
        /// Retourne une liste de extremités de liens partant de l'élément demandé
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [DynamicMethod("Returns a list of supporting elements (chain) from requested element", "Start element")]
        public IEnumerable<IElementDeSchemaReseau> GetSupportingElementsSortedFrom(IElementDeSchemaReseau element)
        {
            CListeObjetsDonnees lstSupports = LiensSupportants;
            HashSet<int> setFaits = new HashSet<int>();
            List<IElementDeSchemaReseau> lstElements = new List<IElementDeSchemaReseau>();
            if (element != null)
            {
                List<CLienReseau> lstLiens = new List<CLienReseau>();
                FillLiensSupportFrom(element, lstLiens, setFaits, lstSupports.ToList<CLienReseau>());
                lstElements.Add(element);
                foreach (CLienReseau lien in lstLiens)
                {
                    if (lien.Element1.Equals(element))
                        lstElements.Add(lien.Element2);
                    else
                        lstElements.Add(lien.Element1);

                }
            }
            return lstElements;
        }

        /// <summary>
        /// Retourne une liste de sites de liens partant de l'élément demandé
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [DynamicMethod("Returns a list of supporting sites (chain) from requested element", "Start element")]
        public IEnumerable<CSite> GetSupportingSitesSortedFrom(CSite site)
        {
            return from e in GetSupportingElementsSortedFrom(site) where (e is CSite) select (CSite)e;
        }

        /// <summary>
        /// Retourne une liste des équipements de liens partant de l'élément demandé
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [DynamicMethod("Returns a list of supporting devices (chain) from requested element", "Start element")]
        public IEnumerable<CEquipementLogique> GetSupportingEquipmentSortedFrom(CEquipementLogique equipement)
        {
            return from e in GetSupportingElementsSortedFrom(equipement) where (e is CEquipementLogique) select (CEquipementLogique)e;
        }

        /// <summary>
        /// Retourne une liste des entites snmp de liens partant de l'élément demandé
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [DynamicMethod("Returns a list of supporting sites (chain) from requested element", "Start element")]
        public IEnumerable<CEntiteSnmp> GetSupportingSnmpEntitySortedFrom(CEntiteSnmp ett)
        {
            return from e in GetSupportingElementsSortedFrom(ett) where (e is CEntiteSnmp) select (CEntiteSnmp)e;
        }

       


        private void FillLiensSupportFrom ( IElementDeSchemaReseau element, List<CLienReseau> lstRetour, HashSet<int> setFaits, List<CLienReseau> lstSupports )
        {
            if ( element == null )
                return;
            List<CLienReseau> lst = new List<CLienReseau>();
            foreach ( CLienReseau lien in lstSupports )
            {
                if (!setFaits.Contains(lien.Id) &&  (lien.Element1 != null && lien.Element1.Equals(element) || lien.Element2 != null && lien.Element2.Equals(element) ))
                    lst.Add ( lien );
            }
            foreach ( CLienReseau lien in lst )
            {
                setFaits.Add ( lien.Id );
                lstRetour.Add(lien);
            }
            foreach ( CLienReseau lien in lst )
                FillLiensSupportFrom(lien.Element1.Id==element.Id?lien.Element2:lien.Element1, lstRetour, setFaits, lstSupports);
            
        }


        /// <summary>
        /// Donne la liste de tous les liens supports de ce lien, quelque soit le niveau dans la hiérarchie.
        /// C'est à dire donne la liste des liens immédiatement supports de ce lien (liens inclus dans le schéma de ce lien),
        /// puis pour chaque support direct, donne la liste des liens immmédiatement supports de ce lien support direct
        /// et ainsi de suite jusqu'aux supports de plus haut niveau.
        /// </summary>
        [DynamicField("All supporting links")]
        public CLienReseau[] TousLesLiensSupportants
        {
            get
            {
                Dictionary<CLienReseau, bool> supportants = new Dictionary<CLienReseau, Boolean>();
                FillDicSupportants(supportants);
                List<CLienReseau> lstRetour = new List<CLienReseau>();
                foreach (CLienReseau lien in supportants.Keys)
                    lstRetour.Add(lien);
                return lstRetour.ToArray();
            }
        }

        private void FillDicSupportants(Dictionary<CLienReseau, bool> dic)
        {
            foreach (CLienReseau lienSupportant in LiensSupportants)
            {
                dic[lienSupportant] = true;
                lienSupportant.FillDicSupportes(dic);
            }
        }



        #region IElementDeSchemaReseau Membres

        public C2iSymbole SymboleADessiner
        {
            get { return null; }
        }



        public C2iObjetDeSchema GetObjetDeSchema(CElementDeSchemaReseau element)
        {
            C2iLienDeSchemaReseau lien = new C2iLienDeSchemaReseau();
            lien.ElementDeSchema = element;
            return lien;
        }

        #endregion


        //---------------------------------------------
        /// <summary>
        /// Côntrôle de non récursivité pour les liens supportants et supportés
        /// </summary>

        public bool PeutEtreSupporte(CLienReseau lienSupportant)
        {
            if (lienSupportant == this)
                return false;
            CSchemaReseau schemaLienSupportant = lienSupportant.SchemaReseau;
            if (schemaLienSupportant != null)
            {
                foreach (CElementDeSchemaReseau element in schemaLienSupportant.ElementsDeSchema)
                {
                    if (element.ElementAssocie.GetType() == typeof(CLienReseau))
                    {
                        CLienReseau lienReseau = (CLienReseau)element.ElementAssocie;

                        if (lienReseau == this)
                            return false;
                        if (!PeutEtreSupporte(lienReseau))
                            return false;

                    }
                }
            }
            return true;


        }


        //---------------------------------------------
        /// <summary>
        /// Vérifie si le type d'un lien appartient aux types supportants possibles pour ce lien
        /// </summary>
        public bool TypeSupportantPossible(CLienReseau lienSupportant)
        {
            bool bTrouve = false;
            if (TypeLienReseau != null && lienSupportant.TypeLienReseau != null)
            {
                foreach (CTypeLienReseauSupport typeLienSupport in this.TypeLienReseau.TypesPouvantSupporterCeType)
                {
                    if (typeLienSupport.TypeSupportant == lienSupportant.TypeLienReseau)
                    {
                        bTrouve = true;
                        break;
                    }
                }
            }
            return bTrouve;
        }

        

        /// <summary>
        /// Retourne l'extremité opposée à l'extremité demandée.
        /// </summary>
        /// <param name="elt">Si cet élément correspond à l'élément1, retourne l'élement2,
        /// si il correspond à l'élement 2, retourne l'élément 1</param>
        /// <returns></returns>
        public IElementALiensReseau GetAutreExtremite(IElementALiensReseau elt)
        {
            if (elt == null)
                return null;
            if (elt.Equals(Element1))
                return Element2;
            if (elt.Equals(Element2))
                return Element1;
            return null;
        }

        /*//Vérifie que le lien ne supporte pas un lien qui le supporte
        public CResultAErreur VerifieDependanceCycliqueSupportés()
        {
            return VerifieDependanceCycliqueSupportés(this);
        }

        protected CResultAErreur VerifieDependanceCycliqueSupportés ( CLienReseau lienSupportant )
        {
            CResultAErreur result = CResultAErreur.True;
            CListeObjetDonneeGenerique<CElementDeSchemaReseau> listeSupportes = new CListeObjetDonneeGenerique<CElementDeSchemaReseau>(ContexteDonnee);
            listeSupportes.Filtre = new CFiltreData(
                CLienReseau.c_champId + "=@1", Id);
            foreach (CElementDeSchemaReseau elt in listeSupportes)
            {
                if (elt.LienReseau != null && elt.SchemaReseau != null && elt.SchemaReseau.LienReseau != null)
                {
                    if (elt.SchemaReseau.LienReseau.Equals(lienSupportant))
                    {
                        result.EmpileErreur(I.T("Link @1 is supported by @2|20042",
                            elt.SchemaReseau.LienReseau.Libelle,
                            elt.LienReseau.Libelle));
                        return result;
                    }
                    result = elt.SchemaReseau.LienReseau.VerifieDependanceCycliqueSupportés(lienSupportant);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Link @1 is supported by @2|20042",
                            elt.SchemaReseau.LienReseau.Libelle,
                            elt.LienReseau.Libelle));
                        return result;
                    }
                }
            }
            return result;
        }*/

        //---------------------------------------------
        /// <summary>
        /// <see cref="CEntiteSnmp">Entité SNMP</see> associée au lien lorsqu'elle existe
        /// </summary>
        [RelationFille(typeof(CEntiteSnmp), "LienReseauSupervise")]
        [DynamicChilds("Snmp entities", typeof(CEntiteSnmp))]
        public CListeObjetsDonnees EntitesSnmp
        {
            get
            {
                return GetDependancesListe(CEntiteSnmp.c_nomTable, c_champId);
            }
        }
    }

}
 
