alter table site drop column VAL_ID;
alter table CLIENT drop column VAL_ID;                        
alter table EQUIP drop column VAL_ID;                         
alter table ALARMGEREE  drop column VAL_ID;                   
alter table ARCH  drop column VAL_ID;                         
alter table FAMILLE  drop column VAL_ID;                      
alter table ACCES drop column VAL_ID;                         
alter table LIAI drop column VAL_ID;                          
alter table MODELEQUIP drop column VAL_ID;                    
alter table MODELLIAI drop column VAL_ID;                     
alter table MODELPROG drop column VAL_ID;                     
alter table MODELSITE drop column VAL_ID;                     
alter table ORDRE  drop column VAL_ID;                        
alter table PERIF drop column VAL_ID;                         
alter table PROG drop column VAL_ID;                          
alter table SCRIPT drop column VAL_ID;                        
alter table TOP drop column VAL_ID;                          
alter table TYPEQ drop column VAL_ID;                         
alter table TYPLIAI drop column VAL_ID; 

alter table ALARMGEREE drop column FICHE_ID;                  
alter table CONSFICHE  drop column FICHE_ID;                        
alter table TYPEQ  drop column FICHE_ID;                            
alter table SITE  drop column FICHE_ID;                             
alter table PROG  drop column FICHE_ID;                             
alter table PERIF  drop column FICHE_ID;                            
alter table MODELSITE  drop column FICHE_ID;                        
alter table MODELPROG  drop column FICHE_ID;                        
alter table CLIENT drop column FICHE_ID;                            
alter table FAMILLE  drop column FICHE_ID;                          
alter table TOP  drop column FICHE_ID;                              
alter table TYPSITE  drop column FICHE_ID;                          
alter table ORDRE drop column FICHE_ID;                            
alter table TYPPROG  drop column FICHE_ID;                          
alter table TYPLIAI drop column FICHE_ID;  
alter table fiche drop constraint FK1_FICHE; 
alter table fiche drop constraint FK2_FICHE; 
alter table fiche drop constraint FK3_FICHE;
alter table fiche drop constraint FK4_FICHE; 
alter table fiche drop constraint FK5_FICHE; 
alter table fiche drop constraint FK6_FICHE; 
alter table fiche drop constraint FK7_FICHE; 
alter table fiche drop constraint FK8_FICHE;
alter table fiche drop constraint FK9_FICHE; 
alter table fiche drop constraint FK10_FICHE; 
alter table fiche drop constraint FK11_FICHE; 
alter table fiche drop constraint FK12_FICHE;
alter table fiche drop constraint FK13_FICHE; 
alter table fiche drop constraint FK15_FICHE; 
alter table fiche drop constraint FK16_FICHE; 
alter table fiche drop constraint FK17_FICHE; 
alter table fiche drop constraint FK18_FICHE;
alter table valeurs drop constraint FK1_VALEURS; 
alter table valeurs drop constraint FK2_VALEURS;
alter table valeurs drop constraint FK3_VALEURS; 
alter table valeurs drop constraint FK4_VALEURS; 
alter table valeurs drop constraint FK5_VALEURS;
alter table valeurs drop constraint FK6_VALEURS;
alter table valeurs drop constraint FK7_VALEURS; 
alter table valeurs drop constraint FK8_VALEURS; 
alter table valeurs drop constraint FK9_VALEURS;
alter table valeurs drop constraint FK10_VALEURS;
alter table valeurs drop constraint FK11_VALEURS;
alter table valeurs drop constraint FK12_VALEURS; 
alter table valeurs drop constraint FK13_VALEURS; 
alter table valeurs drop constraint FK14_VALEURS; 
alter table valeurs drop constraint FK15_VALEURS; 
alter table valeurs drop constraint FK16_VALEURS; 
alter table valeurs drop constraint FK17_VALEURS; 
alter table valeurs drop constraint FK18_VALEURS; 
alter table valeurs drop constraint FK19_VALEURS; 
alter table valeurs drop constraint FK21_VALEURS;
alter table valeurs drop constraint FK22_VALEURS;
alter table valeurs drop constraint FK23_VALEURS; 
alter table valeurs drop constraint FK24_VALEURS;



drop table ACCES_ACCESG;
drop table ACCES_ACCESV;
drop table ACCES_BITMESS;
drop table ACCES_MESS;
drop table ACCESRESER;
drop table ELTSAT;
alter table BINDDOC drop constraint FK3_BINDDOC;
alter table BOUTON drop constraint FK1_BOUTON;
alter table DESSIN drop constraint FK15_DESSIN;
alter table VERROU drop constraint FK8_VERROU;
drop table AFFBOUTON;
drop table ALARMG_ALARMG;

alter table DESSIN drop constraint FK30_DESSIN;
alter table PROG_ARCH drop constraint FK1_PROG_ARCH;
alter table SITE_ARCH drop constraint FK1_SITE_ARCH;
drop table ARCHCONTACT;
drop table ARCH_DOMAIN;
drop table ARCHSITE;
drop table ARCH;

drop table BINDDOC;
drop table BITMESS_REP;
drop table BITMESS2;

drop table BOUTON_PROG;
drop table BOUTON_SITE;


drop table CONSFICHECHAMPS;
drop table CONSFICHEWHERE;
drop table CONSULTAL;
drop table CONTACT;

drop table CONTROLDIST;
drop table CRITOP;
drop table CTRLLISTDYN;


drop table DISCRI_ALARM;

drop table EQUIP_DOMAIN;
drop table EQUIP_FABRIC2;
drop table EQUIP_FNCT;
drop table EQUIP_LIAI;
drop table ERRIMP;
drop table EXCHANGE;



