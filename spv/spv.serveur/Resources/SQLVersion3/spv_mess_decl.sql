create or replace
PACKAGE spv_mess
AS
    -- type pour stocker ce que retourne userenv('LANG')
    SUBTYPE lang_t IS VARCHAR2(5);

    -- constantes pour définir le type de message
    c_type_erreur	CONSTANT message.message_type%TYPE := 0;
    c_type_info		CONSTANT message.message_type%TYPE := 1;
    
    -- constante pour définir le n° de message Oracle lorsque
    -- c'est un message de type c_type_erreur
    c_num_oracle	CONSTANT NUMBER := -20000;

    -- constantes pour choisir la langue des messages dans SPV
    c_lang_anglais	CONSTANT message.message_text%TYPE := 0;
    c_lang_francais	CONSTANT message.message_text%TYPE := 1;

    -- constantes pour comparer par rapport à ce que retourne userenv('LANG')
    c_ora_anglais	CONSTANT lang_t := 'US';
    c_ora_francais	CONSTANT lang_t := 'F';

    c_prefix_mess	CONSTANT lang_t := 'SPV-';
    c_format        CONSTANT VARCHAR2(5) := '00000';

    -- Renvoie la langue de l'utilisateur
    FUNCTION get_lang  RETURN NUMBER;

    -- Renvoie le message en fonction de la langue de l'utilisateur
    FUNCTION get_mess (type_mess NUMBER, code_mess NUMBER) RETURN VARCHAR2;
    FUNCTION get_mess (type_mess NUMBER, code_mess NUMBER, code_lang NUMBER) RETURN VARCHAR2;
END spv_mess;
