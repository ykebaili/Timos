using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sc2i.data;
using sc2i.common.memorydb;
using timos.acteurs;
using timos.data;
using sc2i.web;
using System.Data;
using System.Text;
using TID = TimosInventory.data;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.expression;


/// <summary>
/// Description résumée de CInventoryConvertor
/// </summary>
public class CInventoryConvertor
{
	public CInventoryConvertor()
	{
		
	}

    
    //------------------------------------------------------------------------
    public static void AddStaticDatas ( CContexteDonnee ctx, CMemoryDb db )
    {
        db.EnforceConstraints = false;
        DateTime dt = DateTime.Now;
        AddFormatsNumerotation(ctx, db);
        AddUnites(ctx, db);
        AddSystemesCoordonnees(ctx, db);
        AddConstructeursToDb(ctx, db);
        AddTypesEquipementsToDb(ctx,db);
        AddTypesSitesToDb(ctx, db);
        AddChampsCustom(ctx, db);
        TimeSpan sp = DateTime.Now - dt;
        db.EnforceConstraints = true;
    }

    //------------------------------------------------------------------------
    private static void AddFormatsNumerotation(CContexteDonnee ctx, CMemoryDb db)
    {
        CListeObjetDonneeGenerique<CFormatNumerotation> lst = new CListeObjetDonneeGenerique<CFormatNumerotation>(ctx);
        foreach (CFormatNumerotation formatTimos in lst)
        {
            TID.CFormatNumerotation format = new TID.CFormatNumerotation(db);
            format.CreateNew(formatTimos.Id);
            format.Libelle = formatTimos.Libelle;
            format.LongueurReference = formatTimos.LongueurReference;
            format.Romain = formatTimos.Romain;
            format.Sequence = formatTimos.Sequence;
        }
    }

