define Tablespace=spv_ind;

ACCEPT Path     CHAR PROMPT 'Saisissez le chemin d''acces aux scripts SQL : '
define Path=T:\Tibco\Timos\Timos\spv\SQL;

spool c:\temp\maj1320_1.log

PROMPT 'Appel du fichier de mise à jour MAJ2413-2414.sql'
start &Path\MAJ2413-2414.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2414-2415.sql'
start &Path\MAJ2414-2415.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2415-2416.sql'
start &Path\MAJ2415-2416.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2416-2416b.sql'
start &Path\MAJ2416-2416b.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2416b-2416c.sql'
start &Path\MAJ2416b-2416c.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2416c-24173.sql'
start &Path\MAJ2416c-24173.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ24173-24175.sql'
start &Path\MAJ24173-24175.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ24175-2418.sql'
start &Path\MAJ24175-2418.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2418-2418SNMP.sql'
start &Path\MAJ2418-2418SNMP.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2418-2419.sql'
start &Path\MAJ2418-2419.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2419-2420.sql'
start &Path\MAJ2419-2420.sql &Tablespace;

PROMPT 'Appel du fichier de mise à jour MAJ2420-2500.sql'
start &Path\MAJ2420-2500.sql &Tablespace;

spool off
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

spool c:\temp\maj1320_2.log

PROMPT 'Appel du fichier PurgePrStock.sql'
start &Path\PurgePrStock.sql &Tablespace;
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

PROMPT 'Appel du fichier PurgeSuitbase2.sql'
start &Path\PurgeSuitbase2.sql &Tablespace;
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

PROMPT 'Appel du fichier PurgePostPrStock.sql'
start &Path\PurgePostPrStock.sql &Tablespace;
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

PROMPT 'Appel du fichier PurgeTables.sql'
start &Path\PurgeTables.sql &Tablespace;
spool off
PROMPT 'Frappez "Entrée" pour continuer'
PAUSE

spool c:\temp\maj1320_3.log
PROMPT 'Appel du fichier PrStock.sql'
start &Path\PrStock.sql &Tablespace;

PROMPT 'Appel du fichier Suitbas2.sql'
start &Path\Suitbas2.sql &Tablespace;

PROMPT 'Appel du fichier InsertSequenceInSysChampAuto.sql'
start &Path\InsertSequenceInSysChampAuto.sql
commit;

spool off
