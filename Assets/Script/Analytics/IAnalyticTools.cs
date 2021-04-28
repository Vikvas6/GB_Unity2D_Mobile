using System.Collections.Generic;

namespace Game.Analytic
{
    public interface IAnalyticTools
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}