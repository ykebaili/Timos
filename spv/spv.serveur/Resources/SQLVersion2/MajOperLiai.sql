create or replace
PROCEDURE MajOperLiai
		(Id NUMBER, LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
		 ProgNb IN OUT NUMBER, EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
		 EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
		 TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)

	/* Cette procédure met à jour l'état opérationnel de la liaison en défaut

	Id	   : Id de l'alarme
	LiaiId	   : Id de la liaison traitée
	AlarmGrave : gravité alarme	*/

IS

    OperElt	NUMBER;		/* Etat opérationnel de la liaison en cause */

    Grave	NUMBER;		/* Gravité des alarmes restantes */
 --   GraveS	NUMBER;		/* Gravité banale (BitMess etc..) */

    SiteId	NUMBER;		/* Id du site contenant l'équipement en défaut */
    SiteIndex	NUMBER;		/* Index de ce site */

    ModCalc	NUMBER;		/* Mode de calcul (standard ou NEC) */

/*  CURSOR CurProg is			-- les programmes concernés par cette liaison en alarme
	select distinct PROG.PROG_ID, GRAVE
	    from PROG_usedliais, SUPTES_TEMP, PROG
	    where ALARM_ID = Id and
		  PROG_usedliais.LIAI_ID = SUPTES_TEMP.LIAI_ID and
		  PROG_usedliais.PROG_ID = PROG.PROG_ID and
		  PROG_LIAIBOUND is NULL;*/

		  CURSOR CurProg is			-- les programmes concernés par cette liaison en alarme
	select PROG_ID from PROG_usedliais  where Liai_id=LiaiId;

/*	CURSOR CurTop is			-- les topologies concernées par cette liaison en alarme
  select TOP_ID, GRAVE
	    from top_LIAI, SUPTES_TEMP
	    where ALARM_ID = Id and
		  top_LIAI.LIAI_ID = SUPTES_TEMP.LIAI_ID ;*/


BEGIN
--  insert into test values (SEQ_TEST.NEXTVAL, 'MAJOPERLIAI : LiaiId '||to_char(LiaiId));

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

    -- Mise à jour de Poseq et Typeq
    -- Modif. GG le 22/07/03
    -- Modif. JPB le 01/11/03. Voir remarque V 1.087
    EltId := LiaiId;
    EltNom := GetLiaiNom (LiaiId);
    select TYPLIAI_ID, TYPLIAI_NOM
	   into EltTypeId, EltTypeNom 	from LIAI
	   where LIAI_ID = LiaiId;
    -- Mise à jour de l'état opérationnel de la liaison

    select MAX (ALARMGEREE_GRAVE) into Grave from ACCES_ACCESC_REP
	     where LIAI_ID = LiaiId and ALARM_ID <> Id;
		-- Valeur de la gravité à prendre en compte en début d'alarme
 		-- on regarde les autres alarmes
    Grave := NVL (Grave, 0);

  /*  select MAX (ALARMGEREE_GRAVE) into GraveS from BITMESS, BITMESS_REP
	   where BITMESS_REP.LIAI_ID = LiaiId and
	      BITMESS_REP.ALARM_ID <> Id and
	      BITMESS.BITMESS_ID = BITMESS_REP.BITMESS_ID;
		-- Valeur de la gravité à prendre en compte en début d'alarme
 		-- on regarde les autres alarmes
    GraveS := NVL (GraveS, 0); */

   -- Grave := Max3 (Grave, GraveS, AlarmGrave);	-- cas d'une panne des équips. de multiplexage
   Grave := Max2 (Grave, AlarmGrave);	-- cas d'une panne des équips. de multiplexage

    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    -- Prendre en compte l'état opérationnel des supports

    OperElt := Max2 (OperElt, OperSupport (LiaiId, OperElt));

    update LIAI_REP
	     set LIAI_OPER = OperElt	where LIAI_ID = LiaiId;

    -- Mise à jour de l'état opérationnel des supportés

--    insert into SUPTES_TEMP (ALARM_ID, LIAI_ID, GRAVE) values (Id, LiaiId, Grave);

    MajOperSupte (Id, LiaiId, OperElt, AlarmLocal);

    -- Mise à jour de l'état opérationnel de tous les programmes qui utilisent cette liaison
    -- (ou l'un de ses supportés) dans le site où elle aboutit

-- ZN. l'etat operationelle des cablages n'est pas changé, inutille de calculer PROG_CABL_REP.prog_oper_grave

 /*       select SITE_DESTID into SiteId
	   from LIAI	where LIAI_ID = LiaiId;

  select SITE_OPER into OperElt
	       from SITE_REP where SITE_ID = SiteId;
	  OperElt := NVL (OperElt, 0);

  for vProg in CurProg loop
	    UpdateProgOperProg(vProg.Prog_Id, SiteId, Id, OperElt);
    end loop;	*/


  /*  for vTop in CurTop loop
	    UpdateProgOperTop(vTop.TOP_ID, SiteId, Id, OperElt);
    end loop;	*/

    ProgNb   := 0;
--    TsPrOper := '';  -- 70 prog. au max. Structure : NbProg; ProgId, OldOper, ProgOper, ProgMsk;
--			ProgId, OldOper, ProgOper, ProgMsk; etc...
--    Debord   := 0;

    for vProg in CurProg loop
      MajAlarmProg(Id, vProg.PROG_ID);
    	TsPrOperProg(vProg.PROG_ID, ModCalc, /* OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affectés par cette erreur

 --   TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

/*    for vTop in CurTop loop
      TsPrOperTopLiai(vTop.top_id, SiteId, ModCalc, OperElt, TsPrOper, Debord);
    end loop;*/

 --   delete SUPTES_TEMP where ALARM_ID = Id;
END MajOperLiai;
