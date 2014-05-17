using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeUnknown.Models
{
    public class TimelineModel : RecordModel
    {
        DateTime BeginningYear { get; set; }

        Uri PictureURL { get; set; }
    }
}