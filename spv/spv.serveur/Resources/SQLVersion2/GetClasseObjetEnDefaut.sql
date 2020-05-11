create or replace
FUNCTION GetClasseObjetEnDefaut(EquipId NUMBER, LiaiId NUMBER, SiteId NUMBER)
return VARCHAR2 is

-- Cette fonction retourne un nombre repr�sentatif de la classe de l'objet concern�
-- par un �v�nement ALARM.
-- Un �v�nement ALARM concerne soit un �quipement (0), soit une liaison (1),
-- soit un site (2). Si tous les ID pass�s en param�tre sont � NULL,
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
