-- Ce fichier permet de créer le fichier permettant de recréer les séquences
-- à la valeur qu'elles doivent avoir en fonction de la clé primaire de la table
-- à laquelle chacune correspond.
--
-- Ce script peut être utile lorsqu'on fait un import des données seules des tables
-- alors que ces dernières sont déjà créées.
--
-- Modif JPB le 02/04/04 : ajout de &Path au nom du fichier spool
-- Modif JFL le 21/11/06 : change &Path par &1 afin de passer le path en paramètre.

-- sélection des noms de séquence

-- Création d'une table temporaire

CREATE SEQUENCE seq_alarmcoul start with 10;

drop table SYS_CHAMP_AUTO;

CREATE TABLE "SYS_CHAMP_AUTO" 
(	"TABLE_NAME" NVARCHAR2(25) NOT NULL ENABLE, 
	"CHAMP_NAME" NVARCHAR2(25) NOT NULL ENABLE, 
	"TG_NAME" NVARCHAR2(30) NOT NULL ENABLE, 
	"SQ_NAME" NVARCHAR2(30) NOT NULL ENABLE, 
	 CONSTRAINT "PK_SYS_CHAMP_AUTO" PRIMARY KEY ("TABLE_NAME", "CHAMP_NAME", "SQ_NAME", "TG_NAME") ENABLE
) ;

drop table unusedseq;

create table unusedseq
(
 unusedseq_name VARCHAR2 (40)
);


-- Modif. X.L. le 08/09/09 afin d'ajouter le nom du trigger pour la table EQUIP_MSK
DECLARE
	colname VARCHAR2(50);
	tablename VARCHAR2(30);
	seqname VARCHAR2(50);
	seekOrder VARCHAR2(100);
	seekCol VARCHAR2(100);

	seqval NUMBER;
	lineid NUMBER;
	TrigName VARCHAR2 (40);

	cSeek	INTEGER;
	res	INTEGER;
	IsCol	INTEGER;

	CURSOR c1 IS
		SELECT object_name FROM user_objects
		WHERE object_type = 'TABLE'
		AND object_name != 'ACCES_ACCESC2'
		AND object_name != 'PARAM_ALRMEC'
		AND object_name != 'PARAMALRMEC_EMAIL'
		ORDER BY OBJECT_NAME;
-- vs SEQUENCE

begin
	cSeek := dbms_sql.open_cursor;
	lineid := 0;

	FOR rc1 IN c1 LOOP
		seqname := 'SEQ_'|| rc1.object_name;
--		colname := substr (rc1.object_name, 5) || '_ID';
colname := rc1.object_name||'_ID';

 dbms_output.put_line ('colonne : ' || colname);
--		tablename := substr (rc1.object_name, 5);
tablename := rc1.object_name;

		SELECT count(*) into IsCol FROM user_tab_columns
		    WHERE table_name = tablename
		    AND column_name = colname;

		IF (IsCol = 1) THEN
			seekOrder := 'SELECT nvl (max (' || colname || '), 1) seqval  FROM ' || tablename;
 dbms_output.put_line ('ordre : ' || seekOrder);

			dbms_sql.parse (cSeek, seekOrder, dbms_sql.NATIVE);
			dbms_sql.define_column (cSeek, 1, seqval);
			res := dbms_sql.execute (cSeek);

			IF (dbms_sql.FETCH_ROWS (cSeek) > 0) THEN
				dbms_sql.column_value (cSeek, 1, seqval);
			ELSE
				seqval := 0;
			END IF;
			seqval := seqval + 1;
 dbms_output.put_line ('A');

			IF tablename = 'EQUIP_MSK' THEN
				TrigName := 'TIB_EQUIP_MSK';
			ELSE
				TrigName := ' ';
			END IF;
			insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
				values (tablename, colname, seqname, TrigName);

		ELSE
			insert into unusedseq (unusedseq_name) values (seqname);
		END IF;
	END LOOP;
	dbms_sql.close_cursor (cSeek);

	--
	-- Init. des tables ne respectant pas la règle de nommage
	--
 dbms_output.put_line ('B');
	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('PROG_OPER', 'NODE_ID', 'SEQ_PROG_OPER', ' ');


	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('ACCES_ACCESC2', 'ACCES_ACCESC2_AUTO_ID', 'SEQ_ACCES_ACCESC2', ' ');

	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('EQUIP_MSK_SRC', 'EQMSSR_ID', 'EQUIP_MSK_SRCSB', 'EQUIP_MSK_SRCTB');

	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('PARAM_ALRMEC', 'PARAM_ALRMEC_ID', 'PARAM_ALRMECSB', 'PARAM_ALRMECTB');

	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('PARAMALRMEC_EMAIL', 'PARAMALRMEC_EMAIL_ID', 'PARAMALRMEC_EMAILSB', 'PARAMALRMEC_EMAILTB');

	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('PROG_USEDCABL_SRC', 'PRUSCASRC_ID', 'PROG_USEDCABL_SRCSB', 'PROG_USEDCABL_SRCTB');

	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('PROG_USEDDIAG', 'PRUSDIAG_ID', 'PROG_USEDDIAGSB', 'PROG_USEDDIAGTB');

	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('PROG_USEDLIAI_SRC', 'PRUSLISRC_ID', 'PROG_USEDLIAI_SRCSB', 'PROG_USEDLIAI_SRCTB');

	insert into sys_champ_auto (table_name, champ_name, sq_name, tg_name)
		values ('PROG_USEDSITES_SRC', 'PRUSSRC_ID', 'PROG_USEDSITES_SRCSB', 'PROG_USEDSITES_SRCTB');


	commit;
exception
	WHEN OTHERS THEN
		dbms_output.put_line ('Erreur exécution script');

		IF dbms_sql.is_open (cSeek) THEN
			dbms_sql.close_cursor (cSeek);
		END IF;
		ROLLBACK;

		RAISE;
end;
/

