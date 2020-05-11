create or replace
PACKAGE PACK_SITE AS

  -- TODO enter package declarations (types, exceptions, methods etc) here
  
    FUNCTION get_grave_max(p_id site.site_id%TYPE) RETURN NUMBER;
    
    PROCEDURE set_coeff_oper (p_site_id SITE.SITE_ID%TYPE, 
                              p_coeff diagramme.etat_oper_t,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                              
    FUNCTION get_oper (p_site_id site.site_id%TYPE) 
    RETURN diagramme.etat_oper_t;
    
    PROCEDURE maj_oper_site(Id NUMBER, SiteId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
                            EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
                            EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
                            EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                            infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                            
    PROCEDURE init_oper_sites;
    
    FUNCTION GetSiteNom(SiteId NUMBER) return VARCHAR2;

END PACK_SITE;
