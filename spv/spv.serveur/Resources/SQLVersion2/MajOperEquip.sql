create or replace
PROCEDURE MajOperEquip
	(Id NUMBER, EquipId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, AlarmCommut NUMBER,
	 ProgNb IN OUT NUMBER,
	 EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2,
	 EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
	 EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
	 TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
IS
	/* Cette procédure met à jour l'état opérationnel de l'équipement en défaut,
	   ainsi que l'état opérationnel des CABLEQU et des programmes que cela concerne.
	Tient compte des "sous-équipements" (ie. équipements inclus).
	Un "sous-équipement" n'est pas utilisé directement (on met un équipement dans un câblage).
	Un équipement peut être en panne parce que un de ses sous-équipements est en panne.
	FAUX - FAUX - FAUX !!!
	On met à jour l'état opérationnel des équipements qui contiennent celui-ci (OperEnglob).

	Lorsqu'un équipement est en panne, il faut donc mettre à jour immédiatement
	l'état opérationnel des équipements qui le concernent.
	AlarmGrave : gravité alarme */

    OperElt	NUMBER;		-- Etat opérationnel de l'élt. géré en cause
    Grave	NUMBER;		-- Gravité des alarmes restantes
    BindingId	NUMBER;		-- Id de l'englobant de EquipId. 0 si fini
    Buf		VARCHAR2 (100); -- banal
    ModCalc	NUMBER;		-- Mode de calcul standard ou NEC

BEGIN
--  lock table PROG_OPER in exclusive mode;

  	--insert into test values (SEQ_TEST.NEXTVAL, 'MajOperEquip : EquipId = '||EquipId ||
   -- ' AlarmCommut = ' || AlarmCommut);

    ModCalc := GetModCalc;

    -- Mise à jour de EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom
    -- Modif. JPB le 01/11/03. Voir remarque V 1.087
    select SITE.SITE_ID, SITE.SITE_NOM, TYPEQ_ID, TYPEQ_NOM, EquipId, GetEquipNom (EquipId, 1)
      	into EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom
      	from EQUIP, SITE
      	where EQUIP_ID = EquipId and
      	      EQUIP.SITE_ID  = SITE.SITE_ID;

    -- Mise à jour de l'état opérationnel de l'équipement et des programmes qui l'utilisent
    if (AlarmCommut = 1) then
/*
        update EQUIP
	    set EQUIP_COMMUT = AlarmGrave	-- Position d'un commutateur
	    where EQUIP_ID   = EquipId;
*/
    	ProgNb   := 0;
    --	TsPrOper := '';
    --	Debord   := 0;
    	Grave    := MajOperInclus (Id, EquipId, AlarmGrave, AlarmLocal, ProgNb, TsPrOper, Debord);
    --	TsPrOper := to_char (ProgNb) || ';' || TsPrOper;
    	return;

    else
    	ProgNb   := 0;
    --	TsPrOper := '';
    --   	Debord   := 0;
    	Grave    := MajOperInclus (Id, EquipId, AlarmGrave, AlarmLocal, ProgNb, TsPrOper, Debord);

   --   insert into test values (SEQ_TEST.NEXTVAL, 'MajOperEquip : TsPrOper = '||TsPrOper ||
   --           ' Grave =  ' || Grave);

    end if;

    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    update EQUIP_REP
	     set EQUIP_OPER = OperElt 	where EQUIP_ID = EquipId;

  -- Mise à jour de l'état opérationnel des équipements qui contiennent celui-ci
  -- Un seul niveau, car l'appel est récursif

    select PARAM_VALEUR into Buf from PARAM
       where PARAM_VALEUR like 'ALARM_ENGLOB%';

    if (INSTR (Buf, 'true') > 0) then	-- il faut tenir compte des englobants / englobés
       BindingId := 0;


       select EQUIP_BINDINGID into BindingId
         from EQUIP  where EQUIP_ID = EquipId;

       BindingId := NVL (BindingId, 0);

    	if (BindingId > 0) then
    	    OperEnglob (Grave, BindingId, AlarmLocal, ProgNb, TsPrOper, Debord);
    	end if;
   end if;

--    TsPrOper := to_char (ProgNb) || ';' || TsPrOper;
END MajOperEquip;
