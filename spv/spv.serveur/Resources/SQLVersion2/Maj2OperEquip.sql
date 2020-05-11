create or replace
PROCEDURE Maj2OperEquip(EquipId NUMBER, CablequId NUMBER)
IS
	/* Cette procédure met à jour l'état opérationnel du CABLEQU et des programmes
	que cela concerne, lorsqu'on supprime ou qu'on ajoute un équipement dans un câblage */

    Id 		NUMBER;		/* Id de l'alarme en cours */
    AlarmLocal	NUMBER;		/* Données de l'alarme en cours */
    AlarmGrave	NUMBER;
    AlarmCommut	NUMBER;
    ProgId	NUMBER;		/* Id du programme traité */
    ProgNb	NUMBER;
    EltTypeId   NUMBER;
    EltTypeNom	VARCHAR2 (40);
    EltId       NUMBER;
    EltNom	VARCHAR2 (80);
    TsPrOper	VARCHAR2 (900);

    OperElt	NUMBER;		/* Etat opérationnel de l'élt. géré en cause */

    SiteId	NUMBER;		/* Id du site contenant l'équipement en défaut */

    OperSite	NUMBER;		/* Etat opér. de ce site */
    OperLiai	NUMBER;		/* Max. état opér. des liaisons du programme dans ce site */

    OperProg	NUMBER;		/* Etat opérationnel du programme :
					0 : tout va bien
					1 : erreurs mineures rencontrées
					2 : perte de la redondance
					3 : non fonctionnel */
    OldOperProg NUMBER;		/* ancien état opérationnel du programme */
    ProgMsk	NUMBER;		/* Etat de masquage du programme :
					0 : non masqué
					1 : masquage brigadier
					2 : masquage administrateur */

    ErrWarn	BOOLEAN;	/* TRUE si une erreur existe */
    ErrMin	BOOLEAN;	/* TRUE si une erreur mineure existe */
    ErrMaj	BOOLEAN;	/* TRUE si une erreur majeure existe */
    ErrTs	BOOLEAN;	/* TRUE si tous les chemins sont coupés entre un des noeuds
				origine et un noeud destination */

    Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associé au programme

    ModCalc	NUMBER;		/* Mode de calcul standard ou NEC */

    LProgNb	NUMBER;		/* Nb. de programmes correspondant à des liaisons en panne
				(mpx) */
    LPrOper	VARCHAR2 (450); /* Etat opérationnel de ces liaisons */

    Debord 	NUMBER;		/* 1 si débordement, 0 sinon */

    CURSOR CurProg1 (Idl NUMBER) is
	select distinct prog_id, site_id from PROG_CABL
	where CABLEQU_ID = Idl;

    CURSOR CurProg2 (Prog NUMBER) is	-- les sites d'entrée d'un programme
	select * from PROG_OPER
	where PROG_ID  = Prog and
	      SITE_NUM = 1;

    CURSOR CurLiai (Idl NUMBER) is
	select * from LIAI_CABLEQU
	where CABLEQU_ID = Idl;

    CURSOR CurAl is
	select B.ALARM_ID from ACCES_ACCESC A, ACCES_ACCESC_REP B
	    where A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID and
		  (B.EQUIP_ID = EquipId or A.ACCES_BINDINGID = EquipId);

BEGIN

-- 	  insert into test values (SEQ_TEST.NEXTVAL, 'Maj2OperEquip : EquipId = '||EquipId);

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

    select EQUIP_OPER into OperElt
    	from EQUIP_REP
    	where EQUIP_ID = EquipId;

    if (OperElt = 0) then
	     return;		/* pas d'alarme en cours, il n'y a rien à faire */
    end if;

--    lock table PROG_OPER in exclusive mode;

    -- Mise à jour de l'état opérationnel de tous les programmes qui utilisent cet équipement

    select max (EQUIP_OPER) into OperElt	-- max. Oper pour les équipements du CABLEQU
    	from EQUIP_REP, CABLEQU_EQUIP
    	where	CABLEQU_EQUIP.CABLEQU_ID = CablequId and
		  CABLEQU_EQUIP.EQUIP_ID = EQUIP_REP.EQUIP_ID; --  OperElt : état opérationnel

    OperElt := NVL (OperElt, 0);
-- insert into test values (SEQ_TEST.NEXTVAL, 'OperElt ' || to_char (OperElt));

    update PROG_CABL_REP
    	set PROG_CABL_GRAVE = OperElt
    	where CABLEQU_ID = CablequId;

    for vProg in CurProg1 (CablequId) loop	/* tous les PROG_CABL tq CABLEQU_ID = Id */
    	SiteId := vProg.SITE_ID;
    	ProgId := vProg.PROG_ID;

    	 select max (PROG_CABL_GRAVE) into OperElt
    	    from PROG_CABL_REP
    	    where PROG_ID = ProgId and  SITE_ID = SiteId;

      -- max. Oper pour les CABLEQU de ce prog. dans ce site
	     OperElt := NVL (OperElt, 0);

	     select SITE_OPER into OperSite
	     from SITE_REP  where SITE_ID = SiteId;

       OperSite := NVL (OperSite, 0);

	   OperElt := Max2 (OperElt, OperSite);
