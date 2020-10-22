using System;

namespace DeleteBoilerplate.Domain.Models.BaseModels
{
    public interface IViewModel
    {
        public Guid NodeGuid { get; set; }
    }
}
