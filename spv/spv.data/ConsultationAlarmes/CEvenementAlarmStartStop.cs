using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    /*
    public class CEvenementAlarmStartStop
    {
        private CInfoAlarmeAffichee m_AlarmInfo = null;
        
        public CEvenementAlarmStartStop(string messalarmMessage, string separateur)            
        {
            m_AlarmInfo = new CInfoAlarmeAffichee(messalarmMessage, separateur);
        }

        public CInfoAlarmeAffichee AlarmInfo
        {
            get
            {
                return m_AlarmInfo;
            }
        }
    }*/

    public class CEvenementAlarmStartStop : CEvenementAlarm
    {
        public CEvenementAlarmStartStop(CMessageAlarmeNotification message)
            : base(message)
        {
        }

        public int IdEvtAlarme
        {
            get
            {
                return Message.IdEvtAlarme;
            }
        }

        public int IdAlarmData
        {
            get
            {
                return Message.IdAlarmData;
            }
        }

        public int IdAlarmeDebut
        {
            get
            {
                return Message.IdAlarmeDebut;
            }
        }


        public int IdAlarmeGeree
        {
            get
            {
                return Message.IdAlarmeGeree;
            }
        }

        public int? IdSite
        {
            get
            {
                return Message.IdSite;
            }
        }

        public int? IdEquipement
        {
            get
            {
                return Message.IdEquipement;
            }
        }

        public int? IdLiaison
        {
            get
            {
                return Message.IdLiaison;
            }
        }

        public string NomAlarmeGeree
        {
            get
            {
                return Message.NomAlarmeGeree;
            }
        }

        public ETypeObjetEnAlarme TypeObjetEnAlarme
        {
            get
            {
                return Message.TypeObjetEnAlarme;
            }
        }

        public EGraviteAlarmeAvecMasquage Gravite
        {
            get
            {
                return Message.GraviteAlarme;
            }
        }

        public string Commentaire
        {
            get
            {
                return Message.Commentaire;
            }
        }

        public string ClasseAlarme
        {
            get
            {
                return Message.ClasseAlarme;
            }
        }

        public int NumeroObjetDeCollecteOuTrap
        {
            get
            {
                return Message.NumeroObjetDeCollecteOuTrap;
            }
        }

        public EAlarmEvent TypeEvenementAlarme
        {
            get
            {
                return Message.TypeEvenementAlarme;
            }
        }

        public DateTime DateEvenementAlarme
        {
            get
            {
                return Message.DateEvenementAlarme;
            }
        }

        public string NomSeuil
        {
            get
            {
                return Message.NomSeuil;
            }
        }

        public int ValeurSeuil
        {
            get
            {
                return Message.ValeurSeuil;
            }
        }

        public string NumeroSortieAlarmeOuIP
        {
            get
            {
                return Message.NumeroSortieAlarmeOuIP;
            }
        }

        public EAlarmNature NatureAlarme
        {
            get
            {
                return Message.NatureAlarme;
            }
        }

        public string InfoAdditionnelle
        {
            get
            {
                return Message.InfoAdditionnelle;
            }
        }

        public bool AAcquitter
        {
            get
            {
                return Message.AAcquitter;
            }
        }

        public bool Sonner
        {
            get
            {
                return Message.Sonner;
            }
        }

        public ETypeSon TypeSonnerie
        {
            get
            {
                return Message.TypeSonnerie;
            }
        }

        public bool EstPositionCommutateur
        {
            get
            {
                return Message.EstPositionCommutateur;
            }
        }

        public string NomSite
        {
            get
            {
                return Message.NomSite;
            }
        }

        public string NomTypeObjet
        {
            get
            {
                return Message.NomTypeObjet;
            }
        }

        public string NomObjet
        {
            get
            {
                return Message.NomObjet;
            }
        }

        public string[] ServicesConcernes
        {
            get
            {
                return Message.ServicesConcernes;
            }
        }

        public int[] IdServicesConcernes
        {
            get
            {
                return Message.IdServicesConcernes;
            }
        }

        public string[] ClientsConcernes
        {
            get
            {
                return Message.ClientsConcernes;
            }
        }

        public double[] EtatServices
        {
            get
            {
                return Message.EtatServices;
            }
        }

        public string EtatsServices
        {
            get
            {
                return Message.EtatsServices;
            }
        }

        public string[] VariablesTrap
        {
            get
            {
                return Message.VariablesTrap;
            }
        }
    }
}
