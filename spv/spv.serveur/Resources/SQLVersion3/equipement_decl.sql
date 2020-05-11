create or replace
PACKAGE equipement AS
	
    FUNCTION get_grave_max(p_id equip.equip_id%TYPE) RETURN NUMBER;
	
    FUNCTION get_id_pere(p_id equip.equip_id%TYPE) RETURN NUMBER;
	
    PROCEDURE set_coeff_oper (p_equip_id EQUIP.EQUIP_ID%TYPE, 
                              p_coeff diagramme.etat_oper_t,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
							 
							 
    FUNCTION maj_oper_inclus (Id NUMBER, EquipId NUMBER, AlarmGrave NUMBER, AlarmLocal NUMBER,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) 
    RETURN NUMBER;
    
    PROCEDURE oper_englob (AlarmGrave NUMBER, EquipId NUMBER, AlarmLocal NUMBER,
                           infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
		 
    PROCEDURE maj_oper_equip(Id NUMBER, EquipId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, 
                             is_commut spv_types.is_commut_t, 
                             EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2,
                             EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
                             EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                             infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);

    FUNCTION get_oper (p_equip_id equip.equip_id%TYPE) 
    RETURN diagramme.etat_oper_t;
    
    PROCEDURE init_oper_equips;
END equipement;
