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
    public class HomeUnknownApiController : ApiController
    {
        [HttpGet]
        [Route("timelines/{familyId}")]
        public string GetTimelines()
        {
            //List<TimelineModel> timelines = GetFromSQL(familyID);

            List<TimelineModel> timelines = new List<TimelineModel>();
            timelines.Add(new TimelineModel(DateTime.Now, new Uri("http://www.test.com/test"), new Guid(), "Test"));
            timelines.Add(new TimelineModel(DateTime.Now, new Uri("http://www.test.com/test"), new Guid(), "Name"));

            return JsonConvert.SerializeObject(timelines);
        }

        [HttpGet]
        [Route("events/{timelineId}")]
        public string GetEvents(Guid timelineId)
        {
            List<EventModel> events = new List<EventModel>();//GetFromSQL(timelineId);
            return JsonConvert.SerializeObject(events);
        }

        [HttpGet]
        [Route("contents/{eventId}")]
        public string GetContents(Guid eventId)
        {
            List<ContentModel> contents = new List<ContentModel>(); // GetFromSQL(eventId);
            return JsonConvert.SerializeObject(contents);
        }



    }
}
