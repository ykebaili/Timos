create or replace
PACKAGE BODY LIAISON AS

    -- TODO enter package declarations (types, exceptions, methods etc) here
  
    --===============================================================================
    -- Retourne la gravité d'alarme maximum existant sur une liaison
    FUNCTION get_grave_max(p_id liai.liai_id%TYPE) RETURN NUMBER IS
	
        l_grave ACCES_ACCESC_REP.ALARMGEREE_GRAVE%TYPE;
    BEGIN
        RETURN lien_acces_alarme.get_grave_max(p_id, spv_types.c_type_liai);
    END get_grave_max;
    --===============================================================================
    
    
    
    --===============================================================================
    FUNCTION get_coeff_from_als(p_id liai.liai_id%TYPE)
    RETURN diagramme.etat_oper_t IS
        l_grave ACCES_ACCESC_REP.ALARMGEREE_GRAVE%TYPE;
    BEGIN
        l_grave := get_grave_max(p_id);
        -- Dans ce cas, on part du principe que l'alarme est locale
        -- mais ce n'est pas propre, il faudrait revoir cela
        return diagramme.calc_coeff_oper_elt(l_grave, alarme_geree.c_locale);
    END get_coeff_from_als;
    --===============================================================================
    
    
    
    --==============================================================================================
    -- Mise à jour du coefficient opérationnel de tous les liens inter-équipements
    -- à partir du coefficient opérationnel d'un équipement de ces liens
    PROCEDURE set_coeff_oper_ts_liai (p_equip_id EQUIP.EQUIP_ID%TYPE, 
                                      p_coeff diagramme.etat_oper_t,
                                      infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) IS
                                    
        l_coeff_equip2  diagramme.etat_oper_t;
        l_coeff_result  diagramme.etat_oper_t;
      
        l_equip2_id EQUIP.EQUIP_ID%TYPE;

        CURSOR CurLiai IS
            SELECT liai_id, liai_equiporig, liai_equipdest FROM liai 
              WHERE liai_equiporig = p_equip_id
              OR liai_equipdest = p_equip_id;
            
    BEGIN
        FOR rCurLiai IN CurLiai LOOP
            IF rCurLiai.liai_equiporig = p_equip_id THEN
                l_equip2_id := rCurLiai.liai_equipdest;
            ELSE
                l_equip2_id := rCurLiai.liai_equiporig;
            END IF;
            SELECT equip_coeff_op INTO l_coeff_equip2 FROM equip_rep
              WHERE equip_id = l_equip2_id;
            
            l_coeff_result := LEAST(p_coeff, l_coeff_equip2);
            UPDATE liai_rep SET liai_coeff_oper = l_coeff_result
              WHERE liai_id = rCurLiai.liai_id;
            
            diagramme.set_coeff_oper_ts_graph (NULL, rCurLiai.liai_id, NULL, l_coeff_result, infos_diag_table);
        END LOOP;
    END set_coeff_oper_ts_liai;
    --==============================================================================================
  
  
    --==============================================================================================
    PROCEDURE set_coeff_oper (p_liai_id LIAI.LIAI_ID%TYPE,
                              p_coeff diagramme.etat_oper_t,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) IS
                                      
    BEGIN
        update LIAI_REP
            set LIAI_COEFF_OPER = p_coeff
            where LIAI_ID = p_liai_id;
            
        -- Mise à jour du coefficient opérationnel de tous éléments de graphes qui exploitent
        -- cette liaison
        diagramme.set_coeff_oper_ts_graph(NULL, p_liai_id, NULL, p_coeff, infos_diag_table);
    END set_coeff_oper;
    --==============================================================================================
  
  
  
    --===============================================================================
    FUNCTION get_oper (p_liai_id liai.liai_id%TYPE) 
    RETURN diagramme.etat_oper_t IS
    
        l_coeff diagramme.etat_oper_t;
    BEGIN
        SELECT liai_coeff_oper INTO l_coeff FROM liai_rep WHERE liai_id = p_liai_id;
        RETURN l_coeff;
    END get_oper;
    --===============================================================================
    
    
    
    --==============================================================================================
    FUNCTION get_oper_graph(p_id liai.liai_id%TYPE)
    RETURN diagramme.etat_oper_t IS
        /* Renvoie l'état opérationnel du graphe de la liaison. Celui-ci peut être différent du
          coefficient opérationnel de la liaison; en effet, ce dernier dépend du coefficient du 
          graphe et du coeffcient dû aux alarmes câblées directement sur la liaison */
        l_coeff     diagramme.etat_oper_t;

        CURSOR cLiai IS		-- recherche du support
            select NTWDREP_COEF from NETWORK_DIAG, NTWDIAG_REP
                where LIAI_ID = p_id
                and NTWDIAG_REP.NTWDIAG_ID = NETWORK_DIAG.NTWDIAG_ID;
    BEGIN
        l_coeff := diagramme.c_operationnel;

        for rCLiai in cLiai loop	-- recherche du support
            l_coeff := LEAST (l_coeff, rCLiai.ntwdrep_coef);
            exit;
        end loop;

        return l_coeff;
    END get_oper_graph;
    --==============================================================================================
    
    
    --==============================================================================================
    PROCEDURE maj_oper_liai(Id NUMBER, LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
                            EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
                            EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                            infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) IS

      -- Coefficient opérationnel de l'élt. géré en cause
      CoeffOperElt	diagramme.etat_oper_t;

      Grave	NUMBER;		/* Gravité des alarmes restantes */

      SiteId	NUMBER;		/* Id du site contenant l'équipement en défaut */
      SiteIndex	NUMBER;		/* Index de ce site */

    BEGIN

        -- Mise à jour de Poseq et Typeq
        EltId := LiaiId;
        EltNom := GetLiaiNom (LiaiId);
        select TYPLIAI_ID, TYPLIAI_NOM
             into EltTypeId, EltTypeNom 	from LIAI
             where LIAI_ID = LiaiId;
             
        -- Mise à jour de l'état opérationnel de la liaison

        Grave := get_grave_max(LiaiId);
        Grave := GREATEST (Grave, AlarmGrave);

        CoeffOperElt := diagramme.calc_coeff_oper_elt(Grave, AlarmLocal);

        -- Prendre en compte l'état opérationnel des supports
        CoeffOperElt := LEAST (CoeffOperElt, get_oper_graph (LiaiId));

        set_coeff_oper (LiaiId, CoeffOperElt, infos_diag_table);
    END maj_oper_liai;
    --==============================================================================================
    
    
    --==============================================================================================<
    FUNCTION GetLiaiNom(LiaiId	liai.liai_id%TYPE) RETURN VARCHAR2 IS
    
        Nom		VARCHAR2 (60);	-- Nom recherché

    BEGIN

        select A.SITE_NOM ||
                decode (LIAI_DIR, 0, ' -> ', 1, ' <- ', ' <-> ') ||
                B.SITE_NOM || ' / ' || LIAI_NUM
        into Nom
        from LIAI, SITE A, SITE B
        where A.SITE_ID = SITE_ORIGID and
            B.SITE_ID = SITE_DESTID and
            LIAI_ID  = LiaiId;

        return (Nom);

    EXCEPTION
        when NO_DATA_FOUND then
        return ('INEX');

        when OTHERS then
        return ('ERROR');
    END	GetLiaiNom;
    --==============================================================================================
    
    
    
    --===============================================================================
    PROCEDURE init_oper_liais IS
        CURSOR Curliai IS
          SELECT liai_id FROM liai ORDER BY liai_id;
        EltSiteId site.site_id%TYPE;
        EltSiteNom site.site_nom%TYPE;
        EltTypeId typliai.typliai_id%TYPE;
        EltTypeNom typliai.typliai_nom%TYPE;
        EltId liai.liai_id%TYPE;
        EltNom liai_nom_t;
        infos_diag_table diagramme.infos_diag_t;
    BEGIN
        FOR rCurLiai IN CurLiai LOOP
            infos_diag_table.DELETE;
            maj_oper_liai(NULL, rCurLiai.liai_id, alarme_geree.c_locale, alarme_geree.c_sans,
                          EltTypeId, EltTypeNom, EltId, EltNom, infos_diag_table);
        END LOOP;
    END init_oper_liais;
    --===============================================================================
    
END LIAISON;
