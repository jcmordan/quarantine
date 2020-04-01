using System;

namespace Quarantine.Core.Models
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}