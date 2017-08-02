using QuickDictionary.Contracts.Entities;

namespace QuickDictionary.Common.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }
    }
}
