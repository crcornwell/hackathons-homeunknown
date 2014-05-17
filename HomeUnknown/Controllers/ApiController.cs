using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using HomeUnknown.Models;

namespace HomeUnknown.Controllers
{
    [RoutePrefix("api")]
    public class ApiController : ApiController
    {
        [HttpGet]
        [Route("timelines/{familyId}")]
        public string Get(Guid familyID)
        {
            List<TimelineModel> timelines = GetFromSQL(familyID);
            return JsonConvert.SerializeObject(timelines);
        }

        [HttpGet]
        [Route("events/{timelineId")]
        public string Get(Guid timelineId)
        {
            List<EventModel> events = GetFromSQL(timelineId);
            return JsonConvert.SerializeObject(events);
        }

        [HttpGet]
        [Route("contents/{eventId")]
        public string Get(Guid eventId)
        {
            List<ContentModel> contents = GetFromSQL(eventId);
            return JsonConvert.SerializeObject(contents);
        }



    }
}
