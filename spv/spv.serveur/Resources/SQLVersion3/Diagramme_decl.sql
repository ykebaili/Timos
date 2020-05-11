create or replace
PACKAGE diagramme
AS
    -- type pour le code des modes de calcul de l'état opérationnel
    SUBTYPE code_oper_t IS NUMBER(1);
    
    c_all_mandatory   CONSTANT code_oper_t := 0;
    c_automatic       CONSTANT code_oper_t := 1;
    c_custom          CONSTANT code_oper_t := 2;
    c_default_value   CONSTANT code_oper_t := c_automatic;

    -- type pour l'état opérationnel
    SUBTYPE	etat_oper_t IS NUMBER;
    c_operationnel    CONSTANT etat_oper_t := 1;
    c_coupe           CONSTANT etat_oper_t := 0;
    
    -- type pour le type de branche dans un network_graph
    SUBTYPE code_type_t IS NUMBER(1);
    c_type_ou       CONSTANT code_type_t := 0;
    c_type_et       CONSTANT code_type_t := 1;
    c_type_elt      CONSTANT code_type_t := 2;
    c_type_ssschema CONSTANT code_type_t := 3;
    
    -- type pour le type de masquage
    SUBTYPE type_masque_t IS NUMBER(1);
    c_non_masque    CONSTANT type_masque_t := 0;
    c_masque_ope    CONSTANT type_masque_t := 1;
    c_masque_adm    CONSTANT type_masque_t := 2;
    
    c_nb_decim      CONSTANT NUMBER := 2;   -- nombre de décimales pour l'arrondi du coeff
    
    -- type pour stocker les informations sur les services 
    -- (doc les diagrammes qui ne sont pas des liaisons)
    TYPE infos_diag_r IS RECORD
      (
        m_diag_id         NETWORK_DIAG.NTWDIAG_ID%TYPE,
        m_diag_label      NETWORK_DIAG.NTWDIAG_LABEL%TYPE,
        m_old_coeff_oper  NTWDIAG_REP.NTWDREP_COEF%TYPE,
        m_new_coeff_oper  NTWDIAG_REP.NTWDREP_COEF%TYPE,
        m_masque          NETWORK_DIAG.NTWDIAG_MASQUE%TYPE
      );
      
    
    SUBTYPE index_t IS VARCHAR2(20);
    TYPE infos_diag_t IS TABLE OF infos_diag_r INDEX BY index_t;
    
    SUBTYPE ts_etat_oper_t  IS VARCHAR2(900);
        
        
    FUNCTION libelle (code code_oper_t) RETURN VARCHAR2;
    
    FUNCTION get_parametre RETURN code_oper_t;
    
    FUNCTION calc_coeff_oper_elt(gravite alarme_geree.gravite_t, locale spv_types.bool_t) 
    RETURN etat_oper_t;
    
    PROCEDURE calc_coeff_parent_graph (p_id NETWORK_GRAPH.NTWGPH_ID%TYPE,
                                       p_coeff_oper_fils etat_oper_t,
                                       infos_diag_table IN OUT NOCOPY infos_diag_t);

    PROCEDURE set_coeff_oper_un_graph (p_id NETWORK_GRAPH.NTWGPH_ID%TYPE, 
                                       p_parent_id NETWORK_GRAPH.NTWGPH_PARENT_ID%TYPE,
                                       p_diag_id NETWORK_DIAG.NTWDIAG_ID%TYPE,
                                       p_coeff_oper etat_oper_t,
                                       infos_diag_table IN OUT NOCOPY infos_diag_t);
										
    PROCEDURE set_coeff_oper_ts_graph (p_equip_id EQUIP.EQUIP_ID%TYPE,
                                       p_liai_id LIAI.LIAI_ID%TYPE,
                                       p_site_id SITE.SITE_ID%TYPE,
                                       p_coeff_oper etat_oper_t,
                                       infos_diag_table IN OUT NOCOPY infos_diag_t);
                                       
    PROCEDURE set_coeff_oper_diag (p_diag_id NETWORK_DIAG.NTWDIAG_ID%TYPE, 
                                   p_coeff_oper etat_oper_t,
                                   infos_diag_table IN OUT NOCOPY infos_diag_t);
                                   
    PROCEDURE maj_info_diag_table (p_diag_id network_diag.ntwdiag_id%TYPE,
                                   p_old_coeff etat_oper_t, p_new_coeff etat_oper_t,
                                   p_masque type_masque_t, infos_diag_table IN OUT NOCOPY infos_diag_t);
                                   
    PROCEDURE calc_and_set_coeff_oper_diag (p_diag_id network_diag.ntwdiag_id%TYPE);
    
END diagramme;
