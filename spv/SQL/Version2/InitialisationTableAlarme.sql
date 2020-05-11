DECLARE
    nAck    NUMBER;
    nMaskOpe  NUMBER;
    nMaskAdm  NUMBER;
    nGrave  NUMBER;
    strAlarmNom ALARMDATA.ALARMGEREE_NOM%TYPE;
    nType   NUMBER;
    AlarmDate DATE;
    DateAcquit DATE;
    SecDebut NUMBER;

    CURSOR CAlarm IS
        SELECT * FROM alarm WHERE alarm_iddeb IS NULL order by alarm_id;

BEGIN
    FOR rCAlarm IN CAlarm LOOP
        nAck := 0;
        IF (length (rCAlarm.alarm_date) < 19) THEN
            SELECT to_date(substr (rCAlarm.alarm_date, 1, 8) ||
			'0' || substr (rCAlarm.alarm_date, 9), 'YYYY MM DD HH24:MI:SS') INTO AlarmDate FROM dual;
            SELECT co_sec1998 (substr (rCAlarm.alarm_date, 1, 8) || 
			'0' || substr (rCAlarm.alarm_date, 9)) INTO SecDebut FROM dual;
        ELSE
            SELECT to_date(rCAlarm.alarm_date, 'YYYY MM DD HH24:MI:SS') INTO AlarmDate FROM dual;
            SecDebut := rCAlarm.alarm_sec;

        END IF;
        SELECT to_date(rCAlarm.alarm_acquitwhen, 'DD/MM/YYYY HH24:MI:SS') INTO DateAcquit FROM dual;

        IF (rCAlarm.alarm_aquittee > 0) THEN
            nAck := 1;
        END IF;

        IF (rCAlarm.alarm_grave = 1) THEN
            nMaskOpe := 1;
        ELSIF (rCAlarm.alarm_grave = 2) THEN
            nMaskAdm := 1;
        ELSE
            nMaskOpe := 0;
            nMaskAdm := 0;
        END IF;

        IF (rCAlarm.alarm_grave < 3) THEN
            SELECT alarmgeree_grave INTO nGrave
            FROM alarmgeree
            WHERE alarmgeree_id = rCAlarm.alarmgeree_id;
        ELSE
            nGrave := rCAlarm.alarm_grave;
        END IF;

        IF (rCAlarm.alarm_nom IS NULL) THEN
            SELECT alarmgeree_nom INTO strAlarmNom
            FROM alarmgeree
            WHERE alarmgeree_id = rCAlarm.alarmgeree_id;
        ELSE
            strAlarmNom := rCAlarm.alarm_nom;
        END IF;

        IF (rCAlarm.alarm_type IS NULL) THEN
            SELECT alarmgeree_typal INTO nType
            FROM alarmgeree
            WHERE alarmgeree_id = rCAlarm.alarmgeree_id;
        ELSE
            nType := rCAlarm.alarm_type;
        END IF;

        INSERT INTO alarmdata (
            alarmdata_id, alarmdata_ackwhen, alarmdata_ackwho,
            alarmdata_ack, alarmdata_comment, alarmdata_datedebut,
            alarmdata_mask_ope, alarmdata_mask_adm,
            alarmdata_iana, alarmdata_secdebut,
            alarmdata_vseuil, alarmgeree_grave, alarmgeree_local,
            alarmgeree_nom, alarmgeree_nseuil, alarmgeree_typal,
            acces_accesc_id, equip_id, liai_id, site_id)
        VALUES (
            seq_alarmdata.nextval, DateAcquit,
            rCAlarm.alarm_acquitwho, nAck, rCAlarm.alarm_comment,
            AlarmDate,
            nMaskOpe, nMaskAdm, rCAlarm.alarm_iana, SecDebut,
            rCAlarm.alarm_vseuil, nGrave, rCAlarm.alarm_local,
            strAlarmNom, rCAlarm.alarm_nseuil, nType,
            rCAlarm.cablagep_id,
            rCAlarm.equip_id, rCAlarm.liai_id, rCAlarm.site_id);

	update ALARM set alarmdata_ID = seq_alarmdata.currval,
			 EVENEMENT_TYPE = 1
	where ALARM_ID = rCAlarm.alarm_id;
    END LOOP;
END;