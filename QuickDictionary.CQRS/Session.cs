using Dapper;
using QuickDictionary.Contracts.CQRS;
using System.Collections.Generic;

namespace QuickDictionary.CQRS
{
    public class Session : ISession
    {
        private readonly IDapperContext _context;

        public Session(IDapperContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object parameters)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Query<T>(query, parameters, transaction);

                return result;
            });
        }

        public void Execute(string sql, object parameters)
        {
            _context.Transaction(transaction => _context.Connection.Execute(sql, parameters, transaction));
        }
    }
}
