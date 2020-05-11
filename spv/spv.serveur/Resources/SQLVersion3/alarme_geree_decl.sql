create or replace
PACKAGE alarme_geree
AS
    SUBTYPE   gravite_t IS NUMBER(1);
    SUBTYPE   locale_t  IS NUMBER(1);

    c_sans          CONSTANT gravite_t := 0;
    c_avertissement CONSTANT gravite_t := 3;
    c_indetermine   CONSTANT gravite_t := 4;
    c_mineure       CONSTANT gravite_t := 5;
    c_majeure       CONSTANT gravite_t := 6;
    c_critique      CONSTANT gravite_t := 7;
	
    c_locale        CONSTANT locale_t := 1;
    c_distante      CONSTANT locale_t := 0;
        
    FUNCTION libelle_gravite (code gravite_t) RETURN VARCHAR2;
END alarme_geree;
