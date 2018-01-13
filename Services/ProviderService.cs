using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Interfaces;
using System;
using Mapping;

namespace Services
{
    public class ProviderService : IProviderService
    {
        private APIConnection api;

        public ProviderService()
        {
            api = new APIConnection();
        }

        public IServiceResult Create(IServiceInput input)
        {
            throw new NotImplementedException();
        }
        public IServiceResult Search(IServiceInput input)
        {
            JToken providers = GetProviders();
            return ProviderMapper.MapJTokenToProviderSearchResult(providers);
        }
        public IServiceResult Update(IServiceInput input)
        {
            throw new NotImplementedException();
        }

        private JToken GetProviders()
        {
            var postData = new Dictionary<string, string>();
            var restUrl = "/providers";

            JToken action = api.GET(restUrl, postData);

            return action;
        }
    }
}