    //------------------------------------------------------------------------
    private static void AddChampsCustom(CContexteDonnee ctx, CMemoryDb db)
    {
        CListeObjetDonneeGenerique<CChampCustom> lst = new CListeObjetDonneeGenerique<CChampCustom>(ctx);
        lst.Filtre = CChampCustom.GetFiltreChampsForRole(CReleveEquipement.c_roleChampCustom);
        lst.ReadDependances("ListeValeurs");
        foreach (CChampCustom champTimos in lst)
        {
            if (champTimos.TypeDonneeChamp.TypeDonnee != TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
            {
                AssureChampInMemoryDb(champTimos, db);
            }
        }
    }

    //---------------------------------------------------------------------------------------------
    private static TID.CChampCustom AssureChampInMemoryDb ( CChampCustom champTimos, CMemoryDb db )
    {
        TID.CChampCustom champ = new TimosInventory.data.CChampCustom(db);
        if (!champ.ReadIfExistsIdTimos(champTimos.Id))
        {
            champ.CreateNew(champTimos.Id);
            champ.Nom = champTimos.Nom;
            switch (champTimos.TypeDonneeChamp.TypeDonnee)
            {
                case TypeDonnee.tBool:
                    champ.TypeDonnee = ETypeChampBasique.Bool;
                    break;
                case TypeDonnee.tDate:
                    champ.TypeDonnee = ETypeChampBasique.Date;
                    break;
                case TypeDonnee.tDouble:
                    champ.TypeDonnee = ETypeChampBasique.Decimal;
                    break;
                case TypeDonnee.tEntier:
                    champ.TypeDonnee = ETypeChampBasique.Int;
                    break;
                case TypeDonnee.tString:
                    champ.TypeDonnee = ETypeChampBasique.String;
                    break;
            }
            champ.FormuleValeurParDefaut = champTimos.FormuleValeurParDefaut;
            champ.Precision = champTimos.Precision;
            champ.FormuleValidation = champTimos.FormuleValidation;
            champ.TexteErreurFormat = champTimos.TexteErreurFormat;
            champ.CodeRole = champTimos.CodeRole;
            champ.CodesRolesSecondaires = champTimos.CodesRolesSecondaires;
            foreach (CValeurChampCustom valeurTimos in champTimos.ListeValeurs)
            {
                TID.CValeurChampCustom valeur = new TimosInventory.data.CValeurChampCustom(db);
                valeur.CreateNew();
                valeur.Display = valeurTimos.Display;
                valeur.Value = valeurTimos.ValeurMasquee;
                valeur.ChampCustom = champ;
            }
        }
        return champ;
    }

    //------------------------------------------------------------------------
    private static void AddUnites(CContexteDonnee ctx, CMemoryDb db)
    {
        CListeObjetDonneeGenerique<CUniteCoordonnee> lst = new CListeObjetDonneeGenerique<CUniteCoordonnee>(ctx);
        foreach (CUniteCoordonnee uniteTimos in lst)
        {
            TID.CUniteCoordonnee unite = new TID.CUniteCoordonnee(db);
            unite.CreateNew(uniteTimos.Id);
            unite.Abreviation = uniteTimos.Abreviation;
        }
    }

    //------------------------------------------------------------------------
    private static void AddSystemesCoordonnees(CContexteDonnee ctx, CMemoryDb db)
    {
        CListeObjetDonneeGenerique<CSystemeCoordonnees> lst = new CListeObjetDonneeGenerique<CSystemeCoordonnees>(ctx);
        lst.ReadDependances("RelationFormatsNumerotation");
        foreach (CSystemeCoordonnees systemeTimos in lst)
        {
            TID.CSystemeCoordonnees systeme = new TID.CSystemeCoordonnees(db);
            systeme.CreateNew(systemeTimos.Id);
            systeme.Libelle = systemeTimos.Libelle;
            foreach (CRelationSystemeCoordonnees_FormatNumerotation relTimos in systemeTimos.RelationFormatsNumerotation)
            {
                TID.CRelationSystemeCoordonnees_FormatNumerotation rel = new TID.CRelationSystemeCoordonnees_FormatNumerotation(db);
                TID.CFormatNumerotation format = new TID.CFormatNumerotation(db);
                int? nId = (int?)relTimos.Row[CFormatNumerotation.c_champId, true];
                if (nId == null || format.ReadIfExistsIdTimos(nId.Value))
                {
                    TID.CUniteCoordonnee unite = new TID.CUniteCoordonnee(db);
                    nId = (int?)relTimos.Row[CUniteCoordonnee.c_champId, true];
                    if (nId == null || unite.ReadIfExistsIdTimos(nId.Value))
                    {
                        rel.CreateNew(relTimos.Id);
                        rel.FormatNumerotation = format;
                        rel.Libelle = relTimos.Libelle;
                        rel.Position = relTimos.Position;
                        rel.Prefixes = relTimos.Prefixes;
                        rel.SystemeDeCoordonnees = systeme;
                        rel.Unite = unite;
                    }
                }
            }
        }
    }



    //------------------------------------------------------------------------
    private static void AddConstructeursToDb(CContexteDonnee ctx, CMemoryDb db)
    {
        CListeObjetDonneeGenerique<CDonneesActeurConstructeur> lst = new CListeObjetDonneeGenerique<CDonneesActeurConstructeur>(ctx);
        lst.ReadDependances("Acteur");
        foreach ( CDonneesActeurConstructeur timosConst in lst )
        {
            TID.CConstructeur constructeur = new TID.CConstructeur(db );
            constructeur.CreateNew(timosConst.Id);
            constructeur.Libelle = timosConst.Acteur.Nom;
        }
    }

    //------------------------------------------------------------------------
    private static void AddTypesEquipementsToDb(CContexteDonnee ctx, CMemoryDb db)
    {
        CListeObjetDonneeGenerique<CTypeEquipement> lst = new CListeObjetDonneeGenerique<CTypeEquipement>(ctx);
        lst.ReadDependances("RelationsConstructeurs");
        lst.ReadDependances("ParametragesSystemesCoordonnees");
        lst.ReadDependances("RelationsTypesParents");

        TID.CIndexIdTimos<TID.CConstructeur> dicConstructeurs = TID.CIndexIdTimos<TID.CConstructeur>.GetIdTimosIndex(db);
        TID.CIndexIdTimos<TID.CSystemeCoordonnees> dicSC = TID.CIndexIdTimos<TID.CSystemeCoordonnees>.GetIdTimosIndex(db);
        TID.CIndexIdTimos<TID.CRelationSystemeCoordonnees_FormatNumerotation> dicRFN = TID.CIndexIdTimos<TID.CRelationSystemeCoordonnees_FormatNumerotation>.GetIdTimosIndex(db);

        foreach (CTypeEquipement tpTimos in lst)
        {
            TID.CTypeEquipement tp = new TID.CTypeEquipement(db);
            tp.CreateNew(tpTimos.Id);
            tp.Libelle = tpTimos.Libelle;
            tp.NbUnitesOccupees = tpTimos.NbUnitesOccupees;
            tp.Row[TID.CTypeEquipement.c_champUniteOccupation] = tpTimos.Row[CTypeEquipement.c_champUniteOccupation];
            tp.OptionsControleCoordonneesPropreInt = tpTimos.OptionsControleCoordonneesPropreInt;
            foreach (CRelationTypeEquipement_Constructeurs relConsTimos in tpTimos.RelationsConstructeurs)
            {
                TID.CTypeEquipementConstructeur tpCons = new TID.CTypeEquipementConstructeur(db);
                
                int? nId = (int?)relConsTimos.Row[CDonneesActeurConstructeur.c_champId, true];
                TID.CConstructeur cons = dicConstructeurs.GetSafe(nId);

                if ( cons != null )
                {
                    tpCons.CreateNew(relConsTimos.Id);
                    tpCons.IdTimos = relConsTimos.Id;
                    tpCons.TypeEquipement = tp;
                    tpCons.Constructeur = cons;
                    tpCons.Reference = relConsTimos.Reference;
                }
            }


            //Coordonnées
            CParametrageSystemeCoordonnees paramTimos = tpTimos.ParametrageCoordonneesPropre;
            TID.CParametrageSystemeCoordonnees parametrage = ImporteParametrageSC(
                paramTimos,
                db,
                dicSC, 
                dicRFN);
            if ( parametrage != null )
                parametrage.TypeEquipement = tp;

            foreach (CRelationTypeEquipement_Heritage relTimos in tpTimos.RelationsTypesParents)
            {
                TID.CRelationTypeEquipement_Heritage rel = new TimosInventory.data.CRelationTypeEquipement_Heritage(db);
                rel.CreateNew(relTimos.Id);
                rel.Row[TID.CRelationTypeEquipement_Heritage.c_champIdTypeFils] = relTimos.Row[CRelationTypeEquipement_Heritage.c_champIdTypeFils];
                rel.Row[TID.CRelationTypeEquipement_Heritage.c_champIdTypeParent] = relTimos.Row[CRelationTypeEquipement_Heritage.c_champIdTypeParent];
            }
        }
    }

    //-----------------------------------------------------------------
    private static TID.CParametrageSystemeCoordonnees ImporteParametrageSC(
        CParametrageSystemeCoordonnees paramTimos,
        CMemoryDb db,
        TID.CIndexIdTimos<TID.CSystemeCoordonnees> dicSC,
        TID.CIndexIdTimos<TID.CRelationSystemeCoordonnees_FormatNumerotation> dicRFN)
    {
        if (paramTimos == null)
            return null;
        TID.CParametrageSystemeCoordonnees parametrage = null;
        TID.CSystemeCoordonnees sc = null;
        if (dicSC != null)
            sc = dicSC.GetSafe((int?)paramTimos.Row[CSystemeCoordonnees.c_champId, true]);
        parametrage = new TimosInventory.data.CParametrageSystemeCoordonnees(db);
        parametrage.CreateNew();
        if (sc != null)
            parametrage.SystemeCoordonnees = sc;
        else
            parametrage.Row[TID.CSystemeCoordonnees.c_champId] = paramTimos.Row[TID.CSystemeCoordonnees.c_champId];

        foreach (CParametrageNiveau paramNTimos in paramTimos.ParametragesNiveauxOrdonnees)
        {
            TID.CRelationSystemeCoordonnees_FormatNumerotation relFN = null;
            if (dicRFN != null)
                relFN = dicRFN.GetSafe((int?)paramNTimos.Row[CRelationSystemeCoordonnees_FormatNumerotation.c_champId, true]);
            TID.CParametrageNiveau paramN = new TimosInventory.data.CParametrageNiveau(db);
            paramN.CreateNew();
            paramN.ParametrageSystemeCoordonnees = parametrage;
            paramN.PremierIndice = paramNTimos.PremierIndice;
            paramN.Taille = paramNTimos.Taille;
            if (relFN != null)
                paramN.RelationSysCoor_FormatNum = relFN;
            else
                paramN.Row[TID.CRelationSystemeCoordonnees_FormatNumerotation.c_champId] = paramNTimos.Row[CRelationSystemeCoordonnees_FormatNumerotation.c_champId];
        }
        return parametrage;
    }
    

    //------------------------------------------------------------------------
    private static void AddTypesSitesToDb(CContexteDonnee ctx, CMemoryDb db)
    {
        CListeObjetDonneeGenerique<CTypeSite> lst = new CListeObjetDonneeGenerique<CTypeSite>(ctx);

        foreach (CTypeSite tpTimos in lst)
        {
            TID.CTypeSite tp = new TID.CTypeSite(db);
            tp.CreateNew(tpTimos.Id);
            tp.Libelle = tpTimos.Libelle;
            tp.Id = tpTimos.Id.ToString();
        }
    }

    
    //------------------------------------------------------------------------
    public static DataSet GetListeSitesPourReferences(C2iSessionWeb session)
    {
        using (CContexteDonnee ctx = new CContexteDonnee(session.Session.IdSession, true, false))
        {
            CMemoryDb db = new CMemoryDb();
            AddTypesSitesToDb(ctx, db);
            TID.CIndexIdTimos<TID.CTypeSite> dicTypesSites = TID.CIndexIdTimos<TID.CTypeSite>.GetIdTimosIndex(db);

            CListeObjetDonneeGenerique<CSite> lstSites = new CListeObjetDonneeGenerique<CSite>(ctx);
            lstSites.AssureLectureFaite();
            lstSites.ReadDependances("SitesFils");
            lstSites.ReadDependances("TypeSite");
            lstSites.Filtre = new CFiltreData(CSite.c_champIdParent + " is null");
            foreach (CSite site in lstSites)
                AddSitePourReference(site, null, db, dicTypesSites);
            return db;
        }
    }

    //------------------------------------------------------------------------
    private static void AddSitePourReference(CSite siteTimos,
        TID.CSite siteParent,
        CMemoryDb db,
        Dictionary<int, TID.CTypeSite> dicTypes)
    {
        TID.CSite site = new TID.CSite(db);
        TID.CTypeSite typeSite = null;
        if (siteTimos.TypeSite.Id != null && dicTypes.TryGetValue(siteTimos.TypeSite.Id, out typeSite))
        {
            site.CreateNew(siteTimos.Id);
            site.TypeSite = typeSite;
            site.Libelle = siteTimos.Libelle;
            site.SiteParent = siteParent;
            foreach (CSite siteFils in siteTimos.SitesFils)
            {
                AddSitePourReference(siteFils, site, db, dicTypes);
            }
        }
    }

    //------------------------------------------------------------------------
    public static DataSet GetSites(
        C2iSessionWeb sessionWeb,
        int[] nIdSites)
    {
        using (CContexteDonnee ctx = new CContexteDonnee(sessionWeb.Session.IdSession, true, false))
        {
            CMemoryDb db = new CMemoryDb();
            db.EnforceConstraints = false;
            if (nIdSites != null && nIdSites.Length > 0)
            {
                StringBuilder bl = new StringBuilder();
                foreach (int nIdSite in nIdSites)
                {
                    bl.Append(nIdSite);
                    bl.Append(';');
                }
                bl.Remove(bl.Length - 1, 1);
                CFiltreDataAvance filtre = new CFiltreDataAvance(CSite.c_nomTable,
                    CSite.c_champId + " in {" + bl.ToString() + "}");
                filtre.IntegrerFilsHierarchiques = true;
                CListeObjetDonneeGenerique<CSite> lstSites = new CListeObjetDonneeGenerique<CSite>(ctx);
                lstSites.Filtre = filtre;
                lstSites.AssureLectureFaite();
                lstSites.ReadDependances("SitesFils");
                lstSites.Filtre = new CFiltreData(CSite.c_champIdParent + " is null");
                lstSites.InterditLectureInDB = true;


                foreach (CSite site in lstSites)
                {
                    AddDetailSiteToDb(site, null, db);
                }
            }
            return db;
        }
    }

    private static void AddDetailSiteToDb(CSite siteTimos,
        TID.CSite siteParent,
        CMemoryDb db)
    {
        TID.CSite site = new TimosInventory.data.CSite(db);
        site.CreateNew(siteTimos.Id);
        site.Libelle = siteTimos.Libelle;
        site.Row[TID.CTypeSite.c_champId] = siteTimos.Row[CTypeSite.c_champId.ToString()];
        site.SiteParent = siteParent;
        site.CodeOptionsControleCoordonnees = siteTimos.OptionsControleCoordonneesPropreInt;
        CParametrageSystemeCoordonnees paramTimos = siteTimos.ParametrageCoordonneesApplique;
        TID.CParametrageSystemeCoordonnees parametrage = ImporteParametrageSC(
            paramTimos,
            db,
            null, null);
        if (parametrage != null)
            parametrage.Site = site;

        foreach (CSite siteFils in siteTimos.SitesFils)
        {
            AddDetailSiteToDb(siteFils, site, db);
        }
    }
    

    public static DataSet GetEquipments(C2iSessionWeb sessionWeb,
        int nIdSiteContenant)
    {
        using (CContexteDonnee ctx = new CContexteDonnee(sessionWeb.Session.IdSession, true, false))
        {
            CMemoryDb db = new CMemoryDb();
            db.EnforceConstraints = false;

            //Identifie les champs custom interessants
            CListeObjetDonneeGenerique<CChampCustom> lstChamps = new CListeObjetDonneeGenerique<CChampCustom>(ctx);
            lstChamps.Filtre = CChampCustom.GetFiltreChampsForRole(CReleveEquipement.c_roleChampCustom);
            StringBuilder blChampsCustom = new StringBuilder();
            foreach (CChampCustom champ in lstChamps)
            {
                blChampsCustom.Append(champ.Id);
                blChampsCustom.Append(",");
                AssureChampInMemoryDb(champ, db);
            }
            if (blChampsCustom.Length > 0)
                blChampsCustom.Remove(blChampsCustom.Length - 1, 1);



            //Ajout des équipements
            CListeObjetDonneeGenerique<CEquipement> equipements = new CListeObjetDonneeGenerique<CEquipement>(ctx);
            equipements.Filtre = new CFiltreData ( CSite.c_champId+"=@1", nIdSiteContenant );
            equipements.AssureLectureFaite();
            equipements.ReadDependances("EquipementsContenus.ParametragesSystemesCoordonnees", "RelationsChampsCustom");
            equipements.Filtre = new CFiltreData ( CEquipement.c_champIdEquipementContenant+" is null");
            equipements.InterditLectureInDB = true;
            foreach (CEquipement eqt in equipements)
            {
                AddDetailEquipementToDb(eqt, null, blChampsCustom.ToString(), db);
            }
            return db;
        }
    }

    //-------------------------------------------------------------
    private static void AddDetailEquipementToDb(
        CEquipement eqTimos,
        TID.CEquipement equipementParent,
        string strIdChampsCustom,
        CMemoryDb db
         )
    {
        DateTime dt = DateTime.Now;
        TID.CEquipement eqpt = new TimosInventory.data.CEquipement(db);
        eqpt.CreateNew(eqTimos.Id);
        eqpt.IdTimos = eqTimos.Id;
        eqpt.Row[TID.CTypeEquipement.c_champId] = eqTimos.Row[CTypeEquipement.c_champId].ToString();
        if (eqTimos.Row[CRelationTypeEquipement_Constructeurs.c_champId] != DBNull.Value)
            eqpt.Row[TID.CTypeEquipementConstructeur.c_champId] = eqTimos.Row[CRelationTypeEquipement_Constructeurs.c_champId].ToString();
        eqpt.Row[TID.CSite.c_champId] = eqTimos.Row[CSite.c_champId];
        eqpt.NumeroSerie = eqTimos.NumSerie;
        eqpt.EquipementParent = equipementParent;
        eqpt.Coordonnee = eqTimos.Coordonnee;
        eqpt.CodeOptionsControleCoordonnees = eqTimos.OptionsControleCoordonneesPropreInt;
        eqpt.NbUnitesOccupees = eqTimos.NbUnitesOccupees;
        eqpt.Row[CEquipement.c_champUniteOccupation] = eqTimos.Row[CEquipement.c_champUniteOccupation];
        if (strIdChampsCustom.Length > 0)
        {
            CListeObjetsDonnees relChamps = eqTimos.RelationsChampsCustom;
            relChamps.Filtre = new CFiltreData(CChampCustom.c_champId + " in (" + strIdChampsCustom + ")");
            foreach (CRelationElementAChamp_ChampCustom relChamp in relChamps)
                eqpt.SetValeurChamp(relChamp.Row[CChampCustom.c_champId].ToString(),
                    relChamp.Valeur);
        }
        

        TimeSpan sp = DateTime.Now - dt;
        System.Console.WriteLine(sp.TotalMilliseconds);
        CParametrageSystemeCoordonnees paramTimos = eqTimos.ParametrageCoordonneesPropre;
        if (paramTimos != null)
        {
            TID.CParametrageSystemeCoordonnees param = ImporteParametrageSC(paramTimos,
                db,
                null,
                null);
            if (param != null)
                param.Equipement = eqpt;
        }
        sp = DateTime.Now - dt;
        System.Console.WriteLine(sp.TotalMilliseconds);

        foreach (CEquipement eqptFils in eqTimos.EquipementsContenus)
            AddDetailEquipementToDb(eqptFils, eqpt, strIdChampsCustom,db );
    }

    //-------------------------------------------------------------
    public static CResultAErreur IntegreReleves(C2iSessionInventaire session,
        CMemoryDb db)
    {
        CResultAErreur result = CResultAErreur.True;
        try
        {
            DateTime dt = DateTime.Now;

            CListeEntitesDeMemoryDb<TID.releve.CReleveSite> lstReleves = new CListeEntitesDeMemoryDb<TID.releve.CReleveSite>(db);
            using (CContexteDonnee ctx = new CContexteDonnee(session.Session.IdSession, true, false))
            {
                foreach (TID.releve.CReleveSite releve in lstReleves)
                {
                    result = IntegreReleve(releve, ctx);
                    if (!result)
                        return result;
                }
                TimeSpan sp = DateTime.Now - dt;
                Console.WriteLine(sp.TotalMilliseconds);

                dt = DateTime.Now;
                result = ctx.SaveAll(false);
                sp = DateTime.Now - dt;
                Console.WriteLine(sp.TotalMilliseconds);
            }
        }
        catch (Exception e)
        {
            result.EmpileErreur(new CErreurException(e));
        }
        return result;
    }

    //-------------------------------------------------------------
    private static T GetObjetTimos<T>(object id, CContexteDonnee ctx )
        where T : CObjetDonneeAIdNumerique
    {
        int nId = -1;
        if ( id == DBNull.Value || id == null)
            return null;
        if ( id is string )
        {
            try{
                nId = int.Parse((string)id);
            }
            catch{
                return null;
            }
        }
        if ( id is int )
            nId = (int)id;
        if ( nId >= 0 )
        {
            T obj = (T)Activator.CreateInstance ( typeof(T), new object[]{ctx} );
            if ( obj.ReadIfExists ( nId ) )
                return obj;
        }
        return null;
    }

    //-------------------------------------------------------------
    private static CResultAErreur IntegreReleve(TID.releve.CReleveSite releve,
        CContexteDonnee ctx)
    {
        CResultAErreur result = CResultAErreur.True;
        CReleveSite releveTimos = new CReleveSite(ctx);
        releveTimos.CreateNewInCurrentContexte();
        CSite site = GetObjetTimos<CSite>(releve.Row[TID.CSite.c_champId], ctx);
        if (site == null)
        {
            result.EmpileErreur("Site doesn't exists");
            return result;
        }
        try
        {
            //Précharge les données
            CListeObjetsDonnees lst = new CListeObjetsDonnees(ctx, typeof(CTypeEquipement));
            lst.AssureLectureFaite();
            lst = new CListeObjetsDonnees(ctx, typeof(CRelationTypeEquipement_Constructeurs));
            lst.AssureLectureFaite();
            lst = site.Equipements;
            releveTimos.Site = site;
            releveTimos.DateReleve = releve.DateReleve;
            CListeEntitesDeMemoryDb<TID.releve.CReleveEquipement> lstEqpts = releve.RelevesEquipement;
            lstEqpts.Filtre = new CFiltreMemoryDb(TID.releve.CReleveEquipement.c_champIdContenant + " is null");
            foreach (TID.releve.CReleveEquipement relEq in lstEqpts)
            {
                result = IntegreReleveEquipement(relEq, null, releveTimos);
                if (!result)
                    return result;
            }
        }
        catch (Exception e)
        {
            result.EmpileErreur(new CErreurException(e));
        }
        return result;
    }

    //-------------------------------------------------------------
    private static CResultAErreur IntegreReleveEquipement(
        TID.releve.CReleveEquipement releveEq,
        CReleveEquipement relEqParentTimos,
        CReleveSite releveTimos)
    {
        CResultAErreur result = CResultAErreur.True;
        CReleveEquipement relEqTimos = new CReleveEquipement(releveTimos.ContexteDonnee);
        relEqTimos.CreateNewInCurrentContexte();
        relEqTimos.ReleveSite = releveTimos;
        //trouve l'équipement
        relEqTimos.Equipement = GetObjetTimos<CEquipement>(releveEq.Row[TID.CEquipement.c_champId], releveTimos.ContexteDonnee);
        relEqTimos.TypeEquipement = GetObjetTimos<CTypeEquipement>(releveEq.Row[TID.CTypeEquipement.c_champId], releveTimos.ContexteDonnee);
        relEqTimos.ReferenceConstructeur = GetObjetTimos<CRelationTypeEquipement_Constructeurs>(releveEq.Row[TID.CTypeEquipementConstructeur.c_champId], releveTimos.ContexteDonnee);
        relEqTimos.NumSerie = releveEq.NumeroSerie;
        relEqTimos.Coordonnee = releveEq.Coordonnee;
        relEqTimos.Presence = releveEq.IsPresent;
        relEqTimos.Commentaire = releveEq.Commentaire;
        relEqTimos.ReleveEquipementParent = relEqParentTimos;
        foreach (TID.releve.CRelationReleveEquipementChampCustom rel in releveEq.RelationsChampsCustom)
        {
            if (rel.ChampCustom != null && rel.ChampCustom.IdTimos != null)
                relEqTimos.SetValeurChamp(rel.ChampCustom.IdTimos.Value, rel.Valeur);
        }
        foreach (TID.releve.CReleveEquipement relContenu in releveEq.RelevesContenus)
        {
            result = IntegreReleveEquipement(relContenu, relEqTimos, releveTimos);
            if (!result)
                return result;
        }
        return result;
    }


        
}
