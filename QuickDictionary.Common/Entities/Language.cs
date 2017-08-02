using QuickDictionary.Contracts.Entities;

namespace QuickDictionary.Common.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
