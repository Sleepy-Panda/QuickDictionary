using System.Collections.Generic;

namespace QuickDictionary.Contracts.CQRS
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object parameters = null);

        void Execute(string query, object parameters = null);

        T ExecuteScalar<T>(string sql, object parameters);
    }
}
