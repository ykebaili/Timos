create or replace
FUNCTION AlarmNature (Id NUMBER)
RETURN NUMBER
	/* Cette fonction retourne :
	- 0 si l'alarme est autonome,
	- 1 si c'est une alarme mère,
	- 2 si c'est une alarme fille. */
-- Modif. X.L. le 08/01/2010 ALARM_ALARMC est remplacée
-- par ALARMDATA_CORREL. L'ID passé en paramètre est
-- maintenant l'ID de l'alarme dans ALARMDATA et non plus
-- l'ID de l'événement alarme dans ALARM.
IS
    CURSOR c1 is
	select * from ALARMDATA_CORREL
	    where ALARMDATA_ID = Id
	    for update of ALARMDATA_ID;

    CURSOR c2 is
	select * from ALARMDATA_CORREL
	    where ALARMDATA_BINDINGID = Id
	    for update of ALARMDATA_ID;

BEGIN
    for c in c1 loop
	return 2;	/* alarme fille */
    end loop;

    for c in c2 loop
	return 1;	/* alarme mère */
    end loop;

    return 0;		/* alarme autonome */

END AlarmNature;