-- insert into test values (SEQ_TEST.NEXTVAL, 'Prog ' || to_char (vProg.PROG_ID) ||
-- ' OperElt ' || to_char (OperElt));

	   update PROG_OPER_REP
	      set PROG_OPER_GRAVE = OperElt
	      where PROG_ID = ProgId and SITE_ID = SiteId;

	-- OperElt est le max. de l'état opér. des CABLEQU, pour ts. les PROG qui
	-- utilisent cet équip.
	-- Ceci tient compte aussi des alarmes de site.
	-- Les alarmes de liaisons inter-sites seront prises en compte dans le
	-- traitement suivant, qui considère aussi les redondances éventuelles.
    end loop;

	-- 70 prog. au max. Structure : NbProg; ProgId, OldOper, ProgOper, ProgMsk; ProgId,
	-- OldOper, ProgOper, ProgMsk; etc...

    ProgNb   := 0;
    Debord   := 0;
    TsPrOper := '';

    for vProg in CurProg1 (CablequId) loop	/* tous les programmes tq CABLEQU_ID = Id */
      OperElt := 0;
/*    	ErrWarn := FALSE;
    	ErrMin := FALSE;
    	ErrMaj := FALSE;
    	ErrTs  := FALSE;


    	select PROG_ROUTAGE into Routage
    	    from PROG
    	    where PROG_ID = vProg.PROG_ID;

    	if (Routage is NULL) then		-- Pas de routage
    	    for vProg2 in CurProg2 (vProg.PROG_ID) loop
    		-- boucle sur tous les sites d'entrée du programme
    	    	ErrWarn := ErrWarn or EWarn   (vProg2.NODE_ID);
    	    	ErrMin  := ErrMin  or EMin    (vProg2.NODE_ID, ModCalc);
    	    	ErrMaj  := ErrMaj  or ECoupe  (vProg2.NODE_ID);
    	    	ErrTs   := ErrTs   or TsCoupe (vProg2.NODE_ID);

	       end loop;	-- boucle sur les sites d'entrée du programme

	     else
	       -- en cas de routage, on ne calcule pas la connexité (celle-ci dépend du routage)
	       select max (PROG_OPER_GRAVE) into OperElt
		        from PROG_OPER_REP
	    	    where PROG_ID = vProg.PROG_ID;
	     end if;		-- si pas de routage

	     if (ModCalc = 0) then	-- Cas standard SPV
    	    if (ErrTs     or OperElt >= 3) then
    	    	OperProg := 3;
    	    elsif (ErrMaj or OperElt = 2) then
    	    	OperProg := 2;
    	    elsif (ErrMin or OperElt = 1) then
    	    	OperProg := 1;
    	    else
    	    	OperProg := 0;
    	    end if;

	     else			-- Cas NEC
    	    if (ErrMaj     or OperElt >= 3) then
    	    	OperProg := 3;
    	    elsif (ErrMin  or OperElt = 2) then
    	    	OperProg := 2;
    	    elsif (ErrWarn or OperElt = 1) then
    	    	OperProg := 1;
    	    else
    	    	OperProg := 0;
    	    end if;
	     end if;
--	insert into test values (SEQ_TEST.NEXTVAL, 'MAJOPERINCLUS : OperProg '||to_char(vProg.PROG_ID)||'; '||to_char(OperProg));

	     select B.PROG_OPER, PROG_MASQUE
	       into OldOperprog, ProgMsk
	       from PROG A, PROG_REP B
	       where A.PROG_ID = vProg.PROG_ID and
		      A.PROG_ID = B.PROG_ID;

       update PROG_REP
	       set PROG_OPER = OperProg
	       where PROG_ID = vProg.PROG_ID;

	     if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    ProgNb := ProgNb +1;
	       TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (OldOperProg) ||
		    	',' || to_char (OperProg) || ',' || to_char (ProgMsk) || ';';
	     elsif (length (TsPrOper) > 800) then
	       Debord := 1;
	     end if;
*/
        TsPrOperProg(vProg.PROG_ID, ModCalc,/* OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affectés par cette erreur
-- insert into test values (SEQ_TEST.NEXTVAL, 'TsPrOper ' || TsPrOper);

    for vAl in CurAl loop
	     LProgNb := 0;
	     LPrOper := '';

	     for vLiai in CurLiai (CablequId) loop 	-- cas des équipements de multiplexage ( * from LIAI_CABLEQU)
  	    MajOperLiai (vAl.ALARM_ID, vLiai.LIAI_ID, AlarmLocal, AlarmGrave, LProgNb,
  		         EltTypeId, EltTypeNom, EltId, EltNom, LPrOper, Debord);
  --	    ProgNb  := ProgNb + LProgNb;
  	    LPrOper := SUBSTR (LPrOper, INSTR (LPrOper, ';') +1);

  	    if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
  		      TsPrOper := TsPrOper || LPrOper;
  	    else
  		      Debord := 1;
  	    end if;
       end loop;

--   	TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

	     update ALARM2
	       set ALARM2_TSPROPER = TsPrOper
	       where ALARM2_ID = vAl.ALARM_ID;
    end loop;

END Maj2OperEquip;
