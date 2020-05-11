/*
	CREATION DE USER_REPLIC ET DE LA TABLE JOURNAL. Création JFL le 02/04/2004.

	MAJ JFL le 25/06/2004 => pack_dbatrigger = prise en compte du format des champs dates (YYYY MM DD HH24:MI:SS)
	MAJ JFL le 29/06/2004 => pack_dbatrigger = ajout de la colonne journal_transaction
	MAJ JFL le 18/12/2006 => Ajout des GRANT et des Synonymes pour les utilisateurs SPV.
*/

PROMPT 'Vérifiez que le répertoire C:\Temp existe'
PROMPT '(pour fichiers InstallRep*.log et fic. temporaires)'
PROMPT 'Sinon, créez le.'
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

spool c:\temp\InstallRep1.log

ACCEPT Path     CHAR PROMPT 'Saisissez le chemin d''accès aux scripts SQL : '
ACCEPT ServName CHAR PROMPT 'Saisissez le service de connexion à la BDD : '
DEFINE InstTot  = 'N'

ACCEPT PwdSystem  CHAR PROMPT 'Saisissez le mot de passe de l''utilisateur "SYSTEM" : ' HIDE
ACCEPT PwdSys     CHAR PROMPT 'Saisissez le mot de passe de l''utilisateur "SYS" : ' HIDE

-- Se connecter en utilisateur SYSTEM.
PROMPT 'Se loger SYSTEM'
connect system/&PwdSystem@&ServName

-- Suppression et creation de USER_REPLIC.
ACCEPT PwdReplic  CHAR PROMPT 'Saisissez le mot de passe de USER_REPLIC : ' HIDE
ACCEPT sptbl 	  CHAR PROMPT 'Saisissez le tablespace pour l''utilisateur user_replic (ex: superv_tbl) : '
ACCEPT sptmp 	  CHAR PROMPT 'Saisissez le tablespace temporaire (ex: superv_tmp) : '

drop user user_replic cascade;

create user user_replic identified by &PwdReplic
default tablespace &sptbl temporary tablespace &sptmp
quota UNLIMITED on &sptbl;

-- Droits de USER_REPLIC.
grant CREATE TABLE    to user_replic;
grant CREATE SESSION  to user_replic;
grant CREATE SEQUENCE to user_replic;


-- Se connecter en USER_REPLIC.
PROMPT 'Se loge en USER_REPLIC'
connect user_replic/&PwdReplic@&ServName

-- Script de la table journal.
create table journal
(
	journal_id 	number 		primary key,
	journal_session varchar2(20),			-- n° de session unique
	journal_sql 	long,				-- ordre sql
	journal_flag 	number(1),			-- si =1 clear(diffuseur c++)
	journal_owner 	varchar2(30)			-- owner de la table maj par ordre sql
);

alter table USER_REPLIC.JOURNAL add (JOURNAL_DATE   date, JOURNAL_ACKSRV varchar2 (400));
alter table USER_REPLIC.JOURNAL add (JOURNAL_TRANSACTION VARCHAR2(40));

-- Sequence de la table journal
create sequence seq_journal;


-- Information utilisateur normal.
ACCEPT NomSpv     CHAR PROMPT 'Saisissez le nom du propriétaire de la BDD SPV : '
ACCEPT PwdSpv     CHAR PROMPT 'Saisissez le mot de passe du propriétaire de la BDD SPV : ' HIDE
--ACCEPT NomRW      CHAR PROMPT 'Saisissez le nom de l''utilisateur du programme SPV (USER_RW) : '
--ACCEPT RoleRW     CHAR PROMPT 'Saisissez le nom du rôle de cet utilisateur : '
--ACCEPT NomRO      CHAR PROMPT 'Saisissez le nom des consultants de la BDD (USER_RO) : '
--ACCEPT RoleRO     CHAR PROMPT 'Saisissez le nom du rôle de cet utilisateur : '
--ACCEPT NomScript  CHAR PROMPT 'Saisissez le nom de l''utilisateur de rapports et scripts (USER_SCRIPT) : '
--ACCEPT RoleScript CHAR PROMPT 'Saisissez le nom du rôle de cet utilisateur : '

-- On donne les droits d'écriture sur la table JOURNAL de USER_REPLIC.
grant INSERT, UPDATE, DELETE, SELECT on user_replic.journal to &NomSpv;
--grant INSERT, UPDATE, DELETE, SELECT on user_replic.journal to &NomRW;
--grant INSERT, SELECT on user_replic.journal to &NomScript;
--grant SELECT on user_replic.journal to &NomRO;

grant SELECT on user_replic.seq_journal to &NomSpv;
--grant SELECT on user_replic.seq_journal to &NomRW;
--grant SELECT on user_replic.seq_journal to &NomRO;
--grant SELECT on user_replic.seq_journal to &NomScript;


-- Se connecter en Propriétaire SPV.
PROMPT 'Redevenir propriétaire SPV'
connect &NomSpv/&PwdSpv@&ServName


spool off;
/
