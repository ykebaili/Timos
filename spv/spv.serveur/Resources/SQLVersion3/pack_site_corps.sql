create or replace
PACKAGE BODY PACK_SITE AS
  
    --===============================================================================
    -- Retourne la gravité d'alarme maximum existant sur un site
    FUNCTION get_grave_max(p_id site.site_id%TYPE) RETURN NUMBER IS
	
        l_grave ACCES_ACCESC_REP.ALARMGEREE_GRAVE%TYPE;
    BEGIN
        RETURN lien_acces_alarme.get_grave_max(p_id, spv_types.c_type_site);
    END get_grave_max;
    --===============================================================================
    
    
    --===============================================================================
    -- Met à jour le coefficient opérationnel du site et de ses dépendances
    PROCEDURE set_coeff_oper (p_site_id SITE.SITE_ID%TYPE, 
                              p_coeff diagramme.etat_oper_t,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)
    IS
    BEGIN
        update SITE_REP
            set SITE_COEF = p_coeff
            where SITE_ID = p_site_id;
            
        -- Mise à jour du coefficient opérationnel de tous éléments de graphes qui exploitent
        -- ce site
        diagramme.set_coeff_oper_ts_graph(NULL, NULL, p_site_id, p_coeff, infos_diag_table);
        
    END set_coeff_oper;
    --===============================================================================
    
    
    
    --===============================================================================
    FUNCTION get_oper (p_site_id site.site_id%TYPE) 
    RETURN diagramme.etat_oper_t IS
    
        l_coeff diagramme.etat_oper_t;
    BEGIN
        SELECT site_coef INTO l_coeff FROM site_rep WHERE site_id = p_site_id;
        RETURN l_coeff;
    END get_oper;
    --===============================================================================
    
    
    
    
    --===============================================================================
    PROCEDURE maj_oper_site(Id NUMBER, SiteId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
                            EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
                            EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
                            EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                            infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) IS
        
        -- Coefficient opérationnel de l'élt. géré en cause
        CoeffOperElt	diagramme.etat_oper_t;
        Grave	NUMBER;		/* Gravité des alarmes restantes */

        Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associé au programme
        
        CURSOR CurType IS
          select SITE.TYPSITE_ID, TYPSITE_NOM, SITE_NOM 
            from TYPSITE, SITE 
            where SITE_ID = SiteId and TYPSITE.TYPSITE_ID = SITE.TYPSITE_ID;

    BEGIN
        EltId := SiteId;
        EltSiteId := SiteId;
        FOR rCurType IN CurType LOOP
            EltTypeId := rCurType.TYPSITE_ID;
            EltTypeNom := rCurType.TYPSITE_NOM;
            EltNom := rCurType.SITE_NOM;
            EltSiteNom := rCurType.SITE_NOM;
            EXIT;
        END LOOP;
    
        -- Mise à jour de l'état opérationnel du site et de ses dépendances
        Grave := get_grave_max(SiteId);

        Grave := GREATEST (Grave, AlarmGrave);

        CoeffOperElt := diagramme.calc_coeff_oper_elt(Grave, AlarmLocal);
        set_coeff_oper(SiteId, CoeffOperElt, infos_diag_table);
    
    END maj_oper_site;
    --===============================================================================
    
    
    --===============================================================================
    PROCEDURE init_oper_sites IS
        CURSOR CurSite IS
          SELECT site_id FROM site ORDER BY site_id;
        EltSiteId site.site_id%TYPE;
        EltSiteNom site.site_nom%TYPE;
        EltTypeId typsite.typsite_id%TYPE;
        EltTypeNom typsite.typsite_nom%TYPE;
        EltId site.site_id%TYPE;
        EltNom site.site_nom%TYPE;
        infos_diag_table diagramme.infos_diag_t;
    BEGIN
        FOR rCurSite IN CurSite LOOP
            infos_diag_table.DELETE;
            maj_oper_site(NULL, rCurSite.site_id, alarme_geree.c_locale, alarme_geree.c_sans,
                          EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, infos_diag_table);
        END LOOP;
    END init_oper_sites;
    --===============================================================================
    
    
    
    --===============================================================================
    FUNCTION GetSiteNom(SiteId NUMBER)
    return VARCHAR2 is

	SiteNom SITE.SITE_NOM%TYPE;

    BEGIN
        IF SiteId IS NOT NULL AND SiteId > spv_types.c_inex_objet_id THEN
            select SITE_NOM into SiteNom from SITE where SITE_ID = SiteId;
        END IF;
	
	return SiteNom;
    EXCEPTION
        when NO_DATA_FOUND then
            return ('INEX');

        when OTHERS then
            return ('ERROR');	
    END GetSiteNom;
    --===============================================================================
    
END PACK_SITE;
