using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.ComponentModel;

namespace timos.supervision
{
    public class CBackgroundWorkerAvecProgress : BackgroundWorker,IIndicateurProgression
    {
        private CConteneurIndicateurProgression m_indicateur = null;

        public CBackgroundWorkerAvecProgress(IIndicateurProgression indicateur)
        {
            m_indicateur = CConteneurIndicateurProgression.GetConteneur(indicateur);
        }


        //-----------------------------------
        public bool CanCancel
        {
            get
            {
                return m_indicateur.CanCancel;
            }
            set
            {
                m_indicateur.CanCancel = value;
            }
        }

        //-----------------------------------
        public bool CancelRequest
        {
            get { return m_indicateur.CancelRequest; }
        }

        //-----------------------------------
        public void Masquer(bool bMasquer)
        {
            m_indicateur.Masquer(bMasquer);
        }

        //-----------------------------------
        public void PopLibelle()
        {
            m_indicateur.PopLibelle();
        }

        //-----------------------------------
        public void PopSegment()
        {
            m_indicateur.PopSegment();
        }

        //-----------------------------------
        public void PushLibelle(string strInfo)
        {
            m_indicateur.PushLibelle(strInfo);
        }

        //-----------------------------------
        public void PushSegment(int nMin, int nMax)
        {
            m_indicateur.PushSegment(nMin, nMax);
        }

        //-----------------------------------
        public void SetBornesSegment(int nMin, int nMax)
        {
            m_indicateur.SetBornesSegment(nMin, nMax);
        }

        //-----------------------------------
        public void SetInfo(string strInfo)
        {
            m_indicateur.SetInfo(strInfo);
        }

        //-----------------------------------
        public void SetValue(int nValue)
        {
            m_indicateur.SetValue(nValue);
        }

    }
}
