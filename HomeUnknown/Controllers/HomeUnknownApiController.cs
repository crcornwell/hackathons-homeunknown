﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using HomeUnknown.Models;
using System.Data.SqlClient;

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
            timelines.Add(new TimelineModel(DateTime.Now, new Uri("http://www.test.com/test"), Guid.NewGuid(), "Test"));
            timelines.Add(new TimelineModel(DateTime.Now.AddYears(1), new Uri("http://www.comp.com/test"), Guid.NewGuid(), "Name"));

            return timelines;
        }

        [HttpGet]
        [Route("events/{timelineId}")]
        public string GetEvents(Guid timelineId)
        {
            List<EventModel> events = null;

            HomeUnknownEntities entityHelper = new HomeUnknownEntities();

            var timelineEventsFromDb = entityHelper.sp_sel_TimelineEvents_SelectByTimeline(timelineId);

            if (timelineEventsFromDb != null)
            {
                foreach (var timelineEvent in timelineEventsFromDb)
                {
                    if (events == null)
                    {
                        events = new List<EventModel>();
                    }

                    EventModel model = new EventModel();
                    model.Id = timelineEvent.Event_PK;
                    model.Name = timelineEvent.EventName;
                    model.Location = timelineEvent.EventLocation;
                    model.Year = timelineEvent.EventYear;
                    model.TimelineId = timelineId;

                    events.Add(model);
                }
            }
            return JsonConvert.SerializeObject(events);
        }

        [HttpGet]
        [Route("contents/{eventId}")]
        public string GetContents(Guid eventId)
        {
            List<ContentModel> contents = null; // GetFromSQL(eventId);

            HomeUnknownEntities entityHelper = new HomeUnknownEntities();

            var eventContent = entityHelper.sp_sel_EventContent(eventId);

            if (eventContent != null)
            {
                foreach (var media in eventContent)
                {
                    if (contents == null)
                    {
                        contents = new List<ContentModel>();
                    }

                    ContentModel model = new ContentModel();

                    model.Id = media.Content_PK;
                    model.Name = media.ContentName;
                    model.ContentURL = new Uri(media.ContentURL);
                    model.NoteText = media.ContentText;
                    model.ContentType = (ContentType)media.ContentType;
                    model.EventId = eventId;

                    contents.Add(model);
                }
            }
            return JsonConvert.SerializeObject(contents);
        }

        [HttpGet]
        [Route("content/{contentId}")]
        public string GetMedia(Guid contentId)
        {
            ContentModel model = null;

            HomeUnknownEntities entityHelper = new HomeUnknownEntities();

            var singleMedia = entityHelper.sp_sel_SingleMedia(contentId);

            if (singleMedia != null)
            {
                model = new ContentModel();

                model.Id = contentId;
                model.Name = singleMedia.First().ContentName;
                model.ContentURL = new Uri(singleMedia.First().ContentURL);
                model.EventId = singleMedia.First().Event_PK;
                model.NoteText = singleMedia.First().ContentText;
                model.ContentType = (ContentType)singleMedia.First().ContentType;
            }
            return JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        [Route("events")]
        public HttpResponseMessage InsertEvent(EventModel model)
        {
            HttpResponseMessage resp = new HttpResponseMessage();

            if (!ModelState.IsValid)
            {
                resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ModelState is invalid");
            }
            else
            {
                try
                {
                    HomeUnknownEntities entityHelper = new HomeUnknownEntities();
                    entityHelper.sp_ins_TimelineEvent(model.TimelineId, model.Name, model.Location, model.Year);

                    resp = Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    resp = Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex);
                }
            }

            return resp;
        }

        public HttpResponseMessage InsertContent(ContentModel model)
        {
            HttpResponseMessage resp = new HttpResponseMessage();

            if (!ModelState.IsValid)
            {
                resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ModelState is invalid");
            }
            else
            {
                try
                {
                    HomeUnknownEntities entityHelper = new HomeUnknownEntities();
                    entityHelper.sp_ins_EventContent(model.EventId, model.Name, model.NoteText, (int)model.ContentType, model.ContentURL.ToString());

                    resp = Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    resp = Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex);
                }
            }

            return resp;
        }

    }
}
