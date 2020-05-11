DECLARE
	CURSOR CAccesAccescRep IS
		SELECT * FROM acces_accesc_rep
		    WHERE alarm_id IS NOT NULL;

	CURSOR CAlarmData (AlarmId NUMBER) IS
		SELECT alarmdata_id FROM alarm
		    WHERE alarm_id = AlarmId;

BEGIN
	FOR rCAccesAccescRep IN CAccesAccescRep LOOP
		FOR rCAlarmData IN CAlarmData (rCAccesAccescRep.alarm_id) LOOP
			UPDATE acces_accesc_rep 
			    SET alarmdata_id = rCAlarmData.alarmdata_id
			    WHERE acces_accesc_id = rCAccesAccescRep.acces_accesc_id;
			EXIT;
		END LOOP;
	END LOOP;
END;
			