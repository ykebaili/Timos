ACCEPT Tablespace CHAR PROMPT 'Saisissez le nom du tablespace index : '

-- define Tablespace=spv_ind;

-- ACCEPT Path     CHAR PROMPT 'Saisissez le chemin d''acces aux scripts SQL : '
-- define Path=T:\Tibco\Timos\Timos\spv\SQL;

spool c:\temp\maj16c20_1.log

PROMPT 'Appel du fichier de mise à jour MAJ2416c-24173.sql'
@@MAJ2416c-24173.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ24173-24175.sql'
@@MAJ24173-24175.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ24175-2418.sql'
@@MAJ24175-2418.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2418-2418SNMP.sql'
@@MAJ2418-2418SNMP.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2418-2419.sql'
@@MAJ2418-2419.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2419-2420.sql'
@@MAJ2419-2420.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2420-2500.sql'
@@MAJ2420-2500.sql &Tablespace;

spool off
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

spool c:\temp\maj16c20_2.log

PROMPT 'Appel du fichier PurgePrStock.sql'
@@PurgePrStock.sql &Tablespace;
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

PROMPT 'Appel du fichier PurgeSuitbase2.sql'
@@PurgeSuitbase2.sql &Tablespace;
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

PROMPT 'Appel du fichier PurgePostPrStock.sql'
@@PurgePostPrStock.sql &Tablespace;
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

PROMPT 'Appel du fichier PurgeTables.sql'
@@PurgeTables.sql &Tablespace;
spool off
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

spool c:\temp\maj16c20_3.log
PROMPT 'Appel du fichier PrStock.sql'
@@PrStock.sql &Tablespace;

PROMPT 'Appel du fichier Suitbas2.sql'
@@Suitbas2.sql &Tablespace;

PROMPT 'Appel du fichier InsertSequenceInSysChampAuto.sql'
@@InsertSequenceInSysChampAuto.sql
commit;

spool off
