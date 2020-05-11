--==============================================================================
--                          MAJ2415-2416.sql
--==============================================================================


create table top_cablequ_rep -- comme prog_cablequ_rep
(
	top_id 		number default(0) not null,
	cablequ_id   	number not null,
	grave		number(1) default(0)  not null,
        constraint ck_top_cablequ_rep_grave check (grave in (0,1,2,3)),
    	constraint pk_top_cablequ_rep primary key (top_id, cablequ_id) using index tablespace &1
);

alter table top_cablequ_rep 
    add constraint fk1_top_cablequ_rep foreign key (Top_id) references Top (Top_id);
alter table top_cablequ_rep
    add constraint fk2_top_cablequ_rep foreign key (cablequ_id) references cablequ (cablequ_id);


declare

  CURSOR cTopCabl IS
		SELECT top_id, cablequ_id FROM top_cablequ;

begin
	for vTopCabl in cTopCabl loop
		insert into TOP_CABLEQU_REP (top_id, cablequ_id, grave)
		values (vTopCabl.top_id, vTopCabl.cablequ_id, 0);
	end loop;
 
end;
/

------------------------------programes concernés par l'alarm----------

create table alarm_prog
(
	alarm_id number not null,
	prog_id number not null,
constraint pk_alarm_prog primary key (alarm_id, prog_id) using index tablespace &1
);

alter table alarm_prog
    add constraint fk1_alarm_prog foreign key (alarm_id) references alarm (alarm_id);
alter table alarm_prog
    add constraint fk2_alarm_prog foreign key (prog_id) references prog (prog_id);

-----------------------------un oubli-------------------------

alter table equip_msk 
    add constraint fk3_equip_msk foreign key (cablequ_id) references cablequ (cablequ_id);
    
    

------------------precharger des topologies
  
alter table top add (Precharger  NUMBER(1) DEFAULT(0) NOT NULL );
alter table top add constraint ck_top check (Precharger in (0, 1));


-----------------Ajouter les tables nécessaires au dictionnaire de réplication
-- Cet ajout ne doit se faire que lorsque l'environnement de réplication est présent
-- d'où le recours au SQL dynamique

declare
	PresenceTable	NUMBER;
        v_query VARCHAR2 (1000);
        v_maj   VARCHAR2 (1000);
        TYPE cur_typ IS REF CURSOR;
        c_cursor cur_typ;
begin
	select count(*)  into PresenceTable from USER_TABLES where TABLE_NAME = 'DBADICT';

	if PresenceTable > 0 then
		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''PROG_TOP''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''PROG_TOP'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''TOP_LIAITEMPU''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''TOP_LIAITEMPU'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''TTOP''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''TTOP'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''TOP_DOMAIN''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''TOP_DOMAIN'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''PROG_ACTIV''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''PROG_ACTIV'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''LIAI_TOPSRC_TOPDST''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''LIAI_TOPSRC_TOPDST'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''TOP_TOP''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''TOP_TOP'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''PARAM_HISTO''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''PARAM_HISTO'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;

		v_query := 'select count(*) from dbadict where DBADICT_TABLENAME = ''USERP''';
                OPEN c_cursor FOR v_query;
                FETCH c_cursor INTO PresenceTable;
                CLOSE c_cursor;
		
		if PresenceTable = 0 then
                        v_maj := 'insert into dbadict values (seq_dbadict.nextval, ''USERP'', ''OUI'')';
                        EXECUTE IMMEDIATE v_maj;
                end if;
	end if;

	commit;
end;
/


--=======================================================================================--
-- FIN MAJ
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.16');

commit;
