DECLARE
    CURSOR CAlarm1 IS
        SELECT * FROM alarm WHERE alarm_iddeb IS NOT NULL;

    CURSOR CAlarm2 (AlarmIdDeb ALARM.ALARM_ID%TYPE) IS
	SELECT * FROM alarm WHERE alarm_id = AlarmIdDeb;

BEGIN
    FOR rCAlarm1 IN CAlarm1 LOOP
	FOR rCAlarm2 IN CAlarm2 (rCAlarm1.alarm_iddeb) LOOP
	    UPDATE alarmdata SET
	    	alarmdata_datefin = to_date (rCAlarm.alarm_date, 'YYYY MM DD HH24:MI:SS'),
            	alarmdata_secfin = rCAlarm1.alarm_sec,
            WHERE alarmdata_iddeb = rCAlarm1.alarm_iddeb;
	    EXIT;
	END LOOP;
    END LOOP;
END;