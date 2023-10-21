using doctorly.calender.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace doctorly.calender.Services
{
    public interface IEvent
    {
        Task CreateEvent(EventModel eventModel);
        Task UpdateEvent(EventModel eventModel);
        Task DeleteEvent(int eventId);
        Task<EventModel> GetEvent(int eventId);
        Task<IEnumerable<EventModel>> GetEvents(string search);
        Task CancelEvent(int eventId);
        Task<IEnumerable<AttendeeModel>> GetEventAttendees(int eventId);
    }
}
