using System.Collections.Generic;

namespace Game.Analytic
{
    internal interface IAnalyticTools
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}