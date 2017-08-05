using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using System.Linq;

namespace QuickDictionary.CQRS.Queries.Dictionaries
{
    public class GetDictionaryById : IQuery<Dictionary>
    {
        private readonly int _id;

        public GetDictionaryById(int id)
        {
            _id = id;
        }

        public Dictionary Execute(ISession session)
        {
            return session
                .Query<Dictionary>(
                    "SELECT * " +
                    "FROM Dictionaries " +
                    "WHERE Id = @Id", new { Id = _id })
                .FirstOrDefault();
        }
    }
}
