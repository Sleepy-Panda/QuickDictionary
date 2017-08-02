using QuickDictionary.Common.Entities;
using QuickDictionary.Contracts.CQRS;
using System.Collections.Generic;
using System.Linq;

namespace QuickDictionary.CQRS.Queries.Dictionaries
{
    public class GetAllDictionaries: IQuery<IList<Dictionary>>
    {
        public IList<Dictionary> Execute(ISession session)
        {
            return session
                .Query<Dictionary>("SELECT * FROM Dictionaries")
                .ToList();
        }
    }
}
