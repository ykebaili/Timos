create or replace
TRIGGER tdb_alarm BEFORE DELETE ON alarm FOR EACH ROW
BEGIN

  delete trapalarm where alarm_id= :old.alarm_id;

	/* Si le trigger est déclenché par suite d'un enregistrement créé par réplication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

END tdb_alarm;
