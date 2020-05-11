create or replace
PACKAGE parametre AS
	c_parametres_client   CONSTANT param.PARAM_TYPE%TYPE := 9;
	
	-- paramètre indiquant qu'il faut tenir compte des englobants/englobés
	-- pour le calcul de l'état opérationnel des équipements
	c_str_alarm_englob	  CONSTANT VARCHAR2(12) := 'ALARM_ENGLOB';
	-- paramètre donnant le mode de calcul pour l'état opérationnel
	-- équipements, schéma
	c_str_mode_oper_schema CONSTANT VARCHAR2(24) := 'MODE_OPERATIONNEL_SCHEMA';
	
	FUNCTION get_valeur(type_param param.param_type%TYPE,
                            nom_param param.param_valeur%TYPE) RETURN VARCHAR2;
END parametre;
