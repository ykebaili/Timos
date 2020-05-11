create or replace
PACKAGE BODY diagramme
AS      
	--====================================================================
    FUNCTION libelle (code code_oper_t) RETURN VARCHAR2 IS
    BEGIN
        CASE code
        WHEN c_all_mandatory THEN
            RETURN 'All mandatory';
        WHEN c_automatic THEN
            RETURN 'Automatic';
        WHEN c_custom THEN
            RETURN 'Custom';
        ELSE
            RETURN '';
        END CASE;
    END libelle;
    --====================================================================
    
    
    --====================================================================
    -- Recherche du parametre en base de données donnant le mode
    -- de calcul de l'état opérationnel
    FUNCTION get_parametre RETURN code_oper_t IS
        valeur_char param.param_valeur%TYPE;
        valeur_num code_oper_t := c_default_value;
    BEGIN
        valeur_char := parametre.get_valeur(parametre.c_parametres_client, 
                                            parametre.c_str_mode_oper_schema);
        valeur_num := NVL(TO_NUMBER(valeur_char), c_default_value);
        
        IF valeur_num < c_all_mandatory OR valeur_num > c_custom THEN
            RETURN c_default_value;
        ELSE
            RETURN valeur_num;
        END IF;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN c_default_value;
    END get_parametre;
    --====================================================================
    
    
    --====================================================================
    -- Calcul de l'état opérationnel de l'élément en fonction de la gravité de l'alarme,
    -- du fait que l'alarme est locale ou non et du paramétrage global pour ce calcul
    FUNCTION calc_coeff_oper_elt(gravite alarme_geree.gravite_t, locale spv_types.bool_t) 
    RETURN etat_oper_t IS
        l_mode_calc code_oper_t;
    BEGIN
        IF gravite >= alarme_geree.c_majeure THEN
            RETURN 0;
        END IF;
        RETURN 1;
        /*
        l_mode_calc := get_parametre;
        IF l_mode_calc = c_automatic THEN
            IF gravite >= alarme_geree.c_majeure AND locale = spv_types.c_true THEN
                RETURN 0;						-- non fonctionnel
            ELSIF gravite > alarme_geree.c_sans AND locale = spv_types.c_true THEN
                RETURN 0.75;
            ELSIF gravite > alarme_geree.c_sans AND locale = spv_types.c_false THEN
                RETURN 0.90;
            ELSE
                RETURN 1;
            END IF;
        ELSIF l_mode_calc = c_all_mandatory THEN
            IF gravite >= alarme_geree.c_majeure THEN
                RETURN 0;
            ELSIF gravite >= alarme_geree.c_mineure THEN
                RETURN 0.75;
            ELSIF gravite >= alarme_geree.c_avertissement THEN
                RETURN 0.90;
            ELSE
                RETURN 1;
            END IF;
        ELSE
            -- cas non encore implanté
            RAISE_APPLICATION_ERROR (spv_mess.c_num_oracle, spv_mess.get_mess (spv_mess.c_type_erreur, 1));
        END IF;*/
    END calc_coeff_oper_elt;
    --====================================================================
    
    
    --====================================================================
    -- Calcul de l'état opérationnel d'un élément de graphe parent
    -- à partir de son ou de ses fils et mise à jour de cet élément
    PROCEDURE calc_coeff_parent_graph (p_id NETWORK_GRAPH.NTWGPH_ID%TYPE,
                                       p_coeff_oper_fils etat_oper_t,
                                       infos_diag_table IN OUT NOCOPY infos_diag_t) IS
        ntype code_type_t;
        parent_id network_graph.ntwgph_id%TYPE;
        l_coeff etat_oper_t;
        diag_id network_diag.NTWDIAG_ID%TYPE;
		
    BEGIN
    
        SELECT ntwgph_type, network_graph.ntwgph_parent_id, ntwdiag_id 
            INTO ntype, parent_id, diag_id
            FROM network_graph 
            WHERE ntwgph_id = p_id;
			
        IF ntype = c_type_et THEN
            SELECT MIN (ntwgph_coef_oper) INTO l_coeff
                FROM network_graph
                WHERE ntwgph_parent_id = p_id;
        ELSIF ntype = c_type_ou THEN
            SELECT ROUND(AVG(ntwgph_coef_oper), c_nb_decim) INTO l_coeff
                FROM network_graph
                WHERE ntwgph_parent_id = p_id;
        ELSIF ntype = c_type_ssschema THEN
            l_coeff := p_coeff_oper_fils;
        ELSE
            RAISE_APPLICATION_ERROR (spv_mess.c_num_oracle, spv_mess.get_mess (spv_mess.c_type_erreur, 2));
        END IF;
		
        set_coeff_oper_un_graph (p_id, parent_id, diag_id, l_coeff, infos_diag_table);
    END calc_coeff_parent_graph;
    --====================================================================
    
    
    --====================================================================
    -- Mise à jour du coefficient opérationnel d'un élément de graphe
    PROCEDURE set_coeff_oper_un_graph (p_id NETWORK_GRAPH.NTWGPH_ID%TYPE,
                                       p_parent_id NETWORK_GRAPH.NTWGPH_PARENT_ID%TYPE,
                                       p_diag_id NETWORK_DIAG.NTWDIAG_ID%TYPE,
                                       p_coeff_oper etat_oper_t,
                                       infos_diag_table IN OUT NOCOPY infos_diag_t) IS
    BEGIN
        UPDATE network_graph 
            SET ntwgph_coef_oper = p_coeff_oper
            WHERE ntwgph_id = p_id;
			
        IF p_parent_id IS NOT NULL THEN
            calc_coeff_parent_graph (p_parent_id, p_coeff_oper, infos_diag_table);
        ELSE
            -- on a remonté toute la chaîne, on peut mettre à jour l'état du diagramme
            -- si s'en est un (diagramme qui n'est pas une liaison)
            set_coeff_oper_diag (p_diag_id, p_coeff_oper, infos_diag_table);
        END IF;
    END set_coeff_oper_un_graph;
    --====================================================================
	
	
    --====================================================================
    -- Mise à jour du coefficient opérationnel de tous les
    -- éléments de graphe faisant référence à un équipement ou une liaison ou un site
    PROCEDURE set_coeff_oper_ts_graph (p_equip_id EQUIP.EQUIP_ID%TYPE,
                                       p_liai_id LIAI.LIAI_ID%TYPE,
                                       p_site_id SITE.SITE_ID%TYPE,
                                       p_coeff_oper etat_oper_t,
                                       infos_diag_table IN OUT NOCOPY infos_diag_t) IS
        CURSOR CurNetGraph IS
            SELECT * FROM network_graph 
                WHERE (p_equip_id IS NOT NULL AND equip_id = p_equip_id)
                OR (p_liai_id IS NOT NULL AND liai_id = p_liai_id)
                OR (p_site_id IS NOT NULL AND site_id = p_site_id);
    BEGIN
        FOR rCurNetGraph IN CurNetGraph LOOP
            set_coeff_oper_un_graph (rCurNetGraph.ntwgph_id, 
                                     rCurNetGraph.ntwgph_parent_id, 
                                     rCurNetGraph.ntwdiag_id, p_coeff_oper, infos_diag_table);
        END LOOP; 
    END set_coeff_oper_ts_graph;	
    --====================================================================


    --====================================================================
    -- Met à jour le coefficient opérationnel du service et stocke les informations
    -- nécessaires dans le tableau 'infos_diag_table'
    PROCEDURE set_coeff_oper_diag (p_diag_id NETWORK_DIAG.NTWDIAG_ID%TYPE, p_coeff_oper etat_oper_t,
                                   infos_diag_table IN OUT NOCOPY infos_diag_t) IS
        l_liai_id NETWORK_DIAG.LIAI_ID%TYPE;
        l_old_coeff NTWDIAG_REP.NTWDREP_COEF%TYPE;
        l_masque NETWORK_DIAG.NTWDIAG_MASQUE%TYPE;
    BEGIN
                 
        SELECT liai_id, ntwdrep_coef, ntwdiag_masque INTO l_liai_id, l_old_coeff, l_masque
            FROM ntwdiag_rep, network_diag 
              WHERE network_diag.ntwdiag_id = p_diag_id
              AND ntwdiag_rep.NTWDIAG_ID = network_diag.NTWDIAG_ID;

        UPDATE ntwdiag_rep SET ntwdrep_coef = p_coeff_oper
              WHERE ntwdiag_id = p_diag_id;
              
        
       
        IF l_liai_id IS NULL THEN   -- c'est un service 
            maj_info_diag_table (p_diag_id, l_old_coeff, p_coeff_oper, l_masque, infos_diag_table);   
        ELSE                        -- c'est une liaison
            liaison.set_coeff_oper(l_liai_id, LEAST(liaison.get_coeff_from_als(l_liai_id), p_coeff_oper),
                                   infos_diag_table);
        END IF;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            -- l'enregistrement NTWDIAG_REP n'est pas encore créé
            -- il va falloir calculer le coefficient opérationnel à partir d'un trigger
            -- before sur cette table
            NULL;
    END set_coeff_oper_diag;
    --====================================================================
    
    
    
    --====================================================================
    PROCEDURE maj_info_diag_table (p_diag_id network_diag.ntwdiag_id%TYPE,
                                   p_old_coeff etat_oper_t, p_new_coeff etat_oper_t,
                                   p_masque type_masque_t,
                                   infos_diag_table IN OUT NOCOPY infos_diag_t) IS
        l_index index_t;
        infos_diag  infos_diag_r;
    BEGIN
        l_index := TO_CHAR(p_diag_id);
        IF infos_diag_table.EXISTS(l_index) THEN
            infos_diag := infos_diag_table(l_index);
        ELSE
            infos_diag.m_old_coeff_oper := p_old_coeff;
            infos_diag.m_diag_id := p_diag_id;
            SELECT network_diag.ntwdiag_label INTO infos_diag.m_diag_label
              FROM network_diag WHERE ntwdiag_id = p_diag_id;
        END IF;
        
        infos_diag.m_new_coeff_oper := p_new_coeff;
        infos_diag.m_masque := p_masque;
        infos_diag_table(l_index) := infos_diag;
	END maj_info_diag_table;
    --====================================================================
    
    
    
    --==============================================================================
    PROCEDURE calc_and_set_coeff_oper_diag (p_diag_id network_diag.ntwdiag_id%TYPE)
    IS
        CURSOR CurElt IS
            SELECT ntwgph_id, ntwgph_parent_id, equip_id, liai_id, site_id
              FROM network_graph
              WHERE equip_id IS NOT NULL 
              OR liai_id IS NOT NULL
              OR site_id IS NOT NULL;
              
        l_coeff diagramme.etat_oper_t;
        infos_diag_table infos_diag_t;
    BEGIN
        FOR rCurElt IN CurElt LOOP
            IF rCurElt.equip_id IS NOT NULL THEN
                l_coeff := equipement.get_oper(rCurElt.equip_id);
            ELSIF rCurElt.liai_id IS NOT NULL THEN
                l_coeff := liaison.get_oper(rCurElt.liai_id);
            ELSIF rCurElt.site_id IS NOT NULL THEN
                l_coeff := pack_site.get_oper(rCurElt.site_id);
            ELSE
                RAISE_APPLICATION_ERROR (-20000, 
                                          spv_mess.get_mess(spv_mess.c_type_erreur, 4));
            END IF;
            
            set_coeff_oper_un_graph (rCurElt.ntwgph_id, rCurElt.ntwgph_parent_id,
                                     p_diag_id, l_coeff, infos_diag_table);
        END LOOP;
    END calc_and_set_coeff_oper_diag;
    --==============================================================================
    
END diagramme;
