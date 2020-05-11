create or replace
PACKAGE LIAISON AS
    SUBTYPE liai_nom_t IS VARCHAR2(105);
    
    -- TODO enter package declarations (types, exceptions, methods etc) here
    FUNCTION get_grave_max(p_id liai.liai_id%TYPE) RETURN NUMBER;
    
    FUNCTION get_coeff_from_als(p_id liai.liai_id%TYPE)
    RETURN diagramme.etat_oper_t;
    
    PROCEDURE set_coeff_oper_ts_liai (p_equip_id EQUIP.EQUIP_ID%TYPE, 
                                      p_coeff diagramme.etat_oper_t,
                                      infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                                    
    PROCEDURE set_coeff_oper (p_liai_id LIAI.LIAI_ID%TYPE,
                              p_coeff diagramme.etat_oper_t,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                            
    FUNCTION get_oper (p_liai_id liai.liai_id%TYPE) 
    RETURN diagramme.etat_oper_t;
    
    PROCEDURE maj_oper_liai(Id NUMBER, LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
                            EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
                            EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                            infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                            
    FUNCTION get_oper_graph(p_id liai.liai_id%TYPE)
    RETURN diagramme.etat_oper_t;
    
    FUNCTION GetLiaiNom(LiaiId	liai.liai_id%TYPE) RETURN VARCHAR2;
    
    PROCEDURE init_oper_liais;

END LIAISON;
