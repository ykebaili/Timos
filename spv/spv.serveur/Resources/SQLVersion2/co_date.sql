create or replace
FUNCTION CO_DATE (Val VARCHAR2)
RETURN DATE	/* Convertit une date de début ou fin d'alarme au format date */
IS
    strFormat   VARCHAR2 (40);
BEGIN
    strFormat := GetFormatDateString();
    return TO_DATE (Val, strFormat);

EXCEPTION
    -- when OTHERS then return ('2035 12 31 00:00:00');
    when OTHERS then 
        raise_application_error (-20000, 'CO_DATE function, date format not compliant with ' || strFormat);
END CO_DATE;