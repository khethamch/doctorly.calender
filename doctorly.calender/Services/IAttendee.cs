using doctorly.calender.Model;
using System.Threading.Tasks;

namespace doctorly.calender.Services
{
    public interface IAttendee
    {
        Task CreateAttendee(AttendeeModel attendee);
        Task ConfirmAttendingEvent(int eventId, int attendeeId, bool isAttending);
    }
}
