create or replace
PACKAGE BODY alarme_geree
AS      
    FUNCTION libelle_gravite (code gravite_t) RETURN VARCHAR2 IS
    BEGIN
        CASE code
        WHEN c_sans THEN
            RETURN 'Without alarm';
        WHEN c_avertissement THEN
            RETURN 'Warning';
        WHEN c_indetermine THEN
            RETURN 'Undetermined';
        WHEN c_mineure THEN
            RETURN 'Minor';
	WHEN c_majeure THEN
            RETURN 'Major';
	WHEN c_critique THEN
            RETURN 'Critical';
        ELSE
            RETURN '';
        END CASE;
    END libelle_gravite;
END alarme_geree;
