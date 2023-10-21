using Dapper;
using doctorly.calender.Model;
using doctorly.calender.SqlQueries;
using System.Threading.Tasks;

namespace doctorly.calender.Services
{
    public class AttendeeService : IAttendee
    {
        private readonly IDatabaseHandler _database;

        public AttendeeService(IDatabaseHandler _database)
        {
            this._database = _database;
        }

        public async Task ConfirmAttendingEvent(int eventId, int attendeeId, bool isAttending)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            await connection.QueryAsync(AttendeeQuery.ConfirmAttendingEvent, new { EventId = eventId, AttendeeId = attendeeId, IsAttending = !isAttending ? "0" : "1" }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
        }

        public async Task CreateAttendee(AttendeeModel attendee)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            await connection.QueryAsync(AttendeeQuery.CreateAttendee, new { Name = attendee.Name, Email = attendee.Email, Address = attendee.Address }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
        }
    }
}
