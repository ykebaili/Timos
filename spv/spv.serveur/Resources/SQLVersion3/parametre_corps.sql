create or replace
PACKAGE BODY parametre AS
	FUNCTION get_valeur(type_param param.param_type%TYPE,
						nom_param param.param_valeur%TYPE) 
	RETURN VARCHAR2 IS
		valeur param.param_valeur%TYPE;
		pos NUMBER;	-- position du signe =
		
		CURSOR cur_val IS
			SELECT param_valeur FROM param
				WHERE param_type = type_param
				AND (param_valeur like nom_param || '=%'
                                OR param_valeur like nom_param || ' =%');
	BEGIN
		OPEN cur_val;
		FETCH cur_val INTO valeur;
		CLOSE cur_val;
		
		IF valeur IS NOT NULL THEN
			pos := INSTR(valeur, '=');
			IF pos > 1 THEN
				valeur := TRIM(SUBSTR(valeur, pos + 1));
			END IF;
		END IF;
		return valeur;
	END get_valeur;
END parametre;
