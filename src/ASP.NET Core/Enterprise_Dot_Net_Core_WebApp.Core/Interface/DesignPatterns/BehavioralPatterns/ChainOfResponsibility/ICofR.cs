using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.ChainOfResponsibility
{
    public interface ICofR
    {
        void CofR(string Sequence, out List<Enterprise_MVC_Core> returnObj);

        void CofRByID(List<int> request, out List<Enterprise_MVC_Core> returnObj);
    }
}
