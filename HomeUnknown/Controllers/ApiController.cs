using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace HomeUnknown.Controllers
{
    [RoutePrefix("api")]
    public class ApiController : ApiController
    {
        [HttpGet]
        [Route("timelines/{familyId}")]
        public string Get(Guid familyID)
        {
            List<Timeline> timelines = GetFromSQL(familyID);
            return JsonConvert.SerializeObject(timelines);
        }

        [HttpGet]
        [Route("events/{timelineId")]
        public string Get(Guid timelineId)
        {
            List<Event> events = GetFromSQL(timelineId);
            return JsonConvert.SerializeObject(events);
        }

        [HttpGet]
        [Route("contents/{eventId")]
        public string Get(Guid eventId)
        {
            List<Content> contents = GetFromSQL(eventId);
            return JsonConvert.SerializeObject(contents);
        }



    }
}
