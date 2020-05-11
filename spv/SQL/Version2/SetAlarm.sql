create or replace
PROCEDURE SetAlarm
(
	Grave	NUMBER,		-- Gravité de l'alarme, selon la norme X733 :
				-- 0 : fin d'alarme
				-- 3 : avertissement
				-- 4 : indéterminé
				-- 5 : mineur
				-- 6 : majeur
				-- 7 : critique
				-- ATTENTION, pour certaines alarmes, la gravité est imposée
				-- par la configuration et ne vaudra pas la valeur entrée ici
	DateStr	VARCHAR2,	-- Date et heure du début de l'alarme, au format normalisé :
				-- 'YYYY MM DD HH:MN:SS'
				-- ou ''. Dans ce cas, la date et heure système seront prises par défaut
	Type	VARCHAR2,	-- 'BOUCLE', 'SERIE', 'TRAPG', 'TRAPS' ou 'SYST'
	EquCapture VARCHAR2,	-- Nom du type de l'équipement de capture
				-- (aujourd'hui 'IS', 'IP2PORTS' ou '' si raccordement direct à l'EM)
	NumObj	NUMBER,		-- N° de l'équipement de capture auquel l'élément géré est raccordé
				-- pour les alarmes 'BOUCLE' et 'SERIE'
				-- N° de trap pour les alarmes 'TRAP'
	NumAl	VARCHAR2,	-- N° de l'accès sur l'équipement de capture, auquel l'élément géré est raccordé
				-- (alarmes 'BOUCLE'. Pour les 'IS' : (n° carte -1) * 48 + n° accès sur la carte)
				-- N° du bit d'alarme dans le message série, pour les alarmes 'SERIE'
				-- (Pour les 'IS' : ((n° carte -1) * 8 + (n° accès sur la carte -1)) *10000 + n° bit)
				-- Adresse IP de l'élément géré pour les 'TRAP'
				-- Identifiant de l'alarme pour les alarmes 'SYST'
	Info	VARCHAR2,	-- Pour les 'TRAP' : champ "variable" du trap ("VarBinds"), codé ainsi :
				-- OID1 = Valeur1;OID2 = Valeur2; etc....
				-- Pour les alarmes 'SYST' : message d'alarme système
				-- limité à 256 caractères
	IANA	VARCHAR2	-- Pour les 'TRAP', n° IANA attribué au fabricant de l'agent
)
IS
	AlarmCl VARCHAR2 (5);	-- Classe de l'alarme
	AlarmTxt NUMBER;	-- N° identifiant le type d'alarme
	DateS   VARCHAR2 (20);	-- Date de l'alarme

BEGIN

	if (Grave > 0 and TestAlarm (Type, EquCapture, NumObj, NumAl, IANA)) then
	    return;
	end if;			-- l'alarme est déjà en cours

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
	elsif (Type = 'TRAP')  then	-- Temporaire, ce type va disparaître
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
