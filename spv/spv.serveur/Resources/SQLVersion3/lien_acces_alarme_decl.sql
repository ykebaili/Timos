create or replace
PACKAGE LIEN_ACCES_ALARME AS
  
    -- TODO enter package declarations (types, exceptions, methods etc) here
    c_col_equip_id  CONSTANT spv_types.nom_col_t := 'EQUIP_ID';
    c_col_site_id   CONSTANT spv_types.nom_col_t := 'SITE_ID';
    c_col_liai_id   CONSTANT spv_types.nom_col_t := 'LIAI_ID';
    
    TYPE diag_id_t IS TABLE OF network_diag.ntwdiag_id%TYPE INDEX BY PLS_INTEGER;

    FUNCTION get_grave_max(p_id NUMBER, p_type_objet spv_types.type_objet_t) 
        RETURN alarme_geree.gravite_t;
    
    FUNCTION get_diagrammes_concernes (p_id NUMBER) RETURN diag_id_t;
    
    FUNCTION get_diagrammes_masques (p_id NUMBER) RETURN diag_id_t;
    
    PROCEDURE get_diagrammes_concernes (p_id NUMBER, 
                                        infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);

END LIEN_ACCES_ALARME;
