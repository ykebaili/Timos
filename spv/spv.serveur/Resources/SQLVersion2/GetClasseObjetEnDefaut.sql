create or replace
FUNCTION GetClasseObjetEnDefaut(EquipId NUMBER, LiaiId NUMBER, SiteId NUMBER)
return VARCHAR2 is

-- Cette fonction retourne un nombre représentatif de la classe de l'objet concerné
-- par un événement ALARM.
-- Un événement ALARM concerne soit un équipement (0), soit une liaison (1),
-- soit un site (2). Si tous les ID passés en paramètre sont à NULL,
-- la fonction retourne -1.

	nRet NUMBER;
BEGIN
	nRet := -1;
	if EquipId is not null then
		nRet := 0;
	elsif LiaiId is not null then
		nRet := 1;
	elsif SiteId is not null then
		nRet := 2;
	end if;
	return nRet;
END GetClasseObjetEnDefaut;
