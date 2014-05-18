using HomeUnknown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeUnknown.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult InputEvent()
        {
            return View();
        }

        public ActionResult InputContent(Guid id)
        {
            ContentModel model = new ContentModel();

            model.EventId = id;

            return View(model);
        }

        public ActionResult EventDisplay()
        {
            List<EventModel> eventList = null;
            
            HomeUnknownEntities entityHelper = new HomeUnknownEntities();

            var eventResults = entityHelper.sp_sel_TimelineEvents_SelectByTimeline(Guid.Parse("06AE6ABB-0296-4F10-B6AF-3B13FE9B4FCF"));

            if(eventResults != null)
            {
                foreach(var item in eventResults)
                {
                    if(eventList == null)
                    {
                        eventList = new List<EventModel>();
                    }

                    EventModel singleEvent = new EventModel();

                    singleEvent.Id = item.Event_PK;
                    singleEvent.Name = item.EventName;
                    singleEvent.Location = item.EventLocation;
                    singleEvent.Year = item.EventYear;
                    singleEvent.TimelineId = Guid.Parse("06AE6ABB-0296-4F10-B6AF-3B13FE9B4FCF");

                    eventList.Add(singleEvent);
                }
            }
            return View(eventList.OrderBy(x => x.Year).ToList());
        }
    }
}