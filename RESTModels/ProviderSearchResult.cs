using Interfaces;
using DomainModels;
using System.Collections.Generic;

namespace RESTModels
{
    public class ProviderSearchResult : IServiceResult
    {
        public Dictionary<int, Provider>   Result { get; set; }

        public ProviderSearchResult()
        {
            Result = new Dictionary<int, Provider>();
        }
    }
}
