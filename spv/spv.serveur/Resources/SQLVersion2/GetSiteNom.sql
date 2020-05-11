create or replace
FUNCTION GetSiteNom(SiteId NUMBER)
return VARCHAR2 is

-- Cette fonction retourne le nom du site

	SiteNom SITE.SITE_NOM%TYPE;

BEGIN
	select SITE_NOM into SiteNom from SITE where SITE_ID = SiteId;
	
	return SiteNom;
EXCEPTION
    when NO_DATA_FOUND then
	return ('INEX');

    when OTHERS then
	return ('ERROR');	
END GetSiteNom;