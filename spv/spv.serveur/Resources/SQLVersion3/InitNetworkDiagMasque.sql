DECLARE
	CURSOR CProg IS
		SELECT smtdiag_id, prog_id, ntwdiag_id, prog_masque
			FROM network_diag, prog
			WHERE smtdiag_id = ntwdiag_smt_id;
			
	CURSOR CurMsk (ProgId NUMBER) IS
		SELECT * FROM prog_msk
			WHERE prog_id = ProgId;
BEGIN
	FOR rCProg IN Cprog LOOP
	
		UPDATE network_diag SET ntwdiag_masque = rCProg.prog_masque
			WHERE ntwdiag_id = rCProg.ntwdiag_id;
			
		FOR rCurMsk IN CurMsk (rCProg.prog_id) LOOP
			INSERT INTO network_diag_masque (network_diag_masque_id, ntwdiag_id, 
											 network_diag_masque_etat, acces_accesc_id)
			VALUES (seq_network_diag_masque.NEXTVAL, rCProg.ntwdiag_id, rCurMsk.msk,
					rCurMsk.CABL_ID);
		END LOOP;
	END LOOP;	
END;