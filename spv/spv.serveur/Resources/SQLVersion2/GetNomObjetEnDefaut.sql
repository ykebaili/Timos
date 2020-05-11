create or replace
FUNCTION GetNomObjetEnDefaut(EquipId NUMBER, LiaiId NUMBER, SiteId NUMBER)
return VARCHAR2 is

-- Cette fonction retourne le nom de l'objet en alarme

	strNom VARCHAR2(200);
	nClasse NUMBER;
BEGIN
	strNom := '';
	nClasse := GetClasseObjetEnDefaut(EquipId, LiaiId, SiteId);
	if (nClasse = 0) then	-- equipement
		strNom := GetEquipNom (EquipId, 1);
	elsif (nClasse = 1) then -- liaison
		strNom := GetLiaiNom (LiaiId);
	elsif (nClasse = 2) then -- site
		strNom := GetSiteNom (SiteId);
	end if;
	
	return strNom;
END GetNomObjetEnDefaut;