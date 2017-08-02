using System;

namespace QuickDictionary.Contracts.Entities
{
    public interface ILoggedEntity
    {
        int Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}
