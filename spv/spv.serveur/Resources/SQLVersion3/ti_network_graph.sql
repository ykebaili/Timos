create or replace
TRIGGER TI_NETWORK_GRAPH
    AFTER INSERT ON NETWORK_GRAPH
    
DECLARE
    l_type      network_graph.ntwgph_type%TYPE;
    l_site_id   network_graph.site_id%TYPE;
    l_liai_id   network_graph.liai_id%TYPE;
    l_equip_id  network_graph.equip_id%TYPE;
    l_coeff     diagramme.etat_oper_t := 1;
    l_parent_id network_graph.NTWGPH_PARENT_ID%TYPE;
    l_diag_id   network_graph.NTWDIAG_ID%TYPE;
    infos_diag_table diagramme.infos_diag_t;
BEGIN
    FOR ligne IN (SELECT * FROM network_graph_temp ORDER BY ntwgph_id) LOOP
        SELECT ntwgph_type, site_id, liai_id, equip_id, ntwgph_parent_id, ntwdiag_id 
          INTO l_type, l_site_id, l_liai_id, l_equip_id, l_parent_id, l_diag_id
          FROM network_graph 
          WHERE ntwgph_id = ligne.ntwgph_id;

        BEGIN
            IF l_equip_id IS NOT NULL THEN
                SELECT equip_coeff_op INTO l_coeff FROM equip_rep WHERE equip_id = l_equip_id;
            ELSIF l_liai_id IS NOT NULL THEN
                SELECT liai_coeff_oper INTO l_coeff FROM liai_rep WHERE liai_id = l_liai_id;
            ELSIF l_site_id IS NOT NULL THEN
                SELECT site_coef INTO l_coeff FROM site_rep WHERE site_id = l_site_id;
            END IF;
        EXCEPTION
            WHEN NO_DATA_FOUND THEN
                -- l'enregistrement a été créé dans la même transaction, il se peut donc qu'il
                -- ne soit pas encore visible. l_coeff aura alors sa valeur intiale de 1.
                NULL;
        END;

        diagramme.set_coeff_oper_un_graph (ligne.ntwgph_id, l_parent_id, l_diag_id,
                                                          l_coeff, infos_diag_table);

    END LOOP;
    DELETE network_graph_temp;
EXCEPTION
    WHEN OTHERS THEN
        DELETE network_graph_temp;
        RAISE;
END;

