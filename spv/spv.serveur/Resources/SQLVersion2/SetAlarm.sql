create or replace
PROCEDURE SetAlarm
(
	Grave	NUMBER,		-- Gravit� de l'alarme, selon la norme X733 :
				-- 0 : fin d'alarme
				-- 3 : avertissement
				-- 4 : ind�termin�
				-- 5 : mineur
				-- 6 : majeur
				-- 7 : critique
				-- ATTENTION, pour certaines alarmes, la gravit� est impos�e
				-- par la configuration et ne vaudra pas la valeur entr�e ici
	DateStr	VARCHAR2,	-- Date et heure du d�but de l'alarme, au format normalis� :
				-- 'YYYY MM DD HH:MN:SS'
				-- ou ''. Dans ce cas, la date et heure syst�me seront prises par d�faut
	Type	VARCHAR2,	-- 'BOUCLE', 'SERIE', 'TRAPG', 'TRAPS' ou 'SYST'
	EquCapture VARCHAR2,	-- Nom du type de l'�quipement de capture
				-- (aujourd'hui 'IS', 'IP2PORTS' ou '' si raccordement direct � l'EM)
	NumObj	NUMBER,		-- N� de l'�quipement de capture auquel l'�l�ment g�r� est raccord�
				-- pour les alarmes 'BOUCLE' et 'SERIE'
				-- N� de trap pour les alarmes 'TRAP'
	NumAl	VARCHAR2,	-- N� de l'acc�s sur l'�quipement de capture, auquel l'�l�ment g�r� est raccord�
				-- (alarmes 'BOUCLE'. Pour les 'IS' : (n� carte -1) * 48 + n� acc�s sur la carte)
				-- N� du bit d'alarme dans le message s�rie, pour les alarmes 'SERIE'
				-- (Pour les 'IS' : ((n� carte -1) * 8 + (n� acc�s sur la carte -1)) *10000 + n� bit)
				-- Adresse IP de l'�l�ment g�r� pour les 'TRAP'
				-- Identifiant de l'alarme pour les alarmes 'SYST'
	Info	VARCHAR2,	-- Pour les 'TRAP' : champ "variable" du trap ("VarBinds"), cod� ainsi :
				-- OID1 = Valeur1;OID2 = Valeur2; etc....
				-- Pour les alarmes 'SYST' : message d'alarme syst�me
				-- limit� � 256 caract�res
	IANA	VARCHAR2	-- Pour les 'TRAP', n� IANA attribu� au fabricant de l'agent
)
IS
	AlarmCl VARCHAR2 (5);	-- Classe de l'alarme
	AlarmTxt NUMBER;	-- N� identifiant le type d'alarme
	DateS   VARCHAR2 (20);	-- Date de l'alarme

BEGIN

	if (Grave > 0 and TestAlarm (Type, EquCapture, NumObj, NumAl, IANA)) then
	    return;
	end if;			-- l'alarme est d�j� en cours

	if (DateStr is NULL) then
	    DateS := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
	else
	    DateS := DateStr;
	end if;

	if (Type = 'SYST') then
	    AlarmTxt := 3;
	else
	    AlarmTxt := 1;
	end if;

	if (Type = 'BOUCLE') then
	    if (EquCapture = 'IS') then
		AlarmCl := 'IS';
	    else
		AlarmCl := 'IP2';
	    end if;
	elsif (Type = 'SERIE') then
	    AlarmCl := 'IS_S';
	elsif (Type = 'TRAP')  then	-- Temporaire, ce type va dispara�tre
		AlarmCl := 'TRAPS';
	   else
	    	AlarmCl := Type;	-- ex. Type = 'TRAPG' ou 'TRAPS' ou autre
	   end if;

	insert into ALARM (alarm_id, alarm_num, alarm_cl, alarm_numobj, alarm_date, alarm_grave,
			   alarm_numal, alarm_commut, alarm_texte, alarm_info,
			   alarm_comment)
	    values
	    (SEQ_ALARM.NEXTVAL, SEQ_ALARM.CURRVAL, AlarmCl, NumObj, DateS, Grave,
	     Numal, 0, AlarmTxt, Info, IANA);
	commit;

END	SetAlarm;
