using GoogleSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Umbraco.Cms.Web.Common.Controllers;
using System.Net.Http;
using Umbraco.Cms.Core.Models.Membership;

namespace GoogleSearch.Controllers
{
    public class GoogleSearchController : UmbracoApiController
    {
        [HttpGet]
        public List<GetJsonMapping> GetData(string? search)
        {
            using (StreamReader r = new StreamReader("HardCodedData/searchData.json"))
            {
                if (search == null)
                {
                    return new List<GetJsonMapping>();
                }
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<List<GetJsonMapping>>(json);
                item = item?.Where(i => i.Title.ToLower().Contains(search.ToLower()) 
                                        || i.Body.ToLower().Contains(search.ToLower())).ToList();
                return item ?? new List<GetJsonMapping>();
            }
        }
    }
}
