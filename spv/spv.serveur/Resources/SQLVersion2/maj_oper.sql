create or replace
PROCEDURE maj_oper (Id NUMBER, SiteId NUMBER, EquipId NUMBER,
    LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, AlarmCommut NUMBER,
    ProgNb IN OUT NUMBER,
    EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
    EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
    EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
    TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
	/* Cette proc�dure met � jour l'�tat op�rationnel de l'�l�ment g�r� en d�faut,
	   ainsi que l'�tat op�rationnel des CABLEQU et des programmes que cela concerne */

IS
	-- Id est l'identifiant du nouveau message d'alarme (d�but ou fin).
BEGIN

--    	insert into test values (SEQ_TEST.NEXTVAL, 'maj_oper : SiteId = '||SiteId ||
 --     ' EquipId = '|| EquipId || ' LiaiId = ' || LiaiId);

    delete alarm_prog where alarm_id= Id;

    if (SiteId is not NULL) then
	     MajOperSite (Id, SiteId, AlarmLocal, AlarmGrave, ProgNb, 
					  EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
					  TsPrOper, Debord);
    elsif (EquipId is not NULL) then
	     MajOperEquip (Id, EquipId, AlarmLocal, AlarmGrave, AlarmCommut, ProgNb, 
					   EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom,
					   TsPrOper, Debord);
    elsif (LiaiId is not NULL) then
	     EltSiteId := -1;
	     MajOperLiai (Id, LiaiId, AlarmLocal, AlarmGrave, ProgNb, EltTypeId, EltTypeNom,
					  EltId, EltNom, TsPrOper, Debord);
    end if;

END maj_oper;
