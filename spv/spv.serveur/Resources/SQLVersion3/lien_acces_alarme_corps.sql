create or replace
PACKAGE BODY LIEN_ACCES_ALARME AS
  
    --========================================================================================
    FUNCTION get_grave_max(p_id NUMBER, p_type_objet spv_types.type_objet_t) 
        RETURN alarme_geree.gravite_t AS
        
        l_grave ACCES_ACCESC_REP.ALARMGEREE_GRAVE%TYPE;
        l_nom_col_id spv_types.nom_col_t;
        l_requete VARCHAR2(256);
    BEGIN
        CASE
            WHEN p_type_objet = spv_types.c_type_equip THEN
                l_nom_col_id := c_col_equip_id;
            WHEN p_type_objet = spv_types.c_type_site THEN
                l_nom_col_id := c_col_site_id;
            WHEN p_type_objet = spv_types.c_type_liai THEN
                l_nom_col_id := c_col_liai_id;
            ELSE
                RAISE_APPLICATION_ERROR (-20000, spv_mess.get_mess(spv_mess.c_type_erreur,3));
        END CASE;
              
        l_requete := 'SELECT MAX (ALARMGEREE_GRAVE) FROM ACCES_ACCESC_REP'
                  || ' WHERE ' ||  l_nom_col_id  || ' = :1'
                  || ' AND ALARM_ID IS NOT NULL';
                  
        EXECUTE IMMEDIATE l_requete INTO l_grave USING p_id;
        l_grave := NVL(l_grave, 0);
        return l_grave;
    END get_grave_max;
    --========================================================================================
    
    
    
    --========================================================================================
    FUNCTION get_diagrammes_concernes (p_id NUMBER) 
    RETURN diag_id_t IS
        CURSOR CurDiag IS
            SELECT DISTINCT ntwdiag_id FROM network_graph, acces, acces_accesc	-- al. de site
                WHERE acces_accesc_id = 41267 AND
                      acces_accesc.acces1_id = acces.acces_id AND
                      acces.site_id = network_graph.site_id
            UNION                               -- al. de liaison
            SELECT DISTINCT ntwdiag_id FROM network_graph, acces, acces_accesc
                WHERE acces_accesc_id = 41267 AND
                      acces_accesc.acces1_id = acces.acces_id AND
                      acces.liai_id = network_graph.liai_id
            UNION				-- al. d'équipement câblé
            SELECT DISTINCT ntwdiag_id FROM network_graph, acces, acces_accesc
                WHERE acces_accesc_id = 41267 AND
                      acces_accesc.acces1_id = acces.acces_id AND
                      acces.equip_id = network_graph.equip_id
            UNION				-- al. d'équipement GSITE ou IS ou SYST ou TRAP
            SELECT DISTINCT ntwdiag_id FROM network_graph, acces_accesc
                WHERE acces_accesc_id = 41267 AND
                      acces_accesc.acces_bindingid = network_graph.equip_id;
                      
        diag_table diag_id_t;
        nIndex PLS_INTEGER := 0;
    BEGIN
        FOR rCurDiag IN CurDiag LOOP
            diag_table (nIndex) := rCurDiag.ntwdiag_id;
            nIndex := nIndex + 1;
        END LOOP;
        RETURN diag_table;
    END get_diagrammes_concernes;
    --========================================================================================
    
    
    
    --========================================================================================
    FUNCTION get_diagrammes_masques (p_id NUMBER) 
    RETURN diag_id_t IS
        CURSOR CurDiag  IS      /* Liste des diagrammes à démasquer */
        SELECT ntwdiag_id FROM network_diag_masque
            WHERE acces_accesc_id = p_id;
            
        diag_table diag_id_t;
        nIndex PLS_INTEGER := 0;
    BEGIN
        FOR rCurDiag IN CurDiag LOOP
            diag_table(nIndex) := rCurDiag.ntwdiag_id;
            nIndex := nIndex + 1;
        END LOOP;
        RETURN diag_table;
    END get_diagrammes_masques;
    --========================================================================================
    
    
    
    --========================================================================================
    PROCEDURE get_diagrammes_concernes (p_id NUMBER, 
                                        infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)
    IS
        nMasque network_diag.ntwdiag_masque%TYPE;
        nCoeff ntwdiag_rep.ntwdrep_coef%TYPE;
        diag_table diag_id_t;
    BEGIN
        diag_table := get_diagrammes_concernes (p_id);
        FOR i IN diag_table.FIRST .. diag_table.LAST LOOP
            SELECT ntwdiag_masque, ntwdrep_coef INTO nMasque, nCoeff
              FROM ntwdiag_rep, network_diag 
              WHERE network_diag.ntwdiag_id = diag_table(i) 
              AND ntwdiag_rep.ntwdiag_id = network_diag.ntwdiag_id;
          
              diagramme.maj_info_diag_table(diag_table(i), nCoeff, nCoeff, nMasque, 
                                            infos_diag_table);
        END LOOP;                              
    END get_diagrammes_concernes;
    --========================================================================================

END LIEN_ACCES_ALARME;
