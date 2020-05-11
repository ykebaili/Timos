DECLARE
	nClasse NUMBER;
    EquipId NUMBER;
    LiaiId NUMBER;
    SiteId NUMBER;
    EltSiteId NUMBER;
    EltId NUMBER;
    EltTypeId NUMBER;
    CliConc1 ALARM3.ALARM3_CLICONC%TYPE;
    PrConc1 ALARM3.ALARM3_PRCONC%TYPE;
    CliConc2 ALARM3.ALARM3_CLICONC%TYPE;
    PrConc2 ALARM3.ALARM3_PRCONC%TYPE;
    PrEtat ALARM3.ALARM3_PRETAT%TYPE;
    nPos NUMBER;
    EltNom VARCHAR2(40);
    
    CURSOR CAlarm3 IS
        SELECT * FROM alarm3;

    CURSOR CAlarme (AlarmId NUMBER) IS
	SELECT alarmdata.equip_id, alarmdata.liai_id, alarmdata.site_id
	    FROM alarm, alarmdata
	    WHERE alarm_id = AlarmId
	    AND alarmdata.alarmdata_id = alarm.alarmdata_id;
	    
	CURSOR CSite IS
		SELECT typsite_id FROM site WHERE site_id = SiteId;
		
	CURSOR CSite2 (SiteNom VARCHAR2) IS
		SELECT site_id FROM site WHERE site_nom = SiteNom;
		
	CURSOR CEquip IS
		SELECT site_id, typeq_id FROM equip WHERE equip_id = EquipId;
		
	CURSOR CType (TypeqNom VARCHAR2) IS
		SELECT typeq_id FROM typeq WHERE typeq_nom = TypeqNom;
		
	CURSOR CLiai IS
		SELECT typliai_id FROM liai WHERE liai_id = LiaiId;
		
	CURSOR CClient (ClientNom VARCHAR2) IS
		SELECT client_id FROM client WHERE client_nom = ClientNom;
		
	CURSOR CProg (ProgNom VARCHAR2) IS
		SELECT prog_id FROM prog WHERE prog_nom = ProgNom;

BEGIN
    FOR rCAlarm3 IN CAlarm3 LOOP
		-- Détermination de la classe de l'objet en alarme
		EquipId := NULL;
		LiaiId := NULL;
		SiteId := NULL;
		FOR rCAlarme IN CAlarme (rCAlarm3.ALARM3_ID) LOOP
			EquipId := rCAlarme.EQUIP_ID;
			LiaiId := rCAlarme.LIAI_ID;
			SiteId := rCAlarme.SITE_ID;
			EXIT;
		END LOOP;
		nClasse := GetClasseObjetEnDefaut(EquipId, LiaiId, SiteId);
	
		-- Détermination des ID liés à l'élément en défaut (élément lui-meme, site, type)
		EltSiteId := NULL;
		EltTypeId := NULL;
		IF nClasse = 0 THEN -- equipement en défaut
			EltId := EquipId;
			IF EltId is not null THEN
				FOR rCEquip IN CEquip LOOP
					EltSiteId := rCEquip.site_id;
					EltTypeId := rCEquip.typeq_id;
					EXIT;
				END LOOP;
			ELSE			-- on essaye de site et type par le nom
				FOR rCType IN CType (rCAlarm3.ALARM3_TYPEQ) LOOP
					EltTypeId := rCType.TYPEQ_ID;
				END LOOP;
			END IF;
		ELSIF nClasse = 1 THEN	-- liaison en defaut
			EltId := LiaiId;
			FOR rCLiai IN CLiai LOOP
				EltTypeId := rCLiai.typliai_id;
				EXIT;
			END LOOP;
		ELSIF nCLasse = 2 THEN -- site en defaut
			EltId := SiteId;
			EltSiteId := SiteId;
			FOR rCSite IN CSite LOOP
				EltTypeId := rCSite.typsite_id;
				EXIT;
			END LOOP;
		END IF;
		
        IF EltSiteId IS NULL THEN
            FOR rCSite2 IN CSite2 (rCAlarm3.ALARM3_SITENOM) LOOP
                EltSiteId := rCSite2.SITE_ID;
				EXIT;
            END LOOP;
        END IF;
		-- Transformation des chaînes de concernés de la forme nom;nom;etc
		-- en ;id;id;etc;
		CliConc1 := rCAlarm3.alarm3_cliconc;
		CliConc2 := '';
		IF LENGTH (CliConc1) > 0 THEN
			WHILE TRUE LOOP
				nPos := INSTR (CliConc1, ';');
				IF nPos > 0 THEN
					EltNom := SUBSTR (CliConc1, 1, nPos -1);
				ELSE
					EltNom := CliConc1;
				END IF;
				IF EltNom IS NOT NULL AND LENGTH(EltNom) > 0 THEN
					FOR rCLient IN CCLient (EltNom) LOOP
						CliConc2 := CliConc2 || ';' || rClient.client_id;
						EXIT;
					END LOOP;
				END IF;
				CliConc1 := SUBSTR (CliConc1, nPos + 1);
				IF (CliConc1 IS NULL OR LENGTH (CliConc1) = 0) THEN
					EXIT;
				END IF;
			END LOOP;
		END IF;
		IF LENGTH (CliCOnc2) > 0 THEN
			CliConc2 := CliConc2 || ';';
		END IF;
		
		PrConc1 := rCAlarm3.alarm3_prconc;
		PrConc2 := '';
		IF LENGTH (PrConc1) > 0 THEN
			WHILE TRUE LOOP
				nPos := INSTR (PrConc1, ';');
				IF nPos > 0 THEN
					EltNom := SUBSTR (PrConc1, 1, nPos -1);
				ELSE
					EltNom := PrConc1;
				END IF;
				IF EltNom IS NOT NULL AND LENGTH(EltNom) > 0 THEN
					FOR rCProg IN CProg (EltNom) LOOP
						PrConc2 := PrConc2 || ';' || rCProg.prog_id;
						EXIT;
					END LOOP;
				END IF;
				PrConc1 := SUBSTR (PrConc1, nPos + 1);
				IF (PrConc1 IS NULL OR LENGTH (PrConc1) = 0) THEN
					EXIT;
				END IF;
			END LOOP;
		END IF;
		IF LENGTH (PrCOnc2) > 0 THEN
			PrConc2 := PrConc2 || ';';
		END IF;
		
		PrEtat := NULL;
		IF rCAlarm3.ALARM3_PRETAT IS NOT NULL THEN
			PrEtat := ';' || rCAlarm3.ALARM3_PRETAT;
		END IF;
			
		UPDATE alarm3 
			SET alarm3_eltclasse = nClasse,
				alarm3_prconc = PrConc2,
				alarm3_cliconc = CliConc2,
				alarm3_eltsiteid = EltSiteId,
				alarm3_eltid = EltId,
				alarm3_elttypeid = EltTypeId,
				alarm3_pretat = PrEtat
			WHERE alarm3_id = rCAlarm3.alarm3_id;
    END LOOP;
END;