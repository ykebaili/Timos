create or replace
TRIGGER TIB_NTWDIAG_REP
  BEFORE INSERT ON NTWDIAG_REP FOR EACH ROW 
DECLARE
    l_coeff diagramme.etat_oper_t;
BEGIN
    SELECT NVL(MIN(ntwgph_coef_oper), 1) INTO :new.ntwdrep_coef
      FROM network_graph 
      WHERE ntwdiag_id = :new.ntwdiag_id 
      AND ntwgph_parent_id IS NULL;
END;

