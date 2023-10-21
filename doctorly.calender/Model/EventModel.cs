using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctorly.calender.Model
{
    /// <summary>
    /// The model for the events, used to map data to and from the database
    /// </summary>
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
