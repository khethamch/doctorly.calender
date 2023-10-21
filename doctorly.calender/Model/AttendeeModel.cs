using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctorly.calender.Model
{
    /// <summary>
    /// The model for the attendee, used to map data to and from the database
    /// </summary>
    public class AttendeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsAttending { get; set; }
    }
}
