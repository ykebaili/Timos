create or replace
FUNCTION GetTableObjetEnDefaut(EquipId NUMBER, LiaiId NUMBER, SiteId NUMBER)
return VARCHAR2 is
	nRet VARCHAR2(40);
BEGIN
	nRet := '';
	if EquipId is not null then
		nRet := 'EQUIP';
	elsif LiaiId is not null then
		nRet := 'LIAI';
	elsif SiteId is not null then
		nRet := 'SITE';
	end if;
	return nRet;
END GetTableObjetEnDefaut;
