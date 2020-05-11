create or replace
PACKAGE BODY spv_mess
AS
    FUNCTION get_lang RETURN NUMBER IS
        l_lang	lang_t;
	BEGIN
            SELECT USERENV('LANG') INTO l_lang FROM dual;

            CASE l_lang
            WHEN c_ora_francais THEN
                RETURN c_lang_francais;
            ELSE
                RETURN c_lang_anglais;
            END CASE;
    END get_lang;

    FUNCTION get_mess (type_mess NUMBER, code_mess NUMBER, code_lang NUMBER) RETURN VARCHAR2 IS
        l_messlu	message.message_text%TYPE;
        l_messreturn	message.message_text%TYPE;
	l_lang  	message.message_lang%TYPE;

	CURSOR cur_mess IS
            SELECT message_text FROM message
              WHERE message_lang = l_lang
              AND message_type = type_mess 
              AND message_num = code_mess;
    BEGIN
        l_lang := code_lang;
        l_messreturn := c_prefix_mess || TO_CHAR(code_mess, c_format);
        OPEN cur_mess;
        FETCH cur_mess INTO l_messlu;
        CLOSE cur_mess;
        IF l_messlu IS NULL AND l_lang != c_lang_anglais THEN
            l_lang := c_lang_anglais;
            OPEN cur_mess;
            FETCH cur_mess INTO l_messlu;
            CLOSE cur_mess;
        END IF;
        IF l_messlu IS NOT NULL THEN
            l_messreturn := l_messreturn || ': ' || l_messlu;
        END IF;
				
        RETURN l_messreturn;    
    END get_mess;
    
    FUNCTION get_mess (type_mess NUMBER, code_mess NUMBER) RETURN VARCHAR2 IS
        l_messlu	message.message_text%TYPE;
        l_messreturn	message.message_text%TYPE;
	l_lang  	message.message_lang%TYPE;

	CURSOR cur_mess (langue message.message_lang%TYPE) IS
            SELECT message_text FROM message
              WHERE message_lang = langue
              AND message_type = type_mess 
              AND message_num = code_mess;
              
    BEGIN
        l_lang := get_lang;	
        RETURN get_mess (type_mess, code_mess, l_lang);	
    END get_mess;	
END spv_mess;
