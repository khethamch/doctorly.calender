namespace doctorly.calender.SqlQueries
{
    public static class EventQuery
    {
        public const string CreateEvent = @"INSERT INTO [dbo].[Events]
           ([Title]
           ,[Description]
           ,[StartTime]
           ,[EndTime]
           ,[IsCancelled])
     VALUES
           (@Title
           ,@Description
           ,@StartTime
           ,@EndTime
           ,0)";

        public const string UpdateEvent = @"UPDATE [dbo].[Events]
   SET [Title] = @Title
      ,[Description] = @Description
      ,[StartTime] = @StartTime
      ,[EndTime] = @EndTime
 WHERE [Id] = @Id";

        public const string DeleteEvent = @"DELETE FROM [dbo].[Events] WHERE [Id] = @Id";

        public const string GetEvent = @"SELECT [Id]
      ,[Title]
      ,[Description]
      ,[StartTime]
      ,[EndTime]
      ,[IsCancelled]
  FROM [dbo].[Events]
  WHERE [Id] = @Id";

        public const string GetEvents = @"SELECT [Id]
      ,[Title]
      ,[Description]
      ,[StartTime]
      ,[EndTime]
      ,[IsCancelled]
  FROM [dbo].[Events]
  WHERE [IsCancelled] = 0
  AND [Title] LIKE '%' + ISNULL(@Search, '') + '%'
  AND [Description] LIKE '%' + ISNULL(@Search, '') + '%'";

        public const string CancelEvent = @"UPDATE [dbo].[Events]
   SET [IsCancelled] = 1
 WHERE [Id] = @Id";

        public const string GetEventAttendees = @"SELECT a.[Id]
      ,a.[Name]
      ,a.[Email]
      ,a.[Address]
      ,a.[IsAttending]
  FROM [dbo].[Attendees] a
  INNER JOIN [dbo].[EventAttendees] ea ON ea.[AttendeeId] = a.[Id]
  WHERE ea.[EventId] = @Id";
    }
}
