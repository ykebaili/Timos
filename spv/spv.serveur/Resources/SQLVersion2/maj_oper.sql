create or replace
PROCEDURE maj_oper (Id NUMBER, SiteId NUMBER, EquipId NUMBER,
    LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, AlarmCommut NUMBER,
    ProgNb IN OUT NUMBER,
    EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
    EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
    EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
    TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
	/* Cette procédure met à jour l'état opérationnel de l'élément géré en défaut,
	   ainsi que l'état opérationnel des CABLEQU et des programmes que cela concerne */

IS
	-- Id est l'identifiant du nouveau message d'alarme (début ou fin).
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
