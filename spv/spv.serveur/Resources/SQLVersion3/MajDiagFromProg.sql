DECLARE
    nCount NUMBER;
    
	CURSOR CProg IS
		SELECT smtdiag_id, prog_nom, prog_masque FROM prog;
		
BEGIN
	FOR rCProg IN CProg LOOP
		SELECT count(ntwdiag_id) INTO nCount 
			FROM network_diag 
			WHERE ntwdiag_smt_id = rCProg.smtdiag_id;
		IF nCount = 0 THEN
			INSERT INTO network_diag (ntwdiag_id, ntwdiag_label, ntwdiag_masque,
									  ntwdiag_smt_id)
				VALUES (network_diagsb.NEXTVAL, rCProg.prog_nom, rCProg.prog_masque,
						rCProg.smtdiag_id);
			INSERT INTO ntwdiag_rep (ntwdiag_id, ntwdrep_coef)
				VALUES (network_diagsb.CURRVAL, 1);
		END IF;
	END LOOP;
	UPDATE network_diag SET ntwdiag_masque = 0
	WHERE ntwdiag_masque IS NULL;
END;