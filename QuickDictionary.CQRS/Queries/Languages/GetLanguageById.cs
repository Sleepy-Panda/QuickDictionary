using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using System.Linq;

namespace QuickDictionary.CQRS.Queries.Languages
{
    public class GetLanguageById : IQuery<Language>
    {
        private readonly int _id;

        public GetLanguageById(int id)
        {
            _id = id;
        }

        public Language Execute(ISession session)
        {
            return session
                .Query<Language>(
                    "SELECT * " +
                    "FROM Languages " +
                    "WHERE Id = @Id", new { Id = _id })
                .FirstOrDefault();
        }
    }
}
