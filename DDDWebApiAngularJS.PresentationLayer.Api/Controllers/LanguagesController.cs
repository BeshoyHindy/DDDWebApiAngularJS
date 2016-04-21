using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using DDDWebApiAngularJS.PresentationLayer.Api.Utils.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web.Http;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Controllers
{
    [RoutePrefix("api/languages")]
    public class LanguagesController : ApiController
    {
        [HttpGet]
        [Route("")]
        [DeflateCompression]
        public JArray Get()
        {
            ResourceSet resourceSet = Language.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            resourceSet.Cast<DictionaryEntry>().ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());

            return JArray.Parse(JsonConvert.SerializeObject(resourceSet));
        }
    }
}
