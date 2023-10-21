using Dapper;
using doctorly.calender.Model;
using doctorly.calender.SqlQueries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace doctorly.calender.Services
{
    public class EventService : IEvent
    {
        private IDatabaseHandler _database;

        public EventService(IDatabaseHandler database)
        {
            _database = database;
        }

        public async Task CreateEvent(EventModel eventModel)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            await connection.QueryAsync(EventQuery.CreateEvent,
                new
                {
                    Title = eventModel.Title,
                    Description = eventModel.Description,
                    StartTime = eventModel.StartTime,
                    EndTime = eventModel.EndTime,
                }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
        }

        public async Task DeleteEvent(int eventId)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            await connection.QueryAsync(EventQuery.DeleteEvent, new { Id = eventId }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
        }

        public async Task<EventModel> GetEvent(int eventId)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            var eventModel = await connection.QueryFirstAsync<EventModel>(EventQuery.GetEvent, new { Id = eventId }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
            return eventModel;
        }

        public async Task<IEnumerable<EventModel>> GetEvents(string search)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            var eventModels = await connection.QueryAsync<EventModel>(EventQuery.GetEvents, new { Search = search }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
            return eventModels;
        }

        public async Task UpdateEvent(EventModel eventModel)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            await connection.QueryAsync(EventQuery.UpdateEvent,
                new
                {
                    Id = eventModel.Id,
                    Title = eventModel.Title,
                    Description = eventModel.Description,
                    StartTime = eventModel.StartTime,
                    EndTime = eventModel.EndTime,
                }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
        }

        public async Task CancelEvent(int eventId)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            await connection.QueryAsync(EventQuery.CancelEvent, new { Id = eventId }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
        }

        public async Task<IEnumerable<AttendeeModel>> GetEventAttendees(int eventId)
        {
            var connection = _database.GetDbConnection();
            connection.Open();
            var attendees = await connection.QueryAsync<AttendeeModel>(EventQuery.GetEventAttendees, new { Id = eventId }, commandTimeout: 600).ConfigureAwait(false);
            connection.Close();
            return attendees;
        }
    }
}