drop table HISTO;
drop table JCXION;
drop table LIAI_DOMAIN;
drop table LIAI_LIAIP;
drop table LIAIRESER;
drop table LIAIVPI;
drop table LIAIVPIVCI;
drop table LIAIVPIVCI2;
drop table LIAIVPI2;
drop table LIBELLE;

drop table LINK;
drop table MAILALRM;

drop table MESSMESS;

drop table MODELPROG_LIAI;
drop table MODELPROG_MODELLIAI;
drop table MODELPROG_MODELSITE;
drop table MODELPROG_SITE;
drop table MODELLIAI_MODELLIAI;

alter table ACCES drop constraint FK4_ACCES;
alter table MODELEQUIP drop constraint FK3_MODELEQUIP;
alter table WRKFHISTOETAT drop constraint FK6_WRKFHISTOETAT;
drop table MODELEQUIP;

alter table ACCES drop constraint FK8_ACCES;
alter table DESSIN drop constraint FK14_DESSIN;
alter table EXT drop constraint FK2_EXT;
alter table WRKFHISTOETAT drop constraint FK9_WRKFHISTOETAT;
drop table MODELLIAI;

alter table DESSIN drop constraint FK5_DESSIN;
alter table PROG drop constraint FK5_PROG;
alter table WRKFHISTOETAT drop constraint FK11_WRKFHISTOETAT;
drop table MODELPROG;

alter table ACCES drop constraint FK1_ACCES;
alter table DESSIN drop constraint FK1_DESSIN;
alter table SITE drop constraint FK1_SITE;
alter table WRKFHISTOETAT drop constraint FK3_WRKFHISTOETAT;
drop table MODELSITE;

drop table NEXTVCI;
drop table NEXTVPI;

drop table ORDRETOPCRI;
drop table ORDRETOPEQUIP;
drop table ORDRETOPLIAI;

alter table DESSIN drop constraint FK19_DESSIN;
-- alter table BINDDOC drop constraint FK17_BINDDOC;		table supprimée au préalable
alter table VERROU drop constraint FK14_VERROU;
alter table WRKFHISTOETAT drop constraint FK14_WRKFHISTOETAT;
drop table PERIF;

drop table PREMAILDATA;
drop table PREMAIL;

drop table PRERAPPORT;

alter table ONGLET drop constraint FK3_ONGLET;
drop table PRIV;

drop table PROFILE;
drop table PROG_ARCH;
drop table PROG_BINDDOC;
drop table PROG_CABL_TMP;
drop table PROG_DOMAIN;
drop table PROG_SERVICE;
drop table REGLETTE_ACCES;
drop table ROLE_DOMAIN;
drop table ROLE_USER;

drop table SITE_ARCH;
drop table SITE_DOMAIN;
drop table SITE_EQUIP2;
drop table SITE_SITE;
drop table SNMP2TYPEQ;

drop table SUPTES_TEMP;
drop table TEMP_VPIVCI;
drop table TEMPTABLE;
drop table TOP_DOMAIN;
drop table TPROG;
drop table TTOP;

drop table TYPLIAI_TYPLIAI;
drop table USERP;
drop table VERROU;
drop table XCONNECT;

-- drop VIEW ACCES_VUE;				inutile pour une mise a jour depuis version 2.4.13

drop table WRKFEVTETAT;
drop table WRKFHISTOEVT;
drop table WRKFTRANS_WRKFEVT;
drop table WRKFTRANS;
drop table WRKFEVT;
drop table WRKFHISTOETAT;
drop table CODESAISIE;
drop table SAISIE;

alter table onglet drop constraint FK2_ONGLET;
drop table DESSIN;
drop table CONTROL;
drop table ONGLET;
drop table BOUTON;


alter table alarm drop column bitmess_id;
drop table BITMESS;
drop table CONSFICHE;
drop table DISCRI;
drop table DOMAIN;
drop table typeq_fnct;
drop table fnct;
drop table LIBSYMB;
alter table acces drop column mess_id;
alter table equip drop column mess_id;
alter table equip drop column mes_mess_id;
drop table MESS;
alter table cablequ drop column modelcabl_id;
alter table acces drop column MODELEQUIP_id;
alter table acces drop column MODELLIAI_id;
drop table MODELCABL;
alter table ext drop column MODELLIAI_id;
alter table acces drop column MODELSITE_id;
-- drop table MODELSITE;				table supprimée au préalable
alter table prog drop column prog_modelprogid;
drop table ORDRETOP;
alter table cablequ drop column ordre_id;
drop table ORDRE;
alter table alarm drop column RACKHAM_ID;
drop table rackham;
drop table reglette;
drop table repart;
drop table role;
drop table SQLREQ;
drop table userl;
drop table prog_liaitempu;
drop table top_liaitempu;
drop table prog_liaitemp;
drop table top_top;
drop table top_site;
drop table top_liai;
drop table TOP_CABLEQU_REP;
drop table TOP_CABLEQU;
drop table LIAI_TOPSRC_TOPDST;
drop table prog_top;
alter table prog_cablequ drop column top_id;
drop table top;
drop table VALEURS;
drop table FICHE;
drop table PROG_CABLEQU;
drop table CABLEQU_CABLEQUL;
drop table PROG_SITE;
drop table PROG_LIAI;
drop view DIFFALARMCABL;
drop view ISPRESENTE;
drop view TYPEQLISTE;
drop view V_FAMILLE;
drop view V_FAMILLE2;
drop view V1004_01;
drop view V1018_01A;
drop view EQUIPUSEMESS;
alter table EQUIP_MSK drop column PROG_ID;
alter table EQUIP_MSK drop column SITE_ID;
alter table EQUIP_MSK drop column CABLEQU_ID;
-- Mises à jour après installation OPT
-- Debut le 22/09/09
