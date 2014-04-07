using System.Collections.Generic;
using Sumo.Api;

namespace DBMetaManager
{
    public class SessionStorage
    {
        private readonly Dictionary<int, ISession> _sessions = new Dictionary<int, ISession>();
        
        private int _nextSessionId;

        public int AddSession(ISession session)
        {
            int sessionId;

            lock (this)
            {
                sessionId = _nextSessionId++;
                _sessions.Add(sessionId, session);
            }

            return sessionId;
        }

        public void RemoveSession(SumoSession session)
        {
            lock (this)
                _sessions.Remove(session.SessionId);
        }

        public ISession GetSession(int sessionId)
        {
            lock (this)
            {
                if (!_sessions.ContainsKey(sessionId))
                    return NullSession.Instance;

                return _sessions[sessionId];
            }
        }
    }
}