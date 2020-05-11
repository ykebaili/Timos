drop FUNCTION SetWrkfEvtId;
drop FUNCTION SetWrkfEvt;
drop FUNCTION GetWrkfHistoState;
drop FUNCTION GetWrkfHistoEvt;
drop PROCEDURE UpdateHistoWorkFlow;
drop FUNCTION VerfTrans;
drop trigger ti_valeurs;
drop trigger tu_valeurs;
drop trigger ti_dessin;
drop trigger tu_dessin;
drop trigger ti_fiche;
drop trigger tu_fiche;
drop PROCEDURE ReinitVideo;
drop PROCEDURE mess_video;
drop FUNCTION IsNullOrExistFieldN;
drop FUNCTION IsNullOrExistField;
drop FUNCTION IsNullOrValidField;
drop FUNCTION IsNullOrValidContentN;
drop FUNCTION IsNullOrValidContent;
drop FUNCTION IsNullOrSupprOrExistList;
drop FUNCTION IsNullOrExistList;
drop FUNCTION GetOngletIdx;
drop trigger tib_critop;
drop trigger TU_LICENCE;
drop trigger TD_LICENCE;
drop trigger ti_bitmess;
drop trigger tu_bitmess;
drop trigger td_bitmess;
drop TRIGGER tub_bitmess2;
drop trigger tdb_liaivpivci;
drop trigger ti_liaivpivci;
drop trigger tdb_liaivpi;
drop trigger ti_liaivpi;
drop trigger ti_binddoc;
-- drop TRIGGER td_binddoc;		inutile pour une mise a jour depuis version 2.4.13
drop trigger tib_verrou;
drop trigger td_fabric;
drop trigger td_userl;
drop trigger td_role;
drop trigger ti_contact;
drop trigger tu_contact;
drop trigger tiub_ordretop;
drop PROCEDURE InitRef; 
drop trigger tiub_Valeurs_Saisie;
drop trigger tub_reglette;

drop PROCEDURE CMS_EltGere;
drop trigger tu_progsite;
drop trigger ti_progsite;
drop trigger td_progsite;
drop trigger tu_progliai;
drop trigger td_progliai;
drop trigger td_binddoc;
drop trigger tdb_accesreser;
drop trigger ti_accesreser;
-- drop PROCEDURE DelArchSiteZN;	inutile pour une mise a jour depuis version 2.4.13
drop trigger tib_suptes_temp;
drop trigger td_prog_service;
drop trigger ti_prog_service;
drop TRIGGER tdb_liaireser;
drop TRIGGER ti_liaireser;

drop trigger tib_prog_liaitemp;
drop trigger td_cablequ;
drop trigger tdb_top_liai;
drop trigger tu_ext;
drop trigger tu_liai;
drop trigger tub_cablequ;
drop trigger tu_cablequ;
drop trigger ti_top_liai;
drop trigger td_top_site;
drop trigger ti_progliai;
drop trigger tdb_progliai;
-- drop Procedure ModifProgTop;		inutile pour une mise a jour depuis version 2.4.13
-- drop PROCEDURE UpdateLiaiBP;		inutile pour une mise a jour depuis version 2.4.13
drop trigger tub_prog;
drop trigger tub_liai;
-- drop Procedure ModifTopLiai;		inutile pour une mise a jour depuis version 2.4.13
-- drop function FIND_ACCESACCESCID; (fait dans MAJ2414-2415.sql mais l'etait mal au prealable)
drop Procedure MajDebitLiai;
drop function ECoupe;
drop function EMin;
drop function EWarn;

drop TRIGGER ti_acces;
drop TRIGGER tdb_acces;
drop TRIGGER tub_acces_accesc;


