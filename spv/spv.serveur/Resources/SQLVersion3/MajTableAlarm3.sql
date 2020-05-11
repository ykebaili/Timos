DECLARE
	strProgId VARCHAR2(15);
	ProgId PROG.PROG_ID%TYPE;
	DiagId NETWORK_DIAG.NTWDIAG_ID%TYPE;
	PrConc1 ALARM3.ALARM3_PRCONC%TYPE;
    PrConc2 ALARM3.ALARM3_PRCONC%TYPE;
    nPos NUMBER;
    
    CURSOR CAlarm3 IS
        SELECT * FROM alarm3;

	CURSOR CProg (p_ProgId PROG.PROG_ID%TYPE) IS
		SELECT smtdiag_id FROM prog WHERE prog_id = p_ProgId;
		
	CURSOR CDiag (p_SmtDiagId NETWORK_DIAG.NTWDIAG_SMT_ID%TYPE) IS
		SELECT ntwdiag_id FROM network_diag WHERE ntwdiag_smt_id = p_SmtDiagId;

BEGIN
    FOR rCAlarm3 IN CAlarm3 LOOP
		
		-- Transformation des chaînes de programmes concernés de la forme id;id;etc
		-- qui sont des ID de services (table PROG) en ID de diagramme réseau
		-- table (NETWORK_DIAG). Le lien se fait par le SMT_ID
		PrConc1 := rCAlarm3.alarm3_prconc;
		PrConc2 := '';
		IF LENGTH (PrConc1) > 0 THEN
			WHILE TRUE LOOP
				nPos := INSTR (PrConc1, ';');
				IF nPos > 0 THEN
					strProgId := SUBSTR (PrConc1, 1, nPos -1);
				ELSE
					strProgId := PrConc1;
				END IF;
				IF strProgId IS NOT NULL AND LENGTH(strProgId) > 0 THEN
					ProgId := TO_NUMBER(strProgId);
					FOR rCProg IN CProg (ProgId) LOOP
						FOR rCDiag IN CDiag (rCProg.smtdiag_id) LOOP
							PrConc2 := PrConc2 || ';' || rCDiag.ntwdiag_id;
							EXIT;
						END LOOP;
						EXIT;
					END LOOP;
				END IF;
				PrConc1 := SUBSTR (PrConc1, nPos + 1);
				IF (PrConc1 IS NULL OR LENGTH (PrConc1) = 0) THEN
					EXIT;
				END IF;
			END LOOP;
		END IF;
		IF LENGTH (PrCOnc2) > 0 THEN
			PrConc2 := PrConc2 || ';';
		END IF;
			
		UPDATE alarm3 
			SET alarm3_prconc = PrConc2
			WHERE alarm3_id = rCAlarm3.alarm3_id;
    END LOOP;
END;