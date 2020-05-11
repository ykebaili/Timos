create or replace
PACKAGE spv_types AS
    SUBTYPE   bool_t IS NUMBER(1);
    c_false     CONSTANT bool_t := 0;
    c_true      CONSTANT bool_t := 1;
    c_str_true  CONSTANT VARCHAR2(4) := 'true';
    c_str_false CONSTANT VARCHAR2(5) := 'false';
    
    SUBTYPE type_objet_t IS NUMBER(1);
    c_type_equip  type_objet_t := 0;
    c_type_site   type_objet_t := 1;
    c_type_liai   type_objet_t := 2;
    
    SUBTYPE nom_col_t IS VARCHAR2(30);
    
    SUBTYPE is_commut_t IS bool_t;
    c_commut is_commut_t := c_true;
    c_not_commut is_commut_t := c_false;
    c_inex_objet_id CONSTANT NUMBER := -1;
    
END spv_types;
