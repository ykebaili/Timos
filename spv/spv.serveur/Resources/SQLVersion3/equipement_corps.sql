create or replace
PACKAGE BODY equipement AS

    --===============================================================================
    -- Retourne la gravité d'alarme maximum existant sur un équipement
    FUNCTION get_grave_max(p_id equip.equip_id%TYPE) RETURN NUMBER IS
	
        l_grave ACCES_ACCESC_REP.ALARMGEREE_GRAVE%TYPE;
    BEGIN
        RETURN lien_acces_alarme.get_grave_max(p_id, spv_types.c_type_equip);
    END get_grave_max;
    --===============================================================================
	
        
    --===============================================================================
    -- Met à jour le coefficient opérationnel de l'équipement et de ses dépendances
    PROCEDURE set_coeff_oper (p_equip_id EQUIP.EQUIP_ID%TYPE, 
                              p_coeff diagramme.etat_oper_t,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)
    IS
    BEGIN
        update EQUIP_REP
            set EQUIP_COEFF_OP = p_coeff
            where EQUIP_ID = p_equip_id;
            
        -- Mise à jour du coefficient opérationnel de tous éléments de graphes qui exploitent
        -- cet équipement
        diagramme.set_coeff_oper_ts_graph(p_equip_id, NULL, NULL, p_coeff, infos_diag_table);
        
        -- Idem pour toutes les liaisons inter-équipements qui exploitent cet équipement
        liaison.set_coeff_oper_ts_liai(p_equip_id, p_coeff, infos_diag_table);
    END set_coeff_oper;
    --===============================================================================
	


    --===============================================================================
    FUNCTION get_oper (p_equip_id equip.equip_id%TYPE) 
    RETURN diagramme.etat_oper_t IS
    
        l_coeff diagramme.etat_oper_t;
    BEGIN
        SELECT equip_coeff_op INTO l_coeff FROM equip_rep WHERE equip_id = p_equip_id;
        RETURN l_coeff;
    END get_oper;
    --===============================================================================
    
    
    
    --===============================================================================
    -- Renvoie l'ID de l'équipement père d'ordre immédiatement supérieur
    FUNCTION get_id_pere(p_id equip.equip_id%TYPE) RETURN NUMBER IS
        l_binding_id EQUIP.EQUIP_BINDINGID%TYPE;
    BEGIN
        select EQUIP_BINDINGID into l_binding_id
            from EQUIP  where EQUIP_ID = p_id;

        return l_binding_id;
    END get_id_pere;
    --===============================================================================
	
        
    --===============================================================================
    -- Calcul de coefficient opérationnel d'un équipement en tenant compte
    -- des équipements inclus, ce d'une manière récursive
    FUNCTION maj_oper_inclus (Id NUMBER, EquipId NUMBER, AlarmGrave NUMBER, AlarmLocal NUMBER,
                              infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) 
    RETURN NUMBER
    IS
        /* Cette fonction met à jour l'état opérationnel de l'équipement
            en tenant compte des équipements inclus dans l'équip. en défaut.
            Elle met aussi à jour l'état opérationnel des graphes que cela concerne.
            Retourne la gravité correspondante.

            Id          : Id de l'alarme
            EquipId     : Id de l'équipement traité
            AlarmGrave  : gravité alarme
            ProgNb      : nb. programmes concernés par cette alarme
            TsPrOper    : chaîne décrivant l'état opérationnel de ces programmes */

            -- Coefficient opérationnel de l'élt. géré en cause
        CoeffOperElt	diagramme.etat_oper_t;
        Grave	alarme_geree.gravite_t;		-- Gravité des alarmes restantes
        GraveI	alarme_geree.gravite_t;		-- Max de la gravité des alarmes des équipements inclus

        SiteId	SITE.SITE_ID%TYPE;		-- Id du site de l'équipement en défaut
        -- Etat opér. de ce site
        CoeffOperSite	diagramme.etat_oper_t;
		
        /*   OperProg	NUMBER;		-- Etat opérationnel du programme :
              --		0 : tout va bien
              --		1 : erreurs mineures rencontrées
              --		2 : perte de la redondance
              --		3 : non fonctionnel
            OldOperProg NUMBER;		-- ancien état opérationnel du programme
            ProgMsk	NUMBER;		-- Etat de masquage du programme :
              --		0 : non masqué
              --		1 : masquage brigadier
              --		2 : masquage administrateur

            ErrWarn	BOOLEAN;	-- TRUE si une erreur existe
            ErrMin	BOOLEAN;	-- TRUE si une erreur mineure existe
            ErrMaj	BOOLEAN;	-- TRUE si une erreur majeure existe
            ErrTs	BOOLEAN;	-- TRUE si tous les chemins sont coupés entre un des noeuds
					   --origine et un noeud destination
        */
		
        LProgNb	NUMBER;		/* Nb. de programmes correspondant à des liaisons en panne
				(mpx) */
        LPrOper	VARCHAR2 (900); /* Etat opérationnel de ces liaisons */

        LTypeq	VARCHAR2 (40);	/* Sauvegarde de TypEqu */
        LPoseq	VARCHAR2 (80);	/* Sauvegarde de Poseq */

        Buf		VARCHAR2 (100); -- banal
		
        CURSOR CurInclus is			-- les équipements inclus dans cet équipement
            select EQUIP_ID from EQUIP
                where EQUIP_BINDINGID = EquipId;

    BEGIN

        -- Mise à jour de l'état opérationnel de l'équipement

        Grave := get_grave_max (EquipId);
				
        -- Valeur de la gravité à prendre en compte en début d'alarme
        -- on regarde les autres alarmes
        -- on regarde les alarmes en cours sur cet équip.

        GraveI := alarme_geree.c_sans;
		
        Buf := parametre.get_valeur (parametre.c_parametres_client, parametre.c_str_alarm_englob);

        if Buf = spv_types.c_str_true then  -- il faut tenir compte des englobants / englobés
            for vInc in CurInclus loop
                GraveI := GREATEST (GraveI, maj_oper_inclus (Id, vInc.EQUIP_ID, AlarmGrave, AlarmLocal, infos_diag_table));
            end loop;
        end if;
        
        Grave := GREATEST (Grave, GraveI);
        
        CoeffOperElt := diagramme.calc_coeff_oper_elt(Grave, AlarmLocal);
        set_coeff_oper(EquipId, CoeffOperElt, infos_diag_table);
        
        RETURN Grave;

    END maj_oper_inclus;
    --===============================================================================
	
        
    --===============================================================================
    -- Calcul de coefficient opérationnel d'un équipement en tenant compte des inclus
    -- et des englobants
    PROCEDURE maj_oper_equip(Id NUMBER, EquipId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, 
                             is_commut spv_types.is_commut_t,
                             EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2,
                             EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
                             EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                             infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) IS
        /* Cette procédure met à jour l'état opérationnel de l'équipement en défaut,
            ainsi que l'état opérationnel des CABLEQU et des programmes que cela concerne.
            Tient compte des "sous-équipements" (ie. équipements inclus).
            Un "sous-équipement" n'est pas utilisé directement (on met un équipement dans un câblage).
            Un équipement peut être en panne parce que un de ses sous-équipements est en panne.
            FAUX - FAUX - FAUX !!!
            On met à jour l'état opérationnel des équipements qui contiennent celui-ci (OperEnglob).

            Lorsqu'un équipement est en panne, il faut donc mettre à jour immédiatement
            l'état opérationnel des équipements qui le concernent.
            AlarmGrave : gravité alarme */
		
        Grave           alarme_geree.gravite_t;		-- Gravité des alarmes restantes
        BindingId	NUMBER;                         -- Id de l'englobant de EquipId. 0 si fini
        Buf		VARCHAR2 (100);                 -- banal
        
    BEGIN

        -- Mise à jour de EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom
        -- Modif. JPB le 01/11/03. Voir remarque V 1.087
        select SITE.SITE_ID, SITE.SITE_NOM, TYPEQ_ID, TYPEQ_NOM, EquipId, GetEquipNom (EquipId, 1)
            into EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom
            from EQUIP, SITE
            where EQUIP_ID = EquipId and
            EQUIP.SITE_ID  = SITE.SITE_ID;

        -- Mise à jour de l'état opérationnel de l'équipement et des programmes qui l'utilisent
        if (is_commut = spv_types.c_commut) then
            Grave    := maj_oper_inclus (Id, EquipId, AlarmGrave, AlarmLocal, infos_diag_table);
            return;
        else
            Grave    := maj_oper_inclus (Id, EquipId, AlarmGrave, AlarmLocal, infos_diag_table);
        end if;

        -- Mise à jour de l'état opérationnel des équipements qui contiennent celui-ci
        -- Un seul niveau, car l'appel est récursif

        Buf := parametre.get_valeur(parametre.c_parametres_client, parametre.c_str_alarm_englob);
		
        if Buf = spv_types.c_str_true then	-- il faut tenir compte des englobants / englobés
            BindingId := get_id_pere(EquipId);

            if (BindingId IS NOT NULL) then
                oper_englob (Grave, BindingId, AlarmLocal, infos_diag_table);
            end if;
        end if;

    END maj_oper_equip;
    --===============================================================================
    
    
    --===============================================================================
    -- Calcul de coefficient opérationnel des équipements englobant
    PROCEDURE oper_englob (AlarmGrave NUMBER, EquipId NUMBER, AlarmLocal NUMBER,
                           infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)
    IS
	/* Signale à l'englobant un changement de l'état opérationnel d'un équipement inclus.
	Modifie en conséquence l'état opérationnel de l'englobant, afin que son affichage
	soit correct.

	AlarmGrave : gravité max. de l'équipement inclus (et de ses sous-équipements)
	EquipId	   : Id de l'englobant
	AlarmLocal : précise si l'alarme est locale ou vient du distant (SIA par exemple) */

        Grave       NUMBER;		-- Gravité des alarmes restantes
        
        -- Coefficient opérationnel de l'élément géré en cause
        CoeffOperElt	diagramme.etat_oper_t;
        BindingId   NUMBER;		-- Id de l'englobant de EquipId. 0 si fini

    BEGIN

        select MAX (ALARMGEREE_GRAVE) into Grave from ACCES_ACCESC_REP
            where EQUIP_ID = EquipId 
            and ALARM_ID is not NULL;
		-- Valeur de la gravité à prendre en compte en début d'alarme
		-- on regarde les alarmes en cours sur cet équip.
        Grave := NVL (Grave, 0);

        Grave := GREATEST (Grave, AlarmGrave);
        
        CoeffOperElt := diagramme.calc_coeff_oper_elt(Grave, AlarmLocal);
        set_coeff_oper(EquipId, CoeffOperElt, infos_diag_table);

        BindingId := 0;
        select EQUIP_BINDINGID into BindingId
            from EQUIP	where EQUIP_ID = EquipId;

        BindingId := NVL (BindingId, 0);

        if (BindingId > 0) then
            oper_englob (Grave, BindingId, AlarmLocal, infos_diag_table);
        end if;
    END   oper_englob;
    --===============================================================================
    
    
    
    --===============================================================================
    PROCEDURE init_oper_equips IS
        CURSOR CurEquip IS
          SELECT equip_id FROM equip ORDER BY equip_id;
        EltSiteId site.site_id%TYPE;
        EltSiteNom site.site_nom%TYPE;
        EltTypeId typeq.typeq_id%TYPE;
        EltTypeNom typeq.typeq_nom%TYPE;
        EltId equip.equip_id%TYPE;
        EltNom equip.site_equip_comment%TYPE;
        infos_diag_table diagramme.infos_diag_t;
    BEGIN
        FOR rCurEquip IN CurEquip LOOP
            infos_diag_table.DELETE;
            maj_oper_equip(NULL, rCurequip.equip_id, alarme_geree.c_locale, alarme_geree.c_sans,
                           spv_types.c_not_commut, EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, 
                           EltNom, infos_diag_table);
        END LOOP;
    END init_oper_equips;
    --===============================================================================
	
END equipement;
