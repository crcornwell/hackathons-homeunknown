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
        public List<TimelineModel> GetTimelines()
        {
            //List<TimelineModel> timelines = GetFromSQL(familyID);

            List<TimelineModel> timelines = new List<TimelineModel>();
            timelines.Add(new TimelineModel(DateTime.Now, new Uri("http://homeunknown.collabaxis.com/profilepics/lucilaprofile.jpg"), Guid.NewGuid(), "Lucila"));
            timelines.Add(new TimelineModel(DateTime.Now.AddYears(1), new Uri("http://homeunknown.collabaxis.com/profilepics/oscarprofile.jpg"), Guid.NewGuid(), "Oscar"));

            return timelines;
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
