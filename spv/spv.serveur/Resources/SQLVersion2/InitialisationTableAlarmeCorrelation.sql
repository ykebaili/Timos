DECLARE
	CURSOR CAlarm_Alarmc IS
		SELECT * FROM alarm_alarmc;

	CURSOR CAlarmData1 (AlarmId1 NUMBER) IS
		SELECT alarmdata_id
		    FROM alarm
		    WHERE alarm_id = AlarmId1;

	CURSOR CAlarmData2 (AlarmId2 NUMBER) IS
		SELECT alarmdata_id
		    FROM alarm
		    WHERE alarm_id = AlarmId2;
BEGIN
	DELETE alarmdata_correl;
	FOR rCAlarm_Alarmc IN CAlarm_Alarmc LOOP
		FOR rCAlarmData1 IN CAlarmData1 (rCAlarm_Alarmc.alarm_id) LOOP
			FOR rCAlarmData2 IN CAlarmData2 (rCAlarm_Alarmc.alarm_bindingid) LOOP
				INSERT INTO alarmdata_correl VALUES (rCAlarmData1.alarmdata_id, rCAlarmData2.alarmdata_id);
				EXIT;
			END LOOP;
			EXIT;
		END LOOP;
	END LOOP;
END;	
