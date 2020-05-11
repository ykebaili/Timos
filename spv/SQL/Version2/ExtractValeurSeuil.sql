create or replace FUNCTION ExtractValeurSeuil
(
 AlarmInfo	ALARM.ALARM_INFO%TYPE,
 VSeuil	OUT	NUMBER
)
RETURN BOOLEAN
IS
--
-- Cette fonction extrait la valeur du seuil mesur� et qui a
-- provoqu� l'alarme.
-- Le format du message le contenant est le suivant :
-- "Seuil non respect� (Seuil bas : xx; Seuil haut: yy; Mesure: zz)"
-- X.L. Cr�ation le 27/11/09
--

	nPosParentheseOuvrante	NUMBER;
	nPosParentheseFermante	NUMBER;
	nPos2pointSeuilBas	NUMBER;
	nPos2pointSeuilHaut	NUMBER;
	nPos2PointMesure	NUMBER;
	nPosPointVirgSeuilBas	NUMBER;
	nPosPointVirgSeuilHaut	NUMBER;
BEGIN
	-- V�rification globale du format
	nPosParentheseOuvrante := INSTR (AlarmInfo, '(');
	IF (nPosParentheseOuvrante = 0) THEN
		return FALSE;
        END IF;

	nPos2pointSeuilBas := INSTR (AlarmInfo, ':', nPosParentheseOuvrante);
	IF (nPos2pointSeuilBas = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPosPointVirgSeuilBas := INSTR (AlarmInfo, ';', nPos2pointSeuilBas);
	IF (nPosPointVirgSeuilBas = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPos2pointSeuilHaut := INSTR (AlarmInfo, ':', nPosPointVirgSeuilBas);
	IF (nPos2pointSeuilHaut = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPosPointVirgSeuilHaut := INSTR (AlarmInfo, ';', nPos2pointSeuilHaut);
	IF (nPosPointVirgSeuilHaut = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPos2PointMesure := INSTR (AlarmInfo, ':', nPosPointVirgSeuilHaut);
	IF (nPos2PointMesure = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPosParentheseFermante := INSTR (AlarmInfo, ')', nPos2PointMesure);
	IF (nPosParentheseFermante = 0) THEN
		RETURN FALSE;
        END IF;
        
	IF (nPosParentheseFermante - nPos2PointMesure <= 2) THEN	-- pas de valeur
		return false;
        END IF;
        
	IF (CheckStr (substr (AlarmInfo, nPos2PointMesure + 2, nPosParentheseFermante - nPos2PointMesure - 2), '0123456789,.-') = 0) THEN
		RETURN FALSE;
        END IF;
        
	VSeuil := to_number (substr (AlarmInfo, nPos2PointMesure + 2, nPosParentheseFermante - nPos2PointMesure - 2));
	RETURN TRUE;
	
END ExtractValeurSeuil;