create or replace
PROCEDURE MajOperSite
		(Id NUMBER, SiteId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
		 ProgNb IN OUT NUMBER,
		 EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
		 EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
		 EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
		 TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
	/* Cette proc�dure met � jour l'�tat op�rationnel du site en d�faut,
	   ainsi que l'�tat op�rationnel des programmes que cela concerne
	AlarmGrave : gravit� alarme */
IS
    OperElt	NUMBER;		/* Etat op�rationnel du site en cause */
    Grave	NUMBER;		/* Gravit� des alarmes restantes */
    GraveS	NUMBER;		/* Gravit� restante pour des alarmes SEM */

    Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associ� au programme
   ModCalc	NUMBER;


	CURSOR CurProg is
	  select distinct Prog_id from PROG_usedsites  where SITE_ID = SiteId;


BEGIN
    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

    -- Mise � jour de SiteNom et Poseq
    --select SITE_NOM, SITE_NOM into SiteNom, Poseq
	--       from SITE where SITE_ID = SiteId;
    EltId := SiteId;
    EltSiteId := SiteId;
    select SITE.TYPSITE_ID, TYPSITE_NOM, SITE_NOM 
		into EltTypeId, EltTypeNom, EltNom
		from TYPSITE, SITE 
		where SITE_ID = SiteId and TYPSITE.TYPSITE_ID = SITE.TYPSITE_ID;
    
    -- Mise � jour de l'�tat op�rationnel du site

    select MAX (ALARMGEREE_GRAVE) into Grave from ACCES_ACCESC_REP
	     where SITE_ID = SiteId and  ALARM_ID <> Id;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
	        -- on regarde les autres alarmes
    Grave := NVL (Grave, 0);
		-- Retomb�e d'alarme, cas o� il n'y a pas d'autre alarme pour ce site
		-- (SITE_ID est NULL)

 /*   select MAX (ALARMGEREE_GRAVE) into GraveS from BITMESS, BITMESS_REP
  	where BITMESS_REP.SITE_ID = SiteId and
	      BITMESS_REP.ALARM_ID <> Id and
	      BITMESS.BITMESS_ID = BITMESS_REP.BITMESS_ID;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
		-- on regarde les autres alarmes
    GraveS := NVL (GraveS, 0); */
		-- Retomb�e d'alarme, cas o� il n'y a pas d'autre alarme pour ce site
		-- (SITE_ID est NULL)

    --Grave := Max3 (Grave, GraveS, AlarmGrave);
    Grave := Max2 (Grave, AlarmGrave);

    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    update SITE_REP
	     set SITE_OPER = OperElt	where SITE_ID = SiteId;
    -- Mise � jour de l'�tat op�rationnel de tous les programmes qui utilisent ce site

  --  for vProg in CurProgOper loop
  for vProg in CurProg loop
      UpdateProgOperProg(vProg.PROG_ID, SiteId, Id, OperElt);
	 end loop;

 /*   for vTop in CurTop loop
      UpdateProgOperTop(vTop.top_id, SiteId, Id, OperElt);
    end loop;*/

    ProgNb   := 0;

    -- 70 prog. au max. Structure : ProgId, OldOper, ProgOper, ProgMsk; ProgId,
    -- OldOper, ProgOper, ProgMsk; etc...

    for vProg in CurProg loop --tous les programmes utilisant ce SiteId
       TsPrOperProg(vProg.PROG_ID, ModCalc,/* OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affect�s par cette erreur

 /*   for vTop in CurTop loop
  --  insert into test values(seq_test.nextval, 'MajOperSite top_id ' || vTop.top_id);
      TsPrOperTop(vTop.top_id, ModCalc, OperElt, TsPrOper, Debord);
    end loop;*/

--    TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

END MajOperSite;
