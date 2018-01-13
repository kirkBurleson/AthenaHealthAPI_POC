using System.Collections.Generic;
using RESTModels;
using Newtonsoft.Json.Linq;
using DomainModels;
using Interfaces;

namespace Mapping
{
    public class ProviderMapper
    {
        public static ProviderSearchResult MapJTokenToProviderSearchResult(JToken token)
        {
            var retval = new ProviderSearchResult();
            var providers = token["providers"];

            foreach (var x in providers)
            {
                retval.Result.Add((int)x["providerid"], new Provider(x));
            }

            return retval;
        }

        public static IEnumerable<int> MapProviderSearchResult_ProviderIds(IServiceResult input)
        {
            var items = input as ProviderSearchResult;
            IList<int> retval = new List<int>();

            foreach(var item in items.Result)
            {
                retval.Add(item.Key);
            }

            return retval;
        }
    }
}
